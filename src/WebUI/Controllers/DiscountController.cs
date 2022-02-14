using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Discounts.Commands.CreatePublicDiscount;
using IndustrialServicesSystem.Application.Discounts.Commands.DeletePublicDiscount;
using IndustrialServicesSystem.Application.Discounts.Queries.GetPublicDiscounts;

namespace WebUI.Controllers
{
    [Authorize]
    public class DiscountController : ApiController
    {
        /// <summary>
        /// افزودن کد تخفیف عمومی
        /// </summary>
        /// <param name="command">اطلاعات کد تخفیف عمومی</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreatePublicDiscountVm>> CreatePublicDiscount(CreatePublicDiscountCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// دریافت کد تخفیف های عمومی
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetPublicDiscountsVm>> GetAll()
        {
            return await Mediator.Send(new GetPublicDiscountsQuery());
        }

        /// <summary>
        /// حذف کد تخفیف عمومی
        /// </summary>
        /// <param name="command">آیدی کد تخفیف عمومی</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<DeletePublicDiscountVm>> Delete(DeletePublicDiscountCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
