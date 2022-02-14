using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Application.Posts.Queries.GetAllPosts;
using IndustrialServicesSystem.Domain.Entities;
using System;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllUsers
{
    public class UserDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string UserName { get; set; }

        public string UserFamily { get; set; }

        public string UserCreateDate { get; set; }

        public bool UserIsActive { get; set; }

        public bool UserIsBan { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.UserCreateDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.RegisteredDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
