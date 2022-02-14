using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Linq;
using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentUserRole
{
    public class GetCurrentUserRoleDto : IMapFrom<User>
    {
        public string RoleName { get; set; }

        public string RoleDisplayName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetCurrentUserRoleDto>()
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.Role.Name))
                .ForMember(d => d.RoleDisplayName, opt => opt.MapFrom(s => s.Role.DisplayName));
        }
    }
}
