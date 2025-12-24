
#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class TabButton
    /// <summary>
    /// This is the designer generated code for the TabButton control.
    /// </summary>
    partial class TabButton
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button MainButton;
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
            this.MainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainButton
            // 
            this.MainButton.BackColor = System.Drawing.Color.Transparent;
            this.MainButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MainButton.Location = new System.Drawing.Point(0, 0);
            this.MainButton.Name = "MainButton";
            this.MainButton.Size = new System.Drawing.Size(96, 32);
            this.MainButton.TabIndex = 2;
            this.MainButton.Text = "Button Text";
            this.MainButton.UseVisualStyleBackColor = false;
            this.MainButton.Click += new System.EventHandler(this.TabButton_Click);
            this.MainButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.MainButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // TabButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.MainButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TabButton";
            this.Size = new System.Drawing.Size(96, 32);
            this.EnabledChanged += new System.EventHandler(this.TabButton_EnabledChanged);
            this.Click += new System.EventHandler(this.TabButton_Click);
            this.ResumeLayout(false);

            }
            #endregion
            
        #endregion
        
    }
    #endregion

}


