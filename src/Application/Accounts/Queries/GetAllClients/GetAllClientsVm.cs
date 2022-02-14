using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllClients
{
    public class GetAllClientsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int Count { get; set; }

        public IEnumerable<GetAllClientsDto> Clients { get; set; }
    }
}
