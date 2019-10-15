

#region using statements


#endregion

namespace DataTierClient.Forms
{

    #region class CustomMethodEditorForm
    /// <summary>
    /// This form is used to host the CustomMethodEditor control. 
    /// </summary>
    partial class CustomMethodEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMethodEditorForm));
            this.CustomMethodEditor = new DataTierClient.Controls.CustomMethodEditor();
            this.SuspendLayout();
            // 
            // CustomMethodEditor
            // 
            this.CustomMethodEditor.BackColor = System.Drawing.Color.Linen;
            this.CustomMethodEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomMethodEditor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomMethodEditor.Location = new System.Drawing.Point(0, 0);
            this.CustomMethodEditor.MethodInfo = null;
            this.CustomMethodEditor.Name = "CustomMethodEditor";
            this.CustomMethodEditor.Size = new System.Drawing.Size(720, 610);
            this.CustomMethodEditor.TabIndex = 0;
            this.CustomMethodEditor.UserCancelled = true;
            this.CustomMethodEditor.ViewMode = false;
            // 
            // CustomMethodEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(720, 610);
            this.Controls.Add(this.CustomMethodEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CustomMethodEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Method";
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private Controls.CustomMethodEditor CustomMethodEditor;
    }
    #endregion

}
