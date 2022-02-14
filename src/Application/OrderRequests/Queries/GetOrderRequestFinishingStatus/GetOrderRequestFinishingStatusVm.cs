using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestFinishingStatus
{
    public class GetOrderRequestFinishingStatusVm : IMapFrom<OrderRequest>
    {
        public string Message { get; set; }

        public int State { get; set; }

        public bool FinishingStatus { get; set; }
    }
}
