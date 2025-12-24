

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class SQLDatabaseEditor
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class SQLDatabaseEditor
    {
        
        #region Private Variables
        private System.Windows.Forms.CheckBox SerializableCheckBox;
        private System.Windows.Forms.Label SerializableLabel;
        private System.Windows.Forms.TextBox ConnectionStringTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox SQLUserNameTextBox;
        private System.Windows.Forms.TextBox ServerTextBox;
        private System.Windows.Forms.Label ConnectionStringLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.ComboBox DatabasesComboBox;
        private System.Windows.Forms.RadioButton WindowsRadioButton;
        private System.Windows.Forms.RadioButton SQLServerRadioButton;
        private TabButton BrowseDatabaseButton;
        private TabButton BrowseServerButton;
        private System.ComponentModel.IContainer components = null;
        private DataJuggler.Win.Controls.LabelComboBoxControl EncryptValueComboBox;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IncludeEncryptCheckBox;
        private System.Windows.Forms.Label InfoLabel;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLDatabaseEditor));
            this.SerializableCheckBox = new System.Windows.Forms.CheckBox();
            this.SerializableLabel = new System.Windows.Forms.Label();
            this.ConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.SQLUserNameTextBox = new System.Windows.Forms.TextBox();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionStringLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.DatabasesComboBox = new System.Windows.Forms.ComboBox();
            this.WindowsRadioButton = new System.Windows.Forms.RadioButton();
            this.SQLServerRadioButton = new System.Windows.Forms.RadioButton();
            this.EncryptValueComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.IncludeEncryptCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.BrowseDatabaseButton = new DataTierClient.Controls.TabButton();
            this.BrowseServerButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // SerializableCheckBox
            // 
            this.SerializableCheckBox.AutoSize = true;
            this.SerializableCheckBox.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerializableCheckBox.Location = new System.Drawing.Point(157, 438);
            this.SerializableCheckBox.Name = "SerializableCheckBox";
            this.SerializableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.SerializableCheckBox.TabIndex = 7;
            this.SerializableCheckBox.UseVisualStyleBackColor = true;
            // 
            // SerializableLabel
            // 
            this.SerializableLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerializableLabel.Location = new System.Drawing.Point(28, 430);
            this.SerializableLabel.Name = "SerializableLabel";
            this.SerializableLabel.Size = new System.Drawing.Size(124, 20);
            this.SerializableLabel.TabIndex = 92;
            this.SerializableLabel.Text = "Serializable:";
            this.SerializableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConnectionStringTextBox
            // 
            this.ConnectionStringTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStringTextBox.Location = new System.Drawing.Point(153, 310);
            this.ConnectionStringTextBox.Multiline = true;
            this.ConnectionStringTextBox.Name = "ConnectionStringTextBox";
            this.ConnectionStringTextBox.Size = new System.Drawing.Size(388, 116);
            this.ConnectionStringTextBox.TabIndex = 6;
            this.ConnectionStringTextBox.TextChanged += new System.EventHandler(this.ConnectionStringTextBox_TextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(140, 128);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(401, 34);
            this.PasswordTextBox.TabIndex = 4;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // SQLUserNameTextBox
            // 
            this.SQLUserNameTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLUserNameTextBox.Location = new System.Drawing.Point(140, 90);
            this.SQLUserNameTextBox.Name = "SQLUserNameTextBox";
            this.SQLUserNameTextBox.Size = new System.Drawing.Size(401, 34);
            this.SQLUserNameTextBox.TabIndex = 3;
            this.SQLUserNameTextBox.TextChanged += new System.EventHandler(this.SQLUserNameTextBox_TextChanged);
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerTextBox.Location = new System.Drawing.Point(140, 20);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(360, 34);
            this.ServerTextBox.TabIndex = 0;
            this.ServerTextBox.TextChanged += new System.EventHandler(this.ServerTextBox_TextChanged);
            // 
            // ConnectionStringLabel
            // 
            this.ConnectionStringLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStringLabel.Location = new System.Drawing.Point(20, 306);
            this.ConnectionStringLabel.Name = "ConnectionStringLabel";
            this.ConnectionStringLabel.Size = new System.Drawing.Size(132, 24);
            this.ConnectionStringLabel.TabIndex = 86;
            this.ConnectionStringLabel.Text = "Conn. String:";
            this.ConnectionStringLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(20, 132);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(116, 20);
            this.PasswordLabel.TabIndex = 85;
            this.PasswordLabel.Text = "Password:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDLabel.Location = new System.Drawing.Point(20, 94);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(116, 20);
            this.UserIDLabel.TabIndex = 84;
            this.UserIDLabel.Text = "User ID:";
            this.UserIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServerLabel
            // 
            this.ServerLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerLabel.Location = new System.Drawing.Point(20, 24);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(116, 24);
            this.ServerLabel.TabIndex = 83;
            this.ServerLabel.Text = "Server:";
            this.ServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseLabel.Location = new System.Drawing.Point(20, 170);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(116, 20);
            this.DatabaseLabel.TabIndex = 94;
            this.DatabaseLabel.Text = "Database:";
            this.DatabaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DatabasesComboBox
            // 
            this.DatabasesComboBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabasesComboBox.FormattingEnabled = true;
            this.DatabasesComboBox.Location = new System.Drawing.Point(140, 166);
            this.DatabasesComboBox.Name = "DatabasesComboBox";
            this.DatabasesComboBox.Size = new System.Drawing.Size(360, 34);
            this.DatabasesComboBox.TabIndex = 5;
            this.DatabasesComboBox.SelectedIndexChanged += new System.EventHandler(this.DatabasesComboBox_SelectedIndexChanged);
            // 
            // WindowsRadioButton
            // 
            this.WindowsRadioButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowsRadioButton.Location = new System.Drawing.Point(88, 56);
            this.WindowsRadioButton.Name = "WindowsRadioButton";
            this.WindowsRadioButton.Size = new System.Drawing.Size(206, 32);
            this.WindowsRadioButton.TabIndex = 1;
            this.WindowsRadioButton.TabStop = true;
            this.WindowsRadioButton.Text = "Windows Authentication";
            this.WindowsRadioButton.UseVisualStyleBackColor = true;
            this.WindowsRadioButton.CheckedChanged += new System.EventHandler(this.WindowsRadioButton_CheckedChanged);
            // 
            // SQLServerRadioButton
            // 
            this.SQLServerRadioButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLServerRadioButton.Location = new System.Drawing.Point(318, 56);
            this.SQLServerRadioButton.Name = "SQLServerRadioButton";
            this.SQLServerRadioButton.Size = new System.Drawing.Size(206, 32);
            this.SQLServerRadioButton.TabIndex = 2;
            this.SQLServerRadioButton.TabStop = true;
            this.SQLServerRadioButton.Text = "SQL Authentication";
            this.SQLServerRadioButton.UseVisualStyleBackColor = true;
            this.SQLServerRadioButton.CheckedChanged += new System.EventHandler(this.SQLRadioButton_CheckedChanged);
            // 
            // EncryptValueComboBox
            // 
            this.EncryptValueComboBox.BackColor = System.Drawing.Color.Transparent;
            this.EncryptValueComboBox.ComboBoxLeftMargin = 1;
            this.EncryptValueComboBox.ComboBoxText = "";
            this.EncryptValueComboBox.ComoboBoxFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptValueComboBox.Editable = true;
            this.EncryptValueComboBox.Enabled = false;
            this.EncryptValueComboBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptValueComboBox.HideLabel = false;
            this.EncryptValueComboBox.LabelBottomMargin = 0;
            this.EncryptValueComboBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.EncryptValueComboBox.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptValueComboBox.LabelText = "Encrypt Value:";
            this.EncryptValueComboBox.LabelTopMargin = 0;
            this.EncryptValueComboBox.LabelWidth = 120;
            this.EncryptValueComboBox.List = null;
            this.EncryptValueComboBox.Location = new System.Drawing.Point(257, 268);
            this.EncryptValueComboBox.Name = "EncryptValueComboBox";
            this.EncryptValueComboBox.SelectedIndex = -1;
            this.EncryptValueComboBox.SelectedIndexListener = null;
            this.EncryptValueComboBox.Size = new System.Drawing.Size(284, 32);
            this.EncryptValueComboBox.Sorted = false;
            this.EncryptValueComboBox.Source = null;
            this.EncryptValueComboBox.TabIndex = 105;
            // 
            // IncludeEncryptCheckBox
            // 
            this.IncludeEncryptCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.IncludeEncryptCheckBox.CheckBoxHorizontalOffSet = 0;
            this.IncludeEncryptCheckBox.CheckBoxVerticalOffSet = 4;
            this.IncludeEncryptCheckBox.CheckChangedListener = null;
            this.IncludeEncryptCheckBox.Checked = true;
            this.IncludeEncryptCheckBox.Editable = true;
            this.IncludeEncryptCheckBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncludeEncryptCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.IncludeEncryptCheckBox.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncludeEncryptCheckBox.LabelText = "Include Encrypt:";
            this.IncludeEncryptCheckBox.LabelWidth = 160;
            this.IncludeEncryptCheckBox.Location = new System.Drawing.Point(20, 271);
            this.IncludeEncryptCheckBox.Name = "IncludeEncryptCheckBox";
            this.IncludeEncryptCheckBox.Size = new System.Drawing.Size(185, 28);
            this.IncludeEncryptCheckBox.TabIndex = 104;
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoLabel.Location = new System.Drawing.Point(20, 205);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(521, 54);
            this.InfoLabel.TabIndex = 103;
            this.InfoLabel.Text = "Microsoft.Data.SqlClient requires Encrypt=False if your database is not encrypted" +
    ". Leave this checked if you are targeting .NET Core.\r\n\r\n";
            // 
            // BrowseDatabaseButton
            // 
            this.BrowseDatabaseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseDatabaseButton.BackgroundImage")));
            this.BrowseDatabaseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseDatabaseButton.ButtonNumber = 2;
            this.BrowseDatabaseButton.ButtonText = "...";
            this.BrowseDatabaseButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseDatabaseButton.Location = new System.Drawing.Point(501, 167);
            this.BrowseDatabaseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseDatabaseButton.Name = "BrowseDatabaseButton";
            this.BrowseDatabaseButton.NotSelectedImage = null;
            this.BrowseDatabaseButton.Selected = false;
            this.BrowseDatabaseButton.SelectedImage = null;
            this.BrowseDatabaseButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseDatabaseButton.Size = new System.Drawing.Size(40, 32);
            this.BrowseDatabaseButton.TabIndex = 102;
            this.BrowseDatabaseButton.TabStop = false;
            // 
            // BrowseServerButton
            // 
            this.BrowseServerButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BrowseServerButton.BackgroundImage")));
            this.BrowseServerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseServerButton.ButtonNumber = 1;
            this.BrowseServerButton.ButtonText = "...";
            this.BrowseServerButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseServerButton.Location = new System.Drawing.Point(501, 21);
            this.BrowseServerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseServerButton.Name = "BrowseServerButton";
            this.BrowseServerButton.NotSelectedImage = null;
            this.BrowseServerButton.Selected = false;
            this.BrowseServerButton.SelectedImage = null;
            this.BrowseServerButton.ShowNotSelectedImageWhenDisabled = true;
            this.BrowseServerButton.Size = new System.Drawing.Size(40, 32);
            this.BrowseServerButton.TabIndex = 1;
            this.BrowseServerButton.TabStop = false;
            // 
            // SQLDatabaseEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.EncryptValueComboBox);
            this.Controls.Add(this.IncludeEncryptCheckBox);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.BrowseDatabaseButton);
            this.Controls.Add(this.BrowseServerButton);
            this.Controls.Add(this.SQLServerRadioButton);
            this.Controls.Add(this.WindowsRadioButton);
            this.Controls.Add(this.DatabasesComboBox);
            this.Controls.Add(this.DatabaseLabel);
            this.Controls.Add(this.SerializableCheckBox);
            this.Controls.Add(this.SerializableLabel);
            this.Controls.Add(this.ConnectionStringTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.SQLUserNameTextBox);
            this.Controls.Add(this.ServerTextBox);
            this.Controls.Add(this.ConnectionStringLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.ServerLabel);
            this.Name = "SQLDatabaseEditor";
            this.Size = new System.Drawing.Size(560, 471);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}




