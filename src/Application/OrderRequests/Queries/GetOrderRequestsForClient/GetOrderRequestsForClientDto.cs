using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetOrderRequestsForClient
{
    public class GetOrderRequestsForClientDto : IMapFrom<OrderRequest>
    {
        public Guid OrderRequestGuid { get; set; }

        public string Contractor { get; set; }

        public Guid ContractorGuid { get; set; }

        public string ContractorProfileDocument { get; set; }

        public string Gender { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public long OfferedPrice { get; set; }

        public string RecentMessage { get; set; }

        public string AcceptanceStatus { get; set; }

        public bool IsAccessible { get; set; }

        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderRequest, GetOrderRequestsForClientDto>()
                .ForMember(d => d.RecentMessage, opt => opt.MapFrom(s => s.ChatMessage.OrderByDescending(x => x.SentAt).FirstOrDefault().Text))
                .ForMember(d => d.AcceptanceStatus, opt => opt.MapFrom(s => s.StateCode.DisplayName))
                .ForMember(d => d.IsAccessible, opt => opt.MapFrom(s => (s.Order.StateCodeId == 9 && s.IsAllow) || s.StateCodeId == 18))
                .ForMember(d => d.Contractor, opt => opt.MapFrom(s => s.Contractor.User.FirstName + " " + s.Contractor.User.LastName))
                .ForMember(d => d.ContractorGuid, opt => opt.MapFrom(s => s.Contractor.ContractorGuid))
                .ForMember(d => d.ContractorProfileDocument, opt => opt.MapFrom(s => s.Contractor.User.ProfileDocument.Path))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Contractor.User.GenderCode.DisplayName))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
