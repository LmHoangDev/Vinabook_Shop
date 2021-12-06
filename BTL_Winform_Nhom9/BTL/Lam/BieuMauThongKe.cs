using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.Models;
namespace BTL.Lam
{
    public partial class BieuMauThongKe : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public Image img = null;
        public BieuMauThongKe()
        {
            InitializeComponent();
          
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrint = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }
        private Bitmap memoryimg;
        private void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        public void LoadData()
        {
            try
            {
            List<string> a1 = (List<string>)this.Tag;
            int today = DateTime.Today.Day;
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;
            tbngaytk.Text = " Ngày " + today.ToString() + " Tháng " + month.ToString() + " Năm " + year.ToString();
            tbngaytk2.Text = "Hà nội, " + " Ngày " + today.ToString() + " Tháng " + month.ToString() + " Năm " + year.ToString();
            string[] TongSoTK = new string[] { "Tổng số sách bán ra", "Tổng số sách nhập", "Tổng số doanh thu" };
            string[] DonViTinh = new string[] { "Cuốn sách", "Cuốn sách", "Đồng" };
            int namcantinh = Convert.ToInt32(a1[1]);
            int thangbd = 0;
            int thangkt = 0;

            if (a1[0] == "Quý I")
            {
                thangbd = 1; thangkt = 3;
                 }
            else if (a1[0] == "Quý II") { thangbd = 4; thangkt = 6; }
            else if (a1[0] == "Quý III") { thangbd = 7; thangkt = 9; }
            else
                { thangbd = 10; thangkt = 12; }

            // tinh so luong ban ra hien tai
            var query = from a in db.Hoadons
                        join b in db.Cthoadons on a.MaHd equals b.MaHd
                        join c in db.Khachhangs on a.MaKh equals c.MaKh
                        join d in db.Saches on b.MaSach equals d.MaSach
                        where (a.NgayLap.Value.Month >= thangbd && a.NgayLap.Value.Month <= thangkt && a.NgayLap.Value.Year == namcantinh)
                        select new { mahd = b.MaHd, ngaylap = a.NgayLap, tenkh = c.TenKh, thanhtien = b.SoLuong * d.DonGiaBan, soluong = b.SoLuong };
            int  tongSoLuongBan = query.Sum(b => b.soluong);
            decimal tongTienBanHang = query.Sum(b => b.thanhtien);

            // tinh so luong ban ra quy truoc
            int thangbdqt = 0;
            int thangktqt = 0;
            int namquytrc = namcantinh;
            if (thangkt == 3)
            {
                thangbdqt = 10;
                thangktqt = 12;
                namquytrc = namcantinh - 1;
            }else if (thangkt == 6)
            {
                thangbdqt = 1;
                thangktqt = 3;
                namquytrc = namcantinh;
            }else if (thangkt == 9)
            {
                thangbdqt = 4;
                thangktqt = 6;
                namquytrc = namcantinh;
            }else
            {
                thangbdqt = 7;
                thangktqt = 9;
                namquytrc = namcantinh;
            }
                var query4 = from a in db.Hoadons
                             join b in db.Cthoadons on a.MaHd equals b.MaHd
                             join c in db.Khachhangs on a.MaKh equals c.MaKh
                             join d in db.Saches on b.MaSach equals d.MaSach
                             where (a.NgayLap.Value.Month >= thangbdqt && a.NgayLap.Value.Month <= thangktqt && a.NgayLap.Value.Year == namquytrc)
                             select new { mahd = b.MaHd, ngaylap = a.NgayLap, tenkh = c.TenKh, thanhtien = b.SoLuong*d.DonGiaBan, soluong = b.SoLuong };
            
            int tongSoLuongBanQT = query4.Sum(b => b.soluong);
                double ptramSLB = 0;
                string ptramSLB1 ="Không có";
                if (tongSoLuongBanQT != 0)
                {
                    /*throw new Exception("Số lượng bán quý trước phải khác không");*/
                    ptramSLB =  Convert.ToDouble(tongSoLuongBan / tongSoLuongBanQT) * 100;
                    ptramSLB1 = ptramSLB.ToString("#.##") + "%";
                }
            decimal tongTienBanHangquytrc = query4.Sum(b => b.thanhtien);
            // tinh so luong ban ra cung ki nam trc
            var query7 = from a in db.Hoadons
                         join b in db.Cthoadons on a.MaHd equals b.MaHd
                         join c in db.Khachhangs on a.MaKh equals c.MaKh
                         join d in db.Saches on b.MaSach equals d.MaSach
                         where (a.NgayLap.Value.Month >= thangbd && a.NgayLap.Value.Month <= thangkt && a.NgayLap.Value.Year == (namcantinh-1))
                         select new { mahd = b.MaHd, ngaylap = a.NgayLap, tenkh = c.TenKh, thanhtien = b.SoLuong * d.DonGiaBan, soluong = b.SoLuong };


                int tongSoLuongBanCQNT = query7.Sum(b => b.soluong);
                double ptramSLBNT  = 0;
                string ptramSLBNT1 = "Không có";
                if (tongSoLuongBanCQNT != 0)
                {
                    /*throw new Exception("Số lượng bán ra cùng kì năm trước phải khác không");*/
                     ptramSLBNT =  Convert.ToDouble(tongSoLuongBan / tongSoLuongBanCQNT) * 100;
                     ptramSLBNT1 = ptramSLBNT.ToString("#.##") + "%";
                }
                else
                {
                    ptramSLBNT1 = "Không có";
                }
                decimal tongTienBanHangCKNT = query7.Sum(b => b.thanhtien);
            /* double test = (1 - (float)3 / 2) * 100;
            string test1 = test.ToString("#.##") + "%";*/
            // tinh phamtram quy trc
           
            // tinh phantram cung quy nam trc
           /* double ptramSLBNT = (1 - Convert.ToDouble(tongSoLuongBan / tongSoLuongBanCQNT)) * 100;
            string ptramSLBNT1 = ptramSLBNT.ToString("#.##") + "%";*/

            // tinh so luong nhap
            var query2 = from a in db.Pnhaps
                         join b in db.Dondhs on a.MaDonDh equals b.MaDonDh
                         join c in db.Ctdondhs on a.MaDonDh equals c.MaDonDh
                         join d in db.Ctpnhaps on a.MaPn equals d.MaPn
                         where (a.NgayNhap.Month >= thangbd && a.NgayNhap.Month <= thangkt && a.NgayNhap.Year == namcantinh)
                         select new { soluong = d.SlNhap };
            double tongSoLuongNhap = query2.Sum(x => x.soluong);
            // tinh so luong nhap quy trc
            var query5 = from a in db.Pnhaps
                         join b in db.Dondhs on a.MaDonDh equals b.MaDonDh
                         join c in db.Ctdondhs on a.MaDonDh equals c.MaDonDh
                         join d in db.Ctpnhaps on a.MaPn equals d.MaPn
                         where (a.NgayNhap.Month >= thangbdqt && a.NgayNhap.Month <= thangktqt && a.NgayNhap.Year == namquytrc)
                         select new { soluong = d.SlNhap };
            double tongSoLuongNhapQT = query5.Sum(x => x.soluong);
                double ptramSLN = 0;
                string ptramSLN1 = "Không có";
                if (tongSoLuongNhapQT != 0)
                {
                    double x = tongSoLuongNhap / tongSoLuongNhapQT;
                    /*throw new Exception("Số lượng nhập quý trước phải khác không");*/
                     ptramSLN =  x * 100;
                     ptramSLN1 = ptramSLN.ToString("#.##") + "%";
                }
                else
                {
                    ptramSLN1 = "Không có";
                }
            // tinh so luong nhap cung quy nam trc
            var query8 = from a in db.Pnhaps
                         join b in db.Dondhs on a.MaDonDh equals b.MaDonDh
                         join c in db.Ctdondhs on a.MaDonDh equals c.MaDonDh
                         join d in db.Ctpnhaps on a.MaPn equals d.MaPn
                         where (a.NgayNhap.Month >= thangbd && a.NgayNhap.Month <= thangkt && a.NgayNhap.Year == (namcantinh-1))
                         select new { soluong = d.SlNhap };
            double tongSoLuongNhapCQNT = query8.Sum(x => x.soluong);
                double ptramSLNNT = 0;
                string ptramSLNNT1 = "Không có";
                if (tongSoLuongNhapCQNT != 0)
                {
                    double x1 = tongSoLuongNhap / tongSoLuongNhapCQNT;
                    /*throw new Exception("Số lượng nhập cùng kì năm trước phải khác không");*/
                    ptramSLNNT = x1 * 100;
                    ptramSLNNT1 = ptramSLNNT.ToString() + "%";
                }
                else
                {
                    ptramSLNNT1 = "Không có";
                }
            
                // tinh phantram quy trc
           
            // tinh phan tram cung quy nam trc
           



            // tinh tong chi tieu cho viec nhap hang hien tai
            var query3 = from a in db.Pnhaps
                         join b in db.Dondhs on a.MaDonDh equals b.MaDonDh
                         join c in db.Ctdondhs on a.MaDonDh equals c.MaDonDh
                         join d in db.Ctpnhaps on a.MaPn equals d.MaPn
                         where (a.NgayNhap.Month >= thangbd && a.NgayNhap.Month <= thangkt && a.NgayNhap.Year == namcantinh)
                         select new { soluong = d.SlNhap, dongia = d.DgNhap ,thanhtien = d.SlNhap*d.DgNhap};
            decimal tongTienChi = query3.Sum(x => x.thanhtien);
            // tinh tong chi tieu cho viec nhap hang quy truoc
            var query6 = from a in db.Pnhaps
                         join b in db.Dondhs on a.MaDonDh equals b.MaDonDh
                         join c in db.Ctdondhs on a.MaDonDh equals c.MaDonDh
                         join d in db.Ctpnhaps on a.MaPn equals d.MaPn
                         where (a.NgayNhap.Month >= thangbdqt && a.NgayNhap.Month <= thangktqt && a.NgayNhap.Year == namquytrc)
                         select new { soluong = d.SlNhap, dongia = d.DgNhap, thanhtien = d.SlNhap * d.DgNhap };
            decimal tongTienChiQT = query6.Sum(x => x.thanhtien);
        



            // tinh tong chi tieu cho viec nhap hang cung quy nam trc
            var query9 = from a in db.Pnhaps
                         join b in db.Dondhs on a.MaDonDh equals b.MaDonDh
                         join c in db.Ctdondhs on a.MaDonDh equals c.MaDonDh
                         join d in db.Ctpnhaps on a.MaPn equals d.MaPn
                         where (a.NgayNhap.Month >= thangbd && a.NgayNhap.Month <= thangkt && a.NgayNhap.Year == (namcantinh-1))
                         select new { soluong = d.SlNhap, dongia = d.DgNhap, thanhtien = d.SlNhap * d.DgNhap };
            decimal tongTienChiCQNT = query9.Sum(x => x.thanhtien);

            // tinh tong tien ban hang

            /* double test = (1 - (float)3 / 2) * 100;
             string test1 = test.ToString("#.##") + "%";*/
             double tongDTHU = Convert.ToDouble(tongTienBanHang - tongTienChi);
            
            double tongDTQT = Convert.ToDouble(tongTienBanHangquytrc - tongTienChiQT);
            double tongDTCKNT = Convert.ToDouble(tongTienBanHangCKNT - tongTienChiCQNT);
                double ptramdtqt = 0;
                double ptramdtcknt = 0;

                List<string> sln = new List<string>();
                sln.Add(ptramSLB1);
                sln.Add(ptramSLN1);
              

                if (tongDTQT != 0)
                {
                   ptramdtqt =  (tongDTHU / tongDTQT) * 100;
                    sln.Add(ptramdtqt.ToString("#.##") + "%");
                }
                else
                {
                    sln.Add("Không có");
                }
                List<string> dthu = new List<string>();
                    dthu.Add(ptramSLBNT1);
                    dthu.Add(ptramSLNNT1);
                if (tongDTCKNT != 0)
                {
                    ptramdtcknt =  (tongDTHU / tongDTCKNT) * 100;

                   
                    dthu.Add(ptramdtcknt.ToString("#.##") + "%");
                }
                else
                {  
                    dthu.Add("Không có");
                }
                
                
                // Danh sach du lieu
                List<string> slb = new List<string>();
            slb.Add(tongSoLuongBan.ToString());
            slb.Add(tongSoLuongNhap.ToString());
            slb.Add(tongDTHU.ToString("#.##"));
           
         
            dataThongKe.Rows.Clear();
            for (int i = 0; i < 3; i++)
            {
                    dataThongKe.Rows.Add((i + 1), TongSoTK[i], DonViTinh[i], slb[i], sln[i], dthu[i]);
                   /* dataThongKe.Rows.Add((i + 1),0,0,0,0,0);*/
                }

            lblQuy.Text = a1[0] + " Năm " + a1[1];
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BieuMauThongKe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tbngaytk_TextChanged(object sender, EventArgs e)
        {

        }

        private void Print(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Print");

        }
        public static bool IsAnyInstalledPrinters()
        {
            return PrinterSettings.InstalledPrinters.Count > 0;
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            //e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
            e.Graphics.DrawImage(memoryimg, 0, 0, 840, 1120);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Print(this.panelPrint);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbngaytk2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblQuy_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
