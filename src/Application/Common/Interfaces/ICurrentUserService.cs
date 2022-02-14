using IndustrialServicesSystem.Domain.Entities;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string NameIdentifier { get; }

        string MobilePhone { get; }

        string Role { get; }

        Task<User> GetInfoAsync();
    }
}
