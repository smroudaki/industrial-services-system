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

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestFinishingStatus
{
    public class GetOrderRequestFinishingStatusQuery : IRequest<GetOrderRequestFinishingStatusVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public class GetOrderRequestFinishingStatusQueryHandler : IRequestHandler<GetOrderRequestFinishingStatusQuery, GetOrderRequestFinishingStatusVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public GetOrderRequestFinishingStatusQueryHandler(IIndustrialServicesSystemContext context,
                ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUser = currentUserService;
            }

            public async Task<GetOrderRequestFinishingStatusVm> Handle(GetOrderRequestFinishingStatusQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetOrderRequestFinishingStatusVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAccessStatusState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null)
                {
                    return new GetOrderRequestFinishingStatusVm()
                    {
                        Message = "سرویس گیرنده مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAccessStatusState.ClientNotFound
                    };
                }

                OrderRequest orderRequest = await _context.OrderRequest
                    .Include(x => x.Order)
                    .Where(x => x.OrderRequestGuid == request.OrderRequestGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (orderRequest == null)
                {
                    return new GetOrderRequestFinishingStatusVm()
                    {
                        Message = "درخواست سفارش مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAccessStatusState.OrderRequestNotFound
                    };
                }

                return new GetOrderRequestFinishingStatusVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrderRequestAccessStatusState.Success,
                    FinishingStatus = orderRequest.Order.StateCodeId == 11
                };
            }
        }
    }
}
