

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class CustomMethodsEditor
    /// <summary>
    /// This is the designer code for the CustomMethodsEditor control. 
    /// </summary>
    partial class CustomMethodsEditor
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
            this.LeftMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.RightMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.TopMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.TitlePanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.MethodsLabel = new System.Windows.Forms.Label();
            this.BottomMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.ButtonsPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.DeleteButton = new DataTierClient.Controls.TabButton();
            this.ButtonFillerPanel2 = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.EditButton = new DataTierClient.Controls.TabButton();
            this.ButtonFillerPanel1 = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.AddButton = new DataTierClient.Controls.TabButton();
            this.LeftMarginButtonPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.MethodsListBox = new System.Windows.Forms.ListBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.TitlePanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 380);
            this.LeftMarginPanel.TabIndex = 101;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(624, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 380);
            this.RightMarginPanel.TabIndex = 102;
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(16, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(608, 8);
            this.TopMarginPanel.TabIndex = 103;
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.MethodsLabel);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(16, 8);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(608, 32);
            this.TitlePanel.TabIndex = 104;
            // 
            // MethodsLabel
            // 
            this.MethodsLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MethodsLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodsLabel.Location = new System.Drawing.Point(0, 0);
            this.MethodsLabel.Name = "MethodsLabel";
            this.MethodsLabel.Size = new System.Drawing.Size(178, 32);
            this.MethodsLabel.TabIndex = 96;
            this.MethodsLabel.Text = "Custom Methods:";
            this.MethodsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(16, 368);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(608, 12);
            this.BottomMarginPanel.TabIndex = 105;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.DeleteButton);
            this.ButtonsPanel.Controls.Add(this.ButtonFillerPanel2);
            this.ButtonsPanel.Controls.Add(this.EditButton);
            this.ButtonsPanel.Controls.Add(this.ButtonFillerPanel1);
            this.ButtonsPanel.Controls.Add(this.AddButton);
            this.ButtonsPanel.Controls.Add(this.LeftMarginButtonPanel);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPanel.Location = new System.Drawing.Point(16, 328);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(608, 40);
            this.ButtonsPanel.TabIndex = 106;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.ButtonNumber = 0;
            this.DeleteButton.ButtonText = "Delete";
            this.DeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeleteButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(362, 0);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.Selected = false;
            this.DeleteButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.DeleteButton.ShowNotSelectedImageWhenDisabled = true;
            this.DeleteButton.Size = new System.Drawing.Size(84, 40);
            this.DeleteButton.TabIndex = 110;
            // 
            // ButtonFillerPanel2
            // 
            this.ButtonFillerPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonFillerPanel2.Location = new System.Drawing.Point(346, 0);
            this.ButtonFillerPanel2.Name = "ButtonFillerPanel2";
            this.ButtonFillerPanel2.Size = new System.Drawing.Size(16, 40);
            this.ButtonFillerPanel2.TabIndex = 109;
            // 
            // EditButton
            // 
            this.EditButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditButton.ButtonNumber = 0;
            this.EditButton.ButtonText = "Edit";
            this.EditButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.EditButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(262, 0);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.Selected = false;
            this.EditButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditButton.Size = new System.Drawing.Size(84, 40);
            this.EditButton.TabIndex = 107;
            // 
            // ButtonFillerPanel1
            // 
            this.ButtonFillerPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonFillerPanel1.Location = new System.Drawing.Point(246, 0);
            this.ButtonFillerPanel1.Name = "ButtonFillerPanel1";
            this.ButtonFillerPanel1.Size = new System.Drawing.Size(16, 40);
            this.ButtonFillerPanel1.TabIndex = 106;
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.ButtonNumber = 0;
            this.AddButton.ButtonText = "Add";
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(162, 0);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.AddButton.Selected = true;
            this.AddButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.AddButton.ShowNotSelectedImageWhenDisabled = true;
            this.AddButton.Size = new System.Drawing.Size(84, 40);
            this.AddButton.TabIndex = 105;
            // 
            // LeftMarginButtonPanel
            // 
            this.LeftMarginButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftMarginButtonPanel.Name = "LeftMarginButtonPanel";
            this.LeftMarginButtonPanel.Size = new System.Drawing.Size(162, 40);
            this.LeftMarginButtonPanel.TabIndex = 103;
            // 
            // MethodsListBox
            // 
            this.MethodsListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.MethodsListBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodsListBox.FormattingEnabled = true;
            this.MethodsListBox.ItemHeight = 26;
            this.MethodsListBox.Location = new System.Drawing.Point(16, 40);
            this.MethodsListBox.Name = "MethodsListBox";
            this.MethodsListBox.Size = new System.Drawing.Size(608, 238);
            this.MethodsListBox.TabIndex = 107;
            this.MethodsListBox.SelectedIndexChanged += new System.EventHandler(this.MethodsListBox_SelectedIndexChanged);
            this.MethodsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MethodsListBox_MouseDoubleClick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(16, 278);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(608, 24);
            this.InfoLabel.TabIndex = 108;
            this.InfoLabel.Text = "Double click to edit a method.";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CustomMethodsEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.MethodsListBox);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.TopMarginPanel);
            this.Controls.Add(this.RightMarginPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomMethodsEditor";
            this.Size = new System.Drawing.Size(640, 380);
            this.TitlePanel.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
        #endregion

        #endregion
        private DataJuggler.Win.Controls.Objects.PanelExtender LeftMarginPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender RightMarginPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender TopMarginPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender TitlePanel;
        private System.Windows.Forms.Label MethodsLabel;
        private DataJuggler.Win.Controls.Objects.PanelExtender BottomMarginPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender ButtonsPanel;
        private DataJuggler.Win.Controls.Objects.PanelExtender LeftMarginButtonPanel;
        private TabButton DeleteButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender ButtonFillerPanel2;
        private TabButton EditButton;
        private DataJuggler.Win.Controls.Objects.PanelExtender ButtonFillerPanel1;
        private TabButton AddButton;
        private System.Windows.Forms.ListBox MethodsListBox;
        private System.Windows.Forms.Label InfoLabel;
    }
    #endregion

}



