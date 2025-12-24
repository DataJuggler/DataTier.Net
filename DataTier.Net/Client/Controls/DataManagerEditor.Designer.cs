

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class DataManagerEditor
    /// <summary>
    /// This class is used as the Data Manager References Editor
    /// </summary>
    partial class DataManagerEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox DataManagerReferencesSetComboBox;
        private System.Windows.Forms.TextBox DataManagerFolderTextBox;
        private System.Windows.Forms.TextBox DataManagerNamespaceTextBox;
        private System.Windows.Forms.Label DataManagerFolderLabel;
        private System.Windows.Forms.Label DataManagerReferencesSetLabel;
        private System.Windows.Forms.Label DataManagerNamespaceLabel;
        private TabButton BrowseDataManagerFolderButton;
        private TabButton EditDataManagerReferencesSetButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataManagerEditor));
            this.DataManagerReferencesSetComboBox = new System.Windows.Forms.ComboBox();
            this.DataManagerFolderTextBox = new System.Windows.Forms.TextBox();
            this.DataManagerNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.DataManagerFolderLabel = new System.Windows.Forms.Label();
            this.DataManagerReferencesSetLabel = new System.Windows.Forms.Label();
            this.DataManagerNamespaceLabel = new System.Windows.Forms.Label();
            this.BrowseDataManagerFolderButton = new DataTierClient.Controls.TabButton();
            this.EditDataManagerReferencesSetButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // DataManagerReferencesSetComboBox
            // 
            this.DataManagerReferencesSetComboBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManagerReferencesSetComboBox.FormattingEnabled = true;
            this.DataManagerReferencesSetComboBox.Location = new System.Drawing.Point(218, 108);
            this.DataManagerReferencesSetComboBox.Name = "DataManagerReferencesSetComboBox";
            this.DataManagerReferencesSetComboBox.Size = new System.Drawing.Size(271, 34);
            this.DataManagerReferencesSetComboBox.TabIndex = 124;
            this.DataManagerReferencesSetComboBox.SelectedIndexChanged += new System.EventHandler(this.DataManagerReferencesSetComboBox_SelectedIndexChanged);
            // 
            // DataManagerFolderTextBox
            // 
            this.DataManagerFolderTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManagerFolderTextBox.Location = new System.Drawing.Point(218, 20);
            this.DataManagerFolderTextBox.Name = "DataManagerFolderTextBox";
            this.DataManagerFolderTextBox.Size = new System.Drawing.Size(404, 34);
            this.DataManagerFolderTextBox.TabIndex = 122;
            this.DataManagerFolderTextBox.TextChanged += new System.EventHandler(this.DataManagerFolderTextBox_TextChanged);
            // 
            // DataManagerNamespaceTextBox
            // 
            this.DataManagerNamespaceTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManagerNamespaceTextBox.Location = new System.Drawing.Point(218, 64);
            this.DataManagerNamespaceTextBox.Name = "DataManagerNamespaceTextBox";
            this.DataManagerNamespaceTextBox.Size = new System.Drawing.Size(437, 34);
            this.DataManagerNamespaceTextBox.TabIndex = 121;
            this.DataManagerNamespaceTextBox.TextChanged += new System.EventHandler(this.DataManagerNamespaceTextBox_TextChanged);
            // 
            // DataManagerFolderLabel
            // 
            this.DataManagerFolderLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManagerFolderLabel.Location = new System.Drawing.Point(3, 24);
            this.DataManagerFolderLabel.Name = "DataManagerFolderLabel";
            this.DataManagerFolderLabel.Size = new System.Drawing.Size(217, 24);
            this.DataManagerFolderLabel.TabIndex = 120;
            this.DataManagerFolderLabel.Text = "Data Mgr Folder:";
            this.DataManagerFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataManagerReferencesSetLabel
            // 
            this.DataManagerReferencesSetLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManagerReferencesSetLabel.Location = new System.Drawing.Point(3, 112);
            this.DataManagerReferencesSetLabel.Name = "DataManagerReferencesSetLabel";
            this.DataManagerReferencesSetLabel.Size = new System.Drawing.Size(217, 24);
            this.DataManagerReferencesSetLabel.TabIndex = 119;
            this.DataManagerReferencesSetLabel.Text = "Data Mgr Ref Set:";
            this.DataManagerReferencesSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataManagerNamespaceLabel
            // 
            this.DataManagerNamespaceLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManagerNamespaceLabel.Location = new System.Drawing.Point(3, 68);
            this.DataManagerNamespaceLabel.Name = "DataManagerNamespaceLabel";
            this.DataManagerNamespaceLabel.Size = new System.Drawing.Size(217, 24);
            this.DataManagerNamespaceLabel.TabIndex = 118;
            this.DataManagerNamespaceLabel.Text = "Data Mgr Namespace:";
            this.DataManagerNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrowseDataManagerFolderButton
            // 
            this.BrowseDataManagerFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseDataManagerFolderButton.BackgroundImage")));
            this.BrowseDataManagerFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseDataManagerFolderButton.ButtonNumber = 0;
            this.BrowseDataManagerFolderButton.ButtonText = "...";
            this.BrowseDataManagerFolderButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseDataManagerFolderButton.Location = new System.Drawing.Point(615, 20);
            this.BrowseDataManagerFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseDataManagerFolderButton.Name = "BrowseDataManagerFolderButton";
            this.BrowseDataManagerFolderButton.NotSelectedImage = null;
            this.BrowseDataManagerFolderButton.Selected = false;
            this.BrowseDataManagerFolderButton.SelectedImage = null;
            this.BrowseDataManagerFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseDataManagerFolderButton.Size = new System.Drawing.Size(40, 32);
            this.BrowseDataManagerFolderButton.TabIndex = 127;
            // 
            // EditDataManagerReferencesSetButton
            // 
            this.EditDataManagerReferencesSetButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditDataManagerReferencesSetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditDataManagerReferencesSetButton.ButtonNumber = 0;
            this.EditDataManagerReferencesSetButton.ButtonText = "Edit";
            this.EditDataManagerReferencesSetButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditDataManagerReferencesSetButton.Location = new System.Drawing.Point(583, 107);
            this.EditDataManagerReferencesSetButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditDataManagerReferencesSetButton.Name = "EditDataManagerReferencesSetButton";
            this.EditDataManagerReferencesSetButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditDataManagerReferencesSetButton.Selected = false;
            this.EditDataManagerReferencesSetButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditDataManagerReferencesSetButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditDataManagerReferencesSetButton.Size = new System.Drawing.Size(72, 32);
            this.EditDataManagerReferencesSetButton.TabIndex = 128;
            // 
            // DataManagerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EditDataManagerReferencesSetButton);
            this.Controls.Add(this.BrowseDataManagerFolderButton);
            this.Controls.Add(this.DataManagerFolderTextBox);
            this.Controls.Add(this.DataManagerReferencesSetComboBox);
            this.Controls.Add(this.DataManagerNamespaceTextBox);
            this.Controls.Add(this.DataManagerFolderLabel);
            this.Controls.Add(this.DataManagerReferencesSetLabel);
            this.Controls.Add(this.DataManagerNamespaceLabel);
            this.Name = "DataManagerEditor";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}



