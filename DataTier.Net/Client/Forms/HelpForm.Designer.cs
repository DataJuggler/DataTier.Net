

#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region class HelpForm
    /// <summary>
    /// This form is used to host the Help control. 
    /// </summary>
    partial class HelpForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.HelpControl = new DataTierClient.Controls.HelpControl();
            this.SuspendLayout();
            // 
            // HelpControl
            // 
            this.HelpControl.BackColor = System.Drawing.Color.Linen;
            this.HelpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpControl.Location = new System.Drawing.Point(0, 0);
            this.HelpControl.Name = "HelpControl";
            this.HelpControl.Size = new System.Drawing.Size(712, 488);
            this.HelpControl.TabIndex = 0;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 488);
            this.Controls.Add(this.HelpControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataTier.Net Code Generation Toolkit Help";
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private HelpControl HelpControl;
    }
    #endregion

}
