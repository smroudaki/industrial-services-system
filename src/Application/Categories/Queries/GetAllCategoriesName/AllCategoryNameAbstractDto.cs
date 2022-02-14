using AutoMapper;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Categories.Queries.GetAllCategoriesName
{
    public class AllCategoryNameAbstractDto
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public int? ParentId { get; set; }

        public string Title { get; set; }

        public int Sort { get; set; }

        public List<AllCategoryNameAbstractDto> SubCategories { get; set; }
    }
}
