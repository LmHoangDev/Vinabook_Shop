using BTL.Models;
using BTL.Phuc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTL
{
    public partial class FormQuanLyDonHang_Them : Form
    {
        #region Declaration
        QLBanSachContext obj = new QLBanSachContext();
        List<Ctdondh> li4 = new List<Ctdondh>();

        int[] mpn;
        List<Ctpnhap[]> p2 = new List<Ctpnhap[]>();
        int[] masach;
        int[] slct;
        List<int> masachND = new List<int>();

        int madondh;
        int index;
        string trangthai;

        double getTongTien;

        #endregion

        public FormQuanLyDonHang_Them()
        {
            InitializeComponent();
        }

        #region UserMethods
        private void GetData()
        {
            //ma phieu
            int maph = (from m in obj.Pnhaps
                        orderby m.MaPn
                        select m.MaPn).LastOrDefault();
            txtMaPhieu.Text = maph + 1 + "";

            //lay thong tin ctdondh
            var ct = from c in obj.Ctdondhs
                     where c.MaDonDh == madondh
                     select c;
            li4 = ct.ToList();
            //-----
            masach = new int[li4.Count];
            for (int i = 0; i < li4.Count; i++)
                masach[i] = li4[i].MaSach;
            //-----

            //kiem tra trang thai
            trangthai = (from x in obj.Dondhs
                         where x.MaDonDh == madondh
                         select x.TrangThai).ToString();

            //lay ma phieu nhap co ma don dat hang duoc chon
            var p1 = from p in obj.Pnhaps
                     where p.MaDonDh == madondh
                     select p.MaPn;
            mpn = p1.ToArray();

            //lay danh sach cac mang ctpnhap
            for (int i = 0; i < mpn.Length; i++)
            {
                var xyz = from p in obj.Ctpnhaps
                          where p.MaPn == mpn[i]
                          select p;
                p2.Add(xyz.ToArray());
            }

        }

        private void TongTien()
        {
            double t = (from DataGridViewRow row in dataGridView1.Rows
                        where row.Cells[7].FormattedValue.ToString() != string.Empty
                        select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum();
            txtTongTien.Text = t.ToString("N1");
            getTongTien = t;
        }

        private void ClearTextBox()
        {
            txtTenSach.Clear();
            txtSoluong.Clear();
            txtDongia.Clear();
            txtTheloai.Clear();
            txtTacgia.Clear();
            txtMaxSL.Clear();
            txtTenSach.Focus();
        }

        private void LoadBooksList()
        {
            if (trangthai == "Chưa nhập")
            {
                for (int i = 0; i < li4.Count; i++)
                {
                    Sach s = obj.Saches.SingleOrDefault(s => s.MaSach == li4[i].MaSach);
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = s.MaSach;
                    row.Cells[1].Value = s.TenSach;
                    Loaisach l = obj.Loaisaches.SingleOrDefault(l => l.MaLoai == s.MaLoai);
                    row.Cells[2].Value = l.TenLoai;
                    row.Cells[3].Value = s.TacGia;
                    row.Cells[4].Value = s.NhaXuatBan;
                    row.Cells[5].Value = li4[i].SlDat;
                    row.Cells[6].Value = double.Parse(s.DonGiaNhap.ToString());
                    double tt = int.Parse(li4[i].SlDat.ToString()) * double.Parse(s.DonGiaNhap.ToString());
                    row.Cells[7].Value = tt.ToString("N1");
                    row.Cells[8].Value = "Xóa";
                    dataGridView1.Rows.Add(row);
                    TongTien();
                }
            }
            else
            {
                thuNghiem();
                for (int i = 0; i < slct.Length; i++)
                {
                    Sach s = obj.Saches.SingleOrDefault(s => s.MaSach == masach[i]);
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = s.MaSach;
                    row.Cells[1].Value = s.TenSach;
                    Loaisach l = obj.Loaisaches.SingleOrDefault(l => l.MaLoai == s.MaLoai);
                    row.Cells[2].Value = l.TenLoai;
                    row.Cells[3].Value = s.TacGia;
                    row.Cells[4].Value = s.NhaXuatBan;
                    row.Cells[5].Value = slct[i];
                    row.Cells[6].Value = double.Parse(s.DonGiaNhap.ToString());
                    double tt = int.Parse(li4[i].SlDat.ToString()) * double.Parse(s.DonGiaNhap.ToString());
                    row.Cells[7].Value = tt.ToString("N1");
                    row.Cells[8].Value = "Xóa";
                    if (slct[i] > 0)
                        dataGridView1.Rows.Add(row);
                    TongTien();
                }
            }
        }

        private void thuNghiem()
        {
            //Them gia tri vao mang
            slct = new int[masach.Length];
            for (int i = 0; i < slct.Length; i++)
            {
                slct[i] = li4[i].SlDat;
            }

            //Mang so luong sach con thieu
            foreach (Ctpnhap[] item in p2)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    for (int j = 0; j < masach.Length; j++)
                    {
                        if (item[i].MaSach == masach[j])
                        {
                            slct[j] -= item[i].SlNhap;
                            if (slct[j] <= 0) masachND.Add(masach[j]);
                        }
                    }
                }
            }
            //loai bo sach da nhap du
            foreach (int x in masachND)
                masach = masach.Where((val => val != x)).ToArray();
            slct = slct.Where((val => val > 0)).ToArray();
        }

        #endregion

        private void FormQuanLyDonHang_Them_Load(object sender, EventArgs e)
        {
            madondh = (int)this.Tag;
            GetData();
            txtMaDonHang.Text = madondh.ToString();
            txtMaDonHang.ReadOnly = true;
            LoadBooksList();
        }

        private void btnThem_Click(object sender, EventArgs e) //nut Sua
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            if (int.Parse(txtSoluong.Text) != 0)
            {
                //int mas = int.Parse(selectedRow.Cells[0].Value.ToString());
                selectedRow.Cells[5].Value = txtSoluong.Text;
                double tt = int.Parse(txtSoluong.Text) * double.Parse(selectedRow.Cells[6].Value.ToString());
                selectedRow.Cells[7].Value = tt.ToString("N1");
                TongTien();
                ClearTextBox();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (trangthai == "Chưa nhập")
            {
                index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                if (selectedRow.Cells[0].Value != null || selectedRow.Cells[1].Value != null ||
                    selectedRow.Cells[2].Value != null || selectedRow.Cells[3].Value != null ||
                    selectedRow.Cells[4].Value != null || selectedRow.Cells[5].Value != null ||
                    selectedRow.Cells[6].Value != null)
                {
                    txtTenSach.Text = selectedRow.Cells[1].Value.ToString();
                    txtTheloai.Text = selectedRow.Cells[2].Value.ToString();
                    txtTacgia.Text = selectedRow.Cells[3].Value.ToString();
                    foreach (Ctdondh item in li4)
                        if (item.MaSach == int.Parse(selectedRow.Cells[0].Value.ToString()))
                            txtMaxSL.Text = item.SlDat + "";
                    txtSoluong.Text = selectedRow.Cells[5].Value.ToString();
                    txtDongia.Text = selectedRow.Cells[6].Value.ToString();
                    if (e.ColumnIndex == dataGridView1.Columns["Column9"].Index)
                    {
                        DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            dataGridView1.Rows.Remove(selectedRow);
                            TongTien();
                        }
                    }
                }
            }
            else
            {
                try
                {
                    index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];
                    if (selectedRow.Cells[0].Value != null || selectedRow.Cells[1].Value != null ||
                        selectedRow.Cells[2].Value != null || selectedRow.Cells[3].Value != null ||
                        selectedRow.Cells[4].Value != null || selectedRow.Cells[5].Value != null ||
                        selectedRow.Cells[6].Value != null)
                    {
                        txtTenSach.Text = selectedRow.Cells[1].Value.ToString();
                        txtTheloai.Text = selectedRow.Cells[2].Value.ToString();
                        txtTacgia.Text = selectedRow.Cells[3].Value.ToString();
                        txtMaxSL.Text = slct[index].ToString();
                        txtSoluong.Text = selectedRow.Cells[5].Value.ToString();
                        txtDongia.Text = selectedRow.Cells[6].Value.ToString();

                        if (e.ColumnIndex == dataGridView1.Columns["Column9"].Index)
                        {
                            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                dataGridView1.Rows.Remove(selectedRow);
                                TongTien();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int d = 0;
            //lay thong tin tu datagridview
            int[] ms = (from DataGridViewRow row in dataGridView1.Rows
                        where row.Cells[0].FormattedValue.ToString() != string.Empty
                        select Convert.ToInt32(row.Cells[0].FormattedValue)).ToArray();

            int[] sl = (from DataGridViewRow row in dataGridView1.Rows
                        where row.Cells[5].FormattedValue.ToString() != string.Empty
                        select Convert.ToInt32(row.Cells[5].FormattedValue)).ToArray();

            int[] dg = (from DataGridViewRow row in dataGridView1.Rows
                        where row.Cells[6].FormattedValue.ToString() != string.Empty
                        select Convert.ToInt32(row.Cells[6].FormattedValue)).ToArray();

            //them phieu nhap
            Pnhap pn = new Pnhap();
            pn.MaDonDh = int.Parse(txtMaDonHang.Text);
            pn.NgayNhap = dateTimePicker1.Value;
            obj.Pnhaps.Add(pn);
            obj.SaveChanges();

            //them chi tiet phieu nhap
            var p = obj.Pnhaps
                .OrderBy(s => s.MaPn)
                .LastOrDefault();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Ctpnhap ctpn = new Ctpnhap();
                ctpn.MaPn = p.MaPn;
                ctpn.MaSach = ms[i];
                ctpn.SlNhap = sl[i];
                ctpn.DgNhap = dg[i];

                obj.Ctpnhaps.Add(ctpn);
                if (slct[i] != sl[i])
                    d++;
            }
            obj.SaveChanges();

            //thay doi trang thai nhap
            Dondh ddh = obj.Dondhs.SingleOrDefault(s => s.MaDonDh == madondh);
            if (d == 0)
                ddh.TrangThai = "Nhập đủ";
            else
                ddh.TrangThai = "Nhập thiếu";
            obj.SaveChanges();

            //dong form sau khi them
            this.Close();
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            try
            {
                if (int.Parse(t.Text) > int.Parse(txtMaxSL.Text))
                {
                    if (FormQuanLyDonHang.isAdmin)
                    {
                        DialogResult dr = MessageBox.Show("Bạn đang nhập số lượng quá số lượng đặt, tiếp tục ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (dr == DialogResult.No)
                        {
                            txtSoluong.Clear();
                            txtSoluong.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể nhập quá số lượng đặt", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtSoluong.Clear();
                        txtSoluong.Focus();
                    }
                }
                if (int.Parse(t.Text) == 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtSoluong.Clear();
                    txtSoluong.Focus();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLuuIn_Click(object sender, EventArgs e)
        {
            btnLuu.PerformClick();

            Pnhap pn = obj.Pnhaps
                .Include(c => c.MaDonDhNavigation.MaNhaCcNavigation)
                .OrderBy(s => s.MaPn)
                .LastOrDefault();

            List<Ctpnhap> dspn = (from s in obj.Ctpnhaps
                                  where s.MaPn == pn.MaPn
                                  select s)
                                 .Include(c => c.MaSachNavigation)
                                 .ToList();
            List<Ctdondh> dsddh = (from s in obj.Ctdondhs
                                   where s.MaDonDh == pn.MaDonDh
                                   select s).ToList();

            int maPN = pn.MaPn;
            int maDonDh = (int)pn.MaDonDh;
            string tenNCC = pn.MaDonDhNavigation.MaNhaCcNavigation.TenNhaCc;
            string diaChiNCC = pn.MaDonDhNavigation.MaNhaCcNavigation.DiaChi;
            string soDT = pn.MaDonDhNavigation.MaNhaCcNavigation.DienThoai;
            DateTime nl = (DateTime)pn.NgayNhap;
            string ngayLap = nl.ToShortDateString();
            double TT = getTongTien;

            InPhieuNhapPreview inPhieuNhapPreview = new InPhieuNhapPreview(maPN, maDonDh, tenNCC, diaChiNCC, soDT, ngayLap, TT, dspn, dsddh);
            inPhieuNhapPreview.ShowDialog();
        }
    }
}

