using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllAdmins
{
    public class GetAllAdminsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetAllAdminsDto> Admins { get; set; }
    }
}
