using System;
using System.Windows.Forms;
using BTL.Models;
namespace BTL
{
    public partial class ThemDanhMucSach : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public ThemDanhMucSach()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validata())
                {
                    Loaisach spMoi = new Loaisach();
                    foreach (var item in db.Loaisaches)
                    {
                        if (item.TenLoai == txbTenLoaiSach.Text)
                            throw new Exception("Lỗi tên loại sách trùng !");
                    }
                    spMoi.TenLoai = txbTenLoaiSach.Text;
                    db.Loaisaches.Add(spMoi);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn đóng form?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void themValidated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbTenLoaiSach, "");
        }
        private bool Validata()
        {
            if (txbTenLoaiSach.Text == "")
            {
                errorProvider1.SetError(txbTenLoaiSach, "Bạn phải nhập tên loại sách trước khi thêm");
                return false;
            }
            return true;
        }

        private void txbTenLoaiSach_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
