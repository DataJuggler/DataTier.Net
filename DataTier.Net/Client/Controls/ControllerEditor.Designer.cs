

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ControllerEditor
    /// <summary>
    /// This is the designer code for the ControllerEditor control.
    /// </summary>
    partial class ControllerEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox ControllerReferencesSetComboBox;
        private System.Windows.Forms.TextBox ControllerFolderTextBox;
        private System.Windows.Forms.TextBox ControllerNamespaceTextBox;
        private System.Windows.Forms.Label ControllerFolderLabel;
        private System.Windows.Forms.Label ControllerReferencesSetLabel;
        private System.Windows.Forms.Label ControllerNamespaceLabel;
        private TabButton EditControllerReferencesSetButton;
        private TabButton ControllerFolderBrowseButton;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
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
            #endregion
            
            #region InitializeComponent()
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerEditor));
            this.ControllerReferencesSetComboBox = new System.Windows.Forms.ComboBox();
            this.ControllerFolderTextBox = new System.Windows.Forms.TextBox();
            this.ControllerNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.ControllerFolderLabel = new System.Windows.Forms.Label();
            this.ControllerReferencesSetLabel = new System.Windows.Forms.Label();
            this.ControllerNamespaceLabel = new System.Windows.Forms.Label();
            this.EditControllerReferencesSetButton = new DataTierClient.Controls.TabButton();
            this.ControllerFolderBrowseButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // ControllerReferencesSetComboBox
            // 
            this.ControllerReferencesSetComboBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerReferencesSetComboBox.FormattingEnabled = true;
            this.ControllerReferencesSetComboBox.Location = new System.Drawing.Point(218, 100);
            this.ControllerReferencesSetComboBox.Name = "ControllerReferencesSetComboBox";
            this.ControllerReferencesSetComboBox.Size = new System.Drawing.Size(271, 26);
            this.ControllerReferencesSetComboBox.TabIndex = 97;
            this.ControllerReferencesSetComboBox.SelectedIndexChanged += new System.EventHandler(this.ControllerReferencesSetComboBox_SelectedIndexChanged);
            // 
            // ControllerFolderTextBox
            // 
            this.ControllerFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerFolderTextBox.Location = new System.Drawing.Point(218, 20);
            this.ControllerFolderTextBox.Name = "ControllerFolderTextBox";
            this.ControllerFolderTextBox.Size = new System.Drawing.Size(404, 27);
            this.ControllerFolderTextBox.TabIndex = 95;
            this.ControllerFolderTextBox.TextChanged += new System.EventHandler(this.ControllerFolderTextBox_TextChanged);
            // 
            // ControllerNamespaceTextBox
            // 
            this.ControllerNamespaceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerNamespaceTextBox.Location = new System.Drawing.Point(218, 60);
            this.ControllerNamespaceTextBox.Name = "ControllerNamespaceTextBox";
            this.ControllerNamespaceTextBox.Size = new System.Drawing.Size(437, 27);
            this.ControllerNamespaceTextBox.TabIndex = 94;
            this.ControllerNamespaceTextBox.TextChanged += new System.EventHandler(this.ControllerNamespaceTextBox_TextChanged);
            // 
            // ControllerFolderLabel
            // 
            this.ControllerFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerFolderLabel.Location = new System.Drawing.Point(20, 24);
            this.ControllerFolderLabel.Name = "ControllerFolderLabel";
            this.ControllerFolderLabel.Size = new System.Drawing.Size(200, 20);
            this.ControllerFolderLabel.TabIndex = 93;
            this.ControllerFolderLabel.Text = "Controller Folder:";
            this.ControllerFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ControllerReferencesSetLabel
            // 
            this.ControllerReferencesSetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerReferencesSetLabel.Location = new System.Drawing.Point(20, 104);
            this.ControllerReferencesSetLabel.Name = "ControllerReferencesSetLabel";
            this.ControllerReferencesSetLabel.Size = new System.Drawing.Size(200, 20);
            this.ControllerReferencesSetLabel.TabIndex = 92;
            this.ControllerReferencesSetLabel.Text = "Controller Ref Set:";
            this.ControllerReferencesSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ControllerNamespaceLabel
            // 
            this.ControllerNamespaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerNamespaceLabel.Location = new System.Drawing.Point(20, 64);
            this.ControllerNamespaceLabel.Name = "ControllerNamespaceLabel";
            this.ControllerNamespaceLabel.Size = new System.Drawing.Size(200, 20);
            this.ControllerNamespaceLabel.TabIndex = 91;
            this.ControllerNamespaceLabel.Text = "Controller Namespace:";
            this.ControllerNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditControllerReferencesSetButton
            // 
            this.EditControllerReferencesSetButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditControllerReferencesSetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditControllerReferencesSetButton.ButtonNumber = 0;
            this.EditControllerReferencesSetButton.ButtonText = "Edit";
            this.EditControllerReferencesSetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditControllerReferencesSetButton.Location = new System.Drawing.Point(583, 99);
            this.EditControllerReferencesSetButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditControllerReferencesSetButton.Name = "EditControllerReferencesSetButton";
            this.EditControllerReferencesSetButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditControllerReferencesSetButton.Selected = false;
            this.EditControllerReferencesSetButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditControllerReferencesSetButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditControllerReferencesSetButton.Size = new System.Drawing.Size(72, 28);
            this.EditControllerReferencesSetButton.TabIndex = 102;
            // 
            // ControllerFolderBrowseButton
            // 
            this.ControllerFolderBrowseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ControllerFolderBrowseButton.BackgroundImage")));
            this.ControllerFolderBrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ControllerFolderBrowseButton.ButtonNumber = 0;
            this.ControllerFolderBrowseButton.ButtonText = "...";
            this.ControllerFolderBrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControllerFolderBrowseButton.Location = new System.Drawing.Point(615, 19);
            this.ControllerFolderBrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ControllerFolderBrowseButton.Name = "ControllerFolderBrowseButton";
            this.ControllerFolderBrowseButton.NotSelectedImage = null;
            this.ControllerFolderBrowseButton.Selected = false;
            this.ControllerFolderBrowseButton.SelectedImage = null;
            this.ControllerFolderBrowseButton.ShowNotSelectedImageWhenDisabled = true;
            this.ControllerFolderBrowseButton.Size = new System.Drawing.Size(40, 28);
            this.ControllerFolderBrowseButton.TabIndex = 100;
            // 
            // ControllerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EditControllerReferencesSetButton);
            this.Controls.Add(this.ControllerFolderBrowseButton);
            this.Controls.Add(this.ControllerFolderTextBox);
            this.Controls.Add(this.ControllerReferencesSetComboBox);
            this.Controls.Add(this.ControllerNamespaceTextBox);
            this.Controls.Add(this.ControllerFolderLabel);
            this.Controls.Add(this.ControllerReferencesSetLabel);
            this.Controls.Add(this.ControllerNamespaceLabel);
            this.Name = "ControllerEditor";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
