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

namespace IndustrialServicesSystem.Application.Payments.Queries.GetPaymentByGuid
{
    public class GetPaymentByGuidQuery : IRequest<GetPaymentByGuidVm>
    {
        public Guid PaymentGuid { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetPaymentByGuidQuery, GetPaymentByGuidVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public OrdersListQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetPaymentByGuidVm> Handle(GetPaymentByGuidQuery request, CancellationToken cancellationToken)
            {
                GetPaymentByGuidDto payment = await _context.Payment
                    .Where(x => x.PaymentGuid == request.PaymentGuid)
                    .ProjectTo<GetPaymentByGuidDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                if (payment == null) return new GetPaymentByGuidVm()
                {
                    Message = "پرداخت مورد نظر یافت نشد",
                    State = (int)GetPaymentByGuidState.PaymentNotFound
                };

                return new GetPaymentByGuidVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetPaymentByGuidState.Success,
                    Result = payment
                };
            }
        }
    }
}
