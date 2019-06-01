
#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region ReferenceEditorForm (Designer)
    /// <summary>
    /// This class is the designer for the ReferencesEditorForm.
    /// </summary>
    partial class ReferenceEditorForm
    {
        
        #region Controls
        internal ReferenceEditor ReferenceEditor;
        /// Required designer variable.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferenceEditorForm));
            this.ReferenceEditor = new DataTierClient.Controls.ReferenceEditor();
            this.SuspendLayout();
            // 
            // ReferenceEditor
            // 
            this.ReferenceEditor.BackColor = System.Drawing.Color.Linen;
            this.ReferenceEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceEditor.Location = new System.Drawing.Point(0, 0);
            this.ReferenceEditor.Name = "ReferenceEditor";
            this.ReferenceEditor.OriginalReference = null;
            this.ReferenceEditor.ParentReferenceSet = null;
            this.ReferenceEditor.SelectedReference = null;
            this.ReferenceEditor.Size = new System.Drawing.Size(664, 136);
            this.ReferenceEditor.TabIndex = 0;
            this.ReferenceEditor.UserCancelled = true;
            // 
            // ReferenceEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 136);
            this.Controls.Add(this.ReferenceEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReferenceEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Reference";
            this.ResumeLayout(false);

            } 
            #endregion

        #endregion

    }
    #endregion
    
}