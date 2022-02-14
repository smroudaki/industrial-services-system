using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllProvinceCities
{
    public class GetAllProvinceCitiesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetAllProvinceCitiesDto> Cities { get; set; }
    }
}
