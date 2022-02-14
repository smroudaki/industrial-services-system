using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.ContactUsMessages.Commands.SendMessage;
using IndustrialServicesSystem.Application.ContactUsMessages.Queries.GetAllContactUsMessages;

namespace WebUI.Controllers
{
    public class ContactUsController : ApiController
    {
        /// <summary>
        /// ارسال پیام تماس با ما
        /// </summary>
        /// <param name="command">اطلاعات تماس با ما</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<SendMessageVm> SendMessage(SendMessageCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// دریافت تمامی پیام های ارتباط با ما
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllContactUsMessagesVm>> GetAll()
        {
            return await Mediator.Send(new GetAllContactUsMessagesQuery());
        }
    }
}