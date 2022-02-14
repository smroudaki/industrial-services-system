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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentAdminUser
{
    public class GetCurrentAdminUserQuery : IRequest<GetCurrentAdminUserVm>
    {
        public class GetUserByGuidQueryHandler : IRequestHandler<GetCurrentAdminUserQuery, GetCurrentAdminUserVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public GetUserByGuidQueryHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUserService;
                _mapper = mapper;
            }

            public async Task<GetCurrentAdminUserVm> Handle(GetCurrentAdminUserQuery request, CancellationToken cancellationToken)
            {
                GetCurrentAdminUserDto user = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier) && x.Admin.Count > 0)
                    .ProjectTo<GetCurrentAdminUserDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                if (user == null)
                {
                    return new GetCurrentAdminUserVm()
                    {
                        Message = "کاربری یافت نشد",
                        State = (int)GetCurrentUserState.UserNotFound
                    };
                }

                return new GetCurrentAdminUserVm()
                {
                    Message ="عملیات موفق آمیز",
                    State = (int)GetCurrentUserState.Success,
                    User = user
                };
            }
        }
    }
}
