

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
        private DataJuggler.Win.Controls.LabelCheckBoxControl DatabaseCreatedCheckBox;
        private System.Windows.Forms.Label InstallDatabaseSchemaButton;
        private System.Windows.Forms.Label InstallProjectTemplatesButton;
        private System.Windows.Forms.Label ConfigureButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label InfoLabel3;
        private System.Windows.Forms.Label InfoLabel2;
        private System.Windows.Forms.Label InfoLabel1;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.PictureBox ClickHere;
        private System.Windows.Forms.Button ViewPDFButton;
        private System.Windows.Forms.Button ViewWordButton;
        private System.Windows.Forms.Label UsersGuideLabel;
        private System.Windows.Forms.Label InstallDotNet5Label;
        private System.Windows.Forms.Label FrameworkLabel;
        private System.Windows.Forms.Label UninstallDotNet5Label;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupControl));
                this.DatabaseCreatedCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
                this.InstallDatabaseSchemaButton = new System.Windows.Forms.Label();
                this.InstallProjectTemplatesButton = new System.Windows.Forms.Label();
                this.ConfigureButton = new System.Windows.Forms.Label();
                this.CancelButton = new System.Windows.Forms.Button();
                this.InfoLabel3 = new System.Windows.Forms.Label();
                this.InfoLabel2 = new System.Windows.Forms.Label();
                this.InfoLabel1 = new System.Windows.Forms.Label();
                this.InfoLabel = new System.Windows.Forms.Label();
                this.ClickHere = new System.Windows.Forms.PictureBox();
                this.ViewPDFButton = new System.Windows.Forms.Button();
                this.ViewWordButton = new System.Windows.Forms.Button();
                this.UsersGuideLabel = new System.Windows.Forms.Label();
                this.InstallDotNet5Label = new System.Windows.Forms.Label();
                this.FrameworkLabel = new System.Windows.Forms.Label();
                this.UninstallDotNet5Label = new System.Windows.Forms.Label();
                ((System.ComponentModel.ISupportInitialize)(this.ClickHere)).BeginInit();
                this.SuspendLayout();
                // 
                // DatabaseCreatedCheckBox
                // 
                this.DatabaseCreatedCheckBox.BackColor = System.Drawing.Color.Transparent;
                this.DatabaseCreatedCheckBox.CheckBoxHorizontalOffSet = 0;
                this.DatabaseCreatedCheckBox.CheckBoxVerticalOffSet = 4;
                this.DatabaseCreatedCheckBox.CheckChangedListener = null;
                this.DatabaseCreatedCheckBox.Checked = false;
                this.DatabaseCreatedCheckBox.Editable = true;
                this.DatabaseCreatedCheckBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DatabaseCreatedCheckBox.LabelColor = System.Drawing.Color.GhostWhite;
                this.DatabaseCreatedCheckBox.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DatabaseCreatedCheckBox.LabelText = "DataTier.Net.Database Has Been Created:";
                this.DatabaseCreatedCheckBox.LabelWidth = 412;
                this.DatabaseCreatedCheckBox.Location = new System.Drawing.Point(314, 46);
                this.DatabaseCreatedCheckBox.Name = "DatabaseCreatedCheckBox";
                this.DatabaseCreatedCheckBox.Size = new System.Drawing.Size(440, 32);
                this.DatabaseCreatedCheckBox.TabIndex = 0;
                // 
                // InstallDatabaseSchemaButton
                // 
                this.InstallDatabaseSchemaButton.Enabled = false;
                this.InstallDatabaseSchemaButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.InstallDatabaseSchemaButton.ForeColor = System.Drawing.Color.DarkGray;
                this.InstallDatabaseSchemaButton.Location = new System.Drawing.Point(314, 87);
                this.InstallDatabaseSchemaButton.Name = "InstallDatabaseSchemaButton";
                this.InstallDatabaseSchemaButton.Size = new System.Drawing.Size(400, 28);
                this.InstallDatabaseSchemaButton.TabIndex = 110;
                this.InstallDatabaseSchemaButton.Text = "DataTier.Net.Database.Schema.sql";
                this.InstallDatabaseSchemaButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.InstallDatabaseSchemaButton.Click += new System.EventHandler(this.InstallDatabaseSchemaButton_Click);
                this.InstallDatabaseSchemaButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.InstallDatabaseSchemaButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                this.InstallDatabaseSchemaButton.MouseHover += new System.EventHandler(this.InstallDatabaseSchemaButton_MouseHover);
                // 
                // InstallProjectTemplatesButton
                // 
                this.InstallProjectTemplatesButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.InstallProjectTemplatesButton.ForeColor = System.Drawing.Color.GhostWhite;
                this.InstallProjectTemplatesButton.Location = new System.Drawing.Point(480, 166);
                this.InstallProjectTemplatesButton.Name = "InstallProjectTemplatesButton";
                this.InstallProjectTemplatesButton.Size = new System.Drawing.Size(248, 53);
                this.InstallProjectTemplatesButton.TabIndex = 111;
                this.InstallProjectTemplatesButton.Text = "Install DataTier.Net Project Templates.vsix";
                this.InstallProjectTemplatesButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.InstallProjectTemplatesButton.Click += new System.EventHandler(this.InstallProjectTemplatesButton_Click);
                this.InstallProjectTemplatesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.InstallProjectTemplatesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                this.InstallProjectTemplatesButton.MouseHover += new System.EventHandler(this.InstallProjectTemplatesButton_MouseHover);
                // 
                // ConfigureButton
                // 
                this.ConfigureButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ConfigureButton.ForeColor = System.Drawing.Color.GhostWhite;
                this.ConfigureButton.Location = new System.Drawing.Point(394, 325);
                this.ConfigureButton.Name = "ConfigureButton";
                this.ConfigureButton.Size = new System.Drawing.Size(240, 53);
                this.ConfigureButton.TabIndex = 112;
                this.ConfigureButton.Text = "Build Connectionstring && Setup App.config";
                this.ConfigureButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.ConfigureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
                this.ConfigureButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.ConfigureButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                this.ConfigureButton.MouseHover += new System.EventHandler(this.ConfigureButton_MouseHover);
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
                this.CancelButton.Location = new System.Drawing.Point(967, 664);
                this.CancelButton.Name = "CancelButton";
                this.CancelButton.Size = new System.Drawing.Size(88, 40);
                this.CancelButton.TabIndex = 113;
                this.CancelButton.Text = "Cancel";
                this.CancelButton.UseVisualStyleBackColor = false;
                this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
                this.CancelButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.CancelButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // InfoLabel3
                // 
                this.InfoLabel3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.InfoLabel3.ForeColor = System.Drawing.Color.LemonChiffon;
                this.InfoLabel3.Location = new System.Drawing.Point(767, 303);
                this.InfoLabel3.Name = "InfoLabel3";
                this.InfoLabel3.Size = new System.Drawing.Size(278, 104);
                this.InfoLabel3.TabIndex = 114;
                this.InfoLabel3.Text = "This will launch the form ConnectionStringBuilderForm.\r\n\r\nBuild and install a con" +
                "nectionstring and you are done!";
                this.InfoLabel3.Visible = false;
                // 
                // InfoLabel2
                // 
                this.InfoLabel2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.InfoLabel2.ForeColor = System.Drawing.Color.LemonChiffon;
                this.InfoLabel2.Location = new System.Drawing.Point(767, 162);
                this.InfoLabel2.Name = "InfoLabel2";
                this.InfoLabel2.Size = new System.Drawing.Size(278, 66);
                this.InfoLabel2.TabIndex = 115;
                this.InfoLabel2.Text = "Install the DataTier.Net Project Templates into Visual Studio 2017 or 2019 or bot" +
                "h.";
                this.InfoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.InfoLabel2.Visible = false;
                // 
                // InfoLabel1
                // 
                this.InfoLabel1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.InfoLabel1.ForeColor = System.Drawing.Color.LemonChiffon;
                this.InfoLabel1.Location = new System.Drawing.Point(767, 27);
                this.InfoLabel1.Name = "InfoLabel1";
                this.InfoLabel1.Size = new System.Drawing.Size(278, 126);
                this.InfoLabel1.TabIndex = 116;
                this.InfoLabel1.Text = "This will launch SQL Server Management Studio (if installed).\r\n\r\nExecute this SQL" +
                " Script to create the tables and procedures for DataTier.Net.Database.";
                this.InfoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.InfoLabel1.Visible = false;
                // 
                // InfoLabel
                // 
                this.InfoLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.InfoLabel.ForeColor = System.Drawing.Color.LemonChiffon;
                this.InfoLabel.Location = new System.Drawing.Point(767, 27);
                this.InfoLabel.Name = "InfoLabel";
                this.InfoLabel.Size = new System.Drawing.Size(278, 126);
                this.InfoLabel.TabIndex = 117;
                this.InfoLabel.Text = "Create a new database in SQL Server Management Studio \r\nnamed DataTier.Net.Databa" +
                "se, then check this box.";
                this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // ClickHere
                // 
                this.ClickHere.BackgroundImage = global::DataTierClient.Properties.Resources.Click_Here_Orange_Transparent1;
                this.ClickHere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClickHere.Location = new System.Drawing.Point(188, 83);
                this.ClickHere.Name = "ClickHere";
                this.ClickHere.Size = new System.Drawing.Size(150, 64);
                this.ClickHere.TabIndex = 118;
                this.ClickHere.TabStop = false;
                this.ClickHere.Visible = false;
                // 
                // ViewPDFButton
                // 
                this.ViewPDFButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewPDFButton.BackgroundImage")));
                this.ViewPDFButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ViewPDFButton.FlatAppearance.BorderSize = 0;
                this.ViewPDFButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                this.ViewPDFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ViewPDFButton.Location = new System.Drawing.Point(144, 343);
                this.ViewPDFButton.Name = "ViewPDFButton";
                this.ViewPDFButton.Size = new System.Drawing.Size(64, 64);
                this.ViewPDFButton.TabIndex = 120;
                this.ViewPDFButton.UseVisualStyleBackColor = true;
                this.ViewPDFButton.Click += new System.EventHandler(this.ViewPDFButton_Click);
                this.ViewPDFButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.ViewPDFButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // ViewWordButton
                // 
                this.ViewWordButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewWordButton.BackgroundImage")));
                this.ViewWordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ViewWordButton.FlatAppearance.BorderSize = 0;
                this.ViewWordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                this.ViewWordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ViewWordButton.Location = new System.Drawing.Point(56, 343);
                this.ViewWordButton.Name = "ViewWordButton";
                this.ViewWordButton.Size = new System.Drawing.Size(64, 64);
                this.ViewWordButton.TabIndex = 119;
                this.ViewWordButton.UseVisualStyleBackColor = true;
                this.ViewWordButton.Click += new System.EventHandler(this.ViewWordButton_Click);
                this.ViewWordButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.ViewWordButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // UsersGuideLabel
                // 
                this.UsersGuideLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UsersGuideLabel.ForeColor = System.Drawing.Color.LemonChiffon;
                this.UsersGuideLabel.Location = new System.Drawing.Point(42, 415);
                this.UsersGuideLabel.Name = "UsersGuideLabel";
                this.UsersGuideLabel.Size = new System.Drawing.Size(195, 17);
                this.UsersGuideLabel.TabIndex = 121;
                this.UsersGuideLabel.Text = "DataTier.Net Quick Start";
                // 
                // InstallDotNet5Label
                // 
                this.InstallDotNet5Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.InstallDotNet5Label.ForeColor = System.Drawing.Color.GhostWhite;
                this.InstallDotNet5Label.Location = new System.Drawing.Point(318, 233);
                this.InstallDotNet5Label.Name = "InstallDotNet5Label";
                this.InstallDotNet5Label.Size = new System.Drawing.Size(436, 26);
                this.InstallDotNet5Label.TabIndex = 122;
                this.InstallDotNet5Label.Text = "Install .Net 5 Project Templates\r\n\r\n\r\n\r\n";
                this.InstallDotNet5Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.InstallDotNet5Label.Click += new System.EventHandler(this.DotNet5Label_Click);
                this.InstallDotNet5Label.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.InstallDotNet5Label.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // FrameworkLabel
                // 
                this.FrameworkLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FrameworkLabel.ForeColor = System.Drawing.Color.GhostWhite;
                this.FrameworkLabel.Location = new System.Drawing.Point(345, 166);
                this.FrameworkLabel.Name = "FrameworkLabel";
                this.FrameworkLabel.Size = new System.Drawing.Size(125, 53);
                this.FrameworkLabel.TabIndex = 123;
                this.FrameworkLabel.Text = ".Net Framework:";
                this.FrameworkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // UninstallDotNet5Label
                // 
                this.UninstallDotNet5Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UninstallDotNet5Label.ForeColor = System.Drawing.Color.GhostWhite;
                this.UninstallDotNet5Label.Location = new System.Drawing.Point(318, 259);
                this.UninstallDotNet5Label.Name = "UninstallDotNet5Label";
                this.UninstallDotNet5Label.Size = new System.Drawing.Size(436, 35);
                this.UninstallDotNet5Label.TabIndex = 124;
                this.UninstallDotNet5Label.Text = "Uninstall .Net 5 Project Templates\r\n\r\n\r\n\r\n\r\n";
                this.UninstallDotNet5Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.UninstallDotNet5Label.Click += new System.EventHandler(this.UninstallDotNet5Label_Click);
                this.UninstallDotNet5Label.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.UninstallDotNet5Label.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // SetupControl
                // 
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackColor = System.Drawing.Color.Transparent;
                this.BackgroundImage = global::DataTierClient.Properties.Resources.Setup_Background;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Controls.Add(this.UninstallDotNet5Label);
                this.Controls.Add(this.FrameworkLabel);
                this.Controls.Add(this.InstallDotNet5Label);
                this.Controls.Add(this.ViewPDFButton);
                this.Controls.Add(this.ViewWordButton);
                this.Controls.Add(this.UsersGuideLabel);
                this.Controls.Add(this.ClickHere);
                this.Controls.Add(this.InfoLabel);
                this.Controls.Add(this.InfoLabel1);
                this.Controls.Add(this.InfoLabel2);
                this.Controls.Add(this.InfoLabel3);
                this.Controls.Add(this.CancelButton);
                this.Controls.Add(this.ConfigureButton);
                this.Controls.Add(this.InstallProjectTemplatesButton);
                this.Controls.Add(this.InstallDatabaseSchemaButton);
                this.Controls.Add(this.DatabaseCreatedCheckBox);
                this.DoubleBuffered = true;
                this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ForeColor = System.Drawing.Color.GhostWhite;
                this.Name = "SetupControl";
                this.Size = new System.Drawing.Size(1080, 720);
                ((System.ComponentModel.ISupportInitialize)(this.ClickHere)).EndInit();
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
