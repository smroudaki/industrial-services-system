using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetUserByGuid
{
    public class UserByGuidDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string UserName { get; set; }

        public string UserFamily { get; set; }

        public string UserMobile { get; set; }

        public DateTime UserCreateDate { get; set; }

        public bool UserIsActive { get; set; }

        public bool UserIsBan { get; set; }
    }
}
