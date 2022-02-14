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

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetChatRooms
{
    public class GetChatRoomsQuery : IRequest<GetChatRoomsVm>
    {
        public string Search { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetChatRoomsQuery, GetChatRoomsVm>
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

            public async Task<GetChatRoomsVm> Handle(GetChatRoomsQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetChatRoomsVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetChatRoomState.UserNotFound
                    };
                }

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null)
                {
                    return new GetChatRoomsVm()
                    {
                        Message = "سرویس دهنده مورد نظر یافت نشد",
                        State = (int)GetChatRoomState.ContractorNotFound
                    };
                }

                IQueryable<OrderRequest> orderRequests = _context.OrderRequest.AsQueryable()
                    .Where(x => x.ContractorId == contractor.ContractorId && x.IsAllow && !x.IsDelete && !x.Order.IsDelete);

                if (!string.IsNullOrEmpty(request.Search))
                {
                    orderRequests = orderRequests.Where(x => x.Order.Title.Contains(request.Search));
                }

                List<GetChatRoomsDto> orderRequestsRes = await orderRequests
                    .OrderByDescending(x => x.CreationDate)
                    .ProjectTo<GetChatRoomsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (orderRequestsRes.Count <= 0)
                {
                    return new GetChatRoomsVm()
                    {
                        Message = "درخواست سفارشی برای کاربر مورد نظر یافت نشد",
                        State = (int)GetChatRoomState.NotAnyChatRoomsFound
                    };
                }

                return new GetChatRoomsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetChatRoomState.Success,
                    ChatRooms = orderRequestsRes
                };
            }
        }
    }
}
