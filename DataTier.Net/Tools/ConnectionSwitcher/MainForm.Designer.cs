namespace ConnectionSwitcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            UpdateValueButton = new DataJuggler.Win.Controls.Button();
            ConnectionStringControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            ConnectionTypeComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            StatusLabel = new Label();
            SuspendLayout();
            // 
            // UpdateValueButton
            // 
            UpdateValueButton.BackColor = Color.Transparent;
            UpdateValueButton.ButtonText = "Update";
            UpdateValueButton.FlatStyle = FlatStyle.Flat;
            UpdateValueButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UpdateValueButton.ForeColor = Color.LemonChiffon;
            UpdateValueButton.Location = new Point(531, 294);
            UpdateValueButton.Margin = new Padding(5, 6, 5, 6);
            UpdateValueButton.Name = "UpdateValueButton";
            UpdateValueButton.Size = new Size(140, 48);
            UpdateValueButton.TabIndex = 0;
            UpdateValueButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Glass;
            UpdateValueButton.Click += UpdateValueButton_Click;
            // 
            // ConnectionStringControl
            // 
            ConnectionStringControl.BackColor = Color.Transparent;
            ConnectionStringControl.BottomMargin = 0;
            ConnectionStringControl.Editable = true;
            ConnectionStringControl.Encrypted = false;
            ConnectionStringControl.Font = new Font("Verdana", 12F, FontStyle.Bold);
            ConnectionStringControl.Inititialized = true;
            ConnectionStringControl.LabelBottomMargin = 0;
            ConnectionStringControl.LabelColor = Color.LemonChiffon;
            ConnectionStringControl.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            ConnectionStringControl.LabelText = "ConnectionString:";
            ConnectionStringControl.LabelTopMargin = 0;
            ConnectionStringControl.LabelWidth = 180;
            ConnectionStringControl.Location = new Point(5, 78);
            ConnectionStringControl.MultiLine = true;
            ConnectionStringControl.Name = "ConnectionStringControl";
            ConnectionStringControl.OnTextChangedListener = null;
            ConnectionStringControl.PasswordMode = false;
            ConnectionStringControl.ScrollBars = ScrollBars.None;
            ConnectionStringControl.Size = new Size(666, 143);
            ConnectionStringControl.TabIndex = 1;
            ConnectionStringControl.TextBoxBottomMargin = 0;
            ConnectionStringControl.TextBoxDisabledColor = Color.LightGray;
            ConnectionStringControl.TextBoxEditableColor = Color.White;
            ConnectionStringControl.TextBoxFont = new Font("Verdana", 12F);
            ConnectionStringControl.TextBoxTopMargin = 0;
            ConnectionStringControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ConnectionTypeComboBox
            // 
            ConnectionTypeComboBox.BackColor = Color.Transparent;
            ConnectionTypeComboBox.ComboBoxLeftMargin = 1;
            ConnectionTypeComboBox.ComboBoxText = "";
            ConnectionTypeComboBox.ComoboBoxFont = null;
            ConnectionTypeComboBox.Editable = true;
            ConnectionTypeComboBox.Font = new Font("Verdana", 12F);
            ConnectionTypeComboBox.HideLabel = false;
            ConnectionTypeComboBox.LabelBottomMargin = 0;
            ConnectionTypeComboBox.LabelColor = Color.LemonChiffon;
            ConnectionTypeComboBox.LabelFont = new Font("Verdana", 12F, FontStyle.Bold);
            ConnectionTypeComboBox.LabelText = "Database:";
            ConnectionTypeComboBox.LabelTopMargin = 0;
            ConnectionTypeComboBox.LabelWidth = 180;
            ConnectionTypeComboBox.List = null;
            ConnectionTypeComboBox.Location = new Point(5, 21);
            ConnectionTypeComboBox.Name = "ConnectionTypeComboBox";
            ConnectionTypeComboBox.SelectedIndex = -1;
            ConnectionTypeComboBox.SelectedIndexListener = null;
            ConnectionTypeComboBox.Size = new Size(666, 28);
            ConnectionTypeComboBox.Sorted = true;
            ConnectionTypeComboBox.Source = null;
            ConnectionTypeComboBox.TabIndex = 2;
            ConnectionTypeComboBox.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // StatusLabel
            // 
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(12, 239);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(659, 36);
            StatusLabel.TabIndex = 3;
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            ClientSize = new Size(704, 367);
            Controls.Add(StatusLabel);
            Controls.Add(ConnectionTypeComboBox);
            Controls.Add(ConnectionStringControl);
            Controls.Add(UpdateValueButton);
            Font = new Font("Calibri", 14F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DataTier.Net Connection Switcher";
            ResumeLayout(false);
        }

        #endregion

        private DataJuggler.Win.Controls.Button UpdateValueButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl ConnectionStringControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl ConnectionTypeComboBox;
        private Label StatusLabel;
    }
}
