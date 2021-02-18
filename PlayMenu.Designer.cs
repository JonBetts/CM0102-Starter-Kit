
namespace CM0102_Starter_Kit {
    partial class PlayMenu {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.standard_cm = new System.Windows.Forms.Button();
            this.nick_patcher_cm = new System.Windows.Forms.Button();
            this.cm_93 = new System.Windows.Forms.Button();
            // 
            // standard_cm
            // 
            this.standard_cm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.standard_cm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.standard_cm.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.standard_cm.FlatAppearance.BorderSize = 2;
            this.standard_cm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.standard_cm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.standard_cm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.standard_cm.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.standard_cm.ForeColor = System.Drawing.Color.White;
            this.standard_cm.Location = new System.Drawing.Point(120, 144);
            this.standard_cm.Margin = new System.Windows.Forms.Padding(0);
            this.standard_cm.Name = "standard_cm";
            this.standard_cm.Size = new System.Drawing.Size(327, 65);
            this.standard_cm.TabStop = false;
            this.standard_cm.Text = "CM 01/02 (Standard)";
            this.standard_cm.UseVisualStyleBackColor = false;
            this.standard_cm.Click += new System.EventHandler(this.StandardCm_Click);
            // 
            // nick_patcher_cm
            // 
            this.nick_patcher_cm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nick_patcher_cm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nick_patcher_cm.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.nick_patcher_cm.FlatAppearance.BorderSize = 2;
            this.nick_patcher_cm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nick_patcher_cm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.nick_patcher_cm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nick_patcher_cm.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.nick_patcher_cm.ForeColor = System.Drawing.Color.White;
            this.nick_patcher_cm.Location = new System.Drawing.Point(449, 144);
            this.nick_patcher_cm.Margin = new System.Windows.Forms.Padding(0);
            this.nick_patcher_cm.Name = "nick_patcher_cm";
            this.nick_patcher_cm.Size = new System.Drawing.Size(327, 65);
            this.nick_patcher_cm.TabStop = false;
            this.nick_patcher_cm.Text = "CM 01/02 (With Nick\'s Patcher)";
            this.nick_patcher_cm.UseVisualStyleBackColor = false;
            this.nick_patcher_cm.Click += new System.EventHandler(this.NickPatcherCm_Click);
            // 
            // cm_93
            // 
            this.cm_93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm_93.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm_93.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm_93.FlatAppearance.BorderSize = 2;
            this.cm_93.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm_93.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm_93.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm_93.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm_93.ForeColor = System.Drawing.Color.White;
            this.cm_93.Location = new System.Drawing.Point(284, 211);
            this.cm_93.Margin = new System.Windows.Forms.Padding(0);
            this.cm_93.Name = "cm_93";
            this.cm_93.Size = new System.Drawing.Size(325, 65);
            this.cm_93.TabStop = false;
            this.cm_93.Text = "CM 93/94";
            this.cm_93.UseVisualStyleBackColor = false;
            this.cm_93.Click += new System.EventHandler(this.Cm93_Click);
            // 
            // PlayMenu
            // 
            this.BackgroundImage = Properties.Resources.boca;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.standard_cm);
            this.Controls.Add(this.nick_patcher_cm);
            this.Controls.Add(this.cm_93);
            this.Name = "PlayMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayMenu_FormClosed);
        }

        #endregion
        private System.Windows.Forms.Button standard_cm;
        private System.Windows.Forms.Button nick_patcher_cm;
        private System.Windows.Forms.Button cm_93;
    }
}

