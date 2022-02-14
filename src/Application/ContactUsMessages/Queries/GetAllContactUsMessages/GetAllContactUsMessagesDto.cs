using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.ContactUsMessages.Queries.GetAllContactUsMessages
{
    public class GetAllContactUsMessagesDto : IMapFrom<ContactUs>
    {
        public Guid ContactUsGuid { get; set; }

        public string ContactUsBusinessTypeCode { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Message { get; set; }

        public string State { get; set; }

        public string CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactUs, GetAllContactUsMessagesDto>()
                .ForMember(d => d.ContactUsBusinessTypeCode, opt => opt.MapFrom(s => s.ContactUsBusinessTypeCode.DisplayName))
                .ForMember(d => d.State, opt => opt.MapFrom(s => s.StateCode.DisplayName))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.CreationDate, "yyyy/MM/dd HH:mm")));

        }
    }
}
