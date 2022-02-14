using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.ContactUsMessages.Queries.GetAllContactUsMessages
{
    public class GetAllContactUsMessagesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetAllContactUsMessagesDto> ContactUsMessages { get; set; }
    }
}
