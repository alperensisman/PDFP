namespace programlamadillerifinal
{
    partial class create
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
            this.pbCreate = new System.Windows.Forms.ProgressBar();
            this.btnBasla = new System.Windows.Forms.Button();
            this.btnTezSec = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTezDosyasiYolu = new System.Windows.Forms.TextBox();
            this.txtTezSahibiAdi = new System.Windows.Forms.TextBox();
            this.txtProjeAdi = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPanel.SuspendLayout();
            this.pnlBody.SuspendLayout();
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
            this.tabPanel.TabIndex = 1;
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
            this.formclose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlBody.Controls.Add(this.pbCreate);
            this.pnlBody.Controls.Add(this.btnBasla);
            this.pnlBody.Controls.Add(this.btnTezSec);
            this.pnlBody.Controls.Add(this.label4);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.txtTezDosyasiYolu);
            this.pnlBody.Controls.Add(this.txtTezSahibiAdi);
            this.pnlBody.Controls.Add(this.txtProjeAdi);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 30);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(800, 570);
            this.pnlBody.TabIndex = 2;
            // 
            // pbCreate
            // 
            this.pbCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbCreate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pbCreate.Location = new System.Drawing.Point(0, 565);
            this.pbCreate.MarqueeAnimationSpeed = 1;
            this.pbCreate.Name = "pbCreate";
            this.pbCreate.Size = new System.Drawing.Size(800, 10);
            this.pbCreate.TabIndex = 4;
            this.pbCreate.Visible = false;
            // 
            // btnBasla
            // 
            this.btnBasla.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBasla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBasla.FlatAppearance.BorderSize = 0;
            this.btnBasla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasla.ForeColor = System.Drawing.Color.Black;
            this.btnBasla.Location = new System.Drawing.Point(690, 522);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(98, 40);
            this.btnBasla.TabIndex = 4;
            this.btnBasla.Text = "Başlayın";
            this.btnBasla.UseVisualStyleBackColor = false;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // btnTezSec
            // 
            this.btnTezSec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTezSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTezSec.FlatAppearance.BorderSize = 0;
            this.btnTezSec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTezSec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTezSec.Location = new System.Drawing.Point(627, 289);
            this.btnTezSec.Name = "btnTezSec";
            this.btnTezSec.Size = new System.Drawing.Size(48, 26);
            this.btnTezSec.TabIndex = 3;
            this.btnTezSec.Text = "…";
            this.btnTezSec.UseVisualStyleBackColor = false;
            this.btnTezSec.Click += new System.EventHandler(this.btnTezSec_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(121, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tez (PDF)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(121, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tez Sahibi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(121, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proje Adı";
            // 
            // txtTezDosyasiYolu
            // 
            this.txtTezDosyasiYolu.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTezDosyasiYolu.Location = new System.Drawing.Point(125, 289);
            this.txtTezDosyasiYolu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTezDosyasiYolu.Name = "txtTezDosyasiYolu";
            this.txtTezDosyasiYolu.Size = new System.Drawing.Size(500, 26);
            this.txtTezDosyasiYolu.TabIndex = 2;
            // 
            // txtTezSahibiAdi
            // 
            this.txtTezSahibiAdi.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTezSahibiAdi.Location = new System.Drawing.Point(125, 205);
            this.txtTezSahibiAdi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTezSahibiAdi.Name = "txtTezSahibiAdi";
            this.txtTezSahibiAdi.Size = new System.Drawing.Size(550, 26);
            this.txtTezSahibiAdi.TabIndex = 1;
            // 
            // txtProjeAdi
            // 
            this.txtProjeAdi.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtProjeAdi.Location = new System.Drawing.Point(125, 120);
            this.txtProjeAdi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtProjeAdi.Name = "txtProjeAdi";
            this.txtProjeAdi.Size = new System.Drawing.Size(550, 26);
            this.txtProjeAdi.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.BackgroundImage = global::programlamadillerifinal.Properties.Resources.Backgraund;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.tabPanel);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "create";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.create_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.create_MouseDown);
            this.tabPanel.ResumeLayout(false);
            this.tabPanel.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.Label formHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label formclose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjeAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTezSahibiAdi;
        private System.Windows.Forms.Button btnTezSec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTezDosyasiYolu;
        private System.Windows.Forms.Button btnBasla;
        private System.Windows.Forms.ProgressBar pbCreate;
        private System.Windows.Forms.Timer timer1;
    }
}