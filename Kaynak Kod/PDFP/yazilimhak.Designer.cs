namespace programlamadillerifinal
{
    partial class yazilimhak
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
            this.tabPanel = new System.Windows.Forms.Panel();
            this.formHeader = new System.Windows.Forms.Label();
            this.homeCloseFormBtn = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPanel.SuspendLayout();
            this.pnlBody.SuspendLayout();
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
            this.tabPanel.Size = new System.Drawing.Size(400, 30);
            this.tabPanel.TabIndex = 1;
            this.tabPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPanel_MouseDown);
            // 
            // formHeader
            // 
            this.formHeader.AutoSize = true;
            this.formHeader.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.formHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.formHeader.Location = new System.Drawing.Point(10, 6);
            this.formHeader.Name = "formHeader";
            this.formHeader.Size = new System.Drawing.Size(153, 19);
            this.formHeader.TabIndex = 1;
            this.formHeader.Text = "Yazılım Hakkında";
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
            this.homeCloseFormBtn.Location = new System.Drawing.Point(370, 7);
            this.homeCloseFormBtn.Name = "homeCloseFormBtn";
            this.homeCloseFormBtn.Size = new System.Drawing.Size(16, 16);
            this.homeCloseFormBtn.TabIndex = 0;
            this.homeCloseFormBtn.UseVisualStyleBackColor = true;
            this.homeCloseFormBtn.Click += new System.EventHandler(this.homeCloseFormBtn_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Location = new System.Drawing.Point(0, 36);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(400, 416);
            this.pnlBody.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 100);
            this.label1.TabIndex = 0;
            // 
            // yazilimhak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(88)))), ((int)(((byte)(122)))));
            this.ClientSize = new System.Drawing.Size(400, 451);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.tabPanel);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "yazilimhak";
            this.ShowIcon = false;
            this.Text = "Proje Hakkında";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.hakkinda_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hakkinda_MouseDown);
            this.tabPanel.ResumeLayout(false);
            this.tabPanel.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.Label formHeader;
        private System.Windows.Forms.Button homeCloseFormBtn;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label label1;
    }
}