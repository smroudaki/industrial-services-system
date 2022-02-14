using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Domain.Entities
{
    public partial class Application
    {
        public int ApplicationId { get; set; }
        public Guid ApplicationGuid { get; set; }
        public string Name { get; set; }
        public string MinVersionCode { get; set; }
        public string LatestVersionCode { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
