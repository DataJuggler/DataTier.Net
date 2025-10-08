

namespace DataJuggler.Win.Controls
{

    #region class LabelComboBoxControl (Designer)
    /// <summary>
    /// This class is used to display a Label and a LabelTextBox for editing.
    /// </summary>
    partial class LabelComboBoxControl
    {

        #region Components

        private System.Windows.Forms.Panel TextBoxMarginPanel;
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
            this.TextBoxMarginPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Label = new System.Windows.Forms.Label();
            this.LabelBottomMarginPanel = new System.Windows.Forms.Panel();
            this.LabelTopMarginPanel = new System.Windows.Forms.Panel();
            this.ComboBoxLeftMarginPanel = new System.Windows.Forms.Panel();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxMarginPanel
            // 
            this.TextBoxMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxMarginPanel.Name = "TextBoxMarginPanel";
            this.TextBoxMarginPanel.Size = new System.Drawing.Size(360, 1);
            this.TextBoxMarginPanel.TabIndex = 2;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.Label);
            this.LeftPanel.Controls.Add(this.LabelBottomMarginPanel);
            this.LeftPanel.Controls.Add(this.LabelTopMarginPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 1);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(160, 27);
            this.LeftPanel.TabIndex = 4;
            // 
            // Label
            // 
            this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(160, 27);
            this.Label.TabIndex = 7;
            this.Label.Text = "[Label Text]:";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelBottomMarginPanel
            // 
            this.LabelBottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelBottomMarginPanel.Location = new System.Drawing.Point(0, 27);
            this.LabelBottomMarginPanel.Name = "LabelBottomMarginPanel";
            this.LabelBottomMarginPanel.Size = new System.Drawing.Size(160, 0);
            this.LabelBottomMarginPanel.TabIndex = 6;
            // 
            // LabelTopMarginPanel
            // 
            this.LabelTopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelTopMarginPanel.Name = "LabelTopMarginPanel";
            this.LabelTopMarginPanel.Size = new System.Drawing.Size(160, 0);
            this.LabelTopMarginPanel.TabIndex = 5;
            // 
            // ComboBoxLeftMarginPanel
            // 
            this.ComboBoxLeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ComboBoxLeftMarginPanel.Location = new System.Drawing.Point(160, 1);
            this.ComboBoxLeftMarginPanel.Name = "ComboBoxLeftMarginPanel";
            this.ComboBoxLeftMarginPanel.Size = new System.Drawing.Size(2, 27);
            this.ComboBoxLeftMarginPanel.TabIndex = 5;
            // 
            // ComboBox
            // 
            this.ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Location = new System.Drawing.Point(162, 1);
            this.ComboBox.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(198, 31);
            this.ComboBox.Sorted = true;
            this.ComboBox.TabIndex = 6;
            this.ComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // LabelComboBoxControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.ComboBoxLeftMarginPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TextBoxMarginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LabelComboBoxControl";
            this.Size = new System.Drawing.Size(360, 28);
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
            #endregion

            private System.Windows.Forms.Panel LeftPanel;


        #endregion
            private System.Windows.Forms.Label Label;
            private System.Windows.Forms.Panel LabelBottomMarginPanel;
            private System.Windows.Forms.Panel LabelTopMarginPanel;
            private System.Windows.Forms.Panel ComboBoxLeftMarginPanel;
            private System.Windows.Forms.ComboBox ComboBox;

    } 
    #endregion
    
}
