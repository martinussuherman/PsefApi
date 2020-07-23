using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class JobRole
    {
        public JobRole()
        {
            Badge = new HashSet<Badge>();
            JobRoleMember = new HashSet<JobRoleMember>();
            JobRoleModule = new HashSet<JobRoleModule>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? AuditTrailId { get; set; }
        public Guid? DataId { get; set; }
        public int? No { get; set; }
        public string Name { get; set; }
        public int GlobalRoleLevel { get; set; }
        public string GlobalRolePermissions { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual Data Data { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Badge> Badge { get; set; }
        public virtual ICollection<JobRoleMember> JobRoleMember { get; set; }
        public virtual ICollection<JobRoleModule> JobRoleModule { get; set; }
    }
}
