﻿using System;
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

namespace IndustrialServicesSystem.Application.Tags.Queries.GetAllTags
{
    public class GetAllTagsQuery : IRequest<AllTagsVm>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetAllTagsQuery, AllTagsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetCategoriesQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AllTagsVm> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
            {
                var tags = await _context.Tag
                    .OrderByDescending(x => x.Usage)
                    .ProjectTo<AllTagDto>(_mapper.ConfigurationProvider)
                    .Take(100)
                    .ToListAsync();

                return new AllTagsVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Tags = tags
                };
            }
        }
    }
}
