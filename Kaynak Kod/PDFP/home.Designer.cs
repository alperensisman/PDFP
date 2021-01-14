namespace programlamadillerifinal
{
    partial class home
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPanel = new System.Windows.Forms.Panel();
            this.formHeader = new System.Windows.Forms.Label();
            this.homeCloseFormBtn = new System.Windows.Forms.Button();
            this.ColonLeft = new System.Windows.Forms.Panel();
            this.rowBottom = new System.Windows.Forms.Panel();
            this.rowTop = new System.Windows.Forms.Panel();
            this.btnAra = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAnaBaslik = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYeniProje = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.colonRight = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.btnCloud = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnEskiProje = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.homeRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.tabPanel.SuspendLayout();
            this.ColonLeft.SuspendLayout();
            this.rowTop.SuspendLayout();
            this.btnYeniProje.SuspendLayout();
            this.colonRight.SuspendLayout();
            this.btnCloud.SuspendLayout();
            this.btnEskiProje.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(29)))), ((int)(((byte)(64)))));
            this.tabPanel.Controls.Add(this.formHeader);
            this.tabPanel.Controls.Add(this.homeCloseFormBtn);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(800, 30);
            this.tabPanel.TabIndex = 0;
            this.tabPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPanel_MouseDown);
            // 
            // formHeader
            // 
            this.formHeader.AutoSize = true;
            this.formHeader.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.formHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.formHeader.Location = new System.Drawing.Point(10, 6);
            this.formHeader.Name = "formHeader";
            this.formHeader.Size = new System.Drawing.Size(54, 19);
            this.formHeader.TabIndex = 1;
            this.formHeader.Text = "PDF-P";
            this.formHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeCloseFormBtn
            // 
            this.homeCloseFormBtn.AutoEllipsis = true;
            this.homeCloseFormBtn.BackColor = System.Drawing.Color.Red;
            this.homeCloseFormBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeCloseFormBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.homeCloseFormBtn.FlatAppearance.BorderSize = 0;
            this.homeCloseFormBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.homeCloseFormBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.homeCloseFormBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeCloseFormBtn.Font = new System.Drawing.Font("Adobe Song Std L", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeCloseFormBtn.ForeColor = System.Drawing.Color.Red;
            this.homeCloseFormBtn.Location = new System.Drawing.Point(775, 7);
            this.homeCloseFormBtn.Name = "homeCloseFormBtn";
            this.homeCloseFormBtn.Size = new System.Drawing.Size(16, 16);
            this.homeCloseFormBtn.TabIndex = 0;
            this.homeCloseFormBtn.UseVisualStyleBackColor = true;
            this.homeCloseFormBtn.Click += new System.EventHandler(this.homeCloseFormBtn_Click);
            // 
            // ColonLeft
            // 
            this.ColonLeft.BackColor = System.Drawing.Color.Transparent;
            this.ColonLeft.Controls.Add(this.rowBottom);
            this.ColonLeft.Controls.Add(this.rowTop);
            this.ColonLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ColonLeft.Location = new System.Drawing.Point(0, 30);
            this.ColonLeft.Name = "ColonLeft";
            this.ColonLeft.Size = new System.Drawing.Size(423, 570);
            this.ColonLeft.TabIndex = 2;
            // 
            // rowBottom
            // 
            this.rowBottom.AutoScroll = true;
            this.rowBottom.BackColor = System.Drawing.Color.Transparent;
            this.rowBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rowBottom.Location = new System.Drawing.Point(0, 169);
            this.rowBottom.Name = "rowBottom";
            this.rowBottom.Padding = new System.Windows.Forms.Padding(1);
            this.rowBottom.Size = new System.Drawing.Size(423, 401);
            this.rowBottom.TabIndex = 1;
            // 
            // rowTop
            // 
            this.rowTop.Controls.Add(this.btnAra);
            this.rowTop.Controls.Add(this.txtAra);
            this.rowTop.Controls.Add(this.label4);
            this.rowTop.Controls.Add(this.lblAnaBaslik);
            this.rowTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.rowTop.Location = new System.Drawing.Point(0, 0);
            this.rowTop.Name = "rowTop";
            this.rowTop.Padding = new System.Windows.Forms.Padding(5);
            this.rowTop.Size = new System.Drawing.Size(423, 171);
            this.rowTop.TabIndex = 0;
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.White;
            this.btnAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAra.FlatAppearance.BorderSize = 0;
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAra.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Location = new System.Drawing.Point(342, 120);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(60, 30);
            this.btnAra.TabIndex = 3;
            this.btnAra.Text = "ARA";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(18, 121);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(318, 30);
            this.txtAra.TabIndex = 2;
            this.txtAra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAra_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(14, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Son Kullanılanları Aç";
            // 
            // lblAnaBaslik
            // 
            this.lblAnaBaslik.AutoSize = true;
            this.lblAnaBaslik.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnaBaslik.ForeColor = System.Drawing.Color.White;
            this.lblAnaBaslik.Location = new System.Drawing.Point(47, 16);
            this.lblAnaBaslik.Name = "lblAnaBaslik";
            this.lblAnaBaslik.Size = new System.Drawing.Size(303, 34);
            this.lblAnaBaslik.TabIndex = 0;
            this.lblAnaBaslik.Text = "Final Projesi 2020";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(8, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanmaya Başlayın";
            // 
            // btnYeniProje
            // 
            this.btnYeniProje.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnYeniProje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnYeniProje.Controls.Add(this.label6);
            this.btnYeniProje.Controls.Add(this.label5);
            this.btnYeniProje.Controls.Add(this.label3);
            this.btnYeniProje.Controls.Add(this.label2);
            this.btnYeniProje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniProje.Location = new System.Drawing.Point(12, 121);
            this.btnYeniProje.Name = "btnYeniProje";
            this.btnYeniProje.Size = new System.Drawing.Size(330, 80);
            this.btnYeniProje.TabIndex = 3;
            this.btnYeniProje.Paint += new System.Windows.Forms.PaintEventHandler(this.btnYeniProje_Paint);
            this.btnYeniProje.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnYeniProje_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(69, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "başlangıç bilgilerini giriniz.";
            this.label6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnYeniProje_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(69, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Başlamak için açılacak panelden ";
            this.label5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnYeniProje_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(68, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Yeni Proje Oluştur";
            this.label3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnYeniProje_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 56);
            this.label2.TabIndex = 0;
            this.label2.Text = "+";
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnYeniProje_MouseClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(238, 5);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(105, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Proje Hakkında";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // colonRight
            // 
            this.colonRight.BackColor = System.Drawing.Color.Transparent;
            this.colonRight.Controls.Add(this.linkLabel2);
            this.colonRight.Controls.Add(this.linkLabel1);
            this.colonRight.Controls.Add(this.btnCloud);
            this.colonRight.Controls.Add(this.btnEskiProje);
            this.colonRight.Controls.Add(this.btnYeniProje);
            this.colonRight.Controls.Add(this.label1);
            this.colonRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.colonRight.Location = new System.Drawing.Point(449, 30);
            this.colonRight.Name = "colonRight";
            this.colonRight.Padding = new System.Windows.Forms.Padding(5);
            this.colonRight.Size = new System.Drawing.Size(351, 570);
            this.colonRight.TabIndex = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(224, 554);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(119, 15);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Yazılım Hakkında";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // btnCloud
            // 
            this.btnCloud.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCloud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCloud.Controls.Add(this.label11);
            this.btnCloud.Controls.Add(this.label12);
            this.btnCloud.Controls.Add(this.label13);
            this.btnCloud.Controls.Add(this.label14);
            this.btnCloud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloud.Location = new System.Drawing.Point(12, 291);
            this.btnCloud.Name = "btnCloud";
            this.btnCloud.Size = new System.Drawing.Size(330, 80);
            this.btnCloud.TabIndex = 3;
            this.btnCloud.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCloud_MouseClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(69, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Halinde İndirin";
            this.label11.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCloud_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(69, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(247, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Eklenen Bütün Çalışmaları, Tek Bir Dosya";
            this.label12.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCloud_MouseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(69, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(210, 22);
            this.label13.TabIndex = 1;
            this.label13.Text = "Çalışmaları Saklayın";
            this.label13.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCloud_MouseClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(13, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 56);
            this.label14.TabIndex = 0;
            this.label14.Text = "¦";
            this.label14.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCloud_MouseClick);
            // 
            // btnEskiProje
            // 
            this.btnEskiProje.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEskiProje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEskiProje.Controls.Add(this.label7);
            this.btnEskiProje.Controls.Add(this.label8);
            this.btnEskiProje.Controls.Add(this.label9);
            this.btnEskiProje.Controls.Add(this.label10);
            this.btnEskiProje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEskiProje.Location = new System.Drawing.Point(12, 206);
            this.btnEskiProje.Name = "btnEskiProje";
            this.btnEskiProje.Size = new System.Drawing.Size(330, 80);
            this.btnEskiProje.TabIndex = 3;
            this.btnEskiProje.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label9_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(69, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = ".pdfp dosyası açın";
            this.label7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label9_MouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(69, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Yerel bir PDFP projesi veya";
            this.label8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label9_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(69, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(230, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "Projeyi veya Çözümü Aç";
            this.label9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label9_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(3, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 56);
            this.label10.TabIndex = 0;
            this.label10.Text = "{}";
            this.label10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label9_MouseClick);
            // 
            // homeRefreshTimer
            // 
            this.homeRefreshTimer.Enabled = true;
            this.homeRefreshTimer.Interval = 1000;
            this.homeRefreshTimer.Tick += new System.EventHandler(this.homeRefreshTimer_Tick);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.BackgroundImage = global::programlamadillerifinal.Properties.Resources.Backgraund;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ColonLeft);
            this.Controls.Add(this.colonRight);
            this.Controls.Add(this.tabPanel);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "home";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programlama Dilleri Final Projesi";
            this.Load += new System.EventHandler(this.home_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.home_MouseDown);
            this.tabPanel.ResumeLayout(false);
            this.tabPanel.PerformLayout();
            this.ColonLeft.ResumeLayout(false);
            this.rowTop.ResumeLayout(false);
            this.rowTop.PerformLayout();
            this.btnYeniProje.ResumeLayout(false);
            this.btnYeniProje.PerformLayout();
            this.colonRight.ResumeLayout(false);
            this.colonRight.PerformLayout();
            this.btnCloud.ResumeLayout(false);
            this.btnCloud.PerformLayout();
            this.btnEskiProje.ResumeLayout(false);
            this.btnEskiProje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.Button homeCloseFormBtn;
        private System.Windows.Forms.Label formHeader;
        private System.Windows.Forms.Panel ColonLeft;
        private System.Windows.Forms.Panel rowBottom;
        private System.Windows.Forms.Panel rowTop;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAnaBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel btnYeniProje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel colonRight;
        private System.Windows.Forms.Panel btnEskiProje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel btnCloud;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer homeRefreshTimer;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

