using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Codes.Queries.GetCodesByCodeGroupGuid
{
    public class GetCodesByCodeGroupGuidVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetCodesByCodeGroupGuidDto> Codes { get; set; }
    }
}