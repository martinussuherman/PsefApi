using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class DesaKelurahan
    {
        public DesaKelurahan()
        {
            Apotek = new HashSet<Apotek>();
        }

        public Guid Id { get; set; }
        public int State { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public string Name { get; set; }
        public Guid KecamatanId { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual Kecamatan Kecamatan { get; set; }
        public virtual User Modifier { get; set; }
        public virtual ICollection<Apotek> Apotek { get; set; }
    }
}
