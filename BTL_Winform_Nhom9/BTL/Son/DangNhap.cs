using BTL.Models;
using System;
using System.Linq;
using System.Windows.Forms;


namespace BTL
{
    public partial class DangNhap : Form
    {
        QLBanSachContext qLBanSachContext = new QLBanSachContext();
        public int MaTK { get; set; }
        public string MatKhau { get; set; }

        public string HoTen { get; set; }

        public string TenDN { get; set; }

        public bool isAdmin { get; set; }

        public DangNhap()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            txtMatKhau.PasswordChar = '*';
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            timer1.Start();
            txtTenDangNhap.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (isValidUser())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isValidUser()
        {
            if (Check())
            {
                var taikhoan = (from tk in qLBanSachContext.Taikhoans
                                where tk.TenDangNhap == txtTenDangNhap.Text && tk.MatKhau == txtMatKhau.Text
                                select tk).SingleOrDefault();

                if (taikhoan != null)
                {
                    MaTK = taikhoan.MaTk;
                    MatKhau = taikhoan.MatKhau;
                    HoTen = taikhoan.HoTen;
                    TenDN = taikhoan.TenDangNhap;
                    isAdmin = taikhoan.LoaiTk;
                    return true;
                }
            }

            return false;
        }

        private bool Check()
        {
            if (txtTenDangNhap.Text == String.Empty)
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return false;
            }


            if (txtMatKhau.Text == string.Empty)
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return false;
            }
            return true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            bool k = false;
            if (lbHTMK.Text == "Ẩn mật khẩu")
            {
                toggleMK.Image = Properties.Resources.icons8_toggle_on_30;
                lbHTMK.Text = "Hiện mật khẩu";
                k = true;
                txtMatKhau.PasswordChar = '\0';
            }
            if (!k)
            {
                toggleMK.Image = Properties.Resources.icons8_toggle_off_30;
                lbHTMK.Text = "Ẩn mật khẩu";
                txtMatKhau.PasswordChar = '*';
            }
        }
        private void ImageShowingDot()
        {
            if (pictureBox2.Visible == true)
                dot2.Image = Properties.Resources.icons8_filled_circle_24;
            else
                dot2.Image = Properties.Resources.icons8_circle_24;

            if (pictureBox3.Visible == true)
                dot3.Image = Properties.Resources.icons8_filled_circle_24;
            else
                dot3.Image = Properties.Resources.icons8_circle_24;

            if (pictureBox4.Visible == true)
                dot4.Image = Properties.Resources.icons8_filled_circle_24;
            else
                dot4.Image = Properties.Resources.icons8_circle_24;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox2.Visible = true;
            }

            //checking
            ImageShowingDot();
        }

        #region HoverSystemButton
        private void btnDong_MouseMove(object sender, MouseEventArgs e)
        {
            btnDong.BackColor = System.Drawing.Color.Red;
            btnDong.ForeColor = System.Drawing.Color.White;
        }

        private void btnDong_MouseLeave(object sender, EventArgs e)
        {
            btnDong.BackColor = System.Drawing.Color.White;
            btnDong.ForeColor = System.Drawing.Color.Black;
        }

        private void btnAn_MouseMove(object sender, MouseEventArgs e)
        {
            btnAn.BackColor = System.Drawing.Color.ForestGreen;
            btnAn.ForeColor = System.Drawing.Color.White;
        }

        private void btnAn_MouseLeave(object sender, EventArgs e)
        {
            btnAn.BackColor = System.Drawing.Color.White;
            btnAn.ForeColor = System.Drawing.Color.Black;
        } 
        #endregion

        private void btnDong_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region MoveFormBorderless

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void dot2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            ImageShowingDot();
        }

        private void dot3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            ImageShowingDot();
        }

        private void dot4_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            ImageShowingDot();
        }
    }
}
