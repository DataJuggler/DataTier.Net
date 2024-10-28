
#region using statements

#endregion

namespace DataTierClient.Controls
{

    #region class WriterEditor
    /// <summary>
    /// This is the designer code for the WriterEditor control.
    /// </summary>
    partial class WriterEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox WriterReferencesSetComboBox;
        private System.Windows.Forms.TextBox WriterFolderTextBox;
        private System.Windows.Forms.TextBox WriterNamespaceTextBox;
        private System.Windows.Forms.Label WriterFolderLabel;
        private System.Windows.Forms.Label WriterReferencesSetLabel;
        private System.Windows.Forms.Label WriterNamespaceLabel;
        private TabButton EditWriterReferencesSetButton;
        private TabButton BrowseWriterManagerFolderButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriterEditor));
            this.WriterReferencesSetComboBox = new System.Windows.Forms.ComboBox();
            this.WriterFolderTextBox = new System.Windows.Forms.TextBox();
            this.WriterNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.WriterFolderLabel = new System.Windows.Forms.Label();
            this.WriterReferencesSetLabel = new System.Windows.Forms.Label();
            this.WriterNamespaceLabel = new System.Windows.Forms.Label();
            this.EditWriterReferencesSetButton = new DataTierClient.Controls.TabButton();
            this.BrowseWriterManagerFolderButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // WriterReferencesSetComboBox
            // 
            this.WriterReferencesSetComboBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WriterReferencesSetComboBox.FormattingEnabled = true;
            this.WriterReferencesSetComboBox.Location = new System.Drawing.Point(218, 100);
            this.WriterReferencesSetComboBox.Name = "WriterReferencesSetComboBox";
            this.WriterReferencesSetComboBox.Size = new System.Drawing.Size(271, 26);
            this.WriterReferencesSetComboBox.TabIndex = 133;
            this.WriterReferencesSetComboBox.SelectedIndexChanged += new System.EventHandler(this.WriterReferencesSetComboBox_SelectedIndexChanged);
            // 
            // WriterFolderTextBox
            // 
            this.WriterFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WriterFolderTextBox.Location = new System.Drawing.Point(218, 20);
            this.WriterFolderTextBox.Name = "WriterFolderTextBox";
            this.WriterFolderTextBox.Size = new System.Drawing.Size(404, 27);
            this.WriterFolderTextBox.TabIndex = 131;
            this.WriterFolderTextBox.TextChanged += new System.EventHandler(this.WriterFolderTextBox_TextChanged);
            // 
            // WriterNamespaceTextBox
            // 
            this.WriterNamespaceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WriterNamespaceTextBox.Location = new System.Drawing.Point(218, 60);
            this.WriterNamespaceTextBox.Name = "WriterNamespaceTextBox";
            this.WriterNamespaceTextBox.Size = new System.Drawing.Size(437, 27);
            this.WriterNamespaceTextBox.TabIndex = 130;
            this.WriterNamespaceTextBox.TextChanged += new System.EventHandler(this.WriterNamespaceTextBox_TextChanged);
            // 
            // WriterFolderLabel
            // 
            this.WriterFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WriterFolderLabel.Location = new System.Drawing.Point(20, 24);
            this.WriterFolderLabel.Name = "WriterFolderLabel";
            this.WriterFolderLabel.Size = new System.Drawing.Size(200, 20);
            this.WriterFolderLabel.TabIndex = 129;
            this.WriterFolderLabel.Text = "Writer Folder:";
            this.WriterFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WriterReferencesSetLabel
            // 
            this.WriterReferencesSetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WriterReferencesSetLabel.Location = new System.Drawing.Point(20, 104);
            this.WriterReferencesSetLabel.Name = "WriterReferencesSetLabel";
            this.WriterReferencesSetLabel.Size = new System.Drawing.Size(200, 20);
            this.WriterReferencesSetLabel.TabIndex = 128;
            this.WriterReferencesSetLabel.Text = "Writer Reference Set:";
            this.WriterReferencesSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WriterNamespaceLabel
            // 
            this.WriterNamespaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WriterNamespaceLabel.Location = new System.Drawing.Point(20, 64);
            this.WriterNamespaceLabel.Name = "WriterNamespaceLabel";
            this.WriterNamespaceLabel.Size = new System.Drawing.Size(200, 20);
            this.WriterNamespaceLabel.TabIndex = 127;
            this.WriterNamespaceLabel.Text = "Writer Namespace:";
            this.WriterNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditWriterReferencesSetButton
            // 
            this.EditWriterReferencesSetButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditWriterReferencesSetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditWriterReferencesSetButton.ButtonNumber = 0;
            this.EditWriterReferencesSetButton.ButtonText = "Edit";
            this.EditWriterReferencesSetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditWriterReferencesSetButton.Location = new System.Drawing.Point(583, 99);
            this.EditWriterReferencesSetButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditWriterReferencesSetButton.Name = "EditWriterReferencesSetButton";
            this.EditWriterReferencesSetButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditWriterReferencesSetButton.Selected = false;
            this.EditWriterReferencesSetButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditWriterReferencesSetButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditWriterReferencesSetButton.Size = new System.Drawing.Size(72, 28);
            this.EditWriterReferencesSetButton.TabIndex = 138;
            // 
            // BrowseWriterManagerFolderButton
            // 
            this.BrowseWriterManagerFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseWriterManagerFolderButton.BackgroundImage")));
            this.BrowseWriterManagerFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseWriterManagerFolderButton.ButtonNumber = 0;
            this.BrowseWriterManagerFolderButton.ButtonText = "...";
            this.BrowseWriterManagerFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseWriterManagerFolderButton.Location = new System.Drawing.Point(615, 19);
            this.BrowseWriterManagerFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseWriterManagerFolderButton.Name = "BrowseWriterManagerFolderButton";
            this.BrowseWriterManagerFolderButton.NotSelectedImage = null;
            this.BrowseWriterManagerFolderButton.Selected = false;
            this.BrowseWriterManagerFolderButton.SelectedImage = null;
            this.BrowseWriterManagerFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseWriterManagerFolderButton.Size = new System.Drawing.Size(40, 28);
            this.BrowseWriterManagerFolderButton.TabIndex = 136;
            // 
            // WriterEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.EditWriterReferencesSetButton);
            this.Controls.Add(this.BrowseWriterManagerFolderButton);
            this.Controls.Add(this.WriterFolderTextBox);
            this.Controls.Add(this.WriterReferencesSetComboBox);
            this.Controls.Add(this.WriterNamespaceTextBox);
            this.Controls.Add(this.WriterFolderLabel);
            this.Controls.Add(this.WriterReferencesSetLabel);
            this.Controls.Add(this.WriterNamespaceLabel);
            this.Name = "WriterEditor";
            this.Size = new System.Drawing.Size(680, 220);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
