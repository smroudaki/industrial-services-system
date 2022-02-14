using System;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;

namespace IndustrialServicesSystem.Application.Codes.Queries.GetCodesByCodeGroupGuid
{
    public class GetCodesByCodeGroupGuidDto : IMapFrom<Code>
    {
        public Guid CodeGuid { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}