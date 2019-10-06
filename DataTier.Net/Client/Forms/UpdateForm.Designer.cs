namespace DataTierClient.Forms
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.UpdateControl = new DataTierClient.Controls.UpdateControl();
            this.SuspendLayout();
            // 
            // UpdateControl
            // 
            this.UpdateControl.BackColor = System.Drawing.Color.Linen;
            this.UpdateControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpdateControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateControl.Location = new System.Drawing.Point(0, 0);
            this.UpdateControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.UpdateControl.Name = "UpdateControl";
            this.UpdateControl.ShowSQLUpdate = false;
            this.UpdateControl.Size = new System.Drawing.Size(676, 380);
            this.UpdateControl.TabIndex = 0;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 380);
            this.Controls.Add(this.UpdateControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "An Update Is Available For DataTier.Net";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UpdateControl UpdateControl;
    }
}