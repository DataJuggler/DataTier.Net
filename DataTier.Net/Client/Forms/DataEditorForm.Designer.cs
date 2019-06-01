
#region using statements

#endregion

namespace DataTierClient.Forms
{

    #region class DataEditorForm
    /// <summary>
    /// This is the designer code for the DataEditorForm.
    /// </summary>
    partial class DataEditorForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Controls.DataEditorControl DataEditorControl;
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
            DataGateway.Gateway gateway1 = new DataGateway.Gateway();
            ApplicationLogicComponent.Controllers.ApplicationController applicationController1 = new ApplicationLogicComponent.Controllers.ApplicationController();
            ApplicationLogicComponent.Logging.ErrorHandler errorHandler1 = new ApplicationLogicComponent.Logging.ErrorHandler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataEditorForm));
            this.DataEditorControl = new DataTierClient.Controls.DataEditorControl();
            this.SuspendLayout();
            // 
            // DataEditorControl
            // 
            this.DataEditorControl.BackColor = System.Drawing.Color.Linen;
            this.DataEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataEditorControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            applicationController1.ConnectionString = null;
            applicationController1.ConnectionTested = false;
            errorHandler1.LogAsSystemEvent = false;
            errorHandler1.LogFileName = null;
            errorHandler1.LogToFile = false;
            applicationController1.ErrorProcessor = errorHandler1;
            applicationController1.Exception = null;
            gateway1.AppController = applicationController1;
            this.DataEditorControl.Gateway = gateway1;
            this.DataEditorControl.Loading = false;
            this.DataEditorControl.Location = new System.Drawing.Point(0, 0);
            this.DataEditorControl.Name = "Manage Data";
            this.DataEditorControl.OriginalValues = null;
            this.DataEditorControl.Project = null;
            this.DataEditorControl.SelectedTable = null;
            this.DataEditorControl.Size = new System.Drawing.Size(964, 496);
            this.DataEditorControl.TabIndex = 0;
            this.DataEditorControl.UserCancelled = true;
            // 
            // DataEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(964, 496);
            this.Controls.Add(this.DataEditorControl);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DataEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Data";
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
