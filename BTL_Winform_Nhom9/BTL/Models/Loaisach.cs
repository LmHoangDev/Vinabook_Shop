using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class Loaisach
    {
        public Loaisach()
        {
            Saches = new HashSet<Sach>();
        }

        public int MaLoai { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
