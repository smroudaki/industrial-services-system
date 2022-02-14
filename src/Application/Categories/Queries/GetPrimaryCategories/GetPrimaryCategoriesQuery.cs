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
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;
using IndustrialServicesSystem.Application.Common;
using System.IO;

namespace IndustrialServicesSystem.Application.Categories.Queries.GetPrimaryCategories
{
    public class GetPrimaryCategoriesQuery : IRequest<PrimaryCategoriesVm>
    {
        public Guid? CategoryGuid { get; set; }

        public string WebRootPath { get; set; }

        public class GetPrimaryCategoriesQueryHandler : IRequestHandler<GetPrimaryCategoriesQuery, PrimaryCategoriesVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public GetPrimaryCategoriesQueryHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<PrimaryCategoriesVm> Handle(GetPrimaryCategoriesQuery request, CancellationToken cancellationToken)
            {
                IQueryable<Category> categories = _context.Category
                    .Where(x => !x.IsDelete);

                if (request.CategoryGuid.HasValue)
                {
                    Category category = await _context.Category
                        .SingleOrDefaultAsync(x => x.CategoryGuid == request.CategoryGuid && !x.IsDelete, cancellationToken);

                    if (category == null) return new PrimaryCategoriesVm()
                    {
                        Message = "دسته بندی مورد نظر یافت نشد",
                        State = (int)GetPrimaryCategoriesState.CategoryNotFound
                    };

                    categories = categories.Where(x => x.ParentCategoryId == category.CategoryId);
                }
                else
                    categories = categories.Where(x => x.ParentCategoryId == null);

                List<PrimaryCategoryDto> primaryCategories = await categories.OrderBy(x => x.Sort)
                    .Select(x => new PrimaryCategoryDto
                    {
                        CategoryGuid = x.CategoryGuid,
                        Title = x.DisplayName,
                        Description = x.Description,
                        Abstract = x.Abstract,
                        Sort = x.Sort,
                        CoverDocument = new FilepondDto
                        {
                            Source = x.CoverDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.CoverDocument.Name,
                                    Size = x.CoverDocument.Size.ToString(),
                                    Type = x.CoverDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.CoverDocument.Path
                                }
                            }
                        },
                        SecondPageCoverDocument = new FilepondDto
                        {
                            Source = x.SecondPageCoverDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.SecondPageCoverDocument.Name,
                                    Size = x.SecondPageCoverDocument.Size.ToString(),
                                    Type = x.SecondPageCoverDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.SecondPageCoverDocument.Path
                                }
                            }
                        },
                        ActiveIconDocument = new FilepondDto
                        {
                            Source = x.ActiveIconDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.ActiveIconDocument.Name,
                                    Size = x.ActiveIconDocument.Size.ToString(),
                                    Type = x.ActiveIconDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.ActiveIconDocument.Path
                                }
                            }
                        },
                        InactiveIconDocument = new FilepondDto
                        {
                            Source = x.InactiveIconDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.InactiveIconDocument.Name,
                                    Size = x.InactiveIconDocument.Size.ToString(),
                                    Type = x.InactiveIconDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.InactiveIconDocument.Path
                                }
                            }
                        },
                        QuadMenuDocument = new FilepondDto
                        {
                            Source = x.QuadMenuDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.QuadMenuDocument.Name,
                                    Size = x.QuadMenuDocument.Size.ToString(),
                                    Type = x.QuadMenuDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.QuadMenuDocument.Path
                                }
                            }
                        },
                        Tags = x.CategoryTag.OrderBy(x => x.Tag.Name)
                            .Select(x => new GetPrimaryCategoryTagNameDto
                            {
                                Guid = x.Tag.TagGuid,
                                Name = x.Tag.Name

                            }) as List<GetPrimaryCategoryTagNameDto>,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).ToListAsync(cancellationToken);

                if (primaryCategories.Count <= 0) return new PrimaryCategoriesVm()
                {
                    Message = "دسته بندی ای یافت نشد",
                    State = (int)GetPrimaryCategoriesState.NotAnyCategoriesFound,
                };

                Document document = await _context.Document
                    .Include(x => x.TypeCode)
                    .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse("ff2b7bd9-400e-4328-8c75-22bfe8b5ba75"));

                if (document != null)
                {
                    foreach (PrimaryCategoryDto primaryCategory in primaryCategories)
                    {
                        if (string.IsNullOrEmpty(primaryCategory.CoverDocument.Source))
                        {
                            primaryCategory.CoverDocument = new FilepondDto
                            {
                                Source = document.Path,
                                Options = new FilepondOptions
                                {
                                    Type = "local",
                                    Files = new FilepondFile
                                    {
                                        Name = document.Name,
                                        Size = document.Size.ToString(),
                                        Type = document.TypeCode.Name
                                    },
                                    Metadata = new FilepondMetadata
                                    {
                                        Poster = document.Path
                                    }
                                }
                            };
                        }
                        else
                        {
                            int uploadsIndex = primaryCategory.CoverDocument.Source.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                request.WebRootPath,
                                primaryCategory.CoverDocument.Source.Substring(uploadsIndex));

                            if (!File.Exists(documentPath))
                            {
                                primaryCategory.CoverDocument = new FilepondDto
                                {
                                    Source = document.Path,
                                    Options = new FilepondOptions
                                    {
                                        Type = "local",
                                        Files = new FilepondFile
                                        {
                                            Name = document.Name,
                                            Size = document.Size.ToString(),
                                            Type = document.TypeCode.Name
                                        },
                                        Metadata = new FilepondMetadata
                                        {
                                            Poster = document.Path
                                        }
                                    }
                                };
                            }
                        }

                        if (string.IsNullOrEmpty(primaryCategory.SecondPageCoverDocument.Source))
                        {
                            primaryCategory.SecondPageCoverDocument = new FilepondDto
                            {
                                Source = document.Path,
                                Options = new FilepondOptions
                                {
                                    Type = "local",
                                    Files = new FilepondFile
                                    {
                                        Name = document.Name,
                                        Size = document.Size.ToString(),
                                        Type = document.TypeCode.Name
                                    },
                                    Metadata = new FilepondMetadata
                                    {
                                        Poster = document.Path
                                    }
                                }
                            };
                        }
                        else
                        {
                            int uploadsIndex = primaryCategory.SecondPageCoverDocument.Source.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                request.WebRootPath,
                                primaryCategory.SecondPageCoverDocument.Source.Substring(uploadsIndex));

                            if (!File.Exists(documentPath))
                            {
                                primaryCategory.SecondPageCoverDocument = new FilepondDto
                                {
                                    Source = document.Path,
                                    Options = new FilepondOptions
                                    {
                                        Type = "local",
                                        Files = new FilepondFile
                                        {
                                            Name = document.Name,
                                            Size = document.Size.ToString(),
                                            Type = document.TypeCode.Name
                                        },
                                        Metadata = new FilepondMetadata
                                        {
                                            Poster = document.Path
                                        }
                                    }
                                };
                            }
                        }
                    }
                }

                return new PrimaryCategoriesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetPrimaryCategoriesState.Success,
                    PrimaryCategories = primaryCategories
                };
            }
        }
    }
}
