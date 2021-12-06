
namespace BTL
{
    partial class SuaDanhMucSach
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
            this.txbTenLoaiSach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMaLoaiSach = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(142, 148);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(94, 29);
            this.btnHuy.TabIndex = 31;
            this.btnHuy.Text = "Thoát";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(3, 148);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(94, 29);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Cập nhật";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tên Loại sách";
            // 
            // txbTenLoaiSach
            // 
            this.txbTenLoaiSach.Location = new System.Drawing.Point(132, 84);
            this.txbTenLoaiSach.Name = "txbTenLoaiSach";
            this.txbTenLoaiSach.Size = new System.Drawing.Size(125, 27);
            this.txbTenLoaiSach.TabIndex = 29;
            this.txbTenLoaiSach.Validated += new System.EventHandler(this.Validate_Data);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Mã loại sách";
            // 
            // txbMaLoaiSach
            // 
            this.txbMaLoaiSach.Location = new System.Drawing.Point(132, 22);
            this.txbMaLoaiSach.Name = "txbMaLoaiSach";
            this.txbMaLoaiSach.ReadOnly = true;
            this.txbMaLoaiSach.Size = new System.Drawing.Size(125, 27);
            this.txbMaLoaiSach.TabIndex = 33;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(36, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 31);
            this.label7.TabIndex = 44;
            this.label7.Text = "Cập nhật danh mục";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbTenLoaiSach);
            this.panel1.Controls.Add(this.txbMaLoaiSach);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Location = new System.Drawing.Point(9, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 203);
            this.panel1.TabIndex = 45;
            // 
            // SuaDanhMucSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 300);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Name = "SuaDanhMucSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuaDanhMucSach";
            this.Load += new System.EventHandler(this.LoadForm_SuaDM);
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
        private System.Windows.Forms.TextBox txbTenLoaiSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMaLoaiSach;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}