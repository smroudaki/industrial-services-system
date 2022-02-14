using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestsForClient
{
    public class GetOrderRequestsForClientVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetOrderRequestsForClientDto> OrderRequests { get; set; }
    }
}
