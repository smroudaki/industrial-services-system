using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum CreateOrderState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        CategoryNotFound = 4
    }

    public enum FinishOrderState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4,
        OrderNotFound = 5,
        OrderNotAcceptedBefore = 6,
        OrderDoneBefore = 7,
        OrderCancelledBefore = 8,
        OrderRequestAllowedBefore = 9
    }

    public enum GetOrdersForContractorState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        CategoryNotFound = 4,
        NotAnyCategoriesFound = 5,
        NotAnyOrdersFound = 6
    }

    public enum GetClientOrdersState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        StateNotFound = 4,
        NotAnyOrdersFound = 5
    }

    public enum GetOrdersForAdminState
    {
        Success = 1,
        CurrentUserNotFound = 2,
        AdminNotFound = 3,
        StateNotFound = 4,
        NotAnyOrdersFound = 5,
        UserNotFound = 6
    }

    public enum DeleteOrderState
    {
        Success = 1,
        OrderNotFound = 2
    }

    public enum GetOrdersCountByStateGuidState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        StateNotFound = 4
    }
}
