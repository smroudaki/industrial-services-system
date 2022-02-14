using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Accounts.Commands.RegisterClient;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;

namespace IndustrialServicesSystem.Application.OrderRequests.Commands.CreateOrderRequest
{
    public class CreateOrderRequestCommand : IRequest<CreateOrderRequestVm>
    {
        public Guid OrderGuid { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public long OfferedPrice { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequestCommand, CreateOrderRequestVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly ISmsService _sms;

            public CreateOrderCommandHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUserService, ISmsService smsService)
            {
                _context = context;
                _currentUser = currentUserService;
                _sms = smsService;
            }

            public async Task<CreateOrderRequestVm> Handle(CreateOrderRequestCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier) && !x.IsDelete)
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new CreateOrderRequestVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)CreateOrderRequestState.UserNotFound
                    };
                }

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null) return new CreateOrderRequestVm
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)CreateOrderRequestState.ContractorNotFound
                };

                Order order = await _context.Order
                    .SingleOrDefaultAsync(x => x.OrderGuid == request.OrderGuid && !x.IsDelete, cancellationToken);

                if (order == null) return new CreateOrderRequestVm
                {
                    Message = "سفارش مورد نظر یافت نشد",
                    State = (int)CreateOrderRequestState.OrderNotFound
                };

                if (await _context.OrderRequest.AnyAsync(or => or.ContractorId == contractor.ContractorId && or.OrderId == order.OrderId)) return new CreateOrderRequestVm
                {
                    Message = "درخواست برای این سفارش قبلا ثبت شده است",
                    State = (int)CreateOrderRequestState.OrderRequestCreatedBefore
                };
                
                Setting setting = await _context.Setting
                    .FirstOrDefaultAsync(cancellationToken);

                if (setting == null) return new CreateOrderRequestVm()
                {
                    Message = "تنظیمات مورد نظر یافت نشد",
                    State = (int)CreateOrderRequestState.SettingNotFound
                };

                if (contractor.Credit < setting.OrderRequestPrice) return new CreateOrderRequestVm()
                {
                    Message = "موجودی سرویس دهنده مورد نظر کافی نمی باشد",
                    State = (int)CreateOrderRequestState.CreditNotEnough
                };

                OrderRequest orderRequest = new OrderRequest
                {
                    ContractorId = contractor.ContractorId,
                    OrderId = order.OrderId,
                    Title = request.Title,
                    Message = request.Message,
                    OfferedPrice = request.OfferedPrice,
                    StateCodeId = 19,
                    Price = setting.OrderRequestPrice
                };

                _context.OrderRequest.Add(orderRequest);

                int price = setting.OrderRequestPrice;

                var isFirstOrderRequest = await _context.OrderRequest
                    .AnyAsync(x => x.ContractorId == contractor.ContractorId);

                if (isFirstOrderRequest)
                    price += setting.IntroductionCodePrice;

                contractor.Credit -= price;

                await _context.SaveChangesAsync(cancellationToken);

                return new CreateOrderRequestVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreateOrderRequestState.Success
                };
            }
        }
    }
}
