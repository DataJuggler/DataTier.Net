

#region using statements


#endregion

namespace DataTierClient.Forms
{

    #region class CustomMethodsEditorForm
    /// <summary>
    /// This is the designer for the CustomMethodsEditorForm.
    /// </summary>
    partial class CustomMethodsEditorForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Controls.CustomMethodsEditor CustomMethodsEditor;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMethodsEditorForm));
            this.CustomMethodsEditor = new DataTierClient.Controls.CustomMethodsEditor();
            this.SuspendLayout();
            // 
            // CustomMethodsEditor
            // 
            this.CustomMethodsEditor.ActionType = ObjectLibrary.Enumerations.ActionTypeEnum.NoAction;
            this.CustomMethodsEditor.BackColor = System.Drawing.Color.Linen;
            this.CustomMethodsEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomMethodsEditor.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomMethodsEditor.Location = new System.Drawing.Point(0, 0);
            this.CustomMethodsEditor.MethodsList = null;
            this.CustomMethodsEditor.Name = "CustomMethodsEditor";
            this.CustomMethodsEditor.SelectedMethod = null;
            this.CustomMethodsEditor.SelectedTable = null;
            this.CustomMethodsEditor.Size = new System.Drawing.Size(420, 240);
            this.CustomMethodsEditor.TabIndex = 0;
            // 
            // CustomMethodsEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 240);
            this.Controls.Add(this.CustomMethodsEditor);
            this.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CustomMethodsEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Custom Methods";
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}


