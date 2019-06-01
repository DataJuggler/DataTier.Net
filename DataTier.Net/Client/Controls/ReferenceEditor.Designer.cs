

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ReferenceEditor
    /// <summary>
    /// This control is used to edit references
    /// </summary>
    partial class ReferenceEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox ReferenceTextBox;
        private System.Windows.Forms.Label ReferenceNameLabel;
        private SaveCancelControl SaveCancelControl;
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
            this.ReferenceTextBox = new System.Windows.Forms.TextBox();
            this.ReferenceNameLabel = new System.Windows.Forms.Label();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.SuspendLayout();
            // 
            // ReferenceTextBox
            // 
            this.ReferenceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferenceTextBox.Location = new System.Drawing.Point(184, 16);
            this.ReferenceTextBox.Name = "ReferenceTextBox";
            this.ReferenceTextBox.Size = new System.Drawing.Size(447, 27);
            this.ReferenceTextBox.TabIndex = 99;
            this.ReferenceTextBox.TextChanged += new System.EventHandler(this.ReferenceTextBox_TextChanged);
            this.ReferenceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReferenceTextBox_KeyDown);
            // 
            // ReferenceNameLabel
            // 
            this.ReferenceNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferenceNameLabel.Location = new System.Drawing.Point(23, 22);
            this.ReferenceNameLabel.Name = "ReferenceNameLabel";
            this.ReferenceNameLabel.Size = new System.Drawing.Size(160, 20);
            this.ReferenceNameLabel.TabIndex = 98;
            this.ReferenceNameLabel.Text = "Reference  Name:";
            this.ReferenceNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 96);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(664, 40);
            this.SaveCancelControl.TabIndex = 100;
            // 
            // ReferenceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.ReferenceTextBox);
            this.Controls.Add(this.ReferenceNameLabel);
            this.Name = "ReferenceEditor";
            this.Size = new System.Drawing.Size(664, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
