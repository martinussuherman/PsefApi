using System;
using System.Collections.Generic;

namespace PsefApi.Model
{
    public partial class OssRegistrationType
    {
        public OssRegistrationType()
        {
            DummyPerusahaan = new HashSet<DummyPerusahaan>();
            Pemohon = new HashSet<Pemohon>();
        }

        public Guid Id { get; set; }
        public string Kode { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<DummyPerusahaan> DummyPerusahaan { get; set; }
        public virtual ICollection<Pemohon> Pemohon { get; set; }
    }
}
