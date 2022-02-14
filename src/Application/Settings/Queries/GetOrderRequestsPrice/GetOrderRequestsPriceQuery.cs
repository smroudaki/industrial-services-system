using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Application.Posts.Queries.GetAllPosts;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;

namespace IndustrialServicesSystem.Application.Codes.Queries.GetOrderRequestsPrice
{
    public class GetOrderRequestsPriceQuery : IRequest<GetOrderRequestsPriceVm>
    {
        public class GetCodesByCodeGroupGuidQueryHandler : IRequestHandler<GetOrderRequestsPriceQuery, GetOrderRequestsPriceVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public GetCodesByCodeGroupGuidQueryHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<GetOrderRequestsPriceVm> Handle(GetOrderRequestsPriceQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new GetOrderRequestsPriceVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)GetOrderRequestsPriceState.UserNotFound
                };

                Setting setting = await _context.Setting
                    .FirstOrDefaultAsync(cancellationToken);

                if (setting == null) return new GetOrderRequestsPriceVm()
                {
                    Message = "تنظیمات مورد نظر یافت نشد",
                    State = (int)GetOrderRequestsPriceState.SettingNotFound
                };

                return new GetOrderRequestsPriceVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrderRequestsPriceState.Success,
                    Price = setting.OrderRequestPrice
                };
            }
        }
    }
}
