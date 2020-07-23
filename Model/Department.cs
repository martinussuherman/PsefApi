using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Department
    {
        public Department()
        {
            InverseDepartmentNavigation = new HashSet<Department>();
            JobRole = new HashSet<JobRole>();
            Sequence = new HashSet<Sequence>();
            User = new HashSet<User>();
            UserChannel = new HashSet<UserChannel>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? AuditTrailId { get; set; }
        public Guid? DataId { get; set; }
        public string Name { get; set; }

        public virtual AuditTrail AuditTrail { get; set; }
        public virtual Data Data { get; set; }
        public virtual Department DepartmentNavigation { get; set; }
        public virtual ICollection<Department> InverseDepartmentNavigation { get; set; }
        public virtual ICollection<JobRole> JobRole { get; set; }
        public virtual ICollection<Sequence> Sequence { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<UserChannel> UserChannel { get; set; }
    }
}
