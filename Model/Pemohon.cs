using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Pemohon
    {
        public Pemohon()
        {
            Permohonan = new HashSet<Permohonan>();
        }

        public Guid Id { get; set; }
        public int State { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public Guid? LoginUserId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Nib { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyNpwp { get; set; }
        public string CompanySiup { get; set; }
        public string Director { get; set; }
        public string ApotekerName { get; set; }
        public string ApotekerEmail { get; set; }
        public string ApotekerPhone { get; set; }
        public string NoStra { get; set; }
        public string NoSipa { get; set; }
        public int CapitalSourceType { get; set; }
        public int CompanyType { get; set; }
        public int LegalEntityType { get; set; }
        public Guid? OssTypeId { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual User LoginUser { get; set; }
        public virtual User Modifier { get; set; }
        public virtual OssRegistrationType OssType { get; set; }
        public virtual ICollection<Permohonan> Permohonan { get; set; }
    }
}
