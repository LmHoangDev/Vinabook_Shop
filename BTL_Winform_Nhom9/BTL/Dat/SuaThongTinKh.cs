using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.Models;

namespace BTL
{
    public partial class SuaThongTinKh : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public SuaThongTinKh()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtTenkh.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtTenkh.Focus();
                return;
            }    
            if(txtDiachi.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachi.Focus();
                return;
            }
            if(txtSodt.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSodt.Focus();
                return;
            }    
            else
            {
                try
                {
                    long sdt = long.Parse(txtSodt.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn nhập số điện thoại khách hàng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSodt.SelectAll();
                    return;
                }
            }
            Khachhang kh = db.Khachhangs.SingleOrDefault(kh => kh.MaKh == int.Parse(txtmaKh.Text));
            kh.TenKh = txtTenkh.Text;
            kh.DiaChi = txtDiachi.Text;
            kh.SoDt = txtSodt.Text;
            db.SaveChanges();
            MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaText();
        }

        private void SuaThongTinKh_Load(object sender, EventArgs e)
        {
            var query = this.Tag;
            Khachhang kh =(Khachhang) query;
            txtmaKh.Text = kh.MaKh.ToString();
            txtTenkh.Text = kh.TenKh;
            txtSodt.Text = kh.SoDt;
            txtDiachi.Text = kh.DiaChi;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void XoaText()
        {
            txtmaKh.Text = "";
            txtTenkh.Text = "";
            txtDiachi.Text = "";
            txtSodt.Text = "";
        }
    }
}
