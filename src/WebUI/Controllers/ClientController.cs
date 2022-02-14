using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Contractors.Commands.ChangeClientCity;

namespace WebUI.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        /// <summary>
        /// تغییر شهر
        /// </summary>
        /// <param name="command">اطلاعات شهر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ChangeClientCityVm>> ChangeCity(ChangeClientCityCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
