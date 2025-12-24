

#region using statements


#endregion

namespace DataTierClient.Forms
{

    #region class DialogControlForm
    /// <summary>
    /// This form is the designer for this form
    /// </summary>
    partial class DialogControlForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Controls.DialogControl DialogControl;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogControlForm));
                this.DialogControl = new DataTierClient.Controls.DialogControl();
                this.SuspendLayout();
                // 
                // DialogControl
                // 
                this.DialogControl.BackColor = System.Drawing.Color.Linen;
                this.DialogControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.DialogControl.Dock = System.Windows.Forms.DockStyle.Fill;
                this.DialogControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DialogControl.Location = new System.Drawing.Point(0, 0);
                this.DialogControl.Name = "DialogControl";
                this.DialogControl.Size = new System.Drawing.Size(640, 248);
                this.DialogControl.TabIndex = 0;
                this.DialogControl.UserResponse = ObjectLibrary.Enumerations.UserResponseEnum.NoResponse;
                // 
                // DialogControlForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(640, 248);
                this.Controls.Add(this.DialogControl);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "DialogControlForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Dialog Message";
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}


