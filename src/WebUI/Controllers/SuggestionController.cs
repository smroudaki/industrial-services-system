using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Contact.Commands.CreateSuggestion;
using IndustrialServicesSystem.Application.Posts.Queries.GetAllSuggestions;

namespace WebUI.Controllers
{
    [Authorize]
    public class SuggestionController : ApiController
    {
        /// <summary>
        /// ارسال انتقاد و پیشنهاد
        /// </summary>
        /// <param name="command">اطلاعات انتقاد و پیشنهاد</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<CreateSuggestionVm> Create(CreateSuggestionCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// دریافت تمامی انتقادات و پیشنهادات
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllSuggestionsVm>> GetAll()
        {
            return await Mediator.Send(new GetAllSuggestionsQuery());
        }
    }
}
