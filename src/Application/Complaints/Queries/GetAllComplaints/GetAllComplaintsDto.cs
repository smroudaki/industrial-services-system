using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Posts.Queries.GetAllComplaints
{
    public class GetAllComplaintsDto : IMapFrom<Complaint>
    {
        public Guid ComplaintGuid { get; set; }

        public string User { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string State { get; set; }

        public string CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Complaint, GetAllComplaintsDto>()
                .ForMember(d => d.User, opt => opt.MapFrom(s => s.User.FirstName + " " + s.User.LastName))
                .ForMember(d => d.State, opt => opt.MapFrom(s => s.StateCode.DisplayName))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.CreationDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
