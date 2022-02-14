using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Application.Posts.Queries.GetAllPosts;
using IndustrialServicesSystem.Domain.Entities;
using System;

namespace IndustrialServicesSystem.Application.Discounts.Queries.GetPublicDiscounts
{
    public class GetPublicDiscountsDto : IMapFrom<PublicDiscount>
    {
        public Guid PublicDiscountGuid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ExpirationDate { get; set; }
        public string CreationDate { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublicDiscount, GetPublicDiscountsDto>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.TypeCode.DisplayName ))
                .ForMember(d => d.ExpirationDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ExpirationDate, "yyyy/MM/dd HH:mm")))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.CreationDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
