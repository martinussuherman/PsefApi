using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Perizinan
    {
        public Perizinan()
        {
            Apotek = new HashSet<Apotek>();
            PermohonanNavigation = new HashSet<Permohonan>();
            TransactionSubmission = new HashSet<TransactionSubmission>();
        }

        public Guid Id { get; set; }
        public int State { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public string NoIzin { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid? PermohonanId { get; set; }
        public Guid? PreviousId { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual User Modifier { get; set; }
        public virtual Permohonan Permohonan { get; set; }
        public virtual Perizinan Previous { get; set; }
        public virtual Perizinan InversePrevious { get; set; }
        public virtual ICollection<Apotek> Apotek { get; set; }
        public virtual ICollection<Permohonan> PermohonanNavigation { get; set; }
        public virtual ICollection<TransactionSubmission> TransactionSubmission { get; set; }
    }
}
