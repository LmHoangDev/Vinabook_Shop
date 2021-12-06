
namespace BTL
{
    partial class ThemSach
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
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTenSach = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbbTenLoai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTacGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbNXB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbGiaNhap = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(294, 300);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(94, 29);
            this.btnHuy.TabIndex = 31;
            this.btnHuy.Text = "Thoát";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.Thoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(66, 300);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 29);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.Them_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tên sách";
            // 
            // txbTenSach
            // 
            this.txbTenSach.Location = new System.Drawing.Point(183, 19);
            this.txbTenSach.Name = "txbTenSach";
            this.txbTenSach.Size = new System.Drawing.Size(215, 27);
            this.txbTenSach.TabIndex = 29;
            this.txbTenSach.TextChanged += new System.EventHandler(this.txbTenSach_TextChanged);
            this.txbTenSach.Validated += new System.EventHandler(this.tenSach);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tên loại sách";
            // 
            // cbbTenLoai
            // 
            this.cbbTenLoai.FormattingEnabled = true;
            this.cbbTenLoai.Location = new System.Drawing.Point(183, 66);
            this.cbbTenLoai.Name = "cbbTenLoai";
            this.cbbTenLoai.Size = new System.Drawing.Size(215, 28);
            this.cbbTenLoai.TabIndex = 33;
            this.cbbTenLoai.SelectedIndexChanged += new System.EventHandler(this.cbbTenLoai_SelectedIndexChanged);
            this.cbbTenLoai.Validated += new System.EventHandler(this.tenLoai);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Giá bán";
            // 
            // txbGia
            // 
            this.txbGia.Location = new System.Drawing.Point(183, 119);
            this.txbGia.Name = "txbGia";
            this.txbGia.Size = new System.Drawing.Size(215, 27);
            this.txbGia.TabIndex = 35;
            this.txbGia.TextChanged += new System.EventHandler(this.txbGia_TextChanged);
            this.txbGia.Validated += new System.EventHandler(this.giaSach);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Tác giả";
            // 
            // txbTacGia
            // 
            this.txbTacGia.Location = new System.Drawing.Point(183, 203);
            this.txbTacGia.Name = "txbTacGia";
            this.txbTacGia.Size = new System.Drawing.Size(215, 27);
            this.txbTacGia.TabIndex = 37;
            this.txbTacGia.TextChanged += new System.EventHandler(this.txbTacGia_TextChanged);
            this.txbTacGia.Validated += new System.EventHandler(this.giaTacGia);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "Nhà xuất bản";
            // 
            // txbNXB
            // 
            this.txbNXB.Location = new System.Drawing.Point(183, 242);
            this.txbNXB.Name = "txbNXB";
            this.txbNXB.Size = new System.Drawing.Size(215, 27);
            this.txbNXB.TabIndex = 39;
            this.txbNXB.Validated += new System.EventHandler(this.nxb);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbGiaNhap);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txbTenSach);
            this.panel1.Controls.Add(this.txbNXB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.txbTacGia);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbGia);
            this.panel1.Controls.Add(this.cbbTenLoai);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(22, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 361);
            this.panel1.TabIndex = 40;
            // 
            // txbGiaNhap
            // 
            this.txbGiaNhap.Location = new System.Drawing.Point(183, 163);
            this.txbGiaNhap.Name = "txbGiaNhap";
            this.txbGiaNhap.Size = new System.Drawing.Size(215, 27);
            this.txbGiaNhap.TabIndex = 44;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(181, 300);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 29);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa trắng";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.XoaTrang);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Giá nhập";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(152, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 41);
            this.label7.TabIndex = 42;
            this.label7.Text = "Thêm sách";
            // 
            // ThemSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 454);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Name = "ThemSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemSach";
            this.Load += new System.EventHandler(this.ThemSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTenSach;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbbTenLoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNXB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTacGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txbGiaNhap;
        private System.Windows.Forms.Label label6;
    }
}