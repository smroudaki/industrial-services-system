using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Domain.Entities
{
    public partial class ContactUs
    {
        public int ContactUsId { get; set; }
        public Guid ContactUsGuid { get; set; }
        public int ContactUsBusinessTypeCodeId { get; set; }
        public int StateCodeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Code ContactUsBusinessTypeCode { get; set; }
        public virtual Code StateCode { get; set; }
    }
}
