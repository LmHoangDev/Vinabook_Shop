
namespace BTL
{
    partial class FormTrangChu
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
            this.txt1 = new System.Windows.Forms.Label();
            this.txtNgay = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtChamNgon = new System.Windows.Forms.Label();
            this.txtHello = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.AutoSize = true;
            this.txt1.BackColor = System.Drawing.Color.Transparent;
            this.txt1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt1.Location = new System.Drawing.Point(12, 173);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(274, 61);
            this.txt1.TabIndex = 0;
            this.txt1.Text = "Xin chào, ";
            // 
            // txtNgay
            // 
            this.txtNgay.AutoSize = true;
            this.txtNgay.BackColor = System.Drawing.Color.Transparent;
            this.txtNgay.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.txtNgay.Location = new System.Drawing.Point(12, 9);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(93, 34);
            this.txtNgay.TabIndex = 1;
            this.txtNgay.Text = "label1";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.Location = new System.Drawing.Point(12, 52);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(354, 75);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "loading. . .";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 1);
            this.label1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtChamNgon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNgay);
            this.panel1.Controls.Add(this.txtHello);
            this.panel1.Controls.Add(this.txt1);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 681);
            this.panel1.TabIndex = 5;
            // 
            // txtChamNgon
            // 
            this.txtChamNgon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChamNgon.AutoSize = true;
            this.txtChamNgon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.txtChamNgon.Location = new System.Drawing.Point(12, 604);
            this.txtChamNgon.Name = "txtChamNgon";
            this.txtChamNgon.Size = new System.Drawing.Size(48, 19);
            this.txtChamNgon.TabIndex = 5;
            this.txtChamNgon.Text = "label2";
            // 
            // txtHello
            // 
            this.txtHello.AutoSize = true;
            this.txtHello.BackColor = System.Drawing.Color.Transparent;
            this.txtHello.Font = new System.Drawing.Font("Arial Rounded MT Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHello.Location = new System.Drawing.Point(108, 217);
            this.txtHello.Name = "txtHello";
            this.txtHello.Size = new System.Drawing.Size(270, 55);
            this.txtHello.TabIndex = 0;
            this.txtHello.Text = "teen nguoi";
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTL.Properties.Resources.HomePage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1304, 681);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FormTrangChu";
            this.Text = "FormTrangChu";
            this.Load += new System.EventHandler(this.FormTrangChu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txt1;
        private System.Windows.Forms.Label txtNgay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtHello;
        private System.Windows.Forms.Label txtChamNgon;
        private System.Windows.Forms.Timer timer2;
    }
}