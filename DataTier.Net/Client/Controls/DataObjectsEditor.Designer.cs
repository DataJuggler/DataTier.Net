
#region using statements

#endregion

namespace DataTierClient.Controls
{

    #region class DataObjectsEditor
    /// <summary>
    /// This is the designer generated code fro the DataObjectsEditor
    /// </summary>
    partial class DataObjectsEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox ObjectReferencesComboBox;
        private System.Windows.Forms.TextBox ObjectNamespaceTextBox;
        private System.Windows.Forms.TextBox ObjectFolderTextBox;
        private System.Windows.Forms.Label ObjectNamespaceLabel;
        private System.Windows.Forms.Label ObjectReferencesLabel;
        private System.Windows.Forms.Label ObjectFolderLabel;
        private TabButton BrowseDataObjectsFolderButton;
        private TabButton EditObjectReferencesButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataObjectsEditor));
            this.ObjectReferencesComboBox = new System.Windows.Forms.ComboBox();
            this.ObjectNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.ObjectFolderTextBox = new System.Windows.Forms.TextBox();
            this.ObjectNamespaceLabel = new System.Windows.Forms.Label();
            this.ObjectReferencesLabel = new System.Windows.Forms.Label();
            this.ObjectFolderLabel = new System.Windows.Forms.Label();
            this.BrowseDataObjectsFolderButton = new DataTierClient.Controls.TabButton();
            this.EditObjectReferencesButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // ObjectReferencesComboBox
            // 
            this.ObjectReferencesComboBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectReferencesComboBox.FormattingEnabled = true;
            this.ObjectReferencesComboBox.Location = new System.Drawing.Point(218, 100);
            this.ObjectReferencesComboBox.Name = "ObjectReferencesComboBox";
            this.ObjectReferencesComboBox.Size = new System.Drawing.Size(271, 34);
            this.ObjectReferencesComboBox.TabIndex = 88;
            this.ObjectReferencesComboBox.SelectedIndexChanged += new System.EventHandler(this.ObjectReferencesComboBox_SelectedIndexChanged);
            // 
            // ObjectNamespaceTextBox
            // 
            this.ObjectNamespaceTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectNamespaceTextBox.Location = new System.Drawing.Point(218, 60);
            this.ObjectNamespaceTextBox.Name = "ObjectNamespaceTextBox";
            this.ObjectNamespaceTextBox.Size = new System.Drawing.Size(437, 34);
            this.ObjectNamespaceTextBox.TabIndex = 87;
            this.ObjectNamespaceTextBox.TextChanged += new System.EventHandler(this.ObjectNamespaceTextBox_TextChanged);
            // 
            // ObjectFolderTextBox
            // 
            this.ObjectFolderTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectFolderTextBox.Location = new System.Drawing.Point(218, 20);
            this.ObjectFolderTextBox.Name = "ObjectFolderTextBox";
            this.ObjectFolderTextBox.Size = new System.Drawing.Size(404, 34);
            this.ObjectFolderTextBox.TabIndex = 85;
            this.ObjectFolderTextBox.TextChanged += new System.EventHandler(this.ObjectFolderTextBox_TextChanged);
            // 
            // ObjectNamespaceLabel
            // 
            this.ObjectNamespaceLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectNamespaceLabel.Location = new System.Drawing.Point(20, 64);
            this.ObjectNamespaceLabel.Name = "ObjectNamespaceLabel";
            this.ObjectNamespaceLabel.Size = new System.Drawing.Size(200, 24);
            this.ObjectNamespaceLabel.TabIndex = 84;
            this.ObjectNamespaceLabel.Text = "Object Namespace:";
            this.ObjectNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ObjectReferencesLabel
            // 
            this.ObjectReferencesLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectReferencesLabel.Location = new System.Drawing.Point(20, 104);
            this.ObjectReferencesLabel.Name = "ObjectReferencesLabel";
            this.ObjectReferencesLabel.Size = new System.Drawing.Size(200, 24);
            this.ObjectReferencesLabel.TabIndex = 83;
            this.ObjectReferencesLabel.Text = "Object References Set:";
            this.ObjectReferencesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ObjectFolderLabel
            // 
            this.ObjectFolderLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectFolderLabel.Location = new System.Drawing.Point(20, 24);
            this.ObjectFolderLabel.Name = "ObjectFolderLabel";
            this.ObjectFolderLabel.Size = new System.Drawing.Size(200, 24);
            this.ObjectFolderLabel.TabIndex = 82;
            this.ObjectFolderLabel.Text = "Object Folder:";
            this.ObjectFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrowseDataObjectsFolderButton
            // 
            this.BrowseDataObjectsFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseDataObjectsFolderButton.BackgroundImage")));
            this.BrowseDataObjectsFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseDataObjectsFolderButton.ButtonNumber = 0;
            this.BrowseDataObjectsFolderButton.ButtonText = "...";
            this.BrowseDataObjectsFolderButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseDataObjectsFolderButton.Location = new System.Drawing.Point(615, 20);
            this.BrowseDataObjectsFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseDataObjectsFolderButton.Name = "BrowseDataObjectsFolderButton";
            this.BrowseDataObjectsFolderButton.NotSelectedImage = null;
            this.BrowseDataObjectsFolderButton.Selected = false;
            this.BrowseDataObjectsFolderButton.SelectedImage = null;
            this.BrowseDataObjectsFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseDataObjectsFolderButton.Size = new System.Drawing.Size(40, 32);
            this.BrowseDataObjectsFolderButton.TabIndex = 91;
            // 
            // EditObjectReferencesButton
            // 
            this.EditObjectReferencesButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditObjectReferencesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditObjectReferencesButton.ButtonNumber = 0;
            this.EditObjectReferencesButton.ButtonText = "Edit";
            this.EditObjectReferencesButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditObjectReferencesButton.Location = new System.Drawing.Point(583, 99);
            this.EditObjectReferencesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditObjectReferencesButton.Name = "EditObjectReferencesButton";
            this.EditObjectReferencesButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditObjectReferencesButton.Selected = false;
            this.EditObjectReferencesButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditObjectReferencesButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditObjectReferencesButton.Size = new System.Drawing.Size(72, 32);
            this.EditObjectReferencesButton.TabIndex = 93;
            // 
            // DataObjectsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EditObjectReferencesButton);
            this.Controls.Add(this.BrowseDataObjectsFolderButton);
            this.Controls.Add(this.ObjectFolderTextBox);
            this.Controls.Add(this.ObjectReferencesComboBox);
            this.Controls.Add(this.ObjectNamespaceTextBox);
            this.Controls.Add(this.ObjectNamespaceLabel);
            this.Controls.Add(this.ObjectReferencesLabel);
            this.Controls.Add(this.ObjectFolderLabel);
            this.Name = "DataObjectsEditor";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}



