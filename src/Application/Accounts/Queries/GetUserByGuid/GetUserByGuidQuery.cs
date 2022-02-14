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

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetUserByGuid
{
    public class GetUserByGuidQuery : IRequest<UserByGuidVm>
    {
        public Guid UserGuid { get; set; }

        public class GetUserByGuidQueryHandler : IRequestHandler<GetUserByGuidQuery, UserByGuidVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetUserByGuidQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserByGuidVm> Handle(GetUserByGuidQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.User
                    .Where(x => x.UserGuid == request.UserGuid && !x.IsDelete)
                    .ProjectTo<UserByGuidDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                bool userExists = user != null;

                return new UserByGuidVm()
                {
                    Message = userExists ? "عملیات موفق آمیز" : "کاربری یافت نشد",
                    Result = userExists ? true : false,
                    User = user
                };
            }
        }
    }
}
