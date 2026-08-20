
#region using statements

#endregion

namespace DataTierClient.Controls
{

    #region class GatewayEditor
    /// <summary>
    /// This is the designer generated code fro the DataObjectsEditor
    /// </summary>
    partial class GatewayEditor
    {

        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox GatewayNamespaceTextBox;
        private System.Windows.Forms.TextBox GatewayFolderTextBox;
        private System.Windows.Forms.Label GatewayNamespaceLabel;
        private System.Windows.Forms.Label GatewayFolderLabel;
        private TabButton BrowseGatewayFolderButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GatewayEditor));
            this.GatewayNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.GatewayFolderTextBox = new System.Windows.Forms.TextBox();
            this.GatewayNamespaceLabel = new System.Windows.Forms.Label();
            this.GatewayFolderLabel = new System.Windows.Forms.Label();
            this.BrowseGatewayFolderButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // GatewayNamespaceTextBox
            // 
            this.GatewayNamespaceTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GatewayNamespaceTextBox.Location = new System.Drawing.Point(222, 64);
            this.GatewayNamespaceTextBox.Name = "GatewayNamespaceTextBox";
            this.GatewayNamespaceTextBox.Size = new System.Drawing.Size(437, 34);
            this.GatewayNamespaceTextBox.TabIndex = 87;
            this.GatewayNamespaceTextBox.TextChanged += new System.EventHandler(this.GatewayNamespaceTextBox_TextChanged);
            // 
            // GatewayFolderTextBox
            // 
            this.GatewayFolderTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GatewayFolderTextBox.Location = new System.Drawing.Point(222, 20);
            this.GatewayFolderTextBox.Name = "GatewayFolderTextBox";
            this.GatewayFolderTextBox.Size = new System.Drawing.Size(404, 34);
            this.GatewayFolderTextBox.TabIndex = 85;
            this.GatewayFolderTextBox.TextChanged += new System.EventHandler(this.GatewayFolderTextBox_TextChanged);
            // 
            // GatewayNamespaceLabel
            // 
            this.GatewayNamespaceLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GatewayNamespaceLabel.Location = new System.Drawing.Point(2, 68);
            this.GatewayNamespaceLabel.Name = "GatewayNamespaceLabel";
            this.GatewayNamespaceLabel.Size = new System.Drawing.Size(224, 24);
            this.GatewayNamespaceLabel.TabIndex = 84;
            this.GatewayNamespaceLabel.Text = "Gateway Namespace:";
            this.GatewayNamespaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GatewayFolderLabel
            // 
            this.GatewayFolderLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GatewayFolderLabel.Location = new System.Drawing.Point(2, 24);
            this.GatewayFolderLabel.Name = "GatewayFolderLabel";
            this.GatewayFolderLabel.Size = new System.Drawing.Size(224, 24);
            this.GatewayFolderLabel.TabIndex = 82;
            this.GatewayFolderLabel.Text = "Gateway Folder:";
            this.GatewayFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrowseGatewayFolderButton
            // 
            this.BrowseGatewayFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseGatewayFolderButton.BackgroundImage")));
            this.BrowseGatewayFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseGatewayFolderButton.ButtonNumber = 0;
            this.BrowseGatewayFolderButton.ButtonText = "...";
            this.BrowseGatewayFolderButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseGatewayFolderButton.Location = new System.Drawing.Point(619, 21);
            this.BrowseGatewayFolderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseGatewayFolderButton.Name = "BrowseGatewayFolderButton";
            this.BrowseGatewayFolderButton.NotSelectedImage = null;
            this.BrowseGatewayFolderButton.Selected = false;
            this.BrowseGatewayFolderButton.SelectedImage = null;
            this.BrowseGatewayFolderButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseGatewayFolderButton.Size = new System.Drawing.Size(40, 32);
            this.BrowseGatewayFolderButton.TabIndex = 91;
            // 
            // GatewayEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BrowseGatewayFolderButton);
            this.Controls.Add(this.GatewayFolderTextBox);
            this.Controls.Add(this.GatewayNamespaceTextBox);
            this.Controls.Add(this.GatewayNamespaceLabel);
            this.Controls.Add(this.GatewayFolderLabel);
            this.Name = "GatewayEditor";
            this.Size = new System.Drawing.Size(680, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #endregion

    }
    #endregion

}