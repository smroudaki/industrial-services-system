using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Payments.Queries.GetPaymentByGuid
{
    public class GetPaymentByGuidVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public GetPaymentByGuidDto Result { get; set; }
    }
}
