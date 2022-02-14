using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Payments.Queries.GetPaymentByGuid
{
    public class GetPaymentByGuidDto : IMapFrom<Payment>
    {
        public Guid PaymentGuid { get; set; }

        public Guid ContractorGuid { get; set; }

        public string Contractor { get; set; }

        public int Cost { get; set; }

        public int Discount { get; set; }

        public long? TrackingToken { get; set; }

        public bool IsSuccessful { get; set; }

        public string CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, GetPaymentByGuidDto>()
                .ForMember(d => d.ContractorGuid, opt => opt.MapFrom(s => s.Contractor.ContractorGuid))
                .ForMember(d => d.Contractor, opt => opt.MapFrom(s => s.Contractor.User.FirstName + " " + s.Contractor.User.LastName))
                .ForMember(d => d.CreationDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.CreationDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
