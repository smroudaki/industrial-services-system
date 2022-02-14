﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Enums
{
    public enum CreatePaymentState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        DiscountCodeNotValid = 4,
        NullReferencePaymentRequest = 5
    }

    public enum VerifyPaymentState
    {
        Success = 1,
        PaymentNotFound = 2,
        InvalidPayment = 3
    }

    public enum GetAllPaymentsState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        InvalidStartDate = 4,
        InvalidEndDate = 5,
        NotAnyPaymentsFound = 6
    }

    public enum GetPaymentByGuidState
    {
        Success = 1,
        UserNotFound = 2,
        AdminNotFound = 3,
        PaymentNotFound = 4
    }
}
