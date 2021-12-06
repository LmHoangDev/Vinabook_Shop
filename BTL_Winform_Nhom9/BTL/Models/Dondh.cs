using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class Dondh
    {
        public Dondh()
        {
            Ctdondhs = new HashSet<Ctdondh>();
            Pnhaps = new HashSet<Pnhap>();
        }

        public int MaDonDh { get; set; }
        public DateTime? NgayDh { get; set; }
        public int? MaNhaCc { get; set; }
        public string TrangThai { get; set; }

        public virtual Nhacc MaNhaCcNavigation { get; set; }
        public virtual ICollection<Ctdondh> Ctdondhs { get; set; }
        public virtual ICollection<Pnhap> Pnhaps { get; set; }
    }
}
