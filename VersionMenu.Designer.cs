using static CM0102_Starter_Kit.Helper;

namespace CM0102_Starter_Kit {
    partial class VersionMenu {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.april_database = new System.Windows.Forms.Button();
            this.original_database = new System.Windows.Forms.Button();
            this.patched_database = new System.Windows.Forms.Button();
            this.october_database = new System.Windows.Forms.Button();
            this.november_database = new System.Windows.Forms.Button();
            this.luessenhoff_database = new System.Windows.Forms.Button();
            this.cm89_database = new System.Windows.Forms.Button();
            this.cm93_database = new System.Windows.Forms.Button();
            this.cm95_database = new System.Windows.Forms.Button();
            this.cm3_database = new System.Windows.Forms.Button();
            this.save_database = new System.Windows.Forms.Button();
            this.load_database = new System.Windows.Forms.Button();
            this.saveDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // april_database
            // 
            this.april_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.april_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.april_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.april_database.FlatAppearance.BorderSize = 2;
            this.april_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.april_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.april_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.april_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.april_database.ForeColor = System.Drawing.Color.White;
            this.april_database.Location = new System.Drawing.Point(120, 144);
            this.april_database.Margin = new System.Windows.Forms.Padding(0);
            this.april_database.Name = "april_database";
            this.april_database.Size = new System.Drawing.Size(327, 65);
            this.april_database.TabIndex = 0;
            this.april_database.TabStop = false;
            this.april_database.Text = "April 2021";
            this.april_database.UseVisualStyleBackColor = false;
            this.april_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // original_database
            // 
            this.original_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.original_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.original_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.original_database.FlatAppearance.BorderSize = 2;
            this.original_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.original_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.original_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.original_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.original_database.ForeColor = System.Drawing.Color.White;
            this.original_database.Location = new System.Drawing.Point(120, 211);
            this.original_database.Margin = new System.Windows.Forms.Padding(0);
            this.original_database.Name = "original_database";
            this.original_database.Size = new System.Drawing.Size(327, 65);
            this.original_database.TabIndex = 2;
            this.original_database.TabStop = false;
            this.original_database.Text = "Original (3.9.60)";
            this.original_database.UseVisualStyleBackColor = false;
            this.original_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // patched_database
            // 
            this.patched_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.patched_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patched_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.patched_database.FlatAppearance.BorderSize = 2;
            this.patched_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.patched_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.patched_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patched_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.patched_database.ForeColor = System.Drawing.Color.White;
            this.patched_database.Location = new System.Drawing.Point(449, 211);
            this.patched_database.Margin = new System.Windows.Forms.Padding(0);
            this.patched_database.Name = "patched_database";
            this.patched_database.Size = new System.Drawing.Size(327, 65);
            this.patched_database.TabIndex = 3;
            this.patched_database.TabStop = false;
            this.patched_database.Text = "Patched (3.9.68)";
            this.patched_database.UseVisualStyleBackColor = false;
            this.patched_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // october_database
            // 
            this.october_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.october_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.october_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.october_database.FlatAppearance.BorderSize = 2;
            this.october_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.october_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.october_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.october_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.october_database.ForeColor = System.Drawing.Color.White;
            this.october_database.Location = new System.Drawing.Point(449, 144);
            this.october_database.Margin = new System.Windows.Forms.Padding(0);
            this.october_database.Name = "october_database";
            this.october_database.Size = new System.Drawing.Size(327, 65);
            this.october_database.TabIndex = 4;
            this.october_database.TabStop = false;
            this.october_database.Text = "October 2021";
            this.october_database.UseVisualStyleBackColor = false;
            this.october_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // november_database
            // 
            this.november_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.november_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.november_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.november_database.FlatAppearance.BorderSize = 2;
            this.november_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.november_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.november_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.november_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.november_database.ForeColor = System.Drawing.Color.White;
            this.november_database.Location = new System.Drawing.Point(449, 278);
            this.november_database.Margin = new System.Windows.Forms.Padding(0);
            this.november_database.Name = "november_database";
            this.november_database.Size = new System.Drawing.Size(327, 65);
            this.november_database.TabIndex = 5;
            this.november_database.TabStop = false;
            this.november_database.Text = "November 2020";
            this.november_database.UseVisualStyleBackColor = false;
            this.november_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // luessenhoff_database
            // 
            this.luessenhoff_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.luessenhoff_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.luessenhoff_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.luessenhoff_database.FlatAppearance.BorderSize = 2;
            this.luessenhoff_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.luessenhoff_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.luessenhoff_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.luessenhoff_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.luessenhoff_database.ForeColor = System.Drawing.Color.White;
            this.luessenhoff_database.Location = new System.Drawing.Point(120, 278);
            this.luessenhoff_database.Margin = new System.Windows.Forms.Padding(0);
            this.luessenhoff_database.Name = "luessenhoff_database";
            this.luessenhoff_database.Size = new System.Drawing.Size(327, 65);
            this.luessenhoff_database.TabIndex = 1;
            this.luessenhoff_database.TabStop = false;
            this.luessenhoff_database.Text = "Luessenhoff";
            this.luessenhoff_database.UseVisualStyleBackColor = false;
            this.luessenhoff_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // cm89_database
            // 
            this.cm89_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm89_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm89_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm89_database.FlatAppearance.BorderSize = 2;
            this.cm89_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm89_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm89_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm89_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm89_database.ForeColor = System.Drawing.Color.White;
            this.cm89_database.Location = new System.Drawing.Point(120, 345);
            this.cm89_database.Margin = new System.Windows.Forms.Padding(0);
            this.cm89_database.Name = "cm89_database";
            this.cm89_database.Size = new System.Drawing.Size(327, 65);
            this.cm89_database.TabIndex = 6;
            this.cm89_database.TabStop = false;
            this.cm89_database.Text = "1989/90";
            this.cm89_database.UseVisualStyleBackColor = false;
            this.cm89_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // cm93_database
            // 
            this.cm93_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm93_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm93_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm93_database.FlatAppearance.BorderSize = 2;
            this.cm93_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm93_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm93_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm93_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm93_database.ForeColor = System.Drawing.Color.White;
            this.cm93_database.Location = new System.Drawing.Point(449, 345);
            this.cm93_database.Margin = new System.Windows.Forms.Padding(0);
            this.cm93_database.Name = "cm93_database";
            this.cm93_database.Size = new System.Drawing.Size(327, 65);
            this.cm93_database.TabIndex = 7;
            this.cm93_database.TabStop = false;
            this.cm93_database.Text = "1993/94";
            this.cm93_database.UseVisualStyleBackColor = false;
            this.cm93_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // cm95_database
            // 
            this.cm95_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm95_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm95_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm95_database.FlatAppearance.BorderSize = 2;
            this.cm95_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm95_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm95_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm95_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm95_database.ForeColor = System.Drawing.Color.White;
            this.cm95_database.Location = new System.Drawing.Point(120, 412);
            this.cm95_database.Margin = new System.Windows.Forms.Padding(0);
            this.cm95_database.Name = "cm95_database";
            this.cm95_database.Size = new System.Drawing.Size(327, 65);
            this.cm95_database.TabIndex = 8;
            this.cm95_database.TabStop = false;
            this.cm95_database.Text = "1995/96";
            this.cm95_database.UseVisualStyleBackColor = false;
            this.cm95_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // cm3_database
            // 
            this.cm3_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm3_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cm3_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.cm3_database.FlatAppearance.BorderSize = 2;
            this.cm3_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cm3_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cm3_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cm3_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.cm3_database.ForeColor = System.Drawing.Color.White;
            this.cm3_database.Location = new System.Drawing.Point(449, 412);
            this.cm3_database.Margin = new System.Windows.Forms.Padding(0);
            this.cm3_database.Name = "cm3_database";
            this.cm3_database.Size = new System.Drawing.Size(327, 65);
            this.cm3_database.TabIndex = 9;
            this.cm3_database.TabStop = false;
            this.cm3_database.Text = "1998/99";
            this.cm3_database.UseVisualStyleBackColor = false;
            this.cm3_database.Click += new System.EventHandler(this.SwitchDatabase_Click);
            // 
            // save_database
            // 
            this.save_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.save_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.save_database.FlatAppearance.BorderSize = 2;
            this.save_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.save_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.save_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.save_database.ForeColor = System.Drawing.Color.White;
            this.save_database.Location = new System.Drawing.Point(120, 479);
            this.save_database.Margin = new System.Windows.Forms.Padding(0);
            this.save_database.Name = "save_database";
            this.save_database.Size = new System.Drawing.Size(327, 65);
            this.save_database.TabIndex = 10;
            this.save_database.TabStop = false;
            this.save_database.Text = "Save Custom Database";
            this.save_database.UseVisualStyleBackColor = false;
            this.save_database.Click += new System.EventHandler(this.SaveDatabase_Click);
            // 
            // load_database
            // 
            this.load_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.load_database.Cursor = System.Windows.Forms.Cursors.Hand;
            this.load_database.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.load_database.FlatAppearance.BorderSize = 2;
            this.load_database.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.load_database.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.load_database.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.load_database.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.load_database.ForeColor = System.Drawing.Color.White;
            this.load_database.Location = new System.Drawing.Point(449, 479);
            this.load_database.Margin = new System.Windows.Forms.Padding(0);
            this.load_database.Name = "load_database";
            this.load_database.Size = new System.Drawing.Size(327, 65);
            this.load_database.TabIndex = 11;
            this.load_database.TabStop = false;
            this.load_database.Text = "Load Custom Database";
            this.load_database.UseVisualStyleBackColor = false;
            this.load_database.Click += new System.EventHandler(this.LoadDatabase_Click);
            // 
            // saveDatabaseDialog
            // 
            this.saveDatabaseDialog.Filter = "Zip file (*.zip)|*.zip";
            this.saveDatabaseDialog.Title = "Save Custom Database";
            this.saveDatabaseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveDatabaseDialog_FileOk);
            // 
            // loadDatabaseDialog
            // 
            this.loadDatabaseDialog.Filter = "Zip file (*.zip)|*.zip";
            this.loadDatabaseDialog.Title = "Load Custom Database";
            this.loadDatabaseDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadDatabaseDialog_FileOk);
            // 
            // VersionMenu
            // 
            this.BackgroundImage = global::CM0102_Starter_Kit.Properties.Resources.owen;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.april_database);
            this.Controls.Add(this.original_database);
            this.Controls.Add(this.patched_database);
            this.Controls.Add(this.october_database);
            this.Controls.Add(this.november_database);
            this.Controls.Add(this.luessenhoff_database);
            this.Controls.Add(this.cm89_database);
            this.Controls.Add(this.cm93_database);
            this.Controls.Add(this.cm95_database);
            this.Controls.Add(this.cm3_database);
            this.Controls.Add(this.save_database);
            this.Controls.Add(this.load_database);
            this.Name = "VersionMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VersionMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button april_database;
        private System.Windows.Forms.Button original_database;
        private System.Windows.Forms.Button patched_database;
        private System.Windows.Forms.Button october_database;
        private System.Windows.Forms.Button november_database;
        private System.Windows.Forms.Button luessenhoff_database;
        private System.Windows.Forms.Button cm89_database;
        private System.Windows.Forms.Button cm93_database;
        private System.Windows.Forms.Button cm95_database;
        private System.Windows.Forms.Button cm3_database;
        private System.Windows.Forms.Button save_database;
        private System.Windows.Forms.Button load_database;
        private System.Windows.Forms.SaveFileDialog saveDatabaseDialog;
        private System.Windows.Forms.OpenFileDialog loadDatabaseDialog;
    }
}

