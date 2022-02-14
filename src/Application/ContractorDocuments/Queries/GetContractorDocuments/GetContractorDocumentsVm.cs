using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.ContractorDocuments.Queries.GetContractorDocuments
{
    public class GetContractorDocumentsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetContractorDocumentsDto> ContractorDocuments { get; set; }
    }
}
