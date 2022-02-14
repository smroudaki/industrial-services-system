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

namespace IndustrialServicesSystem.Application.Accounts.Commands.RegisterAdmin
{
    public class RegisterAdminCommand : IRequest<RegisterAdminCommandVm>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid GenderGuid { get; set; }

        public Guid? ProfileDocumentGuid { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterAdminCommand, RegisterAdminCommandVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public RegisterCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<RegisterAdminCommandVm> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
            {
                Admin admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.User.PhoneNumber.Equals(request.PhoneNumber) && !x.User.IsDelete, cancellationToken);

                if (admin != null) return new RegisterAdminCommandVm()
                {
                    Message = "ادمین مورد نظر قبلا ثبت شده است",
                    State = (int)RegisterAdminState.AdminExists
                };

                Code gender = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.GenderGuid, cancellationToken);

                if (gender == null) return new RegisterAdminCommandVm()
                {
                    Message = "جنسیت نامعتبر است",
                    State = (int)RegisterAdminState.GenderNotFound
                };

                User user = new User
                {
                    RoleId = (int)Domain.Enums.Role.Admin,
                    GenderCodeId = gender.CodeId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };

                if (request.ProfileDocumentGuid != null)
                {
                    Document document = await _context.Document
                        .SingleOrDefaultAsync(x => x.DocumentGuid == request.ProfileDocumentGuid, cancellationToken);

                    if (document == null) return new RegisterAdminCommandVm()
                    {
                        Message = "تصویر پروفایل کاربر مورد نظر یافت نشد",
                        State = (int)RegisterAdminState.ProfileDocumentNotFound
                    };

                    user.ProfileDocumentId = document.DocumentId;
                }

                Admin newAdmin = new Admin()
                {
                    User = user
                };

                _context.User.Add(user);
                _context.Admin.Add(newAdmin);

                await _context.SaveChangesAsync(cancellationToken);

                return new RegisterAdminCommandVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)RegisterAdminState.Success 
                };
            }
        }
    }
}
