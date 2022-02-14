using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Domain.Entities
{
    public partial class ContractorIntroductionCode
    {
        public int ContractorIntroductionCodeId { get; set; }
        public Guid ContractorIntroductionCodeGuid { get; set; }
        public int NewContractorId { get; set; }
        public int ContractorId { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Contractor NewContractor { get; set; }
    }
}
