using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetContractorCategories
{
    public class GetContractorCategoriesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetContractorCategoriesDto> ContractorCategories { get; set; }
    }
}
