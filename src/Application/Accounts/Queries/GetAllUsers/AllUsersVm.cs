using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllUsers
{
    public class AllUsersVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
