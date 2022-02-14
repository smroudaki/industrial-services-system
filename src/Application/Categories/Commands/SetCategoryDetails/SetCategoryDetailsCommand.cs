﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Categories.Commands.SetCategoryDetails
{
    public class SetCategoryDetailsCommand : IRequest<SetCategoryDetailsVm>
    {
        public SetCategoryDetailsDto Command { get; set; }

        public string WebRootPath { get; set; }

        public class SetCategoryDetailsQueryHandler : IRequestHandler<SetCategoryDetailsCommand, SetCategoryDetailsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public SetCategoryDetailsQueryHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<SetCategoryDetailsVm> Handle(SetCategoryDetailsCommand request, CancellationToken cancellationToken)
            {
                Category category = await _context.Category
                    .SingleOrDefaultAsync(x => x.CategoryGuid == request.Command.CategoryGuid, cancellationToken);

                if (category == null) return new SetCategoryDetailsVm
                {
                    Message = "دسته بندی مورد نظر یافت نشد",
                    State = (int)SetCategoryDetailsState.CategoryNotFound
                };

                if (!string.IsNullOrEmpty(request.Command.CoverDocumentGuid))
                {
                    Document coverDocument = await _context.Document
                        .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.Command.CoverDocumentGuid), cancellationToken);

                    if (coverDocument == null) return new SetCategoryDetailsVm()
                    {
                        Message = "تصویر کاور مورد نظر یافت نشد",
                        State = (int)SetCategoryDetailsState.CoverDocumentNotFound
                    };

                    if (category.CoverDocumentId != coverDocument.DocumentId)
                    {
                        Document oldDocument = await _context.Document
                            .FirstOrDefaultAsync(x => x.DocumentId == category.CoverDocumentId, cancellationToken);

                        if (oldDocument != null)
                        {
                            int uploadsIndex = oldDocument.Path.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                request.WebRootPath,
                                oldDocument.Path.Substring(uploadsIndex));

                            if (File.Exists(documentPath))
                                File.Delete(documentPath);

                            _context.Document.Remove(oldDocument);
                        }

                        category.CoverDocumentId = coverDocument.DocumentId;
                    }
                }

                if (!string.IsNullOrEmpty(request.Command.SecondPageCoverDocumentGuid))
                {
                    Document secondPageCoverDocument = await _context.Document
                        .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.Command.SecondPageCoverDocumentGuid), cancellationToken);

                    if (secondPageCoverDocument == null) return new SetCategoryDetailsVm()
                    {
                        Message = "تصویر کاور مورد نظر یافت نشد",
                        State = (int)SetCategoryDetailsState.SecondPageCoverDocumentNotFound
                    };

                    if (category.SecondPageCoverDocumentId != secondPageCoverDocument.DocumentId)
                    {
                        Document oldDocument = await _context.Document
                            .FirstOrDefaultAsync(x => x.DocumentId == category.SecondPageCoverDocumentId, cancellationToken);

                        if (oldDocument != null)
                        {
                            int uploadsIndex = oldDocument.Path.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                request.WebRootPath,
                                oldDocument.Path.Substring(uploadsIndex));

                            if (File.Exists(documentPath))
                                File.Delete(documentPath);

                            _context.Document.Remove(oldDocument);
                        }

                        category.SecondPageCoverDocumentId = secondPageCoverDocument.DocumentId;
                    }
                }

                if (!string.IsNullOrEmpty(request.Command.ActiveIconDocumentGuid))
                {
                    Document activeIconDocument = await _context.Document
                        .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.Command.ActiveIconDocumentGuid), cancellationToken);

                    if (activeIconDocument == null) return new SetCategoryDetailsVm()
                    {
                        Message = "تصویر آیکون فعال مورد نظر یافت نشد",
                        State = (int)SetCategoryDetailsState.ActiveIconDocumentNotFound
                    };
                    
                    if (category.ActiveIconDocumentId != activeIconDocument.DocumentId)
                    {
                        Document oldDocument = await _context.Document
                           .FirstOrDefaultAsync(x => x.DocumentId == category.ActiveIconDocumentId, cancellationToken);

                        if (oldDocument != null)
                        {
                            int uploadsIndex = oldDocument.Path.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                request.WebRootPath,
                                oldDocument.Path.Substring(uploadsIndex));

                            if (File.Exists(documentPath))
                                File.Delete(documentPath);

                            _context.Document.Remove(oldDocument);
                        }

                        category.ActiveIconDocumentId = activeIconDocument.DocumentId;
                    }
                }

                if (!string.IsNullOrEmpty(request.Command.InactiveIconDocumentGuid))
                {
                    Document inactiveIconDocument = await _context.Document
                        .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.Command.InactiveIconDocumentGuid), cancellationToken);

                    if (inactiveIconDocument == null) return new SetCategoryDetailsVm()
                    {
                        Message = "تصویر آیکون غیرفعال مورد نظر یافت نشد",
                        State = (int)SetCategoryDetailsState.InactiveIconDocumentNotFound
                    };

                    if (category.InactiveIconDocumentId != inactiveIconDocument.DocumentId)
                    {
                        Document oldDocument = await _context.Document
                            .FirstOrDefaultAsync(x => x.DocumentId == category.InactiveIconDocumentId, cancellationToken);

                        if (oldDocument != null)
                        {
                            int uploadsIndex = oldDocument.Path.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                request.WebRootPath,
                                oldDocument.Path.Substring(uploadsIndex));

                            if (File.Exists(documentPath))
                                File.Delete(documentPath);

                            _context.Document.Remove(oldDocument);
                        }

                        category.InactiveIconDocumentId = inactiveIconDocument.DocumentId;
                    }
                }

                if (!string.IsNullOrEmpty(request.Command.QuadMenuDocumentGuid))
                {
                    Document quadMenuDocument = await _context.Document
                        .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.Command.QuadMenuDocumentGuid), cancellationToken);

                    if (quadMenuDocument == null) return new SetCategoryDetailsVm()
                    {
                        Message = "تصویر فهرست چرخشی مورد نظر یافت نشد",
                        State = (int)SetCategoryDetailsState.QuadMenuDocumentNotFound
                    };
                    
                    if (category.QuadMenuDocumentId != quadMenuDocument.DocumentId)
                    {
                        Document oldDocument = await _context.Document
                           .FirstOrDefaultAsync(x => x.DocumentId == category.QuadMenuDocumentId, cancellationToken);

                        if (oldDocument != null)
                        {
                            int uploadsIndex = oldDocument.Path.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                request.WebRootPath,
                                oldDocument.Path.Substring(uploadsIndex));

                            if (File.Exists(documentPath))
                                File.Delete(documentPath);

                            _context.Document.Remove(oldDocument);
                        }

                        category.QuadMenuDocumentId = quadMenuDocument.DocumentId;
                    }
                }

                category.DisplayName = request.Command.DisplayName;
                category.Abstract = request.Command.Abstract;
                category.Description = request.Command.Description;
                category.Sort = request.Command.Sort;
                category.ModifiedDate = DateTime.Now;

                List<CategoryTag> categoryTags = await _context.CategoryTag
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToListAsync(cancellationToken);

                foreach (var oldCategory in categoryTags)
                    _context.CategoryTag.Remove(oldCategory);

                if (request.Command.Tags != null)
                {
                    CategoryTag categoryTag;

                    foreach (string tag in request.Command.Tags)
                    {
                        Guid.TryParse(tag, out Guid guid);

                        if (guid == Guid.Empty)
                        {
                            Tag newTag = new Tag()
                            {
                                Name = tag
                            };

                            _context.Tag.Add(newTag);

                            categoryTag = new CategoryTag()
                            {
                                CategoryId = category.CategoryId
                            };

                            categoryTag.Tag = newTag;
                        }
                        else
                        {
                            Tag availableTeg = await _context.Tag
                                .Where(x => x.TagGuid == Guid.Parse(tag))
                                .SingleOrDefaultAsync(cancellationToken);

                            if (availableTeg == null) continue;

                            categoryTag = new CategoryTag()
                            {
                                CategoryId = category.CategoryId,
                                TagId = availableTeg.TagId
                            };
                        }

                        _context.CategoryTag.Add(categoryTag);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new SetCategoryDetailsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)SetCategoryDetailsState.Success
                };
            }
        }
    }
}
