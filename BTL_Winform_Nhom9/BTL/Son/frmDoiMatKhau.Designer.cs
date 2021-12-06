
namespace BTL.Son
{
    partial class frmDoiMatKhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.gbxDoiMK = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuuThayDoi = new System.Windows.Forms.Button();
            this.txtXacNhanMKM = new System.Windows.Forms.TextBox();
            this.txtMKMoi = new System.Windows.Forms.TextBox();
            this.txtMKCu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbxDoiMK.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoiMK);
            this.panel1.Controls.Add(this.lblTenDN);
            this.panel1.Controls.Add(this.lblHoTen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1304, 180);
            this.panel1.TabIndex = 3;
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Location = new System.Drawing.Point(669, 122);
            this.btnDoiMK.Margin = new System.Windows.Forms.Padding(2);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(180, 36);
            this.btnDoiMK.TabIndex = 5;
            this.btnDoiMK.Text = "Đổi mật khẩu";
            this.btnDoiMK.UseVisualStyleBackColor = true;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.Location = new System.Drawing.Point(669, 70);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(65, 28);
            this.lblTenDN.TabIndex = 4;
            this.lblTenDN.Text = "label5";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(669, 25);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(65, 28);
            this.lblHoTen.TabIndex = 3;
            this.lblHoTen.Text = "label4";
            // 
            // gbxDoiMK
            // 
            this.gbxDoiMK.Controls.Add(this.btnHuy);
            this.gbxDoiMK.Controls.Add(this.btnLuuThayDoi);
            this.gbxDoiMK.Controls.Add(this.txtXacNhanMKM);
            this.gbxDoiMK.Controls.Add(this.txtMKMoi);
            this.gbxDoiMK.Controls.Add(this.txtMKCu);
            this.gbxDoiMK.Controls.Add(this.label8);
            this.gbxDoiMK.Controls.Add(this.label7);
            this.gbxDoiMK.Controls.Add(this.label6);
            this.gbxDoiMK.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDoiMK.Location = new System.Drawing.Point(0, 180);
            this.gbxDoiMK.Name = "gbxDoiMK";
            this.gbxDoiMK.Size = new System.Drawing.Size(1304, 231);
            this.gbxDoiMK.TabIndex = 6;
            this.gbxDoiMK.TabStop = false;
            this.gbxDoiMK.Text = "Đổi mật khẩu";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(676, 181);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(180, 36);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuuThayDoi
            // 
            this.btnLuuThayDoi.Location = new System.Drawing.Point(450, 181);
            this.btnLuuThayDoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new System.Drawing.Size(180, 36);
            this.btnLuuThayDoi.TabIndex = 9;
            this.btnLuuThayDoi.Text = "Lưu thay đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = true;
            this.btnLuuThayDoi.Click += new System.EventHandler(this.btnLuuThayDoi_Click);
            // 
            // txtXacNhanMKM
            // 
            this.txtXacNhanMKM.Location = new System.Drawing.Point(676, 125);
            this.txtXacNhanMKM.Name = "txtXacNhanMKM";
            this.txtXacNhanMKM.PasswordChar = '*';
            this.txtXacNhanMKM.Size = new System.Drawing.Size(180, 34);
            this.txtXacNhanMKM.TabIndex = 8;
            // 
            // txtMKMoi
            // 
            this.txtMKMoi.Location = new System.Drawing.Point(676, 76);
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.PasswordChar = '*';
            this.txtMKMoi.Size = new System.Drawing.Size(180, 34);
            this.txtMKMoi.TabIndex = 7;
            // 
            // txtMKCu
            // 
            this.txtMKCu.Location = new System.Drawing.Point(676, 27);
            this.txtMKCu.Name = "txtMKCu";
            this.txtMKCu.PasswordChar = '*';
            this.txtMKCu.Size = new System.Drawing.Size(180, 34);
            this.txtMKCu.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(410, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(220, 28);
            this.label8.TabIndex = 13;
            this.label8.Text = "Xác nhận mật khẩu mới:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mật khẩu mới:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mật khẩu cũ:";
            // 
            // frmQLTaiKhoanCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 681);
            this.Controls.Add(this.gbxDoiMK);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLTaiKhoanCaNhan";
            this.Text = "frmQLTaiKhoanCaNhan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxDoiMK.ResumeLayout(false);
            this.gbxDoiMK.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.GroupBox gbxDoiMK;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuuThayDoi;
        private System.Windows.Forms.TextBox txtXacNhanMKM;
        private System.Windows.Forms.TextBox txtMKMoi;
        private System.Windows.Forms.TextBox txtMKCu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}