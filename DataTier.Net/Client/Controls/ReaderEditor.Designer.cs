

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ReaderEditor
    /// <summary>
    /// This is the designer code for the ReaderEditor control.
    /// </summary>
    partial class ReaderEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox ReaderReferencesSetComboBox;
        private System.Windows.Forms.TextBox ReaderFolderTextBox;
        private System.Windows.Forms.TextBox ReaderNamespaceTextBox;
        private System.Windows.Forms.Label ReaderFolderLabel;
        private System.Windows.Forms.Label ReaderReferencesSetLabel;
        private System.Windows.Forms.Label ReaderNamespaceLabel;
        private TabButton EditReaderReferencesSetButton;
        private TabButton BrowseReaderFolderButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReaderEditor));
            this.ReaderReferencesSetComboBox = new System.Windows.Forms.ComboBox();
            this.ReaderFolderTextBox = new System.Windows.Forms.TextBox();
            this.ReaderNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.ReaderFolderLabel = new System.Windows.Forms.Label();
            this.ReaderReferencesSetLabel = new System.Windows.Forms.Label();
            this.ReaderNamespaceLabel = new System.Windows.Forms.Label();
            this.EditReaderReferencesSetButton = new DataTierClient.Controls.TabButton();
            this.BrowseReaderFolderButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // ReaderReferencesSetComboBox
            // 
            this.ReaderReferencesSetComboBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderReferencesSetComboBox.FormattingEnabled = true;
            this.ReaderReferencesSetComboBox.Location = new System.Drawing.Point(218, 108);
            this.ReaderReferencesSetComboBox.Name = "ReaderReferencesSetComboBox";
            this.ReaderReferencesSetComboBox.Size = new System.Drawing.Size(271, 34);
            this.ReaderReferencesSetComboBox.TabIndex = 88;
            this.ReaderReferencesSetComboBox.SelectedIndexChanged += new System.EventHandler(this.ReaderReferencesSetComboBox_SelectedIndexChanged);
            // 
            // ReaderFolderTextBox
            // 
            this.ReaderFolderTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderFolderTextBox.Location = new System.Drawing.Point(218, 20);
            this.ReaderFolderTextBox.Name = "ReaderFolderTextBox";
            this.ReaderFolderTextBox.Size = new System.Drawing.Size(404, 34);
            this.ReaderFolderTextBox.TabIndex = 86;
            this.ReaderFolderTextBox.TextChanged += new System.EventHandler(this.ReaderFolderTextBox_TextChanged);
            // 
            // ReaderNamespaceTextBox
            // 
            this.ReaderNamespaceTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderNamespaceTextBox.Location = new System.Drawing.Point(218, 64);
            this.ReaderNamespaceTextBox.Name = "ReaderNamespaceTextBox";
            this.ReaderNamespaceTextBox.Size = new System.Drawing.Size(437, 34);
            this.ReaderNamespaceTextBox.TabIndex = 85;
            this.ReaderNamespaceTextBox.TextChanged += new System.EventHandler(this.ReaderNamespaceTextBox_TextChanged);
            // 
            // ReaderFolderLabel
            // 
            this.ReaderFolderLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderFolderLabel.Location = new System.Drawing.Point(8, 26);
            this.ReaderFolderLabel.Name = "ReaderFolderLabel";
            this.ReaderFolderLabel.Size = new System.Drawing.Size(212, 24);
            this.ReaderFolderLabel.TabIndex = 84;
            this.ReaderFolderLabel.Text = "Reader Folder:";
            this.ReaderFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReaderReferencesSetLabel
            // 
            this.ReaderReferencesSetLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderReferencesSetLabel.Location = new System.Drawing.Point(8, 114);
            this.ReaderReferencesSetLabel.Name = "ReaderReferencesSetLabel";
            this.ReaderReferencesSetLabel.Size = new System.Drawing.Size(212, 24);
            this.ReaderReferencesSetLabel.TabIndex = 83;
            this.ReaderReferencesSetLabel.Text = "Reader Reference Set:";
            this.ReaderReferencesSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReaderNamespaceLabel
            // 
            this.ReaderNamespaceLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderNamespaceLabel.Location = new System.Drawing.Point(8, 70);
            this.ReaderNamespaceLabel.Name = "ReaderNamespaceLabel";
            this.ReaderNamespaceLabel.Size = new System.Drawing.Size(212, 24);
            this.ReaderNamespaceLabel.TabIndex = 82;
            this.ReaderNamespaceLabel.Text = "Reader Namespace:";
            this.ReaderNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditReaderReferencesSetButton
            // 
            this.EditReaderReferencesSetButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditReaderReferencesSetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditReaderReferencesSetButton.ButtonNumber = 0;
            this.EditReaderReferencesSetButton.ButtonText = "Edit";
            this.EditReaderReferencesSetButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditReaderReferencesSetButton.Location = new System.Drawing.Point(583, 107);
            this.EditReaderReferencesSetButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditReaderReferencesSetButton.Name = "EditReaderReferencesSetButton";
            this.EditReaderReferencesSetButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditReaderReferencesSetButton.Selected = false;
            this.EditReaderReferencesSetButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditReaderReferencesSetButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditReaderReferencesSetButton.Size = new System.Drawing.Size(72, 32);
            this.EditReaderReferencesSetButton.TabIndex = 96;
            // 
            // BrowseReaderFolderButton
            // 
            this.BrowseReaderFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseReaderFolderButton.BackgroundImage")));
            this.BrowseReaderFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseReaderFolderButton.ButtonNumber = 0;
            this.BrowseReaderFolderButton.ButtonText = "...";
            this.BrowseReaderFolderButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseReaderFolderButton.Location = new System.Drawing.Point(615, 21);
            this.BrowseReaderFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseReaderFolderButton.Name = "BrowseReaderFolderButton";
            this.BrowseReaderFolderButton.NotSelectedImage = null;
            this.BrowseReaderFolderButton.Selected = false;
            this.BrowseReaderFolderButton.SelectedImage = null;
            this.BrowseReaderFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseReaderFolderButton.Size = new System.Drawing.Size(40, 32);
            this.BrowseReaderFolderButton.TabIndex = 94;
            // 
            // ReaderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EditReaderReferencesSetButton);
            this.Controls.Add(this.BrowseReaderFolderButton);
            this.Controls.Add(this.ReaderFolderTextBox);
            this.Controls.Add(this.ReaderReferencesSetComboBox);
            this.Controls.Add(this.ReaderNamespaceTextBox);
            this.Controls.Add(this.ReaderFolderLabel);
            this.Controls.Add(this.ReaderReferencesSetLabel);
            this.Controls.Add(this.ReaderNamespaceLabel);
            this.Name = "ReaderEditor";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}



