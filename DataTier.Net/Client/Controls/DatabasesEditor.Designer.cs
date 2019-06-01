

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class DatabasesEditor
    /// <summary>
    /// This is the designer code for the DatabasesEditor control
    /// </summary>
    partial class DatabasesEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox DatabasesListBox;
        private System.Windows.Forms.Label DatabasesLabel;
        private TabButton AddButton;
        private TabButton EditButton;
        private TabButton DeleteButton;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabasesEditor));
                this.DatabasesListBox = new System.Windows.Forms.ListBox();
                this.DatabasesLabel = new System.Windows.Forms.Label();
                this.AddButton = new TabButton();
                this.EditButton = new TabButton();
                this.DeleteButton = new TabButton();
                this.SuspendLayout();
                // 
                // DatabasesListBox
                // 
                this.DatabasesListBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DatabasesListBox.FormattingEnabled = true;
                this.DatabasesListBox.ItemHeight = 18;
                this.DatabasesListBox.Location = new System.Drawing.Point(43, 45);
                this.DatabasesListBox.Name = "DatabasesListBox";
                this.DatabasesListBox.Size = new System.Drawing.Size(254, 130);
                this.DatabasesListBox.TabIndex = 88;
                this.DatabasesListBox.SelectedIndexChanged += new System.EventHandler(this.DatabasesListBox_SelectedIndexChanged);
                // 
                // DatabasesLabel
                // 
                this.DatabasesLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DatabasesLabel.Location = new System.Drawing.Point(40, 20);
                this.DatabasesLabel.Name = "DatabasesLabel";
                this.DatabasesLabel.Size = new System.Drawing.Size(120, 20);
                this.DatabasesLabel.TabIndex = 87;
                this.DatabasesLabel.Text = "Databases:";
                this.DatabasesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // AddButton
                // 
                this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
                this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.AddButton.ButtonNumber = 0;
                this.AddButton.ButtonText = "Add";
                this.AddButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.AddButton.Location = new System.Drawing.Point(43, 181);
                this.AddButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.AddButton.Name = "AddButton";
                this.AddButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
                this.AddButton.Selected = false;
                this.AddButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
                this.AddButton.ShowNotSelectedImageWhenDisabled = true;
                this.AddButton.Size = new System.Drawing.Size(80, 28);
                this.AddButton.TabIndex = 92;
                // 
                // EditButton
                // 
                this.EditButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditButton.BackgroundImage")));
                this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.EditButton.ButtonNumber = 0;
                this.EditButton.ButtonText = "Edit";
                this.EditButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.EditButton.Location = new System.Drawing.Point(130, 181);
                this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.EditButton.Name = "EditButton";
                this.EditButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
                this.EditButton.Selected = false;
                this.EditButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
                this.EditButton.ShowNotSelectedImageWhenDisabled = true;
                this.EditButton.Size = new System.Drawing.Size(80, 28);
                this.EditButton.TabIndex = 93;
                // 
                // DeleteButton
                // 
                this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
                this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.DeleteButton.ButtonNumber = 0;
                this.DeleteButton.ButtonText = "Delete";
                this.DeleteButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DeleteButton.Location = new System.Drawing.Point(217, 181);
                this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.DeleteButton.Name = "DeleteButton";
                this.DeleteButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
                this.DeleteButton.Selected = false;
                this.DeleteButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
                this.DeleteButton.ShowNotSelectedImageWhenDisabled = true;
                this.DeleteButton.Size = new System.Drawing.Size(80, 28);
                this.DeleteButton.TabIndex = 94;
                // 
                // DatabasesEditor
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.Transparent;
                this.Controls.Add(this.DeleteButton);
                this.Controls.Add(this.EditButton);
                this.Controls.Add(this.AddButton);
                this.Controls.Add(this.DatabasesListBox);
                this.Controls.Add(this.DatabasesLabel);
                this.Name = "DatabasesEditor";
                this.Size = new System.Drawing.Size(680, 320);
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
