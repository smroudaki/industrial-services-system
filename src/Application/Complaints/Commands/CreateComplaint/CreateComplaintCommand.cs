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

namespace IndustrialServicesSystem.Application.Contact.Commands.CreateComplaint
{
    public class CreateComplaintCommand : IRequest<CreateComplaintVm>
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, CreateComplaintVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public CreateComplaintCommandHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<CreateComplaintVm> Handle(CreateComplaintCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new CreateComplaintVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)CreateComplaintState.UserNotFound
                };

                Complaint complaint = new Complaint()
                {
                    UserId = currentUser.UserId,
                    Subject = request.Subject,
                    Description = request.Description,
                    StateCodeId = 27
                };

                _context.Complaint.Add(complaint);

                await _context.SaveChangesAsync(cancellationToken);

                return new CreateComplaintVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreateComplaintState.Success
                };
            }
        }
    }
}
