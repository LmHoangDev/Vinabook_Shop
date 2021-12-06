using System;
using BTL.Models;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BTL.Son
{
    public partial class frmDoiMatKhau : Form
    {
        int maTk;
        string mkCu;

        QLBanSachContext qLBanSachContext = new QLBanSachContext();

        public frmDoiMatKhau(int maTk,string hoTen, string tenDN, string mkCu)
        {
            this.maTk = maTk;
            this.mkCu = mkCu;
            InitializeComponent();

            HideGroupBox();
            HienThiThongTin(hoTen, tenDN);
        }

        private void HideGroupBox()
        {
            gbxDoiMK.Visible = false;

            if (btnDoiMK.Visible == false)
                btnDoiMK.Visible = true;
        }

        private void DisplayGroupBox()
        {
            if (gbxDoiMK.Visible == false)
                gbxDoiMK.Visible = true;
            if (btnDoiMK.Visible == true)
                btnDoiMK.Visible = false;
        }
        
        private void HienThiThongTin(string hoTen, string tenDN)
        {
            lblHoTen.Text = hoTen;
            lblTenDN.Text = tenDN;
        }

        private bool isValid()
        {
            if (String.IsNullOrWhiteSpace(txtMKCu.Text))
            {
                MessageBox.Show("Mật khẩu cũ không được để trống");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtMKMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới không được để trống");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtXacNhanMKM.Text))
            {
                MessageBox.Show("Xác nhận mật khẩu mới không được để trống");
                return false;
            }

            return true;
        }

        private bool Check()
        {
            if(mkCu.Equals(txtMKCu.Text) == false)
            {
                MessageBox.Show("Mật khẩu cũ không khớp");
                return false;
            }

            if (mkCu.Equals(txtMKMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ");
                return false;
            }

            if(txtMKMoi.Text.Equals(txtXacNhanMKM.Text) == false)
            {
                MessageBox.Show("Xác nhận mật khẩu mới không khớp");
                return false;
            }

            return true;
        }

        private void DoiMatKhau()
        {
            try
            {
                var tk = qLBanSachContext.Taikhoans
                    .Where(s => s.MaTk == maTk)
                    .SingleOrDefault();
                tk.MatKhau = txtMKMoi.Text;

                qLBanSachContext.SaveChanges();

                MessageBox.Show("Đổi mật khẩu thành công");
                HideGroupBox();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            DisplayGroupBox();
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                if (Check())
                    DoiMatKhau();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
