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
            this.globalServerDataLocationLabel = new System.Windows.Forms.Label();
            this.refreshSpaceUsageButton = new System.Windows.Forms.Button();
            this.globalDataLocationBrowseButton = new System.Windows.Forms.Button();
            this.globalDataLocationTextBox = new System.Windows.Forms.TextBox();
            this.spaceEfficiencyExperimentalLabel = new System.Windows.Forms.Label();
            this.enableGlobalDataCheckBox = new System.Windows.Forms.CheckBox();
            this.allServersSpaceUsageLabel = new System.Windows.Forms.Label();
            this.globalDataSpaceUsageLabel = new System.Windows.Forms.Label();
            this.serverSpaceUsageLabel = new System.Windows.Forms.Label();
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
            this.deleteModButton = new System.Windows.Forms.Button();
            this.addModButton = new System.Windows.Forms.Button();
            this.modsListDataGridView = new System.Windows.Forms.DataGridView();
            this.ModSortColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastDownloadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModUpdateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModSizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateModButton = new System.Windows.Forms.Button();
            this.increadeModIndexButton = new System.Windows.Forms.Button();
            this.decreaseModIndexButton = new System.Windows.Forms.Button();
            this.modIndexTextBox = new System.Windows.Forms.TextBox();
            this.modIndexLabel = new System.Windows.Forms.Label();
            this.modSortingComboBox = new System.Windows.Forms.ComboBox();
            this.modSortingLabel = new System.Windows.Forms.Label();
            this.modNameLabel = new System.Windows.Forms.Label();
            this.NewProfileButton = new System.Windows.Forms.Button();
            this.DeleteServerButton = new System.Windows.Forms.Button();
            this.ClusterSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.ClusterSelectorLabel = new System.Windows.Forms.Label();
            this.ClusterStatusLabel = new System.Windows.Forms.Label();
            this.ServerStatusLabel = new System.Windows.Forms.Label();
            this.ServerSettingsTabControl.SuspendLayout();
            this.SpaceEfficiencyConfigTabPage.SuspendLayout();
            this.MapInfoTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapInfoDinoListDataGridView)).BeginInit();
            this.ModsConfigTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modsListDataGridView)).BeginInit();
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
            this.SaveAndWriteSettingsButton.Click += new System.EventHandler(this.SaveAndWriteSettingsButton_Click);
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
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.globalServerDataLocationLabel);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.refreshSpaceUsageButton);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.globalDataLocationBrowseButton);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.globalDataLocationTextBox);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.spaceEfficiencyExperimentalLabel);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.enableGlobalDataCheckBox);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.allServersSpaceUsageLabel);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.globalDataSpaceUsageLabel);
            this.SpaceEfficiencyConfigTabPage.Controls.Add(this.serverSpaceUsageLabel);
            this.SpaceEfficiencyConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.SpaceEfficiencyConfigTabPage.Name = "SpaceEfficiencyConfigTabPage";
            this.SpaceEfficiencyConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.SpaceEfficiencyConfigTabPage.TabIndex = 2;
            this.SpaceEfficiencyConfigTabPage.Text = "Space Efficiency";
            this.SpaceEfficiencyConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // globalServerDataLocationLabel
            // 
            this.globalServerDataLocationLabel.AutoSize = true;
            this.globalServerDataLocationLabel.Location = new System.Drawing.Point(13, 90);
            this.globalServerDataLocationLabel.Name = "globalServerDataLocationLabel";
            this.globalServerDataLocationLabel.Size = new System.Drawing.Size(144, 13);
            this.globalServerDataLocationLabel.TabIndex = 8;
            this.globalServerDataLocationLabel.Text = "Global Server Data Location:";
            // 
            // refreshSpaceUsageButton
            // 
            this.refreshSpaceUsageButton.Location = new System.Drawing.Point(390, 18);
            this.refreshSpaceUsageButton.Name = "refreshSpaceUsageButton";
            this.refreshSpaceUsageButton.Size = new System.Drawing.Size(75, 23);
            this.refreshSpaceUsageButton.TabIndex = 7;
            this.refreshSpaceUsageButton.Text = "Refresh";
            this.refreshSpaceUsageButton.UseVisualStyleBackColor = true;
            this.refreshSpaceUsageButton.Click += new System.EventHandler(this.refreshSpaceUsageButton_Click);
            // 
            // globalDataLocationBrowseButton
            // 
            this.globalDataLocationBrowseButton.Enabled = false;
            this.globalDataLocationBrowseButton.Location = new System.Drawing.Point(440, 107);
            this.globalDataLocationBrowseButton.Name = "globalDataLocationBrowseButton";
            this.globalDataLocationBrowseButton.Size = new System.Drawing.Size(83, 22);
            this.globalDataLocationBrowseButton.TabIndex = 6;
            this.globalDataLocationBrowseButton.Text = "Browse...";
            this.globalDataLocationBrowseButton.UseVisualStyleBackColor = true;
            this.globalDataLocationBrowseButton.Click += new System.EventHandler(this.globalDataLocationBrowseButton_Click);
            // 
            // globalDataLocationTextBox
            // 
            this.globalDataLocationTextBox.Enabled = false;
            this.globalDataLocationTextBox.Location = new System.Drawing.Point(16, 108);
            this.globalDataLocationTextBox.Name = "globalDataLocationTextBox";
            this.globalDataLocationTextBox.Size = new System.Drawing.Size(419, 20);
            this.globalDataLocationTextBox.TabIndex = 5;
            this.globalDataLocationTextBox.Text = "          ";
            // 
            // spaceEfficiencyExperimentalLabel
            // 
            this.spaceEfficiencyExperimentalLabel.AutoSize = true;
            this.spaceEfficiencyExperimentalLabel.Location = new System.Drawing.Point(193, 67);
            this.spaceEfficiencyExperimentalLabel.Name = "spaceEfficiencyExperimentalLabel";
            this.spaceEfficiencyExperimentalLabel.Size = new System.Drawing.Size(331, 13);
            this.spaceEfficiencyExperimentalLabel.TabIndex = 4;
            this.spaceEfficiencyExperimentalLabel.Text = "Warning: This feature is experimental and may cause server crashes.";
            // 
            // enableGlobalDataCheckBox
            // 
            this.enableGlobalDataCheckBox.AutoSize = true;
            this.enableGlobalDataCheckBox.Location = new System.Drawing.Point(16, 66);
            this.enableGlobalDataCheckBox.Name = "enableGlobalDataCheckBox";
            this.enableGlobalDataCheckBox.Size = new System.Drawing.Size(152, 17);
            this.enableGlobalDataCheckBox.TabIndex = 3;
            this.enableGlobalDataCheckBox.Text = "Enable Global Server Data";
            this.enableGlobalDataCheckBox.UseVisualStyleBackColor = true;
            this.enableGlobalDataCheckBox.CheckedChanged += new System.EventHandler(this.enableGlobalDataCheckBox_CheckedChanged);
            // 
            // allServersSpaceUsageLabel
            // 
            this.allServersSpaceUsageLabel.AutoSize = true;
            this.allServersSpaceUsageLabel.Location = new System.Drawing.Point(13, 36);
            this.allServersSpaceUsageLabel.Name = "allServersSpaceUsageLabel";
            this.allServersSpaceUsageLabel.Size = new System.Drawing.Size(151, 13);
            this.allServersSpaceUsageLabel.TabIndex = 2;
            this.allServersSpaceUsageLabel.Text = "All Servers Space Usage: N/A";
            // 
            // globalDataSpaceUsageLabel
            // 
            this.globalDataSpaceUsageLabel.AutoSize = true;
            this.globalDataSpaceUsageLabel.Location = new System.Drawing.Point(13, 23);
            this.globalDataSpaceUsageLabel.Name = "globalDataSpaceUsageLabel";
            this.globalDataSpaceUsageLabel.Size = new System.Drawing.Size(157, 13);
            this.globalDataSpaceUsageLabel.TabIndex = 1;
            this.globalDataSpaceUsageLabel.Text = "Global Data Space Usage: N/A";
            // 
            // serverSpaceUsageLabel
            // 
            this.serverSpaceUsageLabel.AutoSize = true;
            this.serverSpaceUsageLabel.Location = new System.Drawing.Point(13, 10);
            this.serverSpaceUsageLabel.Name = "serverSpaceUsageLabel";
            this.serverSpaceUsageLabel.Size = new System.Drawing.Size(132, 13);
            this.serverSpaceUsageLabel.TabIndex = 0;
            this.serverSpaceUsageLabel.Text = "Server Space Usage: N/A";
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
            this.MapInfoDinoListDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.ModsConfigTabPage.Controls.Add(this.deleteModButton);
            this.ModsConfigTabPage.Controls.Add(this.addModButton);
            this.ModsConfigTabPage.Controls.Add(this.modsListDataGridView);
            this.ModsConfigTabPage.Controls.Add(this.updateModButton);
            this.ModsConfigTabPage.Controls.Add(this.increadeModIndexButton);
            this.ModsConfigTabPage.Controls.Add(this.decreaseModIndexButton);
            this.ModsConfigTabPage.Controls.Add(this.modIndexTextBox);
            this.ModsConfigTabPage.Controls.Add(this.modIndexLabel);
            this.ModsConfigTabPage.Controls.Add(this.modSortingComboBox);
            this.ModsConfigTabPage.Controls.Add(this.modSortingLabel);
            this.ModsConfigTabPage.Controls.Add(this.modNameLabel);
            this.ModsConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.ModsConfigTabPage.Name = "ModsConfigTabPage";
            this.ModsConfigTabPage.Size = new System.Drawing.Size(1036, 330);
            this.ModsConfigTabPage.TabIndex = 8;
            this.ModsConfigTabPage.Text = "Mods";
            this.ModsConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // deleteModButton
            // 
            this.deleteModButton.Location = new System.Drawing.Point(449, 53);
            this.deleteModButton.Name = "deleteModButton";
            this.deleteModButton.Size = new System.Drawing.Size(83, 23);
            this.deleteModButton.TabIndex = 19;
            this.deleteModButton.Text = "Delete Mod";
            this.deleteModButton.UseVisualStyleBackColor = true;
            this.deleteModButton.Click += new System.EventHandler(this.deleteModButton_Click);
            // 
            // addModButton
            // 
            this.addModButton.Location = new System.Drawing.Point(360, 53);
            this.addModButton.Name = "addModButton";
            this.addModButton.Size = new System.Drawing.Size(83, 23);
            this.addModButton.TabIndex = 18;
            this.addModButton.Text = "Add Mod";
            this.addModButton.UseVisualStyleBackColor = true;
            this.addModButton.Click += new System.EventHandler(this.addModButton_Click);
            // 
            // modsListDataGridView
            // 
            this.modsListDataGridView.AllowUserToAddRows = false;
            this.modsListDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.modsListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modsListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModSortColumn,
            this.ModIdColumn,
            this.ModNameColumn,
            this.LastDownloadColumn,
            this.LastModUpdateColumn,
            this.ModSizeColumn});
            this.modsListDataGridView.Location = new System.Drawing.Point(2, 83);
            this.modsListDataGridView.Name = "modsListDataGridView";
            this.modsListDataGridView.ReadOnly = true;
            this.modsListDataGridView.RowHeadersVisible = false;
            this.modsListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.modsListDataGridView.Size = new System.Drawing.Size(1031, 244);
            this.modsListDataGridView.TabIndex = 9;
            this.modsListDataGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.modsListDataGridView_CellContentClick);
            // 
            // ModSortColumn
            // 
            this.ModSortColumn.HeaderText = "Num";
            this.ModSortColumn.Name = "ModSortColumn";
            this.ModSortColumn.ReadOnly = true;
            // 
            // ModIdColumn
            // 
            this.ModIdColumn.HeaderText = "ID";
            this.ModIdColumn.Name = "ModIdColumn";
            this.ModIdColumn.ReadOnly = true;
            // 
            // ModNameColumn
            // 
            this.ModNameColumn.HeaderText = "Name";
            this.ModNameColumn.Name = "ModNameColumn";
            this.ModNameColumn.ReadOnly = true;
            // 
            // LastDownloadColumn
            // 
            this.LastDownloadColumn.HeaderText = "Last Download";
            this.LastDownloadColumn.Name = "LastDownloadColumn";
            this.LastDownloadColumn.ReadOnly = true;
            // 
            // LastModUpdateColumn
            // 
            this.LastModUpdateColumn.HeaderText = "Last Mod Update";
            this.LastModUpdateColumn.Name = "LastModUpdateColumn";
            this.LastModUpdateColumn.ReadOnly = true;
            // 
            // ModSizeColumn
            // 
            this.ModSizeColumn.HeaderText = "Mod Size";
            this.ModSizeColumn.Name = "ModSizeColumn";
            this.ModSizeColumn.ReadOnly = true;
            // 
            // updateModButton
            // 
            this.updateModButton.Location = new System.Drawing.Point(271, 53);
            this.updateModButton.Name = "updateModButton";
            this.updateModButton.Size = new System.Drawing.Size(83, 23);
            this.updateModButton.TabIndex = 17;
            this.updateModButton.Text = "Update mod";
            this.updateModButton.UseVisualStyleBackColor = true;
            this.updateModButton.Click += new System.EventHandler(this.updateModButton_Click);
            // 
            // increadeModIndexButton
            // 
            this.increadeModIndexButton.Location = new System.Drawing.Point(85, 54);
            this.increadeModIndexButton.Name = "increadeModIndexButton";
            this.increadeModIndexButton.Size = new System.Drawing.Size(24, 22);
            this.increadeModIndexButton.TabIndex = 16;
            this.increadeModIndexButton.Text = "+";
            this.increadeModIndexButton.UseVisualStyleBackColor = true;
            this.increadeModIndexButton.Click += new System.EventHandler(this.increadeModIndexButton_Click);
            // 
            // decreaseModIndexButton
            // 
            this.decreaseModIndexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.decreaseModIndexButton.Location = new System.Drawing.Point(110, 54);
            this.decreaseModIndexButton.Name = "decreaseModIndexButton";
            this.decreaseModIndexButton.Size = new System.Drawing.Size(24, 22);
            this.decreaseModIndexButton.TabIndex = 15;
            this.decreaseModIndexButton.Text = "-";
            this.decreaseModIndexButton.UseVisualStyleBackColor = true;
            this.decreaseModIndexButton.Click += new System.EventHandler(this.decreaseModIndexButton_Click);
            // 
            // modIndexTextBox
            // 
            this.modIndexTextBox.Enabled = false;
            this.modIndexTextBox.Location = new System.Drawing.Point(9, 55);
            this.modIndexTextBox.MaxLength = 5;
            this.modIndexTextBox.Name = "modIndexTextBox";
            this.modIndexTextBox.Size = new System.Drawing.Size(70, 20);
            this.modIndexTextBox.TabIndex = 14;
            // 
            // modIndexLabel
            // 
            this.modIndexLabel.AutoSize = true;
            this.modIndexLabel.Location = new System.Drawing.Point(6, 39);
            this.modIndexLabel.Name = "modIndexLabel";
            this.modIndexLabel.Size = new System.Drawing.Size(57, 13);
            this.modIndexLabel.TabIndex = 13;
            this.modIndexLabel.Text = "Mod Index";
            // 
            // modSortingComboBox
            // 
            this.modSortingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modSortingComboBox.FormattingEnabled = true;
            this.modSortingComboBox.Items.AddRange(new object[] {
            "None",
            "Size"});
            this.modSortingComboBox.Location = new System.Drawing.Point(140, 54);
            this.modSortingComboBox.Name = "modSortingComboBox";
            this.modSortingComboBox.Size = new System.Drawing.Size(125, 21);
            this.modSortingComboBox.TabIndex = 12;
            // 
            // modSortingLabel
            // 
            this.modSortingLabel.AutoSize = true;
            this.modSortingLabel.Location = new System.Drawing.Point(137, 38);
            this.modSortingLabel.Name = "modSortingLabel";
            this.modSortingLabel.Size = new System.Drawing.Size(67, 13);
            this.modSortingLabel.TabIndex = 11;
            this.modSortingLabel.Text = "Mod Sorting:";
            // 
            // modNameLabel
            // 
            this.modNameLabel.AutoSize = true;
            this.modNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.modNameLabel.Location = new System.Drawing.Point(5, 5);
            this.modNameLabel.Name = "modNameLabel";
            this.modNameLabel.Size = new System.Drawing.Size(179, 26);
            this.modNameLabel.TabIndex = 10;
            this.modNameLabel.Text = "No Mod Selected";
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
            this.SpaceEfficiencyConfigTabPage.ResumeLayout(false);
            this.SpaceEfficiencyConfigTabPage.PerformLayout();
            this.MapInfoTabPage.ResumeLayout(false);
            this.MapInfoTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapInfoDinoListDataGridView)).EndInit();
            this.ModsConfigTabPage.ResumeLayout(false);
            this.ModsConfigTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modsListDataGridView)).EndInit();
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
        private System.Windows.Forms.Label spaceEfficiencyExperimentalLabel;
        private System.Windows.Forms.CheckBox enableGlobalDataCheckBox;
        private System.Windows.Forms.Label allServersSpaceUsageLabel;
        private System.Windows.Forms.Label globalDataSpaceUsageLabel;
        private System.Windows.Forms.Label serverSpaceUsageLabel;
        private System.Windows.Forms.Button globalDataLocationBrowseButton;
        private System.Windows.Forms.TextBox globalDataLocationTextBox;
        private System.Windows.Forms.Button refreshSpaceUsageButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinoGenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinoLatitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TameableColumn;
        private System.Windows.Forms.DataGridView modsListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModSortColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastDownloadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModUpdateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModSizeColumn;
        private System.Windows.Forms.Button updateModButton;
        private System.Windows.Forms.Button increadeModIndexButton;
        private System.Windows.Forms.Button decreaseModIndexButton;
        private System.Windows.Forms.TextBox modIndexTextBox;
        private System.Windows.Forms.Label modIndexLabel;
        private System.Windows.Forms.ComboBox modSortingComboBox;
        private System.Windows.Forms.Label modSortingLabel;
        private System.Windows.Forms.Label modNameLabel;
        private System.Windows.Forms.Label globalServerDataLocationLabel;
        private System.Windows.Forms.Button addModButton;
        private System.Windows.Forms.Button deleteModButton;
    }
}

