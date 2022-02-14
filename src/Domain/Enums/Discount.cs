using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum CreatePublicDiscountState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        TypeCodeNotFound = 4
    }

    public enum ApplyDiscountState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        DiscountValueNotValid = 4
    }

    public enum GetPublicDiscountsState
    {
        Success = 1,
        NotAnyPublicDiscountsFound = 2
    }

    public enum DeletePublicDiscountState
    {
        Success = 1,
        PublicDicountNotFound = 2
    }
}
