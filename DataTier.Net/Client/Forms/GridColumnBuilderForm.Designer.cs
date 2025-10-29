
namespace DataTierClient.Forms
{
    partial class GridColumnBuilderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridColumnBuilderForm));
            this.GridColumnBuilderControl = new DataTierClient.Controls.GridColumnBuilderControl();
            this.SuspendLayout();
            // 
            // GridColumnBuilderControl
            // 
            this.GridColumnBuilderControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GridColumnBuilderControl.BackgroundImage")));
            this.GridColumnBuilderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridColumnBuilderControl.Font = new System.Drawing.Font("Calibri", 16F);
            this.GridColumnBuilderControl.Location = new System.Drawing.Point(0, 0);
            this.GridColumnBuilderControl.Name = "GridColumnBuilderControl";
            this.GridColumnBuilderControl.SelectedField = null;
            this.GridColumnBuilderControl.SelectedTable = null;
            this.GridColumnBuilderControl.Size = new System.Drawing.Size(1384, 664);
            this.GridColumnBuilderControl.TabIndex = 0;
            // 
            // GridColumnBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 664);
            this.Controls.Add(this.GridColumnBuilderControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GridColumnBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid Column Builder";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GridColumnBuilderControl GridColumnBuilderControl;
    }
}