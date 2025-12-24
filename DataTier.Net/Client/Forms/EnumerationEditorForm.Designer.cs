

#region using statements

using DataTierClient.Controls;

#endregion

namespace DataTierClient.Forms
{

    #region class EnumerationEditorForm
    /// <summary>
    /// This form is used to host the EnumerationEditorControl
    /// </summary>
    partial class EnumerationEditorForm
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private Controls.EnumerationEditor EnumerationEditor;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnumerationEditorForm));
            this.EnumerationEditor = new DataTierClient.Controls.EnumerationEditor();
            this.SuspendLayout();
            // 
            // EnumerationEditor
            // 
            this.EnumerationEditor.BackColor = System.Drawing.Color.Linen;
            this.EnumerationEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnumerationEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnumerationEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnumerationEditor.EditMode = false;
            this.EnumerationEditor.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnumerationEditor.Location = new System.Drawing.Point(0, 0);
            this.EnumerationEditor.Name = "EnumerationEditor";
            this.EnumerationEditor.SelectedEnumeration = null;
            this.EnumerationEditor.SelectedProject = null;
            this.EnumerationEditor.Size = new System.Drawing.Size(612, 324);
            this.EnumerationEditor.TabIndex = 0;
            // 
            // EnumerationEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 324);
            this.Controls.Add(this.EnumerationEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EnumerationEditorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enumeration Editor";
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}


