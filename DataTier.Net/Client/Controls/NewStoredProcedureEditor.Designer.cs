

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class NewStoredProcedureEditor
    /// <summary>
    /// This is the designer for the NewStoredProcedureEditor control
    /// </summary>
    partial class NewStoredProcedureEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button ProcedureButton;
        private System.Windows.Forms.RadioButton UpdateMyDatabaseRadioButton;
        private System.Windows.Forms.RadioButton ManualUpdateRadioButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl ProcedureNameControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl SelectedTableControl;
        private System.Windows.Forms.Panel SeperatorPanel;
        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.CustomWhereCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ProcedureButton = new System.Windows.Forms.Button();
            this.UpdateMyDatabaseRadioButton = new System.Windows.Forms.RadioButton();
            this.ManualUpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.ProcedureNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SelectedTableControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SeperatorPanel = new System.Windows.Forms.Panel();
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.WherePanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.WhereTextBox = new System.Windows.Forms.TextBox();
            this.WhereLabel = new System.Windows.Forms.Label();
            this.ProcedureTextBox = new System.Windows.Forms.TextBox();
            this.TopPanel.SuspendLayout();
            this.WherePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.CustomWhereCheckBox);
            this.TopPanel.Controls.Add(this.ProcedureButton);
            this.TopPanel.Controls.Add(this.UpdateMyDatabaseRadioButton);
            this.TopPanel.Controls.Add(this.ManualUpdateRadioButton);
            this.TopPanel.Controls.Add(this.ProcedureNameControl);
            this.TopPanel.Controls.Add(this.SelectedTableControl);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1080, 112);
            this.TopPanel.TabIndex = 101;
            // 
            // CustomWhereCheckBox
            // 
            this.CustomWhereCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CustomWhereCheckBox.CheckBoxHorizontalOffSet = 0;
            this.CustomWhereCheckBox.CheckBoxVerticalOffSet = 3;
            this.CustomWhereCheckBox.CheckChangedListener = null;
            this.CustomWhereCheckBox.Checked = false;
            this.CustomWhereCheckBox.Editable = true;
            this.CustomWhereCheckBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomWhereCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.CustomWhereCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomWhereCheckBox.LabelText = "Custom Where:";
            this.CustomWhereCheckBox.LabelWidth = 148;
            this.CustomWhereCheckBox.Location = new System.Drawing.Point(512, 69);
            this.CustomWhereCheckBox.Name = "CustomWhereCheckBox";
            this.CustomWhereCheckBox.Size = new System.Drawing.Size(169, 28);
            this.CustomWhereCheckBox.TabIndex = 104;
            // 
            // ProcedureButton
            // 
            this.ProcedureButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.ProcedureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProcedureButton.FlatAppearance.BorderSize = 0;
            this.ProcedureButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ProcedureButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProcedureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcedureButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcedureButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ProcedureButton.Location = new System.Drawing.Point(882, 33);
            this.ProcedureButton.Name = "ProcedureButton";
            this.ProcedureButton.Size = new System.Drawing.Size(180, 40);
            this.ProcedureButton.TabIndex = 103;
            this.ProcedureButton.Text = "Copy Procedure";
            this.ProcedureButton.UseVisualStyleBackColor = true;
            this.ProcedureButton.Click += new System.EventHandler(this.ProcedureButton_Click);
            this.ProcedureButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ProcedureButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // UpdateMyDatabaseRadioButton
            // 
            this.UpdateMyDatabaseRadioButton.AutoSize = true;
            this.UpdateMyDatabaseRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateMyDatabaseRadioButton.Location = new System.Drawing.Point(518, 43);
            this.UpdateMyDatabaseRadioButton.Name = "UpdateMyDatabaseRadioButton";
            this.UpdateMyDatabaseRadioButton.Size = new System.Drawing.Size(354, 22);
            this.UpdateMyDatabaseRadioButton.TabIndex = 102;
            this.UpdateMyDatabaseRadioButton.TabStop = true;
            this.UpdateMyDatabaseRadioButton.Text = "Insert Stored Procedure In Database";
            this.UpdateMyDatabaseRadioButton.UseVisualStyleBackColor = true;
            this.UpdateMyDatabaseRadioButton.CheckedChanged += new System.EventHandler(this.UpdateMyDatabaseRadioButton_CheckedChanged);
            // 
            // ManualUpdateRadioButton
            // 
            this.ManualUpdateRadioButton.AutoSize = true;
            this.ManualUpdateRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualUpdateRadioButton.Location = new System.Drawing.Point(518, 15);
            this.ManualUpdateRadioButton.Name = "ManualUpdateRadioButton";
            this.ManualUpdateRadioButton.Size = new System.Drawing.Size(335, 22);
            this.ManualUpdateRadioButton.TabIndex = 101;
            this.ManualUpdateRadioButton.TabStop = true;
            this.ManualUpdateRadioButton.Text = "I will update my database manually";
            this.ManualUpdateRadioButton.UseVisualStyleBackColor = true;
            this.ManualUpdateRadioButton.CheckedChanged += new System.EventHandler(this.ManualUpdateRadioButton_CheckedChanged);
            // 
            // ProcedureNameControl
            // 
            this.ProcedureNameControl.BackColor = System.Drawing.Color.Transparent;
            this.ProcedureNameControl.BottomMargin = 0;
            this.ProcedureNameControl.Editable = false;
            this.ProcedureNameControl.Encrypted = false;
            this.ProcedureNameControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcedureNameControl.LabelBottomMargin = 0;
            this.ProcedureNameControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ProcedureNameControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcedureNameControl.LabelText = "Procedure Name:";
            this.ProcedureNameControl.LabelTopMargin = 2;
            this.ProcedureNameControl.LabelWidth = 172;
            this.ProcedureNameControl.Location = new System.Drawing.Point(16, 64);
            this.ProcedureNameControl.MultiLine = false;
            this.ProcedureNameControl.Name = "ProcedureNameControl";
            this.ProcedureNameControl.OnTextChangedListener = null;
            this.ProcedureNameControl.PasswordMode = false;
            this.ProcedureNameControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ProcedureNameControl.Size = new System.Drawing.Size(492, 28);
            this.ProcedureNameControl.TabIndex = 100;
            this.ProcedureNameControl.TextBoxBottomMargin = 0;
            this.ProcedureNameControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ProcedureNameControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ProcedureNameControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcedureNameControl.TextBoxTopMargin = 0;
            // 
            // SelectedTableControl
            // 
            this.SelectedTableControl.BackColor = System.Drawing.Color.Transparent;
            this.SelectedTableControl.BottomMargin = 0;
            this.SelectedTableControl.Editable = false;
            this.SelectedTableControl.Encrypted = false;
            this.SelectedTableControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableControl.LabelBottomMargin = 0;
            this.SelectedTableControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.SelectedTableControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableControl.LabelText = "Selected Table:";
            this.SelectedTableControl.LabelTopMargin = 4;
            this.SelectedTableControl.LabelWidth = 172;
            this.SelectedTableControl.Location = new System.Drawing.Point(16, 24);
            this.SelectedTableControl.MultiLine = false;
            this.SelectedTableControl.Name = "SelectedTableControl";
            this.SelectedTableControl.OnTextChangedListener = null;
            this.SelectedTableControl.PasswordMode = false;
            this.SelectedTableControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectedTableControl.Size = new System.Drawing.Size(492, 28);
            this.SelectedTableControl.TabIndex = 99;
            this.SelectedTableControl.TextBoxBottomMargin = 0;
            this.SelectedTableControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.SelectedTableControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.SelectedTableControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F);
            this.SelectedTableControl.TextBoxTopMargin = 0;
            // 
            // SeperatorPanel
            // 
            this.SeperatorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SeperatorPanel.Location = new System.Drawing.Point(0, 540);
            this.SeperatorPanel.Name = "SeperatorPanel";
            this.SeperatorPanel.Size = new System.Drawing.Size(1080, 20);
            this.SeperatorPanel.TabIndex = 103;
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 112);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(20, 428);
            this.LeftMarginPanel.TabIndex = 105;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(1060, 112);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(20, 428);
            this.RightMarginPanel.TabIndex = 106;
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 560);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(1080, 40);
            this.SaveCancelControl.TabIndex = 99;
            // 
            // WherePanel
            // 
            this.WherePanel.Controls.Add(this.WhereTextBox);
            this.WherePanel.Controls.Add(this.WhereLabel);
            this.WherePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WherePanel.Location = new System.Drawing.Point(20, 440);
            this.WherePanel.Name = "WherePanel";
            this.WherePanel.Size = new System.Drawing.Size(1040, 100);
            this.WherePanel.TabIndex = 108;
            // 
            // WhereTextBox
            // 
            this.WhereTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WhereTextBox.Location = new System.Drawing.Point(0, 22);
            this.WhereTextBox.Multiline = true;
            this.WhereTextBox.Name = "WhereTextBox";
            this.WhereTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WhereTextBox.Size = new System.Drawing.Size(1040, 78);
            this.WhereTextBox.TabIndex = 111;
            this.WhereTextBox.TextChanged += new System.EventHandler(this.WhereTextBox_TextChanged);
            // 
            // WhereLabel
            // 
            this.WhereLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WhereLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhereLabel.Location = new System.Drawing.Point(0, 0);
            this.WhereLabel.Name = "WhereLabel";
            this.WhereLabel.Size = new System.Drawing.Size(1040, 22);
            this.WhereLabel.TabIndex = 0;
            this.WhereLabel.Text = "Custom Where Clause";
            this.WhereLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ProcedureTextBox
            // 
            this.ProcedureTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcedureTextBox.Location = new System.Drawing.Point(20, 112);
            this.ProcedureTextBox.Multiline = true;
            this.ProcedureTextBox.Name = "ProcedureTextBox";
            this.ProcedureTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcedureTextBox.Size = new System.Drawing.Size(1040, 328);
            this.ProcedureTextBox.TabIndex = 109;
            this.ProcedureTextBox.TextChanged += new System.EventHandler(this.ProcedureTextBox_TextChanged);
            // 
            // NewStoredProcedureEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.ProcedureTextBox);
            this.Controls.Add(this.WherePanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Controls.Add(this.SeperatorPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SaveCancelControl);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewStoredProcedureEditor";
            this.Size = new System.Drawing.Size(1080, 600);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.WherePanel.ResumeLayout(false);
            this.WherePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private DataJuggler.Win.Controls.LabelCheckBoxControl CustomWhereCheckBox;
        private DataJuggler.Win.Controls.Objects.PanelExtender WherePanel;
        private System.Windows.Forms.Label WhereLabel;
        private System.Windows.Forms.TextBox ProcedureTextBox;
        private System.Windows.Forms.TextBox WhereTextBox;
    }
    #endregion

}
