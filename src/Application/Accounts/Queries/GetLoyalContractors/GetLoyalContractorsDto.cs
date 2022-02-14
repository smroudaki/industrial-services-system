using AutoMapper;
using IndustrialServicesSystem.Application.Common;
using IndustrialServicesSystem.Application.Common.Mappings;
using IndustrialServicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialServicesSystem.Application.Payments.Queries.GetLoyalContractors
{
    public class GetLoyalContractorsDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PaymentCount { get; set; }
    }
}
