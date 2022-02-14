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

namespace IndustrialServicesSystem.Application.Complaints.Commands.ChangeComplaintMessageState
{
    public class ChangeComplaintMessageStateCommand : IRequest<ChangeComplaintMessageStateVm>
    {
        public Guid ComplaintMessageGuid { get; set; }

        public Guid StateCodeGuid { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<ChangeComplaintMessageStateCommand, ChangeComplaintMessageStateVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public DeleteUserCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<ChangeComplaintMessageStateVm> Handle(ChangeComplaintMessageStateCommand request, CancellationToken cancellationToken)
            {
                Complaint complaint = await _context.Complaint
                    .SingleOrDefaultAsync(x => x.ComplaintGuid == request.ComplaintMessageGuid);

                if (complaint == null) return new ChangeComplaintMessageStateVm()
                {
                    Message = "پیام شکایت مورد نظر یافت نشد",
                    State = (int)ChangeComplaintMessageStateState.ComplaintMessageNotFound
                };

                Code stateCodeGuid = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.StateCodeGuid);

                if (complaint == null) return new ChangeComplaintMessageStateVm()
                {
                    Message = "وضعیت مورد نظر یافت نشد",
                    State = (int)ChangeComplaintMessageStateState.StateCodeNotFound
                };

                complaint.StateCodeId = stateCodeGuid.CodeId;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChangeComplaintMessageStateVm()
                { 
                    Message = "عملیات موفق آمیز", 
                    State = (int)ChangeComplaintMessageStateState.Success 
                };
            }
        }
    }
}
