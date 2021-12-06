using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using BTL.Models;

namespace BTL.Son
{
    public partial class InDonDatHang : Form
    {
        private int maDDH;
        private string tenNCC;
        private string diaChiNCC;
        private string soDT;
        private string ngayLap;
        private string tongTien;
        private List<Ctdondh> listDatHang = new List<Ctdondh>();

        public InDonDatHang(int maDDH, string tenNCC, string diaChi, string soDT, string ngayLap, string tongTien,List<Ctdondh> listDatHang)
        {
            this.maDDH = maDDH;
            this.tenNCC = tenNCC;
            diaChiNCC = diaChi;
            this.soDT = soDT;
            this.ngayLap = ngayLap;
            this.tongTien = tongTien;
            this.listDatHang = listDatHang;
            InitializeComponent();
        }

        private void InDonDatHang_Load(object sender, EventArgs e)
        {
            lblMaDDH.Text = maDDH.ToString();
            lblDiaChi.Text = diaChiNCC;
            lblSDT.Text = soDT;
            lblNCC.Text = tenNCC;
            lblNgayLap.Text = ngayLap;
            lblTongTien.Text = tongTien;
            SetTable();
        }

        private void SetTable()
        {
            dgvSachDat.Rows.Clear();

            int count = 1;
            foreach (var item in listDatHang)
            {
                DataGridViewRow row = (DataGridViewRow)dgvSachDat.Rows[0].Clone();
                row.Cells[0].Value = count;
                row.Cells[1].Value = item.MaSach;
                row.Cells[2].Value = item.MaSachNavigation.TenSach;
                row.Cells[3].Value = item.SlDat;
                row.Cells[4].Value = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", item.MaSachNavigation.DonGiaNhap);
                row.Cells[5].Value = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", item.ThanhTien);

                dgvSachDat.Rows.Add(row);
                count++;
            }
            dgvSachDat.AllowUserToAddRows = false;
            dgvSachDat.RowHeadersVisible = false;
            dgvSachDat.BackgroundColor = System.Drawing.SystemColors.Control;
        }

        private void Print(Panel panel)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrint = panel;
            GetPrintArea(panel);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
            
        }

        private Bitmap memorying;

        private void GetPrintArea(Panel panel)
        {
            memorying = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(memorying, new Rectangle(0, 0, panel.Width, panel.Height));
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pageArea = e.PageBounds;
            //e.Graphics.DrawImage(memorying, (pageArea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);
            e.Graphics.DrawImage(memorying, 0, 0, 840, 1120);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print(panelPrint);
        }
    }
}
