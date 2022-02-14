﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Accounts.Commands.Login;
using IndustrialServicesSystem.Application.Accounts.Commands.Authenticate;
using IndustrialServicesSystem.Application.Accounts.Queries.GetUserByMobile;
using IndustrialServicesSystem.Application.Accounts.Queries.GetUserByGuid;
using IndustrialServicesSystem.Application.Accounts.Queries.GetUserPermissionsByGuid;
using IndustrialServicesSystem.Application.Accounts.Queries.GetAllUsers;
using Microsoft.AspNetCore.Authorization;
using IndustrialServicesSystem.Application.Accounts.Commands.ChangeUserActiveness;
using IndustrialServicesSystem.Application.Accounts.Commands.DeleteUser;
using IndustrialServicesSystem.Application.Accounts.Commands.RegisterClient;
using IndustrialServicesSystem.Application.Accounts.Commands.RegisterContractor;
using IndustrialServicesSystem.Application.Accounts.Queries.GetAllProvinces;
using IndustrialServicesSystem.Application.Accounts.Queries.GetAllProvinceCities;
using IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentAdminUser;
using IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentClientUser;
using IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentContractorUser;
using IndustrialServicesSystem.Application.Users.Commands.SetProfilePicture;
using IndustrialServicesSystem.Application.Accounts.Queries.GetAllClients;
using IndustrialServicesSystem.Application.Accounts.Queries.GetAllContractors;
using IndustrialServicesSystem.Application.Accounts.Queries.GetAllAdmins;
using IndustrialServicesSystem.Application.Payments.Queries.GetLoyalContractors;
using IndustrialServicesSystem.Application.Accounts.Commands.RegisterAdmin;
using IndustrialServicesSystem.Application.Accounts.Commands.UpdateClient;
using IndustrialServicesSystem.Application.Accounts.Commands.UpdateContractor;
using IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentUserRole;

namespace WebUI.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        /// <summary>
        /// دریافت اطلاعات کاربر از طریق شماره موبایل
        /// </summary>
        /// <param name="mobile">شماره موبایل کاربر</param>
        /// <returns></returns>
        [HttpGet("[action]/{mobile}")]
        public async Task<ActionResult<UserByMobileVm>> GetByMobile(string mobile)
        {
            return await Mediator.Send(new GetUserByMobileQuery { Mobile = mobile });
        }

        /// <summary>
        /// دریافت اطلاعات کاربر از طریق آیدی
        /// </summary>
        /// <param name="guid">آیدی کاربر</param>
        /// <returns></returns>
        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<UserByGuidVm>> GetByGuid(Guid guid)
        {
            return await Mediator.Send(new GetUserByGuidQuery() { UserGuid = guid });
        }

        /// <summary>
        /// دریافت نقش کاربر لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCurrentUserRoleVm>> GetCurrentUserRole()
        {
            return await Mediator.Send(new GetCurrentUserRoleQuery());
        }

        /// <summary>
        /// دریافت اطلاعات کاربر ادمین لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCurrentAdminUserVm>> GetCurrentAdminUser()
        {
            return await Mediator.Send(new GetCurrentAdminUserQuery());
        }

        /// <summary>
        /// دریافت اطلاعات کاربر سرویس دهنده لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCurrentContractorUserVm>> GetCurrentContractorUser()
        {
            return await Mediator.Send(new GetCurrentContractorUserQuery());
        }

        /// <summary>
        /// دریافت اطلاعات کاربر سرویس گیرنده لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCurrentClientUserVm>> GetCurrentClientUser()
        {
            return await Mediator.Send(new GetCurrentClientUserQuery());
        }

        /// <summary>
        /// دریافت اطلاعات تمامی کاربران
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<AllUsersVm>> GetAll()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        /// <summary>
        /// دربافت تمامی سرویس گیرندگان
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllClientsVm>> GetAllClients()
        {
            return await Mediator.Send(new GetAllClientsQuery());
        }

        /// <summary>
        /// دربافت تمامی سرویس دهندگان
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllContractorsVm>> GetAllContractors()
        {
            return await Mediator.Send(new GetAllContractorsQuery());
        }

        /// <summary>
        /// دربافت سرویس دهندگان وفادار
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetLoyalContractorsVm>> GetLoyalContractors()
        {
            return await Mediator.Send(new GetLoyalContractorsQuery());
        }

        /// <summary>
        /// دربافت تمامی ادمین ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllAdminsVm>> GetAllAdmins()
        {
            return await Mediator.Send(new GetAllAdminsQuery());
        }

        /// <summary>
        /// دریافت دسترسی های کاربر از طریق آیدی
        /// </summary>
        /// <param name="guid">آیدی کاربر</param>
        /// <returns></returns>
        [HttpGet("{guid}/[action]")]
        public async Task<ActionResult<UserPermissionsVm>> GetPermissions(Guid guid)
        {
            return await Mediator.Send(new GetUserPermissionsByGuidQuery { UserGuid = guid });
        }

        /// <summary>
        /// دریافت تمامی استان ها
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Provinces")]
        public async Task<ActionResult<GetAllProvincesVm>> GetAllProvinces()
        {
            return await Mediator.Send(new GetAllProvincesQuery());
        }

        /// <summary>
        /// دریافت تمامی شهرهای واقع یک استان
        /// </summary>
        /// <param name="guid">آیدی استان</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Provinces/{guid}/Cities")]
        public async Task<ActionResult<GetAllProvinceCitiesVm>> GetAllProvinceCities(Guid guid)
        {
            return await Mediator.Send(new GetAllProvinceCitiesQuery { ProvinceGuid = guid });
        }

        /// <summary>
        /// افزودن سرویس گیرنده جدید
        /// </summary>
        /// <param name="command">اطلاعات سرویس گیرنده</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterClientCommandVm>> RegisterClient(RegisterClientCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// افزودن ادمین جدید
        /// </summary>
        /// <param name="command">اطلاعات ادمین</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterAdminCommandVm>> RegisterAdmin(RegisterAdminCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// افزودن سرویس دهنده جدید
        /// </summary>
        /// <param name="command">اطلاعات سرویس دهنده</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterContractorVm>> RegisterContractor(RegisterContractorCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش سرویس گیرنده
        /// </summary>
        /// <param name="command">اطلاعات سرویس گیرنده</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<UpdateClientCommandVm>> UpdateClient(UpdateClientCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش سرویس دهنده
        /// </summary>
        /// <param name="command">اطلاعات سرویس دهنده</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<UpdateContractorCommandVm>> UpdateContractor(UpdateContractorCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر تصویر پروفایل کاربر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<SetProfilePictureVm>> SetProfilePicture(SetProfilePictureCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ورود کاربر
        /// </summary>
        /// <param name="command">اطلاعات ورود</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<LoginCommandVm>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// احراز هویت کاربر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<AuthenticateVm>> Authenticate(AuthenticateCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت اکانت کاربر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ChangeUserActivenessVm>> ChangeActiveness(ChangeUserActivenessCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command">آیدی کاربر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<DeleteUserVm>> Delete(DeleteUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}