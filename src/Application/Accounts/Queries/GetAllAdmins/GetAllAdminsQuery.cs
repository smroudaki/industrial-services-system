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

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllAdmins
{
    public class GetAllAdminsQuery : IRequest<GetAllAdminsVm>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetAllAdminsQuery, GetAllAdminsVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetUsersQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetAllAdminsVm> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
            {
                List<GetAllAdminsDto> admins = await _context.User
                    .Where(x => !x.IsDelete && x.RoleId == 1)
                    .OrderByDescending(x => x.RegisteredDate)
                    .ProjectTo<GetAllAdminsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (admins.Count < 0) return new GetAllAdminsVm()
                {
                    Message = "ادمینی یافت نشد",
                    State = (int)GetAllAdminsState.NotAnyAdminsFound
                };

                return new GetAllAdminsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllAdminsState.Success,
                    Admins = admins
                };
            }
        }
    }
}
