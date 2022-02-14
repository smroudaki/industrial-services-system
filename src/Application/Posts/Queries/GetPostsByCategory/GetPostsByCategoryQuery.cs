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

namespace IndustrialServicesSystem.Application.Posts.Queries.GetPostsByCategory
{
    public class GetPostsByCategoryQuery : IRequest<GetPostsByCategoryVm>
    {
        public Guid CategoryGuid { get; set; }

        public int Page { get; set; }

        public class GetPostsByCategoryQueryHandler : IRequestHandler<GetPostsByCategoryQuery, GetPostsByCategoryVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public GetPostsByCategoryQueryHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<GetPostsByCategoryVm> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _context.Category
                    .Where(x => x.CategoryGuid == request.CategoryGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (category == null)
                {
                    return new GetPostsByCategoryVm()
                    {
                        Message = "دسته بندی مورد نظر یافت نشد",
                        Result = false
                    };
                }

                var posts = await (from pc in _context.PostCategory
                                   where pc.CategoryId == category.CategoryId
                                   join p in _context.Post on pc.PostId equals p.PostId
                                   orderby p.ModifiedDate descending
                                   select new GetPostsByCategoryDto
                                   {
                                       PostGuid = p.PostGuid,
                                       UserFullName = p.User.FirstName + " " + p.User.LastName,
                                       DocumentFileName = p.Document.Name,
                                       ViewCount = p.ViewCount,
                                       LikeCount = p.LikeCount,
                                       Title = p.Title,
                                       Abstract = p.Abstract,
                                       Description = p.Description,
                                       IsShow = p.IsShow,
                                       IsSuggested = p.IsSuggested,
                                       Slider = p.SliderCode.DisplayName,
                                       CreationDate = p.CreationDate,
                                       ModifiedDate = p.ModifiedDate

                                   }).Skip(12 * (request.Page - 1))
                                   .Take(12)
                                   .ToListAsync(cancellationToken);

                return new GetPostsByCategoryVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Posts = posts
                };
            }
        }
    }
}
