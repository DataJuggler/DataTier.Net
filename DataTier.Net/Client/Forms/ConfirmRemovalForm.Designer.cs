
#region using statements

#endregion

namespace DataTierClient.Forms
{

    #region class ConfirmRemovalForm
    /// <summary>
    /// This is the designer code for the ConfirmRemovalForm.
    /// </summary>
    partial class ConfirmRemovalForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Controls.ConfirmRemovalControl ConfirmRemovalControl;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmRemovalForm));
                this.ConfirmRemovalControl = new DataTierClient.Controls.ConfirmRemovalControl();
                this.SuspendLayout();
                // 
                // ConfirmRemovalControl
                // 
                this.ConfirmRemovalControl.BackColor = System.Drawing.Color.Linen;
                this.ConfirmRemovalControl.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ConfirmRemovalControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ConfirmRemovalControl.Loading = false;
                this.ConfirmRemovalControl.Location = new System.Drawing.Point(0, 0);
                this.ConfirmRemovalControl.Name = "ConfirmRemovalControl";
                this.ConfirmRemovalControl.ProjectFileManager = null;
                this.ConfirmRemovalControl.ProjectFolder = null;
                this.ConfirmRemovalControl.Size = new System.Drawing.Size(960, 568);
                this.ConfirmRemovalControl.TabIndex = 0;
                this.ConfirmRemovalControl.UserCancelled = true;
                // 
                // ConfirmRemovalForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(960, 568);
                this.Controls.Add(this.ConfirmRemovalControl);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "ConfirmRemovalForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Confirm Code Removal";
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}


