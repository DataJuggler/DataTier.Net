

#region using statements

using DataTierClient.Controls;
using DataTierClient.Objects;

#endregion

namespace DataTierClient.Forms
{

    #region class MainForm
    /// <summary>
    /// This is the designer code for MainForm.
    /// </summary>
    partial class MainForm
    {
        
        #region Private Variables
        private System.Windows.Forms.ListView StatusListBox;
        private PanelExtender MainPanel;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ImageList Images;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripProgressBar MainProgressBar;
        private System.Windows.Forms.ToolTip ToolTipManager;
        private System.Windows.Forms.Label CurrentProjectLabel;
        private System.Windows.Forms.Label ProjectLabel;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button NewProjectButton;
        private System.Windows.Forms.Button OpenProjectButton;
        private System.Windows.Forms.Button CloseProjectButton;
        private System.Windows.Forms.Button EditProjectButton;
        private System.Windows.Forms.Button BuildAllButton;
        private System.Windows.Forms.Button HiddenButton;
        private PanelExtender RightContainer;
        private PanelExtender RightPanel;
        private System.Windows.Forms.Button ViewPDFButton;
        private System.Windows.Forms.Button ViewWordButton;
        private System.Windows.Forms.Label QuickStartLabel;
        private System.Windows.Forms.PictureBox ClassRoomImage;
        private PanelExtender BottomPanel;
        private PanelExtender BottomRightMarginpanel;
        private PanelExtender TopPanel;
        private System.Windows.Forms.Button ManageDataButton;
        private System.Windows.Forms.Label StoredProcedureSQLButton;
        private System.Windows.Forms.Label RunSetupButton;
        private System.Windows.Forms.Button ViewPDFButton2;
        private System.Windows.Forms.Button ViewWordButton2;
        private System.Windows.Forms.Label UsersGuideLabel;
        private System.Windows.Forms.Button YouTubeButton;
        private PanelExtender YouTubeButtonRightMarginPanel;
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
            internal void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
                this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
                this.MainProgressBar = new System.Windows.Forms.ToolStripProgressBar();
                this.Images = new System.Windows.Forms.ImageList(this.components);
                this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
                this.ToolTipManager = new System.Windows.Forms.ToolTip(this.components);
                this.MainPanel = new DataTierClient.Objects.PanelExtender();
                this.RunSetupButton = new System.Windows.Forms.Label();
                this.StoredProcedureSQLButton = new System.Windows.Forms.Label();
                this.HiddenButton = new System.Windows.Forms.Button();
                this.BuildAllButton = new System.Windows.Forms.Button();
                this.CloseProjectButton = new System.Windows.Forms.Button();
                this.EditProjectButton = new System.Windows.Forms.Button();
                this.OpenProjectButton = new System.Windows.Forms.Button();
                this.NewProjectButton = new System.Windows.Forms.Button();
                this.CurrentProjectLabel = new System.Windows.Forms.Label();
                this.ProjectLabel = new System.Windows.Forms.Label();
                this.StatusListBox = new System.Windows.Forms.ListView();
                this.RightContainer = new DataTierClient.Objects.PanelExtender();
                this.BottomPanel = new DataTierClient.Objects.PanelExtender();
                this.BottomRightMarginpanel = new DataTierClient.Objects.PanelExtender();
                this.TopPanel = new DataTierClient.Objects.PanelExtender();
                this.RightPanel = new DataTierClient.Objects.PanelExtender();
                this.ViewPDFButton2 = new System.Windows.Forms.Button();
                this.ViewWordButton2 = new System.Windows.Forms.Button();
                this.UsersGuideLabel = new System.Windows.Forms.Label();
                this.ViewPDFButton = new System.Windows.Forms.Button();
                this.ViewWordButton = new System.Windows.Forms.Button();
                this.QuickStartLabel = new System.Windows.Forms.Label();
                this.ClassRoomImage = new System.Windows.Forms.PictureBox();
                this.ManageDataButton = new System.Windows.Forms.Button();
                this.YouTubeButtonRightMarginPanel = new DataTierClient.Objects.PanelExtender();
                this.YouTubeButton = new System.Windows.Forms.Button();
                this.MainPanel.SuspendLayout();
                this.RightContainer.SuspendLayout();
                this.BottomPanel.SuspendLayout();
                this.RightPanel.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.ClassRoomImage)).BeginInit();
                this.SuspendLayout();
                // 
                // StatusLabel
                // 
                this.StatusLabel.BackColor = System.Drawing.SystemColors.Control;
                this.StatusLabel.Name = "StatusLabel";
                this.StatusLabel.Size = new System.Drawing.Size(39, 17);
                this.StatusLabel.Text = "Ready";
                // 
                // MainProgressBar
                // 
                this.MainProgressBar.Name = "MainProgressBar";
                this.MainProgressBar.Size = new System.Drawing.Size(100, 16);
                this.MainProgressBar.Visible = false;
                // 
                // Images
                // 
                this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
                this.Images.TransparentColor = System.Drawing.Color.Transparent;
                this.Images.Images.SetKeyName(0, "success.ico");
                this.Images.Images.SetKeyName(1, "Failed.ico");
                // 
                // MainStatusStrip
                // 
                this.MainStatusStrip.BackColor = System.Drawing.Color.Transparent;
                this.MainStatusStrip.BackgroundImage = global::DataTierClient.Properties.Resources.Deep_Black;
                this.MainStatusStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.MainStatusStrip.Location = new System.Drawing.Point(0, 659);
                this.MainStatusStrip.Name = "MainStatusStrip";
                this.MainStatusStrip.Size = new System.Drawing.Size(900, 22);
                this.MainStatusStrip.TabIndex = 2;
                this.MainStatusStrip.Text = "statusStrip1";
                // 
                // MainPanel
                // 
                this.MainPanel.BackColor = System.Drawing.Color.Transparent;
                this.MainPanel.BackgroundImage = global::DataTierClient.Properties.Resources.Deep_Black;
                this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.MainPanel.Controls.Add(this.RunSetupButton);
                this.MainPanel.Controls.Add(this.StoredProcedureSQLButton);
                this.MainPanel.Controls.Add(this.HiddenButton);
                this.MainPanel.Controls.Add(this.BuildAllButton);
                this.MainPanel.Controls.Add(this.CloseProjectButton);
                this.MainPanel.Controls.Add(this.EditProjectButton);
                this.MainPanel.Controls.Add(this.OpenProjectButton);
                this.MainPanel.Controls.Add(this.NewProjectButton);
                this.MainPanel.Controls.Add(this.CurrentProjectLabel);
                this.MainPanel.Controls.Add(this.ProjectLabel);
                this.MainPanel.Controls.Add(this.StatusListBox);
                this.MainPanel.Controls.Add(this.RightContainer);
                this.MainPanel.Controls.Add(this.ManageDataButton);
                this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                this.MainPanel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.MainPanel.Location = new System.Drawing.Point(0, 0);
                this.MainPanel.Name = "MainPanel";
                this.MainPanel.Size = new System.Drawing.Size(900, 659);
                this.MainPanel.TabIndex = 17;
                // 
                // RunSetupButton
                // 
                this.RunSetupButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.RunSetupButton.ForeColor = System.Drawing.Color.LemonChiffon;
                this.RunSetupButton.Location = new System.Drawing.Point(262, 20);
                this.RunSetupButton.Name = "RunSetupButton";
                this.RunSetupButton.Size = new System.Drawing.Size(240, 18);
                this.RunSetupButton.TabIndex = 110;
                this.RunSetupButton.Text = "Run Setup Again";
                this.RunSetupButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.RunSetupButton.Click += new System.EventHandler(this.RunSetupButton_Click);
                this.RunSetupButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.RunSetupButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // StoredProcedureSQLButton
                // 
                this.StoredProcedureSQLButton.ForeColor = System.Drawing.Color.GhostWhite;
                this.StoredProcedureSQLButton.Location = new System.Drawing.Point(18, 620);
                this.StoredProcedureSQLButton.Name = "StoredProcedureSQLButton";
                this.StoredProcedureSQLButton.Size = new System.Drawing.Size(220, 24);
                this.StoredProcedureSQLButton.TabIndex = 109;
                this.StoredProcedureSQLButton.Text = "StoredProcedures.sql";
                this.StoredProcedureSQLButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.StoredProcedureSQLButton.Visible = false;
                this.StoredProcedureSQLButton.Click += new System.EventHandler(this.StoredProcedureSQLButton_Click);
                this.StoredProcedureSQLButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.StoredProcedureSQLButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // HiddenButton
                // 
                this.HiddenButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
                this.HiddenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.HiddenButton.FlatAppearance.BorderSize = 0;
                this.HiddenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                this.HiddenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.HiddenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.HiddenButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.HiddenButton.ForeColor = System.Drawing.Color.LemonChiffon;
                this.HiddenButton.Location = new System.Drawing.Point(-1000, 655);
                this.HiddenButton.Name = "HiddenButton";
                this.HiddenButton.Size = new System.Drawing.Size(160, 40);
                this.HiddenButton.TabIndex = 94;
                this.HiddenButton.Text = "New Project";
                this.HiddenButton.UseVisualStyleBackColor = true;
                // 
                // BuildAllButton
                // 
                this.BuildAllButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuildAllButton.BackgroundImage")));
                this.BuildAllButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.BuildAllButton.Enabled = false;
                this.BuildAllButton.FlatAppearance.BorderSize = 0;
                this.BuildAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                this.BuildAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.BuildAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.BuildAllButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.BuildAllButton.ForeColor = System.Drawing.Color.DimGray;
                this.BuildAllButton.Location = new System.Drawing.Point(20, 114);
                this.BuildAllButton.Name = "BuildAllButton";
                this.BuildAllButton.Size = new System.Drawing.Size(150, 40);
                this.BuildAllButton.TabIndex = 91;
                this.BuildAllButton.Text = "Build All";
                this.BuildAllButton.UseVisualStyleBackColor = true;
                this.BuildAllButton.Click += new System.EventHandler(this.BuildAllButton_Click);
                this.BuildAllButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.BuildAllButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // CloseProjectButton
                // 
                this.CloseProjectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseProjectButton.BackgroundImage")));
                this.CloseProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.CloseProjectButton.Enabled = false;
                this.CloseProjectButton.FlatAppearance.BorderSize = 0;
                this.CloseProjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                this.CloseProjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.CloseProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.CloseProjectButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.CloseProjectButton.ForeColor = System.Drawing.Color.DimGray;
                this.CloseProjectButton.Location = new System.Drawing.Point(352, 114);
                this.CloseProjectButton.Name = "CloseProjectButton";
                this.CloseProjectButton.Size = new System.Drawing.Size(150, 40);
                this.CloseProjectButton.TabIndex = 90;
                this.CloseProjectButton.Text = "Close Project";
                this.CloseProjectButton.UseVisualStyleBackColor = true;
                this.CloseProjectButton.Click += new System.EventHandler(this.CloseProjectButton_Click);
                this.CloseProjectButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.CloseProjectButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // EditProjectButton
                // 
                this.EditProjectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditProjectButton.BackgroundImage")));
                this.EditProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.EditProjectButton.Enabled = false;
                this.EditProjectButton.FlatAppearance.BorderSize = 0;
                this.EditProjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                this.EditProjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.EditProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.EditProjectButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.EditProjectButton.ForeColor = System.Drawing.Color.DimGray;
                this.EditProjectButton.Location = new System.Drawing.Point(352, 57);
                this.EditProjectButton.Name = "EditProjectButton";
                this.EditProjectButton.Size = new System.Drawing.Size(150, 40);
                this.EditProjectButton.TabIndex = 89;
                this.EditProjectButton.Text = "Edit Project";
                this.EditProjectButton.UseVisualStyleBackColor = true;
                this.EditProjectButton.Click += new System.EventHandler(this.EditProjectButton_Click);
                this.EditProjectButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.EditProjectButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // OpenProjectButton
                // 
                this.OpenProjectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenProjectButton.BackgroundImage")));
                this.OpenProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.OpenProjectButton.FlatAppearance.BorderSize = 0;
                this.OpenProjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                this.OpenProjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.OpenProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.OpenProjectButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.OpenProjectButton.ForeColor = System.Drawing.Color.LemonChiffon;
                this.OpenProjectButton.Location = new System.Drawing.Point(186, 57);
                this.OpenProjectButton.Name = "OpenProjectButton";
                this.OpenProjectButton.Size = new System.Drawing.Size(150, 40);
                this.OpenProjectButton.TabIndex = 88;
                this.OpenProjectButton.Text = "Open Project";
                this.OpenProjectButton.UseVisualStyleBackColor = true;
                this.OpenProjectButton.Click += new System.EventHandler(this.OpenProjectButton_Click);
                this.OpenProjectButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.OpenProjectButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // NewProjectButton
                // 
                this.NewProjectButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
                this.NewProjectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.NewProjectButton.FlatAppearance.BorderSize = 0;
                this.NewProjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                this.NewProjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.NewProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.NewProjectButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.NewProjectButton.ForeColor = System.Drawing.Color.LemonChiffon;
                this.NewProjectButton.Location = new System.Drawing.Point(20, 57);
                this.NewProjectButton.Name = "NewProjectButton";
                this.NewProjectButton.Size = new System.Drawing.Size(150, 40);
                this.NewProjectButton.TabIndex = 87;
                this.NewProjectButton.Text = "New Project";
                this.NewProjectButton.UseVisualStyleBackColor = true;
                this.NewProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
                this.NewProjectButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.NewProjectButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // CurrentProjectLabel
                // 
                this.CurrentProjectLabel.AutoSize = true;
                this.CurrentProjectLabel.BackColor = System.Drawing.Color.Transparent;
                this.CurrentProjectLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.CurrentProjectLabel.ForeColor = System.Drawing.Color.DimGray;
                this.CurrentProjectLabel.Location = new System.Drawing.Point(94, 20);
                this.CurrentProjectLabel.Name = "CurrentProjectLabel";
                this.CurrentProjectLabel.Size = new System.Drawing.Size(169, 18);
                this.CurrentProjectLabel.TabIndex = 71;
                this.CurrentProjectLabel.Text = "No Project Selected";
                this.CurrentProjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // ProjectLabel
                // 
                this.ProjectLabel.AutoSize = true;
                this.ProjectLabel.BackColor = System.Drawing.Color.Transparent;
                this.ProjectLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ProjectLabel.ForeColor = System.Drawing.Color.LemonChiffon;
                this.ProjectLabel.Location = new System.Drawing.Point(21, 19);
                this.ProjectLabel.Name = "ProjectLabel";
                this.ProjectLabel.Size = new System.Drawing.Size(78, 18);
                this.ProjectLabel.TabIndex = 70;
                this.ProjectLabel.Text = "Project:";
                this.ProjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // StatusListBox
                // 
                this.StatusListBox.AutoArrange = false;
                this.StatusListBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.StatusListBox.FullRowSelect = true;
                this.StatusListBox.Location = new System.Drawing.Point(20, 170);
                this.StatusListBox.Name = "StatusListBox";
                this.StatusListBox.Size = new System.Drawing.Size(482, 440);
                this.StatusListBox.SmallImageList = this.Images;
                this.StatusListBox.TabIndex = 56;
                this.StatusListBox.UseCompatibleStateImageBehavior = false;
                this.StatusListBox.View = System.Windows.Forms.View.List;
                this.StatusListBox.DoubleClick += new System.EventHandler(this.StatusListBox_DoubleClick);
                // 
                // RightContainer
                // 
                this.RightContainer.Controls.Add(this.BottomPanel);
                this.RightContainer.Controls.Add(this.TopPanel);
                this.RightContainer.Controls.Add(this.RightPanel);
                this.RightContainer.Dock = System.Windows.Forms.DockStyle.Right;
                this.RightContainer.Location = new System.Drawing.Point(520, 0);
                this.RightContainer.Name = "RightContainer";
                this.RightContainer.Size = new System.Drawing.Size(380, 659);
                this.RightContainer.TabIndex = 102;
                // 
                // BottomPanel
                // 
                this.BottomPanel.Controls.Add(this.YouTubeButton);
                this.BottomPanel.Controls.Add(this.YouTubeButtonRightMarginPanel);
                this.BottomPanel.Controls.Add(this.BottomRightMarginpanel);
                this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.BottomPanel.Location = new System.Drawing.Point(0, 587);
                this.BottomPanel.Name = "BottomPanel";
                this.BottomPanel.Size = new System.Drawing.Size(380, 64);
                this.BottomPanel.TabIndex = 104;
                // 
                // BottomRightMarginpanel
                // 
                this.BottomRightMarginpanel.Dock = System.Windows.Forms.DockStyle.Right;
                this.BottomRightMarginpanel.Location = new System.Drawing.Point(372, 0);
                this.BottomRightMarginpanel.Name = "BottomRightMarginpanel";
                this.BottomRightMarginpanel.Size = new System.Drawing.Size(8, 64);
                this.BottomRightMarginpanel.TabIndex = 1;
                // 
                // TopPanel
                // 
                this.TopPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.TopPanel.Location = new System.Drawing.Point(0, 651);
                this.TopPanel.Name = "TopPanel";
                this.TopPanel.Size = new System.Drawing.Size(380, 8);
                this.TopPanel.TabIndex = 103;
                // 
                // RightPanel
                // 
                this.RightPanel.Controls.Add(this.ViewPDFButton2);
                this.RightPanel.Controls.Add(this.ViewWordButton2);
                this.RightPanel.Controls.Add(this.UsersGuideLabel);
                this.RightPanel.Controls.Add(this.ViewPDFButton);
                this.RightPanel.Controls.Add(this.ViewWordButton);
                this.RightPanel.Controls.Add(this.QuickStartLabel);
                this.RightPanel.Controls.Add(this.ClassRoomImage);
                this.RightPanel.Location = new System.Drawing.Point(18, 20);
                this.RightPanel.Name = "RightPanel";
                this.RightPanel.Size = new System.Drawing.Size(319, 419);
                this.RightPanel.TabIndex = 101;
                // 
                // ViewPDFButton2
                // 
                this.ViewPDFButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewPDFButton2.BackgroundImage")));
                this.ViewPDFButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ViewPDFButton2.FlatAppearance.BorderSize = 0;
                this.ViewPDFButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                this.ViewPDFButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ViewPDFButton2.Location = new System.Drawing.Point(164, 263);
                this.ViewPDFButton2.Name = "ViewPDFButton2";
                this.ViewPDFButton2.Size = new System.Drawing.Size(64, 64);
                this.ViewPDFButton2.TabIndex = 104;
                this.ViewPDFButton2.UseVisualStyleBackColor = true;
                this.ViewPDFButton2.Click += new System.EventHandler(this.ViewPDFButton2_Click);
                this.ViewPDFButton2.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.ViewPDFButton2.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // ViewWordButton2
                // 
                this.ViewWordButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewWordButton2.BackgroundImage")));
                this.ViewWordButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ViewWordButton2.FlatAppearance.BorderSize = 0;
                this.ViewWordButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                this.ViewWordButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ViewWordButton2.Location = new System.Drawing.Point(76, 263);
                this.ViewWordButton2.Name = "ViewWordButton2";
                this.ViewWordButton2.Size = new System.Drawing.Size(64, 64);
                this.ViewWordButton2.TabIndex = 103;
                this.ViewWordButton2.UseVisualStyleBackColor = true;
                this.ViewWordButton2.Click += new System.EventHandler(this.ViewWordButton2_Click);
                this.ViewWordButton2.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.ViewWordButton2.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // UsersGuideLabel
                // 
                this.UsersGuideLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UsersGuideLabel.ForeColor = System.Drawing.Color.LemonChiffon;
                this.UsersGuideLabel.Location = new System.Drawing.Point(34, 335);
                this.UsersGuideLabel.Name = "UsersGuideLabel";
                this.UsersGuideLabel.Size = new System.Drawing.Size(236, 17);
                this.UsersGuideLabel.TabIndex = 105;
                this.UsersGuideLabel.Text = "DataTier.Net User\'s Guide";
                this.UsersGuideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // ViewPDFButton
                // 
                this.ViewPDFButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ViewPDFButton.BackgroundImage")));
                this.ViewPDFButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ViewPDFButton.FlatAppearance.BorderSize = 0;
                this.ViewPDFButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                this.ViewPDFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ViewPDFButton.Location = new System.Drawing.Point(164, 146);
                this.ViewPDFButton.Name = "ViewPDFButton";
                this.ViewPDFButton.Size = new System.Drawing.Size(64, 64);
                this.ViewPDFButton.TabIndex = 101;
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
                this.ViewWordButton.Location = new System.Drawing.Point(76, 146);
                this.ViewWordButton.Name = "ViewWordButton";
                this.ViewWordButton.Size = new System.Drawing.Size(64, 64);
                this.ViewWordButton.TabIndex = 100;
                this.ViewWordButton.UseVisualStyleBackColor = true;
                this.ViewWordButton.Click += new System.EventHandler(this.ViewWordButton_Click);
                this.ViewWordButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.ViewWordButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // QuickStartLabel
                // 
                this.QuickStartLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.QuickStartLabel.ForeColor = System.Drawing.Color.LemonChiffon;
                this.QuickStartLabel.Location = new System.Drawing.Point(34, 218);
                this.QuickStartLabel.Name = "QuickStartLabel";
                this.QuickStartLabel.Size = new System.Drawing.Size(236, 17);
                this.QuickStartLabel.TabIndex = 102;
                this.QuickStartLabel.Text = "DataTier.Net Quick Start";
                this.QuickStartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.QuickStartLabel.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.QuickStartLabel.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // ClassRoomImage
                // 
                this.ClassRoomImage.Image = ((System.Drawing.Image)(resources.GetObject("ClassRoomImage.Image")));
                this.ClassRoomImage.Location = new System.Drawing.Point(9, 9);
                this.ClassRoomImage.Name = "ClassRoomImage";
                this.ClassRoomImage.Size = new System.Drawing.Size(300, 113);
                this.ClassRoomImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.ClassRoomImage.TabIndex = 99;
                this.ClassRoomImage.TabStop = false;
                // 
                // ManageDataButton
                // 
                this.ManageDataButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
                this.ManageDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ManageDataButton.Enabled = false;
                this.ManageDataButton.FlatAppearance.BorderSize = 0;
                this.ManageDataButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                this.ManageDataButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                this.ManageDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.ManageDataButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ManageDataButton.ForeColor = System.Drawing.Color.LemonChiffon;
                this.ManageDataButton.Location = new System.Drawing.Point(186, 114);
                this.ManageDataButton.Name = "ManageDataButton";
                this.ManageDataButton.Size = new System.Drawing.Size(150, 40);
                this.ManageDataButton.TabIndex = 107;
                this.ManageDataButton.Text = "Manage Data";
                this.ManageDataButton.UseVisualStyleBackColor = true;
                this.ManageDataButton.Click += new System.EventHandler(this.ManageDataButton_Click);
                this.ManageDataButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.ManageDataButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // YouTubeButtonRightMarginPanel
                // 
                this.YouTubeButtonRightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
                this.YouTubeButtonRightMarginPanel.Location = new System.Drawing.Point(356, 0);
                this.YouTubeButtonRightMarginPanel.Name = "YouTubeButtonRightMarginPanel";
                this.YouTubeButtonRightMarginPanel.Size = new System.Drawing.Size(16, 64);
                this.YouTubeButtonRightMarginPanel.TabIndex = 67;
                // 
                // YouTubeButton
                // 
                this.YouTubeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("YouTubeButton.BackgroundImage")));
                this.YouTubeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.YouTubeButton.Dock = System.Windows.Forms.DockStyle.Right;
                this.YouTubeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.YouTubeButton.Location = new System.Drawing.Point(228, 0);
                this.YouTubeButton.Name = "YouTubeButton";
                this.YouTubeButton.Size = new System.Drawing.Size(128, 64);
                this.YouTubeButton.TabIndex = 68;
                this.ToolTipManager.SetToolTip(this.YouTubeButton, "Click here to launch your browser to watch the DataTier.Net Intro Movie");
                this.YouTubeButton.UseVisualStyleBackColor = true;
                this.YouTubeButton.Click += new System.EventHandler(this.YouTubeButton_Click);
                this.YouTubeButton.MouseEnter += new System.EventHandler(this.Button_Enter);
                this.YouTubeButton.MouseLeave += new System.EventHandler(this.Button_Leave);
                // 
                // MainForm
                // 
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackColor = System.Drawing.Color.White;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(900, 681);
                this.Controls.Add(this.MainPanel);
                this.Controls.Add(this.MainStatusStrip);
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.DoubleBuffered = true;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "MainForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "DataTier.Net";
                this.MainPanel.ResumeLayout(false);
                this.MainPanel.PerformLayout();
                this.RightContainer.ResumeLayout(false);
                this.BottomPanel.ResumeLayout(false);
                this.RightPanel.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.ClassRoomImage)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
