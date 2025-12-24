

namespace DataTierClient.Controls
{

    #region class WizardControlPanel
    /// <summary>
    /// The WizardControlPanel is the navigation buttons
    /// for the ContactWizardControl.
    /// </summary>
    partial class WizardControlPanel
    {
    
        #region Controls
        internal System.Windows.Forms.Panel BottomPanel;
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;
        internal System.Windows.Forms.Panel RightMargin;
        internal TabButton BackButton;
        internal TabButton DoneButton;
        internal TabButton SaveButton;
        internal TabButton NextButton;
        internal System.Windows.Forms.Panel FillerPanel1;
        internal System.Windows.Forms.Panel FillerPanel2;
        internal System.Windows.Forms.Panel FillerPanel3;
        internal System.Windows.Forms.Panel FillerPanel4;
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
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.FillerPanel1 = new System.Windows.Forms.Panel();
            this.RightMargin = new System.Windows.Forms.Panel();
            this.DoneButton = new DataTierClient.Controls.TabButton();
            this.FillerPanel2 = new System.Windows.Forms.Panel();
            this.SaveButton = new DataTierClient.Controls.TabButton();
            this.FillerPanel3 = new System.Windows.Forms.Panel();
            this.NextButton = new DataTierClient.Controls.TabButton();
            this.FillerPanel4 = new System.Windows.Forms.Panel();
            this.BackButton = new DataTierClient.Controls.TabButton();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 44);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(585, 8);
            this.BottomPanel.TabIndex = 24;
            // 
            // FillerPanel1
            // 
            this.FillerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.FillerPanel1.Location = new System.Drawing.Point(0, 0);
            this.FillerPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FillerPanel1.Name = "FillerPanel1";
            this.FillerPanel1.Size = new System.Drawing.Size(585, 8);
            this.FillerPanel1.TabIndex = 55;
            // 
            // RightMargin
            // 
            this.RightMargin.BackColor = System.Drawing.Color.Transparent;
            this.RightMargin.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMargin.Location = new System.Drawing.Point(569, 8);
            this.RightMargin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RightMargin.Name = "RightMargin";
            this.RightMargin.Size = new System.Drawing.Size(16, 36);
            this.RightMargin.TabIndex = 56;
            // 
            // DoneButton
            // 
            this.DoneButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DoneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoneButton.ButtonNumber = 0;
            this.DoneButton.ButtonText = "Done";
            this.DoneButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.DoneButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(489, 8);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DoneButton.Selected = false;
            this.DoneButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.DoneButton.ShowNotSelectedImageWhenDisabled = true;
            this.DoneButton.Size = new System.Drawing.Size(80, 36);
            this.DoneButton.TabIndex = 66;
            // 
            // FillerPanel2
            // 
            this.FillerPanel2.BackColor = System.Drawing.Color.Transparent;
            this.FillerPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.FillerPanel2.Location = new System.Drawing.Point(477, 8);
            this.FillerPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FillerPanel2.Name = "FillerPanel2";
            this.FillerPanel2.Size = new System.Drawing.Size(12, 36);
            this.FillerPanel2.TabIndex = 71;
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.ButtonNumber = 0;
            this.SaveButton.ButtonText = "Save";
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(397, 8);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.SaveButton.Selected = false;
            this.SaveButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.SaveButton.ShowNotSelectedImageWhenDisabled = true;
            this.SaveButton.Size = new System.Drawing.Size(80, 36);
            this.SaveButton.TabIndex = 73;
            // 
            // FillerPanel3
            // 
            this.FillerPanel3.BackColor = System.Drawing.Color.Transparent;
            this.FillerPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.FillerPanel3.Location = new System.Drawing.Point(385, 8);
            this.FillerPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FillerPanel3.Name = "FillerPanel3";
            this.FillerPanel3.Size = new System.Drawing.Size(12, 36);
            this.FillerPanel3.TabIndex = 76;
            // 
            // NextButton
            // 
            this.NextButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextButton.ButtonNumber = 0;
            this.NextButton.ButtonText = "Next";
            this.NextButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.NextButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(305, 8);
            this.NextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NextButton.Name = "NextButton";
            this.NextButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.NextButton.Selected = false;
            this.NextButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.NextButton.ShowNotSelectedImageWhenDisabled = true;
            this.NextButton.Size = new System.Drawing.Size(80, 36);
            this.NextButton.TabIndex = 78;
            // 
            // FillerPanel4
            // 
            this.FillerPanel4.BackColor = System.Drawing.Color.Transparent;
            this.FillerPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.FillerPanel4.Location = new System.Drawing.Point(293, 8);
            this.FillerPanel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FillerPanel4.Name = "FillerPanel4";
            this.FillerPanel4.Size = new System.Drawing.Size(12, 36);
            this.FillerPanel4.TabIndex = 79;
            // 
            // BackButton
            // 
            this.BackButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.BackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackButton.ButtonNumber = 0;
            this.BackButton.ButtonText = "Back";
            this.BackButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BackButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(213, 8);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BackButton.Name = "BackButton";
            this.BackButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.BackButton.Selected = false;
            this.BackButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.BackButton.ShowNotSelectedImageWhenDisabled = true;
            this.BackButton.Size = new System.Drawing.Size(80, 36);
            this.BackButton.TabIndex = 80;
            // 
            // WizardControlPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FillerPanel4);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.FillerPanel3);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.FillerPanel2);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.RightMargin);
            this.Controls.Add(this.FillerPanel1);
            this.Controls.Add(this.BottomPanel);
            this.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WizardControlPanel";
            this.Size = new System.Drawing.Size(585, 52);
            this.ResumeLayout(false);

            } 
            #endregion

        #endregion

    }
    #endregion
    
}


