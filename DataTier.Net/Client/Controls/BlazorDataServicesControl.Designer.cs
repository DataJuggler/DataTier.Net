

#region using statements

using DataJuggler.Core.UltimateHelper;

#endregion

namespace DataTierClient.Controls
{

    #region class BlazorDataServicesControl
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class BlazorDataServicesControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox Logo;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl ServicesFolderControl;
        private DataJuggler.Win.Controls.Objects.PanelExtender RightMarginPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender BottomMarginPanel;
        private DataJuggler.Win.Controls.SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.LinkLabel InstallBlazorServicesButton;
        private System.Windows.Forms.LinkLabel CreateBlazorServicesButton;
        private System.Windows.Forms.ProgressBar Graph;
        private System.Windows.Forms.LinkLabel UninstallBlazorServicesButton;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlazorDataServicesControl));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.ServicesFolderControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            this.RightMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.BottomMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.SaveCancelControl = new DataJuggler.Win.Controls.SaveCancelControl();
            this.InstallBlazorServicesButton = new System.Windows.Forms.LinkLabel();
            this.CreateBlazorServicesButton = new System.Windows.Forms.LinkLabel();
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.UninstallBlazorServicesButton = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Logo.BackgroundImage")));
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.Location = new System.Drawing.Point(23, 16);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(282, 42);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // ServicesFolderControl
            // 
            this.ServicesFolderControl.BackColor = System.Drawing.Color.Transparent;
            this.ServicesFolderControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.Folder;
            this.ServicesFolderControl.ButtonImage = ((System.Drawing.Image)(resources.GetObject("ServicesFolderControl.ButtonImage")));
            this.ServicesFolderControl.ButtonWidth = 48;
            this.ServicesFolderControl.DisabledLabelColor = System.Drawing.Color.LightGray;
            this.ServicesFolderControl.Editable = true;
            this.ServicesFolderControl.EnabledLabelColor = System.Drawing.Color.LemonChiffon;
            this.ServicesFolderControl.Filter = null;
            this.ServicesFolderControl.Font = new System.Drawing.Font("Verdana", 12F);
            this.ServicesFolderControl.HideBrowseButton = false;
            this.ServicesFolderControl.LabelBottomMargin = 0;
            this.ServicesFolderControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.ServicesFolderControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.ServicesFolderControl.LabelText = "Services Folder:";
            this.ServicesFolderControl.LabelTopMargin = 0;
            this.ServicesFolderControl.LabelWidth = 160;
            this.ServicesFolderControl.Location = new System.Drawing.Point(23, 80);
            this.ServicesFolderControl.Name = "ServicesFolderControl";
            this.ServicesFolderControl.OnTextChangedListener = null;
            this.ServicesFolderControl.OpenCallback = null;
            this.ServicesFolderControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ServicesFolderControl.SelectedPath = null;
            this.ServicesFolderControl.Size = new System.Drawing.Size(656, 32);
            this.ServicesFolderControl.StartPath = null;
            this.ServicesFolderControl.TabIndex = 1;
            this.ServicesFolderControl.TextBoxBottomMargin = 0;
            this.ServicesFolderControl.TextBoxDisabledColor = System.Drawing.Color.Empty;
            this.ServicesFolderControl.TextBoxEditableColor = System.Drawing.Color.Empty;
            this.ServicesFolderControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.ServicesFolderControl.TextBoxTopMargin = 0;
            this.ServicesFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(704, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 360);
            this.RightMarginPanel.TabIndex = 3;
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(0, 352);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(704, 8);
            this.BottomMarginPanel.TabIndex = 4;
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.CancelButtonWidth = 80;
            this.SaveCancelControl.DisabledForeColor = System.Drawing.Color.DarkGray;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.DoneMode = false;
            this.SaveCancelControl.EnableSaveAndCloseButton = false;
            this.SaveCancelControl.EnableSaveButton = false;
            this.SaveCancelControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 300);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.SaveAndCloseButtonWidth = 0;
            this.SaveCancelControl.SaveButtonWidth = 80;
            this.SaveCancelControl.ShowSaveAndCloseButton = false;
            this.SaveCancelControl.ShowSaveButton = true;
            this.SaveCancelControl.Size = new System.Drawing.Size(704, 52);
            this.SaveCancelControl.TabIndex = 5;
            // 
            // InstallBlazorServicesButton
            // 
            this.InstallBlazorServicesButton.AutoSize = true;
            this.InstallBlazorServicesButton.BackColor = System.Drawing.Color.Transparent;
            this.InstallBlazorServicesButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallBlazorServicesButton.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.InstallBlazorServicesButton.LinkColor = System.Drawing.Color.LemonChiffon;
            this.InstallBlazorServicesButton.Location = new System.Drawing.Point(20, 144);
            this.InstallBlazorServicesButton.Name = "InstallBlazorServicesButton";
            this.InstallBlazorServicesButton.Size = new System.Drawing.Size(622, 18);
            this.InstallBlazorServicesButton.TabIndex = 6;
            this.InstallBlazorServicesButton.TabStop = true;
            this.InstallBlazorServicesButton.Text = "Install DataJuggler.DataTier.Net5.ItemTemplates.BlazorDataServices";
            this.InstallBlazorServicesButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InstallBlazorServicesButton_LinkClicked);
            this.InstallBlazorServicesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.InstallBlazorServicesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // CreateBlazorServicesButton
            // 
            this.CreateBlazorServicesButton.AutoSize = true;
            this.CreateBlazorServicesButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateBlazorServicesButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBlazorServicesButton.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.CreateBlazorServicesButton.LinkColor = System.Drawing.Color.LemonChiffon;
            this.CreateBlazorServicesButton.Location = new System.Drawing.Point(20, 224);
            this.CreateBlazorServicesButton.Name = "CreateBlazorServicesButton";
            this.CreateBlazorServicesButton.Size = new System.Drawing.Size(207, 18);
            this.CreateBlazorServicesButton.TabIndex = 7;
            this.CreateBlazorServicesButton.TabStop = true;
            this.CreateBlazorServicesButton.Text = "Create Blazor Services";
            this.CreateBlazorServicesButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateBlazorServicesButton_LinkClicked);
            this.CreateBlazorServicesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CreateBlazorServicesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(23, 252);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(656, 20);
            this.Graph.TabIndex = 8;
            this.Graph.Visible = false;
            // 
            // UninstallBlazorServicesButton
            // 
            this.UninstallBlazorServicesButton.AutoSize = true;
            this.UninstallBlazorServicesButton.BackColor = System.Drawing.Color.Transparent;
            this.UninstallBlazorServicesButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UninstallBlazorServicesButton.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.UninstallBlazorServicesButton.LinkColor = System.Drawing.Color.LemonChiffon;
            this.UninstallBlazorServicesButton.Location = new System.Drawing.Point(20, 184);
            this.UninstallBlazorServicesButton.Name = "UninstallBlazorServicesButton";
            this.UninstallBlazorServicesButton.Size = new System.Drawing.Size(642, 18);
            this.UninstallBlazorServicesButton.TabIndex = 9;
            this.UninstallBlazorServicesButton.TabStop = true;
            this.UninstallBlazorServicesButton.Text = "Uninstall DataJuggler.DataTier.Net5.ItemTemplates.BlazorDataServices";
            this.UninstallBlazorServicesButton.Click += new System.EventHandler(this.UninstallBlazorServicesButton_Click);
            this.UninstallBlazorServicesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.UninstallBlazorServicesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // BlazorDataServicesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataTierClient.Properties.Resources.Deep_Black;
            this.Controls.Add(this.UninstallBlazorServicesButton);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.CreateBlazorServicesButton);
            this.Controls.Add(this.InstallBlazorServicesButton);
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.ServicesFolderControl);
            this.Controls.Add(this.Logo);
            this.DoubleBuffered = true;
            this.Name = "BlazorDataServicesControl";
            this.Size = new System.Drawing.Size(720, 360);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
