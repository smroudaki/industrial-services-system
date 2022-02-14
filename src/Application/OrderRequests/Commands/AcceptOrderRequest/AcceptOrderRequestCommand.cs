using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Accounts.Commands.RegisterClient;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;

namespace IndustrialServicesSystem.Application.OrderRequests.Commands.AcceptOrderRequest
{
    public class AcceptOrderRequestCommand : IRequest<AcceptOrderRequestVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public bool IsAccept { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<AcceptOrderRequestCommand, AcceptOrderRequestVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public CreateOrderCommandHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUser = currentUserService;
            }

            public async Task<AcceptOrderRequestVm> Handle(AcceptOrderRequestCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier) && !x.IsDelete)
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new AcceptOrderRequestVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)AcceptOrderRequestState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null) return new AcceptOrderRequestVm
                {
                    Message = "سرویس گیرنده مورد نظر یافت نشد",
                    State = (int)AcceptOrderRequestState.ClientNotFound
                };

                OrderRequest orderRequest = await _context.OrderRequest
                    .Include(x => x.Order)
                    .SingleOrDefaultAsync(x => x.OrderRequestGuid == request.OrderRequestGuid && !x.IsDelete, cancellationToken);

                if (orderRequest == null) return new AcceptOrderRequestVm
                {
                    Message = "درخواست سفارش مورد نظر یافت نشد",
                    State = (int)AcceptOrderRequestState.OrderRequestNotFound
                };

                switch (orderRequest.Order.StateCodeId)
                {
                    case 11:
                        return new AcceptOrderRequestVm
                        {
                            Message = "سفارش مورد نظر به اتمام رسیده است",
                            State = (int)AcceptOrderRequestState.OrderDoneBefore
                        };

                    case 12:
                        return new AcceptOrderRequestVm
                        {
                            Message = "سفارش مورد نظر لغو شده است",
                            State = (int)AcceptOrderRequestState.OrderCancelledBefore
                        };
                }

                if (!orderRequest.IsAllow) return new AcceptOrderRequestVm
                {
                    Message = "سفارش مورد نظر تایید نشده است",
                    State = (int)AcceptOrderRequestState.OrderRequestNotAllowed
                };

                orderRequest.StateCodeId = request.IsAccept ? 18 : 20;
                orderRequest.ModifiedDate = DateTime.Now;
                orderRequest.Order.StateCodeId = request.IsAccept ? 10 : 12;
                orderRequest.Order.ContractorId = orderRequest.ContractorId;

                await _context.SaveChangesAsync(cancellationToken);

                return new AcceptOrderRequestVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)AcceptOrderRequestState.Success
                };
            }
        }
    }
}
