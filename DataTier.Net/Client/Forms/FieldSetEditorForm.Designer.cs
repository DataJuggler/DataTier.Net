namespace DataTierClient.Forms
{
    partial class FieldSetEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldSetEditorForm));
            this.FieldSetEditor = new DataTierClient.Controls.FieldSetEditor();
            this.SuspendLayout();
            // 
            // FieldSetEditor
            // 
            this.FieldSetEditor.BackColor = System.Drawing.Color.Linen;
            this.FieldSetEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldSetEditor.EditMode = ObjectLibrary.Enumerations.EditModeEnum.Unknown;
            this.FieldSetEditor.FailedReason = null;
            this.FieldSetEditor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldSetEditor.Location = new System.Drawing.Point(0, 0);
            this.FieldSetEditor.Name = "FieldSetEditor";
            this.FieldSetEditor.ParameterMode = false;
            this.FieldSetEditor.ParameterModeReadOnly = false;
            this.FieldSetEditor.SelectedFieldSet = null;
            this.FieldSetEditor.SelectedTable = null;
            this.FieldSetEditor.Size = new System.Drawing.Size(840, 600);
            this.FieldSetEditor.TabIndex = 0;
            // 
            // FieldSetEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(840, 600);
            this.Controls.Add(this.FieldSetEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FieldSetEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Field Set Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldSetEditorForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FieldSetEditor FieldSetEditor;
    }
}