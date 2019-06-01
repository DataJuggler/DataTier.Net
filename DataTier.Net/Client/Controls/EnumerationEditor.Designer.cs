

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class EnumerationEditor
    /// <summary>
    /// This is the designer code for the EnumerationEditor control.
    /// </summary>
    partial class EnumerationEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox EnumerationsListBox;
        private System.Windows.Forms.Label FieldNameLabel;
        private System.Windows.Forms.Label DataTypeEditLabel;
        private System.Windows.Forms.TextBox DataTypeTextBox;
        private System.Windows.Forms.TextBox FieldNameTextBox;
        private System.Windows.Forms.Label FieldNameEditLabel;
        private System.Windows.Forms.Label ExampleLabel;
        private System.Windows.Forms.Label ExampleTItleLabel;
        private System.Windows.Forms.Label DataTypeLabel;
        private System.Windows.Forms.Label FieldNameExampleLabel;
        private System.Windows.Forms.Label DataTypeExampleLabel;
        private TabButton AddButton;
        private TabButton EditButton;
        private TabButton DeleteButton;
        private TabButton SaveButton;
        private TabButton CancelButton;
        private TabButton DoneButton;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnumerationEditor));
                this.EnumerationsListBox = new System.Windows.Forms.ListBox();
                this.FieldNameLabel = new System.Windows.Forms.Label();
                this.DataTypeEditLabel = new System.Windows.Forms.Label();
                this.DataTypeTextBox = new System.Windows.Forms.TextBox();
                this.FieldNameTextBox = new System.Windows.Forms.TextBox();
                this.FieldNameEditLabel = new System.Windows.Forms.Label();
                this.ExampleLabel = new System.Windows.Forms.Label();
                this.ExampleTItleLabel = new System.Windows.Forms.Label();
                this.DataTypeLabel = new System.Windows.Forms.Label();
                this.FieldNameExampleLabel = new System.Windows.Forms.Label();
                this.DataTypeExampleLabel = new System.Windows.Forms.Label();
                this.AddButton = new TabButton();
                this.EditButton = new TabButton();
                this.DeleteButton = new TabButton();
                this.SaveButton = new TabButton();
                this.CancelButton = new TabButton();
                this.DoneButton = new TabButton();
                this.SuspendLayout();
                // 
                // EnumerationsListBox
                // 
                this.EnumerationsListBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.EnumerationsListBox.FormattingEnabled = true;
                this.EnumerationsListBox.ItemHeight = 18;
                this.EnumerationsListBox.Location = new System.Drawing.Point(29, 26);
                this.EnumerationsListBox.Name = "EnumerationsListBox";
                this.EnumerationsListBox.Size = new System.Drawing.Size(275, 238);
                this.EnumerationsListBox.TabIndex = 0;
                this.EnumerationsListBox.SelectedIndexChanged += new System.EventHandler(this.EnumerationsListBox_SelectedIndexChanged);
                // 
                // FieldNameLabel
                // 
                this.FieldNameLabel.BackColor = System.Drawing.Color.Transparent;
                this.FieldNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FieldNameLabel.Location = new System.Drawing.Point(27, 4);
                this.FieldNameLabel.Name = "FieldNameLabel";
                this.FieldNameLabel.Size = new System.Drawing.Size(140, 18);
                this.FieldNameLabel.TabIndex = 99;
                this.FieldNameLabel.Text = "Field Name:";
                this.FieldNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // DataTypeEditLabel
                // 
                this.DataTypeEditLabel.BackColor = System.Drawing.Color.Transparent;
                this.DataTypeEditLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DataTypeEditLabel.Location = new System.Drawing.Point(316, 83);
                this.DataTypeEditLabel.Name = "DataTypeEditLabel";
                this.DataTypeEditLabel.Size = new System.Drawing.Size(271, 18);
                this.DataTypeEditLabel.TabIndex = 97;
                this.DataTypeEditLabel.Text = "Data Type (Enumeration Name):";
                this.DataTypeEditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // DataTypeTextBox
                // 
                this.DataTypeTextBox.Enabled = false;
                this.DataTypeTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DataTypeTextBox.Location = new System.Drawing.Point(316, 105);
                this.DataTypeTextBox.Name = "DataTypeTextBox";
                this.DataTypeTextBox.Size = new System.Drawing.Size(271, 27);
                this.DataTypeTextBox.TabIndex = 5;
                // 
                // FieldNameTextBox
                // 
                this.FieldNameTextBox.Enabled = false;
                this.FieldNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FieldNameTextBox.Location = new System.Drawing.Point(316, 49);
                this.FieldNameTextBox.Name = "FieldNameTextBox";
                this.FieldNameTextBox.Size = new System.Drawing.Size(271, 27);
                this.FieldNameTextBox.TabIndex = 4;
                // 
                // FieldNameEditLabel
                // 
                this.FieldNameEditLabel.BackColor = System.Drawing.Color.Transparent;
                this.FieldNameEditLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FieldNameEditLabel.Location = new System.Drawing.Point(316, 27);
                this.FieldNameEditLabel.Name = "FieldNameEditLabel";
                this.FieldNameEditLabel.Size = new System.Drawing.Size(205, 18);
                this.FieldNameEditLabel.TabIndex = 102;
                this.FieldNameEditLabel.Text = "Field Name:";
                this.FieldNameEditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // ExampleLabel
                // 
                this.ExampleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ExampleLabel.Location = new System.Drawing.Point(320, 201);
                this.ExampleLabel.Name = "ExampleLabel";
                this.ExampleLabel.Size = new System.Drawing.Size(108, 18);
                this.ExampleLabel.TabIndex = 104;
                this.ExampleLabel.Text = "Field Name:";
                this.ExampleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // ExampleTItleLabel
                // 
                this.ExampleTItleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ExampleTItleLabel.Location = new System.Drawing.Point(320, 179);
                this.ExampleTItleLabel.Name = "ExampleTItleLabel";
                this.ExampleTItleLabel.Size = new System.Drawing.Size(80, 18);
                this.ExampleTItleLabel.TabIndex = 105;
                this.ExampleTItleLabel.Text = "Example:";
                // 
                // DataTypeLabel
                // 
                this.DataTypeLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DataTypeLabel.Location = new System.Drawing.Point(320, 226);
                this.DataTypeLabel.Name = "DataTypeLabel";
                this.DataTypeLabel.Size = new System.Drawing.Size(108, 18);
                this.DataTypeLabel.TabIndex = 106;
                this.DataTypeLabel.Text = "Data Type:";
                this.DataTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // FieldNameExampleLabel
                // 
                this.FieldNameExampleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FieldNameExampleLabel.ForeColor = System.Drawing.Color.Black;
                this.FieldNameExampleLabel.Location = new System.Drawing.Point(427, 201);
                this.FieldNameExampleLabel.Name = "FieldNameExampleLabel";
                this.FieldNameExampleLabel.Size = new System.Drawing.Size(160, 18);
                this.FieldNameExampleLabel.TabIndex = 107;
                this.FieldNameExampleLabel.Text = "CostType";
                this.FieldNameExampleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // DataTypeExampleLabel
                // 
                this.DataTypeExampleLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DataTypeExampleLabel.ForeColor = System.Drawing.Color.Black;
                this.DataTypeExampleLabel.Location = new System.Drawing.Point(427, 226);
                this.DataTypeExampleLabel.Name = "DataTypeExampleLabel";
                this.DataTypeExampleLabel.Size = new System.Drawing.Size(160, 18);
                this.DataTypeExampleLabel.TabIndex = 108;
                this.DataTypeExampleLabel.Text = "CostTypeEnum";
                this.DataTypeExampleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // AddButton
                // 
                this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
                this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.AddButton.ButtonNumber = 0;
                this.AddButton.ButtonText = "Add";
                this.AddButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.AddButton.Location = new System.Drawing.Point(30, 277);
                this.AddButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.AddButton.Name = "AddButton";
                this.AddButton.NotSelectedImage = null;
                this.AddButton.Selected = false;
                this.AddButton.SelectedImage = null;
                this.AddButton.ShowNotSelectedImageWhenDisabled = true;
                this.AddButton.Size = new System.Drawing.Size(80, 28);
                this.AddButton.TabIndex = 1;
                // 
                // EditButton
                // 
                this.EditButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditButton.BackgroundImage")));
                this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.EditButton.ButtonNumber = 0;
                this.EditButton.ButtonText = "Edit";
                this.EditButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.EditButton.Location = new System.Drawing.Point(126, 277);
                this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.EditButton.Name = "EditButton";
                this.EditButton.NotSelectedImage = null;
                this.EditButton.Selected = false;
                this.EditButton.SelectedImage = null;
                this.EditButton.ShowNotSelectedImageWhenDisabled = true;
                this.EditButton.Size = new System.Drawing.Size(80, 28);
                this.EditButton.TabIndex = 2;
                // 
                // DeleteButton
                // 
                this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
                this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.DeleteButton.ButtonNumber = 0;
                this.DeleteButton.ButtonText = "Delete";
                this.DeleteButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DeleteButton.Location = new System.Drawing.Point(222, 277);
                this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.DeleteButton.Name = "DeleteButton";
                this.DeleteButton.NotSelectedImage = null;
                this.DeleteButton.Selected = false;
                this.DeleteButton.SelectedImage = null;
                this.DeleteButton.ShowNotSelectedImageWhenDisabled = true;
                this.DeleteButton.Size = new System.Drawing.Size(80, 28);
                this.DeleteButton.TabIndex = 3;
                // 
                // SaveButton
                // 
                this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
                this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.SaveButton.ButtonNumber = 0;
                this.SaveButton.ButtonText = "Save";
                this.SaveButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.SaveButton.Location = new System.Drawing.Point(419, 140);
                this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.SaveButton.Name = "SaveButton";
                this.SaveButton.NotSelectedImage = null;
                this.SaveButton.Selected = false;
                this.SaveButton.SelectedImage = null;
                this.SaveButton.ShowNotSelectedImageWhenDisabled = true;
                this.SaveButton.Size = new System.Drawing.Size(80, 28);
                this.SaveButton.TabIndex = 6;
                // 
                // CancelButton
                // 
                this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.CancelButton.ButtonNumber = 0;
                this.CancelButton.ButtonText = "Cancel";
                this.CancelButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.CancelButton.Location = new System.Drawing.Point(507, 140);
                this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.CancelButton.Name = "CancelButton";
                this.CancelButton.NotSelectedImage = null;
                this.CancelButton.Selected = false;
                this.CancelButton.SelectedImage = null;
                this.CancelButton.ShowNotSelectedImageWhenDisabled = true;
                this.CancelButton.Size = new System.Drawing.Size(80, 28);
                this.CancelButton.TabIndex = 7;
                // 
                // DoneButton
                // 
                this.DoneButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DoneButton.BackgroundImage")));
                this.DoneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.DoneButton.ButtonNumber = 0;
                this.DoneButton.ButtonText = "Done";
                this.DoneButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DoneButton.Location = new System.Drawing.Point(507, 277);
                this.DoneButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.DoneButton.Name = "DoneButton";
                this.DoneButton.NotSelectedImage = null;
                this.DoneButton.Selected = false;
                this.DoneButton.SelectedImage = null;
                this.DoneButton.ShowNotSelectedImageWhenDisabled = true;
                this.DoneButton.Size = new System.Drawing.Size(80, 28);
                this.DoneButton.TabIndex = 8;
                // 
                // EnumerationEditor
                // 
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackColor = System.Drawing.Color.Linen;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.Controls.Add(this.DoneButton);
                this.Controls.Add(this.CancelButton);
                this.Controls.Add(this.SaveButton);
                this.Controls.Add(this.DeleteButton);
                this.Controls.Add(this.EditButton);
                this.Controls.Add(this.AddButton);
                this.Controls.Add(this.DataTypeExampleLabel);
                this.Controls.Add(this.FieldNameExampleLabel);
                this.Controls.Add(this.DataTypeLabel);
                this.Controls.Add(this.ExampleTItleLabel);
                this.Controls.Add(this.ExampleLabel);
                this.Controls.Add(this.FieldNameTextBox);
                this.Controls.Add(this.FieldNameEditLabel);
                this.Controls.Add(this.DataTypeTextBox);
                this.Controls.Add(this.DataTypeEditLabel);
                this.Controls.Add(this.EnumerationsListBox);
                this.Controls.Add(this.FieldNameLabel);
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Name = "EnumerationEditor";
                this.Size = new System.Drawing.Size(612, 320);
                this.ResumeLayout(false);
                this.PerformLayout();
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
