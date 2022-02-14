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

namespace IndustrialServicesSystem.Application.Discounts.Commands.CreatePublicDiscount
{
    public class CreatePublicDiscountCommand : IRequest<CreatePublicDiscountVm>
    {
        public string Value { get; set; }

        public Guid TypeCodeGuid { get; set; }

        public DateTime ExpirationDate { get; set; }

        public class CreateSuggestionCommandHandler : IRequestHandler<CreatePublicDiscountCommand, CreatePublicDiscountVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            
            public CreateSuggestionCommandHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<CreatePublicDiscountVm> Handle(CreatePublicDiscountCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new CreatePublicDiscountVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)CreatePublicDiscountState.UserNotFound
                };

                Admin admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (admin == null) return new CreatePublicDiscountVm()
                {
                    Message = "ادمین مورد نظر یافت نشد",
                    State = (int)CreatePublicDiscountState.AdminNotFound
                };

                Code typeCode = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.TypeCodeGuid, cancellationToken);

                if (typeCode == null) return new CreatePublicDiscountVm()
                {
                    Message = "نوع کد تخفیف مورد نظر یافت نشد",
                    State = (int)CreatePublicDiscountState.TypeCodeNotFound
                };

                PublicDiscount publicDiscount = new PublicDiscount()
                {
                    TypeCodeId = typeCode.CodeId,
                    Name = "PUB" + new Random().Next(100, 999),
                    Value = request.Value,
                    ExpirationDate = request.ExpirationDate
                };

                _context.PublicDiscount.Add(publicDiscount);

                await _context.SaveChangesAsync(cancellationToken);

                return new CreatePublicDiscountVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreatePublicDiscountState.Success
                };
            }
        }
    }
}
