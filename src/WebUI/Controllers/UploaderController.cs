using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IndustrialServicesSystem.Application.Common.UploadHelper.CKEditor;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;

namespace WebUI.Controllers
{
    //[Authorize]
    public class UploaderController : ApiController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploaderController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// بارگذاری سند
        /// </summary>
        /// <param name="formCollection">اطلاعات سند</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult> UploadFile(IFormCollection formCollection)
        {
            if (formCollection == null)
            {
                return BadRequest();
            }

            var documentGuid = await Mediator.Send(new FilepondProcess { Filepond = formCollection.Files[0], WebRootPath = _hostingEnvironment.WebRootPath });

            return Ok(new { documentGuid });
        }

        /// <summary>
        /// بارگذاری سند - FilepondProcess
        /// </summary>
        /// <param name="filepond">اطلاعات سند</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<Guid?>> FilepondProcess(IFormFile filepond)
        {
            if (filepond == null)
            {
                return BadRequest();
            }

            return await Mediator.Send(new FilepondProcess { Filepond = filepond, WebRootPath = _hostingEnvironment.WebRootPath });
        }

        /// <summary>
        /// بارگذاری سند - FilepondRevert
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> FilepondRevert()
        {
            return await Mediator.Send(new FilepondRevert { Body = Request.Body, WebRootPath = _hostingEnvironment.WebRootPath });
        }

        /// <summary>
        /// بارگذاری سند - CKEditor
        /// </summary>
        /// <param name="upload">اطلاعات سند</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CKEditorDto>> CKEditor(IFormFile upload)
        {
            if (upload == null)
            {
                return BadRequest();
            }

            return await Mediator.Send(new CKEditorUploader { File = upload, WebRootPath = _hostingEnvironment.WebRootPath });
        }
    }
}