using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class User
    {
        public User()
        {
            ApotekCreator = new HashSet<Apotek>();
            ApotekModifier = new HashSet<Apotek>();
            AuditTrailLine = new HashSet<AuditTrailLine>();
            Badge = new HashSet<Badge>();
            DesaKelurahanCreator = new HashSet<DesaKelurahan>();
            DesaKelurahanModifier = new HashSet<DesaKelurahan>();
            JobRoleMember = new HashSet<JobRoleMember>();
            KabKotaCreator = new HashSet<KabKota>();
            KabKotaModifier = new HashSet<KabKota>();
            KecamatanCreator = new HashSet<Kecamatan>();
            KecamatanModifier = new HashSet<Kecamatan>();
            PemohonCreator = new HashSet<Pemohon>();
            PemohonLoginUser = new HashSet<Pemohon>();
            PemohonModifier = new HashSet<Pemohon>();
            PerizinanCreator = new HashSet<Perizinan>();
            PerizinanModifier = new HashSet<Perizinan>();
            PermohonanCreator = new HashSet<Permohonan>();
            PermohonanModifier = new HashSet<Permohonan>();
            ProvinsiCreator = new HashSet<Provinsi>();
            ProvinsiModifier = new HashSet<Provinsi>();
            TokenTimer = new HashSet<TokenTimer>();
            TransactionErrorCreator = new HashSet<TransactionError>();
            TransactionErrorModifier = new HashSet<TransactionError>();
            TransactionItemCreator = new HashSet<TransactionItem>();
            TransactionItemModifier = new HashSet<TransactionItem>();
            TransactionSubmissionCreator = new HashSet<TransactionSubmission>();
            TransactionSubmissionModifier = new HashSet<TransactionSubmission>();
            UserChannel = new HashSet<UserChannel>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? AuditTrailId { get; set; }
        public Guid? DataId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual Data Data { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Apotek> ApotekCreator { get; set; }
        public virtual ICollection<Apotek> ApotekModifier { get; set; }
        public virtual ICollection<AuditTrailLine> AuditTrailLine { get; set; }
        public virtual ICollection<Badge> Badge { get; set; }
        public virtual ICollection<DesaKelurahan> DesaKelurahanCreator { get; set; }
        public virtual ICollection<DesaKelurahan> DesaKelurahanModifier { get; set; }
        public virtual ICollection<JobRoleMember> JobRoleMember { get; set; }
        public virtual ICollection<KabKota> KabKotaCreator { get; set; }
        public virtual ICollection<KabKota> KabKotaModifier { get; set; }
        public virtual ICollection<Kecamatan> KecamatanCreator { get; set; }
        public virtual ICollection<Kecamatan> KecamatanModifier { get; set; }
        public virtual ICollection<Pemohon> PemohonCreator { get; set; }
        public virtual ICollection<Pemohon> PemohonLoginUser { get; set; }
        public virtual ICollection<Pemohon> PemohonModifier { get; set; }
        public virtual ICollection<Perizinan> PerizinanCreator { get; set; }
        public virtual ICollection<Perizinan> PerizinanModifier { get; set; }
        public virtual ICollection<Permohonan> PermohonanCreator { get; set; }
        public virtual ICollection<Permohonan> PermohonanModifier { get; set; }
        public virtual ICollection<Provinsi> ProvinsiCreator { get; set; }
        public virtual ICollection<Provinsi> ProvinsiModifier { get; set; }
        public virtual ICollection<TokenTimer> TokenTimer { get; set; }
        public virtual ICollection<TransactionError> TransactionErrorCreator { get; set; }
        public virtual ICollection<TransactionError> TransactionErrorModifier { get; set; }
        public virtual ICollection<TransactionItem> TransactionItemCreator { get; set; }
        public virtual ICollection<TransactionItem> TransactionItemModifier { get; set; }
        public virtual ICollection<TransactionSubmission> TransactionSubmissionCreator { get; set; }
        public virtual ICollection<TransactionSubmission> TransactionSubmissionModifier { get; set; }
        public virtual ICollection<UserChannel> UserChannel { get; set; }
    }
}
