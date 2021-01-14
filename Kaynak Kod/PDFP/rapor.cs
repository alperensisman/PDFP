using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programlamadillerifinal
{
    public partial class rapor : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public rapor()
        {
            InitializeComponent();
            
        }


        public int pregX = 0, pregY = 0, Index = -1;
        public Tez thisTez;
        public home hm;
        public bool newCreate=false;
        bool progressStart = false;
        int progressPercent = 0;
        string progressText = "Proje Hazırlanıyor..";
        
        private void rapor_Load(object sender, EventArgs e)
        {
            this.Left = pregX; this.Top = pregY;
            formHeader.Text = thisTez.projeAdi + " - " + thisTez.tezSahibi;
            LoaderBaslat();
        }
        private void formclose_Click(object sender, EventArgs e)
        {
            datapdfp.DataKontrolVeYaOlustur();
            this.Hide();
            hm.Top = this.Top;
            hm.Left = this.Left;
            hm.homeRefresh = true;
            hm.Show();
            this.Close();
        }
        private void rapor_MouseDown(object sender, MouseEventArgs e)
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
        private void LoaderBaslat()
        {
            if(newCreate)
            {
                pnlLoader.MaximumSize = new Size(pnlBody.Width, pnlBody.Height);
                pnlLoader.Size = new Size(pnlBody.Width, pnlBody.Height);
                pnlLoader.Left = pnlBody.Left;
                pnlLoader.Top = pnlBody.Top;
                pnlLoader.Visible = true;
                pbLoader.Size = new Size(pnlBody.Width - 40, 23);
                pbLoader.Left = 20;
                pbLoader.Top = (pnlBody.Height / 2)+100;

                lblLoader.AutoSize = false;
                lblLoader.Top = pnlBody.Top;
                lblLoader.Dock = DockStyle.Top;
                lblLoader.Height = (pnlBody.Height / 2) + 70;
                lblLoader.TextAlign = ContentAlignment.MiddleCenter;

                pnlLoader.BringToFront();
                progressStart = true;
                tmProgress.Start();
                Thread thread1 = new Thread(new ThreadStart(yeniProje));
                thread1.Start();
            }
            else
            {
                Thread thread2 = new Thread(new ThreadStart(eskiProje));
                thread2.Start();
            }
        }
        private void LoaderDurdur()
        {
            pbLoader.Value = 0;
            lblLoader.Text = "";
            pnlLoader.SendToBack();
        }
        private void tmProgress_Tick(object sender, EventArgs e)
        {
            if (progressStart)
            {
                pbLoader.Value = progressPercent;
                lblLoader.Text = progressText;
            }
        }

        private void yeniProje()
        {
            formclose.Visible = false;
            newproj newProject = new newproj();
            newProject.RunIt(ref thisTez,ref progressPercent,ref progressText);
            listBoxRapor.Items.AddRange(thisTez.projeRaporlar.Split(new string[] { "&&" },StringSplitOptions.RemoveEmptyEntries));
            listBoxIsta.Items.AddRange(thisTez.IstatistikselBilgiler.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries));
            datapdfp._LASTDATAOBJECT.Add(thisTez);
            Index = datapdfp._LASTDATAOBJECT.Count - 1;
            datapdfp.AllTezToJson();
            LoaderDurdur();
            tmProgress.Stop();
            formclose.Visible = true;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           
            DialogResult dialogResult = MessageBox.Show("Bu Çözümü Silmek İstiyor Musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                datapdfp._LASTDATAOBJECT.RemoveAt(Index);
                datapdfp.AllTezToJson();
                datapdfp.DataKontrolVeYaOlustur();
                this.Hide();
                hm.Top = this.Top;
                hm.Left = this.Left;
                hm.homeRefresh = true;
                hm.Show();
                this.Close();
            }
        }

        private void btnMetinIndir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBD = new FolderBrowserDialog();
            fBD.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = fBD.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = fBD.SelectedPath;
                datapdfp.RaporKaydet(path,thisTez);
                MessageBox.Show("Veriler Bilgisayarınıza Kaydedildi.");
            }
            
        }



        delegate void InvokeDelegate();
        private void eskiProje()
        {
            formclose.BeginInvoke(new InvokeDelegate(()=> formclose.Visible = false));
            listBoxRapor.BeginInvoke(new InvokeDelegate(() => listBoxRapor.Items.AddRange(thisTez.projeRaporlar.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries))));
            listBoxIsta.BeginInvoke(new InvokeDelegate(() => listBoxIsta.Items.AddRange(thisTez.IstatistikselBilgiler.Split(new string[] { "&&" }, StringSplitOptions.RemoveEmptyEntries))));
            formclose.BeginInvoke(new InvokeDelegate(() => formclose.Visible = true));
            DateTime dateTime = DateTime.UtcNow.Date;
            thisTez.Tarih = dateTime.ToString("dd/MM/yyyy");
            datapdfp._LASTDATAOBJECT[Index] = thisTez;
            datapdfp.AllTezToJson();
        }



    }
}
