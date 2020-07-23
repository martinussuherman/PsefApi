using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class AuditTrail
    {
        public AuditTrail()
        {
            Apotek = new HashSet<Apotek>();
            AuditTrailLine = new HashSet<AuditTrailLine>();
            Department = new HashSet<Department>();
            DesaKelurahan = new HashSet<DesaKelurahan>();
            JobRole = new HashSet<JobRole>();
            KabKota = new HashSet<KabKota>();
            Kecamatan = new HashSet<Kecamatan>();
            Pemohon = new HashSet<Pemohon>();
            Perizinan = new HashSet<Perizinan>();
            Permohonan = new HashSet<Permohonan>();
            Provinsi = new HashSet<Provinsi>();
            Sequence = new HashSet<Sequence>();
            TransactionError = new HashSet<TransactionError>();
            TransactionItem = new HashSet<TransactionItem>();
            TransactionSubmission = new HashSet<TransactionSubmission>();
            User = new HashSet<User>();
            UserChannel = new HashSet<UserChannel>();
        }

        public Guid Id { get; set; }
        public string Submodule { get; set; }

        public virtual ICollection<Apotek> Apotek { get; set; }
        public virtual ICollection<AuditTrailLine> AuditTrailLine { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<DesaKelurahan> DesaKelurahan { get; set; }
        public virtual ICollection<JobRole> JobRole { get; set; }
        public virtual ICollection<KabKota> KabKota { get; set; }
        public virtual ICollection<Kecamatan> Kecamatan { get; set; }
        public virtual ICollection<Pemohon> Pemohon { get; set; }
        public virtual ICollection<Perizinan> Perizinan { get; set; }
        public virtual ICollection<Permohonan> Permohonan { get; set; }
        public virtual ICollection<Provinsi> Provinsi { get; set; }
        public virtual ICollection<Sequence> Sequence { get; set; }
        public virtual ICollection<TransactionError> TransactionError { get; set; }
        public virtual ICollection<TransactionItem> TransactionItem { get; set; }
        public virtual ICollection<TransactionSubmission> TransactionSubmission { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<UserChannel> UserChannel { get; set; }
    }
}
