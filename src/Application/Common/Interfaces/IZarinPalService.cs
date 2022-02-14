using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Common.Interfaces
{
    public interface IZarinPalService
    {
        Task<string> Request(Guid paymentGuid, int amount, string email, string mobile);

        Task<(bool, long)> Verify(int amount, string authority);
    }
}
