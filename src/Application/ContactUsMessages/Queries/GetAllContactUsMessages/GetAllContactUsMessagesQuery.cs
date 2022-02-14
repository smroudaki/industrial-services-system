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

namespace IndustrialServicesSystem.Application.ContactUsMessages.Queries.GetAllContactUsMessages
{
    public class GetAllContactUsMessagesQuery : IRequest<GetAllContactUsMessagesVm>
    {
        public class GetAllComplaintsQueryHandler : IRequestHandler<GetAllContactUsMessagesQuery, GetAllContactUsMessagesVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public GetAllComplaintsQueryHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUser;
                _mapper = mapper;
            }

            public async Task<GetAllContactUsMessagesVm> Handle(GetAllContactUsMessagesQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new GetAllContactUsMessagesVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)GetAllContactUsMessagesState.UserNotFound
                };

                Admin admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (admin == null) return new GetAllContactUsMessagesVm()
                {
                    Message = "ادمین مورد نظر یافت نشد",
                    State = (int)GetAllContactUsMessagesState.AdminNotFound
                };

                List<GetAllContactUsMessagesDto> contactUsMessages = await _context.ContactUs
                    .OrderByDescending(x => x.CreationDate)
                    .ProjectTo<GetAllContactUsMessagesDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (contactUsMessages.Count == 0) return new GetAllContactUsMessagesVm()
                {
                    Message = "پیامی یافت نشد",
                    State = (int)GetAllContactUsMessagesState.NotAnyMessages
                };

                return new GetAllContactUsMessagesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllContactUsMessagesState.Success,
                    ContactUsMessages = contactUsMessages
                };
            }
        }
    }
}
