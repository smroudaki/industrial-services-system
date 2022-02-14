using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Tags.Queries.GetAllTags;

namespace WebUI.Controllers
{
    [Authorize]
    public class TagController : ApiController
    {
        /// <summary>
        /// دریافت 100 برچسب برتر
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<AllTagsVm>> GetAll()
        {
            return await Mediator.Send(new GetAllTagsQuery());
        }
    }
}