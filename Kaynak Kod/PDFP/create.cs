using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace programlamadillerifinal
{
    public partial class create : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public int pregX=0, pregY = 0;
        public home hm;
        public create()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        bool gonextpage = false;
        int progressbarpercent = 0;

        private void create_Load(object sender, EventArgs e)
        {
            this.Left = pregX; this.Top = pregY;
        }

        private void btnTezSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog tezSecDialog = new OpenFileDialog();
            tezSecDialog.Filter= "Pdf Files|*.pdf";
            tezSecDialog.Title = "Tez Dosyası Seç";
            tezSecDialog.CheckFileExists = true;
            tezSecDialog.CheckPathExists = true;
            tezSecDialog.Multiselect = false;
            if (tezSecDialog.ShowDialog() == DialogResult.OK)
            {
                txtTezDosyasiYolu.Text = tezSecDialog.FileName;
            }
        }


        private void btnBasla_Click(object sender, EventArgs e)
        {
            pbCreate.Visible = true;
            btnBasla.Enabled = false;
            txtProjeAdi.Enabled = false;
            txtTezDosyasiYolu.Enabled = false;
            txtTezSahibiAdi.Enabled = false;
            formclose.Visible = false;
            Thread thread1 = new Thread(new ThreadStart(islemleriYap));
            thread1.Start();
        }
        string projeAdi ,tezSahibi ,tezKonumu,tezIcerik;
        void islemleriYap()
        {
            projeAdi = txtProjeAdi.Text.Trim();
            tezSahibi = txtTezSahibiAdi.Text.Trim();
            tezKonumu = txtTezDosyasiYolu.Text.Trim();
            if (projeAdi != "" && tezSahibi != "" && tezKonumu != "")
            {
                if (File.Exists(tezKonumu))
                {
                    
                    FileInfo Uzanti = new FileInfo(tezKonumu);
                    string DosyaUzantisi = Uzanti.Extension;
                    if(DosyaUzantisi==".pdf")
                    {
                        progressbarpercent = 75;
                        tezIcerik = Pdftohtml.pdfextract(tezKonumu);
                        progressbarpercent = 100;
                        gonextpage = true;
                    }
                    else
                    {
                        MessageBox.Show("Tez Dosyası Sadece Pdf Formatında Kabul Edilir.");
                    }
                }
                else
                {
                    MessageBox.Show("Tez Dosyası Girilen Konumda Değil.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Yer Bırakmayınız.");
            }
        }


        private void create_MouseDown(object sender, MouseEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbCreate.Value = progressbarpercent;
            if (gonextpage)
            {
                timer1.Stop();
                Tez yeniTez = new Tez();
                yeniTez.projeAdi = projeAdi;
                yeniTez.projeRaporlar = "";
                yeniTez.IstatistikselBilgiler = "";
                yeniTez.tezSahibi = tezSahibi;
                yeniTez.projeTezIcerik = tezIcerik;
                DateTime dateTime = DateTime.UtcNow.Date;
                yeniTez.Tarih = dateTime.ToString("dd/MM/yyyy");
                rapor rp = new rapor();
                rp.pregX = this.Left;
                rp.pregY = this.Top;
                rp.thisTez = yeniTez;
                rp.newCreate = true;
                rp.hm = hm;
                rp.Show();
                this.Hide();
                this.Close();
            }
        }

        private void formclose_Click(object sender, EventArgs e)
        {
            this.Hide();
            hm.Top = this.Top;
            hm.Left = this.Left;
            hm.Show();
            this.Close();
        }
    }
}
