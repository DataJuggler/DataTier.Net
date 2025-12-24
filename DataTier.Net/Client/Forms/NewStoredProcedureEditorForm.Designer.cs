namespace DataTierClient.Forms
{
    partial class NewStoredProcedureEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewStoredProcedureEditorForm));
            this.NewStoredProcedureEditor = new DataTierClient.Controls.NewStoredProcedureEditor();
            this.SuspendLayout();
            // 
            // NewStoredProcedureEditor
            // 
            this.NewStoredProcedureEditor.BackColor = System.Drawing.Color.Linen;
            this.NewStoredProcedureEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewStoredProcedureEditor.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewStoredProcedureEditor.Location = new System.Drawing.Point(0, 0);
            this.NewStoredProcedureEditor.Name = "NewStoredProcedureEditor";
            this.NewStoredProcedureEditor.Size = new System.Drawing.Size(1080, 600);
            this.NewStoredProcedureEditor.TabIndex = 0;
            // 
            // NewProcedureEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 600);
            this.Controls.Add(this.NewStoredProcedureEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewProcedureEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Stored Procedure";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NewStoredProcedureEditor NewStoredProcedureEditor;
    }
}

