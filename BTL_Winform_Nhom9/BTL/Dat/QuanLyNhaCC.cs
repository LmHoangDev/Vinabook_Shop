using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BTL.Models;

namespace BTL
{
    public partial class QuanLyNhaCC : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public QuanLyNhaCC()
        {
            InitializeComponent();
        }

        private void QuanLyNhaCC_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhaCungCap();
        }
        private void HienThiDanhSachNhaCungCap()
        {
            var query = from n in db.Nhaccs
                        select new
                        {
                            n.MaNhaCc,
                            n.TenNhaCc,
                            n.DiaChi,
                            n.DienThoai,
                            n.Dondhs.Count,
                        };
            var nhacc = query.ToList();
            dvgDanhSachNhaCungCap.DataSource = nhacc;
            dvgDanhSachNhaCungCap.Columns[0].HeaderText = "Mã";
            dvgDanhSachNhaCungCap.Columns[1].HeaderText = "Tên";
            dvgDanhSachNhaCungCap.Columns[2].HeaderText = "Địa chị";
            dvgDanhSachNhaCungCap.Columns[3].HeaderText = "Số điện thoại";
            dvgDanhSachNhaCungCap.Columns[4].HeaderText = "Số đơn đặt";
        }
        private void HienThiChiTietNhaCungCap()
        {
            if(index==-1)
            {
                MessageBox.Show("Bạn chưa chọn dòng chứa nhà cung cấp", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  
            else
            {
                txtManhaCC.Text = dvgDanhSachNhaCungCap.Rows[index].Cells[0].Value.ToString();
                txtTenNhaCC.Text= dvgDanhSachNhaCungCap.Rows[index].Cells[1].Value.ToString();
                txtDiaChi.Text= dvgDanhSachNhaCungCap.Rows[index].Cells[2].Value.ToString();
                txtSoDienThoai.Text= dvgDanhSachNhaCungCap.Rows[index].Cells[3].Value.ToString();
                txtSodondat.Text= dvgDanhSachNhaCungCap.Rows[index].Cells[4].Value.ToString();
                var query = from ct in db.Dondhs
                            where ct.MaNhaCc == int.Parse(dvgDanhSachNhaCungCap.Rows[index].Cells[0].Value.ToString())
                            select new
                            {
                                ct.MaDonDh,
                                ct.NgayDh,                              
                            };
                dvgDanhsachchitietdondh.DataSource = query.ToList();
                dvgDanhsachchitietdondh.Columns[0].HeaderText = "Mã đơn đặt";
                dvgDanhsachchitietdondh.Columns[1].HeaderText = "Ngày đặt";
            }    
            
        }
        static int index=-1;
        private void dvgDanhSachNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void tnXemThongtin_Click(object sender, EventArgs e)
        {
            HienThiChiTietNhaCungCap();
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if(index==-1)
            {
                MessageBox.Show("Bạn chưa chọn dòng chứa nhà cung cấp", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            else
            {
                int ma=int.Parse(dvgDanhSachNhaCungCap.Rows[index].Cells[0].Value.ToString());
                SuaThongTinNhaCC myform = new SuaThongTinNhaCC();
                Nhacc ncc = db.Nhaccs.SingleOrDefault(ncc => ncc.MaNhaCc == ma);
                myform.Tag = ncc;
                myform.Show();
            }    
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Tim();
        }
        private void Tim()
        {
            if(txtManhaccTim.Text=="")
            {
                MessageBox.Show("Bận chưa nhập mã nhà cung cấp cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManhaccTim.Focus();
                return;
            }
            else
            {
                try
                {
                    int ma = int.Parse(txtManhaccTim.Text);
                }
                catch
                {
                    MessageBox.Show("Bận nhập mã nhà cung cấp không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtManhaccTim.SelectAll();
                    return;
                }
            }
            Nhacc ncc = db.Nhaccs.SingleOrDefault(ncc => ncc.MaNhaCc == int.Parse(txtManhaccTim.Text));
            if(ncc!=null)
            {
                var query = from n in db.Nhaccs
                            where n.MaNhaCc==ncc.MaNhaCc
                            select new
                            {
                                n.MaNhaCc,
                                n.TenNhaCc,
                                n.DiaChi,
                                n.DienThoai,
                                n.Dondhs.Count,
                            };
                var nhacc = query.ToList();
                dvgDanhSachNhaCungCap.DataSource = nhacc;
                dvgDanhSachNhaCungCap.Columns[0].HeaderText = "Mã";
                dvgDanhSachNhaCungCap.Columns[1].HeaderText = "Tên";
                dvgDanhSachNhaCungCap.Columns[2].HeaderText = "Địa chị";
                dvgDanhSachNhaCungCap.Columns[3].HeaderText = "Số điện thoại";
                dvgDanhSachNhaCungCap.Columns[4].HeaderText = "Số đơn đặt";

            }
            else
            {
                MessageBox.Show("Mà nhà cung cấp không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Loc();
        }
        private void Loc()
        {
            if (txtSolandatmin.Text == "")
            {
                MessageBox.Show("Bận chưa nhập số lượng đơn đặt min", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSolandatmin.Focus();
                return;

            }
            else
            {
                try
                {
                    int min = int.Parse(txtSolandatmin.Text);
                }
                catch
                {
                    MessageBox.Show("Bận nhập số lượng đơn đặt min không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtSolandatmax.Text == "")
            {
                MessageBox.Show("Bận chưa nhập số lượng đơn đặt max", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSolandatmax.Focus();
                return;
            }
            else
            {
                try
                {
                    int max = int.Parse(txtSolandatmax.Text);
                }
                catch
                {
                    MessageBox.Show("Bận nhập số lượng đơn đặt max không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            var query = from n in db.Nhaccs
                        where n.Dondhs.Count>=int.Parse(txtSolandatmin.Text)&&n.Dondhs.Count<=int.Parse(txtSolandatmax.Text)
                        select new
                        {
                            n.MaNhaCc,
                            n.TenNhaCc,
                            n.DiaChi,
                            n.DienThoai,
                            n.Dondhs.Count,
                        };
            var nhacc = query.ToList();
            dvgDanhSachNhaCungCap.DataSource = nhacc;
            dvgDanhSachNhaCungCap.Columns[0].HeaderText = "Mã";
            dvgDanhSachNhaCungCap.Columns[1].HeaderText = "Tên";
            dvgDanhSachNhaCungCap.Columns[2].HeaderText = "Địa chị";
            dvgDanhSachNhaCungCap.Columns[3].HeaderText = "Số điện thoại";
            dvgDanhSachNhaCungCap.Columns[4].HeaderText = "Số đơn đặt";

        }

        private void btnboloc_Click(object sender, EventArgs e)
        {
            BoLoc();
        }
        private void BoLoc()
        {
            HienThiDanhSachNhaCungCap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemNhaCC myform = new ThemNhaCC();
            myform.Show();

        }
    }
}
