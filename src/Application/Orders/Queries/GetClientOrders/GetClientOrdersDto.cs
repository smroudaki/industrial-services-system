using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialServicesSystem.Application.Orders.Queries.GetClientOrders
{
    public class GetClientOrdersDto : IMapFrom<Order>
    {
        public Guid OrderGuid { get; set; }

        public Guid OrderRequestGuid { get; set; }

        public string Contractor { get; set; }

        public string Category { get; set; }

        public string State { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public double? Rate { get; set; }

        public int? Cost { get; set; }

        public string ModifiedDate { get; set; }

        public int RequestsCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetClientOrdersDto>()
                .ForMember(d => d.OrderRequestGuid, opt => opt.MapFrom(s => s.OrderRequest.FirstOrDefault(x => x.StateCodeId != 9).OrderRequestGuid))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.DisplayName))
                .ForMember(d => d.Contractor, opt => opt.MapFrom(s => s.Contractor.User.FirstName + " " + s.Contractor.User.LastName))
                .ForMember(d => d.RequestsCount, opt => opt.MapFrom(s => s.OrderRequest.Count))
                .ForMember(d => d.State, opt => opt.MapFrom(s => s.StateCode.DisplayName))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
