using BTL.Models;
using BTL.Phuc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTL
{
    public partial class FormQuanLyDonHang : Form
    {
        QLBanSachContext obj = new QLBanSachContext();
        int index;
        int mapn;
        int madondh;
        public static bool isAdmin;
        public FormQuanLyDonHang()
        {
            InitializeComponent();
        }
        private void ShowDanhSach()
        {
            var query = from p in obj.Pnhaps
                        select new
                        {
                            p.MaPn,
                            p.MaDonDhNavigation.MaNhaCcNavigation.TenNhaCc,
                            p.NgayNhap,
                            p.MaDonDh
                        };
            dataGridView1.DataSource = query.ToList();
            dataGridView1.Columns[0].HeaderText = "Mã phiếu nhập";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Ngày nhập";
            dataGridView1.Columns[3].HeaderText = "Mã đơn đặt hàng";
        }

        private void ShowChiTiet()
        {
            dataGridView2.Rows.Clear();
            var query = from s in obj.Ctpnhaps
                        where s.MaPn == mapn
                        select s;
            List<Ctpnhap> list = query.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Sach s = obj.Saches.SingleOrDefault(s => s.MaSach == list[i].MaSach);
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                row.Cells[0].Value = s.TenSach;
                row.Cells[1].Value = list[i].SlNhap;
                row.Cells[2].Value = list[i].DgNhap;
                double tt = Convert.ToInt32(list[i].SlNhap) * Convert.ToDouble(list[i].DgNhap);
                row.Cells[3].Value = tt.ToString("N1");
                dataGridView2.Rows.Add(row);
            }
            string[] tien = (from DataGridViewRow r in dataGridView2.Rows
                             where r.Cells[3].FormattedValue.ToString() != string.Empty
                             select r.Cells[3].FormattedValue.ToString()).ToArray();
            double tong = 0;
            for (int i = 0; i < tien.Length; i++)
                tong += double.Parse(tien[i]);
            DataGridViewRow rw = (DataGridViewRow)dataGridView2.Rows[0].Clone();
            rw.Cells[2].Value = "Tổng tiền";
            rw.Cells[3].Value = tong.ToString("N1");
            dataGridView2.Rows.Add(rw);
        }

        private void GetDSDonDH()
        {
            var query = from s in obj.Dondhs
                        where s.TrangThai == "Chưa nhập" || s.TrangThai == "Nhập thiếu"
                        select new
                        {
                            s.MaDonDh,
                            s.NgayDh,
                            s.MaNhaCcNavigation.TenNhaCc,
                            s.TrangThai
                        };
            dgvDSDH.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region HoverButton
        private void btnSearch_MouseMove(object sender, MouseEventArgs e)
        {
            btnSearch.Image = Properties.Resources.icons8_google_web_search_48__1_;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.Image = Properties.Resources.icons8_google_web_search_48;
        }

        private void btnFilter_MouseMove(object sender, MouseEventArgs e)
        {
            btnFilter.Image = Properties.Resources.icons8_filter_48__1_;
        }

        private void btnFilter_MouseLeave(object sender, EventArgs e)
        {
            btnFilter.Image = Properties.Resources.icons8_filter_48;
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.Image = Properties.Resources.icons8_refresh_48__1_;
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.Image = Properties.Resources.icons8_refresh_48;
        }
        #endregion

        private void FormQuanLyDonHang_Load(object sender, EventArgs e)
        {
            isAdmin = (bool)this.Tag;
            ShowDanhSach();
            GetDSDonDH();
            dataGridView1.CurrentCell = null;
            dgvDSDH.CurrentCell = null;
            btnThem.Enabled = false;
            if (!isAdmin) btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormQuanLyDonHang_Them frmQLDH_Them = new FormQuanLyDonHang_Them();
            if (Application.OpenForms[frmQLDH_Them.Name] == null)
            {
                frmQLDH_Them.Tag = madondh;
                frmQLDH_Them.ShowDialog();
                ShowDanhSach();
                GetDSDonDH();
                btnThem.Enabled = false;
            }
            else
                Application.OpenForms[frmQLDH_Them.Name].Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Pnhap pn = obj.Pnhaps.SingleOrDefault(s => s.MaPn == mapn);
                    Dondh ddh = obj.Dondhs.SingleOrDefault(s => s.MaDonDh == pn.MaDonDh);
                    obj.Pnhaps.Remove(pn);
                    obj.SaveChanges();
                    List<Pnhap> tempList = (from s in obj.Pnhaps
                                            where s.MaDonDh == ddh.MaDonDh
                                            select s).ToList();
                    if (tempList.Count == 0)
                        ddh.TrangThai = "Chưa nhập";
                    obj.SaveChanges();
                    LoadingForm ld = new LoadingForm();
                    ld.ShowDialog();
                    ShowDanhSach();
                    GetDSDonDH();
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView1.CurrentCell = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Chưa chọn phiếu nhập hàng nào", "Lỗi");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                mapn = int.Parse(selectedRow.Cells[0].Value.ToString());
                ShowChiTiet();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                return;
            }
        }

        private void FormQuanLyDonHang_Activated(object sender, EventArgs e)
        {
            ShowDanhSach();
            GetDSDonDH();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Pnhap pn = obj.Pnhaps.SingleOrDefault(s => s.MaPn == int.Parse(txtTimPhieu.Text));
            if (pn != null)
            {
                int[] mp = (from DataGridViewRow row in dataGridView1.Rows
                            where row.Cells[0].FormattedValue.ToString() != string.Empty
                            select Convert.ToInt32(row.Cells[0].FormattedValue)).ToArray();
                for (int i = 0; i < mp.Length; i++)
                    if (pn.MaPn == mp[i])
                    {
                        mapn = mp[i];
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Cells[0].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        ShowChiTiet();
                        txtTimPhieu.Clear();
                    }
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã phiếu : " + txtTimPhieu.Text, "Thất bại");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime bd = dtpBD.Value;
            DateTime kt = dtpKT.Value;
            var query = from p in obj.Pnhaps
                        where bd.Date <= p.NgayNhap && p.NgayNhap <= kt.Date
                        select new
                        {
                            p.MaPn,
                            p.MaDonDhNavigation.MaNhaCcNavigation.TenNhaCc,
                            p.NgayNhap,
                            p.MaDonDh
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowDanhSach();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView1.CurrentCell = null;
        }

        private void dgvDSDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnThem.Enabled = true;
                DataGridViewRow selectedRow = dgvDSDH.Rows[e.RowIndex];
                madondh = int.Parse(selectedRow.Cells[0].Value.ToString());
            }
        }
    }
}
