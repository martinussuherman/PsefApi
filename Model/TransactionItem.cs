using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class TransactionItem
    {
        public TransactionItem()
        {
            TransactionError = new HashSet<TransactionError>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AuditTrailId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? ModifierId { get; set; }
        public int State { get; set; }
        public Guid? SubmissionId { get; set; }
        public DateTime? TransactionTime { get; set; }
        public Guid? ApotekId { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyId { get; set; }
        public string ProductBrand { get; set; }
        public string ProductType { get; set; }
        public string Dosage { get; set; }
        public double? Amount { get; set; }
        public string Uom { get; set; }
        public string ProductCategory { get; set; }
        public string InvoiceNo { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerAddress { get; set; }
        public string ConsumerGender { get; set; }
        public string ConsumerId { get; set; }
        public bool ByPrescription { get; set; }
        public string DoctorName { get; set; }
        public string DoctorRegNo { get; set; }

        public virtual Apotek Apotek { get; set; }
        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User Creator { get; set; }
        public virtual User Modifier { get; set; }
        public virtual TransactionSubmission Submission { get; set; }
        public virtual ICollection<TransactionError> TransactionError { get; set; }
    }
}
