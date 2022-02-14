using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum CreateComplaintState
    {
        Success = 1,
        UserNotFound = 2
    }

    public enum GetAllComplaintsState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        NotAnyComplaints = 4
    }

    public enum ChangeComplaintMessageStateState
    {
        Success = 1,
        ComplaintMessageNotFound = 2,
        StateCodeNotFound = 3
    }
}
