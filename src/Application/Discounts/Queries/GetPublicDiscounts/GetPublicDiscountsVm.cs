using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Discounts.Queries.GetPublicDiscounts
{
    public class GetPublicDiscountsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetPublicDiscountsDto> PublicDiscounts { get; set; }
    }
}
