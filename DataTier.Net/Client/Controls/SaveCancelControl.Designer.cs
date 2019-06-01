
#region using statements

#endregion

namespace DataTierClient.Controls
{

    #region class SaveCancelControl
    /// <summary>
    /// This is the designer code for the SaveCancelControl
    /// </summary>
    partial class SaveCancelControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        internal System.Windows.Forms.Panel BottomPanel;
        internal System.Windows.Forms.Panel RightMargin;
        internal System.Windows.Forms.Panel FillerPanel1;
        private TabButton CancelSaveButton;
        private TabButton SaveButton;
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
                this.BottomPanel = new System.Windows.Forms.Panel();
                this.RightMargin = new System.Windows.Forms.Panel();
                this.CancelSaveButton = new DataTierClient.Controls.TabButton();
                this.FillerPanel1 = new System.Windows.Forms.Panel();
                this.SaveButton = new DataTierClient.Controls.TabButton();
                this.SuspendLayout();
                // 
                // BottomPanel
                // 
                this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.BottomPanel.Location = new System.Drawing.Point(0, 28);
                this.BottomPanel.Name = "BottomPanel";
                this.BottomPanel.Size = new System.Drawing.Size(510, 12);
                this.BottomPanel.TabIndex = 55;
                // 
                // RightMargin
                // 
                this.RightMargin.BackColor = System.Drawing.Color.Transparent;
                this.RightMargin.Dock = System.Windows.Forms.DockStyle.Right;
                this.RightMargin.Location = new System.Drawing.Point(494, 0);
                this.RightMargin.Name = "RightMargin";
                this.RightMargin.Size = new System.Drawing.Size(16, 28);
                this.RightMargin.TabIndex = 56;
                // 
                // CancelSaveButton
                // 
                this.CancelSaveButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
                this.CancelSaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.CancelSaveButton.ButtonNumber = 0;
                this.CancelSaveButton.ButtonText = "Cancel";
                this.CancelSaveButton.Dock = System.Windows.Forms.DockStyle.Right;
                this.CancelSaveButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.CancelSaveButton.Location = new System.Drawing.Point(414, 0);
                this.CancelSaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.CancelSaveButton.Name = "CancelSaveButton";
                this.CancelSaveButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
                this.CancelSaveButton.Selected = false;
                this.CancelSaveButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
                this.CancelSaveButton.ShowNotSelectedImageWhenDisabled = true;
                this.CancelSaveButton.Size = new System.Drawing.Size(80, 28);
                this.CancelSaveButton.TabIndex = 60;
                this.CancelSaveButton.Click += new System.EventHandler(this.CancelButton_Click);
                // 
                // FillerPanel1
                // 
                this.FillerPanel1.BackColor = System.Drawing.Color.Transparent;
                this.FillerPanel1.Dock = System.Windows.Forms.DockStyle.Right;
                this.FillerPanel1.Location = new System.Drawing.Point(402, 0);
                this.FillerPanel1.Name = "FillerPanel1";
                this.FillerPanel1.Size = new System.Drawing.Size(12, 28);
                this.FillerPanel1.TabIndex = 61;
                // 
                // SaveButton
                // 
                this.SaveButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
                this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.SaveButton.ButtonNumber = 0;
                this.SaveButton.ButtonText = "Save";
                this.SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
                this.SaveButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.SaveButton.Location = new System.Drawing.Point(322, 0);
                this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.SaveButton.Name = "SaveButton";
                this.SaveButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
                this.SaveButton.Selected = false;
                this.SaveButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
                this.SaveButton.ShowNotSelectedImageWhenDisabled = true;
                this.SaveButton.Size = new System.Drawing.Size(80, 28);
                this.SaveButton.TabIndex = 62;
                this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
                // 
                // SaveCancelControl
                // 
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackColor = System.Drawing.Color.Transparent;
                this.Controls.Add(this.SaveButton);
                this.Controls.Add(this.FillerPanel1);
                this.Controls.Add(this.CancelSaveButton);
                this.Controls.Add(this.RightMargin);
                this.Controls.Add(this.BottomPanel);
                this.Name = "SaveCancelControl";
                this.Size = new System.Drawing.Size(510, 40);
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
