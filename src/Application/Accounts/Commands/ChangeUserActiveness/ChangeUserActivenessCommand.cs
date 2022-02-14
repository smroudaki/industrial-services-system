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

namespace IndustrialServicesSystem.Application.Accounts.Commands.ChangeUserActiveness
{
    public class ChangeUserActivenessCommand : IRequest<ChangeUserActivenessVm>
    {
        public Guid UserGuid { get; set; }

        public bool IsActive { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<ChangeUserActivenessCommand, ChangeUserActivenessVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public DeleteUserCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<ChangeUserActivenessVm> Handle(ChangeUserActivenessCommand request, CancellationToken cancellationToken)
            {
                User user = await _context.User
                    .SingleOrDefaultAsync(x => x.UserGuid == request.UserGuid && !x.IsDelete);

                if (user == null) return new ChangeUserActivenessVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)ChangeUserActivenessState.UserNotFound
                };

                user.IsActive = request.IsActive;
                user.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChangeUserActivenessVm()
                { 
                    Message = "عملیات موفق آمیز", 
                    State = (int)ChangeUserActivenessState.Success 
                };
            }
        }
    }
}
