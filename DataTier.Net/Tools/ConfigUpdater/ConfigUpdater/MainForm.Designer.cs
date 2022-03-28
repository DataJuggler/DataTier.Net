namespace ConfigUpdater
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.Done = new DataJuggler.Win.Controls.Button();
            this.ConfigTimer = new System.Windows.Forms.Timer(this.components);
            this.AppConfigPathControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            this.ConvertButton = new DataJuggler.Win.Controls.Button();
            this.CloseTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(54, 184);
            this.Graph.MarqueeAnimationSpeed = 180;
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(692, 23);
            this.Graph.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Graph.TabIndex = 0;
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InfoLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.InfoLabel.Location = new System.Drawing.Point(50, 108);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(700, 60);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Done
            // 
            this.Done.BackColor = System.Drawing.Color.Transparent;
            this.Done.ButtonText = "Done";
            this.Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Done.ForeColor = System.Drawing.Color.LemonChiffon;
            this.Done.Location = new System.Drawing.Point(414, 238);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(118, 48);
            this.Done.TabIndex = 2;
            this.Done.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // ConfigTimer
            // 
            this.ConfigTimer.Interval = 1000;
            this.ConfigTimer.Tick += new System.EventHandler(this.ConfigTimer_Tick);
            // 
            // AppConfigPathControl
            // 
            this.AppConfigPathControl.BackColor = System.Drawing.Color.Transparent;
            this.AppConfigPathControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            this.AppConfigPathControl.ButtonColor = System.Drawing.Color.LemonChiffon;
            this.AppConfigPathControl.ButtonImage = ((System.Drawing.Image)(resources.GetObject("AppConfigPathControl.ButtonImage")));
            this.AppConfigPathControl.ButtonWidth = 48;
            this.AppConfigPathControl.DarkMode = false;
            this.AppConfigPathControl.DisabledLabelColor = System.Drawing.Color.Empty;
            this.AppConfigPathControl.Editable = true;
            this.AppConfigPathControl.EnabledLabelColor = System.Drawing.Color.Empty;
            this.AppConfigPathControl.Filter = null;
            this.AppConfigPathControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AppConfigPathControl.HideBrowseButton = false;
            this.AppConfigPathControl.LabelBottomMargin = 0;
            this.AppConfigPathControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.AppConfigPathControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AppConfigPathControl.LabelText = "App.config:";
            this.AppConfigPathControl.LabelTopMargin = 0;
            this.AppConfigPathControl.LabelWidth = 120;
            this.AppConfigPathControl.Location = new System.Drawing.Point(64, 48);
            this.AppConfigPathControl.Name = "AppConfigPathControl";
            this.AppConfigPathControl.OnTextChangedListener = null;
            this.AppConfigPathControl.OpenCallback = null;
            this.AppConfigPathControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AppConfigPathControl.SelectedPath = null;
            this.AppConfigPathControl.Size = new System.Drawing.Size(686, 32);
            this.AppConfigPathControl.StartPath = null;
            this.AppConfigPathControl.TabIndex = 3;
            this.AppConfigPathControl.TextBoxBottomMargin = 0;
            this.AppConfigPathControl.TextBoxDisabledColor = System.Drawing.Color.Empty;
            this.AppConfigPathControl.TextBoxEditableColor = System.Drawing.Color.Empty;
            this.AppConfigPathControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AppConfigPathControl.TextBoxTopMargin = 0;
            this.AppConfigPathControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ConvertButton
            // 
            this.ConvertButton.BackColor = System.Drawing.Color.Transparent;
            this.ConvertButton.ButtonText = "Convert";
            this.ConvertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConvertButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ConvertButton.Location = new System.Drawing.Point(275, 238);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(118, 48);
            this.ConvertButton.TabIndex = 4;
            this.ConvertButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // CloseTimer
            // 
            this.CloseTimer.Interval = 2000;
            this.CloseTimer.Tick += new System.EventHandler(this.CloseTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::ConfigUpdater.Properties.Resources.BlackImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 326);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.AppConfigPathControl);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.Graph);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataTier.Net Config Updater";
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressBar Graph;
        private Label InfoLabel;
        private DataJuggler.Win.Controls.Button Done;
        private System.Windows.Forms.Timer ConfigTimer;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl AppConfigPathControl;
        private DataJuggler.Win.Controls.Button ConvertButton;
        private System.Windows.Forms.Timer CloseTimer;
    }
}