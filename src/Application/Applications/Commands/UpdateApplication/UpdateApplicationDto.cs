using System;

namespace IndustrialServicesSystem.Application.Applications.Commands.UpdateApplication
{
    public class UpdateApplicationDto
    {
        public Guid ApplicationGuid { get; set; }

        public string Name { get; set; }

        public string VersionCode { get; set; }

        public string DocumentGuid { get; set; }
    }
}