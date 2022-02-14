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

namespace IndustrialServicesSystem.Application.Contractors.Queries.GetContractor
{
    public class GetContractorQuery : IRequest<GetContractorVm>
    {
        public Guid ContractorGuid { get; set; }

        public class GetUserByGuidQueryHandler : IRequestHandler<GetContractorQuery, GetContractorVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetUserByGuidQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetContractorVm> Handle(GetContractorQuery request, CancellationToken cancellationToken)
            {
                var contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.ContractorGuid == request.ContractorGuid, cancellationToken);

                if (contractor == null) return new GetContractorVm()
                {
                    Message = "کاربری یافت نشد",
                    State = (int)GetContractorState.ContractorNotFound
                };

                GetContractorDto user = await _context.User
                    .Where(x => x.UserId == contractor.UserId)
                    .ProjectTo<GetContractorDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                if (user == null) return new GetContractorVm()
                {
                    Message = "کاربری یافت نشد",
                    State = (int)GetContractorState.UserNotFound
                };

                return new GetContractorVm()
                {
                    Message ="عملیات موفق آمیز",
                    State = (int)GetContractorState.Success,
                    User = user
                };
            }
        }
    }
}
