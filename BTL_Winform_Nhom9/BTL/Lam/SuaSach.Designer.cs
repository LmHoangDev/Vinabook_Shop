
namespace BTL
{
    partial class SuaSach
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
            this.components = new System.ComponentModel.Container();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTenSach = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txbNXB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTacGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbTenLoai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbMaSach = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(257, 344);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(94, 29);
            this.btnHuy.TabIndex = 43;
            this.btnHuy.Text = "Thoát";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.Thoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(42, 344);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(94, 29);
            this.btnSua.TabIndex = 42;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.Update_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Tên sách";
            // 
            // txbTenSach
            // 
            this.txbTenSach.Location = new System.Drawing.Point(187, 59);
            this.txbTenSach.Name = "txbTenSach";
            this.txbTenSach.Size = new System.Drawing.Size(215, 27);
            this.txbTenSach.TabIndex = 41;
            this.txbTenSach.Validated += new System.EventHandler(this.tenSach);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txbNXB
            // 
            this.txbNXB.Location = new System.Drawing.Point(187, 298);
            this.txbNXB.Name = "txbNXB";
            this.txbNXB.Size = new System.Drawing.Size(215, 27);
            this.txbNXB.TabIndex = 51;
            this.txbNXB.Validated += new System.EventHandler(this.nxb);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "Nhà xuất bản";
            // 
            // txbTacGia
            // 
            this.txbTacGia.Location = new System.Drawing.Point(187, 251);
            this.txbTacGia.Name = "txbTacGia";
            this.txbTacGia.Size = new System.Drawing.Size(215, 27);
            this.txbTacGia.TabIndex = 49;
            this.txbTacGia.Validated += new System.EventHandler(this.tacGia);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "Tác giả";
            // 
            // txbGia
            // 
            this.txbGia.Location = new System.Drawing.Point(187, 159);
            this.txbGia.Name = "txbGia";
            this.txbGia.Size = new System.Drawing.Size(215, 27);
            this.txbGia.TabIndex = 47;
            this.txbGia.Validated += new System.EventHandler(this.gia);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Giá bán";
            // 
            // cbbTenLoai
            // 
            this.cbbTenLoai.FormattingEnabled = true;
            this.cbbTenLoai.Location = new System.Drawing.Point(187, 106);
            this.cbbTenLoai.Name = "cbbTenLoai";
            this.cbbTenLoai.Size = new System.Drawing.Size(215, 28);
            this.cbbTenLoai.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Tên loại sách";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "Mã sách";
            // 
            // txbMaSach
            // 
            this.txbMaSach.Location = new System.Drawing.Point(187, 20);
            this.txbMaSach.Name = "txbMaSach";
            this.txbMaSach.ReadOnly = true;
            this.txbMaSach.Size = new System.Drawing.Size(215, 27);
            this.txbMaSach.TabIndex = 53;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtGiaNhap);
            this.panel1.Controls.Add(this.txbMaSach);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbbTenLoai);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.txbGia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txbTenSach);
            this.panel1.Controls.Add(this.txbTacGia);
            this.panel1.Controls.Add(this.txbNXB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 407);
            this.panel1.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 54;
            this.label8.Text = "Giá nhập";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(187, 209);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(215, 27);
            this.txtGiaNhap.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(128, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 41);
            this.label7.TabIndex = 55;
            this.label7.Text = "Cập nhật sách";
            // 
            // SuaSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 484);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Name = "SuaSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuaSach";
            this.Load += new System.EventHandler(this.LoadForm_Sua);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTenSach;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txbNXB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTacGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbTenLoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMaSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaNhap;
    }
}