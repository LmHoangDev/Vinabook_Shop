using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using BTL.Models;

namespace BTL
{
    public partial class frmLapHoaDon : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        static List<Cthoadon> li = new List<Cthoadon>();
        static List<Cthoadon> li2 = new List<Cthoadon>();
      
        static decimal TongTien = 0;
        static int TongSoLuong = 0;
        private int maTK;
        public frmLapHoaDon(int maTK)
        {
            InitializeComponent();
            this.maTK = maTK;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatLoiCTHoaDon();
        }
     
        private void ThemKhachHang()
        {
            Khachhang kh = new Khachhang();
            Khachhang khtim = new Khachhang();
             
                khtim = db.Khachhangs.SingleOrDefault(khtim => khtim.SoDt == txtSoDienThoai.Text);
                if(khtim==null)
                {
                    kh.TenKh = txtTenkhachhang.Text;
                    kh.SoDt = txtSoDienThoai.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    db.Khachhangs.Add(kh);
                    db.SaveChanges();
                    return ;
                }                                        
        }
        private void ThemHoaDon()
        {
            Hoadon hd = new Hoadon();
            hd.NgayLap = dtNgayLap.Value;
            hd.MaTk = maTK;
            int k = db.Hoadons.ToList().Count;
            Khachhang khtest = db.Khachhangs.FirstOrDefault(khtest => khtest.SoDt == txtSoDienThoai.Text);
           
                hd.MaKh = khtest.MaKh;
      

            db.Hoadons.Add(hd);
            db.SaveChanges();
        }
        private void ThemChiTietHoaDon()
        {

            var query = from h in db.Hoadons
                        select new
                        {
                            h.MaHd,
                            h.MaKh,
                        };
            var a = query.ToList();
            int dem = a.Count;

            int sum = dvgSanPham.Rows.Count;
            for (int i = 0; i < sum - 1; i++)
            {

                Cthoadon cthd = new Cthoadon();
                cthd.MaHd = a[dem - 1].MaHd;
                Sach sa = db.Saches.SingleOrDefault(s => s.TenSach.ToUpper() == dvgSanPham.Rows[i].Cells[0].Value.ToString().ToUpper());
                cthd.MaSach = sa.MaSach;
                cthd.SoLuong = int.Parse(dvgSanPham.Rows[i].Cells[2].Value.ToString());
                cthd.ThanhTien = decimal.Parse(dvgSanPham.Rows[i].Cells[3].Value.ToString());
                db.Cthoadons.Add(cthd);
            }
            db.SaveChanges();
            li.Clear();
        }
        private bool BatLoi()
        {
            if (txtTenkhachhang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenkhachhang.Focus();
                return false ;
            }

            if (txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Bạn phải số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return false;
            }
            else
            {
                try
                {
                    int i = int.Parse(txtSoDienThoai.Text);
                }
                catch
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoDienThoai.SelectAll();
                    return false ;
                }
            }

            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn phải địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            if(dvgSanPham.Rows.Count==1)
            {
                MessageBox.Show("Bạn chưa nhập sản phẩm cần mua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }    
            if (txtTienKhachDua.Text == "")
            {
                MessageBox.Show("Chưa nhập tiền khách hàng thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienKhachDua.Focus();
                return false;
            }
            else
            {
                try
                {
                    decimal i = decimal.Parse(txtTienKhachDua.Text);

                }
                catch
                {
                    MessageBox.Show("Nhập tiền khách hàng thanh toán không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTienKhachDua.SelectAll();
                    return false;
                }
            }
            decimal tienthua = decimal.Parse(txtTienThua.Text);
            if (tienthua < 0)
            {
                MessageBox.Show("Tiền khách hàng thanh toán không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienKhachDua.SelectAll();
                return false;
            }

            try
            {
                using (FileStream stream = new FileStream("HoaDon.pdf", FileMode.Create));
            }
            catch
            {
                MessageBox.Show("File Hoadon.pdf vẫn chưa được đóng lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool BatLoiCTHoaDon()
        {
           if(txtTenSanPham.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenSanPham.Focus();
                return false;
            }
            else
            {
                Sach s = db.Saches.SingleOrDefault(s => s.TenSach.ToUpper() == txtTenSanPham.Text.ToUpper());
                if(s==null)
                {
                    MessageBox.Show("Sản phẩm không có trông hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenSanPham.SelectAll();
                    return false;
                }    
            }
           if(txtSoLuong.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập số lượng mua sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return false;
            }
            else
            {
                try
                {
                    try
                    {
                        int i = int.Parse(txtSoLuong.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Bạn nhập số lượng sản phẩm không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoLuong.SelectAll();
                        return false;
                    }
                    if (int.Parse(txtSoLuong.Text) <= 0)
                        throw new Exception("Số lượng sách phải lớn hơn 0");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.SelectAll();
                    return false;
                }
               
            }
            var query = from h in db.Hoadons

                        select new
                        {
                            h.MaHd,
                            h.MaKh,
                        };
            var a = query.ToList();
            int dem = a.Count;
      
            Cthoadon cthd = new Cthoadon();
            if (dem == 0)
                cthd.MaHd = 1;
            else
                cthd.MaHd = a[dem - 1].MaHd + 1;

            Sach sa = db.Saches.SingleOrDefault(s => s.TenSach.ToUpper() == txtTenSanPham.Text.ToUpper());
            cthd.MaSach = sa.MaSach;
            cthd.SoLuong = int.Parse(txtSoLuong.Text);
            cthd.ThanhTien = sa.DonGiaBan * cthd.SoLuong;
            if (li.Contains(cthd))
            {
                MessageBox.Show("Bạn không thể chọn 1 sản phẩm trên 2 dòng hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSanPham.SelectAll();
                return false;
            }
            else
            {              
                li.Add(cthd);
                ThemSanPhamVaoBang();
                txtTenSanPham.Text = "";
                txtSoLuong.Text = "";
            }
            return true;
        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(txtTienKhachDua.Text=="")
            {

            }    
            else
            {
                try
                {
                    decimal i = 0;
                    i = decimal.Parse(txtTienKhachDua.Text) - TongTien;
                    txtTienThua.Text = i.ToString();
                }catch
                {
                    MessageBox.Show("Nhập số tiền không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return ;
                }
                        

            }

        }
       
        private void dvgSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            int row = e.RowIndex;         
            int colum = e.ColumnIndex;
            if (row==(dvgSanPham.Rows.Count - 1))
            {
                MessageBox.Show("Dòng chưa có sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (row ==- 1)
            {
                MessageBox.Show("Không chọn đúng dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (colum == 4)
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa dòng này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Cthoadon ct = new Cthoadon();
                    li.RemoveAt(row);

                    TongTien = TongTien - decimal.Parse(dvgSanPham.Rows[row].Cells[3].Value.ToString());
                    TongSoLuong = TongSoLuong - int.Parse(dvgSanPham.Rows[row].Cells[2].Value.ToString());
                    dvgSanPham.Rows.Remove(dvgSanPham.Rows[row]);
              //      txtTongSoLuong.Text = TongSoLuong.ToString();
                    txtTongTien.Text = TongTien.ToString();
                }
            }
            else if (colum == 5)
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn Sửa dòng này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (txtTenSanPham.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenSanPham.Focus();
                        return ;
                    }
                    else
                    {
                        Sach sa = db.Saches.SingleOrDefault(sa => sa.TenSach.ToUpper() == txtTenSanPham.Text.ToUpper());
                        if (sa == null)
                        {
                            MessageBox.Show("Sản phẩm không có trông hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTenSanPham.SelectAll();
                            return ;
                        }
                    }
                    if (txtSoLuong.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập số lượng mua sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSoLuong.Focus();
                        return ;
                    }
                    else
                    {
                        
                        try
                        {
                            try
                            {
                                int i = int.Parse(txtSoLuong.Text);
                            }
                            catch 
                            {
                                MessageBox.Show( "Bạn nhập số lượng sản phẩm không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSoLuong.SelectAll();
                                return;
                            }

                            if (int.Parse(txtSoLuong.Text) <= 0)
                                throw new Exception("Số lượng sách phải lớn hơn 0");
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSoLuong.SelectAll();
                            return ;
                        }
                    }
                  

                    Cthoadon ct = new Cthoadon();
                    ct.MaHd = li[row].MaHd;
                    ct.MaSach = li[row].MaSach;
                    li.RemoveAt(row);
                    Cthoadon ctms = new Cthoadon();
                    ctms.MaHd = ct.MaHd;
                    Sach s = db.Saches.SingleOrDefault(s => s.TenSach.ToUpper() == txtTenSanPham.Text.ToUpper());
                    ctms.MaSach = s.MaSach;
                    if (li.Contains(ctms))
                    {
                        MessageBox.Show("Bạn không thể chọn 1 sản phẩm trên 2 dòng hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        li.Insert(row, ct);
                    }
                    else
                    {
                        if (ctms == null)
                        {
                            MessageBox.Show("Sách không có trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTenSanPham.SelectAll();
                            return;
                        }
                        else
                        {
                            TongTien = TongTien - decimal.Parse(dvgSanPham.Rows[row].Cells[3].Value.ToString());
                            TongSoLuong = TongSoLuong - int.Parse(dvgSanPham.Rows[row].Cells[2].Value.ToString());
                            dvgSanPham.Rows[row].Cells[0].Value = txtTenSanPham.Text;
                            dvgSanPham.Rows[row].Cells[1].Value = s.DonGiaBan;
                            dvgSanPham.Rows[row].Cells[2].Value = txtSoLuong.Text;
                            dvgSanPham.Rows[row].Cells[3].Value = s.DonGiaBan * int.Parse(txtSoLuong.Text);
                            TongTien = TongTien + decimal.Parse(dvgSanPham.Rows[row].Cells[3].Value.ToString());
                            TongSoLuong = TongSoLuong + int.Parse(dvgSanPham.Rows[row].Cells[2].Value.ToString());
                            ctms.SoLuong = int.Parse(txtSoLuong.Text);
                            ctms.ThanhTien = s.DonGiaBan * int.Parse(txtSoLuong.Text);
                            li.Insert(row, ctms);
                            //     txtTongSoLuong.Text = TongSoLuong.ToString();
                            txtTongTien.Text = TongTien.ToString();
                            txtSoLuong.Text = "";
                            txtTenSanPham.Text = "";
                        }
                       
                    }
                }
            }
            else
            {
                txtTenSanPham.Text = dvgSanPham.Rows[row].Cells[0].Value.ToString();
                txtSoLuong.Text = dvgSanPham.Rows[row].Cells[2].Value.ToString();
            }
            
        }

        private void ThemSanPhamVaoBang()
        {
            DataGridViewRow row = (DataGridViewRow)dvgSanPham.Rows[0].Clone();
            row.Cells[0].Value = txtTenSanPham.Text;
            Sach s = db.Saches.SingleOrDefault(s => s.TenSach.ToUpper() == txtTenSanPham.Text.ToUpper());
            row.Cells[1].Value = s.DonGiaBan.ToString();
            row.Cells[2].Value = txtSoLuong.Text;
            row.Cells[3].Value = s.DonGiaBan * int.Parse(txtSoLuong.Text);
            TongTien += s.DonGiaBan * int.Parse(txtSoLuong.Text);
            TongSoLuong += int.Parse(txtSoLuong.Text);
            dvgSanPham.Rows.Add(row);
          //  txtTongSoLuong.Text = TongSoLuong.ToString();
            txtTongTien.Text = TongTien.ToString();
        }

        private void FormInHoaDon_Load(object sender, EventArgs e)
        {
            Taikhoan tk = db.Taikhoans.SingleOrDefault(tk => tk.MaTk == maTK);
            txtNguoiBan.Text = tk.HoTen;
            GoiY();         
        }
        private void GoiY()
        {
            var sa = from s in db.Saches
                     select new
                     {
                         s.TenSach
                     };
       
            var  li = sa.ToList();
            foreach(var item in li)
            txtTenSanPham.AutoCompleteCustomSource.Add(item.TenSach);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
           
           if( BatLoi()==true)
            {
                ThemKhachHang();
                ThemHoaDon();
                ThemChiTietHoaDon();
                li.Clear();
                InHoaDon();
                txtTenSanPham.Text = "";
                txtSoLuong.Text = "";
                txtSoDienThoai.Text = "";
                txtTenkhachhang.Text = "";
                txtDiaChi.Text = "";

                dvgSanPham.Rows.Clear();
                li.Clear();
                TongSoLuong = 0;
                TongTien = 0;
                txtTongTien.Text = 0.ToString();
                txtTienKhachDua.Text = 0.ToString();
            }    
           
        }
        private void btnHuyGd_Click(object sender, EventArgs e)
        {
            txtTenSanPham.Text = "";
            txtSoLuong.Text = "";
            txtSoDienThoai.Text = "";
            txtTenkhachhang.Text = "";
            txtDiaChi.Text = "";
           
            dvgSanPham.Rows.Clear();
            li.Clear();
            TongSoLuong = 0;
            TongTien = 0;          
            txtTongTien.Text = 0.ToString();
            txtTienKhachDua.Text = 0.ToString();
            //  txtTongSoLuong.Text = 0.ToString();
        }
        private void InHoaDon()
        {
            var query = from h in db.Hoadons

                        select new
                        {
                            h.MaHd,
                            h.MaKh,
                        };
            var a = query.ToList();
            int ma = a[a.Count - 1].MaHd;
            Hoadon hd = db.Hoadons.SingleOrDefault(hd => hd.MaHd == ma);
            Khachhang kh = db.Khachhangs.SingleOrDefault(kh => kh.MaKh == hd.MaKh);
            Taikhoan tk = db.Taikhoans.SingleOrDefault(tk => tk.MaTk == maTK);
            PdfPTable tthd = new PdfPTable(2);

            tthd.DefaultCell.BorderWidth = 0;

            tthd.SpacingBefore = 1f;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var mainp = path.Replace("\\bin\\Debug\\net5.0-windows\\", "\\Resources\\Times New Roman 400.ttf");
            BaseFont bf;
            try
            {
                bf = BaseFont.CreateFont(mainp, BaseFont.IDENTITY_H, true);
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

            dongmahd.Add(new Chunk("Mã HD: ",font12));
            dongmahd.Add(new Chunk(hd.MaHd.ToString(),font12));
           
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
            dongtenkh.Add(new Chunk(txtTenkhachhang.Text, font1));
            PdfPCell Tenkh = new PdfPCell(dongtenkh);
            Tenkh.Colspan = 2;
            Tenkh.BorderWidth = 0;
            Tenkh.PaddingBottom = 0.2f;
            Tenkh.Padding = 0;
            tthd.AddCell(Tenkh);
            Phrase dongdc = new Phrase();
            dongdc.Add(new Chunk("Địa chỉ: ", font12));
            dongdc.Add(new Chunk(txtDiaChi.Text, font1));
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
                PdfPCell cell4 = new PdfPCell(new Phrase(item.MaSach.ToString(), font1));
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
                ttsp.AddCell(cell1);
                ttsp.AddCell(cell2);
                ttsp.AddCell(cell3);

            }

            Font fontt = new Font(bf, 2.2f);
            fontt.SetStyle(1);
            PdfPTable tt = new PdfPTable(7);
            tt.DefaultCell.BorderWidth = 0;
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
            PdfPCell tktcell2 = new PdfPCell(new Phrase(decimal.Parse(txtTienKhachDua.Text).ToString("0,00.##"), fontt));
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
            PdfPCell tkdcell2 = new PdfPCell(new Phrase(decimal.Parse( txtTienThua.Text).ToString("0,00.##"), fontt));
            tkdcell2.Colspan = 2;
            tkdcell2.BorderWidth = 0;
            tkdcell2.Padding = 0;
            tkdcell2.HorizontalAlignment = Element.ALIGN_RIGHT;
            tt.AddCell(tkdcell2);
            var url = path.Replace("\\bin\\Debug\\net5.0-windows\\", "\\Resources\\_Logo.png");
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
            jbp.ScaleToFit(8f, 10f);
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
                using (FileStream stream = new FileStream("HoaDon.pdf", FileMode.Create))
                {
                  
                    Document pdfdoc = new Document(PageSize.A9.Rotate(), 50f, 50f, 5f, 5f);
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
                    MessageBox.Show("In hóa đơn thành công",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch
            {
                MessageBox.Show("File HoaDon.pdf vẫn chưa được đóng lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
