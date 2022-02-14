using System;
using System.Collections.Generic;

namespace IndustrialServicesSystem.Domain.Entities
{
    public partial class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public Guid ChatMessageGuid { get; set; }
        public int OrderRequestId { get; set; }
        public int UserId { get; set; }
        public int? DocumentId { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; }

        public virtual Document Document { get; set; }
        public virtual OrderRequest OrderRequest { get; set; }
        public virtual User User { get; set; }
    }
}
