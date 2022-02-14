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

namespace IndustrialServicesSystem.Application.Accounts.Commands.UpdateContractor
{
    public class UpdateContractorCommand : IRequest<UpdateContractorCommandVm>
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string AboutMe { get; set; }

        public string Telephone { get; set; }

        public string Instagram { get; set; }

        public string Telegram { get; set; }

        public string Linkedin { get; set; }

        public string Whatsapp { get; set; }

        public string Website { get; set; }

        public Guid CityGuid { get; set; }

        public Guid GenderGuid { get; set; }

        public Guid BusinessTypeGuid { get; set; }

        public Guid? ProfileDocumentGuid { get; set; }

        public class RegisterCommandHandler : IRequestHandler<UpdateContractorCommand, UpdateContractorCommandVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public RegisterCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<UpdateContractorCommandVm> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
            {
                Contractor contractor = await _context.Contractor
                    .Include(x => x.User)
                    .SingleOrDefaultAsync(x => x.User.UserGuid.Equals(request.UserGuid) && !x.IsDelete, cancellationToken);

                if (contractor == null) return new UpdateContractorCommandVm()
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)UpdateContractorState.ContractorNotFound
                };

                Code gender = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.GenderGuid, cancellationToken);

                if (gender == null) return new UpdateContractorCommandVm()
                {
                    Message = "جنسیت نامعتبر است",
                    State = (int)UpdateContractorState.GenderNotFound
                };

                Code business = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.BusinessTypeGuid, cancellationToken);

                if (business == null) return new UpdateContractorCommandVm()
                {
                    Message = "نوع کسب و کار نامعتبر است",
                    State = (int)UpdateContractorState.BusinessNotFound
                };

                City city = await _context.City
                    .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                if (city == null) return new UpdateContractorCommandVm()
                {
                    Message = "اطلاعات مکانی نامعتبر است",
                    State = (int)UpdateContractorState.CityNotFound
                };

                if (request.ProfileDocumentGuid != null)
                {
                    Document document = await _context.Document
                        .SingleOrDefaultAsync(x => x.DocumentGuid == request.ProfileDocumentGuid, cancellationToken);

                    if (document == null) return new UpdateContractorCommandVm()
                    {
                        Message = "تصویر پروفایل کاربر مورد نظر یافت نشد",
                        State = (int)UpdateContractorState.ProfileDocumentNotFound
                    };

                    contractor.User.ProfileDocumentId = document.DocumentId;
                }

                contractor.CityId = city.CityId;
                contractor.BusinessTypeCodeId = business.CodeId;
                contractor.Address = request.Address;
                contractor.Latitude = request.Latitude;
                contractor.Longitude = request.Longitude;
                contractor.AboutMe = request.AboutMe;
                contractor.Telephone = request.Telephone;
                contractor.Instagram = request.Instagram;
                contractor.Telegram = request.Telegram;
                contractor.Linkedin = request.Linkedin;
                contractor.Whatsapp = request.Whatsapp;
                contractor.Website = request.Website;
                contractor.User.FirstName = request.FirstName;
                contractor.User.LastName = request.LastName;
                contractor.User.GenderCodeId = gender.CodeId;
                contractor.User.Email = request.Email;
                contractor.User.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateContractorCommandVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)UpdateContractorState.Success
                };
            }
        }
    }
}
