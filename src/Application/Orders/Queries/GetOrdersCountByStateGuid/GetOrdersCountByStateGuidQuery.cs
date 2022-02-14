using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Orders.Queries.GetOrdersCountByStateGuid
{
    public class GetOrdersCountByStateGuidQuery : IRequest<GetOrdersCountByStateGuidVm>
    {
        public Guid StateGuid { get; set; }

        public class GetOrdersCountByStateGuidQueryHandler : IRequestHandler<GetOrdersCountByStateGuidQuery, GetOrdersCountByStateGuidVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public GetOrdersCountByStateGuidQueryHandler(IIndustrialServicesSystemContext context,
                ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<GetOrdersCountByStateGuidVm> Handle(GetOrdersCountByStateGuidQuery request, CancellationToken cancellationToken)
            {
                var currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new GetOrdersCountByStateGuidVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)GetOrdersCountByStateGuidState.UserNotFound
                };

                var admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (admin == null) return new GetOrdersCountByStateGuidVm()
                {
                    Message = "ادمین مورد نظر یافت نشد",
                    State = (int)GetOrdersCountByStateGuidState.AdminNotFound
                };

                var state = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.StateGuid, cancellationToken);

                if (state == null) return new GetOrdersCountByStateGuidVm()
                {
                    Message = "وضعیت مورد نظر یافت نشد",
                    State = (int)GetOrdersCountByStateGuidState.StateNotFound
                };

                return new GetOrdersCountByStateGuidVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrdersCountByStateGuidState.Success,
                    Count = await _context.Order
                        .CountAsync(o => o.StateCodeId == state.CodeId && !o.IsDelete)
            };
            }
        }
    }
}
