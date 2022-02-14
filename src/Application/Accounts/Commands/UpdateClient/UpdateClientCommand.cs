using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IndustrialServicesSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace IndustrialServicesSystem.Application.Accounts.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<UpdateClientCommandVm>
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid CityGuid { get; set; }

        public Guid GenderGuid { get; set; }

        public Guid? ProfileDocumentGuid { get; set; }

        public class RegisterCommandHandler : IRequestHandler<UpdateClientCommand, UpdateClientCommandVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public RegisterCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<UpdateClientCommandVm> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
            {
                Client client = await _context.Client
                    .Include(x => x.User)
                    .SingleOrDefaultAsync(x => x.User.UserGuid.Equals(request.UserGuid) && !x.IsDelete, cancellationToken);

                if (client == null) return new UpdateClientCommandVm()
                {
                    Message = "سرویس گیرنده مورد نظر یافت نشد",
                    State = (int)UpdateClientState.ClientNotFound
                };

                Code gender = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.GenderGuid, cancellationToken);

                if (gender == null) return new UpdateClientCommandVm()
                {
                    Message = "جنسیت نامعتبر است",
                    State = (int)UpdateClientState.GenderNotFound
                };

                City city = await _context.City
                    .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                if (city == null) return new UpdateClientCommandVm()
                {
                    Message = "اطلاعات مکانی نامعتبر است",
                    State = (int)UpdateClientState.CityNotFound
                };

                if (request.ProfileDocumentGuid != null)
                {
                    Document document = await _context.Document
                        .SingleOrDefaultAsync(x => x.DocumentGuid == request.ProfileDocumentGuid, cancellationToken);

                    if (document == null) return new UpdateClientCommandVm()
                    {
                        Message = "تصویر پروفایل کاربر مورد نظر یافت نشد",
                        State = (int)UpdateClientState.ProfileDocumentNotFound
                    };

                    client.User.ProfileDocumentId = document.DocumentId;
                }

                client.CityId = city.CityId;
                client.User.FirstName = request.FirstName;
                client.User.LastName = request.LastName;
                client.User.GenderCodeId = gender.CodeId;
                client.User.Email = request.Email;
                client.User.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateClientCommandVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)UpdateClientState.Success
                };
            }
        }
    }
}
