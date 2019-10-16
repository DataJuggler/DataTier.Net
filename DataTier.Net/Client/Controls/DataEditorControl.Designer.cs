

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class DataEditorControl
    /// <summary>
    /// This is the designer code for the DataEditorControl control.
    /// </summary>
    partial class DataEditorControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckedListBox TablesListBox;
        private SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.Label ExcludeTableLabel;
        private System.Windows.Forms.Label ExcludeFieldLabel;
        private System.Windows.Forms.CheckedListBox FieldsListBox;
        private System.Windows.Forms.Label TablesLabel;
        private System.Windows.Forms.Label FieldsLabel;
        private System.Windows.Forms.Label SelectedTableLabel;
        private System.Windows.Forms.TextBox SelectedTableTextBox;
        private System.Windows.Forms.Button RemoveTableButton;
        private System.Windows.Forms.Button CreateMethodButton;
        private System.Windows.Forms.Button ManageMethodButton;
        private System.Windows.Forms.Button ManageReadersButton;
        private System.Windows.Forms.Button ManageFieldSetsButton;
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
            this.TablesListBox = new System.Windows.Forms.CheckedListBox();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.ExcludeTableLabel = new System.Windows.Forms.Label();
            this.ExcludeFieldLabel = new System.Windows.Forms.Label();
            this.FieldsListBox = new System.Windows.Forms.CheckedListBox();
            this.TablesLabel = new System.Windows.Forms.Label();
            this.FieldsLabel = new System.Windows.Forms.Label();
            this.SelectedTableLabel = new System.Windows.Forms.Label();
            this.SelectedTableTextBox = new System.Windows.Forms.TextBox();
            this.RemoveTableButton = new System.Windows.Forms.Button();
            this.CreateMethodButton = new System.Windows.Forms.Button();
            this.ManageMethodButton = new System.Windows.Forms.Button();
            this.ManageReadersButton = new System.Windows.Forms.Button();
            this.ManageFieldSetsButton = new System.Windows.Forms.Button();
            this.BlazorFeaturesButton = new System.Windows.Forms.Button();
            this.CreateBindingCallbackControl = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.AllButton = new System.Windows.Forms.Label();
            this.NoneButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TablesListBox
            // 
            this.TablesListBox.FormattingEnabled = true;
            this.TablesListBox.Location = new System.Drawing.Point(24, 36);
            this.TablesListBox.Name = "TablesListBox";
            this.TablesListBox.Size = new System.Drawing.Size(320, 356);
            this.TablesListBox.TabIndex = 0;
            this.TablesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TablesListBox_ItemCheck);
            this.TablesListBox.SelectedIndexChanged += new System.EventHandler(this.TablesListBox_SelectedIndexChanged);
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 456);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(964, 40);
            this.SaveCancelControl.TabIndex = 1;
            // 
            // ExcludeTableLabel
            // 
            this.ExcludeTableLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcludeTableLabel.Location = new System.Drawing.Point(24, 394);
            this.ExcludeTableLabel.Name = "ExcludeTableLabel";
            this.ExcludeTableLabel.Size = new System.Drawing.Size(282, 29);
            this.ExcludeTableLabel.TabIndex = 2;
            this.ExcludeTableLabel.Text = "Uncheck to exclude a table.";
            // 
            // ExcludeFieldLabel
            // 
            this.ExcludeFieldLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcludeFieldLabel.Location = new System.Drawing.Point(608, 394);
            this.ExcludeFieldLabel.Name = "ExcludeFieldLabel";
            this.ExcludeFieldLabel.Size = new System.Drawing.Size(282, 29);
            this.ExcludeFieldLabel.TabIndex = 4;
            this.ExcludeFieldLabel.Text = "Uncheck to exclude a field.";
            // 
            // FieldsListBox
            // 
            this.FieldsListBox.CheckOnClick = true;
            this.FieldsListBox.FormattingEnabled = true;
            this.FieldsListBox.Location = new System.Drawing.Point(608, 36);
            this.FieldsListBox.Name = "FieldsListBox";
            this.FieldsListBox.Size = new System.Drawing.Size(320, 356);
            this.FieldsListBox.TabIndex = 3;
            this.FieldsListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FieldsListBox_ItemCheck);
            // 
            // TablesLabel
            // 
            this.TablesLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TablesLabel.Location = new System.Drawing.Point(24, 14);
            this.TablesLabel.Name = "TablesLabel";
            this.TablesLabel.Size = new System.Drawing.Size(94, 18);
            this.TablesLabel.TabIndex = 5;
            this.TablesLabel.Text = "Tables:";
            this.TablesLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FieldsLabel
            // 
            this.FieldsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldsLabel.Location = new System.Drawing.Point(608, 4);
            this.FieldsLabel.Name = "FieldsLabel";
            this.FieldsLabel.Size = new System.Drawing.Size(282, 29);
            this.FieldsLabel.TabIndex = 6;
            this.FieldsLabel.Text = "Fields:";
            this.FieldsLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // SelectedTableLabel
            // 
            this.SelectedTableLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableLabel.Location = new System.Drawing.Point(360, 4);
            this.SelectedTableLabel.Name = "SelectedTableLabel";
            this.SelectedTableLabel.Size = new System.Drawing.Size(147, 29);
            this.SelectedTableLabel.TabIndex = 7;
            this.SelectedTableLabel.Text = "Selected Table:";
            this.SelectedTableLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // SelectedTableTextBox
            // 
            this.SelectedTableTextBox.Location = new System.Drawing.Point(360, 36);
            this.SelectedTableTextBox.Name = "SelectedTableTextBox";
            this.SelectedTableTextBox.ReadOnly = true;
            this.SelectedTableTextBox.Size = new System.Drawing.Size(232, 27);
            this.SelectedTableTextBox.TabIndex = 8;
            // 
            // RemoveTableButton
            // 
            this.RemoveTableButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.RemoveTableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveTableButton.FlatAppearance.BorderSize = 0;
            this.RemoveTableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RemoveTableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RemoveTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveTableButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveTableButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.RemoveTableButton.Location = new System.Drawing.Point(360, 269);
            this.RemoveTableButton.Name = "RemoveTableButton";
            this.RemoveTableButton.Size = new System.Drawing.Size(232, 40);
            this.RemoveTableButton.TabIndex = 97;
            this.RemoveTableButton.Text = "Remove Table Code";
            this.RemoveTableButton.UseVisualStyleBackColor = true;
            this.RemoveTableButton.Visible = false;
            this.RemoveTableButton.Click += new System.EventHandler(this.RemoveTableButton_Click);
            this.RemoveTableButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.RemoveTableButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // CreateMethodButton
            // 
            this.CreateMethodButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.CreateMethodButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateMethodButton.FlatAppearance.BorderSize = 0;
            this.CreateMethodButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CreateMethodButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CreateMethodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateMethodButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateMethodButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CreateMethodButton.Location = new System.Drawing.Point(360, 77);
            this.CreateMethodButton.Name = "CreateMethodButton";
            this.CreateMethodButton.Size = new System.Drawing.Size(232, 40);
            this.CreateMethodButton.TabIndex = 100;
            this.CreateMethodButton.Text = "Create New Method";
            this.CreateMethodButton.UseVisualStyleBackColor = true;
            this.CreateMethodButton.Visible = false;
            this.CreateMethodButton.Click += new System.EventHandler(this.CreateMethodButton_Click);
            this.CreateMethodButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CreateMethodButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ManageMethodButton
            // 
            this.ManageMethodButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.ManageMethodButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ManageMethodButton.FlatAppearance.BorderSize = 0;
            this.ManageMethodButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ManageMethodButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ManageMethodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageMethodButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageMethodButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ManageMethodButton.Location = new System.Drawing.Point(360, 125);
            this.ManageMethodButton.Name = "ManageMethodButton";
            this.ManageMethodButton.Size = new System.Drawing.Size(232, 40);
            this.ManageMethodButton.TabIndex = 101;
            this.ManageMethodButton.Text = "Manage Methods";
            this.ManageMethodButton.UseVisualStyleBackColor = true;
            this.ManageMethodButton.Visible = false;
            this.ManageMethodButton.Click += new System.EventHandler(this.ManageMethodButton_Click);
            this.ManageMethodButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ManageMethodButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ManageReadersButton
            // 
            this.ManageReadersButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.ManageReadersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ManageReadersButton.FlatAppearance.BorderSize = 0;
            this.ManageReadersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ManageReadersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ManageReadersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageReadersButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageReadersButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ManageReadersButton.Location = new System.Drawing.Point(360, 221);
            this.ManageReadersButton.Name = "ManageReadersButton";
            this.ManageReadersButton.Size = new System.Drawing.Size(232, 40);
            this.ManageReadersButton.TabIndex = 102;
            this.ManageReadersButton.Text = "Manage Readers";
            this.ManageReadersButton.UseVisualStyleBackColor = true;
            this.ManageReadersButton.Visible = false;
            this.ManageReadersButton.Click += new System.EventHandler(this.ManageReadersButton_Click);
            this.ManageReadersButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ManageReadersButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ManageFieldSetsButton
            // 
            this.ManageFieldSetsButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.ManageFieldSetsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ManageFieldSetsButton.FlatAppearance.BorderSize = 0;
            this.ManageFieldSetsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ManageFieldSetsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ManageFieldSetsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageFieldSetsButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageFieldSetsButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ManageFieldSetsButton.Location = new System.Drawing.Point(360, 173);
            this.ManageFieldSetsButton.Name = "ManageFieldSetsButton";
            this.ManageFieldSetsButton.Size = new System.Drawing.Size(232, 40);
            this.ManageFieldSetsButton.TabIndex = 103;
            this.ManageFieldSetsButton.Text = "Manage Field Sets";
            this.ManageFieldSetsButton.UseVisualStyleBackColor = true;
            this.ManageFieldSetsButton.Visible = false;
            this.ManageFieldSetsButton.Click += new System.EventHandler(this.ManageFieldSetsButton_Click);
            this.ManageFieldSetsButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ManageFieldSetsButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // BlazorFeaturesButton
            // 
            this.BlazorFeaturesButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.BlazorFeaturesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BlazorFeaturesButton.FlatAppearance.BorderSize = 0;
            this.BlazorFeaturesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BlazorFeaturesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BlazorFeaturesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlazorFeaturesButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlazorFeaturesButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BlazorFeaturesButton.Location = new System.Drawing.Point(363, 315);
            this.BlazorFeaturesButton.Name = "BlazorFeaturesButton";
            this.BlazorFeaturesButton.Size = new System.Drawing.Size(232, 40);
            this.BlazorFeaturesButton.TabIndex = 104;
            this.BlazorFeaturesButton.Text = "Blazor Data Services";
            this.BlazorFeaturesButton.UseVisualStyleBackColor = true;
            this.BlazorFeaturesButton.Visible = false;
            this.BlazorFeaturesButton.Click += new System.EventHandler(this.BlazorFeaturesButton_Click);
            this.BlazorFeaturesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.BlazorFeaturesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // CreateBindingCallbackControl
            // 
            this.CreateBindingCallbackControl.BackColor = System.Drawing.Color.Transparent;
            this.CreateBindingCallbackControl.CheckBoxHorizontalOffSet = 0;
            this.CreateBindingCallbackControl.CheckBoxVerticalOffSet = 3;
            this.CreateBindingCallbackControl.CheckChangedListener = null;
            this.CreateBindingCallbackControl.Checked = false;
            this.CreateBindingCallbackControl.Editable = true;
            this.CreateBindingCallbackControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBindingCallbackControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.CreateBindingCallbackControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBindingCallbackControl.LabelText = "Create Callback:";
            this.CreateBindingCallbackControl.LabelWidth = 160;
            this.CreateBindingCallbackControl.Location = new System.Drawing.Point(383, 363);
            this.CreateBindingCallbackControl.Name = "CreateBindingCallbackControl";
            this.CreateBindingCallbackControl.Size = new System.Drawing.Size(176, 28);
            this.CreateBindingCallbackControl.TabIndex = 105;
            // 
            // AllButton
            // 
            this.AllButton.AutoSize = true;
            this.AllButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllButton.Location = new System.Drawing.Point(177, 14);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(28, 18);
            this.AllButton.TabIndex = 106;
            this.AllButton.Text = "All";
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            this.AllButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.AllButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // NoneButton
            // 
            this.NoneButton.AutoSize = true;
            this.NoneButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoneButton.Location = new System.Drawing.Point(232, 14);
            this.NoneButton.Name = "NoneButton";
            this.NoneButton.Size = new System.Drawing.Size(54, 18);
            this.NoneButton.TabIndex = 107;
            this.NoneButton.Text = "None";
            this.NoneButton.Click += new System.EventHandler(this.NoneButton_Click);
            this.NoneButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.NoneButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DataEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.NoneButton);
            this.Controls.Add(this.AllButton);
            this.Controls.Add(this.CreateBindingCallbackControl);
            this.Controls.Add(this.BlazorFeaturesButton);
            this.Controls.Add(this.ManageFieldSetsButton);
            this.Controls.Add(this.ManageReadersButton);
            this.Controls.Add(this.ManageMethodButton);
            this.Controls.Add(this.CreateMethodButton);
            this.Controls.Add(this.RemoveTableButton);
            this.Controls.Add(this.SelectedTableTextBox);
            this.Controls.Add(this.SelectedTableLabel);
            this.Controls.Add(this.FieldsLabel);
            this.Controls.Add(this.TablesLabel);
            this.Controls.Add(this.ExcludeFieldLabel);
            this.Controls.Add(this.FieldsListBox);
            this.Controls.Add(this.ExcludeTableLabel);
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.TablesListBox);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DataEditorControl";
            this.Size = new System.Drawing.Size(964, 496);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private System.Windows.Forms.Button BlazorFeaturesButton;
        private DataJuggler.Win.Controls.LabelCheckBoxControl CreateBindingCallbackControl;
        private System.Windows.Forms.Label AllButton;
        private System.Windows.Forms.Label NoneButton;
    }
    #endregion

}
