using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum ChangeOrderRequestPriceState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        SettingNotFound = 4
    }

    public enum ChangeUserInitialCreditState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        SettingNotFound = 4
    }

    public enum GetOrderRequestsPriceState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        SettingNotFound = 4
    }

    public enum GetUsersInitialCreditState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        SettingNotFound = 4
    }
}
