using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Applications.Commands.UpdateApplication
{
    public class UpdateApplicationCommand : IRequest<UpdateApplicationVm>
    {
        public Guid ApplicationGuid { get; set; }

        public string Name { get; set; }

        public string MinVersionCode { get; set; }

        public string LatestVersionCode { get; set; }

        public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, UpdateApplicationVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public UpdateApplicationCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<UpdateApplicationVm> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
            {
                var application = await _context.Application
                    .SingleOrDefaultAsync(x => x.ApplicationGuid == request.ApplicationGuid && !x.IsDelete);

                if (application == null) return new UpdateApplicationVm()
                {
                    Message = "اپلیکیشن مورد نظر یافت نشد",
                    State = (int)UpdateApplicationState.ApplicationNotFound
                };

                application.Name = request.Name;
                application.MinVersionCode = request.MinVersionCode;
                application.LatestVersionCode = request.LatestVersionCode;
                application.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateApplicationVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)UpdateApplicationState.Success
                };
            }
        }
    }
}
