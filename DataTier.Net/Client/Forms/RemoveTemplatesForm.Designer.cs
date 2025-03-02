
namespace DataTierClient.Forms
{
    partial class RemoveTemplatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveTemplatesForm));
            this.RemoveTemplatesControl = new DataTierClient.Controls.RemoveTemplatesControl();
            this.SuspendLayout();
            // 
            // RemoveTemplatesControl
            // 
            this.RemoveTemplatesControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveTemplatesControl.BackgroundImage")));
            this.RemoveTemplatesControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveTemplatesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveTemplatesControl.Location = new System.Drawing.Point(0, 0);
            this.RemoveTemplatesControl.Margin = new System.Windows.Forms.Padding(5);
            this.RemoveTemplatesControl.Name = "RemoveTemplatesControl";
            this.RemoveTemplatesControl.Size = new System.Drawing.Size(980, 668);
            this.RemoveTemplatesControl.TabIndex = 0;
            // 
            // RemoveTemplatesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(980, 668);
            this.Controls.Add(this.RemoveTemplatesControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoveTemplatesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoveTemplatesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RemoveTemplatesControl RemoveTemplatesControl;
    }
}