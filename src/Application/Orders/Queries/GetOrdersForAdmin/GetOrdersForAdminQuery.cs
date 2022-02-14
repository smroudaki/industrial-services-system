﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Orders.Queries.GetOrdersForAdmin
{
    public class GetOrdersForAdminQuery : IRequest<GetOrdersForAdminVm>
    {
        public Guid? UserGuid { get; set; }
        public Guid? StateGuid { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetOrdersForAdminQuery, GetOrdersForAdminVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public OrdersListQueryHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUserService;
                _mapper = mapper;
            }

            public async Task<GetOrdersForAdminVm> Handle(GetOrdersForAdminQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetOrdersForAdminVm()
                    {
                        Message = "کاربر لاگین شده یافت نشد",
                        State = (int)GetOrdersForAdminState.CurrentUserNotFound
                    };
                }

                Admin admin = await _context.Admin
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (admin == null)
                {
                    return new GetOrdersForAdminVm()
                    {
                        Message = "ادمین لاگین شده یافت نشد",
                        State = (int)GetOrdersForAdminState.AdminNotFound
                    };
                }

                IQueryable<Order> orders = _context.Order
                    .Where(x => !x.IsDelete)
                    .AsQueryable();

                if (request.UserGuid != null)
                {
                    User user = await _context.User
                        .SingleOrDefaultAsync(x => x.UserGuid == request.UserGuid, cancellationToken);

                    if (user == null)
                    {
                        return new GetOrdersForAdminVm()
                        {
                            Message = "کاربر مورد نظر یافت نشد",
                            State = (int)GetOrdersForAdminState.UserNotFound
                        };
                    }

                    orders = orders.Where(x => x.Client.UserId == user.UserId);
                }

                if (request.StateGuid != null)
                {
                    Code state = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.StateGuid, cancellationToken);

                    if (state == null)
                    {
                        return new GetOrdersForAdminVm()
                        {
                            Message = "وضعیت مورد نظر یافت نشد",
                            State = (int)GetOrdersForAdminState.StateNotFound
                        };
                    }

                    orders = orders.Where(x => x.StateCodeId == state.CodeId);
                }

                List<GetOrdersForAdminDto> ordersResult = await orders
                    .ProjectTo<GetOrdersForAdminDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (ordersResult.Count <= 0)
                {
                    return new GetOrdersForAdminVm()
                    {
                        Message = "سفارشی یافت نشد",
                        State = (int)GetOrdersForAdminState.NotAnyOrdersFound
                    };
                }

                return new GetOrdersForAdminVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrdersForAdminState.Success,
                    Orders = ordersResult
                };
            }
        }
    }
}
