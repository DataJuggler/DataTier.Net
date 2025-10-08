namespace DataJuggler.Win.Controls
{
    partial class LabelTextBoxBrowserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelTextBoxControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelTextBoxControl
            // 
            this.LabelTextBoxControl.BackColor = System.Drawing.Color.Transparent;
            this.LabelTextBoxControl.BottomMargin = 0;
            this.LabelTextBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTextBoxControl.Editable = true;
            this.LabelTextBoxControl.Encrypted = false;
            this.LabelTextBoxControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTextBoxControl.LabelBottomMargin = 0;
            this.LabelTextBoxControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.LabelTextBoxControl.LabelFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.LabelTextBoxControl.LabelText = "[LabelText]:";
            this.LabelTextBoxControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelTextBoxControl.LabelTopMargin = 0;
            this.LabelTextBoxControl.LabelWidth = 160;
            this.LabelTextBoxControl.Location = new System.Drawing.Point(0, 0);
            this.LabelTextBoxControl.MultiLine = false;
            this.LabelTextBoxControl.Name = "LabelTextBoxControl";
            this.LabelTextBoxControl.OnTextChangedListener = null;
            this.LabelTextBoxControl.PasswordMode = false;
            this.LabelTextBoxControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LabelTextBoxControl.Size = new System.Drawing.Size(400, 32);
            this.LabelTextBoxControl.TabIndex = 0;
            this.LabelTextBoxControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.LabelTextBoxControl.TextBoxBottomMargin = 0;
            this.LabelTextBoxControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.LabelTextBoxControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.LabelTextBoxControl.TextBoxFont = new System.Drawing.Font("Verdana", 14.25F);
            this.LabelTextBoxControl.TextBoxTopMargin = 0;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.BackgroundImage = global::DataJuggler.Win.Controls.Properties.Resources.DarkBlueButton;
            this.BrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BrowseButton.Location = new System.Drawing.Point(352, 0);
            this.BrowseButton.MaximumSize = new System.Drawing.Size(48, 32);
            this.BrowseButton.MinimumSize = new System.Drawing.Size(48, 32);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(48, 32);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            this.BrowseButton.MouseEnter += new System.EventHandler(this.BrowseButton_MouseEnter);
            this.BrowseButton.MouseLeave += new System.EventHandler(this.BrowseButton_MouseLeave);
            // 
            // LabelTextBoxBrowserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.LabelTextBoxControl);
            this.Name = "LabelTextBoxBrowserControl";
            this.Size = new System.Drawing.Size(400, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private LabelTextBoxControl LabelTextBoxControl;
        private System.Windows.Forms.Button BrowseButton;
    }
}
