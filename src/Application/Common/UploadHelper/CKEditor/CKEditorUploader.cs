using System;
using System.Collections.Generic;
using System.Text;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IndustrialServicesSystem.Domain.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace IndustrialServicesSystem.Application.Common.UploadHelper.CKEditor
{
    public class CKEditorUploader : IRequest<CKEditorDto>
    {
        public IFormFile File { get; set; }

        public string WebRootPath { get; set; }

        public class CKEditorUploaderHandler : IRequestHandler<CKEditorUploader, CKEditorDto>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public CKEditorUploaderHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<CKEditorDto> Handle(CKEditorUploader request, CancellationToken cancellationToken)
            {
                var fileName = request.File.FileName;
                var extention = fileName.Substring(fileName.LastIndexOf('.'));
                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extention;
                var path = Path.Combine(Directory.GetCurrentDirectory(), request.WebRootPath, "Uploads", newFileName);
                var stream = new FileStream(path, FileMode.Create);

                await request.File.CopyToAsync(stream);

                var typeCode = await _context.Code
                    .Where(x => x.Name.Equals(request.File.ContentType) && !x.IsDelete)
                    .SingleOrDefaultAsync(cancellationToken);

                if (typeCode == null)
                {
                    return new CKEditorDto
                    {
                        Url = null
                    };
                }

                var document = new Document
                {
                    TypeCodeId = typeCode.CodeId,
                    Path = Path.Combine("http://api.IndustrialServicesSystem.com", "Uploads", newFileName),
                    Size = request.File.Length,
                    Name = newFileName
                };

                _context.Document.Add(document);

                await _context.SaveChangesAsync(cancellationToken);

                return new CKEditorDto
                {
                    Url = document.Path
                };
            }
        }
    }
}
