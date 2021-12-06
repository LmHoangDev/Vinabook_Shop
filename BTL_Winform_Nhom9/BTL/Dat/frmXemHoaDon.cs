using BTL.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BTL
{
    public partial class frmXemHoaDon : Form
    {
        QLBanSachContext db = new QLBanSachContext();

        private int maTk;
        public frmXemHoaDon(int maTk)
        {
            this.maTk = maTk;
            InitializeComponent();
        }
        int index = -1;
        private void dvgDanhSachHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
        private void HienThiDanhSachHoaDon()
        {
            var query = from h in db.Hoadons
                        select new
                        {
                            h.MaHd,
                            h.NgayLap,
                            h.MaKhNavigation.TenKh,
                            h.MaTkNavigation.HoTen,
                        };

            dvgDanhSachHoaDon.DataSource = query.ToList();
            dvgDanhSachHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dvgDanhSachHoaDon.Columns[1].HeaderText = "Ngày lập";
            dvgDanhSachHoaDon.Columns[2].HeaderText = "Tên khách hàng";
            dvgDanhSachHoaDon.Columns[3].HeaderText = "Tên người lập";
        }
        private void HienThiChiTietHoaDon()
        {
            if (index == -1)
            {
                MessageBox.Show("Bạn chưa chọn dòng hóa đơn cần xem");
                return;
            }
            int ma = int.Parse(dvgDanhSachHoaDon.Rows[index].Cells[0].Value.ToString());

            Hoadon hd = db.Hoadons.SingleOrDefault(hd => hd.MaHd == ma);
            txtMahoadon.Text = hd.MaHd.ToString();
            txtNgaylap.Text = hd.NgayLap.ToString();
            Taikhoan tk = db.Taikhoans.SingleOrDefault(tk => tk.MaTk == hd.MaTk);
            txtNguoilap.Text = tk.HoTen;


            Khachhang kh = db.Khachhangs.SingleOrDefault(kh => kh.MaKh == hd.MaKh);
            txtMakhachhang.Text = kh.MaKh.ToString();
            txtTenkhachhang.Text = kh.TenKh.ToString();
            txtDiachi.Text = kh.DiaChi.ToString();
            txtSodienthoai.Text = kh.SoDt.ToString();

            var query3 = from h in db.Cthoadons
                         where h.MaHd == int.Parse(dvgDanhSachHoaDon.Rows[index].Cells[0].Value.ToString())
                         select new
                         {
                             h.MaSachNavigation.TenSach,
                             h.MaSachNavigation.TacGia,
                             h.MaSachNavigation.NhaXuatBan,
                             h.MaSachNavigation.DonGiaBan,
                             h.SoLuong,
                             h.ThanhTien,
                         };
            dvgDanhsachchitietsach.DataSource = query3.ToList();
            dvgDanhsachchitietsach.Columns[0].HeaderText = "Tên sách";
            dvgDanhsachchitietsach.Columns[1].HeaderText = "Tác giả";
            dvgDanhsachchitietsach.Columns[2].HeaderText = "Nhà xuất bản";
            dvgDanhsachchitietsach.Columns[3].HeaderText = "Đơn giá";
            dvgDanhsachchitietsach.Columns[4].HeaderText = "Số lượng";
            dvgDanhsachchitietsach.Columns[5].HeaderText = "Thành tiền";
            txtTongTien.Text = ThanhTien(hd.MaHd).ToString();
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            HienThiDanhSachHoaDon();

        }

        private decimal ThanhTien(int ma)
        {
            var query = from ct in db.Cthoadons
                        where ct.MaHd == ma
                        select new
                        {
                            ct.ThanhTien
                        };
            var li = query.ToList();
            decimal tt = 0;
            foreach (var item in li)
            {
                tt += item.ThanhTien;
            }
            return tt;
        }

        private void Tim()
        {
            if (txtMahdtim.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMahdtim.Focus();
                return;
            }
            else
            {
                try
                {
                    int ma = int.Parse(txtMahdtim.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn nhập mã hóa đơn không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMahdtim.SelectAll();
                    return;
                }
            }
            Hoadon hd = db.Hoadons.SingleOrDefault(hd => hd.MaHd == int.Parse(txtMahdtim.Text));
            if (hd != null)
            {
                var query = from h in db.Hoadons
                            where h.MaHd == int.Parse(txtMahdtim.Text)
                            select new
                            {
                                h.MaHd,
                                h.NgayLap,
                                h.MaKhNavigation.TenKh,
                                h.MaTkNavigation.HoTen,
                            };

                dvgDanhSachHoaDon.DataSource = query.ToList();
                dvgDanhSachHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
                dvgDanhSachHoaDon.Columns[1].HeaderText = "Ngày lập";
                dvgDanhSachHoaDon.Columns[2].HeaderText = "Tên khách hàng";
                dvgDanhSachHoaDon.Columns[3].HeaderText = "Tên người lập";
            }
            else
            {
                MessageBox.Show("Hóa đơn không có trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoc_Click_2(object sender, EventArgs e)
        {

            var query = from h in db.Hoadons
                        where dtNgaybatdau.Value <= h.NgayLap && h.NgayLap <= dtNgayketthuc.Value
                        select new
                        {
                            h.MaHd,
                            h.NgayLap,
                            h.MaKhNavigation.TenKh,
                            h.MaTkNavigation.HoTen
                        };
            dvgDanhSachHoaDon.DataSource = query.ToList();
            dvgDanhSachHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dvgDanhSachHoaDon.Columns[1].HeaderText = "Ngày lập";
            dvgDanhSachHoaDon.Columns[2].HeaderText = "Tên khách hàng";
            dvgDanhSachHoaDon.Columns[3].HeaderText = "Tên người lập";
        }

        private void btnboloc_Click_1(object sender, EventArgs e)
        {
            HienThiDanhSachHoaDon();
        }
        private void btnTim_Click_1(object sender, EventArgs e)
        {
            Tim();
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            HienThiChiTietHoaDon();
        }
        private void btnLapHoaDon_Click_1(object sender, EventArgs e)
        {
            frmLapHoaDon myForm = new frmLapHoaDon(maTk);

            myForm.Show();
        }
        private void btninhoadon_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("Bạn chưa chọn dòng hóa đơn cần xuất");
                return;
            }
            else
            {
                int ma = int.Parse(dvgDanhSachHoaDon.Rows[index].Cells[0].Value.ToString());
                Hoadon hd = db.Hoadons.SingleOrDefault(hd => hd.MaHd == ma);
                Khachhang kh = db.Khachhangs.SingleOrDefault(kh => kh.MaKh == hd.MaKh);
                Taikhoan tk = db.Taikhoans.SingleOrDefault(tk => tk.MaTk == maTk);
                PdfPTable tthd = new PdfPTable(2);
               // tthd.DefaultCell.Left 
                //tthd.DefaultCell.PaddingLeft = 90f;
     
                tthd.DefaultCell.BorderWidth = 0;
                
                //tthd.WidthPercentage = 50f;

                //tthd.HorizontalAlignment = Element.ALIGN_LEFT;
                tthd.SpacingBefore = 1f;
                //tthd.SpacingAfter = 20f;
                string path = Application.StartupPath + "Times New Roman 400.ttf";              
                BaseFont bf;
                try
                {
                    bf = BaseFont.CreateFont(path, BaseFont.IDENTITY_H, true);
                }
                catch
                {
                    MessageBox.Show("Bạn phải chọn đường dẫn đến thư mục :Time New Roman 400.ttf không chính xác.Có thể file nằm trong mục Resources của project",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Font font1 = new Font(bf, 2f);
                Font font12 = new Font(bf, 2f);
                font12.SetStyle(1);
                Phrase dongmahd = new Phrase();
                dongmahd.Add(new Chunk("Mã HD: ", font12));
                dongmahd.Add(new Chunk(hd.MaHd.ToString(), font1));
                PdfPCell mahd = new PdfPCell(dongmahd);
                mahd.BorderWidth = 0;
                mahd.Padding = 0;
                mahd.PaddingBottom = 0.2f;
                mahd.Colspan = 2;
                tthd.AddCell(mahd);
                Phrase dongtennl = new Phrase();
                dongtennl.Add(new Chunk("Người lập: ", font12));
                dongtennl.Add(new Chunk(tk.HoTen, font1));
                PdfPCell nglap = new PdfPCell(dongtennl);
                nglap.Colspan = 2;
                nglap.Padding = 0;
                nglap.PaddingBottom = 0.2f;
                nglap.BorderWidth = 0;
                tthd.AddCell(nglap);
                Phrase dongtenkh = new Phrase();
                dongtenkh.Add(new Chunk("Tên khách hàng: ", font12));
                dongtenkh.Add(new Chunk(kh.TenKh, font1));
                PdfPCell Tenkh = new PdfPCell(dongtenkh);
                Tenkh.Colspan = 2;
                Tenkh.BorderWidth = 0;
                Tenkh.PaddingBottom = 0.2f;
                Tenkh.Padding = 0;
                tthd.AddCell(Tenkh);
                Phrase dongdc = new Phrase();
                dongdc.Add(new Chunk("Địa chỉ: ", font12));
                dongdc.Add(new Chunk(kh.DiaChi, font1));
                PdfPCell diachi = new PdfPCell(dongdc);
                diachi.Colspan = 2;
                diachi.Padding = 0;
                diachi.BorderWidth = 0;
                tthd.AddCell(diachi);
                Phrase dongsdt = new Phrase();
                dongsdt.Add(new Chunk("Số điện thoại: ", font12));
                dongsdt.Add(new Chunk(kh.SoDt, font1));
                PdfPCell sodt = new PdfPCell(dongsdt);
                sodt.Colspan = 2;
                sodt.Padding = 0;
                sodt.BorderWidth = 0;
                tthd.AddCell(sodt);

                PdfPTable ttsp = new PdfPTable(10);
                ttsp.DefaultCell.Rotation = 0;
                ttsp.DefaultCell.BorderWidth = 0f;
                ttsp.TotalWidth = 40f;
              
                PdfPCell td1 = new PdfPCell(new Phrase("Tên sách", font12));
                PdfPCell td2 = new PdfPCell(new Phrase("Đơn giá", font12));
                PdfPCell td3 = new PdfPCell(new Phrase("SL", font12));
                PdfPCell td4 = new PdfPCell(new Phrase("T.Tiền", font12));
                td1.BorderWidth = 0;
                td1.Colspan = 5;
                td1.PaddingLeft = 0;
                td2.BorderWidth = 0;
                td3.BorderWidth = 0;
                td4.BorderWidth = 0;
                td1.Padding = 0;
                td1.PaddingBottom = 2f;
                td2.Padding = 0;
                td2.Colspan = 2;
                td3.Padding = 0;
                td4.Padding = 0;
                td4.Colspan = 2;
                ttsp.AddCell(td1);
                ttsp.AddCell(td2);
                ttsp.AddCell(td3);
                ttsp.AddCell(td4);
                ttsp.DefaultCell.Padding = 0;
                var ct = from cthd in db.Cthoadons
                         where cthd.MaHd == ma
                         select new
                         {
                             cthd.MaSach,
                             cthd.MaSachNavigation.TenSach,
                             cthd.MaSachNavigation.DonGiaBan,
                             cthd.SoLuong,
                             cthd.ThanhTien
                         };
               
                var li = ct.ToList();
                
                foreach (var item in li)
                {
                    
                    PdfPCell cell = new PdfPCell(new Phrase(item.TenSach.ToString(), font1));
                    PdfPCell cell1 = new PdfPCell(new Phrase(((decimal)item.DonGiaBan).ToString("0,00.##"), font1));
                    PdfPCell cell2 = new PdfPCell(new Phrase(item.SoLuong.ToString(), font1));
                    PdfPCell cell3 = new PdfPCell(new Phrase(((decimal)item.ThanhTien).ToString("0,00.##"), font1));
                    PdfPCell cell4 = new PdfPCell(new Phrase(item.MaSach.ToString(),font1));
                    cell.BorderWidth = 0;
                    cell.Colspan = 5;
                    cell.PaddingBottom = 1f;
                    cell1.BorderWidth = 0;
                    cell2.BorderWidth = 0;
                    cell3.BorderWidth = 0;
                    cell4.BorderWidth = 0;
                    cell.Padding = 0;
                    cell1.Padding = 0;
                    cell2.Padding = 0;
                    cell3.Padding = 0;
                    cell1.Colspan = 2;
                    cell3.Colspan = 2;
                    ttsp.AddCell(cell);
                    //ttsp.AddCell(cell4);
                    ttsp.AddCell(cell1);
                    ttsp.AddCell(cell2);
                    ttsp.AddCell(cell3);

                }
               
                Font fontt = new Font(bf, 2.2f);
                fontt.SetStyle(1);
                PdfPTable tt = new PdfPTable(7);
                tt.DefaultCell.BorderWidth = 0;
                //tt.SpacingBefore = 10f;
                //tt.WidthPercentage = 40f;
               // tt.DefaultCell.PaddingRight = 60f;
                //tt.HorizontalAlignment = Element.ALIGN_RIGHT;
                Decimal sum = 0;
                foreach (var item in ct)
                {
                    sum += item.ThanhTien;
                }
                Paragraph lineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator
                    (0.0F, 80.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                lineSeparator.SetLeading(0.2f, 0.2f);
                PdfPCell ttcell1 = new PdfPCell(new Phrase("Tổng tiền: ", fontt));
                ttcell1.Colspan = 5;
                ttcell1.BorderWidth = 0;
                ttcell1.Padding = 0;
                tt.AddCell(ttcell1);
                PdfPCell ttcell2 = new PdfPCell(new Phrase(((decimal)sum).ToString("0,00.##"), fontt));
                ttcell2.Colspan = 2;
                ttcell2.BorderWidth = 0;
                ttcell2.Padding = 0;
                ttcell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tt.AddCell(ttcell2);
                PdfPCell tktcell1 = new PdfPCell(new Phrase("Tiền khách trả: ", fontt));
                tktcell1.Colspan = 5;
                tktcell1.BorderWidth = 0;
                tktcell1.Padding = 0;
                tt.AddCell(tktcell1);
                //txtTest.Text = flTienThuong.ToString("0,00.##");
                PdfPCell tktcell2 = new PdfPCell(new Phrase(((decimal)sum).ToString("0,00.##"), fontt));
                tktcell2.Colspan = 2;
                tktcell2.BorderWidth = 0;
                tktcell2.Padding = 0;
                tktcell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tt.AddCell(tktcell2);
                PdfPCell tkdcell1 = new PdfPCell(new Phrase("Tiền trả lại: ", fontt));
                tkdcell1.Colspan = 5;
                tkdcell1.BorderWidth = 0;
                tkdcell1.Padding = 0;
                tt.AddCell(tkdcell1);
                PdfPCell tkdcell2 = new PdfPCell(new Phrase(((decimal)sum).ToString("0,00.##"), fontt));
                tkdcell2.Colspan = 2;
                tkdcell2.BorderWidth = 0;
                tkdcell2.Padding = 0;
                tkdcell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tt.AddCell(tkdcell2);
                string url = @"C:\Users\ADMIN\source\repos\BTLWinformNhom9\BTL\Resources\logo.png";
                Image jbp;
                try
                {
                    jbp = Image.GetInstance(url);
                }
                catch
                {
                    MessageBox.Show("Bạn phải chọn đường dẫn đến thư mục :logo.png không chính xác.Có thể file nằm trong mục Resources của project",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                jbp.Alignment = Element.ALIGN_LEFT;
                jbp.ScaleToFit(10f, 12f);
                jbp.SetAbsolutePosition(55f, 92f);
                
               
                Font font2 = new Font(bf, 3f);
                font2.SetStyle(1);
                Paragraph pr = new Paragraph("HÓA ĐƠN BÁN HÀNG", font2);
                pr.SpacingAfter = 2f; ;
                pr.Alignment = Element.ALIGN_CENTER;
                Font fontf = new Font(bf, 1.5f);
                fontf.SetStyle(2);
                Paragraph lc = new Paragraph("CẢM ƠN QUÝ KHÁCH VÀ HẸN GẶP LẠI", fontf);
                lc.SpacingBefore = 0f;
                lc.Alignment = Element.ALIGN_CENTER;                                        
                PdfPTable ttch = new PdfPTable(1);
                PdfPCell ttch1 = new PdfPCell(new Phrase("Cửa hàng sách VinaBook 125 Phan Đình Chiểu,              Đống Đa, Hà Nội        SDT:0975892373", font1));
                ttch1.BorderWidth = 0;
                ttch1.Padding = 0;
                ttch1.PaddingLeft = 15f;
                ttch.HorizontalAlignment = Element.ALIGN_CENTER;
                ttch.AddCell(ttch1);
                
                
                try
                {
                    using (FileStream stream = new FileStream(@"C:\Users\ADMIN\Downloads\Đề 1.pdf", FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A9.Rotate(),50f,50f,5f,5f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();
                    
                        pdfdoc.Add(jbp);
                        pdfdoc.Add(ttch);                       
                        pdfdoc.Add(pr);
                        pdfdoc.Add(tthd);
                        pdfdoc.Add(lineSeparator);
                        pdfdoc.Add(ttsp);
                        pdfdoc.Add(lineSeparator);
                        pdfdoc.Add(tt);
                        pdfdoc.Add(lineSeparator);
                        pdfdoc.Add(lc);
                        pdfdoc.Close();
                        writer.Close();
                        stream.Close();
                        MessageBox.Show("In hóa đơn thành công. Mở thư mục Hoadon.pdf trong thư mục bin của project",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("File Hoadon.pdf vẫn chưa được đóng lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
    }
}
