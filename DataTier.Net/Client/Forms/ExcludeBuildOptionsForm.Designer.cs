namespace DataTierClient.Forms
{
    partial class ExcludeBuildOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcludeBuildOptionsForm));
            this.ExcludeBuildOptionsControl = new DataTierClient.Controls.ExcludeBuildOptionsControl();
            this.SuspendLayout();
            // 
            // ExcludeBuildOptionsControl
            // 
            this.ExcludeBuildOptionsControl.BackColor = System.Drawing.Color.Linen;
            this.ExcludeBuildOptionsControl.BuildExcludes = null;
            this.ExcludeBuildOptionsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcludeBuildOptionsControl.Location = new System.Drawing.Point(0, 0);
            this.ExcludeBuildOptionsControl.Name = "ExcludeBuildOptionsControl";
            this.ExcludeBuildOptionsControl.SelectedTable = null;
            this.ExcludeBuildOptionsControl.Size = new System.Drawing.Size(480, 348);
            this.ExcludeBuildOptionsControl.TabIndex = 0;
            this.ExcludeBuildOptionsControl.UserCancelled = true;
            // 
            // ExcludeBuildOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 348);
            this.Controls.Add(this.ExcludeBuildOptionsControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcludeBuildOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluce Build Options";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ExcludeBuildOptionsControl ExcludeBuildOptionsControl;
    }
}