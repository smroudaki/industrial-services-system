using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Linq;
using AutoMapper;
using IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentClientUser;
using IndustrialServicesSystem.Application.Common;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentContractorUser
{
    public class GetCurrentContractorUserDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CurrentContracorUserGenderDto Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public CurrentContracorUserCityDto City { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public CurrentContracorUserBusinessDto Business { get; set; }

        public int Credit { get; set; }

        public double? AverageRate { get; set; }

        public string Address { get; set; }

        public string AboutMe { get; set; }

        public string Telephone { get; set; }

        public string Website { get; set; }

        public string Instagram { get; set; }

        public string Telegram { get; set; }

        public string Linkedin { get; set; }

        public string Whatsapp { get; set; }

        public string ProfileDocument { get; set; }

        public int Income { get; set; }

        public bool IsRegister { get; set; }

        public bool IsActive { get; set; }

        public string RegisteredDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetCurrentContractorUserDto>()
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => new CurrentContracorUserGenderDto
                {
                    GenderGuid = s.GenderCode.CodeGuid,
                    Name = s.GenderCode.DisplayName
                }))
                .ForMember(d => d.City, opt => opt.MapFrom(s => new CurrentContracorUserCityDto
                {
                    CityGuid = s.Contractor.SingleOrDefault().City.CityGuid,
                    Name = s.Contractor.SingleOrDefault().City.Name
                }))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Latitude))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Longitude))
                .ForMember(d => d.Credit, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Credit))
                .ForMember(d => d.AverageRate, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().AverageRate))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Address))
                .ForMember(d => d.AboutMe, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().AboutMe))
                .ForMember(d => d.Telephone, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Telephone))
                .ForMember(d => d.Website, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Website))
                .ForMember(d => d.Instagram, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Instagram))
                .ForMember(d => d.Telegram, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Telegram))
                .ForMember(d => d.Linkedin, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Linkedin))
                .ForMember(d => d.Whatsapp, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Whatsapp))
                .ForMember(d => d.ProfileDocument, opt => opt.MapFrom(s => s.ProfileDocument.Path))
                .ForMember(d => d.Income, opt => opt.MapFrom(s => s.Contractor.SingleOrDefault().Order.Sum(x => x.Cost)))
                .ForMember(d => d.Business, opt => opt.MapFrom(s => new CurrentContracorUserBusinessDto
                {
                    BusinessGuid = s.Contractor.SingleOrDefault().BusinessTypeCode.CodeGuid,
                    Name = s.Contractor.SingleOrDefault().BusinessTypeCode.DisplayName
                }))
                .ForMember(d => d.RegisteredDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.RegisteredDate, "yyyy/MM/dd HH:mm")));
        }
    }

    public class CurrentContracorUserCityDto
    {
        public Guid CityGuid { get; set; }

        public string Name { get; set; }
    }

    public class CurrentContracorUserGenderDto
    {
        public Guid GenderGuid { get; set; }

        public string Name { get; set; }
    }

    public class CurrentContracorUserBusinessDto
    {
        public Guid BusinessGuid { get; set; }

        public string Name { get; set; }
    }
}
