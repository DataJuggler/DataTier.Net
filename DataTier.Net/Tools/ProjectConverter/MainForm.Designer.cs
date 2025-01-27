namespace ProjectConverter
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SourceControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            ConvertProjectButton = new DataJuggler.Win.Controls.Button();
            ConnectionNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            BackupCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            ProjectNameTextBox = new DataJuggler.Win.Controls.LabelTextBoxControl();
            ConfirmationPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            CancelConvertButton = new DataJuggler.Win.Controls.Button();
            ConfirmationLabel = new Label();
            ConfirmButton = new DataJuggler.Win.Controls.Button();
            BackupPathControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            ImageList = new ImageList(components);
            StatusListBox = new ListView();
            UpgradeButton = new DataJuggler.Win.Controls.Button();
            DotNetVersion = new DataJuggler.Win.Controls.LabelTextBoxControl();
            MoveDatabasePanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            RefreshButton = new PictureBox();
            MoveDatabaseButton = new DataJuggler.Win.Controls.Button();
            DatabaseComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            TargetConnectionControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            ConfirmationPanel.SuspendLayout();
            MoveDatabasePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RefreshButton).BeginInit();
            SuspendLayout();
            // 
            // SourceControl
            // 
            SourceControl.BackColor = Color.Transparent;
            SourceControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            SourceControl.ButtonColor = Color.LemonChiffon;
            SourceControl.ButtonImage = (Image)resources.GetObject("SourceControl.ButtonImage");
            SourceControl.ButtonWidth = 48;
            SourceControl.DarkMode = false;
            SourceControl.DisabledLabelColor = Color.Empty;
            SourceControl.Editable = true;
            SourceControl.EnabledLabelColor = Color.Empty;
            SourceControl.Filter = null;
            SourceControl.Font = new Font("Verdana", 12F);
            SourceControl.HideBrowseButton = false;
            SourceControl.LabelBottomMargin = 0;
            SourceControl.LabelColor = Color.LemonChiffon;
            SourceControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            SourceControl.LabelText = "Source Solution:";
            SourceControl.LabelTopMargin = 0;
            SourceControl.LabelWidth = 180;
            SourceControl.Location = new Point(23, 27);
            SourceControl.Name = "SourceControl";
            SourceControl.OnTextChangedListener = null;
            SourceControl.OpenCallback = null;
            SourceControl.ScrollBars = ScrollBars.None;
            SourceControl.SelectedPath = null;
            SourceControl.Size = new Size(1087, 32);
            SourceControl.StartPath = null;
            SourceControl.TabIndex = 0;
            SourceControl.TextBoxBottomMargin = 0;
            SourceControl.TextBoxDisabledColor = Color.Empty;
            SourceControl.TextBoxEditableColor = Color.Empty;
            SourceControl.TextBoxFont = new Font("Verdana", 12F);
            SourceControl.TextBoxTopMargin = 0;
            SourceControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ConvertProjectButton
            // 
            ConvertProjectButton.BackColor = Color.Transparent;
            ConvertProjectButton.ButtonText = "Convert / Fix";
            ConvertProjectButton.FlatStyle = FlatStyle.Flat;
            ConvertProjectButton.ForeColor = Color.LemonChiffon;
            ConvertProjectButton.Location = new Point(977, 219);
            ConvertProjectButton.Margin = new Padding(4, 5, 4, 5);
            ConvertProjectButton.Name = "ConvertProjectButton";
            ConvertProjectButton.Size = new Size(133, 46);
            ConvertProjectButton.TabIndex = 1;
            ConvertProjectButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            ConvertProjectButton.Click += ConvertProjectButton_Click;
            // 
            // ConnectionNameControl
            // 
            ConnectionNameControl.BackColor = Color.Transparent;
            ConnectionNameControl.BottomMargin = 0;
            ConnectionNameControl.Editable = true;
            ConnectionNameControl.Encrypted = false;
            ConnectionNameControl.Font = new Font("Verdana", 12F, FontStyle.Bold);
            ConnectionNameControl.Inititialized = true;
            ConnectionNameControl.LabelBottomMargin = 0;
            ConnectionNameControl.LabelColor = Color.LemonChiffon;
            ConnectionNameControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            ConnectionNameControl.LabelText = "Connection Name:";
            ConnectionNameControl.LabelTopMargin = 0;
            ConnectionNameControl.LabelWidth = 180;
            ConnectionNameControl.Location = new Point(23, 76);
            ConnectionNameControl.MultiLine = false;
            ConnectionNameControl.Name = "ConnectionNameControl";
            ConnectionNameControl.OnTextChangedListener = null;
            ConnectionNameControl.PasswordMode = false;
            ConnectionNameControl.ScrollBars = ScrollBars.None;
            ConnectionNameControl.Size = new Size(393, 32);
            ConnectionNameControl.TabIndex = 2;
            ConnectionNameControl.TextBoxBottomMargin = 0;
            ConnectionNameControl.TextBoxDisabledColor = Color.LightGray;
            ConnectionNameControl.TextBoxEditableColor = Color.White;
            ConnectionNameControl.TextBoxFont = new Font("Verdana", 12F);
            ConnectionNameControl.TextBoxTopMargin = 0;
            ConnectionNameControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // BackupCheckBox
            // 
            BackupCheckBox.BackColor = Color.Transparent;
            BackupCheckBox.CheckBoxHorizontalOffSet = 0;
            BackupCheckBox.CheckBoxVerticalOffSet = 3;
            BackupCheckBox.CheckChangedListener = null;
            BackupCheckBox.Checked = true;
            BackupCheckBox.Editable = true;
            BackupCheckBox.Font = new Font("Verdana", 12F);
            BackupCheckBox.LabelColor = Color.LemonChiffon;
            BackupCheckBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            BackupCheckBox.LabelText = "Backup Project:";
            BackupCheckBox.LabelWidth = 180;
            BackupCheckBox.Location = new Point(23, 116);
            BackupCheckBox.Name = "BackupCheckBox";
            BackupCheckBox.Size = new Size(209, 28);
            BackupCheckBox.TabIndex = 3;
            BackupCheckBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.BackColor = Color.Transparent;
            ProjectNameTextBox.BottomMargin = 0;
            ProjectNameTextBox.Editable = false;
            ProjectNameTextBox.Encrypted = false;
            ProjectNameTextBox.Font = new Font("Verdana", 12F, FontStyle.Bold);
            ProjectNameTextBox.Inititialized = true;
            ProjectNameTextBox.LabelBottomMargin = 0;
            ProjectNameTextBox.LabelColor = Color.LemonChiffon;
            ProjectNameTextBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            ProjectNameTextBox.LabelText = "Project Name:";
            ProjectNameTextBox.LabelTopMargin = 0;
            ProjectNameTextBox.LabelWidth = 180;
            ProjectNameTextBox.Location = new Point(772, 76);
            ProjectNameTextBox.MultiLine = false;
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.OnTextChangedListener = null;
            ProjectNameTextBox.PasswordMode = false;
            ProjectNameTextBox.ScrollBars = ScrollBars.None;
            ProjectNameTextBox.Size = new Size(338, 32);
            ProjectNameTextBox.TabIndex = 5;
            ProjectNameTextBox.TextBoxBottomMargin = 0;
            ProjectNameTextBox.TextBoxDisabledColor = Color.LightGray;
            ProjectNameTextBox.TextBoxEditableColor = Color.White;
            ProjectNameTextBox.TextBoxFont = new Font("Verdana", 12F);
            ProjectNameTextBox.TextBoxTopMargin = 0;
            ProjectNameTextBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ConfirmationPanel
            // 
            ConfirmationPanel.Controls.Add(CancelConvertButton);
            ConfirmationPanel.Controls.Add(ConfirmationLabel);
            ConfirmationPanel.Controls.Add(ConfirmButton);
            ConfirmationPanel.Location = new Point(677, 280);
            ConfirmationPanel.Name = "ConfirmationPanel";
            ConfirmationPanel.Size = new Size(433, 175);
            ConfirmationPanel.TabIndex = 9;
            ConfirmationPanel.Visible = false;
            // 
            // CancelConvertButton
            // 
            CancelConvertButton.BackColor = Color.Transparent;
            CancelConvertButton.ButtonText = "Cancel";
            CancelConvertButton.FlatStyle = FlatStyle.Flat;
            CancelConvertButton.ForeColor = Color.LemonChiffon;
            CancelConvertButton.Location = new Point(234, 105);
            CancelConvertButton.Margin = new Padding(4, 5, 4, 5);
            CancelConvertButton.Name = "CancelConvertButton";
            CancelConvertButton.Size = new Size(110, 46);
            CancelConvertButton.TabIndex = 11;
            CancelConvertButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            CancelConvertButton.Click += CancelConvertButton_Click;
            // 
            // ConfirmationLabel
            // 
            ConfirmationLabel.Font = new Font("Calibri", 20F);
            ConfirmationLabel.ForeColor = Color.LemonChiffon;
            ConfirmationLabel.Location = new Point(17, 32);
            ConfirmationLabel.Name = "ConfirmationLabel";
            ConfirmationLabel.Size = new Size(409, 52);
            ConfirmationLabel.TabIndex = 10;
            ConfirmationLabel.Text = "Confirm Project Name?";
            ConfirmationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ConfirmButton
            // 
            ConfirmButton.BackColor = Color.Transparent;
            ConfirmButton.ButtonText = "Confirm";
            ConfirmButton.FlatStyle = FlatStyle.Flat;
            ConfirmButton.ForeColor = Color.LemonChiffon;
            ConfirmButton.Location = new Point(102, 105);
            ConfirmButton.Margin = new Padding(4, 5, 4, 5);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(110, 46);
            ConfirmButton.TabIndex = 9;
            ConfirmButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // BackupPathControl
            // 
            BackupPathControl.BackColor = Color.Transparent;
            BackupPathControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.Folder;
            BackupPathControl.ButtonColor = Color.LemonChiffon;
            BackupPathControl.ButtonImage = (Image)resources.GetObject("BackupPathControl.ButtonImage");
            BackupPathControl.ButtonWidth = 48;
            BackupPathControl.DarkMode = false;
            BackupPathControl.DisabledLabelColor = Color.Empty;
            BackupPathControl.Editable = true;
            BackupPathControl.EnabledLabelColor = Color.Empty;
            BackupPathControl.Filter = null;
            BackupPathControl.Font = new Font("Verdana", 12F);
            BackupPathControl.HideBrowseButton = false;
            BackupPathControl.LabelBottomMargin = 0;
            BackupPathControl.LabelColor = Color.LemonChiffon;
            BackupPathControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            BackupPathControl.LabelText = "Backup Path:";
            BackupPathControl.LabelTopMargin = 0;
            BackupPathControl.LabelWidth = 180;
            BackupPathControl.Location = new Point(23, 154);
            BackupPathControl.Name = "BackupPathControl";
            BackupPathControl.OnTextChangedListener = null;
            BackupPathControl.OpenCallback = null;
            BackupPathControl.ScrollBars = ScrollBars.None;
            BackupPathControl.SelectedPath = null;
            BackupPathControl.Size = new Size(1087, 32);
            BackupPathControl.StartPath = null;
            BackupPathControl.TabIndex = 10;
            BackupPathControl.TextBoxBottomMargin = 0;
            BackupPathControl.TextBoxDisabledColor = Color.Empty;
            BackupPathControl.TextBoxEditableColor = Color.Empty;
            BackupPathControl.TextBoxFont = new Font("Verdana", 12F);
            BackupPathControl.TextBoxTopMargin = 0;
            BackupPathControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ImageList
            // 
            ImageList.ColorDepth = ColorDepth.Depth32Bit;
            ImageList.ImageStream = (ImageListStreamer)resources.GetObject("ImageList.ImageStream");
            ImageList.TransparentColor = Color.Transparent;
            ImageList.Images.SetKeyName(0, "Success.png");
            ImageList.Images.SetKeyName(1, "Failure.png");
            // 
            // StatusListBox
            // 
            StatusListBox.Location = new Point(23, 219);
            StatusListBox.Name = "StatusListBox";
            StatusListBox.Size = new Size(613, 451);
            StatusListBox.SmallImageList = ImageList;
            StatusListBox.TabIndex = 11;
            StatusListBox.UseCompatibleStateImageBehavior = false;
            StatusListBox.View = View.List;
            // 
            // UpgradeButton
            // 
            UpgradeButton.BackColor = Color.Transparent;
            UpgradeButton.ButtonText = "Upgrade To .NET 9";
            UpgradeButton.FlatStyle = FlatStyle.Flat;
            UpgradeButton.ForeColor = Color.LemonChiffon;
            UpgradeButton.Location = new Point(677, 219);
            UpgradeButton.Margin = new Padding(4, 5, 4, 5);
            UpgradeButton.Name = "UpgradeButton";
            UpgradeButton.Size = new Size(200, 46);
            UpgradeButton.TabIndex = 12;
            UpgradeButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            // 
            // DotNetVersion
            // 
            DotNetVersion.BackColor = Color.Transparent;
            DotNetVersion.BottomMargin = 0;
            DotNetVersion.Editable = false;
            DotNetVersion.Encrypted = false;
            DotNetVersion.Font = new Font("Verdana", 12F, FontStyle.Bold);
            DotNetVersion.Inititialized = true;
            DotNetVersion.LabelBottomMargin = 0;
            DotNetVersion.LabelColor = Color.LemonChiffon;
            DotNetVersion.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            DotNetVersion.LabelText = ".NET Version:";
            DotNetVersion.LabelTopMargin = 0;
            DotNetVersion.LabelWidth = 180;
            DotNetVersion.Location = new Point(425, 76);
            DotNetVersion.MultiLine = false;
            DotNetVersion.Name = "DotNetVersion";
            DotNetVersion.OnTextChangedListener = null;
            DotNetVersion.PasswordMode = false;
            DotNetVersion.ScrollBars = ScrollBars.None;
            DotNetVersion.Size = new Size(338, 32);
            DotNetVersion.TabIndex = 13;
            DotNetVersion.TextBoxBottomMargin = 0;
            DotNetVersion.TextBoxDisabledColor = Color.LightGray;
            DotNetVersion.TextBoxEditableColor = Color.White;
            DotNetVersion.TextBoxFont = new Font("Verdana", 12F);
            DotNetVersion.TextBoxTopMargin = 0;
            DotNetVersion.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // MoveDatabasePanel
            // 
            MoveDatabasePanel.Controls.Add(RefreshButton);
            MoveDatabasePanel.Controls.Add(MoveDatabaseButton);
            MoveDatabasePanel.Controls.Add(DatabaseComboBox);
            MoveDatabasePanel.Controls.Add(TargetConnectionControl);
            MoveDatabasePanel.Location = new Point(677, 484);
            MoveDatabasePanel.Name = "MoveDatabasePanel";
            MoveDatabasePanel.Size = new Size(452, 175);
            MoveDatabasePanel.TabIndex = 18;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.Transparent;
            RefreshButton.BackgroundImage = Properties.Resources.RefreshButton4;
            RefreshButton.BackgroundImageLayout = ImageLayout.Stretch;
            RefreshButton.Location = new Point(392, 52);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(56, 56);
            RefreshButton.TabIndex = 21;
            RefreshButton.TabStop = false;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // MoveDatabaseButton
            // 
            MoveDatabaseButton.BackColor = Color.Transparent;
            MoveDatabaseButton.ButtonText = "Move Database";
            MoveDatabaseButton.FlatStyle = FlatStyle.Flat;
            MoveDatabaseButton.ForeColor = Color.LemonChiffon;
            MoveDatabaseButton.Location = new Point(225, 115);
            MoveDatabaseButton.Margin = new Padding(4, 5, 4, 5);
            MoveDatabaseButton.Name = "MoveDatabaseButton";
            MoveDatabaseButton.Size = new Size(163, 46);
            MoveDatabaseButton.TabIndex = 20;
            MoveDatabaseButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            MoveDatabaseButton.Click += MoveDatabaseButton_Click;
            // 
            // DatabaseComboBox
            // 
            DatabaseComboBox.BackColor = Color.Transparent;
            DatabaseComboBox.ComboBoxLeftMargin = 1;
            DatabaseComboBox.ComboBoxText = "";
            DatabaseComboBox.ComoboBoxFont = null;
            DatabaseComboBox.Editable = true;
            DatabaseComboBox.Font = new Font("Verdana", 12F);
            DatabaseComboBox.HideLabel = false;
            DatabaseComboBox.LabelBottomMargin = 0;
            DatabaseComboBox.LabelColor = Color.LemonChiffon;
            DatabaseComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            DatabaseComboBox.LabelText = "Database:";
            DatabaseComboBox.LabelTopMargin = 0;
            DatabaseComboBox.LabelWidth = 188;
            DatabaseComboBox.List = null;
            DatabaseComboBox.Location = new Point(17, 66);
            DatabaseComboBox.Name = "DatabaseComboBox";
            DatabaseComboBox.SelectedIndex = -1;
            DatabaseComboBox.SelectedIndexListener = null;
            DatabaseComboBox.Size = new Size(401, 28);
            DatabaseComboBox.Sorted = true;
            DatabaseComboBox.Source = null;
            DatabaseComboBox.TabIndex = 19;
            DatabaseComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // TargetConnectionControl
            // 
            TargetConnectionControl.BackColor = Color.Transparent;
            TargetConnectionControl.BottomMargin = 0;
            TargetConnectionControl.Editable = true;
            TargetConnectionControl.Encrypted = false;
            TargetConnectionControl.Font = new Font("Verdana", 12F, FontStyle.Bold);
            TargetConnectionControl.Inititialized = true;
            TargetConnectionControl.LabelBottomMargin = 0;
            TargetConnectionControl.LabelColor = Color.LemonChiffon;
            TargetConnectionControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            TargetConnectionControl.LabelText = "Target Connection:";
            TargetConnectionControl.LabelTopMargin = 0;
            TargetConnectionControl.LabelWidth = 188;
            TargetConnectionControl.Location = new Point(17, 13);
            TargetConnectionControl.MultiLine = false;
            TargetConnectionControl.Name = "TargetConnectionControl";
            TargetConnectionControl.OnTextChangedListener = null;
            TargetConnectionControl.PasswordMode = false;
            TargetConnectionControl.ScrollBars = ScrollBars.None;
            TargetConnectionControl.Size = new Size(369, 32);
            TargetConnectionControl.TabIndex = 18;
            TargetConnectionControl.TextBoxBottomMargin = 0;
            TargetConnectionControl.TextBoxDisabledColor = Color.LightGray;
            TargetConnectionControl.TextBoxEditableColor = Color.White;
            TargetConnectionControl.TextBoxFont = new Font("Verdana", 12F);
            TargetConnectionControl.TextBoxTopMargin = 0;
            TargetConnectionControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            ClientSize = new Size(1141, 712);
            Controls.Add(MoveDatabasePanel);
            Controls.Add(DotNetVersion);
            Controls.Add(UpgradeButton);
            Controls.Add(StatusListBox);
            Controls.Add(BackupPathControl);
            Controls.Add(ConfirmationPanel);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(BackupCheckBox);
            Controls.Add(ConnectionNameControl);
            Controls.Add(ConvertProjectButton);
            Controls.Add(SourceControl);
            Font = new Font("Calibri", 14F);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DataTier.Net Project Converter";
            ConfirmationPanel.ResumeLayout(false);
            MoveDatabasePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RefreshButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl SourceControl;
        private DataJuggler.Win.Controls.Button ConvertProjectButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl ConnectionNameControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl BackupCheckBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl ProjectNameTextBox;
        private DataJuggler.Win.Controls.Objects.PanelExtender ConfirmationPanel;
        private DataJuggler.Win.Controls.Button CancelConvertButton;
        private Label ConfirmationLabel;
        private DataJuggler.Win.Controls.Button ConfirmButton;
        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl BackupPathControl;
        private ImageList ImageList;
        private ListView StatusListBox;
        private DataJuggler.Win.Controls.Button UpgradeButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl DotNetVersion;
        private DataJuggler.Win.Controls.Objects.PanelExtender MoveDatabasePanel;
        private PictureBox RefreshButton;
        private DataJuggler.Win.Controls.Button MoveDatabaseButton;
        private DataJuggler.Win.Controls.LabelComboBoxControl DatabaseComboBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl TargetConnectionControl;
    }
}
