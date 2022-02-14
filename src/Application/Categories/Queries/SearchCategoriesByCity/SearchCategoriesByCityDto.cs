﻿using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Categories.Queries.SearchCategoriesByCity
{
    public class SearchCategoriesByCityDto : IMapFrom<Category>
    {
        public Guid CategoryGuid { get; set; }

        public string DisplayName { get; set; }
    }
}
