using IndustrialServicesSystem.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Zarinpal;

namespace IndustrialServicesSystem.Infrastructure.Services
{
    public class ZarinPalService : IZarinPalService
    {
        private readonly IIndustrialServicesSystemContext _context;

        public ZarinPalService(IIndustrialServicesSystemContext context)
        {
            _context = context;
        }

        public async Task<string> Request(Guid paymentGuid, int amount, string email, string mobile)
        {
            string callbackUrl = $"http://185.211.59.237/Payment/OnlinePayment/{paymentGuid}";
            string description = $"شارژ کیف پول";
            string merchantId = await GetMerchantId();

            var payment = new Payment(merchantId, amount);
            var request = await payment.PaymentRequest(description, callbackUrl, email, mobile);

            return request.Status == 100 ? $"https://zarinpal.com/pg/StartPay/{request.Authority}" : null;
        }

        public async Task<(bool, long)> Verify(int amount, string authority)
        {
            string merchantId = await GetMerchantId();

            var payment = new Payment(merchantId, amount);
            var verification = await payment.Verification(authority);

            return (verification.Status == 100, verification.RefId);
        }

        private async Task<string> GetMerchantId()
        {
            return await _context.PaymentProviderSetting
                .OrderByDescending(x => x.ModifiedDate)
                .Select(x => x.Apikey)
                .FirstOrDefaultAsync();
        }
    }
}
