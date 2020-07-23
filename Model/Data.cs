using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class Data
    {
        public Data()
        {
            DataLine = new HashSet<DataLine>();
            Department = new HashSet<Department>();
            JobRole = new HashSet<JobRole>();
            Sequence = new HashSet<Sequence>();
            User = new HashSet<User>();
            UserChannel = new HashSet<UserChannel>();
        }

        public Guid Id { get; set; }
        public string Submodule { get; set; }

        public virtual ICollection<DataLine> DataLine { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<JobRole> JobRole { get; set; }
        public virtual ICollection<Sequence> Sequence { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<UserChannel> UserChannel { get; set; }
    }
}
