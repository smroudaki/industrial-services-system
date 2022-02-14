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

namespace IndustrialServicesSystem.Application.Posts.Queries.GetSuggestedPosts
{
    public class GetSuggestedPostsQuery : IRequest<GetSuggestedPostsVm>
    {
        public class GetIndexPostsQueryHandler : IRequestHandler<GetSuggestedPostsQuery, GetSuggestedPostsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetIndexPostsQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetSuggestedPostsVm> Handle(GetSuggestedPostsQuery request, CancellationToken cancellationToken)
            {
                var posts = await _context.Post
                    .Where(x => x.IsSuggested && !x.IsDelete)
                    .OrderByDescending(x => x.ViewCount)
                    .ProjectTo<GetSuggestedPostsDto>(_mapper.ConfigurationProvider)
                    .Take(3)
                    .ToListAsync(cancellationToken);

                if (posts.Count == 0)
                {
                    return new GetSuggestedPostsVm()
                    {
                        Message = "پستی یافت نشد",
                        State = (int)GetSuggestedPostsState.NoPosts
                    };
                }

                foreach (var post in posts)
                {
                    var p = await _context.Post
                        .Where(x => x.PostGuid == post.PostGuid)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (p == null)
                    {
                        continue;
                    }

                    var postCategory = await _context.PostCategory
                        .Where(x => x.PostId == p.PostId)
                        .OrderBy(x => x.Category.DisplayName)
                        .Select(x => new GetSuggestedPostsCategoryNameDto
                        {
                            Guid = x.Category.CategoryGuid,
                            Title = x.Category.DisplayName

                        }).FirstOrDefaultAsync(cancellationToken);

                    if (postCategory != null)
                    {
                        post.Category = postCategory;
                    }

                    var postTags = await _context.PostTag
                        .Where(x => x.PostId == p.PostId)
                        .OrderBy(x => x.Tag.Name)
                        .Select(x => new GetSuggestedPostsTagNameDto
                        {
                            Guid = x.Tag.TagGuid,
                            Name = x.Tag.Name

                        }).ToListAsync(cancellationToken);

                    if (postTags.Count > 0)
                    {
                        post.Tags = postTags;
                    }
                }

                return new GetSuggestedPostsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetSuggestedPostsState.Success,
                    Posts = posts
                };
            }
        }
    }
}
