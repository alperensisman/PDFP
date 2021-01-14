using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programlamadillerifinal
{
    public partial class home : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public home()
        {
            InitializeComponent();
        }
        public bool homeRefresh = false;
        private void home_Load(object sender, EventArgs e)
        {
            
            Template tmp = new Template();
            

            btnAra.BackColor = tmp.buttonArkaPlanColor;
            btnAra.ForeColor = tmp.buttonFontColor;

            btnYeniProje.BackColor = tmp.buttonArkaPlanColor;
            btnYeniProje.ForeColor = tmp.buttonFontColor;
            

            btnEskiProje.BackColor = tmp.buttonArkaPlanColor;
            btnEskiProje.ForeColor = tmp.buttonFontColor;

            btnCloud.BackColor = tmp.buttonArkaPlanColor;
            btnCloud.ForeColor = tmp.buttonFontColor;

            datapdfp.DataKontrolVeYaOlustur();
            OncekiProjeleriYerlestir();
        }

        private void OncekiProjeleriYerlestir()
        {
            //rowBottom
            if (datapdfp._LASTDATAOBJECT == null)
                return;
            Template tmp = new Template();
            for (int i = 0; i < datapdfp._LASTDATAOBJECT.Count; i++)
            {
                Tez oldTez = (Tez)datapdfp._LASTDATAOBJECT[i];
                Panel newPanel = new Panel();
                newPanel.Name = "old_" + i.ToString();
                newPanel.BackColor = Color.WhiteSmoke;
                newPanel.Parent = rowBottom;
                newPanel.Size = new Size(rowBottom.Width-40, 70);
                newPanel.Left = 20;
                newPanel.Top = (i * 80)+10;
                Label newLabel = new Label();
                newLabel.Name = "lbold_" + i.ToString();
                newLabel.Parent = newPanel;
                newLabel.AutoSize = true;
                newLabel.BackColor = Color.WhiteSmoke;
                newLabel.TextAlign = ContentAlignment.MiddleLeft;
                newLabel.ForeColor= tmp.buttonFontColor;
                newLabel.Font = label3.Font;
                newLabel.Left = 10;
                newLabel.Top = 10;
                string baslik = "Ad: " + oldTez.projeAdi;
                if (baslik.Length > 36)
                    baslik = baslik.Substring(0, 33) + "...";
                newLabel.Text = baslik;
                Label newLabel2 = new Label();
                newLabel2.Name = "lb2old_" + i.ToString();
                newLabel2.Parent = newPanel;
                newLabel2.AutoSize = true;
                newLabel2.BackColor = Color.WhiteSmoke;
                newLabel2.TextAlign = ContentAlignment.MiddleLeft;
                newLabel2.ForeColor = tmp.buttonFontColor;
                newLabel2.Left = 10;
                newLabel2.Top = 40;
                newLabel2.Font = label5.Font;
                newLabel2.Text = "Son Kullanım: " + oldTez.Tarih;

                newPanel.Cursor = Cursors.Hand;
                newLabel.Cursor = Cursors.Hand;
                newLabel2.Cursor = Cursors.Hand;

                newPanel.MouseClick += OldProjeAc;
                newLabel.MouseClick += OldProjeAc;
                newLabel2.MouseClick += OldProjeAc;

                rowBottom.Controls.Add(newPanel);
            }
        }

        void OldProjeAc(object sender, MouseEventArgs e)
        {
            Type tip = sender.GetType();
            int Index = -1;
            if(tip.Name=="Panel")
            {
                Panel pnl = (Panel)sender;
                Index = Convert.ToInt32(pnl.Name.Split('_')[1]);
            }
            else if (tip.Name == "Label")
            {
                Label lbl = (Label)sender;
                Index = Convert.ToInt32(lbl.Name.Split('_')[1]);
            }

            rapor rp = new rapor();
            rp.pregX = this.Left;
            rp.pregY = this.Top;
            rp.Index = Index;
            rp.thisTez = (Tez)datapdfp._LASTDATAOBJECT[Index];
            rp.newCreate = false;
            rp.hm = this;
            rp.Show();
            this.Hide();
        }


        private void home_MouseDown(object sender, MouseEventArgs e)
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

        private void homeCloseFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            AramaYap();
        }


        void AramaYap()
        {
            string araText = txtAra.Text.Trim().ToLower();
            if (araText == "")
            {
                rowBottom.Controls.Clear();
                OncekiProjeleriYerlestir();
            }
            else if (araText == "fatih özkaynak")
            {
                MessageBox.Show("Seviliyorsunuz Sayın Fatih Özkaynak :) ");
            }
            else
            {
                rowBottom.Controls.Clear();
                ArrayList araProje = new ArrayList();
                for (int i = 0; i < datapdfp._LASTDATAOBJECT.Count; i++)
                {
                    Tez tz = (Tez)datapdfp._LASTDATAOBJECT[i];
                    if (tz.projeAdi.ToLower().IndexOf(araText) > -1)
                    {
                        araProje.Add(tz);
                    }
                }

                Template tmp = new Template();
                for (int i = 0; i < araProje.Count; i++)
                {
                    Tez oldTez = (Tez)araProje[i];
                    Panel newPanel = new Panel();
                    newPanel.Name = "old_" + i.ToString();
                    newPanel.BackColor = Color.WhiteSmoke;
                    newPanel.Parent = rowBottom;
                    newPanel.Size = new Size(rowBottom.Width - 40, 70);
                    newPanel.Left = 20;
                    newPanel.Top = (i * 80) + 10;
                    Label newLabel = new Label();
                    newLabel.Name = "lbold_" + i.ToString();
                    newLabel.Parent = newPanel;
                    newLabel.AutoSize = true;
                    newLabel.BackColor = Color.WhiteSmoke;
                    newLabel.TextAlign = ContentAlignment.MiddleLeft;
                    newLabel.ForeColor = tmp.buttonFontColor;
                    newLabel.Font = label3.Font;
                    newLabel.Left = 10;
                    newLabel.Top = 10;
                    string baslik = "Ad: " + oldTez.projeAdi;
                    if (baslik.Length > 36)
                        baslik = baslik.Substring(0, 33) + "...";
                    newLabel.Text = baslik;
                    Label newLabel2 = new Label();
                    newLabel2.Name = "lb2old_" + i.ToString();
                    newLabel2.Parent = newPanel;
                    newLabel2.AutoSize = true;
                    newLabel2.BackColor = Color.WhiteSmoke;
                    newLabel2.TextAlign = ContentAlignment.MiddleLeft;
                    newLabel2.ForeColor = tmp.buttonFontColor;
                    newLabel2.Left = 10;
                    newLabel2.Top = 40;
                    newLabel2.Font = label5.Font;
                    newLabel2.Text = "Son Kullanım: " + oldTez.Tarih;

                    newPanel.Cursor = Cursors.Hand;
                    newLabel.Cursor = Cursors.Hand;
                    newLabel2.Cursor = Cursors.Hand;

                    newPanel.MouseClick += OldProjeAc;
                    newLabel.MouseClick += OldProjeAc;
                    newLabel2.MouseClick += OldProjeAc;

                    rowBottom.Controls.Add(newPanel);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hakkinda hk = new hakkinda();
            hk.ShowDialog();
        }


        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            yeniProje();
        }
        void yeniProje()
        {
            create yeniProjeClass = new create();
            yeniProjeClass.pregX = this.Left;
            yeniProjeClass.pregY = this.Top;
            yeniProjeClass.hm = this;
            yeniProjeClass.Show();
            this.Hide();
        }

        private void homeRefreshTimer_Tick(object sender, EventArgs e)
        {
            if(homeRefresh)
            {
                rowBottom.Controls.Clear();
                OncekiProjeleriYerlestir();
                homeRefresh = false;
            }
        }

        private void btnCloud_MouseClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog fBD = new FolderBrowserDialog();
            fBD.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = fBD.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = fBD.SelectedPath;
                datapdfp.cloudProjects(path);
                MessageBox.Show("Projeleri Bilgisayarınıza İndirdiniz.");
            }
        }

        private void btnYeniProje_MouseClick(object sender, MouseEventArgs e)
        {
            yeniProje();
        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dataSecDialog = new OpenFileDialog();
            dataSecDialog.Filter = "PDFP Projects|*.pdfp";
            dataSecDialog.InitialDirectory = @"C:\";
            dataSecDialog.Title = "PDFP(.pdfp) Dosyası Seç";
            dataSecDialog.CheckFileExists = true;
            dataSecDialog.CheckPathExists = true;
            dataSecDialog.Multiselect = false;
            if (dataSecDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = dataSecDialog.FileName;
                datapdfp.CozumProjectsAdd(dosyaYolu);
                homeRefresh = true;
                MessageBox.Show("Başarıyla Eklenmiştir.");

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            yazilimhak hk = new yazilimhak();
            hk.ShowDialog();
        }

        private void txtAra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AramaYap();
            }
        }

        private void btnYeniProje_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
