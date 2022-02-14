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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace IndustrialServicesSystem.Application.Discounts.Queries.GetPublicDiscounts
{
    public class GetPublicDiscountsQuery : IRequest<GetPublicDiscountsVm>
    {
        public class GetPublicDiscountsQueryHandler : IRequestHandler<GetPublicDiscountsQuery, GetPublicDiscountsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetPublicDiscountsQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetPublicDiscountsVm> Handle(GetPublicDiscountsQuery request, CancellationToken cancellationToken)
            {
                List<GetPublicDiscountsDto> publicDiscounts = await _context.PublicDiscount
                    .Where(x => !x.IsDelete)
                    .OrderByDescending(x => x.CreationDate)
                    .ProjectTo<GetPublicDiscountsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (publicDiscounts.Count < 0) return new GetPublicDiscountsVm()
                {
                    Message = "کد تخفیف عمومی ای یافت نشد",
                    State = (int)GetPublicDiscountsState.NotAnyPublicDiscountsFound
                };

                return new GetPublicDiscountsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetPublicDiscountsState.Success,
                    PublicDiscounts = publicDiscounts
                };
            }
        }
    }
}
