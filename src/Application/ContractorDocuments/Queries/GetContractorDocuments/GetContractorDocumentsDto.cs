using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.ContractorDocuments.Queries.GetContractorDocuments
{
    public class GetContractorDocumentsDto : IMapFrom<ContractorDocument>
    {
        public string Title { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }
        public bool IsAccept { get; set; }
        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractorDocument, GetContractorDocumentsDto>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.TitleCode.DisplayName))
                .ForMember(d => d.Document, opt => opt.MapFrom(s => s.Document.Path))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
