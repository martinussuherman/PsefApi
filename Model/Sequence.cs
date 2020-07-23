using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Sequence
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? AuditTrailId { get; set; }
        public Guid? DataId { get; set; }
        public string Code { get; set; }
        public string Format { get; set; }
        public string Repeat { get; set; }
        public int IRepeatEvery { get; set; }
        public DateTime LastEntryTime { get; set; }
        public string LastEntryString { get; set; }
        public int LastEntrySequence { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual Data Data { get; set; }
        public virtual Department Department { get; set; }
    }
}
