
namespace DataTierClient.Forms
{
    partial class DisplayMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayMessageForm));
            this.DisplayMessageControl = new DataTierClient.Controls.DisplayMessageControl();
            this.SuspendLayout();
            // 
            // DisplayMessageControl
            // 
            this.DisplayMessageControl.BackColor = System.Drawing.Color.Linen;
            this.DisplayMessageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayMessageControl.Font = new System.Drawing.Font("Calibri", 16F);
            this.DisplayMessageControl.Location = new System.Drawing.Point(0, 0);
            this.DisplayMessageControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DisplayMessageControl.MessageText = null;
            this.DisplayMessageControl.Name = "DisplayMessageControl";
            this.DisplayMessageControl.Size = new System.Drawing.Size(508, 172);
            this.DisplayMessageControl.TabIndex = 0;
            // 
            // DisplayMessageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(508, 172);
            this.Controls.Add(this.DisplayMessageControl);
            this.Font = new System.Drawing.Font("Calibri", 16F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "DisplayMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisplayMessageForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayMessageForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DisplayMessageControl DisplayMessageControl;
    }
}

