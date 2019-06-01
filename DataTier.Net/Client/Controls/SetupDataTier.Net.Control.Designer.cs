

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class SetupDataTierNetControl
    /// <summary>
    /// This is the designer code for the SetupDataTierNetControl control.
    /// </summary>
    partial class SetupDataTierNetControl
    {
        
        #region Private Variables
        internal TabButton LaunchConfigManagerButton;
        internal TabButton DontShowAgainButton;
        internal TabButton TestConnectionButton;
        private System.Windows.Forms.PictureBox GettingStarted;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label WritersLabel;
        private System.Windows.Forms.PictureBox Information;
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDataTierNetControl));
                this.WritersLabel = new System.Windows.Forms.Label();
                this.Information = new System.Windows.Forms.PictureBox();
                this.GettingStarted = new System.Windows.Forms.PictureBox();
                this.TestConnectionButton = new DataTierClient.Controls.TabButton();
                this.DontShowAgainButton = new DataTierClient.Controls.TabButton();
                this.LaunchConfigManagerButton = new DataTierClient.Controls.TabButton();
                ((System.ComponentModel.ISupportInitialize)(this.Information)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.GettingStarted)).BeginInit();
                this.SuspendLayout();
                // 
                // WritersLabel
                // 
                this.WritersLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.WritersLabel.ForeColor = System.Drawing.Color.Firebrick;
                this.WritersLabel.Location = new System.Drawing.Point(309, 553);
                this.WritersLabel.Name = "WritersLabel";
                this.WritersLabel.Size = new System.Drawing.Size(359, 23);
                this.WritersLabel.TabIndex = 89;
                this.WritersLabel.Text = "After the connectionstring is set in app.config";
                this.WritersLabel.Visible = false;
                // 
                // Information
                // 
                this.Information.BackgroundImage = global::DataTierClient.Properties.Resources.Information2;
                this.Information.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Information.Location = new System.Drawing.Point(656, 581);
                this.Information.Name = "Information";
                this.Information.Size = new System.Drawing.Size(32, 32);
                this.Information.TabIndex = 90;
                this.Information.TabStop = false;
                this.Information.MouseEnter += new System.EventHandler(this.Information_MouseEnter);
                this.Information.MouseLeave += new System.EventHandler(this.Information_MouseLeave);
                this.Information.MouseHover += new System.EventHandler(this.Information_MouseHover);
                // 
                // GettingStarted
                // 
                this.GettingStarted.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GettingStarted.BackgroundImage")));
                this.GettingStarted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.GettingStarted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.GettingStarted.Location = new System.Drawing.Point(29, 24);
                this.GettingStarted.Name = "GettingStarted";
                this.GettingStarted.Size = new System.Drawing.Size(660, 520);
                this.GettingStarted.TabIndex = 88;
                this.GettingStarted.TabStop = false;
                // 
                // TestConnectionButton
                // 
                this.TestConnectionButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TestConnectionButton.BackgroundImage")));
                this.TestConnectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.TestConnectionButton.ButtonNumber = 2;
                this.TestConnectionButton.ButtonText = "Test Database Connection";
                this.TestConnectionButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.TestConnectionButton.Location = new System.Drawing.Point(397, 577);
                this.TestConnectionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.TestConnectionButton.Name = "TestConnectionButton";
                this.TestConnectionButton.NotSelectedImage = null;
                this.TestConnectionButton.Selected = true;
                this.TestConnectionButton.SelectedImage = null;
                this.TestConnectionButton.ShowNotSelectedImageWhenDisabled = true;
                this.TestConnectionButton.Size = new System.Drawing.Size(251, 40);
                this.TestConnectionButton.TabIndex = 87;
                // 
                // DontShowAgainButton
                // 
                this.DontShowAgainButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DontShowAgainButton.BackgroundImage")));
                this.DontShowAgainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.DontShowAgainButton.ButtonNumber = 3;
                this.DontShowAgainButton.ButtonText = "Database Setup Is Complete; Don\'t Show This Message Again";
                this.DontShowAgainButton.Enabled = false;
                this.DontShowAgainButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.DontShowAgainButton.Location = new System.Drawing.Point(71, 626);
                this.DontShowAgainButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.DontShowAgainButton.Name = "DontShowAgainButton";
                this.DontShowAgainButton.NotSelectedImage = null;
                this.DontShowAgainButton.Selected = true;
                this.DontShowAgainButton.SelectedImage = null;
                this.DontShowAgainButton.ShowNotSelectedImageWhenDisabled = true;
                this.DontShowAgainButton.Size = new System.Drawing.Size(577, 40);
                this.DontShowAgainButton.TabIndex = 86;
                // 
                // LaunchConfigManagerButton
                // 
                this.LaunchConfigManagerButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LaunchConfigManagerButton.BackgroundImage")));
                this.LaunchConfigManagerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.LaunchConfigManagerButton.ButtonNumber = 1;
                this.LaunchConfigManagerButton.ButtonText = "Launch Connection String Builder";
                this.LaunchConfigManagerButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.LaunchConfigManagerButton.Location = new System.Drawing.Point(71, 577);
                this.LaunchConfigManagerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                this.LaunchConfigManagerButton.Name = "LaunchConfigManagerButton";
                this.LaunchConfigManagerButton.NotSelectedImage = null;
                this.LaunchConfigManagerButton.Selected = true;
                this.LaunchConfigManagerButton.SelectedImage = null;
                this.LaunchConfigManagerButton.ShowNotSelectedImageWhenDisabled = true;
                this.LaunchConfigManagerButton.Size = new System.Drawing.Size(318, 40);
                this.LaunchConfigManagerButton.TabIndex = 85;
                // 
                // SetupDataTierNetControl
                // 
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackColor = System.Drawing.Color.Linen;
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.Controls.Add(this.Information);
                this.Controls.Add(this.WritersLabel);
                this.Controls.Add(this.GettingStarted);
                this.Controls.Add(this.TestConnectionButton);
                this.Controls.Add(this.DontShowAgainButton);
                this.Controls.Add(this.LaunchConfigManagerButton);
                this.Name = "SetupDataTierNetControl";
                this.Size = new System.Drawing.Size(720, 680);
                ((System.ComponentModel.ISupportInitialize)(this.Information)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.GettingStarted)).EndInit();
                this.ResumeLayout(false);
                
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
