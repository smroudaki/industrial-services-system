using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int SentMessagesCount { get; set; }
    }
}
