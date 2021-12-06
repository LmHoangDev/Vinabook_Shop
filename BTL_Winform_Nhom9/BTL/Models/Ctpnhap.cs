
#nullable disable

namespace BTL.Models
{
    public partial class Ctpnhap
    {
        public int MaPn { get; set; }
        public int MaSach { get; set; }
        public int SlNhap { get; set; }
        public decimal DgNhap { get; set; }

        public virtual Pnhap MaPnNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
    }
}
