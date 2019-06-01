
#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region class EditReferencesSetForm (Designer)
    /// <summary>
    /// This class is the designer for the EditReferencesSetForm.
    /// </summary>
    partial class ReferencesSetEditorForm
    {
        
        #region Controls
        internal ReferencesSetEditor ReferencesSetEditor;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferencesSetEditorForm));
            this.ReferencesSetEditor = new DataTierClient.Controls.ReferencesSetEditor();
            this.SuspendLayout();
            // 
            // ReferencesSetEditor
            // 
            this.ReferencesSetEditor.BackColor = System.Drawing.Color.Linen;
            this.ReferencesSetEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReferencesSetEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesSetEditor.Location = new System.Drawing.Point(0, 0);
            this.ReferencesSetEditor.Name = "ReferencesSetEditor";
            this.ReferencesSetEditor.OriginalSet = null;
            this.ReferencesSetEditor.SelectedProject = null;
            this.ReferencesSetEditor.SelectedReference = null;
            this.ReferencesSetEditor.SelectedReferencesSet = null;
            this.ReferencesSetEditor.Size = new System.Drawing.Size(632, 348);
            this.ReferencesSetEditor.TabIndex = 0;
            this.ReferencesSetEditor.UserCancelled = true;
            // 
            // ReferencesSetEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 348);
            this.Controls.Add(this.ReferencesSetEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReferencesSetEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New References Set";
            this.ResumeLayout(false);

            } 
            #endregion

        #endregion
        
    }
    #endregion
    
}