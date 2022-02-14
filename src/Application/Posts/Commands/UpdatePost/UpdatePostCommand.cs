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
using System.IO;

namespace IndustrialServicesSystem.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<UpdatePostCommandVm>
    {
        public UpdatePostCommandDto Command { get; set; }

        public string WebRootPath { get; set; }

        public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostCommandVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public UpdatePostCommandHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUser = currentUserService;
            }

            public async Task<UpdatePostCommandVm> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _context.Post
                    .SingleOrDefaultAsync(x => x.PostGuid == request.Command.PostGuid && !x.IsDelete);

                if (post == null)
                {
                    return new UpdatePostCommandVm()
                    {
                        Message = "پست مورد نظر یافت نشد",
                        State = (int)UpdatePostState.PostNotFound
                    };
                }

                var currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new UpdatePostCommandVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)UpdatePostState.UserNotFound
                    };
                }

                if (!string.IsNullOrEmpty(request.Command.DocumentGuid))
                {
                    var document = await _context.Document
                        .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.Command.DocumentGuid), cancellationToken);

                    if (document == null)
                    {
                        return new UpdatePostCommandVm()
                        {
                            Message = "تصویر مورد نظر یافت نشد",
                            State = (int)UpdatePostState.DocumentNotFound
                        };
                    }

                    if (post.DocumentId != document.DocumentId)
                    {
                        var oldDocument = await _context.Document
                           .FirstOrDefaultAsync(x => x.DocumentId == post.DocumentId, cancellationToken);

                        if (oldDocument != null)
                        {
                            var uploadsIndex = oldDocument.Path.IndexOf("Uploads");
                            var documentPath = Path.Combine(Directory.GetCurrentDirectory(), request.WebRootPath, oldDocument.Path.Substring(uploadsIndex));

                            if (File.Exists(documentPath))
                            {
                                File.Delete(documentPath);
                            }

                            _context.Document.Remove(oldDocument);
                        }

                        post.DocumentId = document.DocumentId;
                    }
                }

                post.UserId = currentUser.UserId;
                post.Title = request.Command.Title;
                post.Abstract = request.Command.Abstract;
                post.Description = request.Command.Description;
                post.IsShow = request.Command.IsShow;
                post.ModifiedDate = DateTime.Now;

                var oldCategories = await _context.PostCategory
                    .Where(x => x.PostId == post.PostId)
                    .ToListAsync(cancellationToken);

                foreach (var oldCategory in oldCategories)
                {
                    _context.PostCategory.Remove(oldCategory);
                }

                if (request.Command.Categories != null)
                {
                    foreach (var categoryGuid in request.Command.Categories)
                    {
                        var category = await _context.Category
                            .Where(x => x.CategoryGuid == categoryGuid)
                            .SingleOrDefaultAsync(cancellationToken);

                        if (category == null) continue;

                        var postCategory = new PostCategory()
                        {
                            Post = post,
                            CategoryId = category.CategoryId
                        };

                        _context.PostCategory.Add(postCategory);
                    }
                }

                var oldTags = await _context.PostTag
                    .Where(x => x.PostId == post.PostId)
                    .ToListAsync(cancellationToken);

                foreach (var oldTag in oldTags)
                {
                    _context.PostTag.Remove(oldTag);
                }

                if (request.Command.Tags != null)
                {
                    PostTag postTag;

                    foreach (var tag in request.Command.Tags)
                    {
                        Guid.TryParse(tag, out Guid guid);

                        if (guid == Guid.Empty)
                        {
                            var newTag = new Tag()
                            {
                                Name = tag
                            };

                            _context.Tag.Add(newTag);

                            postTag = new PostTag()
                            {
                                Post = post
                            };

                            postTag.Tag = newTag;
                        }
                        else
                        {
                            var t = await _context.Tag
                                .Where(x => x.TagGuid == Guid.Parse(tag))
                                .SingleOrDefaultAsync(cancellationToken);

                            if (t == null) continue;

                            postTag = new PostTag()
                            {
                                Post = post,
                                TagId = t.TagId
                            };
                        }

                        _context.PostTag.Add(postTag);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdatePostCommandVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)UpdatePostState.Success
                };
            }
        }
    }
}
