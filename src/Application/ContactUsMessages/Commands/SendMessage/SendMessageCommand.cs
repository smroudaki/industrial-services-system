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

namespace IndustrialServicesSystem.Application.ContactUsMessages.Commands.SendMessage
{
    public class SendMessageCommand : IRequest<SendMessageVm>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Message { get; set; }

        public Guid ContactUsBusinessTypeGuid { get; set; }

        public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, SendMessageVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public SendMessageCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<SendMessageVm> Handle(SendMessageCommand request, CancellationToken cancellationToken)
            {
                Code contactUsBusinessType = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.ContactUsBusinessTypeGuid && !x.IsDelete, cancellationToken);

                if (contactUsBusinessType == null) return new SendMessageVm()
                {
                    Message = "نوع کسب و کار مورد نظر یافت نشد",
                    State = (int)SendContactUsMessgae.CategoryNotFound
                };

                ContactUs contectUs = new ContactUs()
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Message = request.Message,
                    ContactUsBusinessTypeCodeId = contactUsBusinessType.CodeId,
                    StateCodeId = 24
                };

                _context.ContactUs.Add(contectUs);

                await _context.SaveChangesAsync(cancellationToken);

                return new SendMessageVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)SendContactUsMessgae.Success
                };
            }
        }
    }
}
