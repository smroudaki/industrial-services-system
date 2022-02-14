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

namespace IndustrialServicesSystem.Application.Codes.Commands.DeleteCode
{
    public class DeleteCodeCommand : IRequest<DeleteCodeVm>
    {
        public Guid CodeGuid { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteCodeCommand, DeleteCodeVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public DeleteUserCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<DeleteCodeVm> Handle(DeleteCodeCommand request, CancellationToken cancellationToken)
            {
                Code code = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.CodeGuid && !x.IsDelete);

                if (code == null) return new DeleteCodeVm()
                {
                    Message = "کد مورد نظر یافت نشد",
                    State = (int)DeleteCodeState.CodeNotFound
                };

                code.IsDelete = true;
                code.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteCodeVm() 
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)DeleteCodeState.Success 
                };
            }
        }
    }
}
