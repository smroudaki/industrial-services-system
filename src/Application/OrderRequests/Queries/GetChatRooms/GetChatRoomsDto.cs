using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetChatRooms
{
    public class GetChatRoomsDto : IMapFrom<OrderRequest>
    {
        public Guid OrderRequestGuid { get; set; }

        public string Client { get; set; }

        public string Gender { get; set; }

        public string Title { get; set; }

        public string AcceptanceStatus { get; set; }

        public bool IsAccessible { get; set; }

        public string RecentMessage { get; set; }

        public string CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderRequest, GetChatRoomsDto>()
                .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Order.Client.User.FirstName + " " + s.Order.Client.User.LastName))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Order.Client.User.GenderCode.DisplayName))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Order.Title))
                .ForMember(d => d.AcceptanceStatus, opt => opt.MapFrom(s => s.StateCode.DisplayName))
                .ForMember(d => d.IsAccessible, opt => opt.MapFrom(s => (s.Order.StateCodeId == 9 && s.IsAllow) || s.StateCodeId == 18))
                .ForMember(d => d.RecentMessage, opt => opt.MapFrom(s => s.ChatMessage.OrderByDescending(x => x.SentAt).FirstOrDefault().Text))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.CreationDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
