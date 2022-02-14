using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetChatMessages
{
    public class GetChatMessagesQuery : IRequest<GetChatMessagesVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetChatMessagesQuery, GetChatMessagesVm>
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

            public async Task<GetChatMessagesVm> Handle(GetChatMessagesQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetChatMessagesVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetMessagesState.UserNotFound
                    };
                }

                OrderRequest orderRequest = await _context.OrderRequest
                    .Include(x => x.Contractor)
                    .ThenInclude(x => x.User)
                    .ThenInclude(x => x.Role)
                    .Where(x => x.OrderRequestGuid == request.OrderRequestGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (orderRequest == null) return new GetChatMessagesVm()
                {
                    Message = "درخواست سفارش مورد نظر یافت نشد",
                    State = (int)GetMessagesState.OrderRequestNotFound
                };

                GetChatMessagesDto chatMessage = new GetChatMessagesDto
                {
                    From = orderRequest.Contractor.User.Role.DisplayName,
                    Text = orderRequest.Message,
                    SentAt = PersianDateExtensionMethods.ToPeString(orderRequest.ModifiedDate, "yyyy/MM/dd HH:mm")
                };

                List<GetChatMessagesDto> chatMessages = await _context.ChatMessage
                   .Where(x => x.OrderRequestId == orderRequest.OrderRequestId)
                   .OrderBy(x => x.SentAt)
                   .ProjectTo<GetChatMessagesDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

                chatMessages.Insert(0, chatMessage);

                //if (chatMessages.Count <= 1)
                //{
                //    return new GetChatMessagesVm()
                //    {
                //        Message = "تاریخچه ای یافت نشد",
                //        State = (int)GetMessagesState.NotAnyChatMessagesFound,
                //        ChatMessages = chatMessages
                //    };
                //}

                return new GetChatMessagesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetMessagesState.Success,
                    ChatMessages = chatMessages
                };
            }
        }
    }
}
