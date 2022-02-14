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
using IndustrialServicesSystem.Application.Accounts.Commands.RegisterClient;

namespace IndustrialServicesSystem.Application.Contractors.Commands.CompleteContractorProfile
{
    public class CompleteContractorProfileCommand : IRequest<CompleteContractorProfileVm>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string AboutMe { get; set; }

        public string Telephone { get; set; }

        public string Website { get; set; }

        public string Instagram { get; set; }

        public string Telegram { get; set; }

        public string Linkedin { get; set; }

        public string Whatsapp { get; set; }

        public class RegisterContractorHandler : IRequestHandler<CompleteContractorProfileCommand, CompleteContractorProfileVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public RegisterContractorHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<CompleteContractorProfileVm> Handle(CompleteContractorProfileCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new CompleteContractorProfileVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)CompleteContractorProfileState.UserNotFound
                };

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null) return new CompleteContractorProfileVm()
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)CompleteContractorProfileState.ContractorNotFound
                };

                contractor.User.FirstName = request.FirstName;
                contractor.User.LastName = request.LastName;
                contractor.Address = request.Address;
                contractor.AboutMe = request.AboutMe;
                contractor.Telephone = request.Telephone;
                contractor.Website = request.Website;
                contractor.Instagram = request.Instagram;
                contractor.Telegram = request.Telephone;
                contractor.Linkedin = request.Linkedin;
                contractor.Whatsapp = request.Whatsapp;
                contractor.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new CompleteContractorProfileVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CompleteContractorProfileState.Success
                };
            }
        }
    }
}
