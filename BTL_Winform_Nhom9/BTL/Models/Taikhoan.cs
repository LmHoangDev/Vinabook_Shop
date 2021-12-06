using System;
using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int MaTk { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public bool LoaiTk { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
