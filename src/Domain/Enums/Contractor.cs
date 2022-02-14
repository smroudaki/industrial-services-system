using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum GetContractorCategoriesState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        NotAnyContractorCategoriesFound = 4
    }
    
    public enum ChangeContractorCityState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        CityNotFound = 4
    }

    public enum CompleteContractorProfileState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3
    }

    public enum GetContractorState
    {
        Success = 1,
        ContractorNotFound = 2,
        UserNotFound = 3
    }

    public enum CreateDocumentState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        TitleCodeNotFound = 4,
        DocumentNotFound = 5
    }

    public enum GetDocumentsState
    {
        Success = 1,
        ContractorNotFound = 2,
        NotFound = 3
    }

    public enum ChargeContractorCreditState
    {
        Success = 1,
        ContractorNotFound = 2
    }
}
