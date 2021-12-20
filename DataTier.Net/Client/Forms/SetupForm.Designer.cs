namespace DataTierClient.Forms
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.SetupControl = new DataTierClient.Controls.SetupControl();
            this.SuspendLayout();
            // 
            // SetupControl
            // 
            this.SetupControl.BackColor = System.Drawing.Color.Transparent;
            this.SetupControl.BackgroundImage = global::DataTierClient.Properties.Resources.Setup1;
            this.SetupControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SetupControl.DatabaseSchemaClicked = false;
            this.SetupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupControl.ForeColor = System.Drawing.Color.GhostWhite;
            this.SetupControl.Location = new System.Drawing.Point(0, 0);
            this.SetupControl.Name = "SetupControl";
            this.SetupControl.Size = new System.Drawing.Size(1080, 720);
            this.SetupControl.TabIndex = 0;
            this.SetupControl.Load += new System.EventHandler(this.SetupControl_Load);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.SetupControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup DataTier.Net";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SetupControl SetupControl;
    }
}