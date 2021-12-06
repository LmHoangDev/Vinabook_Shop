using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BTL.Models;
namespace BTL
{
    public partial class BaoTriSach : Form
    {
        QLBanSachContext db = new QLBanSachContext();

        public BaoTriSach()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            var query = from c in db.Saches
                        select new {c.MaSach,c.TenSach,c.MaLoaiNavigation.TenLoai,c.DonGiaBan,c.DonGiaNhap,c.TacGia,c.NhaXuatBan};
            dsSach.Rows.Clear();
            var query3 = from c in db.Loaisaches
                         select new { c.TenLoai };
            foreach(var item in query3)
            {
                cbbTenLoaiSach.Items.Add(item.TenLoai);
            }
            foreach (var item in query)
            {
                dsSach.Rows.Add(item.MaSach, item.TenSach, item.TenLoai, item.DonGiaBan,item.DonGiaNhap, item.TacGia, item.NhaXuatBan);
               /* cbbTenLoaiSach.Items.Add(item.TenLoai);*/
            }
            
        }

        private void BaoTriSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {    if(cbbTenLoaiSach.SelectedIndex == -1)
                {
                    throw new Exception("Bạn phải chọn loại sách trước khi lọc");
                }
                 var query = from s in db.Saches
                                        where s.MaLoaiNavigation.TenLoai.Contains(cbbTenLoaiSach.SelectedItem.ToString())
                                        select new
                                        {
                                            map = s.MaSach,
                                            tensp = s.TenSach,
                                            tenl = s.MaLoaiNavigation.TenLoai,
                                            giab  =s.DonGiaBan,
                                            gian = s.DonGiaNhap,
                                            tg = s.TacGia,
                                            nxb = s.NhaXuatBan
                                        };
                            dsSach.Rows.Clear();
                            //Hiển thị lên datagrid view
                            foreach (var item in query)
                            {
                                dsSach.Rows.Add(item.map, item.tensp,item.tenl,item.giab,item.gian,item.tg,item.nxb);
                            }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Resert_Click(object sender, EventArgs e)
        {
            var query = from c in db.Saches
                        select new { c.MaSach, c.TenSach, c.MaLoaiNavigation.TenLoai, c.DonGiaBan, c.DonGiaNhap, c.TacGia, c.NhaXuatBan };
            dsSach.Rows.Clear();
            foreach (var item in query)
            {
                dsSach.Rows.Add(item.MaSach, item.TenSach, item.TenLoai, item.DonGiaBan,item.DonGiaNhap, item.TacGia, item.NhaXuatBan);
            }
            cbbTenLoaiSach.SelectedIndex = -1;
            
        }

        private void ChonDong(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index < 0) throw new Exception("Không có dòng được chọn!");
                DataGridViewRow dr = dsSach.Rows[index];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dsSach.CurrentCell.RowIndex;
                if (index < 0) throw new Exception("Bạn chưa chọn dòng để xóa!");
                DataGridViewRow row = dsSach.Rows[index];
                int maSachXoa = Convert.ToInt32(dsSach.Rows[index].Cells[0].Value.ToString());
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa sách này", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //lấy ra sản phẩm muốn xóa
                        Sach sachXoa = (from s in db.Saches
                                          where s.MaSach == maSachXoa
                                          select s).FirstOrDefault();
 
                        db.Saches.Remove(sachXoa); 
                        db.SaveChanges();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }

            catch (Exception e1)
            {

                MessageBox.Show(e1.Message);
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            ThemSach f = new ThemSach();
            f.ShowDialog();
            LoadData();
        }

        private void SuaClick(object sender, EventArgs e)
        {
            try
            {
                int index = dsSach.CurrentCell.RowIndex;
                if (index < 0) throw new Exception("Bạn chưa chọn dòng để sửa!");
                DataGridViewRow row = dsSach.Rows[index];
                int masach = Convert.ToInt32(dsSach.Rows[index].Cells[0].Value.ToString());
                var item = (from c in db.Saches
                            where c.MaSach == masach
                            select c).SingleOrDefault();
                Sach a = (Sach)item;
                SuaSach f = new SuaSach();
                f.Tag = a;
                f.ShowDialog();

            }

            catch (Exception e1)
            {

                MessageBox.Show(e1.Message);
            }
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
