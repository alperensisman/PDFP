using System;
using System.IO;
using System.Windows.Forms;

namespace programlamadillerifinal
{
    public partial class yazilimhak : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public yazilimhak()
        {
            InitializeComponent();
        }

        private void hakkinda_Load(object sender, EventArgs e)
        {
            Metinler();
        }

        private void Metinler()
        {
            string mainText = "Proje İçin Bilgiler;\n";
            mainText += "\n\n" + "1) Projenin İsmi 'PDFP' yani 'Programlama Dilleri Final Projesi' Kısaltmasıdır.";
            mainText += "\n\n" + "2) Projenin Kendine Has Dosya Türü Vardır. Dosya Türü: '.pdfp'";
            mainText += "\n\n" + "3) Projenin Data Dosyaları AppData\\Roaming Yolu Altındaki Pdfp Klasöründedir.";
            mainText += "\n\n" + "4) Projede Kriptografi Kullanılmıştır";
            mainText += "\n\n" + "5) Proje Dosyaları Kriptografi İle Korunmaktadır.";
            mainText += "\n\n" + "6) Projede 1 Adet Easter Egg Bulunmaktadır.";
            mainText += "\n\n" + "8) Projede 2 adet Nuget Kullanılmıştır. Geri Kalan Yazılımlar Bana Aittir";
            mainText += "\n\n" + "9) Projede Kullanılan Nugetler: Spire.PDF, Newtonsoft.Json";
            mainText += "\n\n" + "10) Proje Toplamda 1 Hafta Sürmüştür.";
            mainText += "\n\n" + "11) Proje Sırasında Covid-19 Virüsü Yüzünden Hasta Olunmuştur.";
            mainText += "\n\n" + "12) Kriptografi Şifresi Çok Değerli Fatih Hocama Bir Latifedir :)";
            mainText += "\n\n" + "13) Tasarım Konusunda Eğitime İhtiyacım Var :)";
            mainText += "\n\n" + "14) Data Dosyaları Tam Yolu: " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Pdfp\data.pdfp");
            label1.Text = mainText;
            label1.Height = 700;
        }

        private void homeCloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hakkinda_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void tabPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


    }
}
