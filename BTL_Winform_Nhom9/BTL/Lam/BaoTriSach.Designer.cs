
namespace BTL
{
    partial class BaoTriSach
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
            this.dsSach = new System.Windows.Forms.DataGridView();
            this.masach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenloai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giasach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tacgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhaxuatban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbTenLoaiSach = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dsSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsSach
            // 
            this.dsSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dsSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masach,
            this.tensach,
            this.tenloai,
            this.giasach,
            this.giaban,
            this.tacgia,
            this.nhaxuatban});
            this.dsSach.Location = new System.Drawing.Point(8, 33);
            this.dsSach.Name = "dsSach";
            this.dsSach.RowHeadersWidth = 51;
            this.dsSach.RowTemplate.Height = 29;
            this.dsSach.Size = new System.Drawing.Size(809, 218);
            this.dsSach.TabIndex = 28;
            this.dsSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChonDong);
            this.dsSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChonDong);
            // 
            // masach
            // 
            this.masach.HeaderText = "Mã sách";
            this.masach.MinimumWidth = 6;
            this.masach.Name = "masach";
            // 
            // tensach
            // 
            this.tensach.HeaderText = "Tên sách";
            this.tensach.MinimumWidth = 6;
            this.tensach.Name = "tensach";
            // 
            // tenloai
            // 
            this.tenloai.HeaderText = "Tên loại sách";
            this.tenloai.MinimumWidth = 6;
            this.tenloai.Name = "tenloai";
            // 
            // giasach
            // 
            this.giasach.HeaderText = "Giá bán";
            this.giasach.MinimumWidth = 6;
            this.giasach.Name = "giasach";
            // 
            // giaban
            // 
            this.giaban.HeaderText = "Giá nhập";
            this.giaban.MinimumWidth = 6;
            this.giaban.Name = "giaban";
            // 
            // tacgia
            // 
            this.tacgia.HeaderText = "Tác giả";
            this.tacgia.MinimumWidth = 6;
            this.tacgia.Name = "tacgia";
            // 
            // nhaxuatban
            // 
            this.nhaxuatban.HeaderText = "Nhà xuất bản";
            this.nhaxuatban.MinimumWidth = 6;
            this.nhaxuatban.Name = "nhaxuatban";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTim.Location = new System.Drawing.Point(560, 19);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(104, 38);
            this.btnTim.TabIndex = 26;
            this.btnTim.Text = "Lọc";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(178, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 28);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tên loại sách";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(66, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 100);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.Location = new System.Drawing.Point(430, 33);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(122, 48);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSua.Location = new System.Drawing.Point(293, 33);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(122, 48);
            this.btnSua.TabIndex = 28;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.SuaClick);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Blue;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(560, 32);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(128, 52);
            this.btnReset.TabIndex = 34;
            this.btnReset.Text = "Xóa trắng";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.Resert_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThem.Location = new System.Drawing.Point(149, 33);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(122, 48);
            this.btnThem.TabIndex = 27;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.Them_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.dsSach);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(67, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(823, 296);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm sách";
            // 
            // cbbTenLoaiSach
            // 
            this.cbbTenLoaiSach.FormattingEnabled = true;
            this.cbbTenLoaiSach.Location = new System.Drawing.Point(305, 24);
            this.cbbTenLoaiSach.Name = "cbbTenLoaiSach";
            this.cbbTenLoaiSach.Size = new System.Drawing.Size(243, 28);
            this.cbbTenLoaiSach.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbbTenLoaiSach);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Location = new System.Drawing.Point(73, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 71);
            this.panel1.TabIndex = 36;
            // 
            // BaoTriSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(953, 582);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BaoTriSach";
            this.Text = "BaoTriSach";
            this.Load += new System.EventHandler(this.BaoTriSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dsSach;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn masach;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensach;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenloai;
        private System.Windows.Forms.DataGridViewTextBoxColumn giasach;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaban;
        private System.Windows.Forms.DataGridViewTextBoxColumn tacgia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhaxuatban;
        private System.Windows.Forms.ComboBox cbbTenLoaiSach;
        private System.Windows.Forms.Panel panel1;
    }
}