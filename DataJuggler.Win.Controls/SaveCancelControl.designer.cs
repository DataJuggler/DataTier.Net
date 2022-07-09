namespace DataJuggler.Win.Controls
{
    partial class SaveCancelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveCancelControl));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.CancelSave = new System.Windows.Forms.Button();
            this.FillerPanel = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FillerPanel2 = new System.Windows.Forms.Panel();
            this.SaveAndCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(494, 8);
            this.TopPanel.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 44);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(494, 8);
            this.BottomPanel.TabIndex = 1;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(486, 8);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(8, 36);
            this.RightMarginPanel.TabIndex = 2;
            // 
            // CancelSave
            // 
            this.CancelSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelSave.BackgroundImage")));
            this.CancelSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.CancelSave.FlatAppearance.BorderSize = 0;
            this.CancelSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CancelSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CancelSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelSave.Location = new System.Drawing.Point(402, 8);
            this.CancelSave.Name = "CancelSave";
            this.CancelSave.Size = new System.Drawing.Size(84, 36);
            this.CancelSave.TabIndex = 3;
            this.CancelSave.Text = "Cancel";
            this.CancelSave.UseVisualStyleBackColor = true;
            this.CancelSave.Click += new System.EventHandler(this.CancelSave_Click);
            this.CancelSave.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.CancelSave.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // FillerPanel
            // 
            this.FillerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.FillerPanel.Location = new System.Drawing.Point(394, 8);
            this.FillerPanel.Name = "FillerPanel";
            this.FillerPanel.Size = new System.Drawing.Size(8, 36);
            this.FillerPanel.TabIndex = 4;
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImage = global::DataJuggler.Win.Controls.Properties.Resources.WoodButtonWidth640Disabled;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveButton.Enabled = false;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(310, 8);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(84, 36);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // FillerPanel2
            // 
            this.FillerPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.FillerPanel2.Location = new System.Drawing.Point(302, 8);
            this.FillerPanel2.Name = "FillerPanel2";
            this.FillerPanel2.Size = new System.Drawing.Size(8, 36);
            this.FillerPanel2.TabIndex = 6;
            // 
            // SaveAndCloseButton
            // 
            this.SaveAndCloseButton.BackgroundImage = global::DataJuggler.Win.Controls.Properties.Resources.WoodButtonWidth640Disabled;
            this.SaveAndCloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveAndCloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveAndCloseButton.Enabled = false;
            this.SaveAndCloseButton.FlatAppearance.BorderSize = 0;
            this.SaveAndCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SaveAndCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveAndCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAndCloseButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAndCloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveAndCloseButton.Location = new System.Drawing.Point(154, 8);
            this.SaveAndCloseButton.Name = "SaveAndCloseButton";
            this.SaveAndCloseButton.Size = new System.Drawing.Size(148, 36);
            this.SaveAndCloseButton.TabIndex = 7;
            this.SaveAndCloseButton.Text = "Save && Close";
            this.SaveAndCloseButton.UseVisualStyleBackColor = true;
            this.SaveAndCloseButton.EnabledChanged += new System.EventHandler(this.Button_EnabledChanged);
            this.SaveAndCloseButton.Click += new System.EventHandler(this.SaveAndCloseButton_Click);
            this.SaveAndCloseButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.SaveAndCloseButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // SaveCancelControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.SaveAndCloseButton);
            this.Controls.Add(this.FillerPanel2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.FillerPanel);
            this.Controls.Add(this.CancelSave);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SaveCancelControl";
            this.Size = new System.Drawing.Size(494, 52);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.Button CancelSave;
        private System.Windows.Forms.Panel FillerPanel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel FillerPanel2;
        private System.Windows.Forms.Button SaveAndCloseButton;
    }
}
