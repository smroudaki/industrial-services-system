using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Complaints.Commands.ChangeContactUsMessageState
{
    public class ChangeContactUsMessageStateVm
    {
        public string Message { get; set; }

        public int State { get; set; }
    }
}
