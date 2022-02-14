using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum SendContactUsMessgae
    {
        Success = 1,
        CategoryNotFound = 2
    }

    public enum GetAllContactUsMessagesState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        NotAnyMessages = 4
    }

    public enum ChangeContactUsMessageStateState
    {
        Success = 1,
        ContactUsMessageNotFound = 2,
        StateCodeNotFound = 3
    }
}
