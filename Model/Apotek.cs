using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Apotek
    {
        public Apotek()
        {
            TransactionItem = new HashSet<TransactionItem>();
        }

        public Guid Id { get; set; }
        public int State { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid? DesaKelurahanId { get; set; }
        public string Name { get; set; }
        public string NoSia { get; set; }
        public string Apoteker { get; set; }
        public string NoStra { get; set; }
        public string NoSipa { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public Guid? PermohonanId { get; set; }
        public Guid? PerizinanId { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual DesaKelurahan DesaKelurahan { get; set; }
        public virtual User Modifier { get; set; }
        public virtual Perizinan Perizinan { get; set; }
        public virtual Permohonan Permohonan { get; set; }
        public virtual ICollection<TransactionItem> TransactionItem { get; set; }
    }
}
