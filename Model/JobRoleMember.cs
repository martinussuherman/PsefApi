using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class JobRoleMember
    {
        public Guid Id { get; set; }
        public int? No { get; set; }
        public Guid? JobRoleId { get; set; }
        public Guid? UserId { get; set; }
        public int? RoleLevel { get; set; }
        public string RolePermissions { get; set; }
        public string Title { get; set; }

        public virtual JobRole JobRole { get; set; }
        public virtual User User { get; set; }
    }
}
