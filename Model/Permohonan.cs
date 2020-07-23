using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Permohonan
    {
        public Permohonan()
        {
            Apotek = new HashSet<Apotek>();
        }

        public Guid Id { get; set; }
        public int State { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime CreatedTime { get; set; }
        public int RegistrationType { get; set; }
        public string IdPermohonan { get; set; }
        public Guid? PemohonId { get; set; }
        public Guid? PreviousId { get; set; }
        public string ProviderName { get; set; }
        public string Domain { get; set; }
        public string SystemName { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual User Modifier { get; set; }
        public virtual Pemohon Pemohon { get; set; }
        public virtual Perizinan Previous { get; set; }
        public virtual Perizinan Perizinan { get; set; }
        public virtual ICollection<Apotek> Apotek { get; set; }
    }
}
