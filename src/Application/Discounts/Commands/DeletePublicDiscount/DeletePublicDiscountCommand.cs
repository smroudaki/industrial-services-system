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

namespace IndustrialServicesSystem.Application.Discounts.Commands.DeletePublicDiscount
{
    public class DeletePublicDiscountCommand : IRequest<DeletePublicDiscountVm>
    {
        public Guid PublicDiscountGuid { get; set; }

        public class DeletePublicDiscountCommandHandler : IRequestHandler<DeletePublicDiscountCommand, DeletePublicDiscountVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public DeletePublicDiscountCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<DeletePublicDiscountVm> Handle(DeletePublicDiscountCommand request, CancellationToken cancellationToken)
            {
                var discount = await _context.PublicDiscount
                    .SingleOrDefaultAsync(x => x.PublicDiscountGuid == request.PublicDiscountGuid && !x.IsDelete);

                if (discount == null)
                {
                    return new DeletePublicDiscountVm
                    {
                        Message = "کد تخفیف عمومی مورد نظر یافت نشد",
                        State = (int)DeletePublicDiscountState.PublicDicountNotFound
                    };
                }

                discount.IsDelete = true;

                await _context.SaveChangesAsync(cancellationToken);

                return new DeletePublicDiscountVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)DeletePublicDiscountState.Success
                };
            }
        }
    }
}
