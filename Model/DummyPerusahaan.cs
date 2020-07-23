using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class DummyPerusahaan
    {
        public Guid Id { get; set; }
        public string Nib { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Npwp { get; set; }
        public string Siup { get; set; }
        public string Director { get; set; }
        public int CapitalSourceType { get; set; }
        public int CompanyType { get; set; }
        public int LegalEntityType { get; set; }
        public Guid? OssTypeId { get; set; }

        public virtual OssRegistrationType OssType { get; set; }
    }
}
