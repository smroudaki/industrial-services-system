using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.CodeGroups.Queries.GetAllCodeGroups;

namespace WebUI.Controllers
{
    [Authorize]
    public class CodeGroupController : ApiController
    {
        /// <summary>
        /// دریافت تمامی کد گروه ها
        /// </summary>
        /// <param name="guid">آیدی</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllCodeGroupsVm>> GetAll(Guid guid)
        {
            return await Mediator.Send(new GetAllCodeGroupsQuery());
        }
    }
}
