
namespace CM0102_Starter_Kit {
    partial class NickPatcherMenu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.loader = new System.Windows.Forms.PictureBox();
            this.starting_year_label = new System.Windows.Forms.Label();
            this.starting_year = new System.Windows.Forms.NumericUpDown();
            this.game_speed_label = new System.Windows.Forms.Label();
            this.game_speed = new System.Windows.Forms.ComboBox();
            this.currency_inflation_label = new System.Windows.Forms.Label();
            this.currency_inflation = new System.Windows.Forms.NumericUpDown();
            this.coloured_attributes = new System.Windows.Forms.CheckBox();
            this.resolution = new System.Windows.Forms.CheckBox();
            this.work_permits = new System.Windows.Forms.CheckBox();
            this.non_public_bids = new System.Windows.Forms.CheckBox();
            this.seven_substitutes = new System.Windows.Forms.CheckBox();
            this.unprotected_contracts = new System.Windows.Forms.CheckBox();
            this.foreign_player_limit = new System.Windows.Forms.CheckBox();
            this.apply = new System.Windows.Forms.Button();
            this.transparent_panel = new System.Windows.Forms.PictureBox();
            this.version = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.sidenav = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.title_bar = new System.Windows.Forms.PictureBox();
            this.subtitle = new System.Windows.Forms.Label();
            this.subtitle_bar = new System.Windows.Forms.PictureBox();
            this.back_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starting_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currency_inflation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparent_panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidenav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtitle_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // loader
            // 
            this.loader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.loader.Location = new System.Drawing.Point(0, 0);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(794, 578);
            this.loader.TabIndex = 22;
            this.loader.TabStop = false;
            this.loader.Visible = false;
            this.loader.Paint += new System.Windows.Forms.PaintEventHandler(this.Loader_Paint);
            // 
            // starting_year_label
            // 
            this.starting_year_label.AutoSize = true;
            this.starting_year_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.starting_year_label.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.starting_year_label.ForeColor = System.Drawing.Color.White;
            this.starting_year_label.Location = new System.Drawing.Point(120, 166);
            this.starting_year_label.Name = "starting_year_label";
            this.starting_year_label.Size = new System.Drawing.Size(122, 21);
            this.starting_year_label.TabIndex = 0;
            this.starting_year_label.Text = "Starting Year";
            // 
            // starting_year
            // 
            this.starting_year.Font = new System.Drawing.Font("Savile ExtraBold", 9F, System.Drawing.FontStyle.Bold);
            this.starting_year.Location = new System.Drawing.Point(321, 166);
            this.starting_year.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.starting_year.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.starting_year.Name = "starting_year";
            this.starting_year.Size = new System.Drawing.Size(100, 22);
            this.starting_year.TabIndex = 1;
            this.starting_year.Value = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            // 
            // game_speed_label
            // 
            this.game_speed_label.AutoSize = true;
            this.game_speed_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.game_speed_label.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.game_speed_label.ForeColor = System.Drawing.Color.White;
            this.game_speed_label.Location = new System.Drawing.Point(120, 214);
            this.game_speed_label.Name = "game_speed_label";
            this.game_speed_label.Size = new System.Drawing.Size(116, 21);
            this.game_speed_label.TabIndex = 3;
            this.game_speed_label.Text = "Game Speed";
            // 
            // game_speed
            // 
            this.game_speed.Font = new System.Drawing.Font("Savile ExtraBold", 9F, System.Drawing.FontStyle.Bold);
            this.game_speed.FormattingEnabled = true;
            this.game_speed.Items.AddRange(new object[] {
            "x1",
            "x2",
            "x4",
            "x8",
            "x20"});
            this.game_speed.Location = new System.Drawing.Point(321, 214);
            this.game_speed.Name = "game_speed";
            this.game_speed.Size = new System.Drawing.Size(101, 23);
            this.game_speed.TabIndex = 4;
            this.game_speed.Text = "x4";
            // 
            // currency_inflation_label
            // 
            this.currency_inflation_label.AutoSize = true;
            this.currency_inflation_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.currency_inflation_label.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.currency_inflation_label.ForeColor = System.Drawing.Color.White;
            this.currency_inflation_label.Location = new System.Drawing.Point(120, 265);
            this.currency_inflation_label.Name = "currency_inflation_label";
            this.currency_inflation_label.Size = new System.Drawing.Size(158, 21);
            this.currency_inflation_label.TabIndex = 6;
            this.currency_inflation_label.Text = "Currency Inflation";
            // 
            // currency_inflation
            // 
            this.currency_inflation.DecimalPlaces = 2;
            this.currency_inflation.Font = new System.Drawing.Font("Savile ExtraBold", 9F, System.Drawing.FontStyle.Bold);
            this.currency_inflation.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.currency_inflation.Location = new System.Drawing.Point(321, 265);
            this.currency_inflation.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.currency_inflation.Name = "currency_inflation";
            this.currency_inflation.Size = new System.Drawing.Size(101, 22);
            this.currency_inflation.TabIndex = 7;
            this.currency_inflation.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // coloured_attributes
            // 
            this.coloured_attributes.AutoSize = true;
            this.coloured_attributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.coloured_attributes.Checked = true;
            this.coloured_attributes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.coloured_attributes.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.coloured_attributes.ForeColor = System.Drawing.Color.White;
            this.coloured_attributes.Location = new System.Drawing.Point(120, 315);
            this.coloured_attributes.Name = "coloured_attributes";
            this.coloured_attributes.Size = new System.Drawing.Size(194, 25);
            this.coloured_attributes.TabIndex = 9;
            this.coloured_attributes.Text = "Coloured Attributes";
            this.coloured_attributes.UseVisualStyleBackColor = false;
            // 
            // resolution
            // 
            this.resolution.AutoSize = true;
            this.resolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resolution.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.resolution.ForeColor = System.Drawing.Color.White;
            this.resolution.Location = new System.Drawing.Point(121, 364);
            this.resolution.Name = "resolution";
            this.resolution.Size = new System.Drawing.Size(301, 25);
            this.resolution.TabIndex = 11;
            this.resolution.Text = "Change Resolution to 1200x800";
            this.resolution.UseVisualStyleBackColor = false;
            this.resolution.Visible = false;
            // 
            // work_permits
            // 
            this.work_permits.AutoSize = true;
            this.work_permits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.work_permits.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.work_permits.ForeColor = System.Drawing.Color.White;
            this.work_permits.Location = new System.Drawing.Point(470, 166);
            this.work_permits.Name = "work_permits";
            this.work_permits.Size = new System.Drawing.Size(170, 25);
            this.work_permits.TabIndex = 2;
            this.work_permits.Text = "No Work Permits";
            this.work_permits.UseVisualStyleBackColor = false;
            // 
            // non_public_bids
            // 
            this.non_public_bids.AutoSize = true;
            this.non_public_bids.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.non_public_bids.Checked = true;
            this.non_public_bids.CheckState = System.Windows.Forms.CheckState.Checked;
            this.non_public_bids.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.non_public_bids.ForeColor = System.Drawing.Color.White;
            this.non_public_bids.Location = new System.Drawing.Point(470, 213);
            this.non_public_bids.Name = "non_public_bids";
            this.non_public_bids.Size = new System.Drawing.Size(208, 25);
            this.non_public_bids.TabIndex = 5;
            this.non_public_bids.Text = "Hide Non-Public Bids";
            this.non_public_bids.UseVisualStyleBackColor = false;
            // 
            // seven_substitutes
            // 
            this.seven_substitutes.AutoSize = true;
            this.seven_substitutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.seven_substitutes.Checked = true;
            this.seven_substitutes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.seven_substitutes.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.seven_substitutes.ForeColor = System.Drawing.Color.White;
            this.seven_substitutes.Location = new System.Drawing.Point(470, 261);
            this.seven_substitutes.Name = "seven_substitutes";
            this.seven_substitutes.Size = new System.Drawing.Size(242, 25);
            this.seven_substitutes.TabIndex = 8;
            this.seven_substitutes.Text = "Increase To 7 Substitutes";
            this.seven_substitutes.UseVisualStyleBackColor = false;
            // 
            // unprotected_contracts
            // 
            this.unprotected_contracts.AutoSize = true;
            this.unprotected_contracts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.unprotected_contracts.Checked = true;
            this.unprotected_contracts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unprotected_contracts.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.unprotected_contracts.ForeColor = System.Drawing.Color.White;
            this.unprotected_contracts.Location = new System.Drawing.Point(470, 315);
            this.unprotected_contracts.Name = "unprotected_contracts";
            this.unprotected_contracts.Size = new System.Drawing.Size(288, 25);
            this.unprotected_contracts.TabIndex = 10;
            this.unprotected_contracts.Text = "Disable Unprotected Contracts";
            this.unprotected_contracts.UseVisualStyleBackColor = false;
            // 
            // foreign_player_limit
            // 
            this.foreign_player_limit.AutoSize = true;
            this.foreign_player_limit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.foreign_player_limit.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.foreign_player_limit.ForeColor = System.Drawing.Color.White;
            this.foreign_player_limit.Location = new System.Drawing.Point(470, 364);
            this.foreign_player_limit.Name = "foreign_player_limit";
            this.foreign_player_limit.Size = new System.Drawing.Size(293, 25);
            this.foreign_player_limit.TabIndex = 12;
            this.foreign_player_limit.Text = "Remove UK Foreign Player Limit";
            this.foreign_player_limit.UseVisualStyleBackColor = false;
            // 
            // apply
            // 
            this.apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.apply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.apply.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.apply.FlatAppearance.BorderSize = 2;
            this.apply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.apply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply.Font = new System.Drawing.Font("Savile ExtraBold", 12.75F, System.Drawing.FontStyle.Bold);
            this.apply.ForeColor = System.Drawing.Color.White;
            this.apply.Location = new System.Drawing.Point(368, 453);
            this.apply.Margin = new System.Windows.Forms.Padding(0);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(150, 40);
            this.apply.TabIndex = 13;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = false;
            this.apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // transparent_panel
            // 
            this.transparent_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.transparent_panel.Location = new System.Drawing.Point(107, 142);
            this.transparent_panel.Name = "transparent_panel";
            this.transparent_panel.Size = new System.Drawing.Size(675, 272);
            this.transparent_panel.TabIndex = 13;
            this.transparent_panel.TabStop = false;
            // 
            // version
            // 
            this.version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.version.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.version.FlatAppearance.BorderSize = 0;
            this.version.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.version.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.version.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.version.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(215)))), ((int)(((byte)(16)))));
            this.version.Location = new System.Drawing.Point(9, 12);
            this.version.Margin = new System.Windows.Forms.Padding(0);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(79, 50);
            this.version.TabIndex = 16;
            this.version.Text = "Version 1.1.0";
            this.version.UseVisualStyleBackColor = false;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(215)))), ((int)(((byte)(16)))));
            this.exit.Location = new System.Drawing.Point(9, 153);
            this.exit.Margin = new System.Windows.Forms.Padding(0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(79, 50);
            this.exit.TabIndex = 19;
            this.exit.Text = "Exit Tool";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // sidenav
            // 
            this.sidenav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.sidenav.Location = new System.Drawing.Point(0, 0);
            this.sidenav.Margin = new System.Windows.Forms.Padding(0);
            this.sidenav.Name = "sidenav";
            this.sidenav.Size = new System.Drawing.Size(97, 578);
            this.sidenav.TabIndex = 19;
            this.sidenav.TabStop = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Red;
            this.title.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.title.Location = new System.Drawing.Point(143, 27);
            this.title.Margin = new System.Windows.Forms.Padding(0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(603, 29);
            this.title.TabIndex = 21;
            this.title.Text = "Championship Manager 2001/02 Starter Kit";
            // 
            // title_bar
            // 
            this.title_bar.BackColor = System.Drawing.Color.Red;
            this.title_bar.Location = new System.Drawing.Point(107, 10);
            this.title_bar.Margin = new System.Windows.Forms.Padding(0);
            this.title_bar.Name = "title_bar";
            this.title_bar.Size = new System.Drawing.Size(675, 64);
            this.title_bar.TabIndex = 21;
            this.title_bar.TabStop = false;
            // 
            // subtitle
            // 
            this.subtitle.AutoSize = true;
            this.subtitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.subtitle.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.ForeColor = System.Drawing.Color.Yellow;
            this.subtitle.Location = new System.Drawing.Point(255, 88);
            this.subtitle.Margin = new System.Windows.Forms.Padding(0);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(403, 26);
            this.subtitle.TabIndex = 22;
            this.subtitle.Text = "Change Nick\'s Patcher Settings";
            // 
            // subtitle_bar
            // 
            this.subtitle_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.subtitle_bar.Location = new System.Drawing.Point(107, 78);
            this.subtitle_bar.Margin = new System.Windows.Forms.Padding(0);
            this.subtitle_bar.Name = "subtitle_bar";
            this.subtitle_bar.Size = new System.Drawing.Size(675, 48);
            this.subtitle_bar.TabIndex = 23;
            this.subtitle_bar.TabStop = false;
            // 
            // back_button
            // 
            this.back_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.back_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back_button.Font = new System.Drawing.Font("Savile ExtraBold", 12F, System.Drawing.FontStyle.Bold);
            this.back_button.ForeColor = System.Drawing.Color.White;
            this.back_button.Location = new System.Drawing.Point(107, 531);
            this.back_button.Margin = new System.Windows.Forms.Padding(0);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(505, 37);
            this.back_button.TabIndex = 14;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = false;
            this.back_button.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.Enabled = false;
            this.next_button.Font = new System.Drawing.Font("Savile ExtraBold", 12F, System.Drawing.FontStyle.Bold);
            this.next_button.ForeColor = System.Drawing.Color.White;
            this.next_button.Location = new System.Drawing.Point(611, 531);
            this.next_button.Margin = new System.Windows.Forms.Padding(0);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(171, 37);
            this.next_button.TabIndex = 15;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = false;
            // 
            // NickPatcherMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CM0102_Starter_Kit.Properties.Resources.ruud;
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.work_permits);
            this.Controls.Add(this.non_public_bids);
            this.Controls.Add(this.seven_substitutes);
            this.Controls.Add(this.foreign_player_limit);
            this.Controls.Add(this.unprotected_contracts);
            this.Controls.Add(this.resolution);
            this.Controls.Add(this.coloured_attributes);
            this.Controls.Add(this.game_speed_label);
            this.Controls.Add(this.currency_inflation_label);
            this.Controls.Add(this.starting_year_label);
            this.Controls.Add(this.game_speed);
            this.Controls.Add(this.starting_year);
            this.Controls.Add(this.currency_inflation);
            this.Controls.Add(this.transparent_panel);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.version);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.sidenav);
            this.Controls.Add(this.title);
            this.Controls.Add(this.title_bar);
            this.Controls.Add(this.subtitle);
            this.Controls.Add(this.subtitle_bar);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.next_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::CM0102_Starter_Kit.Properties.Resources.logo;
            this.MaximizeBox = false;
            this.Name = "NickPatcherMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CM 01/02 Starter Kit - Nick\'s Patcher Menu";
            ((System.ComponentModel.ISupportInitialize)(this.loader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starting_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currency_inflation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparent_panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidenav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtitle_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox loader;
        private System.Windows.Forms.NumericUpDown currency_inflation;
        private System.Windows.Forms.NumericUpDown starting_year;
        private System.Windows.Forms.ComboBox game_speed;
        private System.Windows.Forms.Label starting_year_label;
        private System.Windows.Forms.Label currency_inflation_label;
        private System.Windows.Forms.Label game_speed_label;
        private System.Windows.Forms.CheckBox coloured_attributes;
        private System.Windows.Forms.CheckBox resolution;
        private System.Windows.Forms.CheckBox unprotected_contracts;
        private System.Windows.Forms.CheckBox foreign_player_limit;
        private System.Windows.Forms.CheckBox seven_substitutes;
        private System.Windows.Forms.CheckBox non_public_bids;
        private System.Windows.Forms.CheckBox work_permits;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.PictureBox transparent_panel;
        private System.Windows.Forms.Button version;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.PictureBox sidenav;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox title_bar;
        private System.Windows.Forms.Label subtitle;
        private System.Windows.Forms.PictureBox subtitle_bar;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button next_button;
    }
}

