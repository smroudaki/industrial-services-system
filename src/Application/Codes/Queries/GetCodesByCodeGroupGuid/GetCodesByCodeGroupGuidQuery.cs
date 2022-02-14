using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Application.Posts.Queries.GetAllPosts;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;

namespace IndustrialServicesSystem.Application.Codes.Queries.GetCodesByCodeGroupGuid
{
    public class GetCodesByCodeGroupGuidQuery : IRequest<GetCodesByCodeGroupGuidVm>
    {
        public Guid CodeGroupGuid { get; set; }

        public class GetCodesByCodeGroupGuidQueryHandler : IRequestHandler<GetCodesByCodeGroupGuidQuery, GetCodesByCodeGroupGuidVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetCodesByCodeGroupGuidQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetCodesByCodeGroupGuidVm> Handle(GetCodesByCodeGroupGuidQuery request, CancellationToken cancellationToken)
            {
                CodeGroup codeGroup = await _context.CodeGroup
                    .SingleOrDefaultAsync(x => x.CodeGroupGuid == request.CodeGroupGuid && !x.IsDelete, cancellationToken);

                if (codeGroup == null) return new GetCodesByCodeGroupGuidVm()
                {
                    Message = "کد وارد شده نامعتبر است",
                    State = (int)CodeType.CodeGroupNotFound
                };

                List<GetCodesByCodeGroupGuidDto> codes = await _context.Code
                    .Where(x => x.CodeGroupId == codeGroup.CodeGroupId && !x.IsDelete)
                    .OrderBy(x => x.DisplayName)
                    .ProjectTo<GetCodesByCodeGroupGuidDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new GetCodesByCodeGroupGuidVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CodeType.Success,
                    Codes = codes
                };
            }
        }
    }
}
