using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class FormTrangChu : Form
    {
        Dictionary<DayOfWeek, string> translateDay = new Dictionary<DayOfWeek, string>();
        int d = 0;

        public FormTrangChu()
        {
            InitializeComponent();
            Dich();
            txtChamNgon.Text = "“Các mẹo làm giàu nhanh chỉ dành cho kẻ lười biếng & không dám dấn thân.\n" +
                   "Hãy tôn trọng ước mơ của bạn, nó thật vô vị nếu bạn không đổ mồ hôi”\n" +
                   "–Steve Maraboli-";
        }

        private void Dich()
        {
            translateDay.Add(DayOfWeek.Monday, "Thứ hai");
            translateDay.Add(DayOfWeek.Tuesday, "Thứ ba");
            translateDay.Add(DayOfWeek.Wednesday, "Thứ tư");
            translateDay.Add(DayOfWeek.Thursday, "Thứ năm");
            translateDay.Add(DayOfWeek.Friday, "Thứ sáu");
            translateDay.Add(DayOfWeek.Saturday, "Thứ bảy");
            translateDay.Add(DayOfWeek.Sunday, "Chủ nhật");
        }

        private void customQuotes()
        {
            if (d == 0)
                txtChamNgon.Text = "“Tập trung cả đời vào việc kiếm tiền cho thấy sự nghèo nàn về tham vọng.\n" +
                                       "Bạn yêu cầu quá ít ở bản thân. Và điều đó sẽ khiến bạn không thỏa mãn.”\n" +
                                       "–Barack Obama-";
            else if (d == 1)
                txtChamNgon.Text = "“Sự thành công nằm ở việc bạn bước qua được những thất bại mà vẫn không \n" +
                                   "mất đi sự quyết tâm.”\n" +
                                   "–Winston Churchill-";
            else if (d == 2)
                txtChamNgon.Text = "““Cho” thì tốt hơn là “cho mượn”, nhất là khi chúng tốn kém gần như nhau.”\n" +
                               "–Philip Gibbs-";
            else if (d == 3)
                txtChamNgon.Text = "“Bất cứ gã nào nói, trao cho bạn cơ hội để kiếm được nhiều tiền mà không \n" +
                               "có rủi ro, hãy bỏ qua phần còn lại của câu nói. Làm theo điều này, bạn sẽ\n" +
                               "tránh được khổ đau”\n" +
                               "–Charlie Munger-";
            else if (d == 4)
                txtChamNgon.Text = "“Chẳng có cỗ máy nào làm giàu nhanh chóng cả, đó chỉ là người cố gắng móc \n" +
                               "tiền của bạn để làm giàu cho họ”\n" +
                               "-Naval Ravikant-";
            else
                txtChamNgon.Text = "“Các mẹo làm giàu nhanh chỉ dành cho kẻ lười biếng & không dám dấn thân.\n" +
                   "Hãy tôn trọng ước mơ của bạn, nó thật vô vị nếu bạn không đổ mồ hôi”\n" +
                   "–Steve Maraboli-";
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            DayOfWeek dow = dt.DayOfWeek;
            string tenThu = "";
            foreach (KeyValuePair<DayOfWeek, string> kvp in translateDay)
                if (kvp.Key == dow)
                    tenThu = kvp.Value;
            txtNgay.Text = tenThu + ", ngày " + dt.Day + " tháng " + dt.Month + " năm " + dt.Year;
            txtHello.Text = MainForm.ten;
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (d <= 5)
                d++;
            else
                d = 0;
            customQuotes();
        }
    }
}
