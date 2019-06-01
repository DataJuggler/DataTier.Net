namespace DataTierClient.Forms
{
    partial class ValidationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationForm));
            this.ValidationControl = new DataTierClient.Controls.ValidationControl();
            this.SuspendLayout();
            // 
            // ValidationControl
            // 
            this.ValidationControl.BackColor = System.Drawing.Color.Linen;
            this.ValidationControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ValidationControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ValidationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValidationControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidationControl.Location = new System.Drawing.Point(0, 0);
            this.ValidationControl.Name = "ValidationControl";
            this.ValidationControl.Size = new System.Drawing.Size(840, 240);
            this.ValidationControl.TabIndex = 0;
            // 
            // ValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 240);
            this.Controls.Add(this.ValidationControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValidationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validation Errors";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ValidationControl ValidationControl;
    }
}