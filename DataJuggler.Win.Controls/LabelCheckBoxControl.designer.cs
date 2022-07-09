﻿

namespace DataJuggler.Win.Controls
{

    #region class LabelTextBoxControl (Designer)
    /// <summary>
    /// This class is used to display a Label and a LabelTextBox for editing.
    /// </summary>
    partial class LabelCheckBoxControl
    {

        #region Components
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Panel CheckBoxTopMarginPanel;
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;
        #endregion

        #region Component Designer generated code

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
            this.Label = new System.Windows.Forms.Label();
            this.CheckBoxTopMarginPanel = new System.Windows.Forms.Panel();
            this.CheckBoxLeftMarginPanel = new System.Windows.Forms.Panel();
            this.CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(160, 28);
            this.Label.TabIndex = 0;
            this.Label.Text = "[Label Text]:";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckBoxTopMarginPanel
            // 
            this.CheckBoxTopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckBoxTopMarginPanel.Location = new System.Drawing.Point(160, 0);
            this.CheckBoxTopMarginPanel.Name = "CheckBoxTopMarginPanel";
            this.CheckBoxTopMarginPanel.Size = new System.Drawing.Size(76, 3);
            this.CheckBoxTopMarginPanel.TabIndex = 2;
            // 
            // CheckBoxLeftMarginPanel
            // 
            this.CheckBoxLeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CheckBoxLeftMarginPanel.Location = new System.Drawing.Point(160, 3);
            this.CheckBoxLeftMarginPanel.Name = "CheckBoxLeftMarginPanel";
            this.CheckBoxLeftMarginPanel.Size = new System.Drawing.Size(0, 25);
            this.CheckBoxLeftMarginPanel.TabIndex = 3;
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSize = true;
            this.CheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.CheckBox.Location = new System.Drawing.Point(160, 3);
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Size = new System.Drawing.Size(15, 25);
            this.CheckBox.TabIndex = 4;
            this.CheckBox.UseVisualStyleBackColor = true;
            this.CheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // LabelCheckBoxControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.CheckBox);
            this.Controls.Add(this.CheckBoxLeftMarginPanel);
            this.Controls.Add(this.CheckBoxTopMarginPanel);
            this.Controls.Add(this.Label);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LabelCheckBoxControl";
            this.Size = new System.Drawing.Size(236, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
        #endregion

        #endregion

        private System.Windows.Forms.Panel CheckBoxLeftMarginPanel;
        private System.Windows.Forms.CheckBox CheckBox;
    } 
    #endregion
    
}
