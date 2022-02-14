using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Categories.Queries.GetCategoryByGuid
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public Guid CategoryGuid { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public int Sort { get; set; }

        public FilepondDtoTest CoverDocument { get; set; }

        public FilepondDtoTest SecondPageCoverDocument { get; set; }

        public FilepondDtoTest ActiveIconDocument { get; set; }

        public FilepondDtoTest InactiveIconDocument { get; set; }

        public FilepondDtoTest QuadMenuDocument { get; set; }

        public List<GetCategoryTagNameDto> Tags { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedDate { get; set; }

        public List<CategoryDto> Children { get; set; }
    }

    public class CategoryDtoResult
    {
        public Guid CategoryGuid { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public int Sort { get; set; }

        public FilepondDtoTest CoverDocument { get; set; }

        public FilepondDtoTest SecondPageCoverDocument { get; set; }

        public FilepondDtoTest ActiveIconDocument { get; set; }

        public FilepondDtoTest InactiveIconDocument { get; set; }

        public FilepondDtoTest QuadMenuDocument { get; set; }

        public List<GetCategoryTagNameDto> Tags { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedDate { get; set; }

        public List<CategoryDto> Children { get; set; }
    }

    public class GetCategoryTagNameDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}
