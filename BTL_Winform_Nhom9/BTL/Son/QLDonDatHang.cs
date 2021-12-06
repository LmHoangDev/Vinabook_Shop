using BTL.Models;
using BTL.Son;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BTL
{
    public partial class QLDonDatHang : Form
    {
        private readonly string[] trangThai = new string[4] { "Chưa nhập", "Nhập đủ", "Nhập thiếu", "Đã hủy" };

        QLBanSachContext qLBanSachContext = new QLBanSachContext();
        List<Dondh> dsDondh = new List<Dondh>();
        List<Ctdondh> ctdondhs = new List<Ctdondh>();

        private int maDonDh;
        private string tenNCC;
        private string diaChiNCC;
        private string soDT;
        private string ngayLap;
        private decimal tongTien = 0;

        private int index;

        private bool isSearchWithDate = false;

        private string[] trangThaiLoc = new string[4];

        public QLDonDatHang()
        {
            InitializeComponent();
            dgvThongTinSach.RowHeadersVisible = false;
            dgvDSDonDH.RowHeadersVisible = false;
        }

        private void QLDonDatHang_Load(object sender, EventArgs e)
        {
            LoadDonDatHang(GetDonDatHang());
        }

        public List<Dondh> GetDonDatHang()
        {
            var ddh = qLBanSachContext.Dondhs
                .Include("MaNhaCcNavigation");
            return ddh.ToList();
        }

        public void LoadDonDatHang(List<Dondh> dondhs)
        {
            dsDondh = dondhs;

            dgvDSDonDH.Rows.Clear();
            foreach (var item in dsDondh)
            {
                DataGridViewRow row = (DataGridViewRow)dgvDSDonDH.Rows[0].Clone();
                row.Cells[0].Value = item.MaDonDh;
                DateTime time = (DateTime)item.NgayDh;
                row.Cells[1].Value = time.ToShortDateString();
                row.Cells[2].Value = item.MaNhaCcNavigation.TenNhaCc;
                row.Cells[3].Value = item.TrangThai;
                dgvDSDonDH.Rows.Add(row);
            }          
        }

        private List<Ctdondh> GetChiTietDonHang(int maDonDh)
        {
            var ddh = qLBanSachContext.Ctdondhs
                .Where(s => s.MaDonDh == maDonDh)
                .Include("MaSachNavigation")
                .ToList();

            return ddh;
        }

        private void HienThiChiTietDDH(int maDonDh)
        {
            ctdondhs = GetChiTietDonHang(maDonDh);
            tongTien = 0;
            dgvThongTinSach.Rows.Clear();

            foreach (var item in ctdondhs)
            {
                DataGridViewRow row = (DataGridViewRow)dgvThongTinSach.Rows[0].Clone();
                row.Cells[0].Value = item.MaSach;
                row.Cells[1].Value = item.MaSachNavigation.TenSach;
                row.Cells[2].Value = item.SlDat;
                row.Cells[3].Value = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", item.MaSachNavigation.DonGiaNhap);
                row.Cells[4].Value = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", item.ThanhTien);
                tongTien += item.ThanhTien;

                dgvThongTinSach.Rows.Add(row);
            }

            lblTongTien.Text = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", tongTien);
        }

        #region Lọc đơn đặt hàng
        private List<Dondh> LocDonDatHang()
        {
            DateTime dayFrom = dtpFrom.Value;
            DateTime dayTo = dtpTo.Value;

            if (isSearchWithDate == true)
            {
                if (IsSearchWithStatus() == true)
                {
                    SetListTrangThaiLoc();

                    var ddh = qLBanSachContext.Dondhs
                        .Where(s => s.NgayDh >= dayFrom && s.NgayDh <= dayTo &&
                        (s.TrangThai == trangThaiLoc[0] || s.TrangThai == trangThaiLoc[1] || s.TrangThai == trangThaiLoc[2] || s.TrangThai == trangThaiLoc[3]))
                        .ToList();
                    return ddh;
                }
                else
                {
                    var ddh = qLBanSachContext.Dondhs
                        .Where(s => s.NgayDh >= dayFrom && s.NgayDh <= dayTo)
                        .ToList();
                    return ddh;
                }

            }
            else
            {
                if (IsSearchWithStatus() == true)
                {
                    SetListTrangThaiLoc();

                    var ddh = qLBanSachContext.Dondhs
                       .Where(s => s.TrangThai == trangThaiLoc[0] || s.TrangThai == trangThaiLoc[1] || s.TrangThai == trangThaiLoc[2] || s.TrangThai == trangThaiLoc[3])
                       .ToList();
                    return ddh;
                }
                else
                    return GetDonDatHang();               
            }
        }

        private void SetListTrangThaiLoc()
        {
            trangThaiLoc[0] = cbxChuaNhap.Checked == true ? trangThai[0] : "";
            trangThaiLoc[1] = cbxNhapDu.Checked == true ? trangThai[1] : "";
            trangThaiLoc[2] = cbxChuaNhapDu.Checked == true ? trangThai[2] : "";
            trangThaiLoc[3] = cbxDaHuy.Checked == true ? trangThai[3] : "";
        }

        private bool IsSearchWithStatus()
        {
            if (cbxChuaNhap.Checked == true)
                return true;
            if (cbxNhapDu.Checked == true)
                return true;
            if (cbxChuaNhapDu.Checked == true)
                return true;
            if (cbxDaHuy.Checked == true)
                return true;

            return false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            isSearchWithDate = true;
            LoadDonDatHang(LocDonDatHang());
        }

        private void btnHuyLoc_Click(object sender, EventArgs e)
        {
            isSearchWithDate = false;
            LoadDonDatHang(GetDonDatHang());
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            LoadDonDatHang(LocDonDatHang());
        }

        #endregion
        private void ThemDonDatHang()
        {
            ThemDonDatHang themDonDatHang = new ThemDonDatHang(this);
            themDonDatHang.ShowDialog();
        }

        private void HuyDonDH()
        {
            int maDDH = int.Parse(dgvDSDonDH.Rows[index].Cells[0].Value.ToString());

            var xoa = qLBanSachContext.Dondhs
                .Where(s => s.MaDonDh == maDDH)
                .SingleOrDefault();

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn hủy đơn đặt hàng", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                xoa.TrangThai = "Đã hủy";
                qLBanSachContext.SaveChanges();
            }

            LoadDonDatHang(GetDonDatHang());
            dgvThongTinSach.Rows.Clear();
        }

        private void dgvDSDonDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {
                if (index < 0)
                    throw new Exception("Dòng bạn chọn không tồn tại");
                if(index == dgvDSDonDH.RowCount - 1)
                    throw new Exception("Dòng bạn chọn không có dữ liệu");

                maDonDh = int.Parse(dgvDSDonDH.Rows[index].Cells[0].Value.ToString());
                HienThiChiTietDDH(maDonDh);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemDonDatHang();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HuyDonDH();
        }
        //in đơn đặt hàng
        private void button3_Click(object sender, EventArgs e)
        {
            if (index < 0 || index > dgvDSDonDH.RowCount - 2)
            {
                MessageBox.Show("Chưa chọn đơn đặt hàng");
                return;
            }
                
            var ddh = qLBanSachContext.Dondhs
                .Include("MaNhaCcNavigation")
                .Where(s => s.MaDonDh == maDonDh)
                .SingleOrDefault();

            tenNCC = ddh.MaNhaCcNavigation.TenNhaCc;
            diaChiNCC = ddh.MaNhaCcNavigation.DiaChi;
            soDT = ddh.MaNhaCcNavigation.DienThoai;
            DateTime nl = (DateTime)ddh.NgayDh;
            ngayLap = nl.ToShortDateString();
            string TT = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", tongTien);

            InDonDatHang inDonDatHang = new InDonDatHang(maDonDh, tenNCC, diaChiNCC, soDT, ngayLap, TT, ctdondhs);
            inDonDatHang.ShowDialog();
        }
    }
}
