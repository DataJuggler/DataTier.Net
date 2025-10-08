

#region using statements


#endregion

namespace DataJuggler.Win.Controls
{

    #region class LabelSliderControl
    /// <summary>
    /// This class is the designer for the LabelTextBoxControl
    /// </summary>
    partial class LabelSliderControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel SliderPanel;
        private System.Windows.Forms.Panel TopMarginPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel SpacerPanel;
        private SliderControl SliderControl;
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
            this.SliderPanel = new System.Windows.Forms.Panel();
            this.TopMarginPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.LabelTextBoxControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.SpacerPanel = new System.Windows.Forms.Panel();
            this.SliderControl = new DataJuggler.Win.Controls.SliderControl();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SliderPanel
            // 
            this.SliderPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SliderPanel.Location = new System.Drawing.Point(320, 0);
            this.SliderPanel.MaximumSize = new System.Drawing.Size(0, 32);
            this.SliderPanel.Name = "SliderPanel";
            this.SliderPanel.Size = new System.Drawing.Size(0, 32);
            this.SliderPanel.TabIndex = 23;
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(320, 4);
            this.TopMarginPanel.TabIndex = 24;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.LabelTextBoxControl);
            this.LeftPanel.Controls.Add(this.SpacerPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 4);
            this.LeftPanel.MinimumSize = new System.Drawing.Size(0, 28);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(160, 32);
            this.LeftPanel.TabIndex = 25;
            // 
            // LabelTextBoxControl
            // 
            this.LabelTextBoxControl.BackColor = System.Drawing.Color.Transparent;
            this.LabelTextBoxControl.BottomMargin = 0;
            this.LabelTextBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTextBoxControl.Editable = true;
            this.LabelTextBoxControl.Encrypted = false;
            this.LabelTextBoxControl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTextBoxControl.LabelBottomMargin = 0;
            this.LabelTextBoxControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.LabelTextBoxControl.LabelFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTextBoxControl.LabelText = "[Label Text]:";
            this.LabelTextBoxControl.LabelTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelTextBoxControl.LabelTopMargin = 0;
            this.LabelTextBoxControl.LabelWidth = 120;
            this.LabelTextBoxControl.Location = new System.Drawing.Point(0, 0);
            this.LabelTextBoxControl.MinimumSize = new System.Drawing.Size(0, 28);
            this.LabelTextBoxControl.MultiLine = false;
            this.LabelTextBoxControl.Name = "LabelTextBoxControl";
            this.LabelTextBoxControl.OnTextChangedListener = null;
            this.LabelTextBoxControl.PasswordMode = false;
            this.LabelTextBoxControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LabelTextBoxControl.Size = new System.Drawing.Size(152, 32);
            this.LabelTextBoxControl.TabIndex = 12;
            this.LabelTextBoxControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.LabelTextBoxControl.TextBoxBottomMargin = 0;
            this.LabelTextBoxControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.LabelTextBoxControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.LabelTextBoxControl.TextBoxFont = null;
            this.LabelTextBoxControl.TextBoxTopMargin = 0;
            // 
            // SpacerPanel
            // 
            this.SpacerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SpacerPanel.Location = new System.Drawing.Point(152, 0);
            this.SpacerPanel.Name = "SpacerPanel";
            this.SpacerPanel.Size = new System.Drawing.Size(8, 32);
            this.SpacerPanel.TabIndex = 10;
            // 
            // SliderControl
            // 
            this.SliderControl.BackColor = System.Drawing.Color.Transparent;
            this.SliderControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SliderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SliderControl.Increments = 0;
            this.SliderControl.LabelTextBox = null;
            this.SliderControl.LargeChange = 5;
            this.SliderControl.Location = new System.Drawing.Point(160, 4);
            this.SliderControl.Maximum = 5;
            this.SliderControl.Minimum = 1;
            this.SliderControl.Name = "SliderControl";
            this.SliderControl.Size = new System.Drawing.Size(160, 32);
            this.SliderControl.SliderValue = 3;
            this.SliderControl.SmallChange = 1;
            this.SliderControl.TabIndex = 26;
            this.SliderControl.ValueChangedListener = null;
            // 
            // LabelSliderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SliderControl);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.SliderPanel);
            this.DoubleBuffered = true;
            this.Name = "LabelSliderControl";
            this.Size = new System.Drawing.Size(320, 36);
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
            #endregion

            private LabelTextBoxControl LabelTextBoxControl;
            
        #endregion
        
    }
    #endregion

}
