using System;
using System.Windows.Forms;

namespace BTL
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        
        public static MainForm mainForm;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DangNhap dangNhap = new DangNhap();
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                mainForm = new MainForm(dangNhap.MaTK, dangNhap.TenDN, dangNhap.MatKhau, dangNhap.HoTen, dangNhap.isAdmin);
                Application.Run(mainForm);
            }
            else
                Application.Exit();

        }
    }
}
