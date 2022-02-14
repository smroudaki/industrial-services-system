using System;
using System.Collections.Generic;
using System.Text;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IndustrialServicesSystem.Domain.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IndustrialServicesSystem.Application.Discounts.Queries.ApplyDiscountCommand
{
    public class ApplyDiscountQuery : IRequest<ApplyDiscountVm>
    {
        public int RealAmount { get; set; }

        public string DiscountValue { get; set; }

        public class ApplyDiscountQueryHandler : IRequestHandler<ApplyDiscountQuery, ApplyDiscountVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            
            public ApplyDiscountQueryHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<ApplyDiscountVm> Handle(ApplyDiscountQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new ApplyDiscountVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)ApplyDiscountState.UserNotFound
                };

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null) return new ApplyDiscountVm()
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)ApplyDiscountState.ContractorNotFound
                };

                PublicDiscount publicDiscount = await _context.PublicDiscount
                    .Where(x => x.Name.Equals(request.DiscountValue) && x.IsActive && !x.IsDelete)
                    .FirstOrDefaultAsync(cancellationToken);

                if (publicDiscount == null) return new ApplyDiscountVm()
                {
                    Message = "کد تخفیف وارد شده معتبر نیست",
                    State = (int)ApplyDiscountState.DiscountValueNotValid
                };

                int discount = publicDiscount.TypeCodeId switch
                {
                    32 => Convert.ToInt32(publicDiscount.Value) * request.RealAmount / 100,
                    33 => Convert.ToInt32(publicDiscount.Value),
                    _ => 0,
                };

                return new ApplyDiscountVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)ApplyDiscountState.Success,
                    PayAmount = request.RealAmount - discount
                };
            }
        }
    }
}
