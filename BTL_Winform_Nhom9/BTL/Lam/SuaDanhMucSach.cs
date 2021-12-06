using System;
using System.Windows.Forms;
using BTL.Models;
namespace BTL
{
    public partial class SuaDanhMucSach : Form
    {

        QLBanSachContext db = new QLBanSachContext();
        public SuaDanhMucSach()
        {
            InitializeComponent();
        }

        private void LoadForm_SuaDM(object sender, EventArgs e)
        {
            Loaisach a = (Loaisach)this.Tag;
            txbMaLoaiSach.Text = a.MaLoai.ToString();
            txbTenLoaiSach.Text = a.TenLoai;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maloai = Convert.ToInt32(txbMaLoaiSach.Text);
            try
            {
                var sach = db.Loaisaches.Find(maloai);
                if (ValidateData())
                {
                    sach.TenLoai = txbTenLoaiSach.Text;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
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

        private void Validate_Data(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbTenLoaiSach, "");
        }
        private bool ValidateData()
        {
            if (txbTenLoaiSach.Text == "")
            {
                errorProvider1.SetError(txbTenLoaiSach, "Bạn không được để trống tên loại sách");
                return false;
            }
            return true;
        }
    }
}
