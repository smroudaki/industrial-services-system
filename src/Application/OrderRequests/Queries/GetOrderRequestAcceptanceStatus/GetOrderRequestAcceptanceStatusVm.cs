using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestAcceptanceStatus
{
    public class GetOrderRequestAcceptanceStatusVm : IMapFrom<OrderRequest>
    {
        public string Message { get; set; }

        public int State { get; set; }

        public string AcceptanceStatus { get; set; }
    }
}
