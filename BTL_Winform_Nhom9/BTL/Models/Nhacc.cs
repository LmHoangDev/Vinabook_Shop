using System.Collections.Generic;

#nullable disable

namespace BTL.Models
{
    public partial class Nhacc
    {
        public Nhacc()
        {
            Dondhs = new HashSet<Dondh>();
        }

        public int MaNhaCc { get; set; }
        public string TenNhaCc { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<Dondh> Dondhs { get; set; }
    }
}
