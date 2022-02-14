using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllContractors
{
    public class GetAllContractorsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int Count { get; set; }

        public IEnumerable<GetAllContractorsDto> Contractors { get; set; }
    }
}
