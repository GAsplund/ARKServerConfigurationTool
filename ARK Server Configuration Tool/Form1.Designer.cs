namespace ARK_Server_Configuration_Tool
{
    partial class MainForm
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
            this.ServerSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateServerStatusButton = new System.Windows.Forms.Button();
            this.ServerProfileNameTextBox = new System.Windows.Forms.TextBox();
            this.SaveAndWriteSettingsButton = new System.Windows.Forms.Button();
            this.ProfileSelectorLabel = new System.Windows.Forms.Label();
            this.ProfileNameLabel = new System.Windows.Forms.Label();
            this.ServerSettingsTabControl = new System.Windows.Forms.TabControl();
            this.BackEndSettingsTabPage = new System.Windows.Forms.TabPage();
            this.SpaceEfficiencyConfigTabPage = new System.Windows.Forms.TabPage();
            this.ClusterConfigTabPage = new System.Windows.Forms.TabPage();
            this.MapInfoTabPage = new System.Windows.Forms.TabPage();
            this.TamedDinosRadioButton = new System.Windows.Forms.RadioButton();
            this.WildDinosRadioButton = new System.Windows.Forms.RadioButton();
            this.MapInfoDinoListDataGridView = new System.Windows.Forms.DataGridView();
            this.DinoGenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinoLatitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TameableColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MapInfoDinoSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RatesSettingsTabPage = new System.Windows.Forms.TabPage();
            this.PlayersConfigTabPage = new System.Windows.Forms.TabPage();
            this.DinosConfigTabPage = new System.Windows.Forms.TabPage();
            this.EnvironmentalConfigTabPage = new System.Windows.Forms.TabPage();
            this.ModsConfigTabPage = new System.Windows.Forms.TabPage();
            this.NewProfileButton = new System.Windows.Forms.Button();
            this.DeleteServerButton = new System.Windows.Forms.Button();
            this.ClusterSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.ClusterSelectorLabel = new System.Windows.Forms.Label();
            this.ClusterStatusLabel = new System.Windows.Forms.Label();
            this.ServerStatusLabel = new System.Windows.Forms.Label();
            this.ServerSettingsTabControl.SuspendLayout();
            this.MapInfoTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapInfoDinoListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerSelectionComboBox
            // 
            this.ServerSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerSelectionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ServerSelectionComboBox.FormattingEnabled = true;
            this.ServerSelectionComboBox.Location = new System.Drawing.Point(12, 75);
            this.ServerSelectionComboBox.Name = "ServerSelectionComboBox";
            this.ServerSelectionComboBox.Size = new System.Drawing.Size(226, 24);
            this.ServerSelectionComboBox.TabIndex = 1;
            this.ServerSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.ServerSelectionComboBox_SelectedIndexChanged);
            // 
            // UpdateServerStatusButton
            // 
            this.UpdateServerStatusButton.Enabled = false;
            this.UpdateServerStatusButton.Location = new System.Drawing.Point(244, 106);
            this.UpdateServerStatusButton.Name = "UpdateServerStatusButton";
            this.UpdateServerStatusButton.Size = new System.Drawing.Size(99, 26);
            this.UpdateServerStatusButton.TabIndex = 2;
            this.UpdateServerStatusButton.Text = "Update Status";
            this.UpdateServerStatusButton.UseVisualStyleBackColor = true;
            this.UpdateServerStatusButton.Click += new System.EventHandler(this.UpdateServerStatusButton_Click);
            // 
            // ServerProfileNameTextBox
            // 
            this.ServerProfileNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ServerProfileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ServerProfileNameTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ServerProfileNameTextBox.Location = new System.Drawing.Point(245, 28);
            this.ServerProfileNameTextBox.Name = "ServerProfileNameTextBox";
            this.ServerProfileNameTextBox.Size = new System.Drawing.Size(202, 24);
            this.ServerProfileNameTextBox.TabIndex = 6;
            // 
            // SaveAndWriteSettingsButton
            // 
            this.SaveAndWriteSettingsButton.Enabled = false;
            this.SaveAndWriteSettingsButton.Location = new System.Drawing.Point(348, 106);
            this.SaveAndWriteSettingsButton.Name = "SaveAndWriteSettingsButton";
            this.SaveAndWriteSettingsButton.Size = new System.Drawing.Size(99, 26);
            this.SaveAndWriteSettingsButton.TabIndex = 7;
            this.SaveAndWriteSettingsButton.Text = "Save Settings";
            this.SaveAndWriteSettingsButton.UseVisualStyleBackColor = true;
            // 
            // ProfileSelectorLabel
            // 
            this.ProfileSelectorLabel.AutoSize = true;
            this.ProfileSelectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ProfileSelectorLabel.Location = new System.Drawing.Point(9, 55);
            this.ProfileSelectorLabel.Name = "ProfileSelectorLabel";
            this.ProfileSelectorLabel.Size = new System.Drawing.Size(54, 17);
            this.ProfileSelectorLabel.TabIndex = 8;
            this.ProfileSelectorLabel.Text = "Server:";
            // 
            // ProfileNameLabel
            // 
            this.ProfileNameLabel.AutoSize = true;
            this.ProfileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ProfileNameLabel.Location = new System.Drawing.Point(242, 8);
            this.ProfileNameLabel.Name = "ProfileNameLabel";
            this.ProfileNameLabel.Size = new System.Drawing.Size(95, 17);
            this.ProfileNameLabel.TabIndex = 9;
            this.ProfileNameLabel.Text = "Server Name:";
            // 
            // ServerSettingsTabControl
            // 
            this.ServerSettingsTabControl.Controls.Add(this.BackEndSettingsTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.SpaceEfficiencyConfigTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.ClusterConfigTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.MapInfoTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.RatesSettingsTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.PlayersConfigTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.DinosConfigTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.EnvironmentalConfigTabPage);
            this.ServerSettingsTabControl.Controls.Add(this.ModsConfigTabPage);
            this.ServerSettingsTabControl.Enabled = false;
            this.ServerSettingsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ServerSettingsTabControl.Location = new System.Drawing.Point(12, 160);
            this.ServerSettingsTabControl.Name = "ServerSettingsTabControl";
            this.ServerSettingsTabControl.SelectedIndex = 0;
            this.ServerSettingsTabControl.Size = new System.Drawing.Size(1044, 356);
            this.ServerSettingsTabControl.TabIndex = 10;
            // 
            // BackEndSettingsTabPage
            // 
            this.BackEndSettingsTabPage.AutoScroll = true;
            this.BackEndSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.BackEndSettingsTabPage.Name = "BackEndSettingsTabPage";
            this.BackEndSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BackEndSettingsTabPage.Size = new System.Drawing.Size(1036, 330);
            this.BackEndSettingsTabPage.TabIndex = 0;
            this.BackEndSettingsTabPage.Text = "Back-end";
            this.BackEndSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // SpaceEfficiencyConfigTabPage
            // 
            this.SpaceEfficiencyConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.SpaceEfficiencyConfigTabPage.Name = "SpaceEfficiencyConfigTabPage";
            this.SpaceEfficiencyConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.SpaceEfficiencyConfigTabPage.TabIndex = 2;
            this.SpaceEfficiencyConfigTabPage.Text = "Space Efficiency";
            this.SpaceEfficiencyConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // ClusterConfigTabPage
            // 
            this.ClusterConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.ClusterConfigTabPage.Name = "ClusterConfigTabPage";
            this.ClusterConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.ClusterConfigTabPage.TabIndex = 4;
            this.ClusterConfigTabPage.Text = "Cluster";
            this.ClusterConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // MapInfoTabPage
            // 
            this.MapInfoTabPage.AutoScroll = true;
            this.MapInfoTabPage.Controls.Add(this.TamedDinosRadioButton);
            this.MapInfoTabPage.Controls.Add(this.WildDinosRadioButton);
            this.MapInfoTabPage.Controls.Add(this.MapInfoDinoListDataGridView);
            this.MapInfoTabPage.Controls.Add(this.MapInfoDinoSelectionComboBox);
            this.MapInfoTabPage.Controls.Add(this.label1);
            this.MapInfoTabPage.Location = new System.Drawing.Point(4, 22);
            this.MapInfoTabPage.Name = "MapInfoTabPage";
            this.MapInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MapInfoTabPage.Size = new System.Drawing.Size(1036, 330);
            this.MapInfoTabPage.TabIndex = 1;
            this.MapInfoTabPage.Text = "Map Info";
            this.MapInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // TamedDinosRadioButton
            // 
            this.TamedDinosRadioButton.AutoSize = true;
            this.TamedDinosRadioButton.Enabled = false;
            this.TamedDinosRadioButton.Location = new System.Drawing.Point(211, 31);
            this.TamedDinosRadioButton.Name = "TamedDinosRadioButton";
            this.TamedDinosRadioButton.Size = new System.Drawing.Size(88, 17);
            this.TamedDinosRadioButton.TabIndex = 4;
            this.TamedDinosRadioButton.Text = "Tamed Dinos";
            this.TamedDinosRadioButton.UseVisualStyleBackColor = true;
            this.TamedDinosRadioButton.CheckedChanged += new System.EventHandler(this.TamedDinosRadioButton_CheckedChanged);
            // 
            // WildDinosRadioButton
            // 
            this.WildDinosRadioButton.AutoSize = true;
            this.WildDinosRadioButton.Checked = true;
            this.WildDinosRadioButton.Location = new System.Drawing.Point(211, 11);
            this.WildDinosRadioButton.Name = "WildDinosRadioButton";
            this.WildDinosRadioButton.Size = new System.Drawing.Size(76, 17);
            this.WildDinosRadioButton.TabIndex = 3;
            this.WildDinosRadioButton.TabStop = true;
            this.WildDinosRadioButton.Text = "Wild Dinos";
            this.WildDinosRadioButton.UseVisualStyleBackColor = true;
            this.WildDinosRadioButton.CheckedChanged += new System.EventHandler(this.WildDinosRadioButton_CheckedChanged);
            // 
            // MapInfoDinoListDataGridView
            // 
            this.MapInfoDinoListDataGridView.AllowUserToAddRows = false;
            this.MapInfoDinoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MapInfoDinoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DinoGenderColumn,
            this.LevelColumn,
            this.DinoLatitudeColumn,
            this.LongitudeColumn,
            this.TameableColumn});
            this.MapInfoDinoListDataGridView.Location = new System.Drawing.Point(6, 67);
            this.MapInfoDinoListDataGridView.Name = "MapInfoDinoListDataGridView";
            this.MapInfoDinoListDataGridView.ReadOnly = true;
            this.MapInfoDinoListDataGridView.RowHeadersVisible = false;
            this.MapInfoDinoListDataGridView.Size = new System.Drawing.Size(1024, 257);
            this.MapInfoDinoListDataGridView.TabIndex = 2;
            // 
            // DinoGenderColumn
            // 
            this.DinoGenderColumn.Frozen = true;
            this.DinoGenderColumn.HeaderText = "Gender";
            this.DinoGenderColumn.Name = "DinoGenderColumn";
            this.DinoGenderColumn.ReadOnly = true;
            // 
            // LevelColumn
            // 
            this.LevelColumn.Frozen = true;
            this.LevelColumn.HeaderText = "Level";
            this.LevelColumn.Name = "LevelColumn";
            this.LevelColumn.ReadOnly = true;
            // 
            // DinoLatitudeColumn
            // 
            this.DinoLatitudeColumn.Frozen = true;
            this.DinoLatitudeColumn.HeaderText = "Latitude";
            this.DinoLatitudeColumn.Name = "DinoLatitudeColumn";
            this.DinoLatitudeColumn.ReadOnly = true;
            // 
            // LongitudeColumn
            // 
            this.LongitudeColumn.Frozen = true;
            this.LongitudeColumn.HeaderText = "Longitude";
            this.LongitudeColumn.Name = "LongitudeColumn";
            this.LongitudeColumn.ReadOnly = true;
            // 
            // TameableColumn
            // 
            this.TameableColumn.HeaderText = "Tameable";
            this.TameableColumn.Name = "TameableColumn";
            this.TameableColumn.ReadOnly = true;
            // 
            // MapInfoDinoSelectionComboBox
            // 
            this.MapInfoDinoSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapInfoDinoSelectionComboBox.FormattingEnabled = true;
            this.MapInfoDinoSelectionComboBox.Location = new System.Drawing.Point(15, 28);
            this.MapInfoDinoSelectionComboBox.Name = "MapInfoDinoSelectionComboBox";
            this.MapInfoDinoSelectionComboBox.Size = new System.Drawing.Size(185, 21);
            this.MapInfoDinoSelectionComboBox.TabIndex = 1;
            this.MapInfoDinoSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.MapInfoDinoSelectionComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dino";
            // 
            // RatesSettingsTabPage
            // 
            this.RatesSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.RatesSettingsTabPage.Name = "RatesSettingsTabPage";
            this.RatesSettingsTabPage.Size = new System.Drawing.Size(1036, 330);
            this.RatesSettingsTabPage.TabIndex = 3;
            this.RatesSettingsTabPage.Text = "Rates";
            this.RatesSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // PlayersConfigTabPage
            // 
            this.PlayersConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.PlayersConfigTabPage.Name = "PlayersConfigTabPage";
            this.PlayersConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.PlayersConfigTabPage.TabIndex = 5;
            this.PlayersConfigTabPage.Text = "Players";
            this.PlayersConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // DinosConfigTabPage
            // 
            this.DinosConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.DinosConfigTabPage.Name = "DinosConfigTabPage";
            this.DinosConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.DinosConfigTabPage.TabIndex = 6;
            this.DinosConfigTabPage.Text = "Dinos";
            this.DinosConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // EnvironmentalConfigTabPage
            // 
            this.EnvironmentalConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.EnvironmentalConfigTabPage.Name = "EnvironmentalConfigTabPage";
            this.EnvironmentalConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.EnvironmentalConfigTabPage.TabIndex = 7;
            this.EnvironmentalConfigTabPage.Text = "Environment";
            this.EnvironmentalConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // ModsConfigTabPage
            // 
            this.ModsConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.ModsConfigTabPage.Name = "ModsConfigTabPage";
            this.ModsConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.ModsConfigTabPage.TabIndex = 8;
            this.ModsConfigTabPage.Text = "Mods";
            this.ModsConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // NewProfileButton
            // 
            this.NewProfileButton.Location = new System.Drawing.Point(244, 74);
            this.NewProfileButton.Name = "NewProfileButton";
            this.NewProfileButton.Size = new System.Drawing.Size(99, 26);
            this.NewProfileButton.TabIndex = 11;
            this.NewProfileButton.Text = "New Server";
            this.NewProfileButton.UseVisualStyleBackColor = true;
            this.NewProfileButton.Click += new System.EventHandler(this.NewProfileButton_Click);
            // 
            // DeleteServerButton
            // 
            this.DeleteServerButton.Location = new System.Drawing.Point(348, 74);
            this.DeleteServerButton.Name = "DeleteServerButton";
            this.DeleteServerButton.Size = new System.Drawing.Size(99, 26);
            this.DeleteServerButton.TabIndex = 12;
            this.DeleteServerButton.Text = "Delete Server";
            this.DeleteServerButton.UseVisualStyleBackColor = true;
            this.DeleteServerButton.Click += new System.EventHandler(this.DeleteServerButton_Click);
            // 
            // ClusterSelectionComboBox
            // 
            this.ClusterSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClusterSelectionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ClusterSelectionComboBox.FormattingEnabled = true;
            this.ClusterSelectionComboBox.Location = new System.Drawing.Point(12, 28);
            this.ClusterSelectionComboBox.Name = "ClusterSelectionComboBox";
            this.ClusterSelectionComboBox.Size = new System.Drawing.Size(226, 24);
            this.ClusterSelectionComboBox.TabIndex = 13;
            this.ClusterSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.ClusterSelectionComboBox_SelectedIndexChanged);
            // 
            // ClusterSelectorLabel
            // 
            this.ClusterSelectorLabel.AutoSize = true;
            this.ClusterSelectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ClusterSelectorLabel.Location = new System.Drawing.Point(9, 8);
            this.ClusterSelectorLabel.Name = "ClusterSelectorLabel";
            this.ClusterSelectorLabel.Size = new System.Drawing.Size(56, 17);
            this.ClusterSelectorLabel.TabIndex = 14;
            this.ClusterSelectorLabel.Text = "Cluster:";
            // 
            // ClusterStatusLabel
            // 
            this.ClusterStatusLabel.AutoSize = true;
            this.ClusterStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ClusterStatusLabel.Location = new System.Drawing.Point(10, 102);
            this.ClusterStatusLabel.Name = "ClusterStatusLabel";
            this.ClusterStatusLabel.Size = new System.Drawing.Size(83, 17);
            this.ClusterStatusLabel.TabIndex = 15;
            this.ClusterStatusLabel.Text = "Cluster: N/A";
            // 
            // ServerStatusLabel
            // 
            this.ServerStatusLabel.AutoSize = true;
            this.ServerStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ServerStatusLabel.Location = new System.Drawing.Point(12, 121);
            this.ServerStatusLabel.Name = "ServerStatusLabel";
            this.ServerStatusLabel.Size = new System.Drawing.Size(81, 17);
            this.ServerStatusLabel.TabIndex = 16;
            this.ServerStatusLabel.Text = "Server: N/A";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 528);
            this.Controls.Add(this.ServerStatusLabel);
            this.Controls.Add(this.ClusterStatusLabel);
            this.Controls.Add(this.ClusterSelectorLabel);
            this.Controls.Add(this.ClusterSelectionComboBox);
            this.Controls.Add(this.DeleteServerButton);
            this.Controls.Add(this.NewProfileButton);
            this.Controls.Add(this.ServerSettingsTabControl);
            this.Controls.Add(this.ProfileNameLabel);
            this.Controls.Add(this.ProfileSelectorLabel);
            this.Controls.Add(this.SaveAndWriteSettingsButton);
            this.Controls.Add(this.ServerProfileNameTextBox);
            this.Controls.Add(this.UpdateServerStatusButton);
            this.Controls.Add(this.ServerSelectionComboBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "MainForm";
            this.Text = "ARK Server Configuration Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ServerSettingsTabControl.ResumeLayout(false);
            this.MapInfoTabPage.ResumeLayout(false);
            this.MapInfoTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapInfoDinoListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button UpdateServerStatusButton;
        private System.Windows.Forms.TextBox ServerProfileNameTextBox;
        private System.Windows.Forms.Button SaveAndWriteSettingsButton;
        private System.Windows.Forms.Label ProfileSelectorLabel;
        private System.Windows.Forms.Label ProfileNameLabel;
        private System.Windows.Forms.TabPage MapInfoTabPage;
        private System.Windows.Forms.Button NewProfileButton;
        private System.Windows.Forms.Button DeleteServerButton;
        public System.Windows.Forms.ComboBox ServerSelectionComboBox;
        public System.Windows.Forms.TabControl ServerSettingsTabControl;
        public System.Windows.Forms.TabPage BackEndSettingsTabPage;
        public System.Windows.Forms.TabPage RatesSettingsTabPage;
        public System.Windows.Forms.TabPage SpaceEfficiencyConfigTabPage;
        private System.Windows.Forms.TabPage ClusterConfigTabPage;
        public System.Windows.Forms.ComboBox ClusterSelectionComboBox;
        private System.Windows.Forms.Label ClusterSelectorLabel;
        private System.Windows.Forms.Label ClusterStatusLabel;
        private System.Windows.Forms.Label ServerStatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage PlayersConfigTabPage;
        private System.Windows.Forms.TabPage DinosConfigTabPage;
        private System.Windows.Forms.TabPage EnvironmentalConfigTabPage;
        public System.Windows.Forms.ComboBox MapInfoDinoSelectionComboBox;
        public System.Windows.Forms.DataGridView MapInfoDinoListDataGridView;
        private System.Windows.Forms.TabPage ModsConfigTabPage;
        private System.Windows.Forms.RadioButton TamedDinosRadioButton;
        private System.Windows.Forms.RadioButton WildDinosRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinoGenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinoLatitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TameableColumn;
    }
}

