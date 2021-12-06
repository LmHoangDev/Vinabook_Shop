using System;
using System.Windows.Forms;
using BTL.Models;
namespace BTL
{
    public partial class SuaSach : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public SuaSach()
        {
            InitializeComponent();
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn đóng form?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LoadForm_Sua(object sender, EventArgs e)
        {
            cbbTenLoai.Items.Clear();
            //Hiển thị lên Combobox
            foreach (var item in db.Loaisaches)
            {
                cbbTenLoai.Items.Add(item.TenLoai);
            }


            Sach a = (Sach)this.Tag;
            txbMaSach.Text = a.MaSach.ToString();
            txbTenSach.Text = a.TenSach;
            foreach (var item in db.Loaisaches)
            {
                if (item.MaLoai == a.MaLoai)
                {
                    cbbTenLoai.SelectedItem = item.TenLoai;
                    break;
                }
            }
            txbGia.Text = a.DonGiaBan.ToString();
            txtGiaNhap.Text = a.DonGiaNhap.ToString();
            txbNXB.Text = a.NhaXuatBan;
            txbTacGia.Text = a.TacGia;

        }

        private void Update_click(object sender, EventArgs e)
        {
            int masach = Convert.ToInt32(txbMaSach.Text);
            try
            {
                var sach = db.Saches.Find(masach);
                if (ValidateData())
                {
                    sach.TenSach = txbTenSach.Text;
                    string tenloai = cbbTenLoai.Text;
                    foreach (var item in db.Loaisaches)
                    {
                        if (item.TenLoai == tenloai)
                        {
                            sach.MaLoai = item.MaLoai;
                            break;
                        }
                    }
                    decimal value;
                    if (!decimal.TryParse(txbGia.Text, out value))
                    {
                        throw new Exception("Lỗi nhập giá bán không phải là số");
                    }
                    decimal value1;
                    if (!decimal.TryParse(txtGiaNhap.Text, out value1))
                    {
                        throw new Exception("Lỗi nhập giá nhập không phải là số");
                    }
                    sach.TacGia = txbTacGia.Text;
                    sach.DonGiaBan = Convert.ToDecimal(txbGia.Text);
                    sach.DonGiaNhap = Convert.ToDecimal(txtGiaNhap.Text);
                    sach.NhaXuatBan = txbNXB.Text;
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

        private void tenSach(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbTenSach, "");
        }

        private void gia(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbGia, "");
        }

        private void tacGia(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbTacGia, "");
        }

        private void nxb(object sender, EventArgs e)
        {
            errorProvider1.SetError(txbNXB, "");
        }
        public bool ValidateData()
        {
            if (txbTenSach.Text == "")
            {
                errorProvider1.SetError(txbTenSach, "Bạn phải nhập tên sách trước khi sửa");
                return false;
            }
            if (cbbTenLoai.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbbTenLoai, "Bạn phải chọn tên loại sách trước khi sửa");
                return false;
            }
            if (txbGia.Text == "")
            {
                errorProvider1.SetError(txbGia, "Bạn phải nhập giá bán trước khi sửa");
                return false;
            }
            if (txtGiaNhap.Text == "")
            {
                errorProvider1.SetError(txbGia, "Bạn phải nhập giá nhập trước khi sửa");
                return false;
            }
            if (txbTacGia.Text == "")
            {
                errorProvider1.SetError(txbTacGia, "Bạn phải tên tác giả trước khi sửa");
                return false;
            }
            if (txbNXB.Text == "")
            {
                errorProvider1.SetError(txbNXB, "Bạn phải tên nhà xuất bản trước khi sửa");
                return false;
            }
            return true;
        }
    }
}
