using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class UserChannel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? AuditTrailId { get; set; }
        public Guid? DataId { get; set; }
        public Guid? UserId { get; set; }
        public int Channel { get; set; }
        public string ChannelUsername { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual Data Data { get; set; }
        public virtual Department Department { get; set; }
        public virtual User User { get; set; }
    }
}
