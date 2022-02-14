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
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;
using System.IO;

namespace IndustrialServicesSystem.Application.Categories.Queries.GetCategoryByGuid
{
    public class GetCategoryByGuidQuery : IRequest<CategoryVm>
    {
        public Guid CategoryGuid { get; set; }

        public bool IncludeChildren { get; set; }

        public string WebRootPath { get; set; }

        public class GetCategoryByGuidQueryHandler : IRequestHandler<GetCategoryByGuidQuery, CategoryVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private string _webRootPath;

            public GetCategoryByGuidQueryHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<CategoryDtoResult> GetCategory(Guid parentGuid, bool includeChildren = false)
            {
                CategoryDto category = await _context.Category
                    .Where(x => x.CategoryGuid == parentGuid && !x.IsDelete)
                    .Select(x => new CategoryDto
                    {
                        CategoryId = x.CategoryId,
                        CategoryGuid = x.CategoryGuid,
                        Title = x.DisplayName,
                        Description = x.Description,
                        Abstract = x.Abstract,
                        Sort = x.Sort,
                        CoverDocument = new FilepondDtoTest
                        {
                            Source = x.CoverDocument.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
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
                        SecondPageCoverDocument = new FilepondDtoTest
                        {
                            Source = x.SecondPageCoverDocument.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
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
                        ActiveIconDocument = new FilepondDtoTest
                        {
                            Source = x.ActiveIconDocument.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
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
                        InactiveIconDocument = new FilepondDtoTest
                        {
                            Source = x.InactiveIconDocument.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
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
                        QuadMenuDocument = new FilepondDtoTest
                        {
                            Source = x.QuadMenuDocument.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
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
                            .Select(x => new GetCategoryTagNameDto
                            {
                                Guid = x.Tag.TagGuid,
                                Name = x.Tag.Name

                            }) as List<GetCategoryTagNameDto>,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).SingleOrDefaultAsync();

                if (category == null)
                    return null;

                Document document = await _context.Document
                    .Include(x => x.TypeCode)
                    .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse("ff2b7bd9-400e-4328-8c75-22bfe8b5ba75"));

                if (document != null)
                {
                    if (string.IsNullOrEmpty(category.CoverDocument.Source))
                    {
                        category.CoverDocument = new FilepondDtoTest
                        {
                            Source = document.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
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
                        int uploadsIndex = category.CoverDocument.Source.IndexOf("Uploads");
                        string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                            _webRootPath,
                            category.CoverDocument.Source.Substring(uploadsIndex));

                        if (!File.Exists(documentPath))
                        {
                            category.CoverDocument = new FilepondDtoTest
                            {
                                Source = document.Path,
                                Options = new FilepondOptionsTest
                                {
                                    Type = "local",
                                    File = new FilepondFile
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

                    if (string.IsNullOrEmpty(category.SecondPageCoverDocument.Source))
                    {
                        category.SecondPageCoverDocument = new FilepondDtoTest
                        {
                            Source = document.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
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
                        int uploadsIndex = category.SecondPageCoverDocument.Source.IndexOf("Uploads");
                        string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                            _webRootPath,
                            category.SecondPageCoverDocument.Source.Substring(uploadsIndex));

                        if (!File.Exists(documentPath))
                        {
                            category.SecondPageCoverDocument = new FilepondDtoTest
                            {
                                Source = document.Path,
                                Options = new FilepondOptionsTest
                                {
                                    Type = "local",
                                    File = new FilepondFile
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

                if (includeChildren)
                {
                    List<Category> categories = await _context.Category
                       .Include(x => x.CoverDocument)
                       .Include(x => x.SecondPageCoverDocument)
                       .Include(x => x.ActiveIconDocument)
                       .Include(x => x.InactiveIconDocument)
                       .Include(x => x.QuadMenuDocument)
                       .Include(x => x.CategoryTag)
                       .Where(x => !x.IsDelete)
                       .ToListAsync();

                    if (categories.Count <= 0)
                        return null;

                    category.Children = await GetCategoryChildren(categories, category);
                }
                else
                    category.Children = new List<CategoryDto>();

                return new CategoryDtoResult()
                {
                    CategoryGuid = category.CategoryGuid,
                    Title = category.Title,
                    Abstract = category.Abstract,
                    Description = category.Description,
                    Sort = category.Sort,
                    CoverDocument = category.CoverDocument,
                    SecondPageCoverDocument = category.SecondPageCoverDocument,
                    ActiveIconDocument = category.ActiveIconDocument,
                    InactiveIconDocument = category.InactiveIconDocument,
                    QuadMenuDocument = category.QuadMenuDocument,
                    Tags = category.Tags,
                    IsActive = category.IsActive,
                    ModifiedDate = category.ModifiedDate,
                    Children = category.Children
                };
            }

            private async Task<List<CategoryDto>> GetCategoryChildren(List<Category> categories, CategoryDto category)
            {
                List<CategoryDto> subCategories = categories
                    .Where(x => x.ParentCategoryId == category.CategoryId && !x.IsDelete)
                    .OrderBy(x => x.Sort)
                    .Select(x => new CategoryDto
                    {
                        CategoryId = x.CategoryId,
                        CategoryGuid = x.CategoryGuid,
                        Title = x.DisplayName,
                        Description = x.Description,
                        Abstract = x.Abstract,
                        Sort = x.Sort,
                        CoverDocument = new FilepondDtoTest
                        {
                            Source = x.CoverDocument?.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
                                {
                                    Name = x.CoverDocument?.Name,
                                    Size = x.CoverDocument?.Size.ToString(),
                                    Type = x.CoverDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.CoverDocument?.Path
                                }
                            }
                        },
                        SecondPageCoverDocument = new FilepondDtoTest
                        {
                            Source = x.SecondPageCoverDocument?.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
                                {
                                    Name = x.SecondPageCoverDocument?.Name,
                                    Size = x.SecondPageCoverDocument?.Size.ToString(),
                                    Type = x.SecondPageCoverDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.SecondPageCoverDocument?.Path
                                }
                            }
                        },
                        ActiveIconDocument = new FilepondDtoTest
                        {
                            Source = x.ActiveIconDocument?.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
                                {
                                    Name = x.ActiveIconDocument?.Name,
                                    Size = x.ActiveIconDocument?.Size.ToString(),
                                    Type = x.ActiveIconDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.ActiveIconDocument?.Path
                                }
                            }
                        },
                        InactiveIconDocument = new FilepondDtoTest
                        {
                            Source = x.InactiveIconDocument?.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
                                {
                                    Name = x.InactiveIconDocument?.Name,
                                    Size = x.InactiveIconDocument?.Size.ToString(),
                                    Type = x.InactiveIconDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.InactiveIconDocument?.Path
                                }
                            }
                        },
                        QuadMenuDocument = new FilepondDtoTest
                        {
                            Source = x.QuadMenuDocument?.Path,
                            Options = new FilepondOptionsTest
                            {
                                Type = "local",
                                File = new FilepondFile
                                {
                                    Name = x.QuadMenuDocument?.Name,
                                    Size = x.QuadMenuDocument?.Size.ToString(),
                                    Type = x.QuadMenuDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.QuadMenuDocument?.Path
                                }
                            }
                        },
                        Tags = x.CategoryTag.OrderBy(x => x.Tag.Name)
                            .Select(x => new GetCategoryTagNameDto
                            {
                                Guid = x.Tag.TagGuid,
                                Name = x.Tag.Name

                            }) as List<GetCategoryTagNameDto> ?? null,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).ToList();

                if (subCategories.Count <= 0) return new List<CategoryDto>();

                Document document = await _context.Document
                    .Include(x => x.TypeCode)
                    .FirstOrDefaultAsync(x => x.DocumentGuid == Guid.Parse("ff2b7bd9-400e-4328-8c75-22bfe8b5ba75"));

                category.Children = subCategories;

                if (document != null)
                {
                    foreach (CategoryDto subCategory in category.Children)
                    {
                        if (string.IsNullOrEmpty(subCategory.CoverDocument.Source))
                        {
                            subCategory.CoverDocument = new FilepondDtoTest
                            {
                                Source = document.Path,
                                Options = new FilepondOptionsTest
                                {
                                    Type = "local",
                                    File = new FilepondFile
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
                            int uploadsIndex = subCategory.CoverDocument.Source.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                _webRootPath,
                                subCategory.CoverDocument.Source.Substring(uploadsIndex));

                            if (!File.Exists(documentPath))
                            {
                                subCategory.CoverDocument = new FilepondDtoTest
                                {
                                    Source = document.Path,
                                    Options = new FilepondOptionsTest
                                    {
                                        Type = "local",
                                        File = new FilepondFile
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

                        if (string.IsNullOrEmpty(subCategory.SecondPageCoverDocument.Source))
                        {
                            subCategory.SecondPageCoverDocument = new FilepondDtoTest
                            {
                                Source = document.Path,
                                Options = new FilepondOptionsTest
                                {
                                    Type = "local",
                                    File = new FilepondFile
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
                            int uploadsIndex = subCategory.SecondPageCoverDocument.Source.IndexOf("Uploads");
                            string documentPath = Path.Combine(Directory.GetCurrentDirectory(),
                                _webRootPath,
                                subCategory.SecondPageCoverDocument.Source.Substring(uploadsIndex));

                            if (!File.Exists(documentPath))
                            {
                                subCategory.SecondPageCoverDocument = new FilepondDtoTest
                                {
                                    Source = document.Path,
                                    Options = new FilepondOptionsTest
                                    {
                                        Type = "local",
                                        File = new FilepondFile
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

                        subCategory.Children = await GetCategoryChildren(categories, subCategory);
                    }
                }
                else
                {
                    foreach (CategoryDto subCategory in category.Children)
                        subCategory.Children = await GetCategoryChildren(categories, subCategory);
                }

                return category.Children;
            }

            public async Task<CategoryVm> Handle(GetCategoryByGuidQuery request, CancellationToken cancellationToken)
            {
                _webRootPath = request.WebRootPath;

                CategoryDtoResult category = await GetCategory(request.CategoryGuid, request.IncludeChildren);

                if (category == null) return new CategoryVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetCategoryByGuidState.NotFound
                };

                return new CategoryVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetCategoryByGuidState.Success,
                    Category = category
                };
            }
        }
    }
}
