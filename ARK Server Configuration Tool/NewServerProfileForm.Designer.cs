namespace ARK_Server_Configuration_Tool
{
    partial class NewServerProfileForm
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
            this.CommitCreateProfileButton = new System.Windows.Forms.Button();
            this.CancelCreateProfileButton = new System.Windows.Forms.Button();
            this.ProfileNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProfileServerLocationLabel = new System.Windows.Forms.Label();
            this.ServerRootDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.BrowseForServerRootDirectoryButton = new System.Windows.Forms.Button();
            this.ImportInisCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CommitCreateProfileButton
            // 
            this.CommitCreateProfileButton.Location = new System.Drawing.Point(156, 198);
            this.CommitCreateProfileButton.Name = "CommitCreateProfileButton";
            this.CommitCreateProfileButton.Size = new System.Drawing.Size(75, 23);
            this.CommitCreateProfileButton.TabIndex = 0;
            this.CommitCreateProfileButton.Text = "Create";
            this.CommitCreateProfileButton.UseVisualStyleBackColor = true;
            this.CommitCreateProfileButton.Click += new System.EventHandler(this.CommitCreateProfileButton_Click);
            // 
            // CancelCreateProfileButton
            // 
            this.CancelCreateProfileButton.Location = new System.Drawing.Point(237, 198);
            this.CancelCreateProfileButton.Name = "CancelCreateProfileButton";
            this.CancelCreateProfileButton.Size = new System.Drawing.Size(75, 23);
            this.CancelCreateProfileButton.TabIndex = 1;
            this.CancelCreateProfileButton.Text = "Cancel";
            this.CancelCreateProfileButton.UseVisualStyleBackColor = true;
            this.CancelCreateProfileButton.Click += new System.EventHandler(this.CancelCreateProfileButton_Click);
            // 
            // ProfileNameTextBox
            // 
            this.ProfileNameTextBox.Location = new System.Drawing.Point(12, 25);
            this.ProfileNameTextBox.Name = "ProfileNameTextBox";
            this.ProfileNameTextBox.Size = new System.Drawing.Size(300, 20);
            this.ProfileNameTextBox.TabIndex = 2;
            this.ProfileNameTextBox.Text = "New Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Name";
            // 
            // ProfileServerLocationLabel
            // 
            this.ProfileServerLocationLabel.AutoSize = true;
            this.ProfileServerLocationLabel.Location = new System.Drawing.Point(9, 67);
            this.ProfileServerLocationLabel.Name = "ProfileServerLocationLabel";
            this.ProfileServerLocationLabel.Size = new System.Drawing.Size(109, 13);
            this.ProfileServerLocationLabel.TabIndex = 4;
            this.ProfileServerLocationLabel.Text = "Server Root Directory";
            // 
            // ServerRootDirectoryTextBox
            // 
            this.ServerRootDirectoryTextBox.Location = new System.Drawing.Point(12, 83);
            this.ServerRootDirectoryTextBox.Name = "ServerRootDirectoryTextBox";
            this.ServerRootDirectoryTextBox.Size = new System.Drawing.Size(219, 20);
            this.ServerRootDirectoryTextBox.TabIndex = 5;
            this.ServerRootDirectoryTextBox.TextChanged += new System.EventHandler(this.ServerRootDirectoryTextBox_TextChanged);
            // 
            // BrowseForServerRootDirectoryButton
            // 
            this.BrowseForServerRootDirectoryButton.Location = new System.Drawing.Point(237, 82);
            this.BrowseForServerRootDirectoryButton.Name = "BrowseForServerRootDirectoryButton";
            this.BrowseForServerRootDirectoryButton.Size = new System.Drawing.Size(75, 22);
            this.BrowseForServerRootDirectoryButton.TabIndex = 6;
            this.BrowseForServerRootDirectoryButton.Text = "Browse...";
            this.BrowseForServerRootDirectoryButton.UseVisualStyleBackColor = true;
            this.BrowseForServerRootDirectoryButton.Click += new System.EventHandler(this.BrowseForServerRootDirectoryButton_Click);
            // 
            // ImportInisCheckBox
            // 
            this.ImportInisCheckBox.AutoSize = true;
            this.ImportInisCheckBox.Location = new System.Drawing.Point(12, 123);
            this.ImportInisCheckBox.Name = "ImportInisCheckBox";
            this.ImportInisCheckBox.Size = new System.Drawing.Size(96, 17);
            this.ImportInisCheckBox.TabIndex = 7;
            this.ImportInisCheckBox.Text = "Import Settings";
            this.ImportInisCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewServerProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 231);
            this.Controls.Add(this.ImportInisCheckBox);
            this.Controls.Add(this.BrowseForServerRootDirectoryButton);
            this.Controls.Add(this.ServerRootDirectoryTextBox);
            this.Controls.Add(this.ProfileServerLocationLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProfileNameTextBox);
            this.Controls.Add(this.CancelCreateProfileButton);
            this.Controls.Add(this.CommitCreateProfileButton);
            this.Name = "NewServerProfileForm";
            this.Text = "New Profile";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CommitCreateProfileButton;
        private System.Windows.Forms.Button CancelCreateProfileButton;
        private System.Windows.Forms.TextBox ProfileNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ProfileServerLocationLabel;
        private System.Windows.Forms.TextBox ServerRootDirectoryTextBox;
        private System.Windows.Forms.Button BrowseForServerRootDirectoryButton;
        private System.Windows.Forms.CheckBox ImportInisCheckBox;
    }
}