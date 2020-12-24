
#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class StoredProcedureEditor
    /// <summary>
    /// This is the designer code for the control.
    /// </summary>
    partial class StoredProcedureEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox StoredProcedureSQLFolderTextBox;
        private System.Windows.Forms.Label StoredProcedureSQLFolderLabel;
        private System.Windows.Forms.TextBox StoredProcedureFolderTextBox;
        private System.Windows.Forms.TextBox StoredProcedureNamespaceTextBox;
        private System.Windows.Forms.Label StoredProcedureFolderLabel;
        private System.Windows.Forms.Label StoredProcedureNamespaceLabel;
        private TabButton BrowseStoredProcedureSQLFolderButton;
        private TabButton BrowseStoredProcedureFolderButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoredProcedureEditor));
            this.StoredProcedureSQLFolderTextBox = new System.Windows.Forms.TextBox();
            this.StoredProcedureSQLFolderLabel = new System.Windows.Forms.Label();
            this.StoredProcedureFolderTextBox = new System.Windows.Forms.TextBox();
            this.StoredProcedureNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.StoredProcedureFolderLabel = new System.Windows.Forms.Label();
            this.StoredProcedureNamespaceLabel = new System.Windows.Forms.Label();
            this.BrowseStoredProcedureSQLFolderButton = new DataTierClient.Controls.TabButton();
            this.BrowseStoredProcedureFolderButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // StoredProcedureSQLFolderTextBox
            // 
            this.StoredProcedureSQLFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredProcedureSQLFolderTextBox.Location = new System.Drawing.Point(218, 104);
            this.StoredProcedureSQLFolderTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StoredProcedureSQLFolderTextBox.Name = "StoredProcedureSQLFolderTextBox";
            this.StoredProcedureSQLFolderTextBox.Size = new System.Drawing.Size(404, 27);
            this.StoredProcedureSQLFolderTextBox.TabIndex = 122;
            this.StoredProcedureSQLFolderTextBox.TextChanged += new System.EventHandler(this.StoredProcedureSQLFolderTextBox_TextChanged);
            // 
            // StoredProcedureSQLFolderLabel
            // 
            this.StoredProcedureSQLFolderLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredProcedureSQLFolderLabel.Location = new System.Drawing.Point(20, 107);
            this.StoredProcedureSQLFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StoredProcedureSQLFolderLabel.Name = "StoredProcedureSQLFolderLabel";
            this.StoredProcedureSQLFolderLabel.Size = new System.Drawing.Size(200, 20);
            this.StoredProcedureSQLFolderLabel.TabIndex = 121;
            this.StoredProcedureSQLFolderLabel.Text = "SQL Output Folder:";
            this.StoredProcedureSQLFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StoredProcedureFolderTextBox
            // 
            this.StoredProcedureFolderTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredProcedureFolderTextBox.Location = new System.Drawing.Point(218, 20);
            this.StoredProcedureFolderTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StoredProcedureFolderTextBox.Name = "StoredProcedureFolderTextBox";
            this.StoredProcedureFolderTextBox.Size = new System.Drawing.Size(404, 27);
            this.StoredProcedureFolderTextBox.TabIndex = 116;
            this.StoredProcedureFolderTextBox.TextChanged += new System.EventHandler(this.StoredProcedureFolderTextBox_TextChanged);
            // 
            // StoredProcedureNamespaceTextBox
            // 
            this.StoredProcedureNamespaceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredProcedureNamespaceTextBox.Location = new System.Drawing.Point(218, 62);
            this.StoredProcedureNamespaceTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StoredProcedureNamespaceTextBox.Name = "StoredProcedureNamespaceTextBox";
            this.StoredProcedureNamespaceTextBox.Size = new System.Drawing.Size(437, 27);
            this.StoredProcedureNamespaceTextBox.TabIndex = 115;
            this.StoredProcedureNamespaceTextBox.TextChanged += new System.EventHandler(this.StoredProcedureNamespaceTextBox_TextChanged);
            // 
            // StoredProcedureFolderLabel
            // 
            this.StoredProcedureFolderLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredProcedureFolderLabel.Location = new System.Drawing.Point(20, 23);
            this.StoredProcedureFolderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StoredProcedureFolderLabel.Name = "StoredProcedureFolderLabel";
            this.StoredProcedureFolderLabel.Size = new System.Drawing.Size(200, 20);
            this.StoredProcedureFolderLabel.TabIndex = 114;
            this.StoredProcedureFolderLabel.Text = "Stored Proc Folder:";
            this.StoredProcedureFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StoredProcedureNamespaceLabel
            // 
            this.StoredProcedureNamespaceLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredProcedureNamespaceLabel.Location = new System.Drawing.Point(20, 65);
            this.StoredProcedureNamespaceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StoredProcedureNamespaceLabel.Name = "StoredProcedureNamespaceLabel";
            this.StoredProcedureNamespaceLabel.Size = new System.Drawing.Size(200, 20);
            this.StoredProcedureNamespaceLabel.TabIndex = 112;
            this.StoredProcedureNamespaceLabel.Text = "Proc Namespace:";
            this.StoredProcedureNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrowseStoredProcedureSQLFolderButton
            // 
            this.BrowseStoredProcedureSQLFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseStoredProcedureSQLFolderButton.BackgroundImage")));
            this.BrowseStoredProcedureSQLFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseStoredProcedureSQLFolderButton.ButtonNumber = 2;
            this.BrowseStoredProcedureSQLFolderButton.ButtonText = "...";
            this.BrowseStoredProcedureSQLFolderButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseStoredProcedureSQLFolderButton.Location = new System.Drawing.Point(615, 103);
            this.BrowseStoredProcedureSQLFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseStoredProcedureSQLFolderButton.Name = "BrowseStoredProcedureSQLFolderButton";
            this.BrowseStoredProcedureSQLFolderButton.NotSelectedImage = null;
            this.BrowseStoredProcedureSQLFolderButton.Selected = false;
            this.BrowseStoredProcedureSQLFolderButton.SelectedImage = null;
            this.BrowseStoredProcedureSQLFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseStoredProcedureSQLFolderButton.Size = new System.Drawing.Size(40, 28);
            this.BrowseStoredProcedureSQLFolderButton.TabIndex = 139;
            // 
            // BrowseStoredProcedureFolderButton
            // 
            this.BrowseStoredProcedureFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseStoredProcedureFolderButton.BackgroundImage")));
            this.BrowseStoredProcedureFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseStoredProcedureFolderButton.ButtonNumber = 1;
            this.BrowseStoredProcedureFolderButton.ButtonText = "...";
            this.BrowseStoredProcedureFolderButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseStoredProcedureFolderButton.Location = new System.Drawing.Point(615, 19);
            this.BrowseStoredProcedureFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseStoredProcedureFolderButton.Name = "BrowseStoredProcedureFolderButton";
            this.BrowseStoredProcedureFolderButton.NotSelectedImage = null;
            this.BrowseStoredProcedureFolderButton.Selected = false;
            this.BrowseStoredProcedureFolderButton.SelectedImage = null;
            this.BrowseStoredProcedureFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseStoredProcedureFolderButton.Size = new System.Drawing.Size(40, 28);
            this.BrowseStoredProcedureFolderButton.TabIndex = 142;
            // 
            // StoredProcedureEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BrowseStoredProcedureFolderButton);
            this.Controls.Add(this.BrowseStoredProcedureSQLFolderButton);
            this.Controls.Add(this.StoredProcedureSQLFolderTextBox);
            this.Controls.Add(this.StoredProcedureFolderTextBox);
            this.Controls.Add(this.StoredProcedureSQLFolderLabel);
            this.Controls.Add(this.StoredProcedureNamespaceTextBox);
            this.Controls.Add(this.StoredProcedureFolderLabel);
            this.Controls.Add(this.StoredProcedureNamespaceLabel);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StoredProcedureEditor";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
