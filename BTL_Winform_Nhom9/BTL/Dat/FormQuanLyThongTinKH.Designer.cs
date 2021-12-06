
namespace BTL
{
    partial class FormQuanLyThongTinKH
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
            this.grDanhSachKH = new System.Windows.Forms.GroupBox();
            this.dvgDanhsachKH = new System.Windows.Forms.DataGridView();
            this.tnXemThongtin = new System.Windows.Forms.Button();
            this.btnSuaThongTin = new System.Windows.Forms.Button();
            this.grChucNang = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtSolanmuamax = new System.Windows.Forms.TextBox();
            this.txtSolanmuamin = new System.Windows.Forms.TextBox();
            this.txtMakhTim = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnboloc = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.dvgDanhsachchitietdonkh = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiaChikh = new System.Windows.Forms.TextBox();
            this.txtMakh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenkh = new System.Windows.Forms.TextBox();
            this.grDanhSachKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhsachKH)).BeginInit();
            this.grChucNang.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhsachchitietdonkh)).BeginInit();
            this.SuspendLayout();
            // 
            // grDanhSachKH
            // 
            this.grDanhSachKH.Controls.Add(this.dvgDanhsachKH);
            this.grDanhSachKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.grDanhSachKH.Location = new System.Drawing.Point(0, 0);
            this.grDanhSachKH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grDanhSachKH.Name = "grDanhSachKH";
            this.grDanhSachKH.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grDanhSachKH.Size = new System.Drawing.Size(1635, 213);
            this.grDanhSachKH.TabIndex = 17;
            this.grDanhSachKH.TabStop = false;
            this.grDanhSachKH.Text = "Danh Sách Khách Hàng";
            // 
            // dvgDanhsachKH
            // 
            this.dvgDanhsachKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgDanhsachKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDanhsachKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgDanhsachKH.Location = new System.Drawing.Point(4, 31);
            this.dvgDanhsachKH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dvgDanhsachKH.Name = "dvgDanhsachKH";
            this.dvgDanhsachKH.RowHeadersWidth = 51;
            this.dvgDanhsachKH.RowTemplate.Height = 29;
            this.dvgDanhsachKH.Size = new System.Drawing.Size(1627, 178);
            this.dvgDanhsachKH.TabIndex = 0;
            this.dvgDanhsachKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgDanhsachKH_CellClick);
            // 
            // tnXemThongtin
            // 
            this.tnXemThongtin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tnXemThongtin.Location = new System.Drawing.Point(754, 52);
            this.tnXemThongtin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tnXemThongtin.Name = "tnXemThongtin";
            this.tnXemThongtin.Size = new System.Drawing.Size(172, 111);
            this.tnXemThongtin.TabIndex = 0;
            this.tnXemThongtin.Text = "Xem Thông Tin";
            this.tnXemThongtin.UseVisualStyleBackColor = true;
            this.tnXemThongtin.Click += new System.EventHandler(this.tnXemThongtin_Click);
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaThongTin.Location = new System.Drawing.Point(991, 52);
            this.btnSuaThongTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(164, 111);
            this.btnSuaThongTin.TabIndex = 7;
            this.btnSuaThongTin.Text = "Sửa Thông Tin";
            this.btnSuaThongTin.UseVisualStyleBackColor = true;
            this.btnSuaThongTin.Click += new System.EventHandler(this.btnSuaThongTin_Click);
            // 
            // grChucNang
            // 
            this.grChucNang.Controls.Add(this.btnTim);
            this.grChucNang.Controls.Add(this.txtSolanmuamax);
            this.grChucNang.Controls.Add(this.txtSolanmuamin);
            this.grChucNang.Controls.Add(this.txtMakhTim);
            this.grChucNang.Controls.Add(this.label8);
            this.grChucNang.Controls.Add(this.label7);
            this.grChucNang.Controls.Add(this.label6);
            this.grChucNang.Controls.Add(this.btnboloc);
            this.grChucNang.Controls.Add(this.btnLoc);
            this.grChucNang.Controls.Add(this.btnSuaThongTin);
            this.grChucNang.Controls.Add(this.tnXemThongtin);
            this.grChucNang.Location = new System.Drawing.Point(4, 514);
            this.grChucNang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grChucNang.Name = "grChucNang";
            this.grChucNang.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grChucNang.Size = new System.Drawing.Size(1594, 214);
            this.grChucNang.TabIndex = 19;
            this.grChucNang.TabStop = false;
            this.grChucNang.Text = "Chức Năng";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(397, 41);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(129, 41);
            this.btnTim.TabIndex = 21;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtSolanmuamax
            // 
            this.txtSolanmuamax.Location = new System.Drawing.Point(190, 164);
            this.txtSolanmuamax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSolanmuamax.Name = "txtSolanmuamax";
            this.txtSolanmuamax.Size = new System.Drawing.Size(170, 34);
            this.txtSolanmuamax.TabIndex = 20;
            // 
            // txtSolanmuamin
            // 
            this.txtSolanmuamin.Location = new System.Drawing.Point(190, 102);
            this.txtSolanmuamin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSolanmuamin.Name = "txtSolanmuamin";
            this.txtSolanmuamin.Size = new System.Drawing.Size(170, 34);
            this.txtSolanmuamin.TabIndex = 19;
            // 
            // txtMakhTim
            // 
            this.txtMakhTim.Location = new System.Drawing.Point(190, 42);
            this.txtMakhTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMakhTim.Name = "txtMakhTim";
            this.txtMakhTim.Size = new System.Drawing.Size(170, 34);
            this.txtMakhTim.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 28);
            this.label8.TabIndex = 17;
            this.label8.Text = "Số lần mua max";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 28);
            this.label7.TabIndex = 16;
            this.label7.Text = "Số lần mua min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "Số điện thoại";
            // 
            // btnboloc
            // 
            this.btnboloc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnboloc.Location = new System.Drawing.Point(583, 118);
            this.btnboloc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnboloc.Name = "btnboloc";
            this.btnboloc.Size = new System.Drawing.Size(129, 74);
            this.btnboloc.TabIndex = 14;
            this.btnboloc.Text = "Bỏ Lọc";
            this.btnboloc.UseVisualStyleBackColor = true;
            this.btnboloc.Click += new System.EventHandler(this.btnboloc_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoc.Location = new System.Drawing.Point(397, 118);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(129, 71);
            this.btnLoc.TabIndex = 13;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoDienThoai);
            this.groupBox1.Controls.Add(this.dvgDanhsachchitietdonkh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDiaChikh);
            this.groupBox1.Controls.Add(this.txtMakh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenkh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 213);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1635, 293);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết khách hàng";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(202, 175);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.ReadOnly = true;
            this.txtSoDienThoai.Size = new System.Drawing.Size(304, 34);
            this.txtSoDienThoai.TabIndex = 27;
            // 
            // dvgDanhsachchitietdonkh
            // 
            this.dvgDanhsachchitietdonkh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgDanhsachchitietdonkh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgDanhsachchitietdonkh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDanhsachchitietdonkh.Location = new System.Drawing.Point(564, 36);
            this.dvgDanhsachchitietdonkh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dvgDanhsachchitietdonkh.Name = "dvgDanhsachchitietdonkh";
            this.dvgDanhsachchitietdonkh.RowHeadersWidth = 51;
            this.dvgDanhsachchitietdonkh.RowTemplate.Height = 29;
            this.dvgDanhsachchitietdonkh.Size = new System.Drawing.Size(1063, 193);
            this.dvgDanhsachchitietdonkh.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 28);
            this.label5.TabIndex = 26;
            this.label5.Text = "Điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 28);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã khách hàng";
            // 
            // txtDiaChikh
            // 
            this.txtDiaChikh.Location = new System.Drawing.Point(202, 129);
            this.txtDiaChikh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiaChikh.Name = "txtDiaChikh";
            this.txtDiaChikh.ReadOnly = true;
            this.txtDiaChikh.Size = new System.Drawing.Size(304, 34);
            this.txtDiaChikh.TabIndex = 25;
            // 
            // txtMakh
            // 
            this.txtMakh.Location = new System.Drawing.Point(202, 36);
            this.txtMakh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMakh.Name = "txtMakh";
            this.txtMakh.ReadOnly = true;
            this.txtMakh.Size = new System.Drawing.Size(304, 34);
            this.txtMakh.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 28);
            this.label4.TabIndex = 24;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 28);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tên khách hàng";
            // 
            // txtTenkh
            // 
            this.txtTenkh.Location = new System.Drawing.Point(202, 83);
            this.txtTenkh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenkh.Name = "txtTenkh";
            this.txtTenkh.ReadOnly = true;
            this.txtTenkh.Size = new System.Drawing.Size(304, 34);
            this.txtTenkh.TabIndex = 23;
            // 
            // FormQuanLyThongTinKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1635, 890);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grDanhSachKH);
            this.Controls.Add(this.grChucNang);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormQuanLyThongTinKH";
            this.Text = "FormQuanLyThongTinKH";
            this.Load += new System.EventHandler(this.FormQuanLyThongTinKH_Load);
            this.grDanhSachKH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhsachKH)).EndInit();
            this.grChucNang.ResumeLayout(false);
            this.grChucNang.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDanhsachchitietdonkh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grDanhSachKH;
        private System.Windows.Forms.DataGridView dvgDanhsachKH;
        private System.Windows.Forms.Button tnXemThongtin;
        private System.Windows.Forms.Button btnSuaThongTin;
        private System.Windows.Forms.GroupBox grChucNang;
        private System.Windows.Forms.Button btnboloc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtSolanmuamax;
        private System.Windows.Forms.TextBox txtSolanmuamin;
        private System.Windows.Forms.TextBox txtMakhTim;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.DataGridView dvgDanhsachchitietdonkh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiaChikh;
        private System.Windows.Forms.TextBox txtMakh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenkh;
    }
}