using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Application.Common.UploadHelper.Filepond;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Application.Applications.Queries.GetAllApplications
{
    public class GetAllApplicationsDto : IMapFrom<IndustrialServicesSystem.Domain.Entities.Application>
    {
        public Guid ApplicationGuid { get; set; }

        public string Name { get; set; }

        public string MinVersionCode { get; set; }

        public string LatestVersionCode { get; set; }

        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IndustrialServicesSystem.Domain.Entities.Application, GetAllApplicationsDto>()
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
