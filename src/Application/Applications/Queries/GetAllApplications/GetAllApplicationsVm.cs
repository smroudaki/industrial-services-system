using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Applications.Queries.GetAllApplications
{
    public class GetAllApplicationsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetAllApplicationsDto> Applications { get; set; } = new List<GetAllApplicationsDto>();
    }
}
