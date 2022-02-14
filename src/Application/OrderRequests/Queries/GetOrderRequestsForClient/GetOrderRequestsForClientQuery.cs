using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestsForClient
{
    public class GetOrderRequestsForClientQuery : IRequest<GetOrderRequestsForClientVm>
    {
        public Guid? OrderGuid { get; set; }

        public Guid? StateGuid { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetOrderRequestsForClientQuery, GetOrderRequestsForClientVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public OrdersListQueryHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUserService;
                _mapper = mapper;
            }

            public async Task<GetOrderRequestsForClientVm> Handle(GetOrderRequestsForClientQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new GetOrderRequestsForClientVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)GetOrderRequestsForClientState.UserNotFound
                };

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null) return new GetOrderRequestsForClientVm()
                {
                    Message = "سرویس گیرنده مورد نظر یافت نشد",
                    State = (int)GetOrderRequestsForClientState.ClientNotFound
                };

                IQueryable<OrderRequest> orderRequests = _context.OrderRequest
                    .Where(x => !x.IsDelete && !x.Order.IsDelete);

                if (request.OrderGuid == null)
                {
                    orderRequests = orderRequests.Where(x => x.Order.ClientId == client.ClientId);
                }
                else
                {
                    Order order = await _context.Order
                        .Where(x => x.OrderGuid == request.OrderGuid)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (order == null) return new GetOrderRequestsForClientVm()
                    {
                        Message = "سفارش مورد نظر یافت نشد",
                        State = (int)GetOrderRequestsForClientState.OrderNotFound
                    };

                    orderRequests = orderRequests.Where(x => x.OrderId == order.OrderId);
                }

                if (request.StateGuid != null)
                {
                    Code state = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.StateGuid, cancellationToken);

                    if (state == null)
                    {
                        return new GetOrderRequestsForClientVm()
                        {
                            Message = "وضعیت مورد نظر یافت نشد",
                            State = (int)GetOrderRequestsForClientState.StateNotFound
                        };
                    }

                    orderRequests = orderRequests.Where(x => x.Order.StateCodeId == state.CodeId);
                }

                var orderRequestRes = await orderRequests
                    .OrderByDescending(x => x.CreationDate)
                    .ProjectTo<GetOrderRequestsForClientDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (orderRequestRes.Count <= 0)
                {
                    return new GetOrderRequestsForClientVm()
                    {
                        Message = "درخواست سفارشی برای سفارش مورد نظر یافت نشد",
                        State = (int)GetOrderRequestsForClientState.NotAnyOrderRequestsFound
                    };
                }

                return new GetOrderRequestsForClientVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrderRequestsForClientState.Success,
                    OrderRequests = orderRequestRes
                };
            }
        }
    }
}
