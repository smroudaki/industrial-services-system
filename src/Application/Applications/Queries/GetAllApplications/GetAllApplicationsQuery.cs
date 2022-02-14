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

namespace IndustrialServicesSystem.Application.Applications.Queries.GetAllApplications
{
    public class GetAllApplicationsQuery : IRequest<GetAllApplicationsVm>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetAllApplicationsQuery, GetAllApplicationsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public GetCategoriesQueryHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUser;
                _mapper = mapper;
            }

            public async Task<GetAllApplicationsVm> Handle(GetAllApplicationsQuery request, CancellationToken cancellationToken)
            {
                var currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new GetAllApplicationsVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)GetAllApplicationsState.UserNotFound
                };

                Admin admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (admin == null) return new GetAllApplicationsVm()
                {
                    Message = "ادمین مورد نظر یافت نشد",
                    State = (int)GetAllApplicationsState.AdminNotFound
                };

                var applications = await _context.Application
                    .Where(x => !x.IsDelete)
                    .ProjectTo<GetAllApplicationsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (applications.Count == 0) return new GetAllApplicationsVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetAllApplicationsState.NotFound
                };

                return new GetAllApplicationsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllApplicationsState.Success,
                    Applications = applications
                };
            }
        }
    }
}
