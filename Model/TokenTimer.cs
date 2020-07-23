using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class TokenTimer
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public int Types { get; set; }
        public string Data { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool DeleteOnExpired { get; set; }

        public virtual User User { get; set; }
    }
}
