using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Orders.Queries.GetClientOrders
{
    public class GetClientOrdersVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetClientOrdersDto> Orders { get; set; }
    }
}
