using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum CreateOrderRequestState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        OrderNotFound = 4,
        OrderRequestCreatedBefore = 5,
        SettingNotFound = 6,
        CreditNotEnough = 7
    }

    public enum AcceptOrderRequestState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4,
        OrderRequestAcceptedBefore = 5,
        OrderDoneBefore = 6,
        OrderCancelledBefore = 7,
        OrderRequestNotAllowed = 8
    }

    public enum AllowOrderRequestState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4,
        OrderRequestAcceptedBefore = 5,
        OrderDoneBefore = 6,
        OrderCancelledBefore = 7,
        OrderRequestAllowedBefore = 8
    }

    public enum GetOrderRequestsForClientState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderNotFound = 4,
        StateNotFound = 5,
        NotAnyOrderRequestsFound = 6
    }

    public enum GetOrderRequestsForAdminState
    {
        Success = 1,
        CurrentUserNotFound = 2,
        AdminNotFound = 3,
        OrderNotFound = 4,
        NotAnyOrderRequestsFound = 5,
        UserNotFound = 6
    }

    public enum GetContractorOrderRequestsState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        StateNotFound = 4,
        NotAnyOrderRequestsFound = 5
    }

    public enum GetOrderRequestAllowingStatusState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4
    }

    public enum GetOrderRequestAcceptanceStatusState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4
    }

    public enum GetOrderRequestAccessStatusState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4
    }

    public enum GetChatRoomState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        NotAnyChatRoomsFound = 4
    }

    public enum GetMessagesState
    {
        Success = 1,
        UserNotFound = 2,
        OrderRequestNotFound = 3,
        NotAnyChatMessagesFound = 4
    }

    public enum DeleteOrderRequestState
    {
        Success = 1,
        OrderRequestNotFound = 2
    }

    public enum GetMonthlyIncomeState
    {
        Success = 1,
        NotAnyOrderRequestFound = 2
    }
}
