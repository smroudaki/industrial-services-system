using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Complaints.Commands.ChangeComplaintMessageState
{
    public class ChangeComplaintMessageStateVm
    {
        public string Message { get; set; }

        public int State { get; set; }
    }
}
