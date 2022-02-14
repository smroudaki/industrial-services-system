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

namespace IndustrialServicesSystem.Application.Accounts.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<AuthenticateVm>
    {
        public string PhoneNumber { get; set; }

        public string SmsToken{ get; set; }

        public bool RememberMe { get; set; }

        public Guid RoleGuid { get; set; }

        public Guid Platform { get; set; } = Guid.Parse("3f61e2f8-b6a6-4793-96be-4841885090ea");

        public class AuthenticateQueryHandler : IRequestHandler<AuthenticateCommand, AuthenticateVm>
        {
            //private readonly IIndustrialServicesSystemMagContext _context;
            private readonly IIdentityService _identityService;
            //private readonly ISmsService _sms;

            public AuthenticateQueryHandler(IIndustrialServicesSystemContext context, IIdentityService identityService, ISmsService smsService)
            {
                //_context = context;
                _identityService = identityService;
                //_sms = smsService;
            }

            public async Task<AuthenticateVm> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
            {
                return await _identityService.Authenticate(request.PhoneNumber, request.SmsToken, request.RoleGuid, request.RememberMe, request.Platform);
            }
        }
    }
}
