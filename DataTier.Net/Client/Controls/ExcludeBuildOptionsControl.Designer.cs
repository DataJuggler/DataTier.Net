namespace DataTierClient.Controls
{
    partial class ExcludeBuildOptionsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectedTableTextBox = new System.Windows.Forms.TextBox();
            this.SelectedTableLabel = new System.Windows.Forms.Label();
            this.ExcludeDelete = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ExcludeFetchAll = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ExcludeFind = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ExcludeInsert = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ExcludeUpdate = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.SaveCancelControl = new DataJuggler.Win.Controls.SaveCancelControl();
            this.SuspendLayout();
            // 
            // SelectedTableTextBox
            // 
            this.SelectedTableTextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableTextBox.Location = new System.Drawing.Point(28, 52);
            this.SelectedTableTextBox.Name = "SelectedTableTextBox";
            this.SelectedTableTextBox.ReadOnly = true;
            this.SelectedTableTextBox.Size = new System.Drawing.Size(232, 31);
            this.SelectedTableTextBox.TabIndex = 10;
            // 
            // SelectedTableLabel
            // 
            this.SelectedTableLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableLabel.Location = new System.Drawing.Point(28, 20);
            this.SelectedTableLabel.Name = "SelectedTableLabel";
            this.SelectedTableLabel.Size = new System.Drawing.Size(156, 29);
            this.SelectedTableLabel.TabIndex = 9;
            this.SelectedTableLabel.Text = "Selected Table:";
            this.SelectedTableLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ExcludeDelete
            // 
            this.ExcludeDelete.BackColor = System.Drawing.Color.Transparent;
            this.ExcludeDelete.CheckBoxHorizontalOffSet = 0;
            this.ExcludeDelete.CheckBoxVerticalOffSet = 4;
            this.ExcludeDelete.CheckChangedListener = null;
            this.ExcludeDelete.Checked = false;
            this.ExcludeDelete.Editable = true;
            this.ExcludeDelete.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcludeDelete.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ExcludeDelete.LabelFont = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.ExcludeDelete.LabelText = "Exclude Delete:";
            this.ExcludeDelete.LabelWidth = 180;
            this.ExcludeDelete.Location = new System.Drawing.Point(28, 102);
            this.ExcludeDelete.Name = "ExcludeDelete";
            this.ExcludeDelete.Size = new System.Drawing.Size(209, 28);
            this.ExcludeDelete.TabIndex = 11;
            // 
            // ExcludeFetchAll
            // 
            this.ExcludeFetchAll.BackColor = System.Drawing.Color.Transparent;
            this.ExcludeFetchAll.CheckBoxHorizontalOffSet = 0;
            this.ExcludeFetchAll.CheckBoxVerticalOffSet = 4;
            this.ExcludeFetchAll.CheckChangedListener = null;
            this.ExcludeFetchAll.Checked = false;
            this.ExcludeFetchAll.Editable = true;
            this.ExcludeFetchAll.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcludeFetchAll.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ExcludeFetchAll.LabelFont = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.ExcludeFetchAll.LabelText = "Exclude Fetch All:";
            this.ExcludeFetchAll.LabelWidth = 180;
            this.ExcludeFetchAll.Location = new System.Drawing.Point(28, 136);
            this.ExcludeFetchAll.Name = "ExcludeFetchAll";
            this.ExcludeFetchAll.Size = new System.Drawing.Size(209, 28);
            this.ExcludeFetchAll.TabIndex = 12;
            // 
            // ExcludeFind
            // 
            this.ExcludeFind.BackColor = System.Drawing.Color.Transparent;
            this.ExcludeFind.CheckBoxHorizontalOffSet = 0;
            this.ExcludeFind.CheckBoxVerticalOffSet = 4;
            this.ExcludeFind.CheckChangedListener = null;
            this.ExcludeFind.Checked = false;
            this.ExcludeFind.Editable = true;
            this.ExcludeFind.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcludeFind.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ExcludeFind.LabelFont = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.ExcludeFind.LabelText = "Exclude Find:";
            this.ExcludeFind.LabelWidth = 180;
            this.ExcludeFind.Location = new System.Drawing.Point(28, 170);
            this.ExcludeFind.Name = "ExcludeFind";
            this.ExcludeFind.Size = new System.Drawing.Size(209, 28);
            this.ExcludeFind.TabIndex = 13;
            // 
            // ExcludeInsert
            // 
            this.ExcludeInsert.BackColor = System.Drawing.Color.Transparent;
            this.ExcludeInsert.CheckBoxHorizontalOffSet = 0;
            this.ExcludeInsert.CheckBoxVerticalOffSet = 4;
            this.ExcludeInsert.CheckChangedListener = null;
            this.ExcludeInsert.Checked = false;
            this.ExcludeInsert.Editable = true;
            this.ExcludeInsert.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcludeInsert.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ExcludeInsert.LabelFont = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.ExcludeInsert.LabelText = "Exclude Insert:";
            this.ExcludeInsert.LabelWidth = 180;
            this.ExcludeInsert.Location = new System.Drawing.Point(28, 204);
            this.ExcludeInsert.Name = "ExcludeInsert";
            this.ExcludeInsert.Size = new System.Drawing.Size(209, 28);
            this.ExcludeInsert.TabIndex = 14;
            // 
            // ExcludeUpdate
            // 
            this.ExcludeUpdate.BackColor = System.Drawing.Color.Transparent;
            this.ExcludeUpdate.CheckBoxHorizontalOffSet = 0;
            this.ExcludeUpdate.CheckBoxVerticalOffSet = 4;
            this.ExcludeUpdate.CheckChangedListener = null;
            this.ExcludeUpdate.Checked = false;
            this.ExcludeUpdate.Editable = true;
            this.ExcludeUpdate.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExcludeUpdate.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ExcludeUpdate.LabelFont = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.ExcludeUpdate.LabelText = "Exclude Update:";
            this.ExcludeUpdate.LabelWidth = 180;
            this.ExcludeUpdate.Location = new System.Drawing.Point(28, 238);
            this.ExcludeUpdate.Name = "ExcludeUpdate";
            this.ExcludeUpdate.Size = new System.Drawing.Size(209, 28);
            this.ExcludeUpdate.TabIndex = 15;
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.CancelButtonWidth = 96;
            this.SaveCancelControl.DisabledForeColor = System.Drawing.Color.DarkGray;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.DoneMode = false;
            this.SaveCancelControl.EnableSaveAndCloseButton = false;
            this.SaveCancelControl.EnableSaveButton = false;
            this.SaveCancelControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 296);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.SaveAndCloseButtonWidth = 144;
            this.SaveCancelControl.SaveButtonWidth = 0;
            this.SaveCancelControl.ShowSaveAndCloseButton = true;
            this.SaveCancelControl.ShowSaveButton = false;
            this.SaveCancelControl.Size = new System.Drawing.Size(480, 52);
            this.SaveCancelControl.TabIndex = 16;
            // 
            // ExcludeBuildOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.ExcludeUpdate);
            this.Controls.Add(this.ExcludeInsert);
            this.Controls.Add(this.ExcludeFind);
            this.Controls.Add(this.ExcludeFetchAll);
            this.Controls.Add(this.ExcludeDelete);
            this.Controls.Add(this.SelectedTableTextBox);
            this.Controls.Add(this.SelectedTableLabel);
            this.Name = "ExcludeBuildOptionsControl";
            this.Size = new System.Drawing.Size(480, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SelectedTableTextBox;
        private System.Windows.Forms.Label SelectedTableLabel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ExcludeDelete;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ExcludeFetchAll;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ExcludeFind;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ExcludeInsert;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ExcludeUpdate;
        private DataJuggler.Win.Controls.SaveCancelControl SaveCancelControl;
    }
}
