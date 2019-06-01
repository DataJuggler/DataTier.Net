

#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region class VisualStudioProjectUpdateForm
    /// <summary>
    /// This is the designer for the VisualStudioProjectUpdateForm.
    /// </summary>
    partial class VisualStudioProjectUpdateForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private VisualStudioProjectUpdateControl VisualStudioProjectUpdateControl;
        #endregion
        
        #region Methods
            
            #region Dispose(bool disposing)
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
            #endregion
            
            #region InitializeComponent()
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualStudioProjectUpdateForm));
            this.VisualStudioProjectUpdateControl = new DataTierClient.Controls.VisualStudioProjectUpdateControl();
            this.SuspendLayout();
            // 
            // VisualStudioProjectUpdateControl
            // 
            this.VisualStudioProjectUpdateControl.BackColor = System.Drawing.Color.Linen;
            this.VisualStudioProjectUpdateControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VisualStudioProjectUpdateControl.CurrentProject = null;
            this.VisualStudioProjectUpdateControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualStudioProjectUpdateControl.Files = null;
            this.VisualStudioProjectUpdateControl.Location = new System.Drawing.Point(0, 0);
            this.VisualStudioProjectUpdateControl.Name = "VisualStudioProjectUpdateControl";
            this.VisualStudioProjectUpdateControl.Size = new System.Drawing.Size(680, 320);
            this.VisualStudioProjectUpdateControl.TabIndex = 0;
            this.VisualStudioProjectUpdateControl.VSSolution = null;
            // 
            // VisualStudioProjectUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 320);
            this.Controls.Add(this.VisualStudioProjectUpdateControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisualStudioProjectUpdateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visual Studio Project Updater";
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
