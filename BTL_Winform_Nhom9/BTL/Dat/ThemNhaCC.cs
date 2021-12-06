using System;
using System.Windows.Forms;
using BTL.Models;

namespace BTL
{
    public partial class ThemNhaCC : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public ThemNhaCC()
        {
            InitializeComponent();
        }
        private void AddNhaCC()
        {
            if (txtTenNhaCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNhaCC.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return;
            }
            if (txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Focus();
                return;
            }
            else
            {
                try
                {
                    long sdt = long.Parse(txtSoDienThoai.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn nhập số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoDienThoai.SelectAll();
                    return;
                }
            }
            Nhacc ncc = new Nhacc();
            ncc.TenNhaCc = txtTenNhaCC.Text;
            ncc.DienThoai = txtSoDienThoai.Text;
            ncc.DiaChi = txtDiaChi.Text;
            db.Add(ncc);
            db.SaveChanges();
            XoaText();
        }
        private void XoaText()
        {
            txtTenNhaCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddNhaCC();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
