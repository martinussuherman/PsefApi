using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class JobRoleModule
    {
        public Guid Id { get; set; }
        public Guid? JobRoleId { get; set; }
        public int Module { get; set; }
        public int RoleLevel { get; set; }
        public string RolePermissions { get; set; }

        public virtual JobRole JobRole { get; set; }
    }
}
