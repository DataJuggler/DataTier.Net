

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ValidationControl
    /// <summary>
    /// This is the designer code for the ValidationControl control.
    /// </summary>
    partial class ValidationControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox ValidationListBox;
        private System.Windows.Forms.Label InvalidMessageLabel;
        private System.Windows.Forms.Button OKButton;
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
            this.ValidationListBox = new System.Windows.Forms.ListBox();
            this.InvalidMessageLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ValidationListBox
            // 
            this.ValidationListBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidationListBox.ForeColor = System.Drawing.Color.Red;
            this.ValidationListBox.FormattingEnabled = true;
            this.ValidationListBox.ItemHeight = 26;
            this.ValidationListBox.Location = new System.Drawing.Point(20, 40);
            this.ValidationListBox.Name = "ValidationListBox";
            this.ValidationListBox.Size = new System.Drawing.Size(800, 134);
            this.ValidationListBox.TabIndex = 0;
            // 
            // InvalidMessageLabel
            // 
            this.InvalidMessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.InvalidMessageLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvalidMessageLabel.ForeColor = System.Drawing.Color.Black;
            this.InvalidMessageLabel.Location = new System.Drawing.Point(18, 12);
            this.InvalidMessageLabel.Name = "InvalidMessageLabel";
            this.InvalidMessageLabel.Size = new System.Drawing.Size(419, 24);
            this.InvalidMessageLabel.TabIndex = 1;
            this.InvalidMessageLabel.Text = "The following fields are missing or invalid:";
            // 
            // OKButton
            // 
            this.OKButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.OKButton.Location = new System.Drawing.Point(378, 184);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(84, 40);
            this.OKButton.TabIndex = 97;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            this.OKButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.OKButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // ValidationControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.InvalidMessageLabel);
            this.Controls.Add(this.ValidationListBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ValidationControl";
            this.Size = new System.Drawing.Size(840, 240);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}



