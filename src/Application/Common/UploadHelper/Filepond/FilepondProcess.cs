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

namespace IndustrialServicesSystem.Application.Common.UploadHelper.Filepond
{
    public class FilepondProcess : IRequest<Guid?>
    {
        public IFormFile Filepond { get; set; }

        public string WebRootPath { get; set; }

        public class FilepondProcessHandler : IRequestHandler<FilepondProcess, Guid?>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public FilepondProcessHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<Guid?> Handle(FilepondProcess request, CancellationToken cancellationToken)
            {
                var fileName = request.Filepond.FileName;
                var extention = fileName.Substring(fileName.LastIndexOf('.'));
                var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extention;
                var path = Path.Combine(Directory.GetCurrentDirectory(), request.WebRootPath, "Uploads", newFileName);
                var stream = new FileStream(path, FileMode.Create);

                await request.Filepond.CopyToAsync(stream);

                var typeCode = _context.Code
                    .Where(x => x.Name.Equals(request.Filepond.ContentType) && !x.IsDelete)
                    .SingleOrDefaultAsync(cancellationToken);
                
                if (typeCode.Result == null) return null;

                var document = new Document
                {
                    TypeCodeId = typeCode.Result.CodeId,
                    Path = Path.Combine("http://api.IndustrialServicesSystem.com", "Uploads", newFileName),
                    Size = request.Filepond.Length,
                    Name = newFileName
                };

                _context.Document.Add(document);

                await _context.SaveChangesAsync(cancellationToken);

                return document.DocumentGuid;
            }
        }
    }
}
