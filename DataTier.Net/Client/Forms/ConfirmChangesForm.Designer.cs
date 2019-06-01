

#region using statements


#endregion

namespace DataTierClient.Forms
{

    #region class ConfirmChangesForm
    /// <summary>
    /// This is the designer code for the ConfirmChangesForm.
    /// </summary>
    partial class ConfirmChangesForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Controls.ConfirmChangesControl ConfirmChangesControl;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmChangesForm));
                this.ConfirmChangesControl = new DataTierClient.Controls.ConfirmChangesControl();
                this.SuspendLayout();
                // 
                // ConfirmChangesControl
                // 
                this.ConfirmChangesControl.BackColor = System.Drawing.Color.Linen;
                this.ConfirmChangesControl.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ConfirmChangesControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ConfirmChangesControl.Loading = false;
                this.ConfirmChangesControl.Location = new System.Drawing.Point(0, 0);
                this.ConfirmChangesControl.Name = "ConfirmChangesControl";
                this.ConfirmChangesControl.Size = new System.Drawing.Size(960, 568);
                this.ConfirmChangesControl.TabIndex = 0;
                this.ConfirmChangesControl.UserCancelled = true;
                // 
                // ConfirmChangesForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1080, 600);
                this.Controls.Add(this.ConfirmChangesControl);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "ConfirmChangesForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Confirm Code Changes";
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
