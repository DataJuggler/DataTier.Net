namespace DataTierClient.Forms
{
    partial class CustomReadersEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomReadersEditorForm));
            this.CustomReadersEditor = new DataTierClient.Controls.CustomReadersEditor();
            this.SuspendLayout();
            // 
            // CustomReadersEditor
            // 
            this.CustomReadersEditor.BackColor = System.Drawing.Color.Linen;
            this.CustomReadersEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomReadersEditor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomReadersEditor.Location = new System.Drawing.Point(0, 0);
            this.CustomReadersEditor.Name = "CustomReadersEditor";
            this.CustomReadersEditor.SelectedReader = null;
            this.CustomReadersEditor.SelectedTable = null;
            this.CustomReadersEditor.Size = new System.Drawing.Size(432, 440);
            this.CustomReadersEditor.TabIndex = 0;
            // 
            // CustomReadersEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(432, 440);
            this.Controls.Add(this.CustomReadersEditor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomReadersEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Custom Readers";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomReadersEditor CustomReadersEditor;
    }
}