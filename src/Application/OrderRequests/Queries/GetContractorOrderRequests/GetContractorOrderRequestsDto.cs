using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetContractorOrderRequests
{
    public class GetContractorOrderRequestsDto : IMapFrom<OrderRequest>
    {
        public Guid OrderRequestGuid { get; set; }

        public string Contractor { get; set; }

        public string Client { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public long OfferedPrice { get; set; }

        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderRequest, GetContractorOrderRequestsDto>()
                .ForMember(d => d.Contractor, opt => opt.MapFrom(s => s.Contractor.User.FirstName + " " + s.Contractor.User.LastName))
                .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Order.Client.User.FirstName + " " + s.Order.Client.User.LastName))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Order.Category.DisplayName))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
