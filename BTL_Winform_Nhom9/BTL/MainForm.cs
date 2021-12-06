using System;
using BTL.Son;
using BTL.Lam;
using System.Windows.Forms;

namespace BTL
{
    public partial class MainForm : Form
    {
        private Form activeForm = null;

        private int maTK;
        private string tenDN;
        private string matKhau;
        private string hoTen;
        private bool isAdmin;
        public static string ten;
        public static DialogResult dr = DialogResult.No;
        public MainForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        public MainForm(int maTK, string tenDN, string matKhau, string hoTen, bool admin)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            this.maTK = maTK;
            this.tenDN = tenDN;
            this.matKhau = matKhau;
            this.hoTen = hoTen;
            ten = hoTen;
            isAdmin = admin;
            CustomizeDesign();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new FormTrangChu(), null);
            lblTitle.Text = "Trang chủ";
        }

        #region Ẩn hiện thị subpanel
        private void CustomizeDesign()
        {
            if (isAdmin == true)
            {
                panelQLTaiKhoan.Visible = false;
                panelDHNhapXuat.Visible = false;
                panelSach.Visible = false;
                panelQLHoaDon.Visible = false;
                btnQLTK.Visible = false;
            }
            else
            {
                panelQLTaiKhoan.Visible = false;
                panelDHNhapXuat.Visible = false;
                panelSach.Visible = false;
                panelQLHoaDon.Visible = false;
                btnBaoTriTK.Visible = false;
                btnDHNhapXuat.Visible = true;
                btnQLDonDatHang.Visible = false;
                btnQLNhaCungCap.Visible = false;
                btnSach.Visible = false;
            }
        }

        private void HideSubMenu()
        {
            if (panelQLTaiKhoan.Visible == true)
                panelQLTaiKhoan.Visible = false;
            if (panelDHNhapXuat.Visible == true)
                panelDHNhapXuat.Visible = false;
            if (panelSach.Visible == true)
                panelSach.Visible = false;
            if (panelQLHoaDon.Visible == true)
                panelQLHoaDon.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #endregion

        #region Quản lý tài khoản
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelQLTaiKhoan);
        }

        private void btnBaoTriTK_Click(object sender, EventArgs e)
        {
            // Hiển thị form bảo trì tài khoản
            HideSubMenu();
            OpenChildForm(new frmBaoTriTK(), sender);
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            // Hiển thị form quản lý tài khoản
            HideSubMenu();
            OpenChildForm(new frmDoiMatKhau(maTK, hoTen, tenDN, matKhau), sender);
        }
        #endregion

        #region Quản lý hóa đơn 
        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            // Hiển thị form quản lý hóa đơn
            ShowSubMenu(panelQLHoaDon);
        }
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLapHoaDon(maTK), sender);
            HideSubMenu();
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmXemHoaDon(maTK), sender);
            HideSubMenu();
        }
        #endregion

        #region Quản lý nhập xuất đơn đặt hàng
        private void btnDHNhapXuat_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelDHNhapXuat);
        }

        private void btnQLDonDatHang_Click(object sender, EventArgs e)
        {
            // Hiển thị form quản lý đơn đặt hàng
            HideSubMenu();
            OpenChildForm(new QLDonDatHang(), sender);
        }

        private void btnQLDonNhapHang_Click(object sender, EventArgs e)
        {
            // Hiển thị form quản lý đơn nhập hàng
            FormQuanLyDonHang frmQLDNH = new FormQuanLyDonHang();
            frmQLDNH.Tag = isAdmin;
            OpenChildForm(frmQLDNH, sender);
            HideSubMenu();
        }

        private void btnQLNhaCungCap_Click(object sender, EventArgs e)
        {
            // Hiển thị form quản lý nhà cung cấp
            OpenChildForm(new QuanLyNhaCC(), sender);
            HideSubMenu();
        }
        #endregion

        #region Quản lý sách
        private void btnSach_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSach);
        }

        private void btnBaoTriSach_Click(object sender, EventArgs e)
        {
            // Hiển thị form bảo trì sách
            HideSubMenu();
            OpenChildForm(new BaoTriSach(), sender);
        }

        private void btnBaoTriDMSach_Click(object sender, EventArgs e)
        {
            // Hiển thị form bải trì danh mục sách
            HideSubMenu();
            OpenChildForm(new BaoTriDanhMucSach(), sender);
        }
        #endregion

        #region Quản lý thông tin khách hàng
        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            // Hiển thị form quản lý thông tin khách hàng
            OpenChildForm(new FormQuanLyThongTinKH(), sender);
            HideSubMenu();
        }
        #endregion

        #region Thống kê báo cáo
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Hiển thị form thống kê báo cáo
            HideSubMenu();
            OpenChildForm(new ThongKeQuy(), sender);

        }
        #endregion

        #region Hiển thị child form

        // Chỉ mở được một form trên panel
        // Gọi hàm này khi nhấn các button mở form ở panel, tham số là form muốn mở
        private void OpenChildForm(Form childForm, object sender)
        {
            // Đóng form đang mở
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
            if (sender == "trangchu")
                lblTitle.Text = "Trang chủ";
            else if (sender != null)
                lblTitle.Text = (sender as Button).Text;
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogCustomForMainForm dcfm = new DialogCustomForMainForm();
            dcfm.ShowDialog();
            if(dr == DialogResult.Yes)
            {
                DangNhap.ActiveForm.Dispose();
                Application.Restart();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTrangChu(), "trangchu");
        }
    }
}
