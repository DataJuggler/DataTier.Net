

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class CustomMethodsEditor
    /// <summary>
    /// This is the designer code for the CustomMethodsEditor control. 
    /// </summary>
    partial class CustomMethodsEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private TabButton DeleteButton;
        private TabButton EditButton;
        private TabButton AddButton;
        private System.Windows.Forms.ListBox MethodsListBox;
        private System.Windows.Forms.Label MethodsLabel;
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
            this.MethodsListBox = new System.Windows.Forms.ListBox();
            this.MethodsLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new DataTierClient.Controls.TabButton();
            this.AddButton = new DataTierClient.Controls.TabButton();
            this.EditButton = new DataTierClient.Controls.TabButton();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MethodsListBox
            // 
            this.MethodsListBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodsListBox.FormattingEnabled = true;
            this.MethodsListBox.ItemHeight = 18;
            this.MethodsListBox.Location = new System.Drawing.Point(20, 28);
            this.MethodsListBox.Name = "MethodsListBox";
            this.MethodsListBox.Size = new System.Drawing.Size(380, 130);
            this.MethodsListBox.Sorted = true;
            this.MethodsListBox.TabIndex = 96;
            this.MethodsListBox.SelectedIndexChanged += new System.EventHandler(this.MethodsListBox_SelectedIndexChanged);
            this.MethodsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MethodsListBox_MouseDoubleClick);
            // 
            // MethodsLabel
            // 
            this.MethodsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodsLabel.Location = new System.Drawing.Point(20, 8);
            this.MethodsLabel.Name = "MethodsLabel";
            this.MethodsLabel.Size = new System.Drawing.Size(178, 20);
            this.MethodsLabel.TabIndex = 95;
            this.MethodsLabel.Text = "Custom Methods:";
            this.MethodsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.ButtonNumber = 0;
            this.DeleteButton.ButtonText = "Delete";
            this.DeleteButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(256, 200);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.Selected = false;
            this.DeleteButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.DeleteButton.ShowNotSelectedImageWhenDisabled = true;
            this.DeleteButton.Size = new System.Drawing.Size(76, 26);
            this.DeleteButton.TabIndex = 99;
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.ButtonNumber = 0;
            this.AddButton.ButtonText = "Add";
            this.AddButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(102, 200);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.AddButton.Selected = true;
            this.AddButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.AddButton.ShowNotSelectedImageWhenDisabled = true;
            this.AddButton.Size = new System.Drawing.Size(64, 26);
            this.AddButton.TabIndex = 97;
            // 
            // EditButton
            // 
            this.EditButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditButton.ButtonNumber = 0;
            this.EditButton.ButtonText = "Edit";
            this.EditButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(178, 200);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.Selected = false;
            this.EditButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditButton.Size = new System.Drawing.Size(64, 26);
            this.EditButton.TabIndex = 98;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(20, 160);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(380, 24);
            this.InfoLabel.TabIndex = 100;
            this.InfoLabel.Text = "Double click to edit a method.";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CustomMethodsEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MethodsListBox);
            this.Controls.Add(this.MethodsLabel);
            this.Controls.Add(this.EditButton);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomMethodsEditor";
            this.Size = new System.Drawing.Size(420, 240);
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private System.Windows.Forms.Label InfoLabel;
    }
    #endregion

}
