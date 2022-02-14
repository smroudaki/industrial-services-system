using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Orders.Commands.DeleteOrder;
using IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestsForAdmin;
using IndustrialServicesSystem.Application.Orders.Commands.CreateOrder;
using IndustrialServicesSystem.Application.Orders.Commands.FinishOrder;
using IndustrialServicesSystem.Application.Orders.Queries.GetClientOrders;
using IndustrialServicesSystem.Application.Orders.Queries.GetOrdersForAdmin;
using IndustrialServicesSystem.Application.Orders.Queries.GetOrdersForContractor;
using IndustrialServicesSystem.Application.Orders.Queries.GetOrdersCountByStateGuid;

namespace WebUI.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        /// <summary>
        /// افزودن سفارش جدید
        /// </summary>
        /// <param name="command">اطلاعات سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreateOrderVm>> Create(CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// اتمام سفارش
        /// </summary>
        /// <param name="command">اطلاعات سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<FinishOrderVm>> Finish(FinishOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// دریافت سفارش ها جهت انجام توسط سرویس دهنده
        /// </summary>
        /// <param name="categoryGuid">آیدی دسته بندی</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrdersForContractorVm>> GetOrdersForContractor(Guid? categoryGuid)
        {
            return await Mediator.Send(new GetOrdersForContractorQuery() { CategoryGuid = categoryGuid });
        }

        /// <summary>
        /// دریافت کلیه سفارش ها
        /// </summary>
        /// <param name="userGuid">آیدی کاربر</param>
        /// <param name="stateGuid">آیدی وضعیت سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrdersForAdminVm>> GetAll(Guid? userGuid, Guid? stateGuid)
        {
            return await Mediator.Send(new GetOrdersForAdminQuery() { UserGuid = userGuid, StateGuid = stateGuid });
        }

        /// <summary>
        /// دریافت سفارش های ثبت شده سرویس گیرنده
        /// </summary>
        /// <param name="stateGuid">آیدی وضعیت سفارش</param>
        /// <param name="search">جستجو</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetClientOrdersVm>> GetClientOrders(Guid? stateGuid, string search)
        {
            return await Mediator.Send(new GetClientOrdersQuery() { StateGuid = stateGuid, Search = search });
        }

        /// <summary>
        /// دریافت درخواست های سفارش
        /// </summary>
        /// <param name="orderGuid">آیدی سفارش</param>
        /// <returns></returns>
        [HttpGet("{orderGuid}/[action]")]
        public async Task<ActionResult<GetOrderRequestsForAdminVm>> GetOrderRequests(Guid orderGuid)
        {
            return await Mediator.Send(new GetOrderRequestsForAdminQuery() { OrderGuid = orderGuid });
        }

        /// <summary>
        /// دریافت تعداد سفارش ها
        /// </summary>
        /// <param name="stateGuid">آیدی وضعیت سفارش</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrdersCountByStateGuidVm>> GetCount(Guid stateGuid)
        {
            return await Mediator.Send(new GetOrdersCountByStateGuidQuery() { StateGuid = stateGuid });
        }

        /// <summary>
        /// حذف سفارش
        /// </summary>
        /// <param name="command">آیدی سفارش</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<DeleteOrderVm>> Delete(DeleteOrderCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}