using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum AuthenticateState
    {
        Success = 1,
        WrongCode = 2,
        UserNotFound = 3,
        CodeNotFound = 4,
        PlatformNotFound = 5,
        UserNotActivated = 6
    }

    public enum RegisterClientState
    {
        Success = 1,
        UserExists = 2,
        ClientNotFound = 3,
        CityNotFound = 4
    }

    public enum RegisterContractorState
    {
        Success = 1,
        UserExists = 2,
        GenderNotFound = 3,
        BusinessTypeNotFound = 4,
        CityNotFound = 5,
        ContractorNotFound = 6,
        SettingNotFound = 7,
        IntroductionCodeNotFound = 8
    }

    public enum RegisterAdminState
    {
        Success = 1,
        AdminExists = 2,
        GenderNotFound = 3,
        ProfileDocumentNotFound = 4
    }

    public enum UpdateClientState
    {
        Success = 1,
        ClientNotFound = 2,
        GenderNotFound = 3,
        CityNotFound = 4,
        ProfileDocumentNotFound = 5
    }

    public enum UpdateContractorState
    {
        Success = 1,
        ContractorNotFound = 2,
        GenderNotFound = 3,
        BusinessNotFound = 4,
        CityNotFound = 5,
        ProfileDocumentNotFound = 6
    }

    public enum LoginState
    {
        Success = 1,
        UserNotFound = 2,
        UserNotActivated = 3,
        UserNotRegistered = 4
    }

    public enum DeleteUserState
    {
        Success = 1,
        UserNotFound = 2
    }

    public enum ChangeUserActivenessState
    {
        Success = 1,
        UserNotFound = 2
    }

    public enum GetAllProvinceCitiesState
    {
        Success = 1,
        ProvinceNotFound = 2,
        ProvinceCitiesNotFound = 3
    }

    public enum GetAllProvincesState
    {
        Success = 1,
        ProvinceNotFound = 2
    }

    public enum GetCurrentUserState
    {
        Success = 1,
        UserNotFound = 2
    }

    public enum GetAllClientsState
    {
        Success = 1,
        NotAnyClientsFound = 2
    }

    public enum GetAllContractorsState
    {
        Success = 1,
        NotAnyContractorsFound = 2
    }

    public enum GetAllAdminsState
    {
        Success = 1,
        NotAnyAdminsFound = 2
    }

    public enum GetContractorPaymentsState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        NotAnyPaymentsFound = 4
    }

    public enum GetLoyalContractorsState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        NotAnyContractorsFound = 4
    }
}
