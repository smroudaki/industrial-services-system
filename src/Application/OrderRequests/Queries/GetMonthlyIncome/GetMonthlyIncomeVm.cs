using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetMonthlyIncome
{
    public class GetMonthlyIncomeVm
    {
        public string Message { get; set; }
        public int State { get; set; }
        public List<int> Incomes { get; set; }
    }
}