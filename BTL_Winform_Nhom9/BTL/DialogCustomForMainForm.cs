using System;
using System.Windows.Forms;

namespace BTL
{
    public partial class DialogCustomForMainForm : Form
    {
        public DialogCustomForMainForm()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            MainForm.dr = DialogResult.Yes;
            this.Dispose();
        }
    }
}
