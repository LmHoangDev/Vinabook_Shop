using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class Pnhap
    {
        public Pnhap()
        {
            Ctpnhaps = new HashSet<Ctpnhap>();
        }

        public int MaPn { get; set; }
        public DateTime NgayNhap { get; set; }
        public int? MaDonDh { get; set; }

        public virtual Dondh MaDonDhNavigation { get; set; }
        public virtual ICollection<Ctpnhap> Ctpnhaps { get; set; }
    }
}
