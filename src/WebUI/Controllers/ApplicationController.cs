using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Applications.Commands.UpdateApplication;
using IndustrialServicesSystem.Application.Applications.Queries.GetAllApplications;

namespace WebUI.Controllers
{
    [Authorize]
    public class ApplicationController : ApiController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ApplicationController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// ویرایش اپلیکیشن
        /// </summary>
        /// <param name="command">اطلاعات اپلیکیشن</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<UpdateApplicationVm>> Update(UpdateApplicationDto command)
        {
            return await Mediator.Send(new UpdateApplicationCommand());
        }

        /// <summary>
        /// دریافت تمامی اپلیکیشن ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllApplicationsVm>> GetAll()
        {
            return await Mediator.Send(new GetAllApplicationsQuery());
        }
    }
}
