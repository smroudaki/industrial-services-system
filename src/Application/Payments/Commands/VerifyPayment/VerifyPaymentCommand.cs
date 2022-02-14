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

namespace IndustrialServicesSystem.Application.Payments.Commands.VerifyPayment
{
    public class VerifyPaymentCommand : IRequest<VerifyPaymentVm>
    {
        public Guid PaymentGuid { get; set; }

        public string Authority { get; set; }

        public class CreatePaymentCommandHandler : IRequestHandler<VerifyPaymentCommand, VerifyPaymentVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IZarinPalService _zarinPal;

            public CreatePaymentCommandHandler(IIndustrialServicesSystemContext context,
                IZarinPalService zarinPal)
            {
                _context = context;
                _zarinPal = zarinPal;
            }

            public async Task<VerifyPaymentVm> Handle(VerifyPaymentCommand request, CancellationToken cancellationToken)
            {
                Payment payment = await _context.Payment
                    .SingleOrDefaultAsync(x => x.PaymentGuid == request.PaymentGuid, cancellationToken);

                if (payment == null)
                {
                    return new VerifyPaymentVm()
                    {
                        Message = "پرداخت مورد مورد نظر یافت نشد",
                        State = (int)VerifyPaymentState.PaymentNotFound
                    };
                }

                (bool, long) res = await _zarinPal.Verify(Convert.ToInt32(payment.Cost), request.Authority);

                if (!res.Item1)
                {
                    return new VerifyPaymentVm()
                    {
                        Message = "پرداخت ناموفق",
                        State = (int)VerifyPaymentState.InvalidPayment
                    };
                }

                payment.IsSuccessful = true;
                payment.TrackingToken = res.Item2;

                await _context.SaveChangesAsync(cancellationToken);

                return new VerifyPaymentVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)VerifyPaymentState.Success
                };
            }
        }
    }
}
