using System;
using BTL.Models;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTL.Son
{
    public partial class frmBaoTriTK : Form
    {
        QLBanSachContext qLBanSachContext = new QLBanSachContext();

        int index;

        public frmBaoTriTK()
        {
            InitializeComponent();
            LoadTaiKhoan();
            dgvTaiKhoan.Columns[0].Visible = false;
            dgvTaiKhoan.RowHeadersVisible = false;
        }

        private void LoadTaiKhoan()
        {
            var tk = qLBanSachContext.Taikhoans
                .ToList();

            dgvTaiKhoan.Rows.Clear();
            foreach (var item in tk)
            {
                DataGridViewRow row = (DataGridViewRow)dgvTaiKhoan.Rows[0].Clone();
                row.Cells[0].Value = item.MaTk;
                row.Cells[1].Value = item.TenDangNhap;
                row.Cells[2].Value = item.HoTen;
                row.Cells[3].Value = (item.LoaiTk == true) ? "Admin" : "User";
                dgvTaiKhoan.Rows.Add(row);
            }
        }

        private bool isValid()
        {
            if (String.IsNullOrWhiteSpace(txtTenDN.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtMK.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                MessageBox.Show("Xác nhận mật khẩu không được để trống");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống");
                return false;
            }

            if(rbAdmin.Checked == false && rbUser.Checked == false)
            {
                MessageBox.Show("Chưa chọn loại tài khoản");
                return false;
            }

            return true;
        }

        private bool Check()
        {
            if(txtMK.Text.Equals(txtXacNhanMK.Text) == false)
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác");
                return false;
            }

            return true;
        }

        private void ThemTaiKhoan()
        {
            try
            {
                Taikhoan x = new Taikhoan();
                x.TenDangNhap = txtTenDN.Text;
                x.MatKhau = txtMK.Text;
                x.HoTen = txtHoTen.Text;
                x.LoaiTk = (rbAdmin.Checked == true) ? true : false;

                qLBanSachContext.Taikhoans.Add(x);
                qLBanSachContext.SaveChanges();
                MessageBox.Show("Thêm thành công");
                LoadTaiKhoan();
                ClearTextBox();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void XoaTaiKhoan()
        {
            int matk = int.Parse(dgvTaiKhoan.Rows[index].Cells[0].Value.ToString());
            string hoTen = dgvTaiKhoan.Rows[index].Cells[2].Value.ToString();

            var tkXoa = qLBanSachContext.Taikhoans
                .Where(s => s.MaTk == matk)
                .SingleOrDefault();

            DialogResult dg =
                MessageBox.Show("Ban có muốn xóa tài khoản của " + hoTen, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dg == DialogResult.Yes)
            {
                qLBanSachContext.Taikhoans.Remove(tkXoa);
                qLBanSachContext.SaveChanges();
                LoadTaiKhoan();
            }
        }

        private void ClearTextBox()
        {
            txtHoTen.Clear();
            txtMK.Clear();
            txtXacNhanMK.Clear();
            txtTenDN.Clear();
            txtTenDN.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (isValid())
            {
                if (Check())
                    ThemTaiKhoan();
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            int colum = e.ColumnIndex;
            try
            {
                if (index < 0 || index > dgvTaiKhoan.RowCount - 1)
                    throw new Exception("Dòng bạn chọn không tồn tại");
                if (index == dgvTaiKhoan.RowCount - 1)
                    throw new Exception("Dòng bạn chọn không có dữ liệu");

                if (colum == 4)
                {
                    XoaTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
