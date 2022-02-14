using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Domain.Entities
{
    public partial class Setting
    {
        public int SettingId { get; set; }
        public Guid SettingGuid { get; set; }
        public int UserInitialCredit { get; set; }
        public int OrderRequestPrice { get; set; }
        public int IntroductionCodePrice { get; set; }
    }
}
