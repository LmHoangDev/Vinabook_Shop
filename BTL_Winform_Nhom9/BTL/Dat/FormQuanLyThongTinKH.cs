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
    public partial class FormQuanLyThongTinKH : Form
    {
        QLBanSachContext db = new QLBanSachContext();
        public FormQuanLyThongTinKH()
        {
            InitializeComponent();
        }

        private void FormQuanLyThongTinKH_Load(object sender, EventArgs e)
        {
            HienThiDanhSachKhachHang();
        }
        private void HienThiDanhSachKhachHang()
        {
            var query = from kh in db.Khachhangs
                        select new
                        {
                            kh.MaKh,
                            kh.TenKh,
                            kh.DiaChi,
                            kh.SoDt,
                            kh.Hoadons.Count,
                        };
            dvgDanhsachKH.DataSource = query.ToList();
            dvgDanhsachKH.Columns[0].HeaderText ="Mã khách hàng";
            dvgDanhsachKH.Columns[1].HeaderText = "Tên khách hàng";
            dvgDanhsachKH.Columns[2].HeaderText = "Địa chỉ";
            dvgDanhsachKH.Columns[3].HeaderText = "Số điện thoại";
            dvgDanhsachKH.Columns[4].HeaderText = "Số lần mua";
        }
        int index = -1;
        private void HienThiChiTietKhachHang()
        {
            if(index==-1)
            {
                MessageBox.Show("Bạn chưa chọn thông tin khách hàng", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                int ma = int.Parse(dvgDanhsachKH.Rows[index].Cells[0].Value.ToString());
                txtMakh.Text = dvgDanhsachKH.Rows[index].Cells[0].Value.ToString();
                txtTenkh.Text = dvgDanhsachKH.Rows[index].Cells[1].Value.ToString();
                txtDiaChikh.Text = dvgDanhsachKH.Rows[index].Cells[2].Value.ToString();
                txtSoDienThoai.Text = dvgDanhsachKH.Rows[index].Cells[3].Value.ToString();
                var query = from hd in db.Hoadons
                            where hd.MaKh == ma
                            select new
                            {
                                hd.MaHd,
                                hd.NgayLap,
                                hd.MaTkNavigation.HoTen,
                                
                            };
                
                dvgDanhsachchitietdonkh.DataSource = query.ToList();
                dvgDanhsachchitietdonkh.Columns[0].HeaderText = "Mã HD";
                dvgDanhsachchitietdonkh.Columns[1].HeaderText = "Ngày lập";
                dvgDanhsachchitietdonkh.Columns[2].HeaderText = "Người lập";        
            }    
        }

        private void dvgDanhsachKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void tnXemThongtin_Click(object sender, EventArgs e)
        {
            HienThiChiTietKhachHang();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            loc();
        }
        private void LocDanhSach()
        {
            var query = from kh in db.Khachhangs
                        select new
                        {
                            kh.Hoadons.Count
                        };
                      
        }
        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                MessageBox.Show("Bạn chưa chọn thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int ma= int.Parse(dvgDanhsachKH.Rows[index].Cells[0].Value.ToString());
                SuaThongTinKh myform = new SuaThongTinKh();            
                Khachhang kh = db.Khachhangs.SingleOrDefault(kh => kh.MaKh == ma);
                myform.Tag = kh;
                myform.Show();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            Tim();
        }
        private void Tim()
        {
            if (txtMakhTim.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMakhTim.Focus();
                return;
            }
            else
            {
                try
                {
                    int ma = int.Parse(txtMakhTim.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn nhập mã hóa đơn không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMakhTim.SelectAll();
                    return;
                }
            }
            Khachhang khtim = db.Khachhangs.FirstOrDefault(khtim => khtim.SoDt == txtMakhTim.Text);
            if(khtim!=null)
            {
                var query = from kh in db.Khachhangs
                            where kh.SoDt== txtMakhTim.Text
                            select new
                            {
                                kh.MaKh,
                                kh.TenKh,
                                kh.DiaChi,
                                kh.SoDt,
                                kh.Hoadons.Count,
                            };
                dvgDanhsachKH.DataSource = query.ToList();
                dvgDanhsachKH.Columns[0].HeaderText = "Mã khách hàng";
                dvgDanhsachKH.Columns[1].HeaderText = "Tên khách hàng";
                dvgDanhsachKH.Columns[2].HeaderText = "Địa chỉ";
                dvgDanhsachKH.Columns[3].HeaderText = "Số điện thoại";
                dvgDanhsachKH.Columns[4].HeaderText = "Số lần mua";
            }
            else
            {
                MessageBox.Show("Khách hàng không có trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void loc()
        {
            if(txtSolanmuamin.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập số lượng mua nhỏ nhất", "Thông báo");
                txtSolanmuamin.Focus();
                return;
            }
            else
            {
                try
                {
                    int i = int.Parse(txtSolanmuamin.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn nhập số lượng mua nhỏ nhất không đúng định dạng", "Thông báo");
                    txtSolanmuamin.SelectAll();
                    return;
                }
            }
            if (txtSolanmuamax.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng mua lớn nhất", "Thông báo");
                txtSolanmuamax.Focus();
                return;
            }
            else
            {
                try
                {
                    int h = int.Parse(txtSolanmuamax.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn nhập số lượng mua lớn nhất không đúng định dạng", "Thông báo");
                    txtSolanmuamax.SelectAll();
                    return;
                }
            }
            var query = from kh in db.Khachhangs
                        where kh.Hoadons.Count>=int.Parse(txtSolanmuamin.Text) && kh.Hoadons.Count<=int.Parse(txtSolanmuamax.Text)
                        select new
                        {
                            kh.MaKh,
                            kh.TenKh,
                            kh.DiaChi,
                            kh.SoDt,
                            kh.Hoadons.Count,
                        };
            dvgDanhsachKH.DataSource = query.ToList();
            dvgDanhsachKH.Columns[0].HeaderText = "Mã khách hàng";
            dvgDanhsachKH.Columns[1].HeaderText = "Tên khách hàng";
            dvgDanhsachKH.Columns[2].HeaderText = "Địa chỉ";
            dvgDanhsachKH.Columns[3].HeaderText = "Số điện thoại";
            dvgDanhsachKH.Columns[4].HeaderText = "Số lần mua";
        }

        private void btnboloc_Click(object sender, EventArgs e)
        {
            HienThiDanhSachKhachHang();
        }
    }
}
