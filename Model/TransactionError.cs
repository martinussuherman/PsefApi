using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class TransactionError
    {
        public Guid Id { get; set; }
        public int State { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public Guid? TransactionId { get; set; }
        public string Description { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual User Modifier { get; set; }
        public virtual TransactionItem Transaction { get; set; }
    }
}
