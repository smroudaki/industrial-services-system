using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum UpdateApplicationState
    {
        Success = 1,
        ApplicationNotFound = 2,
        DocumentNotFound = 3
    }

    public enum GetAllApplicationsState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        NotFound = 4
    }
}
