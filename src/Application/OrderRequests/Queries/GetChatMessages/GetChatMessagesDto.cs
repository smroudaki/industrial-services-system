using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetChatMessages
{
    public class GetChatMessagesDto : IMapFrom<ChatMessage>
    {
        public Guid ChatMessageGuid { get; set; }

        public string Document { get; set; }

        public string Text { get; set; }

        public string SentAt { get; set; }

        public string From { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChatMessage, GetChatMessagesDto>()
                .ForMember(d => d.Document, opt => opt.MapFrom(s => s.Document.Path))
                .ForMember(d => d.From, opt => opt.MapFrom(s => s.User.Role.DisplayName))
                .ForMember(d => d.SentAt, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.SentAt, "yyyy/MM/dd HH:mm")));
        }
    }
}
