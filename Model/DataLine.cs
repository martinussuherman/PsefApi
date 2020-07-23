using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class DataLine
    {
        public Guid Id { get; set; }
        public Guid? DataId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Data Data { get; set; }
    }
}
