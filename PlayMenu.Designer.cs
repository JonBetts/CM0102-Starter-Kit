namespace CM0102_Starter_Kit {
    partial class PlayMenu {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cm0102_standard = new System.Windows.Forms.Button();
            this.cm0102_nick_patcher = new System.Windows.Forms.Button();
            this.cm0102_retro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cm0102_standard
            // 
            this.cm0102_standard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm0102_standard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm0102_standard.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm0102_standard.FlatAppearance.BorderSize = 2;
            this.cm0102_standard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm0102_standard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm0102_standard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm0102_standard.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm0102_standard.ForeColor = System.Drawing.Color.White;
            this.cm0102_standard.Location = new System.Drawing.Point(120, 144);
            this.cm0102_standard.Margin = new System.Windows.Forms.Padding(0);
            this.cm0102_standard.Name = "cm0102_standard";
            this.cm0102_standard.Size = new System.Drawing.Size(327, 65);
            this.cm0102_standard.TabIndex = 0;
            this.cm0102_standard.TabStop = false;
            this.cm0102_standard.Text = "CM 01/02 (Standard)";
            this.cm0102_standard.UseVisualStyleBackColor = false;
            this.cm0102_standard.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // cm0102_nick_patcher
            // 
            this.cm0102_nick_patcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm0102_nick_patcher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm0102_nick_patcher.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm0102_nick_patcher.FlatAppearance.BorderSize = 2;
            this.cm0102_nick_patcher.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm0102_nick_patcher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm0102_nick_patcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm0102_nick_patcher.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm0102_nick_patcher.ForeColor = System.Drawing.Color.White;
            this.cm0102_nick_patcher.Location = new System.Drawing.Point(449, 144);
            this.cm0102_nick_patcher.Margin = new System.Windows.Forms.Padding(0);
            this.cm0102_nick_patcher.Name = "cm0102_nick_patcher";
            this.cm0102_nick_patcher.Size = new System.Drawing.Size(327, 65);
            this.cm0102_nick_patcher.TabIndex = 1;
            this.cm0102_nick_patcher.TabStop = false;
            this.cm0102_nick_patcher.Text = "CM 01/02 (Nick\'s Patcher)";
            this.cm0102_nick_patcher.UseVisualStyleBackColor = false;
            this.cm0102_nick_patcher.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // cm0102_retro
            // 
            this.cm0102_retro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm0102_retro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm0102_retro.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm0102_retro.FlatAppearance.BorderSize = 2;
            this.cm0102_retro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm0102_retro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm0102_retro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm0102_retro.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm0102_retro.ForeColor = System.Drawing.Color.White;
            this.cm0102_retro.Location = new System.Drawing.Point(285, 211);
            this.cm0102_retro.Margin = new System.Windows.Forms.Padding(0);
            this.cm0102_retro.Name = "cm0102_retro";
            this.cm0102_retro.Size = new System.Drawing.Size(327, 65);
            this.cm0102_retro.TabIndex = 2;
            this.cm0102_retro.TabStop = false;
            this.cm0102_retro.Text = "CM 01/02 (Retro)";
            this.cm0102_retro.UseVisualStyleBackColor = false;
            this.cm0102_retro.Visible = false;
            this.cm0102_retro.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PlayMenu
            // 
            this.BackgroundImage = global::CM0102_Starter_Kit.Properties.Resources.boca;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.cm0102_standard);
            this.Controls.Add(this.cm0102_nick_patcher);
            this.Controls.Add(this.cm0102_retro);
            this.Name = "PlayMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cm0102_standard;
        private System.Windows.Forms.Button cm0102_nick_patcher;
        private System.Windows.Forms.Button cm0102_retro;
    }
}

