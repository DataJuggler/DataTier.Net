namespace ProcedureFinder
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BrowseFolderButton = new System.Windows.Forms.Button();
            this.SelectedFolderControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CopyButton = new System.Windows.Forms.Button();
            this.ProceduresTextBox = new System.Windows.Forms.TextBox();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Linen;
            this.TopPanel.Controls.Add(this.BrowseFolderButton);
            this.TopPanel.Controls.Add(this.SelectedFolderControl);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(944, 56);
            this.TopPanel.TabIndex = 0;
            // 
            // BrowseFolderButton
            // 
            this.BrowseFolderButton.BackgroundImage = global::ProcedureFinder.Properties.Resources.DeepBlue;
            this.BrowseFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BrowseFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseFolderButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseFolderButton.Location = new System.Drawing.Point(807, 14);
            this.BrowseFolderButton.Name = "BrowseFolderButton";
            this.BrowseFolderButton.Size = new System.Drawing.Size(44, 28);
            this.BrowseFolderButton.TabIndex = 1;
            this.BrowseFolderButton.Text = "...";
            this.BrowseFolderButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BrowseFolderButton.UseVisualStyleBackColor = true;
            this.BrowseFolderButton.Click += new System.EventHandler(this.BrowseFolderButton_Click);
            // 
            // SelectedFolderControl
            // 
            this.SelectedFolderControl.BackColor = System.Drawing.Color.Transparent;
            this.SelectedFolderControl.BottomMargin = 0;
            this.SelectedFolderControl.Editable = true;
            this.SelectedFolderControl.Encrypted = false;
            this.SelectedFolderControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFolderControl.LabelBottomMargin = 0;
            this.SelectedFolderControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.SelectedFolderControl.LabelFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.SelectedFolderControl.LabelText = "Data Writers Folder:";
            this.SelectedFolderControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelectedFolderControl.LabelTopMargin = 0;
            this.SelectedFolderControl.LabelWidth = 180;
            this.SelectedFolderControl.Location = new System.Drawing.Point(73, 16);
            this.SelectedFolderControl.MultiLine = false;
            this.SelectedFolderControl.Name = "SelectedFolderControl";
            this.SelectedFolderControl.OnTextChangedListener = null;
            this.SelectedFolderControl.PasswordMode = false;
            this.SelectedFolderControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectedFolderControl.Size = new System.Drawing.Size(739, 24);
            this.SelectedFolderControl.TabIndex = 0;
            this.SelectedFolderControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SelectedFolderControl.TextBoxBottomMargin = 0;
            this.SelectedFolderControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.SelectedFolderControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.SelectedFolderControl.TextBoxFont = new System.Drawing.Font("Verdana", 10F);
            this.SelectedFolderControl.TextBoxTopMargin = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.Linen;
            this.BottomPanel.Controls.Add(this.CopyButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 545);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(944, 56);
            this.BottomPanel.TabIndex = 1;
            // 
            // CopyButton
            // 
            this.CopyButton.BackgroundImage = global::ProcedureFinder.Properties.Resources.DeepBlue;
            this.CopyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyButton.Location = new System.Drawing.Point(842, 13);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(90, 32);
            this.CopyButton.TabIndex = 0;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // ProceduresTextBox
            // 
            this.ProceduresTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProceduresTextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProceduresTextBox.Location = new System.Drawing.Point(0, 56);
            this.ProceduresTextBox.Multiline = true;
            this.ProceduresTextBox.Name = "ProceduresTextBox";
            this.ProceduresTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProceduresTextBox.Size = new System.Drawing.Size(944, 489);
            this.ProceduresTextBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.ProceduresTextBox);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(960, 640);
            this.MinimumSize = new System.Drawing.Size(960, 640);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataTier.Net Procedure Finder";
            this.TopPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button BrowseFolderButton;
        private DataJuggler.Win.Controls.LabelTextBoxControl SelectedFolderControl;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.TextBox ProceduresTextBox;
    }
}

