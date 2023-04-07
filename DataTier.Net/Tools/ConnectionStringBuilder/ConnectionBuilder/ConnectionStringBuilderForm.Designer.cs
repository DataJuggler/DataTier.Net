

#region using statements

#endregion

namespace ConnectionBuilder
{

    #region class ConnectionStringBuilderForm
    /// <summary>
    /// This is the MainForm for this application
    /// </summary>
    partial class ConnectionStringBuilderForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton SQLServerAuthenticationRadioButton;
        private System.Windows.Forms.RadioButton WindowsAuthenticationRadioButton;
        private System.Windows.Forms.Button BuildConnectionStringButton;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button TestDatabaseConnectionButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabaseNameControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabaseServerControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabaseUserControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabasePasswordControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl ConnectionstringControl;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStringBuilderForm));
            this.SQLServerAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.WindowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.BuildConnectionStringButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.TestDatabaseConnectionButton = new System.Windows.Forms.Button();
            this.DatabaseNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.DatabaseServerControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.DatabaseUserControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.DatabasePasswordControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.ConnectionstringControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusImage = new System.Windows.Forms.PictureBox();
            this.CopiedImage = new System.Windows.Forms.PictureBox();
            this.CopiedTimer = new System.Windows.Forms.Timer(this.components);
            this.IncludeEncryptCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.EncryptValueComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.StatusImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SQLServerAuthenticationRadioButton
            // 
            this.SQLServerAuthenticationRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SQLServerAuthenticationRadioButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.SQLServerAuthenticationRadioButton.Location = new System.Drawing.Point(212, 108);
            this.SQLServerAuthenticationRadioButton.Name = "SQLServerAuthenticationRadioButton";
            this.SQLServerAuthenticationRadioButton.Size = new System.Drawing.Size(239, 27);
            this.SQLServerAuthenticationRadioButton.TabIndex = 2;
            this.SQLServerAuthenticationRadioButton.Text = "SQL Authentication";
            this.SQLServerAuthenticationRadioButton.UseVisualStyleBackColor = false;
            this.SQLServerAuthenticationRadioButton.CheckedChanged += new System.EventHandler(this.SQLServerAuthenticationRadioButton_CheckedChanged);
            // 
            // WindowsAuthenticationRadioButton
            // 
            this.WindowsAuthenticationRadioButton.AutoSize = true;
            this.WindowsAuthenticationRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.WindowsAuthenticationRadioButton.Checked = true;
            this.WindowsAuthenticationRadioButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.WindowsAuthenticationRadioButton.Location = new System.Drawing.Point(457, 108);
            this.WindowsAuthenticationRadioButton.Name = "WindowsAuthenticationRadioButton";
            this.WindowsAuthenticationRadioButton.Size = new System.Drawing.Size(295, 27);
            this.WindowsAuthenticationRadioButton.TabIndex = 3;
            this.WindowsAuthenticationRadioButton.TabStop = true;
            this.WindowsAuthenticationRadioButton.Text = "Windows Authentication";
            this.WindowsAuthenticationRadioButton.UseVisualStyleBackColor = false;
            this.WindowsAuthenticationRadioButton.CheckedChanged += new System.EventHandler(this.SQLServerAuthenticationRadioButton_CheckedChanged);
            // 
            // BuildConnectionStringButton
            // 
            this.BuildConnectionStringButton.BackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuildConnectionStringButton.BackgroundImage")));
            this.BuildConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BuildConnectionStringButton.Enabled = false;
            this.BuildConnectionStringButton.FlatAppearance.BorderSize = 0;
            this.BuildConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuildConnectionStringButton.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildConnectionStringButton.ForeColor = System.Drawing.Color.DarkGray;
            this.BuildConnectionStringButton.Location = new System.Drawing.Point(539, 524);
            this.BuildConnectionStringButton.Name = "BuildConnectionStringButton";
            this.BuildConnectionStringButton.Size = new System.Drawing.Size(214, 36);
            this.BuildConnectionStringButton.TabIndex = 8;
            this.BuildConnectionStringButton.Text = "Build Conn String";
            this.BuildConnectionStringButton.UseVisualStyleBackColor = false;
            this.BuildConnectionStringButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.BuildConnectionStringButton.Click += new System.EventHandler(this.BuildConnectionStringButton_Click);
            this.BuildConnectionStringButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BuildConnectionStringButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.Transparent;
            this.DoneButton.BackgroundImage = global::ConnectionBuilder.Properties.Resources.WoodButtonWidth640;
            this.DoneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoneButton.FlatAppearance.BorderSize = 0;
            this.DoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneButton.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.ForeColor = System.Drawing.Color.Black;
            this.DoneButton.Location = new System.Drawing.Point(649, 570);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(104, 36);
            this.DoneButton.TabIndex = 10;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            this.DoneButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.DoneButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // CopyButton
            // 
            this.CopyButton.BackColor = System.Drawing.Color.Transparent;
            this.CopyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CopyButton.BackgroundImage")));
            this.CopyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyButton.Enabled = false;
            this.CopyButton.FlatAppearance.BorderSize = 0;
            this.CopyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CopyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyButton.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyButton.ForeColor = System.Drawing.Color.DarkGray;
            this.CopyButton.Location = new System.Drawing.Point(539, 570);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(104, 36);
            this.CopyButton.TabIndex = 9;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = false;
            this.CopyButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            this.CopyButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CopyButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // TestDatabaseConnectionButton
            // 
            this.TestDatabaseConnectionButton.BackColor = System.Drawing.Color.Transparent;
            this.TestDatabaseConnectionButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TestDatabaseConnectionButton.BackgroundImage")));
            this.TestDatabaseConnectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TestDatabaseConnectionButton.Enabled = false;
            this.TestDatabaseConnectionButton.FlatAppearance.BorderSize = 0;
            this.TestDatabaseConnectionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TestDatabaseConnectionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TestDatabaseConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestDatabaseConnectionButton.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestDatabaseConnectionButton.ForeColor = System.Drawing.Color.DarkGray;
            this.TestDatabaseConnectionButton.Location = new System.Drawing.Point(333, 524);
            this.TestDatabaseConnectionButton.Name = "TestDatabaseConnectionButton";
            this.TestDatabaseConnectionButton.Size = new System.Drawing.Size(200, 36);
            this.TestDatabaseConnectionButton.TabIndex = 7;
            this.TestDatabaseConnectionButton.Text = "Test and Copy";
            this.TestDatabaseConnectionButton.UseVisualStyleBackColor = false;
            this.TestDatabaseConnectionButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.TestDatabaseConnectionButton.Click += new System.EventHandler(this.TestDatabaseConnectionButton_Click);
            this.TestDatabaseConnectionButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.TestDatabaseConnectionButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // DatabaseNameControl
            // 
            this.DatabaseNameControl.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseNameControl.BottomMargin = 0;
            this.DatabaseNameControl.Editable = true;
            this.DatabaseNameControl.Encrypted = false;
            this.DatabaseNameControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseNameControl.LabelBottomMargin = 0;
            this.DatabaseNameControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.DatabaseNameControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseNameControl.LabelText = "Database Name:";
            this.DatabaseNameControl.LabelTopMargin = 0;
            this.DatabaseNameControl.LabelWidth = 240;
            this.DatabaseNameControl.Location = new System.Drawing.Point(32, 64);
            this.DatabaseNameControl.MultiLine = false;
            this.DatabaseNameControl.Name = "DatabaseNameControl";
            this.DatabaseNameControl.OnTextChangedListener = null;
            this.DatabaseNameControl.PasswordMode = false;
            this.DatabaseNameControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DatabaseNameControl.Size = new System.Drawing.Size(720, 30);
            this.DatabaseNameControl.TabIndex = 1;
            this.DatabaseNameControl.TextBoxBottomMargin = 0;
            this.DatabaseNameControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.DatabaseNameControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.DatabaseNameControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseNameControl.TextBoxTopMargin = 0;
            // 
            // DatabaseServerControl
            // 
            this.DatabaseServerControl.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseServerControl.BottomMargin = 0;
            this.DatabaseServerControl.Editable = true;
            this.DatabaseServerControl.Encrypted = false;
            this.DatabaseServerControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseServerControl.LabelBottomMargin = 0;
            this.DatabaseServerControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.DatabaseServerControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseServerControl.LabelText = "Database Server:";
            this.DatabaseServerControl.LabelTopMargin = 0;
            this.DatabaseServerControl.LabelWidth = 240;
            this.DatabaseServerControl.Location = new System.Drawing.Point(32, 20);
            this.DatabaseServerControl.MultiLine = false;
            this.DatabaseServerControl.Name = "DatabaseServerControl";
            this.DatabaseServerControl.OnTextChangedListener = null;
            this.DatabaseServerControl.PasswordMode = false;
            this.DatabaseServerControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DatabaseServerControl.Size = new System.Drawing.Size(720, 30);
            this.DatabaseServerControl.TabIndex = 0;
            this.DatabaseServerControl.TextBoxBottomMargin = 0;
            this.DatabaseServerControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.DatabaseServerControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.DatabaseServerControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseServerControl.TextBoxTopMargin = 0;
            // 
            // DatabaseUserControl
            // 
            this.DatabaseUserControl.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseUserControl.BottomMargin = 0;
            this.DatabaseUserControl.Editable = true;
            this.DatabaseUserControl.Encrypted = false;
            this.DatabaseUserControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseUserControl.LabelBottomMargin = 0;
            this.DatabaseUserControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.DatabaseUserControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseUserControl.LabelText = "Database User Name:";
            this.DatabaseUserControl.LabelTopMargin = 0;
            this.DatabaseUserControl.LabelWidth = 240;
            this.DatabaseUserControl.Location = new System.Drawing.Point(32, 148);
            this.DatabaseUserControl.MultiLine = false;
            this.DatabaseUserControl.Name = "DatabaseUserControl";
            this.DatabaseUserControl.OnTextChangedListener = null;
            this.DatabaseUserControl.PasswordMode = false;
            this.DatabaseUserControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DatabaseUserControl.Size = new System.Drawing.Size(720, 30);
            this.DatabaseUserControl.TabIndex = 4;
            this.DatabaseUserControl.TextBoxBottomMargin = 0;
            this.DatabaseUserControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.DatabaseUserControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.DatabaseUserControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseUserControl.TextBoxTopMargin = 0;
            // 
            // DatabasePasswordControl
            // 
            this.DatabasePasswordControl.BackColor = System.Drawing.Color.Transparent;
            this.DatabasePasswordControl.BottomMargin = 0;
            this.DatabasePasswordControl.Editable = true;
            this.DatabasePasswordControl.Encrypted = false;
            this.DatabasePasswordControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabasePasswordControl.LabelBottomMargin = 0;
            this.DatabasePasswordControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.DatabasePasswordControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabasePasswordControl.LabelText = "Database Password:";
            this.DatabasePasswordControl.LabelTopMargin = 0;
            this.DatabasePasswordControl.LabelWidth = 240;
            this.DatabasePasswordControl.Location = new System.Drawing.Point(32, 192);
            this.DatabasePasswordControl.MultiLine = false;
            this.DatabasePasswordControl.Name = "DatabasePasswordControl";
            this.DatabasePasswordControl.OnTextChangedListener = null;
            this.DatabasePasswordControl.PasswordMode = false;
            this.DatabasePasswordControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DatabasePasswordControl.Size = new System.Drawing.Size(720, 30);
            this.DatabasePasswordControl.TabIndex = 5;
            this.DatabasePasswordControl.TextBoxBottomMargin = 0;
            this.DatabasePasswordControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.DatabasePasswordControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.DatabasePasswordControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabasePasswordControl.TextBoxTopMargin = 0;
            // 
            // ConnectionstringControl
            // 
            this.ConnectionstringControl.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionstringControl.BottomMargin = 0;
            this.ConnectionstringControl.Editable = true;
            this.ConnectionstringControl.Encrypted = false;
            this.ConnectionstringControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionstringControl.LabelBottomMargin = 0;
            this.ConnectionstringControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ConnectionstringControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionstringControl.LabelText = "Connection String:";
            this.ConnectionstringControl.LabelTopMargin = 0;
            this.ConnectionstringControl.LabelWidth = 240;
            this.ConnectionstringControl.Location = new System.Drawing.Point(32, 324);
            this.ConnectionstringControl.MultiLine = true;
            this.ConnectionstringControl.Name = "ConnectionstringControl";
            this.ConnectionstringControl.OnTextChangedListener = null;
            this.ConnectionstringControl.PasswordMode = false;
            this.ConnectionstringControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ConnectionstringControl.Size = new System.Drawing.Size(720, 134);
            this.ConnectionstringControl.TabIndex = 6;
            this.ConnectionstringControl.TextBoxBottomMargin = 0;
            this.ConnectionstringControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ConnectionstringControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ConnectionstringControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionstringControl.TextBoxTopMargin = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Location = new System.Drawing.Point(387, 473);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(308, 37);
            this.StatusLabel.TabIndex = 15;
            this.StatusLabel.Text = "Database Connection Passed!";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusLabel.Visible = false;
            // 
            // StatusImage
            // 
            this.StatusImage.BackColor = System.Drawing.Color.Transparent;
            this.StatusImage.BackgroundImage = global::ConnectionBuilder.Properties.Resources.Success;
            this.StatusImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatusImage.Location = new System.Drawing.Point(699, 467);
            this.StatusImage.Name = "StatusImage";
            this.StatusImage.Size = new System.Drawing.Size(48, 48);
            this.StatusImage.TabIndex = 16;
            this.StatusImage.TabStop = false;
            this.StatusImage.Visible = false;
            // 
            // CopiedImage
            // 
            this.CopiedImage.BackColor = System.Drawing.Color.Transparent;
            this.CopiedImage.BackgroundImage = global::ConnectionBuilder.Properties.Resources.Copied;
            this.CopiedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopiedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CopiedImage.Location = new System.Drawing.Point(12, 546);
            this.CopiedImage.Name = "CopiedImage";
            this.CopiedImage.Size = new System.Drawing.Size(120, 68);
            this.CopiedImage.TabIndex = 17;
            this.CopiedImage.TabStop = false;
            this.CopiedImage.Visible = false;
            // 
            // CopiedTimer
            // 
            this.CopiedTimer.Interval = 4000;
            this.CopiedTimer.Tick += new System.EventHandler(this.CopiedTimer_Tick);
            // 
            // IncludeEncryptCheckBox
            // 
            this.IncludeEncryptCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.IncludeEncryptCheckBox.CheckBoxHorizontalOffSet = 0;
            this.IncludeEncryptCheckBox.CheckBoxVerticalOffSet = 4;
            this.IncludeEncryptCheckBox.CheckChangedListener = null;
            this.IncludeEncryptCheckBox.Checked = false;
            this.IncludeEncryptCheckBox.Editable = true;
            this.IncludeEncryptCheckBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncludeEncryptCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.IncludeEncryptCheckBox.LabelFont = null;
            this.IncludeEncryptCheckBox.LabelText = "Include Encrypt:";
            this.IncludeEncryptCheckBox.LabelWidth = 240;
            this.IncludeEncryptCheckBox.Location = new System.Drawing.Point(32, 286);
            this.IncludeEncryptCheckBox.Name = "IncludeEncryptCheckBox";
            this.IncludeEncryptCheckBox.Size = new System.Drawing.Size(280, 28);
            this.IncludeEncryptCheckBox.TabIndex = 19;
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoLabel.Location = new System.Drawing.Point(54, 237);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(699, 44);
            this.InfoLabel.TabIndex = 18;
            this.InfoLabel.Text = "Microsoft.Data.SqlClient requires you to set Encrypt=False if your database is no" +
    "t encrypted. Leave this checked if you are targeting .NET Core.\r\n";
            // 
            // EncryptValueComboBox
            // 
            this.EncryptValueComboBox.BackColor = System.Drawing.Color.Transparent;
            this.EncryptValueComboBox.ComboBoxLeftMargin = 1;
            this.EncryptValueComboBox.ComboBoxText = "";
            this.EncryptValueComboBox.ComoboBoxFont = null;
            this.EncryptValueComboBox.Editable = true;
            this.EncryptValueComboBox.Enabled = false;
            this.EncryptValueComboBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptValueComboBox.HideLabel = false;
            this.EncryptValueComboBox.LabelBottomMargin = 0;
            this.EncryptValueComboBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.EncryptValueComboBox.LabelFont = null;
            this.EncryptValueComboBox.LabelText = "Encrypt Value:";
            this.EncryptValueComboBox.LabelTopMargin = 0;
            this.EncryptValueComboBox.LabelWidth = 180;
            this.EncryptValueComboBox.List = null;
            this.EncryptValueComboBox.Location = new System.Drawing.Point(392, 284);
            this.EncryptValueComboBox.Name = "EncryptValueComboBox";
            this.EncryptValueComboBox.SelectedIndex = -1;
            this.EncryptValueComboBox.SelectedIndexListener = null;
            this.EncryptValueComboBox.Size = new System.Drawing.Size(360, 32);
            this.EncryptValueComboBox.Sorted = false;
            this.EncryptValueComboBox.Source = null;
            this.EncryptValueComboBox.TabIndex = 20;
            // 
            // ConnectionStringBuilderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::ConnectionBuilder.Properties.Resources.LinenBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(792, 625);
            this.Controls.Add(this.EncryptValueComboBox);
            this.Controls.Add(this.IncludeEncryptCheckBox);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.CopiedImage);
            this.Controls.Add(this.StatusImage);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ConnectionstringControl);
            this.Controls.Add(this.DatabasePasswordControl);
            this.Controls.Add(this.DatabaseUserControl);
            this.Controls.Add(this.DatabaseServerControl);
            this.Controls.Add(this.DatabaseNameControl);
            this.Controls.Add(this.TestDatabaseConnectionButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.BuildConnectionStringButton);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.SQLServerAuthenticationRadioButton);
            this.Controls.Add(this.WindowsAuthenticationRadioButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(808, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(808, 564);
            this.Name = "ConnectionStringBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection String Builder";
            this.Activated += new System.EventHandler(this.ConnectionStringBuilderForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.StatusImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.PictureBox StatusImage;
        private System.Windows.Forms.PictureBox CopiedImage;
        private System.Windows.Forms.Timer CopiedTimer;
        private DataJuggler.Win.Controls.LabelCheckBoxControl IncludeEncryptCheckBox;
        private System.Windows.Forms.Label InfoLabel;
        private DataJuggler.Win.Controls.LabelComboBoxControl EncryptValueComboBox;
    }
    #endregion

}
