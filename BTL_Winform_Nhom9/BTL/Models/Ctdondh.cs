
#nullable disable

namespace BTL.Models
{
    public partial class Ctdondh
    {
        public int MaDonDh { get; set; }
        public int MaSach { get; set; }
        public int SlDat { get; set; }
        public decimal ThanhTien { get; set; }

        public virtual Dondh MaDonDhNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
    }
}
