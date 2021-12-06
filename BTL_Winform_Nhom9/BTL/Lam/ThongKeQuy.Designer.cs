
namespace BTL.Lam
{
    partial class ThongKeQuy
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
            this.label7 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbQuy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(252, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(416, 41);
            this.label7.TabIndex = 48;
            this.label7.Text = "Thống kê báo cáo theo quý  ";
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIn.Location = new System.Drawing.Point(538, 31);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(144, 43);
            this.btnIn.TabIndex = 28;
            this.btnIn.Text = "Xuất báo cáo";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.XuatBaoCao);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(60, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 177);
            this.panel2.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.cbbNam);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbbQuy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(89, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 96);
            this.panel1.TabIndex = 49;
            // 
            // cbbNam
            // 
            this.cbbNam.FormattingEnabled = true;
            this.cbbNam.Location = new System.Drawing.Point(378, 36);
            this.cbbNam.Name = "cbbNam";
            this.cbbNam.Size = new System.Drawing.Size(151, 28);
            this.cbbNam.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Chọn năm";
            // 
            // cbbQuy
            // 
            this.cbbQuy.FormattingEnabled = true;
            this.cbbQuy.Items.AddRange(new object[] {
            "Quý I",
            "Quý II",
            "Quý III",
            "Quý IV"});
            this.cbbQuy.Location = new System.Drawing.Point(120, 36);
            this.cbbQuy.Name = "cbbQuy";
            this.cbbQuy.Size = new System.Drawing.Size(151, 28);
            this.cbbQuy.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "Chọn quý :";
            // 
            // ThongKeQuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 236);
            this.Controls.Add(this.panel2);
            this.Name = "ThongKeQuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThongKeSanPhamBanChay";
            this.Load += new System.EventHandler(this.load_Tk);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbQuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbNam;
    }
}