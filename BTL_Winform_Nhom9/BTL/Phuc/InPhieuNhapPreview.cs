using BTL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace BTL.Phuc
{
    public partial class InPhieuNhapPreview : Form
    {
        private int maPN;
        private int maDDH;
        private string tenNCC;
        private string diaChiNCC;
        private string soDT;
        private string ngayLap;
        private double tongTien;
        private List<Ctpnhap> listCtpn = new List<Ctpnhap>();
        private List<Ctdondh> listCtdondh = new List<Ctdondh>();

        public InPhieuNhapPreview(int maPN, int maDDH, string tenNCC, string diaChi, string soDT, string ngayLap, double tongTien, List<Ctpnhap> listCtpn, List<Ctdondh> listCtdondh)
        {
            this.maPN = maPN;
            this.maDDH = maDDH;
            this.tenNCC = tenNCC;
            diaChiNCC = diaChi;
            this.soDT = soDT;
            this.ngayLap = ngayLap;
            this.tongTien = tongTien;
            this.listCtpn = listCtpn;
            this.listCtdondh = listCtdondh;
            InitializeComponent();
        }

        private void SetTable()
        {
            dgv.Rows.Clear();

            int count = 1;
            foreach (var item in listCtpn)
            {
                foreach (var item1 in listCtdondh)
                {
                    if (item.MaSach == item1.MaSach)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgv.Rows[0].Clone();
                        row.Cells[0].Value = count;
                        row.Cells[1].Value = item.MaSach;
                        row.Cells[2].Value = item.MaSachNavigation.TenSach;
                        row.Cells[3].Value = item.SlNhap;
                        row.Cells[4].Value = item1.SlDat;
                        row.Cells[5].Value = string.Format(new CultureInfo("vi-Vn"), "{0:#,##0.00}", item.MaSachNavigation.DonGiaNhap);
                        double tt = int.Parse(item.SlNhap.ToString()) * double.Parse(item.MaSachNavigation.DonGiaNhap.ToString());
                        row.Cells[6].Value = tt.ToString("N1");

                        dgv.Rows.Add(row);
                        count++; 
                    }
                }
            }
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = System.Drawing.SystemColors.Control;
        }

        private void InPhieuNhapPreview_Load(object sender, EventArgs e)
        {
            lblMaPn.Text = maPN.ToString();
            lblMaDDH.Text = maDDH.ToString();
            lblDiaChi.Text = diaChiNCC;
            lblSDT.Text = soDT;
            lblNCC.Text = tenNCC;
            lblNgayLap.Text = ngayLap;
            lblTongTien.Text = tongTien.ToString("N1");
            SetTable();
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
