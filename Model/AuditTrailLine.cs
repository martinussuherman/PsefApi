using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class AuditTrailLine
    {
        public Guid Id { get; set; }
        public Guid? AuditTrailId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime Time { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual User User { get; set; }
    }
}
