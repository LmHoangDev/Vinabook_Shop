using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Cthoadons = new HashSet<Cthoadon>();
        }

        public int MaHd { get; set; }
        public DateTime? NgayLap { get; set; }
        public int MaKh { get; set; }
        public int MaTk { get; set; }

        public virtual Khachhang MaKhNavigation { get; set; }
        public virtual Taikhoan MaTkNavigation { get; set; }
        public virtual ICollection<Cthoadon> Cthoadons { get; set; }
    }
}
