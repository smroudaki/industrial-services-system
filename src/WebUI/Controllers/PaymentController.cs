using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IndustrialServicesSystem.Application.Contractors.Commands.ChargeContractorCredit;
using IndustrialServicesSystem.Application.Discounts.Queries.ApplyDiscountCommand;
using IndustrialServicesSystem.Application.Payments.Commands.CreatePayment;
using IndustrialServicesSystem.Application.Payments.Commands.VerifyPayment;
using IndustrialServicesSystem.Application.Payments.Queries.GetAllPayments;
using IndustrialServicesSystem.Application.Payments.Queries.GetPaymentByGuid;

namespace WebUI.Controllers
{
    [Authorize]
    public class PaymentController : ApiController
    {
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// دریافت کلیه پرداختی ها
        /// </summary>
        /// <param name="contractorGuid">آیدی سرویس دهنده</param>
        /// <param name="startDate">از تاریخ</param>
        /// <param name="endDate">تا تاریخ</param>
        /// <param name="successfulStatus">وضعیت پرداخت</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllPaymentsVm>> GetAll(Guid? contractorGuid = null, string startDate = null, string endDate = null, bool? successfulStatus = null)
        {
            return await Mediator.Send(new GetAllPaymentsQuery() { ContractorGuid = contractorGuid, StartDate = startDate, EndDate = endDate, SuccessfulStatus = successfulStatus });
        }

        /// <summary>
        /// دریافت پرداخت
        /// </summary>
        /// <param name="paymentGuid">آیدی پرداخت</param>
        /// <returns></returns>
        [HttpGet("[action]/{paymentGuid}")]
        public async Task<ActionResult<GetPaymentByGuidVm>> Get(Guid paymentGuid)
        {
            return await Mediator.Send(new GetPaymentByGuidQuery() { PaymentGuid = paymentGuid });
        }

        /// <summary>
        /// دریافت مبلغ نهایی
        /// </summary>
        /// <param name="realAmount">مبلغ واقعی</param>
        /// <param name="discountValue">کد تخفیف</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<ApplyDiscountVm>> GetPayAmount(int realAmount, string discountValue)
        {
            return await Mediator.Send(new ApplyDiscountQuery() { RealAmount = realAmount, DiscountValue = discountValue });
        }

        /// <summary>
        /// افزودن پرداخت
        /// </summary>
        /// <param name="command">اطلاعات درخواست پرداخت</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreatePaymentVm>> Create(CreatePaymentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// پرداخت آنلاین
        /// </summary>
        /// <param name="paymentGuid">آیدی پرداخت</param>
        /// <returns></returns>
        [HttpGet("[action]/{paymentGuid}")]
        [AllowAnonymous]
        public async Task<ActionResult> OnlinePayment(Guid paymentGuid)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                VerifyPaymentVm res = await Mediator.Send(new VerifyPaymentCommand() { PaymentGuid = paymentGuid, Authority = HttpContext.Request.Query["Authority"].ToString() });

                if (res.State == 1)
                {
                    GetPaymentByGuidVm payment = await Mediator.Send(new GetPaymentByGuidQuery() { PaymentGuid = paymentGuid });

                    if (payment.State != 1)
                    {
                        return Redirect("http://panel.IndustrialServicesSystem.com/payment?result=failed&trackingToken=");
                    }

                    ChargeContractorCreditVm charge = await Mediator.Send(new ChargeContractorCreditCommand() { ContractorGuid = payment.Result.ContractorGuid, Cost = payment.Result.Cost + payment.Result.Discount });

                    if (charge.State != 1)
                    {
                        return Redirect($"http://panel.IndustrialServicesSystem.com/payment?result=failed&trackingToken={payment.Result.TrackingToken}");
                    }

                    return Redirect($"http://panel.IndustrialServicesSystem.com/payment?result=successful&trackingToken={payment.Result.TrackingToken}");
                }
            }

            return Redirect("http://panel.IndustrialServicesSystem.com/payment?result=failed&trackingToken=");
        }
    }
}
