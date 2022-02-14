using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IndustrialServicesSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Accounts.Commands.RegisterClient;

namespace IndustrialServicesSystem.Application.Contractors.Commands.ChargeContractorCredit
{
    public class ChargeContractorCreditCommand : IRequest<ChargeContractorCreditVm>
    {
        public Guid ContractorGuid { get; set; }

        public int Cost { get; set; }

        public class ChargeContractorCreditCommandHandler : IRequestHandler<ChargeContractorCreditCommand, ChargeContractorCreditVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public ChargeContractorCreditCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<ChargeContractorCreditVm> Handle(ChargeContractorCreditCommand request, CancellationToken cancellationToken)
            {
                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.ContractorGuid == request.ContractorGuid, cancellationToken);

                if (contractor == null) return new ChargeContractorCreditVm()
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)ChargeContractorCreditState.ContractorNotFound
                };

                contractor.Credit += request.Cost;
                contractor.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChargeContractorCreditVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)ChargeContractorCreditState.Success
                };
            }
        }
    }
}
