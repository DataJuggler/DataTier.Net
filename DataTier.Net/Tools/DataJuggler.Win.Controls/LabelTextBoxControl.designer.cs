

namespace DataJuggler.Win.Controls
{

    #region class LabelTextBoxControl (Designer)
    /// <summary>
    /// This class is used to display a Label and a LabelTextBox for editing.
    /// </summary>
    partial class LabelTextBoxControl
    {

        #region Components

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
            this.TextBoxTopMarginPanel = new System.Windows.Forms.Panel();
            this.TextBoxBottomMarginPanel = new System.Windows.Forms.Panel();
            this.BottomMarginPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Label = new System.Windows.Forms.Label();
            this.LabelRightMargin = new System.Windows.Forms.Panel();
            this.LabelTopMarginPanel = new System.Windows.Forms.Panel();
            this.LabelBottomMarginPanel = new System.Windows.Forms.Panel();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxTopMarginPanel
            // 
            this.TextBoxTopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxTopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxTopMarginPanel.Name = "TextBoxTopMarginPanel";
            this.TextBoxTopMarginPanel.Size = new System.Drawing.Size(360, 1);
            this.TextBoxTopMarginPanel.TabIndex = 6;
            // 
            // TextBoxBottomMarginPanel
            // 
            this.TextBoxBottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextBoxBottomMarginPanel.Location = new System.Drawing.Point(0, 31);
            this.TextBoxBottomMarginPanel.Name = "TextBoxBottomMarginPanel";
            this.TextBoxBottomMarginPanel.Size = new System.Drawing.Size(360, 1);
            this.TextBoxBottomMarginPanel.TabIndex = 8;
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(0, 31);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(360, 0);
            this.BottomMarginPanel.TabIndex = 14;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.Label);
            this.LeftPanel.Controls.Add(this.LabelRightMargin);
            this.LeftPanel.Controls.Add(this.LabelTopMarginPanel);
            this.LeftPanel.Controls.Add(this.LabelBottomMarginPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 1);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(160, 30);
            this.LeftPanel.TabIndex = 17;
            // 
            // Label
            // 
            this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(158, 30);
            this.Label.TabIndex = 18;
            this.Label.Text = "[LabelText]";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelRightMargin
            // 
            this.LabelRightMargin.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelRightMargin.Location = new System.Drawing.Point(158, 0);
            this.LabelRightMargin.Name = "LabelRightMargin";
            this.LabelRightMargin.Size = new System.Drawing.Size(2, 30);
            this.LabelRightMargin.TabIndex = 17;
            // 
            // LabelTopMarginPanel
            // 
            this.LabelTopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelTopMarginPanel.Name = "LabelTopMarginPanel";
            this.LabelTopMarginPanel.Size = new System.Drawing.Size(160, 0);
            this.LabelTopMarginPanel.TabIndex = 7;
            // 
            // LabelBottomMarginPanel
            // 
            this.LabelBottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelBottomMarginPanel.Location = new System.Drawing.Point(0, 30);
            this.LabelBottomMarginPanel.Name = "LabelBottomMarginPanel";
            this.LabelBottomMarginPanel.Size = new System.Drawing.Size(160, 0);
            this.LabelBottomMarginPanel.TabIndex = 5;
            // 
            // TextBox
            // 
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.Location = new System.Drawing.Point(160, 1);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(200, 31);
            this.TextBox.TabIndex = 18;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // LabelTextBoxControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TextBoxBottomMarginPanel);
            this.Controls.Add(this.TextBoxTopMarginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LabelTextBoxControl";
            this.Size = new System.Drawing.Size(360, 32);
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            }
            #endregion


        #endregion

            private System.Windows.Forms.Panel TextBoxTopMarginPanel;
            private System.Windows.Forms.Panel TextBoxBottomMarginPanel;
            private System.Windows.Forms.Panel BottomMarginPanel;
            private System.Windows.Forms.Panel LeftPanel;
            private System.Windows.Forms.Label Label;
            private System.Windows.Forms.Panel LabelRightMargin;
            private System.Windows.Forms.Panel LabelTopMarginPanel;
            private System.Windows.Forms.Panel LabelBottomMarginPanel;
            private System.Windows.Forms.TextBox TextBox;

    } 
    #endregion
    
}
