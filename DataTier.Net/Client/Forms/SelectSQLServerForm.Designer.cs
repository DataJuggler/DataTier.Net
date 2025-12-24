
#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region class SelectSQLServerForm (Designer)
    /// <summary>
    /// This is the designer for the SelectSQLServerForm
    /// </summary>
    partial class SelectSQLServerForm
    {
        #region Controls
        internal SelectSQLServerControl SelectSQLServerControl;
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        #endregion
        
        #region Windows Form Designer generated code

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSQLServerForm));
            this.SelectSQLServerControl = new DataTierClient.Controls.SelectSQLServerControl();
            this.SuspendLayout();
            // 
            // SelectSQLServerControl
            // 
            this.SelectSQLServerControl.BackColor = System.Drawing.Color.Linen;
            this.SelectSQLServerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectSQLServerControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectSQLServerControl.Loading = false;
            this.SelectSQLServerControl.Location = new System.Drawing.Point(0, 0);
            this.SelectSQLServerControl.Name = "SelectSQLServerControl";
            this.SelectSQLServerControl.SelectionTextBox = null;
            this.SelectSQLServerControl.Size = new System.Drawing.Size(420, 454);
            this.SelectSQLServerControl.TabIndex = 0;
            // 
            // SelectSQLServerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 454);
            this.Controls.Add(this.SelectSQLServerControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectSQLServerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select SQL Server";
            this.ResumeLayout(false);

            }
            
            #endregion
            
        #endregion
        
    }
    #endregion
    
}

