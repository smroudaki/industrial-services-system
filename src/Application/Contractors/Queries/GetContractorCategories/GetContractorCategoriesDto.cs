using AutoMapper;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetContractorCategories
{
    public class GetContractorCategoriesDto
    {
        public Guid CategoryGuid { get; set; }

        public string Name { get; set; }

        public int OrdersCount { get; set; }
    }
}
