
#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Controls
{

    #region class ReferencesSetEditor
    /// <summary>
    /// This is the designer code for theReferencesSetEditor control.
    /// </summary>
    partial class ReferencesSetEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox ReferencesSetNameTextBox;
        private System.Windows.Forms.Label ReferencesSetNameLabel;
        private SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.ListBox ReferencesListBox;
        private TabButton EditButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferencesSetEditor));
            this.ReferencesSetNameTextBox = new System.Windows.Forms.TextBox();
            this.ReferencesSetNameLabel = new System.Windows.Forms.Label();
            this.ReferencesListBox = new System.Windows.Forms.ListBox();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.EditButton = new DataTierClient.Controls.TabButton();
            this.DeleteButton = new DataTierClient.Controls.TabButton();
            this.AddButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // ReferencesSetNameTextBox
            // 
            this.ReferencesSetNameTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferencesSetNameTextBox.Location = new System.Drawing.Point(222, 13);
            this.ReferencesSetNameTextBox.Name = "ReferencesSetNameTextBox";
            this.ReferencesSetNameTextBox.ReadOnly = true;
            this.ReferencesSetNameTextBox.Size = new System.Drawing.Size(370, 34);
            this.ReferencesSetNameTextBox.TabIndex = 75;
            this.ReferencesSetNameTextBox.TextChanged += new System.EventHandler(this.ReferencesSetNameTextBox_TextChanged);
            // 
            // ReferencesSetNameLabel
            // 
            this.ReferencesSetNameLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferencesSetNameLabel.Location = new System.Drawing.Point(13, 21);
            this.ReferencesSetNameLabel.Name = "ReferencesSetNameLabel";
            this.ReferencesSetNameLabel.Size = new System.Drawing.Size(212, 24);
            this.ReferencesSetNameLabel.TabIndex = 74;
            this.ReferencesSetNameLabel.Text = "References Set Name:";
            this.ReferencesSetNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReferencesListBox
            // 
            this.ReferencesListBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferencesListBox.FormattingEnabled = true;
            this.ReferencesListBox.ItemHeight = 26;
            this.ReferencesListBox.Location = new System.Drawing.Point(37, 62);
            this.ReferencesListBox.Name = "ReferencesListBox";
            this.ReferencesListBox.Size = new System.Drawing.Size(555, 160);
            this.ReferencesListBox.TabIndex = 92;
            this.ReferencesListBox.SelectedIndexChanged += new System.EventHandler(this.ReferencesListBox_SelectedIndexChanged);
            this.ReferencesListBox.DoubleClick += new System.EventHandler(this.ReferencesListBox_DoubleClick);
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 300);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(632, 48);
            this.SaveCancelControl.TabIndex = 76;
            // 
            // EditButton
            // 
            this.EditButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditButton.ButtonNumber = 0;
            this.EditButton.ButtonText = "Edit";
            this.EditButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(274, 240);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.Selected = false;
            this.EditButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditButton.Size = new System.Drawing.Size(80, 32);
            this.EditButton.TabIndex = 97;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.ButtonNumber = 0;
            this.DeleteButton.ButtonText = "Delete";
            this.DeleteButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(362, 240);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.Selected = false;
            this.DeleteButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.DeleteButton.ShowNotSelectedImageWhenDisabled = true;
            this.DeleteButton.Size = new System.Drawing.Size(80, 32);
            this.DeleteButton.TabIndex = 98;
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.ButtonNumber = 0;
            this.AddButton.ButtonText = "Add";
            this.AddButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(186, 240);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.NotSelectedImage = null;
            this.AddButton.Selected = false;
            this.AddButton.SelectedImage = null;
            this.AddButton.ShowNotSelectedImageWhenDisabled = true;
            this.AddButton.Size = new System.Drawing.Size(80, 32);
            this.AddButton.TabIndex = 96;
            // 
            // ReferencesSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ReferencesListBox);
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.ReferencesSetNameTextBox);
            this.Controls.Add(this.ReferencesSetNameLabel);
            this.Name = "ReferencesSetEditor";
            this.Size = new System.Drawing.Size(632, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private TabButton DeleteButton;
        private TabButton AddButton;
    }
    #endregion

}




