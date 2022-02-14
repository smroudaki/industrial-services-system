using AutoMapper;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Categories.Queries.GetAllCategories
{
    public class AllCategoryDto
    {
        public Guid Guid { get; set; }

        //public int? ParentId { get; set; }

        public string Title { get; set; }

        //public int Order { get; set; }

        public List<AllCategoryDto> Children { get; set; } = new List<AllCategoryDto>();
    }
}
