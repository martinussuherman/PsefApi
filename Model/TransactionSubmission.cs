using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class TransactionSubmission
    {
        public TransactionSubmission()
        {
            TransactionItem = new HashSet<TransactionItem>();
        }

        public Guid Id { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public Guid? IzinId { get; set; }
        public int State { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual Perizinan Izin { get; set; }
        public virtual User Modifier { get; set; }
        public virtual ICollection<TransactionItem> TransactionItem { get; set; }
    }
}
