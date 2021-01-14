namespace programlamadillerifinal
{
    partial class rapor
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
            this.tabPanel = new System.Windows.Forms.Panel();
            this.formclose = new System.Windows.Forms.Label();
            this.formHeader = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnMetinIndir = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxIsta = new System.Windows.Forms.ListBox();
            this.listBoxRapor = new System.Windows.Forms.ListBox();
            this.pnlLoader = new System.Windows.Forms.Panel();
            this.lblLoader = new System.Windows.Forms.Label();
            this.pbLoader = new System.Windows.Forms.ProgressBar();
            this.tmProgress = new System.Windows.Forms.Timer(this.components);
            this.tabPanel.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlLoader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(29)))), ((int)(((byte)(64)))));
            this.tabPanel.Controls.Add(this.formclose);
            this.tabPanel.Controls.Add(this.formHeader);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(800, 30);
            this.tabPanel.TabIndex = 2;
            this.tabPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPanel_MouseDown);
            // 
            // formclose
            // 
            this.formclose.BackColor = System.Drawing.Color.Transparent;
            this.formclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.formclose.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formclose.ForeColor = System.Drawing.Color.White;
            this.formclose.Image = global::programlamadillerifinal.Properties.Resources.bckbtn;
            this.formclose.Location = new System.Drawing.Point(775, 5);
            this.formclose.Name = "formclose";
            this.formclose.Size = new System.Drawing.Size(20, 20);
            this.formclose.TabIndex = 2;
            this.formclose.Click += new System.EventHandler(this.formclose_Click);
            // 
            // formHeader
            // 
            this.formHeader.AutoSize = true;
            this.formHeader.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.formHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.formHeader.Location = new System.Drawing.Point(10, 6);
            this.formHeader.Name = "formHeader";
            this.formHeader.Size = new System.Drawing.Size(171, 19);
            this.formHeader.TabIndex = 1;
            this.formHeader.Text = "Yeni Proje Oluştur";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.btnMetinIndir);
            this.pnlBody.Controls.Add(this.btnSil);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.listBoxIsta);
            this.pnlBody.Controls.Add(this.listBoxRapor);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBody.Location = new System.Drawing.Point(0, 31);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(800, 569);
            this.pnlBody.TabIndex = 3;
            // 
            // btnMetinIndir
            // 
            this.btnMetinIndir.BackColor = System.Drawing.Color.White;
            this.btnMetinIndir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMetinIndir.FlatAppearance.BorderSize = 0;
            this.btnMetinIndir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMetinIndir.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMetinIndir.ForeColor = System.Drawing.Color.DimGray;
            this.btnMetinIndir.Location = new System.Drawing.Point(322, 38);
            this.btnMetinIndir.Name = "btnMetinIndir";
            this.btnMetinIndir.Size = new System.Drawing.Size(156, 41);
            this.btnMetinIndir.TabIndex = 4;
            this.btnMetinIndir.Text = "Verileri Kaydet";
            this.btnMetinIndir.UseVisualStyleBackColor = false;
            this.btnMetinIndir.Click += new System.EventHandler(this.btnMetinIndir_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Red;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSil.Location = new System.Drawing.Point(322, 519);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(156, 41);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Bu Çözümü Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(579, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "İstatistikler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(119, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Raporlar";
            // 
            // listBoxIsta
            // 
            this.listBoxIsta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(29)))), ((int)(((byte)(64)))));
            this.listBoxIsta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxIsta.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxIsta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxIsta.FormattingEnabled = true;
            this.listBoxIsta.HorizontalScrollbar = true;
            this.listBoxIsta.ItemHeight = 18;
            this.listBoxIsta.Location = new System.Drawing.Point(484, 38);
            this.listBoxIsta.Name = "listBoxIsta";
            this.listBoxIsta.Size = new System.Drawing.Size(304, 522);
            this.listBoxIsta.TabIndex = 0;
            // 
            // listBoxRapor
            // 
            this.listBoxRapor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(29)))), ((int)(((byte)(64)))));
            this.listBoxRapor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxRapor.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxRapor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxRapor.FormattingEnabled = true;
            this.listBoxRapor.HorizontalScrollbar = true;
            this.listBoxRapor.ItemHeight = 18;
            this.listBoxRapor.Location = new System.Drawing.Point(12, 38);
            this.listBoxRapor.Name = "listBoxRapor";
            this.listBoxRapor.Size = new System.Drawing.Size(304, 522);
            this.listBoxRapor.TabIndex = 0;
            // 
            // pnlLoader
            // 
            this.pnlLoader.BackgroundImage = global::programlamadillerifinal.Properties.Resources.Backgraund;
            this.pnlLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLoader.Controls.Add(this.lblLoader);
            this.pnlLoader.Controls.Add(this.pbLoader);
            this.pnlLoader.Location = new System.Drawing.Point(756, 28);
            this.pnlLoader.Name = "pnlLoader";
            this.pnlLoader.Size = new System.Drawing.Size(32, 27);
            this.pnlLoader.TabIndex = 1;
            // 
            // lblLoader
            // 
            this.lblLoader.AutoSize = true;
            this.lblLoader.BackColor = System.Drawing.Color.Transparent;
            this.lblLoader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLoader.Location = new System.Drawing.Point(11, 11);
            this.lblLoader.Name = "lblLoader";
            this.lblLoader.Size = new System.Drawing.Size(70, 22);
            this.lblLoader.TabIndex = 1;
            this.lblLoader.Text = "label1";
            // 
            // pbLoader
            // 
            this.pbLoader.Location = new System.Drawing.Point(15, 36);
            this.pbLoader.Maximum = 250;
            this.pbLoader.Name = "pbLoader";
            this.pbLoader.Size = new System.Drawing.Size(66, 23);
            this.pbLoader.TabIndex = 0;
            // 
            // tmProgress
            // 
            this.tmProgress.Tick += new System.EventHandler(this.tmProgress_Tick);
            // 
            // rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.BackgroundImage = global::programlamadillerifinal.Properties.Resources.Backgraund;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.pnlLoader);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "rapor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rapor";
            this.Load += new System.EventHandler(this.rapor_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rapor_MouseDown);
            this.tabPanel.ResumeLayout(false);
            this.tabPanel.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlLoader.ResumeLayout(false);
            this.pnlLoader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.Label formclose;
        private System.Windows.Forms.Label formHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLoader;
        private System.Windows.Forms.Label lblLoader;
        private System.Windows.Forms.ProgressBar pbLoader;
        private System.Windows.Forms.Timer tmProgress;
        private System.Windows.Forms.ListBox listBoxRapor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxIsta;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnMetinIndir;
    }
}