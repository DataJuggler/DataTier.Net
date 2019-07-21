namespace DataTierClient.Controls
{
    partial class DialogControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogControl));
            this.LeftMarginPanel = new System.Windows.Forms.Panel();
            this.RightMarginPanel = new System.Windows.Forms.Panel();
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 248);
            this.LeftMarginPanel.TabIndex = 0;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(622, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 248);
            this.RightMarginPanel.TabIndex = 1;
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(16, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(606, 16);
            this.TopMarginPanel.TabIndex = 2;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageLabel.Location = new System.Drawing.Point(16, 16);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(606, 160);
            this.MessageLabel.TabIndex = 4;
            this.MessageLabel.Text = resources.GetString("MessageLabel.Text");
            // 
            // YesButton
            // 
            this.YesButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.YesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YesButton.FlatAppearance.BorderSize = 0;
            this.YesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.YesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.YesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.YesButton.Location = new System.Drawing.Point(207, 183);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(96, 40);
            this.YesButton.TabIndex = 97;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            this.YesButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.YesButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // NoButton
            // 
            this.NoButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.NoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NoButton.FlatAppearance.BorderSize = 0;
            this.NoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.NoButton.Location = new System.Drawing.Point(335, 183);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(96, 40);
            this.NoButton.TabIndex = 98;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            this.NoButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.NoButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DialogControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DialogControl";
            this.Size = new System.Drawing.Size(638, 248);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftMarginPanel;
        private System.Windows.Forms.Panel RightMarginPanel;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
    }
}
