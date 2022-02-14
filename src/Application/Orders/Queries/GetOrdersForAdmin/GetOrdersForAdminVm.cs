using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Orders.Queries.GetOrdersForAdmin
{
    public class GetOrdersForAdminVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetOrdersForAdminDto> Orders { get; set; }
    }
}
