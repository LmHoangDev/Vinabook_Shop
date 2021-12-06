using System;
using System.Windows.Forms;
using BTL.Models;
namespace BTL
{
    public partial class ThemSach : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public ThemSach()
        {
            InitializeComponent();
        }

        private void ThemSach_Load(object sender, EventArgs e)
        {
            cbbTenLoai.Items.Clear();
            //Hiển thị lên Combobox
            foreach (var item in db.Loaisaches)
            {
                cbbTenLoai.Items.Add(item.TenLoai);
            }
        }
        private void txbTenSach_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbTenLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTacGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    Sach spMoi = new Sach();
                    foreach (var item in db.Saches)
                    {
                        if (item.TenSach == txbTenSach.Text)
                        {
                            throw new Exception("Lỗi tên sách bị trùng !");

                        }
                    }
                    decimal value;
                    if (!decimal.TryParse(txbGia.Text, out value))
                    {
                        throw new Exception("Lỗi nhập giá không phải là số");
                    }


                    spMoi.TenSach = txbTenSach.Text;
                    int index = cbbTenLoai.SelectedIndex;
                    spMoi.TacGia = txbTacGia.Text;
                    spMoi.NhaXuatBan = txbTacGia.Text;
                    spMoi.DonGiaBan = Convert.ToDecimal(txbGia.Text);
                    spMoi.DonGiaNhap = Convert.ToDecimal(txbGiaNhap.Text);
                    foreach (var item in db.Loaisaches)
                    {
                        if (item.TenLoai == cbbTenLoai.SelectedItem.ToString())
                        {
                            spMoi.MaLoai = item.MaLoai;
                            break;
                        }
                    }

                    db.Saches.Add(spMoi);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txbTenSach.Focus();
            }
        }

        private void tenSach(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbTenSach, "");
        }

        private void giaSach(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbGia, "");
        }

        private void giaTacGia(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbTacGia, "");
        }

        private void nxb(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbNXB, "");
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn đóng form?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool ValidateData()
        {
            if (txbTenSach.Text == "")
            {
                errorProvider1.SetError(txbTenSach, "Bạn phải nhập tên sách trước khi thêm");
                return false;
            }
            if (cbbTenLoai.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbbTenLoai, "Bạn phải chọn tên loại sách trước khi thêm");
                return false;
            }
            if (txbGia.Text == "")
            {
                errorProvider1.SetError(txbGia, "Bạn phải nhập giá bán trước khi thêm");
                return false;
            }
            if (txbGiaNhap.Text == "")
            {
                errorProvider1.SetError(txbGia, "Bạn phải nhập giá nhập trước khi thêm");
                return false;
            }
            if (txbTacGia.Text == "")
            {
                errorProvider1.SetError(txbTacGia, "Bạn phải tên tác giả trước khi thêm");
                return false;
            }
            if (txbNXB.Text == "")
            {
                errorProvider1.SetError(txbNXB, "Bạn phải tên nhà xuất bản trước khi thêm");
                return false;
            }
            return true;
        }

        private void tenLoai(object sender, EventArgs e)
        {

        }
        public void XoaTrang()
        {
            txbGia.Clear();
            txbGiaNhap.Clear();
            txbNXB.Clear();
            txbTacGia.Clear();
            cbbTenLoai.SelectedIndex = -1;
            txbTenSach.Clear();

        }

        private void XoaTrang(object sender, EventArgs e)
        {
            XoaTrang();
        }
    }
}
