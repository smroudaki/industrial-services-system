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

namespace IndustrialServicesSystem.Application.ChangeOrderRequestPrice.Commands.ChangeUsersInitialCredit
{
    public class ChangeUsersInitialCreditCommand : IRequest<ChangeUsersInitialCreditVm>
    {
        public int Credit { get; set; }

        public class ChangeUserInitialCreditCommandHandler : IRequestHandler<ChangeUsersInitialCreditCommand, ChangeUsersInitialCreditVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public ChangeUserInitialCreditCommandHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<ChangeUsersInitialCreditVm> Handle(ChangeUsersInitialCreditCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new ChangeUsersInitialCreditVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)ChangeUserInitialCreditState.UserNotFound
                };

                Admin admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (admin == null) return new ChangeUsersInitialCreditVm()
                {
                    Message = "ادمین مورد نظر یافت نشد",
                    State = (int)ChangeUserInitialCreditState.AdminNotFound
                };

                Setting setting = await _context.Setting
                    .FirstOrDefaultAsync(cancellationToken);

                if (setting == null) return new ChangeUsersInitialCreditVm()
                {
                    Message = "تنظیمات مورد نظر یافت نشد",
                    State = (int)ChangeUserInitialCreditState.SettingNotFound
                };

                setting.UserInitialCredit = request.Credit;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChangeUsersInitialCreditVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)ChangeUserInitialCreditState.Success
                };
            }
        }
    }
}
