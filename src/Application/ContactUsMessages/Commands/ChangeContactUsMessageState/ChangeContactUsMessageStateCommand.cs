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

namespace IndustrialServicesSystem.Application.Complaints.Commands.ChangeContactUsMessageState
{
    public class ChangeContactUsMessageStateCommand : IRequest<ChangeContactUsMessageStateVm>
    {
        public Guid ContactUsMessageGuid { get; set; }

        public Guid StateCodeGuid { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<ChangeContactUsMessageStateCommand, ChangeContactUsMessageStateVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public DeleteUserCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<ChangeContactUsMessageStateVm> Handle(ChangeContactUsMessageStateCommand request, CancellationToken cancellationToken)
            {
                ContactUs contactUs = await _context.ContactUs
                    .SingleOrDefaultAsync(x => x.ContactUsGuid == request.ContactUsMessageGuid);

                if (contactUs == null) return new ChangeContactUsMessageStateVm()
                {
                    Message = "پیام ارتباط با ما مورد نظر یافت نشد",
                    State = (int)ChangeContactUsMessageStateState.ContactUsMessageNotFound
                };

                Code stateCodeGuid = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.StateCodeGuid);

                if (contactUs == null) return new ChangeContactUsMessageStateVm()
                {
                    Message = "وضعیت مورد نظر یافت نشد",
                    State = (int)ChangeContactUsMessageStateState.StateCodeNotFound
                };

                contactUs.StateCodeId = stateCodeGuid.CodeId;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChangeContactUsMessageStateVm()
                { 
                    Message = "عملیات موفق آمیز", 
                    State = (int)ChangeContactUsMessageStateState.Success 
                };
            }
        }
    }
}
