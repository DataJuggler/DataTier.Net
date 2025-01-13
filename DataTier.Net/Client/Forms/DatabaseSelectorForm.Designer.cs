

#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region class DatabaseSelectorForm
    /// <summary>
    /// This is the Designer for the DatabaseSelectorForm
    /// </summary>
    partial class DatabaseSelectorForm
    {
        
        #region Private Variables
        internal DatabaseSelectorControl DatabaseSelectorControl;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSelectorForm));
            this.DatabaseSelectorControl = new DataTierClient.Controls.DatabaseSelectorControl();
            this.SuspendLayout();
            // 
            // DatabaseSelectorControl
            // 
            this.DatabaseSelectorControl.BackColor = System.Drawing.Color.Linen;
            this.DatabaseSelectorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseSelectorControl.Location = new System.Drawing.Point(0, 0);
            this.DatabaseSelectorControl.Name = "DatabaseSelectorControl";
            this.DatabaseSelectorControl.SelectedDatabase = null;
            this.DatabaseSelectorControl.SelectedProject = null;
            this.DatabaseSelectorControl.Size = new System.Drawing.Size(592, 440);
            this.DatabaseSelectorControl.TabIndex = 1;
            this.DatabaseSelectorControl.UserCancelled = true;
            // 
            // DatabaseSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(592, 440);
            this.Controls.Add(this.DatabaseSelectorControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseSelectorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Database";
            this.Activated += new System.EventHandler(this.DatabaseSelectorForm_Activated);
            this.ResumeLayout(false);

            } 
            #endregion
            
        #endregion
        
    }
    #endregion

}
