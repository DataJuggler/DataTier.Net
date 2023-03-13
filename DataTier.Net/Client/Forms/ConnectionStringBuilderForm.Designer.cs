﻿

#region using statements


#endregion

namespace DataTierClient.Forms
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
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button InstallConnectionStringButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabaseNameControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabaseServerControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabaseUserControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DatabasePasswordControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl ConnectionstringControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl UseEncryptionCheckBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl EncryptionKeyControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl UseCustomKeyCheckBox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.PictureBox StatusImage;
        private System.Windows.Forms.PictureBox CopiedImage;
        private System.Windows.Forms.Timer CopiedTimer;
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.InstallConnectionStringButton = new System.Windows.Forms.Button();
            this.DatabaseNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.DatabaseServerControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.DatabaseUserControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.DatabasePasswordControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.ConnectionstringControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.UseEncryptionCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.EncryptionKeyControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.UseCustomKeyCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusImage = new System.Windows.Forms.PictureBox();
            this.CopiedImage = new System.Windows.Forms.PictureBox();
            this.CopiedTimer = new System.Windows.Forms.Timer(this.components);
            this.TestButton = new System.Windows.Forms.Button();
            this.InstalledImage = new System.Windows.Forms.PictureBox();
            this.InstalledTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StatusImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstalledImage)).BeginInit();
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
            this.BuildConnectionStringButton.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonWidth1280Disabled;
            this.BuildConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BuildConnectionStringButton.Enabled = false;
            this.BuildConnectionStringButton.FlatAppearance.BorderSize = 0;
            this.BuildConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BuildConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuildConnectionStringButton.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildConnectionStringButton.ForeColor = System.Drawing.Color.DarkGray;
            this.BuildConnectionStringButton.Location = new System.Drawing.Point(305, 573);
            this.BuildConnectionStringButton.Name = "BuildConnectionStringButton";
            this.BuildConnectionStringButton.Size = new System.Drawing.Size(228, 40);
            this.BuildConnectionStringButton.TabIndex = 8;
            this.BuildConnectionStringButton.Text = "Build Conn String";
            this.BuildConnectionStringButton.UseVisualStyleBackColor = false;
            this.BuildConnectionStringButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.BuildConnectionStringButton.Click += new System.EventHandler(this.BuildConnectionStringButton_Click);
            this.BuildConnectionStringButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.BuildConnectionStringButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelButton.BackgroundImage")));
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.Black;
            this.CancelButton.Location = new System.Drawing.Point(647, 573);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(104, 40);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.DoneButton_Click);
            this.CancelButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CancelButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
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
            this.CopyButton.Location = new System.Drawing.Point(538, 573);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(104, 40);
            this.CopyButton.TabIndex = 9;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = false;
            this.CopyButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            this.CopyButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CopyButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // InstallConnectionStringButton
            // 
            this.InstallConnectionStringButton.BackColor = System.Drawing.Color.Transparent;
            this.InstallConnectionStringButton.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonWidth2560Disabled;
            this.InstallConnectionStringButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InstallConnectionStringButton.Enabled = false;
            this.InstallConnectionStringButton.FlatAppearance.BorderSize = 0;
            this.InstallConnectionStringButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.InstallConnectionStringButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.InstallConnectionStringButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallConnectionStringButton.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallConnectionStringButton.ForeColor = System.Drawing.Color.DarkGray;
            this.InstallConnectionStringButton.Location = new System.Drawing.Point(305, 527);
            this.InstallConnectionStringButton.Name = "InstallConnectionStringButton";
            this.InstallConnectionStringButton.Size = new System.Drawing.Size(450, 40);
            this.InstallConnectionStringButton.TabIndex = 7;
            this.InstallConnectionStringButton.Text = "Install Connection String";
            this.InstallConnectionStringButton.UseVisualStyleBackColor = false;
            this.InstallConnectionStringButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.InstallConnectionStringButton.Click += new System.EventHandler(this.InstallConnectionStringButton_Click);
            this.InstallConnectionStringButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.InstallConnectionStringButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
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
            this.ConnectionstringControl.Location = new System.Drawing.Point(32, 320);
            this.ConnectionstringControl.MultiLine = true;
            this.ConnectionstringControl.Name = "ConnectionstringControl";
            this.ConnectionstringControl.OnTextChangedListener = null;
            this.ConnectionstringControl.PasswordMode = false;
            this.ConnectionstringControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ConnectionstringControl.Size = new System.Drawing.Size(720, 137);
            this.ConnectionstringControl.TabIndex = 6;
            this.ConnectionstringControl.TextBoxBottomMargin = 0;
            this.ConnectionstringControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ConnectionstringControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ConnectionstringControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionstringControl.TextBoxTopMargin = 0;
            // 
            // UseEncryptionCheckBox
            // 
            this.UseEncryptionCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.UseEncryptionCheckBox.CheckBoxHorizontalOffSet = 0;
            this.UseEncryptionCheckBox.CheckBoxVerticalOffSet = 4;
            this.UseEncryptionCheckBox.CheckChangedListener = null;
            this.UseEncryptionCheckBox.Checked = false;
            this.UseEncryptionCheckBox.Editable = true;
            this.UseEncryptionCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseEncryptionCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.UseEncryptionCheckBox.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseEncryptionCheckBox.LabelText = "Use Encryption:";
            this.UseEncryptionCheckBox.LabelWidth = 240;
            this.UseEncryptionCheckBox.Location = new System.Drawing.Point(32, 236);
            this.UseEncryptionCheckBox.Name = "UseEncryptionCheckBox";
            this.UseEncryptionCheckBox.Size = new System.Drawing.Size(290, 24);
            this.UseEncryptionCheckBox.TabIndex = 12;
            // 
            // EncryptionKeyControl
            // 
            this.EncryptionKeyControl.BackColor = System.Drawing.Color.Transparent;
            this.EncryptionKeyControl.BottomMargin = 0;
            this.EncryptionKeyControl.Editable = false;
            this.EncryptionKeyControl.Enabled = false;
            this.EncryptionKeyControl.Encrypted = false;
            this.EncryptionKeyControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptionKeyControl.LabelBottomMargin = 0;
            this.EncryptionKeyControl.LabelColor = System.Drawing.Color.DarkGray;
            this.EncryptionKeyControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptionKeyControl.LabelText = "Encryption Key:";
            this.EncryptionKeyControl.LabelTopMargin = 0;
            this.EncryptionKeyControl.LabelWidth = 240;
            this.EncryptionKeyControl.Location = new System.Drawing.Point(32, 276);
            this.EncryptionKeyControl.MultiLine = false;
            this.EncryptionKeyControl.Name = "EncryptionKeyControl";
            this.EncryptionKeyControl.OnTextChangedListener = null;
            this.EncryptionKeyControl.PasswordMode = false;
            this.EncryptionKeyControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EncryptionKeyControl.Size = new System.Drawing.Size(720, 30);
            this.EncryptionKeyControl.TabIndex = 13;
            this.EncryptionKeyControl.TextBoxBottomMargin = 0;
            this.EncryptionKeyControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.EncryptionKeyControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.EncryptionKeyControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncryptionKeyControl.TextBoxTopMargin = 0;
            // 
            // UseCustomKeyCheckBox
            // 
            this.UseCustomKeyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.UseCustomKeyCheckBox.CheckBoxHorizontalOffSet = 0;
            this.UseCustomKeyCheckBox.CheckBoxVerticalOffSet = 4;
            this.UseCustomKeyCheckBox.CheckChangedListener = null;
            this.UseCustomKeyCheckBox.Checked = false;
            this.UseCustomKeyCheckBox.Editable = false;
            this.UseCustomKeyCheckBox.Enabled = false;
            this.UseCustomKeyCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseCustomKeyCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.UseCustomKeyCheckBox.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseCustomKeyCheckBox.LabelText = "Use Custom Key:";
            this.UseCustomKeyCheckBox.LabelWidth = 200;
            this.UseCustomKeyCheckBox.Location = new System.Drawing.Point(300, 236);
            this.UseCustomKeyCheckBox.Name = "UseCustomKeyCheckBox";
            this.UseCustomKeyCheckBox.Size = new System.Drawing.Size(270, 24);
            this.UseCustomKeyCheckBox.TabIndex = 14;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Location = new System.Drawing.Point(387, 468);
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
            this.StatusImage.BackgroundImage = global::DataTierClient.Properties.Resources.Failure;
            this.StatusImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StatusImage.Location = new System.Drawing.Point(699, 462);
            this.StatusImage.Name = "StatusImage";
            this.StatusImage.Size = new System.Drawing.Size(48, 48);
            this.StatusImage.TabIndex = 16;
            this.StatusImage.TabStop = false;
            this.StatusImage.Visible = false;
            // 
            // CopiedImage
            // 
            this.CopiedImage.BackColor = System.Drawing.Color.Transparent;
            this.CopiedImage.BackgroundImage = global::DataTierClient.Properties.Resources.Copied;
            this.CopiedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            // TestButton
            // 
            this.TestButton.BackColor = System.Drawing.Color.Transparent;
            this.TestButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TestButton.BackgroundImage")));
            this.TestButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TestButton.Enabled = false;
            this.TestButton.FlatAppearance.BorderSize = 0;
            this.TestButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TestButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestButton.ForeColor = System.Drawing.Color.DarkGray;
            this.TestButton.Location = new System.Drawing.Point(272, 466);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(125, 40);
            this.TestButton.TabIndex = 18;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = false;
            this.TestButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.TestButton.Click += new System.EventHandler(this.TestDatabaseConnectionButton_Click);
            this.TestButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.TestButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // InstalledImage
            // 
            this.InstalledImage.BackColor = System.Drawing.Color.Transparent;
            this.InstalledImage.BackgroundImage = global::DataTierClient.Properties.Resources.Installed;
            this.InstalledImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InstalledImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstalledImage.Location = new System.Drawing.Point(12, 546);
            this.InstalledImage.Name = "InstalledImage";
            this.InstalledImage.Size = new System.Drawing.Size(200, 68);
            this.InstalledImage.TabIndex = 19;
            this.InstalledImage.TabStop = false;
            this.InstalledImage.Visible = false;
            // 
            // InstalledTimer
            // 
            this.InstalledTimer.Interval = 4000;
            this.InstalledTimer.Tick += new System.EventHandler(this.InstalledTimer_Tick);
            // 
            // ConnectionStringBuilderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::DataTierClient.Properties.Resources.LinenBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(792, 634);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.CopiedImage);
            this.Controls.Add(this.StatusImage);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.UseCustomKeyCheckBox);
            this.Controls.Add(this.EncryptionKeyControl);
            this.Controls.Add(this.UseEncryptionCheckBox);
            this.Controls.Add(this.ConnectionstringControl);
            this.Controls.Add(this.DatabasePasswordControl);
            this.Controls.Add(this.DatabaseUserControl);
            this.Controls.Add(this.DatabaseServerControl);
            this.Controls.Add(this.DatabaseNameControl);
            this.Controls.Add(this.InstallConnectionStringButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.BuildConnectionStringButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SQLServerAuthenticationRadioButton);
            this.Controls.Add(this.WindowsAuthenticationRadioButton);
            this.Controls.Add(this.InstalledImage);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(808, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(808, 564);
            this.Name = "ConnectionStringBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection String Builder";
            ((System.ComponentModel.ISupportInitialize)(this.StatusImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopiedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstalledImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.PictureBox InstalledImage;
        private System.Windows.Forms.Timer InstalledTimer;
    }
    #endregion

}
