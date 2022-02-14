using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.ContractorDocuments.Commands.CreateContractorDocument;
using IndustrialServicesSystem.Application.ContractorDocuments.Queries.GetContractorDocuments;
using IndustrialServicesSystem.Application.Contractors.Commands.ChangeContractorCity;
using IndustrialServicesSystem.Application.Contractors.Commands.CompleteContractorProfile;
using IndustrialServicesSystem.Application.Contractors.Queries.GetContractor;
using IndustrialServicesSystem.Application.OrderRequests.Queries.GetContractorCategories;
using IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestsForAdmin;

namespace WebUI.Controllers
{
    [Authorize]
    public class ContractorController : ApiController
    {
        /// <summary>
        /// دریافت سرویس دهنده
        /// </summary>
        /// <returns></returns>
        [HttpGet("{contractorGuid}")]
        public async Task<ActionResult<GetContractorVm>> Get(Guid contractorGuid)
        {
            return await Mediator.Send(new GetContractorQuery() { ContractorGuid = contractorGuid });
        }

        /// <summary>
        /// دریافت خدمات سرویس دهنده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetContractorCategoriesVm>> GetCategories()
        {
            return await Mediator.Send(new GetContractorCategoriesQuery());
        }


        /// <summary>
        /// دریافت درخواست های سفارش سرویس دهنده
        /// </summary>
        /// <param name="userGuid">آیدی کاربر</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetOrderRequestsForAdminVm>> GetOrderRequests(Guid userGuid)
        {
            return await Mediator.Send(new GetOrderRequestsForAdminQuery() { UserGuid = userGuid });
        }


        /// <summary>
        /// تغییر شهر
        /// </summary>
        /// <param name="command">اطلاعات شهر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ChangeContractorCityVm>> ChangeCity(ChangeContractorCityCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تکمیل پروفایل
        /// </summary>
        /// <param name="command">اطلاعات پروفایل</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CompleteContractorProfileVm>> CompleteProfile(CompleteContractorProfileCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ارسال مدارک
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreateContractorDocumentVm>> CreateDocument(CreateContractorDocumentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// دریافت مدارک
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetContractorDocumentsVm>> GetDocuments(Guid userGuid)
        {
            return await Mediator.Send(new GetContractorDocumentsQuery() { UserGuid = userGuid });
        }
    }
}