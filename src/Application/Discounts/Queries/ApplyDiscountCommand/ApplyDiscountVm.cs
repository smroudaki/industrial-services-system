using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Discounts.Queries.ApplyDiscountCommand
{
    public class ApplyDiscountVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int PayAmount { get; set; }
    }
}
