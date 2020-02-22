namespace ARK_Server_Configuration_Tool
{
    partial class UpdaterForm
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
            this.steamCmdLogTextBox = new System.Windows.Forms.TextBox();
            this.skipCurrentModButton = new System.Windows.Forms.Button();
            this.cancelModUpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // steamCmdLogTextBox
            // 
            this.steamCmdLogTextBox.Location = new System.Drawing.Point(12, 130);
            this.steamCmdLogTextBox.Multiline = true;
            this.steamCmdLogTextBox.Name = "steamCmdLogTextBox";
            this.steamCmdLogTextBox.ReadOnly = true;
            this.steamCmdLogTextBox.Size = new System.Drawing.Size(580, 308);
            this.steamCmdLogTextBox.TabIndex = 0;
            this.steamCmdLogTextBox.TextChanged += new System.EventHandler(this.steamCmdLogTextBox_TextChanged);
            // 
            // skipCurrentModButton
            // 
            this.skipCurrentModButton.Location = new System.Drawing.Point(12, 101);
            this.skipCurrentModButton.Name = "skipCurrentModButton";
            this.skipCurrentModButton.Size = new System.Drawing.Size(88, 23);
            this.skipCurrentModButton.TabIndex = 1;
            this.skipCurrentModButton.Text = "Skip Mod";
            this.skipCurrentModButton.UseVisualStyleBackColor = true;
            this.skipCurrentModButton.Click += new System.EventHandler(this.skipCurrentModButton_Click);
            // 
            // cancelModUpdateButton
            // 
            this.cancelModUpdateButton.Location = new System.Drawing.Point(106, 101);
            this.cancelModUpdateButton.Name = "cancelModUpdateButton";
            this.cancelModUpdateButton.Size = new System.Drawing.Size(88, 23);
            this.cancelModUpdateButton.TabIndex = 2;
            this.cancelModUpdateButton.Text = "Cancel Update";
            this.cancelModUpdateButton.UseVisualStyleBackColor = true;
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 450);
            this.Controls.Add(this.cancelModUpdateButton);
            this.Controls.Add(this.skipCurrentModButton);
            this.Controls.Add(this.steamCmdLogTextBox);
            this.Name = "UpdaterForm";
            this.Text = "UpdaterForm";
            this.Load += new System.EventHandler(this.UpdaterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox steamCmdLogTextBox;
        private System.Windows.Forms.Button skipCurrentModButton;
        private System.Windows.Forms.Button cancelModUpdateButton;
    }
}