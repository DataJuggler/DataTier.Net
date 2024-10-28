

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class DataOperationsEditor
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class DataOperationsEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox DataOperationsReferencesSetCombobox;
        private System.Windows.Forms.TextBox DataOperationsFolderTextBox;
        private System.Windows.Forms.TextBox DataOperationsNamespaceTextBox;
        private System.Windows.Forms.Label DataOperationsFolderLabel;
        private System.Windows.Forms.Label DataOperationsReferencesSetLabel;
        private System.Windows.Forms.Label DataOperationsNamespaceLabel;
        private TabButton EditDataOperationsReferencesSet;
        private TabButton BrowseDataOperationsFolderButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataOperationsEditor));
            this.DataOperationsReferencesSetCombobox = new System.Windows.Forms.ComboBox();
            this.DataOperationsFolderTextBox = new System.Windows.Forms.TextBox();
            this.DataOperationsNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.DataOperationsFolderLabel = new System.Windows.Forms.Label();
            this.DataOperationsReferencesSetLabel = new System.Windows.Forms.Label();
            this.DataOperationsNamespaceLabel = new System.Windows.Forms.Label();
            this.EditDataOperationsReferencesSet = new DataTierClient.Controls.TabButton();
            this.BrowseDataOperationsFolderButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // DataOperationsReferencesSetCombobox
            // 
            this.DataOperationsReferencesSetCombobox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataOperationsReferencesSetCombobox.FormattingEnabled = true;
            this.DataOperationsReferencesSetCombobox.Location = new System.Drawing.Point(218, 100);
            this.DataOperationsReferencesSetCombobox.Name = "DataOperationsReferencesSetCombobox";
            this.DataOperationsReferencesSetCombobox.Size = new System.Drawing.Size(271, 26);
            this.DataOperationsReferencesSetCombobox.TabIndex = 106;
            this.DataOperationsReferencesSetCombobox.SelectedIndexChanged += new System.EventHandler(this.DataOperationsReferencesSetCombobox_SelectedIndexChanged);
            // 
            // DataOperationsFolderTextBox
            // 
            this.DataOperationsFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataOperationsFolderTextBox.Location = new System.Drawing.Point(218, 20);
            this.DataOperationsFolderTextBox.Name = "DataOperationsFolderTextBox";
            this.DataOperationsFolderTextBox.Size = new System.Drawing.Size(404, 27);
            this.DataOperationsFolderTextBox.TabIndex = 104;
            this.DataOperationsFolderTextBox.TextChanged += new System.EventHandler(this.DataOperationsFolderTextBox_TextChanged);
            // 
            // DataOperationsNamespaceTextBox
            // 
            this.DataOperationsNamespaceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataOperationsNamespaceTextBox.Location = new System.Drawing.Point(218, 60);
            this.DataOperationsNamespaceTextBox.Name = "DataOperationsNamespaceTextBox";
            this.DataOperationsNamespaceTextBox.Size = new System.Drawing.Size(437, 27);
            this.DataOperationsNamespaceTextBox.TabIndex = 103;
            this.DataOperationsNamespaceTextBox.TextChanged += new System.EventHandler(this.DataOperationsNamespaceTextBox_TextChanged);
            // 
            // DataOperationsFolderLabel
            // 
            this.DataOperationsFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataOperationsFolderLabel.Location = new System.Drawing.Point(20, 24);
            this.DataOperationsFolderLabel.Name = "DataOperationsFolderLabel";
            this.DataOperationsFolderLabel.Size = new System.Drawing.Size(200, 20);
            this.DataOperationsFolderLabel.TabIndex = 102;
            this.DataOperationsFolderLabel.Text = "Operations Folder:";
            this.DataOperationsFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataOperationsReferencesSetLabel
            // 
            this.DataOperationsReferencesSetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataOperationsReferencesSetLabel.Location = new System.Drawing.Point(20, 104);
            this.DataOperationsReferencesSetLabel.Name = "DataOperationsReferencesSetLabel";
            this.DataOperationsReferencesSetLabel.Size = new System.Drawing.Size(200, 20);
            this.DataOperationsReferencesSetLabel.TabIndex = 101;
            this.DataOperationsReferencesSetLabel.Text = "Operations Ref Set:";
            this.DataOperationsReferencesSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataOperationsNamespaceLabel
            // 
            this.DataOperationsNamespaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataOperationsNamespaceLabel.Location = new System.Drawing.Point(20, 64);
            this.DataOperationsNamespaceLabel.Name = "DataOperationsNamespaceLabel";
            this.DataOperationsNamespaceLabel.Size = new System.Drawing.Size(200, 20);
            this.DataOperationsNamespaceLabel.TabIndex = 100;
            this.DataOperationsNamespaceLabel.Text = "Oper. Namespace:";
            this.DataOperationsNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditDataOperationsReferencesSet
            // 
            this.EditDataOperationsReferencesSet.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditDataOperationsReferencesSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditDataOperationsReferencesSet.ButtonNumber = 0;
            this.EditDataOperationsReferencesSet.ButtonText = "Edit";
            this.EditDataOperationsReferencesSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditDataOperationsReferencesSet.Location = new System.Drawing.Point(583, 99);
            this.EditDataOperationsReferencesSet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditDataOperationsReferencesSet.Name = "EditDataOperationsReferencesSet";
            this.EditDataOperationsReferencesSet.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditDataOperationsReferencesSet.Selected = false;
            this.EditDataOperationsReferencesSet.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditDataOperationsReferencesSet.ShowNotSelectedImageWhenDisabled = true;
            this.EditDataOperationsReferencesSet.Size = new System.Drawing.Size(72, 28);
            this.EditDataOperationsReferencesSet.TabIndex = 111;
            // 
            // BrowseDataOperationsFolderButton
            // 
            this.BrowseDataOperationsFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseDataOperationsFolderButton.BackgroundImage")));
            this.BrowseDataOperationsFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseDataOperationsFolderButton.ButtonNumber = 0;
            this.BrowseDataOperationsFolderButton.ButtonText = "...";
            this.BrowseDataOperationsFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseDataOperationsFolderButton.Location = new System.Drawing.Point(615, 19);
            this.BrowseDataOperationsFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseDataOperationsFolderButton.Name = "BrowseDataOperationsFolderButton";
            this.BrowseDataOperationsFolderButton.NotSelectedImage = null;
            this.BrowseDataOperationsFolderButton.Selected = false;
            this.BrowseDataOperationsFolderButton.SelectedImage = null;
            this.BrowseDataOperationsFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseDataOperationsFolderButton.Size = new System.Drawing.Size(40, 28);
            this.BrowseDataOperationsFolderButton.TabIndex = 109;
            // 
            // DataOperationsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EditDataOperationsReferencesSet);
            this.Controls.Add(this.BrowseDataOperationsFolderButton);
            this.Controls.Add(this.DataOperationsFolderTextBox);
            this.Controls.Add(this.DataOperationsReferencesSetCombobox);
            this.Controls.Add(this.DataOperationsNamespaceTextBox);
            this.Controls.Add(this.DataOperationsFolderLabel);
            this.Controls.Add(this.DataOperationsReferencesSetLabel);
            this.Controls.Add(this.DataOperationsNamespaceLabel);
            this.Name = "DataOperationsEditor";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
