using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Linq;
using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetCurrentClientUser
{
    public class GetCurrentClientUserDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public CurrentClientUserProvinceDto Province { get; set; }

        public CurrentClientUserCityDto City { get; set; }

        public bool IsRegister { get; set; }

        public bool IsActive { get; set; }

        public FilepondDto ProfileDocument { get; set; }

        public string RegisteredDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetCurrentClientUserDto>()
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.GenderCode.DisplayName))
                .ForMember(d => d.Province, opt => opt.MapFrom(s => new CurrentClientUserProvinceDto
                {
                    ProvinceGuid = s.Client.SingleOrDefault().City.Province.ProvinceGuid,
                    Name = s.Client.SingleOrDefault().City.Province.Name
                }))
                .ForMember(d => d.City, opt => opt.MapFrom(s => new CurrentClientUserCityDto
                {
                    CityGuid = s.Client.SingleOrDefault().City.CityGuid,
                    Name = s.Client.SingleOrDefault().City.Name
                }))
                .ForMember(d => d.ProfileDocument, opt => opt.MapFrom(s => new FilepondDto
                {
                    Source = s.ProfileDocument.Path,
                    Options = new FilepondOptions
                    {
                        Type = "local",
                        Files = new FilepondFile
                        {
                            Name = s.ProfileDocument.Name,
                            Size = s.ProfileDocument.Size.ToString(),
                            Type = s.ProfileDocument.TypeCode.Name
                        },
                        Metadata = new FilepondMetadata
                        {
                            Poster = s.ProfileDocument.Path
                        }
                    }
                }))
                .ForMember(d => d.RegisteredDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.RegisteredDate, "yyyy/MM/dd HH:mm")));
        }
    }

    public class CurrentClientUserCityDto
    {
        public Guid CityGuid { get; set; }

        public string Name { get; set; }
    }

    public class CurrentClientUserProvinceDto
    {
        public Guid ProvinceGuid { get; set; }

        public string Name { get; set; }
    }
}
