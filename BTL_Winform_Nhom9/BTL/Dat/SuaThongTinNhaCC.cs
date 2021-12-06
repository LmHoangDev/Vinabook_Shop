using System;
using System.Linq;
using System.Windows.Forms;
using BTL.Models;
namespace BTL
{
    public partial class SuaThongTinNhaCC : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public SuaThongTinNhaCC()
        {
            InitializeComponent();
        }

        private void SuaThongTinNhaCC_Load(object sender, EventArgs e)
        {
            HienThiThongTinNhaCc();
        }
        private void HienThiThongTinNhaCc()
        {
            var a = this.Tag;         
            var ncc = (Nhacc)a;
            txtManhaCC.Text = ncc.MaNhaCc.ToString();
            txtTenNhaCC.Text = ncc.TenNhaCc;
            txtDiaChi.Text = ncc.DiaChi;
            txtSoDienThoai.Text = ncc.DienThoai;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtTenNhaCC.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNhaCC.Focus();
                return;
            }
            if(txtDiaChi.Text=="")
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
            Nhacc ncc = db.Nhaccs.SingleOrDefault(ncc => ncc.MaNhaCc == int.Parse(txtManhaCC.Text));
            ncc.TenNhaCc = txtTenNhaCC.Text;
            ncc.DienThoai = txtSoDienThoai.Text;
            ncc.DiaChi = txtDiaChi.Text;
            db.SaveChanges();
            XoaText();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void XoaText()
        {
            txtTenNhaCC.Text = "";
            txtManhaCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }
    }
}
