
namespace BTL
{
    partial class frmXemHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grDanhSachHoaDon = new System.Windows.Forms.GroupBox();
            this.dvgDanhSachHoaDon = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dvgDanhsachchitietsach = new System.Windows.Forms.DataGridView();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSodienthoai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenkhachhang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMakhachhang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNguoilap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNgaylap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMahoadon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtMahdtim = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnboloc = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtNgayketthuc = new System.Windows.Forms.DateTimePicker();
            this.dtNgaybatdau = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grDanhSachHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhSachHoaDon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhsachchitietsach)).BeginInit();
            this.SuspendLayout();
            // 
            // grDanhSachHoaDon
            // 
            this.grDanhSachHoaDon.Controls.Add(this.dvgDanhSachHoaDon);
            this.grDanhSachHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.grDanhSachHoaDon.Location = new System.Drawing.Point(0, 0);
            this.grDanhSachHoaDon.Name = "grDanhSachHoaDon";
            this.grDanhSachHoaDon.Size = new System.Drawing.Size(1304, 180);
            this.grDanhSachHoaDon.TabIndex = 9;
            this.grDanhSachHoaDon.TabStop = false;
            this.grDanhSachHoaDon.Text = "Danh Sách Hóa Đơn";
            // 
            // dvgDanhSachHoaDon
            // 
            this.dvgDanhSachHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgDanhSachHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDanhSachHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgDanhSachHoaDon.Location = new System.Drawing.Point(3, 23);
            this.dvgDanhSachHoaDon.Name = "dvgDanhSachHoaDon";
            this.dvgDanhSachHoaDon.RowHeadersWidth = 51;
            this.dvgDanhSachHoaDon.RowTemplate.Height = 29;
            this.dvgDanhSachHoaDon.Size = new System.Drawing.Size(1298, 154);
            this.dvgDanhSachHoaDon.TabIndex = 0;
            this.dvgDanhSachHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgDanhSachHoaDon_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDiachi);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSodienthoai);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTenkhachhang);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMakhachhang);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNguoilap);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNgaylap);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMahoadon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1304, 307);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dvgDanhsachchitietsach);
            this.groupBox3.Location = new System.Drawing.Point(396, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(905, 272);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // dvgDanhsachchitietsach
            // 
            this.dvgDanhsachchitietsach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgDanhsachchitietsach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgDanhsachchitietsach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgDanhsachchitietsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDanhsachchitietsach.Location = new System.Drawing.Point(6, 23);
            this.dvgDanhsachchitietsach.Name = "dvgDanhsachchitietsach";
            this.dvgDanhsachchitietsach.RowHeadersWidth = 51;
            this.dvgDanhsachchitietsach.RowTemplate.Height = 29;
            this.dvgDanhsachchitietsach.Size = new System.Drawing.Size(896, 246);
            this.dvgDanhsachchitietsach.TabIndex = 19;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(133, 257);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(125, 27);
            this.txtTongTien.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 33;
            this.label11.Text = "Tổng Tiền";
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(133, 218);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.ReadOnly = true;
            this.txtDiachi.Size = new System.Drawing.Size(222, 27);
            this.txtDiachi.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Địa chỉ";
            // 
            // txtSodienthoai
            // 
            this.txtSodienthoai.Location = new System.Drawing.Point(133, 185);
            this.txtSodienthoai.Name = "txtSodienthoai";
            this.txtSodienthoai.ReadOnly = true;
            this.txtSodienthoai.Size = new System.Drawing.Size(222, 27);
            this.txtSodienthoai.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Số điện thoại";
            // 
            // txtTenkhachhang
            // 
            this.txtTenkhachhang.Location = new System.Drawing.Point(133, 152);
            this.txtTenkhachhang.Name = "txtTenkhachhang";
            this.txtTenkhachhang.ReadOnly = true;
            this.txtTenkhachhang.Size = new System.Drawing.Size(222, 27);
            this.txtTenkhachhang.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Tên khách hàng";
            // 
            // txtMakhachhang
            // 
            this.txtMakhachhang.Location = new System.Drawing.Point(133, 119);
            this.txtMakhachhang.Name = "txtMakhachhang";
            this.txtMakhachhang.ReadOnly = true;
            this.txtMakhachhang.Size = new System.Drawing.Size(222, 27);
            this.txtMakhachhang.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Mã khách hàng";
            // 
            // txtNguoilap
            // 
            this.txtNguoilap.Location = new System.Drawing.Point(133, 86);
            this.txtNguoilap.Name = "txtNguoilap";
            this.txtNguoilap.ReadOnly = true;
            this.txtNguoilap.Size = new System.Drawing.Size(222, 27);
            this.txtNguoilap.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Người lập";
            // 
            // txtNgaylap
            // 
            this.txtNgaylap.Location = new System.Drawing.Point(133, 53);
            this.txtNgaylap.Name = "txtNgaylap";
            this.txtNgaylap.ReadOnly = true;
            this.txtNgaylap.Size = new System.Drawing.Size(222, 27);
            this.txtNgaylap.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ngày lập";
            // 
            // txtMahoadon
            // 
            this.txtMahoadon.Location = new System.Drawing.Point(133, 20);
            this.txtMahoadon.Name = "txtMahoadon";
            this.txtMahoadon.ReadOnly = true;
            this.txtMahoadon.Size = new System.Drawing.Size(222, 27);
            this.txtMahoadon.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mã hóa đơn";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(289, 570);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(94, 29);
            this.btnTim.TabIndex = 47;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click_1);
            // 
            // txtMahdtim
            // 
            this.txtMahdtim.Location = new System.Drawing.Point(133, 571);
            this.txtMahdtim.Name = "txtMahdtim";
            this.txtMahdtim.Size = new System.Drawing.Size(141, 27);
            this.txtMahdtim.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 578);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 45;
            this.label12.Text = "Mã hóa đơn";
            // 
            // btnboloc
            // 
            this.btnboloc.Location = new System.Drawing.Point(502, 495);
            this.btnboloc.Name = "btnboloc";
            this.btnboloc.Size = new System.Drawing.Size(154, 39);
            this.btnboloc.TabIndex = 44;
            this.btnboloc.Text = "Làm mới danh sách";
            this.btnboloc.UseVisualStyleBackColor = true;
            this.btnboloc.Click += new System.EventHandler(this.btnboloc_Click_1);
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(402, 495);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(94, 39);
            this.btnLoc.TabIndex = 41;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click_2);
            // 
            // dtNgayketthuc
            // 
            this.dtNgayketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayketthuc.Location = new System.Drawing.Point(133, 533);
            this.dtNgayketthuc.Name = "dtNgayketthuc";
            this.dtNgayketthuc.Size = new System.Drawing.Size(250, 27);
            this.dtNgayketthuc.TabIndex = 40;
            // 
            // dtNgaybatdau
            // 
            this.dtNgaybatdau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgaybatdau.Location = new System.Drawing.Point(133, 493);
            this.dtNgaybatdau.Name = "dtNgaybatdau";
            this.dtNgaybatdau.Size = new System.Drawing.Size(250, 27);
            this.dtNgaybatdau.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 538);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Ngày kết thúc:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 495);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Ngày bắt đầu:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(682, 495);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(112, 39);
            this.btnXem.TabIndex = 36;
            this.btnXem.Text = "Xem Hóa Đơn";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(402, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Chú ý: Cần chọn 1 dòng hóa đơn trong danh sách để xem, in hoặc sửa chúng";
            // 
            // frmXemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1304, 641);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMahdtim);
            this.Controls.Add(this.grDanhSachHoaDon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnboloc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtNgaybatdau);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.dtNgayketthuc);
            this.Name = "frmXemHoaDon";
            this.Text = "QuanLyHoaDon";
            this.Load += new System.EventHandler(this.QuanLyHoaDon_Load);
            this.grDanhSachHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhSachHoaDon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhsachchitietsach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grDanhSachHoaDon;
        private System.Windows.Forms.DataGridView dvgDanhSachHoaDon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSodienthoai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenkhachhang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMakhachhang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNguoilap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNgaylap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMahoadon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dvgDanhsachchitietsach;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtMahdtim;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnboloc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtNgayketthuc;
        private System.Windows.Forms.DateTimePicker dtNgaybatdau;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label1;
    }
}