

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class OrderByControl
    /// <summary>
    /// This is the designer file for the OrderByControl 
    /// </summary>
    partial class OrderByControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
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
            this.FieldControl1 = new DataTierClient.Controls.OrderByFieldControl();
            this.FieldControl2 = new DataTierClient.Controls.OrderByFieldControl();
            this.FieldControl3 = new DataTierClient.Controls.OrderByFieldControl();
            this.FieldControl4 = new DataTierClient.Controls.OrderByFieldControl();
            this.SuspendLayout();
            // 
            // FieldControl1
            // 
            this.FieldControl1.BackColor = System.Drawing.Color.Transparent;
            this.FieldControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FieldControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.FieldControl1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldControl1.Index = 0;
            this.FieldControl1.Location = new System.Drawing.Point(0, 0);
            this.FieldControl1.Name = "FieldControl1";
            this.FieldControl1.Size = new System.Drawing.Size(168, 48);
            this.FieldControl1.TabIndex = 18;
            // 
            // FieldControl2
            // 
            this.FieldControl2.BackColor = System.Drawing.Color.Transparent;
            this.FieldControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FieldControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.FieldControl2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldControl2.Index = 1;
            this.FieldControl2.Location = new System.Drawing.Point(168, 0);
            this.FieldControl2.Name = "FieldControl2";
            this.FieldControl2.Size = new System.Drawing.Size(168, 48);
            this.FieldControl2.TabIndex = 28;
            // 
            // FieldControl3
            // 
            this.FieldControl3.BackColor = System.Drawing.Color.Transparent;
            this.FieldControl3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FieldControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.FieldControl3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldControl3.Index = 2;
            this.FieldControl3.Location = new System.Drawing.Point(336, 0);
            this.FieldControl3.Name = "FieldControl3";
            this.FieldControl3.Size = new System.Drawing.Size(168, 48);
            this.FieldControl3.TabIndex = 34;
            // 
            // FieldControl4
            // 
            this.FieldControl4.BackColor = System.Drawing.Color.Transparent;
            this.FieldControl4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FieldControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.FieldControl4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldControl4.Index = 3;
            this.FieldControl4.Location = new System.Drawing.Point(504, 0);
            this.FieldControl4.Name = "FieldControl4";
            this.FieldControl4.Size = new System.Drawing.Size(168, 48);
            this.FieldControl4.TabIndex = 37;
            // 
            // OrderByControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DataTierClient.Properties.Resources.BlueWall;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.FieldControl4);
            this.Controls.Add(this.FieldControl3);
            this.Controls.Add(this.FieldControl2);
            this.Controls.Add(this.FieldControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrderByControl";
            this.Size = new System.Drawing.Size(960, 48);
            this.ResumeLayout(false);

            }
        #endregion

        #endregion
        private OrderByFieldControl FieldControl1;
        private OrderByFieldControl FieldControl2;
        private OrderByFieldControl FieldControl3;
        private OrderByFieldControl FieldControl4;
    }
    #endregion

}
