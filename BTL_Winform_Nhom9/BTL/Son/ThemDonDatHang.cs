using BTL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BTL.Son
{
    public partial class ThemDonDatHang : Form
    {
        QLBanSachContext qLBanSachContext = new QLBanSachContext();

        List<Sach> sachCanDat = new List<Sach>();
        List<Sach> sachMoi = new List<Sach>();

        private int maDonDh;
        private string tenNCC;
        private string diaChiNCC;
        private string soDT;
        private string ngayLap;
        decimal tongTien = 0;

        int index = 0;
        private QLDonDatHang qLDonDatHang;
        
        public ThemDonDatHang(QLDonDatHang qLDonDatHang)
        {
            this.qLDonDatHang = qLDonDatHang;

            InitializeComponent();
            HideAllPanel();

            dtpNgayLap.Value = DateTime.Today;

            GetComboBoxLoaiSach();
            GetComboBoxNCC();
            GetComboBoxSach();

        }

        private void ThemDonDatHang_Load(object sender, EventArgs e)
        {

        }

        #region Ẩn hiện thị panel nhập sách đặt 
        private void HideAllPanel()
        {
            panelDatSachCu.Visible = false;
            panelDatSachMoi.Visible = false;
        }

        private void ShowPanel(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
        }

        private void HidePanel(Panel panel)
        {
            if (panel.Visible == true)
            {
                panel.Visible = false;
            }
        }

        #endregion

        #region Xử lý sự kiện radio button
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSachCu.Checked == true)
            {
                ShowPanel(panelDatSachCu);
                HidePanel(panelDatSachMoi);

                string maSach = cbCu_TenSach.SelectedValue.ToString();

                if (maSach.Equals("BTL.Models.Sach") == false)
                {
                    int x = int.Parse(maSach);
                    HienThiSachCu();
                }
            }
        }

        private void rbSachMoi_CheckedChanged(object sender, EventArgs e)
        {

            if (rbSachMoi.Checked == true)
            {
                ShowPanel(panelDatSachMoi);
                HidePanel(panelDatSachCu);
            }
        }

        #endregion

        #region Truyền dữ liệu vào các ComboBox

        private void GetComboBoxNCC()
        {
            var ncc = qLBanSachContext.Nhaccs
                      .ToList();
            cbNCC.DataSource = ncc;
            cbNCC.DisplayMember = "TenNhaCc";
            cbNCC.ValueMember = "MaNhaCc";
        }

        private void GetComboBoxSach()
        {
            var sach = qLBanSachContext.Saches
                      .ToList();
            cbCu_TenSach.DataSource = sach;
            cbCu_TenSach.DisplayMember = "TenSach";
            cbCu_TenSach.ValueMember = "MaSach";
        }

        private void GetComboBoxLoaiSach()
        {
            var loaiSach = qLBanSachContext.Loaisaches
                      .ToList();

            cbMoi_LoaiSach.DataSource = loaiSach;
            cbMoi_LoaiSach.DisplayMember = "TenLoai";
            cbMoi_LoaiSach.ValueMember = "MaLoai";
        }
        #endregion

        #region Hiển thị thông tin sách cũ
        private Sach GetSachCu(int maSach)
        {
            var sach = qLBanSachContext.Saches
                .Where(s => s.MaSach == maSach)
                .Include("MaLoaiNavigation")
                .SingleOrDefault();
            return sach;
        }

        private void HienThiSachCu()
        {
            string maSach = cbCu_TenSach.SelectedValue.ToString();

            if (maSach.Equals("BTL.Models.Sach") == false)
            {
                int x = int.Parse(maSach);
                Sach sach = GetSachCu(x);

                txtLoaiSachCu.Text = sach.MaLoaiNavigation.TenLoai;
                txtCu_TacGia.Text = sach.TacGia;
                txtCu_NXB.Text = sach.NhaXuatBan;
                txtCu_GiaBan.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", sach.DonGiaBan);
                txtCu_GiaNhap.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", sach.DonGiaNhap);
            }
        }

        private void cbCu_TenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiSachCu();
        }
        #endregion

        private bool isValid()
        {
            #region Check khi đặt hàng sách cũ

            if (rbSachCu.Checked == true)
            {
                if (String.IsNullOrWhiteSpace(txtCu_SLN.Text))
                {
                    MessageBox.Show("Bạn chưa nhập số lượng sách cần đặt");
                    return false;
                }

                int x;
                bool isSoNguyen = int.TryParse(txtCu_SLN.Text, out x);
                if (isSoNguyen == false || x <= 0)
                {
                    MessageBox.Show("Số lượng nhập phải là số nguyên dương");
                    return false;
                }               
            }
            #endregion

            #region Check khi đặt hàng sách mới
            if (rbSachMoi.Checked == true)
            {
                if (String.IsNullOrWhiteSpace(txtTenSach.Text))
                {
                    MessageBox.Show("Tên sách không được để trống");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(txtMoi_TacGia.Text))
                {
                    MessageBox.Show("Tác giả không được để trống");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(txtMoi_NXB.Text))
                {
                    MessageBox.Show("Nhà xuất bản không được để trống");
                    return false;
                }

                if (String.IsNullOrWhiteSpace(txtMoi_SLN.Text))
                {
                    MessageBox.Show("Số lượng nhập không được để trống");
                    return false;
                }

                int x;
                bool isSoNguyen = int.TryParse(txtMoi_SLN.Text, out x);
                if (isSoNguyen == false || x <= 0)
                {
                    MessageBox.Show("Số lượng nhập phải là số nguyên dương");
                    return false;
                }

                decimal z;
                isSoNguyen = decimal.TryParse(txtMoi_GiaBan.Text, out z);
                if (isSoNguyen == false || z <= 0)
                {
                    MessageBox.Show("Đơn giá bán phải là số nguyên dương");
                    return false;
                }
            }
            #endregion

            return true;
        }

        private void ThemSachVaoBang()
        {
            DataGridViewRow row = (DataGridViewRow)dgvSachDatHang.Rows[0].Clone();

            if (rbSachCu.Checked == true)
            {
                int maSach = int.Parse(cbCu_TenSach.SelectedValue.ToString());
                Sach x = GetSachCu(maSach);
                if (sachCanDat.Contains(x) == false)
                    sachCanDat.Add(x);
                else
                {
                    MessageBox.Show("Bạn đã đặt sách này rồi");
                    return;
                }

                row.Cells[0].Value = cbCu_TenSach.Text;
                row.Cells[1].Value = txtCu_SLN.Text;
                row.Cells[2].Value = txtCu_GiaNhap.Text;

                decimal thanhTien = int.Parse(txtCu_SLN.Text) * decimal.Parse(txtCu_GiaNhap.Text);
                row.Cells[3].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", thanhTien);

                tongTien += thanhTien;

                dgvSachDatHang.Rows.Add(row);
            }

            if (rbSachMoi.Checked == true)
            {
                Sach x = new Sach();
                x.TenSach = txtTenSach.Text;
                x.TacGia = txtMoi_TacGia.Text;
                x.NhaXuatBan = txtMoi_NXB.Text;
                x.MaLoai = int.Parse(cbMoi_LoaiSach.SelectedValue.ToString());
                x.DonGiaBan = decimal.Parse(txtMoi_GiaBan.Text);
                x.DonGiaNhap = decimal.Parse(txtMoi_GiaNhap.Text);

                qLBanSachContext.Saches.Add(x);
                qLBanSachContext.SaveChanges();

                var s = qLBanSachContext.Saches.OrderBy(s => s.MaSach)
                    .LastOrDefault();

                sachMoi.Add(s);
                sachCanDat.Add(s);

                GetComboBoxSach();

                row.Cells[0].Value = txtTenSach.Text;
                row.Cells[1].Value = txtMoi_SLN.Text;
                row.Cells[2].Value = txtMoi_GiaNhap.Text;

                decimal thanhTien = int.Parse(txtMoi_SLN.Text) * decimal.Parse(txtMoi_GiaNhap.Text);
                row.Cells[3].Value = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", thanhTien);
                dgvSachDatHang.Rows.Add(row);

                tongTien += thanhTien;

                ClearTextBoxMoi();
            }
            lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongTien);
        }

        private void SuaSachDat()
        {
            Sach x = sachCanDat[index];

            if (sachMoi.Contains(x) == true)
            {
                var querySua = qLBanSachContext.Saches
                    .Where(s => s.MaSach == x.MaSach)
                    .SingleOrDefault();
                if (isValid() == true)
                {
                    querySua.TenSach = txtTenSach.Text;
                    querySua.MaLoai = int.Parse(cbMoi_LoaiSach.SelectedValue.ToString());
                    querySua.TacGia = txtMoi_TacGia.Text;
                    querySua.NhaXuatBan = txtMoi_NXB.Text;
                    querySua.DonGiaBan = decimal.Parse(txtMoi_GiaBan.Text);
                    querySua.DonGiaNhap = decimal.Parse(txtMoi_GiaNhap.Text);
                }

                qLBanSachContext.SaveChanges();

                dgvSachDatHang.Rows[index].Cells[1].Value = txtMoi_SLN.Text;

                sachMoi[sachMoi.FindIndex(s => s.MaSach.Equals(x.MaSach))] = querySua;
                sachCanDat[sachCanDat.FindIndex(s => s.MaSach.Equals(x.MaSach))] = querySua;

                ClearTextBoxMoi();
            }

            else
            {
                dgvSachDatHang.Rows[index].Cells[1].Value = txtCu_SLN.Text;
            }
        }

        private void XoaSachDat()
        {
            Sach x = sachCanDat[index];

            var queryXoa = qLBanSachContext.Saches
                 .Where(s => s.MaSach == x.MaSach)
                 .SingleOrDefault();

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                int sld = int.Parse(dgvSachDatHang.Rows[index].Cells[1].Value.ToString());
                decimal thanhTien = sld * x.DonGiaNhap;
                tongTien -= thanhTien;

                if (sachMoi.Contains(x) == true)
                {
                    qLBanSachContext.Saches.Remove(queryXoa);
                    qLBanSachContext.SaveChanges();
                    sachMoi.Remove(x);
                }

                sachCanDat.Remove(x);
                dgvSachDatHang.Rows.RemoveAt(index);

                if (rbSachMoi.Checked == true)
                {
                    ClearTextBoxMoi();
                }

                if (rbSachCu.Checked == true)
                {
                    txtMoi_SLN.Clear();
                }
            }

            lblTongTien.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongTien);
        }

        private void ChotDonDatHang()
        {
            Dondh dondh = new Dondh();
            dondh.MaNhaCc = int.Parse(cbNCC.SelectedValue.ToString());
            dondh.NgayDh = dtpNgayLap.Value;
            dondh.TrangThai = "Chưa nhập";

            qLBanSachContext.Dondhs.Add(dondh);
            qLBanSachContext.SaveChanges();

            var d = qLBanSachContext.Dondhs
                .OrderBy(x => x.MaDonDh)
                .Include("MaNhaCcNavigation")
                .LastOrDefault();

            maDonDh = d.MaDonDh;
            tenNCC = d.MaNhaCcNavigation.TenNhaCc;
            diaChiNCC = d.MaNhaCcNavigation.DiaChi;
            soDT = d.MaNhaCcNavigation.DienThoai;

            DateTime nl = (DateTime)d.NgayDh;
            ngayLap = nl.ToShortDateString();

            for(int i = 0; i < sachCanDat.Count; i++)
            {
                Ctdondh ctdondh = new Ctdondh();
                ctdondh.MaDonDh = d.MaDonDh;
                ctdondh.MaSach = sachCanDat[i].MaSach;
                ctdondh.SlDat = int.Parse(dgvSachDatHang.Rows[i].Cells[1].Value.ToString());
                ctdondh.ThanhTien = decimal.Parse(dgvSachDatHang.Rows[i].Cells[3].Value.ToString());
                qLBanSachContext.Ctdondhs.Add(ctdondh);
            }
            qLBanSachContext.SaveChanges();

            this.Close();
        }

        private void HuyDonDatHang()
        {
            foreach (var item in sachMoi)
            {
                var query = qLBanSachContext.Saches
                    .Where(s => s.MaSach == item.MaSach)
                    .SingleOrDefault();
                qLBanSachContext.Saches.Remove(query);
            }
            qLBanSachContext.SaveChanges();
        }

        private void ClearTextBoxMoi()
        {
            txtTenSach.Clear();
            txtMoi_GiaBan.Clear();
            txtMoi_NXB.Clear();
            txtMoi_SLN.Clear();
            txtMoi_TacGia.Clear();
            txtTenSach.Focus();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                ThemSachVaoBang();
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            SuaSachDat();
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            XoaSachDat();
        }

        private void dgvSachDatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {
                if (index < 0 || index > dgvSachDatHang.RowCount - 1)
                    throw new Exception("Dòng bạn chọn không tồn tại");

                Sach x = sachCanDat[index];

                if (sachMoi.Contains(x) == false)
                {
                    rbSachCu.Checked = true;

                    cbCu_TenSach.SelectedValue = x.MaSach;
                    txtCu_SLN.Text = dgvSachDatHang.Rows[index].Cells[1].Value.ToString();
                }
                else
                {
                    rbSachMoi.Checked = true;
                    txtTenSach.Text = x.TenSach;
                    txtLoaiSachCu.Text = x.MaLoaiNavigation.TenLoai;
                    txtMoi_TacGia.Text = x.TacGia;
                    txtMoi_NXB.Text = x.NhaXuatBan;
                    txtMoi_GiaBan.Text = x.DonGiaBan.ToString();
                    txtMoi_SLN.Text = dgvSachDatHang.Rows[index].Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Thêm đơn đặt hàng
        private void button1_Click(object sender, EventArgs e)
        {
            if(sachCanDat.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách để đặt");
                return;
            }
            ChotDonDatHang();
            qLDonDatHang.LoadDonDatHang(qLDonDatHang.GetDonDatHang());
        }

        //Hủy đơn đặt hàng
        private void button2_Click(object sender, EventArgs e)
        {
            HuyDonDatHang();
            this.Close();
        }

        private void btnDatHangVaIn_Click(object sender, EventArgs e)
        {
            if (sachCanDat.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách để đặt");
                return;
            }

            ChotDonDatHang();
            qLDonDatHang.LoadDonDatHang(qLDonDatHang.GetDonDatHang());

            var ddh = qLBanSachContext.Ctdondhs
                .Where(s => s.MaDonDh == maDonDh)
                .ToList();               ;

            string TT = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", tongTien);
            InDonDatHang inDonDatHang = new InDonDatHang(maDonDh, tenNCC, diaChiNCC, soDT, ngayLap, TT, ddh);
            inDonDatHang.ShowDialog();
        }
    }
}
