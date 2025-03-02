

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class SetupControl
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class SetupControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
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
            this.Step1Button = new System.Windows.Forms.Button();
            this.Step2Button = new System.Windows.Forms.Button();
            this.RemoveTemplatesButton = new System.Windows.Forms.Button();
            this.ViewPDFButton = new System.Windows.Forms.Button();
            this.ViewWordButton = new System.Windows.Forms.Button();
            this.UsersGuideLabel = new System.Windows.Forms.Label();
            this.RightPanelStep1 = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.InstallDatabaseSchemaButton = new System.Windows.Forms.Label();
            this.DatabaseCreatedCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ManHoldingSign = new System.Windows.Forms.PictureBox();
            this.CancelSetupButton = new System.Windows.Forms.Button();
            this.ClickHereButton = new System.Windows.Forms.PictureBox();
            this.HiddenButton = new System.Windows.Forms.Button();
            this.RightPanelStep1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManHoldingSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClickHereButton)).BeginInit();
            this.SuspendLayout();
            // 
            // Step1Button
            // 
            this.Step1Button.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonRed;
            this.Step1Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Step1Button.FlatAppearance.BorderSize = 0;
            this.Step1Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Step1Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Step1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Step1Button.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step1Button.Location = new System.Drawing.Point(556, 408);
            this.Step1Button.Name = "Step1Button";
            this.Step1Button.Size = new System.Drawing.Size(234, 64);
            this.Step1Button.TabIndex = 122;
            this.Step1Button.Text = "Step 1";
            this.Step1Button.UseVisualStyleBackColor = true;
            this.Step1Button.EnabledChanged += new System.EventHandler(this.Step1Button_EnabledChanged);
            this.Step1Button.Click += new System.EventHandler(this.Step1Button_Click);
            this.Step1Button.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.Step1Button.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Step2Button
            // 
            this.Step2Button.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonDarkGray;
            this.Step2Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Step2Button.Enabled = false;
            this.Step2Button.FlatAppearance.BorderSize = 0;
            this.Step2Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Step2Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Step2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Step2Button.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step2Button.Location = new System.Drawing.Point(556, 478);
            this.Step2Button.Name = "Step2Button";
            this.Step2Button.Size = new System.Drawing.Size(234, 64);
            this.Step2Button.TabIndex = 123;
            this.Step2Button.Text = "Step 2";
            this.Step2Button.UseVisualStyleBackColor = true;
            this.Step2Button.EnabledChanged += new System.EventHandler(this.Step2Button_EnabledChanged);
            this.Step2Button.Click += new System.EventHandler(this.Step2Button_Click);
            this.Step2Button.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.Step2Button.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // RemoveTemplatesButton
            // 
            this.RemoveTemplatesButton.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonWideRed1;
            this.RemoveTemplatesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveTemplatesButton.FlatAppearance.BorderSize = 0;
            this.RemoveTemplatesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RemoveTemplatesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RemoveTemplatesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveTemplatesButton.Font = new System.Drawing.Font("Calibri", 18F);
            this.RemoveTemplatesButton.Location = new System.Drawing.Point(449, 682);
            this.RemoveTemplatesButton.Name = "RemoveTemplatesButton";
            this.RemoveTemplatesButton.Size = new System.Drawing.Size(341, 64);
            this.RemoveTemplatesButton.TabIndex = 124;
            this.RemoveTemplatesButton.Text = "Remove Templates";
            this.RemoveTemplatesButton.UseVisualStyleBackColor = true;
            this.RemoveTemplatesButton.Click += new System.EventHandler(this.RemoveTemplatesButton_Click);
            this.RemoveTemplatesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.RemoveTemplatesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ViewPDFButton
            // 
            this.ViewPDFButton.BackColor = System.Drawing.Color.Transparent;
            this.ViewPDFButton.BackgroundImage = global::DataTierClient.Properties.Resources.WordIcon;
            this.ViewPDFButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewPDFButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ViewPDFButton.FlatAppearance.BorderSize = 0;
            this.ViewPDFButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ViewPDFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewPDFButton.Location = new System.Drawing.Point(84, 386);
            this.ViewPDFButton.Name = "ViewPDFButton";
            this.ViewPDFButton.Size = new System.Drawing.Size(80, 96);
            this.ViewPDFButton.TabIndex = 131;
            this.ViewPDFButton.UseVisualStyleBackColor = false;
            this.ViewPDFButton.Click += new System.EventHandler(this.ViewWordButton_Click);
            this.ViewPDFButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.ViewPDFButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ViewWordButton
            // 
            this.ViewWordButton.BackColor = System.Drawing.Color.Transparent;
            this.ViewWordButton.BackgroundImage = global::DataTierClient.Properties.Resources.PDFIcon;
            this.ViewWordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewWordButton.FlatAppearance.BorderSize = 0;
            this.ViewWordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ViewWordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewWordButton.Location = new System.Drawing.Point(212, 392);
            this.ViewWordButton.Name = "ViewWordButton";
            this.ViewWordButton.Size = new System.Drawing.Size(80, 80);
            this.ViewWordButton.TabIndex = 127;
            this.ViewWordButton.UseVisualStyleBackColor = false;
            this.ViewWordButton.Click += new System.EventHandler(this.ViewPDFButton_Click);
            this.ViewWordButton.MouseEnter += new System.EventHandler(this.Button_Leave);
            this.ViewWordButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // UsersGuideLabel
            // 
            this.UsersGuideLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersGuideLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.UsersGuideLabel.Location = new System.Drawing.Point(56, 355);
            this.UsersGuideLabel.Name = "UsersGuideLabel";
            this.UsersGuideLabel.Size = new System.Drawing.Size(261, 38);
            this.UsersGuideLabel.TabIndex = 129;
            this.UsersGuideLabel.Text = "DataTier.Net Quick Start";
            this.UsersGuideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RightPanelStep1
            // 
            this.RightPanelStep1.Controls.Add(this.InstallDatabaseSchemaButton);
            this.RightPanelStep1.Controls.Add(this.DatabaseCreatedCheckBox);
            this.RightPanelStep1.Controls.Add(this.ManHoldingSign);
            this.RightPanelStep1.Controls.Add(this.CancelSetupButton);
            this.RightPanelStep1.Controls.Add(this.ClickHereButton);
            this.RightPanelStep1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanelStep1.Location = new System.Drawing.Point(851, 0);
            this.RightPanelStep1.Name = "RightPanelStep1";
            this.RightPanelStep1.Size = new System.Drawing.Size(429, 760);
            this.RightPanelStep1.TabIndex = 125;
            // 
            // InstallDatabaseSchemaButton
            // 
            this.InstallDatabaseSchemaButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InstallDatabaseSchemaButton.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.InstallDatabaseSchemaButton.ForeColor = System.Drawing.Color.White;
            this.InstallDatabaseSchemaButton.Location = new System.Drawing.Point(0, 399);
            this.InstallDatabaseSchemaButton.Name = "InstallDatabaseSchemaButton";
            this.InstallDatabaseSchemaButton.Size = new System.Drawing.Size(429, 48);
            this.InstallDatabaseSchemaButton.TabIndex = 135;
            this.InstallDatabaseSchemaButton.Text = "DataTier.Net.Database.Schema.sql";
            this.InstallDatabaseSchemaButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InstallDatabaseSchemaButton.Visible = false;
            this.InstallDatabaseSchemaButton.Click += new System.EventHandler(this.InstallDatabaseSchemaButton_Click);
            this.InstallDatabaseSchemaButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.InstallDatabaseSchemaButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DatabaseCreatedCheckBox
            // 
            this.DatabaseCreatedCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DatabaseCreatedCheckBox.CheckBoxHorizontalOffSet = 0;
            this.DatabaseCreatedCheckBox.CheckBoxVerticalOffSet = 4;
            this.DatabaseCreatedCheckBox.CheckChangedListener = null;
            this.DatabaseCreatedCheckBox.Checked = false;
            this.DatabaseCreatedCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.DatabaseCreatedCheckBox.Editable = true;
            this.DatabaseCreatedCheckBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseCreatedCheckBox.LabelColor = System.Drawing.Color.GhostWhite;
            this.DatabaseCreatedCheckBox.LabelFont = new System.Drawing.Font("Calibri", 14.25F);
            this.DatabaseCreatedCheckBox.LabelText = "Database Has Been Created:";
            this.DatabaseCreatedCheckBox.LabelWidth = 320;
            this.DatabaseCreatedCheckBox.Location = new System.Drawing.Point(0, 371);
            this.DatabaseCreatedCheckBox.Name = "DatabaseCreatedCheckBox";
            this.DatabaseCreatedCheckBox.Size = new System.Drawing.Size(429, 28);
            this.DatabaseCreatedCheckBox.TabIndex = 134;
            // 
            // ManHoldingSign
            // 
            this.ManHoldingSign.BackgroundImage = global::DataTierClient.Properties.Resources.setupStep2;
            this.ManHoldingSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ManHoldingSign.Dock = System.Windows.Forms.DockStyle.Top;
            this.ManHoldingSign.Location = new System.Drawing.Point(0, 0);
            this.ManHoldingSign.Name = "ManHoldingSign";
            this.ManHoldingSign.Size = new System.Drawing.Size(429, 371);
            this.ManHoldingSign.TabIndex = 132;
            this.ManHoldingSign.TabStop = false;
            // 
            // CancelSetupButton
            // 
            this.CancelSetupButton.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonWideRed;
            this.CancelSetupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelSetupButton.FlatAppearance.BorderSize = 0;
            this.CancelSetupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelSetupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSetupButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelSetupButton.Location = new System.Drawing.Point(224, 682);
            this.CancelSetupButton.Name = "CancelSetupButton";
            this.CancelSetupButton.Size = new System.Drawing.Size(188, 64);
            this.CancelSetupButton.TabIndex = 128;
            this.CancelSetupButton.Text = "Cancel";
            this.CancelSetupButton.UseVisualStyleBackColor = true;
            this.CancelSetupButton.Click += new System.EventHandler(this.CancelButton_Click);
            this.CancelSetupButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CancelSetupButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ClickHereButton
            // 
            this.ClickHereButton.BackgroundImage = global::DataTierClient.Properties.Resources.ClickHereRed2;
            this.ClickHereButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClickHereButton.Location = new System.Drawing.Point(-82, 453);
            this.ClickHereButton.Name = "ClickHereButton";
            this.ClickHereButton.Size = new System.Drawing.Size(360, 230);
            this.ClickHereButton.TabIndex = 127;
            this.ClickHereButton.TabStop = false;
            this.ClickHereButton.Visible = false;
            // 
            // HiddenButton
            // 
            this.HiddenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HiddenButton.FlatAppearance.BorderSize = 0;
            this.HiddenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HiddenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HiddenButton.Font = new System.Drawing.Font("Calibri", 18F);
            this.HiddenButton.Location = new System.Drawing.Point(-800, 682);
            this.HiddenButton.Name = "HiddenButton";
            this.HiddenButton.Size = new System.Drawing.Size(341, 64);
            this.HiddenButton.TabIndex = 132;
            this.HiddenButton.Text = "Remove Templates";
            this.HiddenButton.UseVisualStyleBackColor = true;
            // 
            // SetupControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::DataTierClient.Properties.Resources.SetupControl2025;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.HiddenButton);
            this.Controls.Add(this.UsersGuideLabel);
            this.Controls.Add(this.RightPanelStep1);
            this.Controls.Add(this.ViewPDFButton);
            this.Controls.Add(this.ViewWordButton);
            this.Controls.Add(this.RemoveTemplatesButton);
            this.Controls.Add(this.Step2Button);
            this.Controls.Add(this.Step1Button);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.ForeColor = System.Drawing.Color.GhostWhite;
            this.Name = "SetupControl";
            this.Size = new System.Drawing.Size(1280, 760);
            this.RightPanelStep1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ManHoldingSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClickHereButton)).EndInit();
            this.ResumeLayout(false);

            }
        #endregion

        #endregion
        private System.Windows.Forms.Button Step1Button;
        private System.Windows.Forms.Button Step2Button;
        private System.Windows.Forms.Button RemoveTemplatesButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender RightPanelStep1;
        private System.Windows.Forms.Button ViewPDFButton;
        private System.Windows.Forms.Button ViewWordButton;
        private System.Windows.Forms.Label UsersGuideLabel;
        private System.Windows.Forms.PictureBox ClickHereButton;
        private System.Windows.Forms.Button CancelSetupButton;
        private System.Windows.Forms.PictureBox ManHoldingSign;
        private System.Windows.Forms.Label InstallDatabaseSchemaButton;
        private DataJuggler.Win.Controls.LabelCheckBoxControl DatabaseCreatedCheckBox;
        private System.Windows.Forms.Button HiddenButton;
    }
    #endregion

}
