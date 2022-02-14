using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.ContractorDocuments.Queries.GetContractorDocuments
{
    public class GetContractorDocumentsQuery : IRequest<GetContractorDocumentsVm>
    {
        public Guid UserGuid { get; set; }

        public class GetContractorDocumentsQueryHandler : IRequestHandler<GetContractorDocumentsQuery, GetContractorDocumentsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetContractorDocumentsQueryHandler(IIndustrialServicesSystemContext context,
                IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetContractorDocumentsVm> Handle(GetContractorDocumentsQuery request, CancellationToken cancellationToken)
            {
                var contractor = await _context.Contractor
                    .SingleOrDefaultAsync(c => c.User.UserGuid == request.UserGuid && !c.IsDelete);

                if (contractor == null) return new GetContractorDocumentsVm
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)GetDocumentsState.ContractorNotFound
                };

                var contractorDocuments = await _context.ContractorDocument
                    .Where(cd => cd.ContractorId == contractor.ContractorId && !cd.IsDelete)
                    .ProjectTo<GetContractorDocumentsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (contractorDocuments.Count <= 0) return new GetContractorDocumentsVm
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetDocumentsState.NotFound
                };

                return new GetContractorDocumentsVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetDocumentsState.Success,
                    ContractorDocuments = contractorDocuments
                };
            }
        }
    }
}
