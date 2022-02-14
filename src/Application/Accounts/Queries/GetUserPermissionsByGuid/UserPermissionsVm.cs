using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetUserPermissionsByGuid
{
    public class UserPermissionsVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<RolePermissionDto> RolePermissions { get; set; }

        public IEnumerable<CustomPermissionDto> CustomPermissions { get; set; }
    }
}