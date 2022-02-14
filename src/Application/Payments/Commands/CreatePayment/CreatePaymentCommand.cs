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

namespace IndustrialServicesSystem.Application.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<CreatePaymentVm>
    {
        public int RealAmount { get; set; }

        public int PayAmount { get; set; }

        public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IZarinPalService _zarinPal;
            private readonly ICurrentUserService _currentUser;

            public CreatePaymentCommandHandler(IIndustrialServicesSystemContext context,
                IZarinPalService zarinPal,
                ICurrentUserService currentUser)
            {
                _context = context;
                _zarinPal = zarinPal;
                _currentUser = currentUser;
            }

            public async Task<CreatePaymentVm> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new CreatePaymentVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)CreatePaymentState.UserNotFound
                };

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null) return new CreatePaymentVm()
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)CreatePaymentState.ContractorNotFound
                };

                var payment = new Payment()
                {
                    PaymentProviderSettingId = 1,
                    ContractorId = contractor.ContractorId,
                    Cost = request.PayAmount,
                    Discount = request.RealAmount - request.PayAmount
                };

                _context.Payment.Add(payment);
                await _context.SaveChangesAsync(cancellationToken);

                string paymentUrl = await _zarinPal.Request(payment.PaymentGuid, payment.Cost, currentUser.Email, currentUser.PhoneNumber);

                if (paymentUrl == null) return new CreatePaymentVm()
                {
                    Message = "اتصال به درگاه پرداخت با مشکل مواجه شد",
                    State = (int)CreatePaymentState.NullReferencePaymentRequest
                };

                return new CreatePaymentVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreatePaymentState.Success,
                    PaymentUrl = paymentUrl
                };
            }
        }
    }
}
