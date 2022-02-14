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

namespace IndustrialServicesSystem.Application.CodeGroups.Queries.GetAllCodeGroups
{
    public class GetAllCodeGroupsQuery : IRequest<GetAllCodeGroupsVm>
    {
        public class GetAllCodeGroupsQueryHandler : IRequestHandler<GetAllCodeGroupsQuery, GetAllCodeGroupsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetAllCodeGroupsQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetAllCodeGroupsVm> Handle(GetAllCodeGroupsQuery request, CancellationToken cancellationToken)
            {
                var codeGroups = await _context.CodeGroup
                    .Where(x => !x.IsDelete)
                    .ProjectTo<GetAllCodeGroupsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (codeGroups.Count == 0) return new GetAllCodeGroupsVm()
                {
                    Message = "کد گروهی یافت نشد",
                    State = (int)GetAllCodeGroupsState.NotAnyCodeGroups
                };

                return new GetAllCodeGroupsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllCodeGroupsState.Success,
                    CodeGroups = codeGroups
                };
            }
        }
    }
}
