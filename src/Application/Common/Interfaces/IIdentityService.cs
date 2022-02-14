using IndustrialServicesSystem.Application.Accounts.Commands.Authenticate;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserFullNameAsync(Guid userGuid);

        Task<AuthenticateVm> Authenticate(string mobile, string code, Guid roleGuid, bool rememberMe, Guid platform);

        //Task<IEnumerable<TblUser>> GetAll();
    }
}
