using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.Models;
namespace BTL.Lam
{
    public partial class ThongKeQuy : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public ThongKeQuy()
        {
            InitializeComponent();
        }

        private void XuatBaoCao(object sender, EventArgs e)
        {
            try
            {
             BieuMauThongKe f = new BieuMauThongKe();
                         List<string> listItem = new List<string>();
                        string sComboboxQ = cbbQuy.SelectedItem.ToString();
                        
               
                        string sComboboxN = cbbNam.SelectedItem.ToString();
                        int nam = Convert.ToInt32(sComboboxN);
                        if(sComboboxQ == null)
                        {
                            throw new Exception("Bạn phải chọn quý trước khi xuất báo cáo");
                        }
                        if (sComboboxN == null)
                        {
                            throw new Exception("Bạn phải chọn năm trước khi xuất báo cáo");
                        }
                var query = from a in db.Cthoadons
                            join b in db.Hoadons on a.MaHd equals b.MaHd

                            select new { b.NgayLap };
                int count = query.Count(x => x.NgayLap.Value.Year == nam);
               /* if (count == 0)
                {
                    throw new Exception("Không có doanh thu của cửa hàng");
                }*/
               /* var query4 = from a in db.Hoadons
                             join b in db.Cthoadons on a.MaHd equals b.MaHd
                             join c in db.Khachhangs on a.MaKh equals c.MaKh
                             join d in db.Saches on b.MaSach equals d.MaSach
                             where (a.NgayLap.Value.Month >= thangbdqt && a.NgayLap.Value.Month <= thangktqt && a.NgayLap.Value.Year == namquytrc)
                             select new { mahd = b.MaHd, ngaylap = a.NgayLap, tenkh = c.TenKh, thanhtien = b.SoLuong * d.DonGiaBan, soluong = b.SoLuong };

                int tongSoLuongBanQT = query4.Sum(b => b.soluong);*/
                listItem.Add(sComboboxQ);
                        listItem.Add(sComboboxN);
                        f.Tag = listItem;
                
                        f.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

       

        private void load_Tk(object sender, EventArgs e)
        {
            for(int i = DateTime.Today.Year; i >= 1973; i--)
            {
                cbbNam.Items.Add(i);
            }
        }
    }
}
