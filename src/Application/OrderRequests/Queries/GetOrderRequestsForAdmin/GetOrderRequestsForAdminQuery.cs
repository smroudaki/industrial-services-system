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

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestsForAdmin
{
    public class GetOrderRequestsForAdminQuery : IRequest<GetOrderRequestsForAdminVm>
    {
        public Guid? UserGuid { get; set; }

        public Guid? OrderGuid { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetOrderRequestsForAdminQuery, GetOrderRequestsForAdminVm>
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

            public async Task<GetOrderRequestsForAdminVm> Handle(GetOrderRequestsForAdminQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new GetOrderRequestsForAdminVm()
                {
                    Message = "کاربر لاگین شده یافت نشد",
                    State = (int)GetOrderRequestsForAdminState.CurrentUserNotFound
                };

                Admin admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (admin == null) return new GetOrderRequestsForAdminVm()
                {
                    Message = "ادمین لاگین شده یافت نشد",
                    State = (int)GetOrderRequestsForAdminState.AdminNotFound
                };

                IQueryable<OrderRequest> orderRequests = _context.OrderRequest
                    .Where(x => !x.IsDelete && !x.Order.IsDelete)
                    .AsQueryable();

                if (request.UserGuid != null)
                {
                    User user = await _context.User
                    .Where(x => x.UserGuid == request.UserGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                    if (user == null) return new GetOrderRequestsForAdminVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetOrderRequestsForAdminState.UserNotFound
                    };

                    orderRequests = orderRequests.Where(x => x.Contractor.UserId == user.UserId);
                }

                if (request.OrderGuid != null)
                {
                    Order order = await _context.Order
                        .Where(x => x.OrderGuid == request.OrderGuid)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (order == null) return new GetOrderRequestsForAdminVm()
                    {
                        Message = "سفارش مورد نظر یافت نشد",
                        State = (int)GetOrderRequestsForAdminState.OrderNotFound
                    };

                    orderRequests = orderRequests.Where(x => x.OrderId == order.OrderId);
                }

                var orderRequestsRes = await orderRequests
                    .ProjectTo<GetOrderRequestsForAdminDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (orderRequestsRes.Count <= 0)
                {
                    return new GetOrderRequestsForAdminVm()
                    {
                        Message = "درخواست سفارشی برای کاربر مورد نظر یافت نشد",
                        State = (int)GetOrderRequestsForAdminState.NotAnyOrderRequestsFound
                    };
                }

                return new GetOrderRequestsForAdminVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrderRequestsForAdminState.Success,
                    OrderRequests = orderRequestsRes
                };
            }
        }
    }
}
