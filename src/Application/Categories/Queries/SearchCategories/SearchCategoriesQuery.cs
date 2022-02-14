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

namespace IndustrialServicesSystem.Application.Categories.Queries.SearchCategories
{
    public class SearchCategoriesQuery : IRequest<SearchCategoriesVm>
    {
        public string Input { get; set; }

        public class SearchCategoriesQueryHandler : IRequestHandler<SearchCategoriesQuery, SearchCategoriesVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public SearchCategoriesQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SearchCategoriesVm> Handle(SearchCategoriesQuery request, CancellationToken cancellationToken)
            {
                List<SearchCategoriesDto> categories = await _context.Category
                    .Where(x => x.DisplayName.Contains(request.Input) && !x.IsDelete)
                    .ProjectTo<SearchCategoriesDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                int count = categories.Count;

                if (count > 0)
                {
                    return new SearchCategoriesVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)SearchCategoriesState.Success,
                        Count = count,
                        Categories = categories
                    };
                }

                return new SearchCategoriesVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)SearchCategoriesState.NotFound
                };
            }
        }
    }
}
