
namespace DataTierClient.Controls
{
    partial class RemoveTemplatesControl
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
            this.components = new System.ComponentModel.Container();
            this.CleanUp = new System.Windows.Forms.PictureBox();
            this.RemoveTemplateButton = new System.Windows.Forms.Button();
            this.FrameworkComboBox = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.Version1RadioButton = new System.Windows.Forms.RadioButton();
            this.Version2RadioButton = new System.Windows.Forms.RadioButton();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.ManuelInstructionsLabel = new System.Windows.Forms.Label();
            this.CopyButton = new System.Windows.Forms.Button();
            this.CopyTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CleanUp)).BeginInit();
            this.SuspendLayout();
            // 
            // CleanUp
            // 
            this.CleanUp.BackColor = System.Drawing.Color.Transparent;
            this.CleanUp.BackgroundImage = global::DataTierClient.Properties.Resources.Janitor3;
            this.CleanUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CleanUp.Location = new System.Drawing.Point(0, 0);
            this.CleanUp.Name = "CleanUp";
            this.CleanUp.Size = new System.Drawing.Size(629, 533);
            this.CleanUp.TabIndex = 0;
            this.CleanUp.TabStop = false;
            // 
            // RemoveTemplateButton
            // 
            this.RemoveTemplateButton.BackColor = System.Drawing.Color.Transparent;
            this.RemoveTemplateButton.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonWideDarkGray;
            this.RemoveTemplateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveTemplateButton.Enabled = false;
            this.RemoveTemplateButton.FlatAppearance.BorderSize = 0;
            this.RemoveTemplateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RemoveTemplateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RemoveTemplateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveTemplateButton.Font = new System.Drawing.Font("Calibri", 18F);
            this.RemoveTemplateButton.Location = new System.Drawing.Point(635, 171);
            this.RemoveTemplateButton.Name = "RemoveTemplateButton";
            this.RemoveTemplateButton.Size = new System.Drawing.Size(326, 64);
            this.RemoveTemplateButton.TabIndex = 125;
            this.RemoveTemplateButton.Text = "Remove Template";
            this.RemoveTemplateButton.UseVisualStyleBackColor = false;
            this.RemoveTemplateButton.EnabledChanged += new System.EventHandler(this.RemoveTemplateButton_EnabledChanged);
            this.RemoveTemplateButton.Click += new System.EventHandler(this.RemoveTemplateButton_Click);
            this.RemoveTemplateButton.Paint += new System.Windows.Forms.PaintEventHandler(this.RemoveTemplateButton_Paint);
            this.RemoveTemplateButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.RemoveTemplateButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // FrameworkComboBox
            // 
            this.FrameworkComboBox.BackColor = System.Drawing.Color.Transparent;
            this.FrameworkComboBox.ComboBoxLeftMargin = 1;
            this.FrameworkComboBox.ComboBoxText = "";
            this.FrameworkComboBox.ComoboBoxFont = null;
            this.FrameworkComboBox.Editable = true;
            this.FrameworkComboBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrameworkComboBox.HideLabel = false;
            this.FrameworkComboBox.LabelBottomMargin = 0;
            this.FrameworkComboBox.LabelColor = System.Drawing.Color.LemonChiffon;
            this.FrameworkComboBox.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrameworkComboBox.LabelText = "Framework:";
            this.FrameworkComboBox.LabelTopMargin = 4;
            this.FrameworkComboBox.LabelWidth = 120;
            this.FrameworkComboBox.List = null;
            this.FrameworkComboBox.Location = new System.Drawing.Point(663, 77);
            this.FrameworkComboBox.Name = "FrameworkComboBox";
            this.FrameworkComboBox.SelectedIndex = -1;
            this.FrameworkComboBox.SelectedIndexListener = null;
            this.FrameworkComboBox.Size = new System.Drawing.Size(277, 28);
            this.FrameworkComboBox.Sorted = true;
            this.FrameworkComboBox.Source = null;
            this.FrameworkComboBox.TabIndex = 1;
            // 
            // Version1RadioButton
            // 
            this.Version1RadioButton.AutoSize = true;
            this.Version1RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.Version1RadioButton.Font = new System.Drawing.Font("Calibri", 16F);
            this.Version1RadioButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.Version1RadioButton.Location = new System.Drawing.Point(676, 137);
            this.Version1RadioButton.Name = "Version1RadioButton";
            this.Version1RadioButton.Size = new System.Drawing.Size(100, 27);
            this.Version1RadioButton.TabIndex = 126;
            this.Version1RadioButton.TabStop = true;
            this.Version1RadioButton.Text = "Version 1";
            this.Version1RadioButton.UseVisualStyleBackColor = false;
            this.Version1RadioButton.Visible = false;
            // 
            // Version2RadioButton
            // 
            this.Version2RadioButton.AutoSize = true;
            this.Version2RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.Version2RadioButton.Font = new System.Drawing.Font("Calibri", 16F);
            this.Version2RadioButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.Version2RadioButton.Location = new System.Drawing.Point(810, 137);
            this.Version2RadioButton.Name = "Version2RadioButton";
            this.Version2RadioButton.Size = new System.Drawing.Size(100, 27);
            this.Version2RadioButton.TabIndex = 127;
            this.Version2RadioButton.TabStop = true;
            this.Version2RadioButton.Text = "Version 2";
            this.Version2RadioButton.UseVisualStyleBackColor = false;
            this.Version2RadioButton.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Font = new System.Drawing.Font("Calibri", 16F);
            this.StatusLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.StatusLabel.Location = new System.Drawing.Point(658, 250);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(282, 91);
            this.StatusLabel.TabIndex = 128;
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.Transparent;
            this.DoneButton.BackgroundImage = global::DataTierClient.Properties.Resources.WoodButtonWideRed;
            this.DoneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoneButton.FlatAppearance.BorderSize = 0;
            this.DoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.DoneButton.Location = new System.Drawing.Point(773, 469);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(167, 64);
            this.DoneButton.TabIndex = 129;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 18F);
            this.InfoLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.InfoLabel.Location = new System.Drawing.Point(13, 546);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(884, 35);
            this.InfoLabel.TabIndex = 130;
            this.InfoLabel.Text = "Tip: You can view all the installed packages on your machine with: dotnet new --l" +
    "ist\r\n";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManuelInstructionsLabel
            // 
            this.ManuelInstructionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.ManuelInstructionsLabel.Font = new System.Drawing.Font("Calibri", 18F);
            this.ManuelInstructionsLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ManuelInstructionsLabel.Location = new System.Drawing.Point(13, 603);
            this.ManuelInstructionsLabel.Name = "ManuelInstructionsLabel";
            this.ManuelInstructionsLabel.Size = new System.Drawing.Size(859, 35);
            this.ManuelInstructionsLabel.TabIndex = 131;
            this.ManuelInstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CopyButton
            // 
            this.CopyButton.BackColor = System.Drawing.Color.Transparent;
            this.CopyButton.BackgroundImage = global::DataTierClient.Properties.Resources.ClipBoard;
            this.CopyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyButton.FlatAppearance.BorderSize = 0;
            this.CopyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CopyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyButton.ForeColor = System.Drawing.Color.GhostWhite;
            this.CopyButton.Location = new System.Drawing.Point(892, 588);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(48, 64);
            this.CopyButton.TabIndex = 132;
            this.CopyButton.UseVisualStyleBackColor = false;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            this.CopyButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CopyButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // CopyTimer
            // 
            this.CopyTimer.Interval = 3000;
            this.CopyTimer.Tick += new System.EventHandler(this.CopyTimer_Tick);
            // 
            // RemoveTemplatesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataTierClient.Properties.Resources.BlackImageDarker;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.ManuelInstructionsLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.RemoveTemplateButton);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.Version2RadioButton);
            this.Controls.Add(this.Version1RadioButton);
            this.Controls.Add(this.FrameworkComboBox);
            this.Controls.Add(this.CleanUp);
            this.DoubleBuffered = true;
            this.Name = "RemoveTemplatesControl";
            this.Size = new System.Drawing.Size(980, 668);
            ((System.ComponentModel.ISupportInitialize)(this.CleanUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CleanUp;
        private DataJuggler.Win.Controls.LabelComboBoxControl FrameworkComboBox;
        private System.Windows.Forms.Button RemoveTemplateButton;
        private System.Windows.Forms.RadioButton Version1RadioButton;
        private System.Windows.Forms.RadioButton Version2RadioButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label ManuelInstructionsLabel;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Timer CopyTimer;
    }
}

