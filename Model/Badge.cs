using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Badge
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? JobRoleId { get; set; }
        public string BadgeId { get; set; }
        public string Text { get; set; }
        public string Background { get; set; }
        public DateTime? ExpiryTime { get; set; }

        public virtual JobRole JobRole { get; set; }
        public virtual User User { get; set; }
    }
}
