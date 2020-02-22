namespace ARK_Server_Configuration_Tool
{
    partial class AddModForm
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
            this.commitAddModButton = new System.Windows.Forms.Button();
            this.modSearchTermTextBox = new System.Windows.Forms.TextBox();
            this.modNameOrIdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commitAddModButton
            // 
            this.commitAddModButton.Location = new System.Drawing.Point(12, 158);
            this.commitAddModButton.Name = "commitAddModButton";
            this.commitAddModButton.Size = new System.Drawing.Size(75, 23);
            this.commitAddModButton.TabIndex = 0;
            this.commitAddModButton.Text = "Add";
            this.commitAddModButton.UseVisualStyleBackColor = true;
            this.commitAddModButton.Click += new System.EventHandler(this.commitAddModButton_Click);
            // 
            // modSearchTermTextBox
            // 
            this.modSearchTermTextBox.Location = new System.Drawing.Point(12, 37);
            this.modSearchTermTextBox.Name = "modSearchTermTextBox";
            this.modSearchTermTextBox.Size = new System.Drawing.Size(100, 20);
            this.modSearchTermTextBox.TabIndex = 1;
            // 
            // modNameOrIdLabel
            // 
            this.modNameOrIdLabel.AutoSize = true;
            this.modNameOrIdLabel.Location = new System.Drawing.Point(12, 21);
            this.modNameOrIdLabel.Name = "modNameOrIdLabel";
            this.modNameOrIdLabel.Size = new System.Drawing.Size(85, 13);
            this.modNameOrIdLabel.TabIndex = 2;
            this.modNameOrIdLabel.Text = "Mod Name or ID";
            // 
            // AddModForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 252);
            this.Controls.Add(this.modNameOrIdLabel);
            this.Controls.Add(this.modSearchTermTextBox);
            this.Controls.Add(this.commitAddModButton);
            this.Name = "AddModForm";
            this.Text = "AddModForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button commitAddModButton;
        private System.Windows.Forms.TextBox modSearchTermTextBox;
        private System.Windows.Forms.Label modNameOrIdLabel;
    }
}