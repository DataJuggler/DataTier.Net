namespace DataJuggler.Win.Controls
{
    partial class ListEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListEditorControl));
            this.BottomMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.TopMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.LeftMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.ListEditorPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.ButtonPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.AllItemsLabel = new System.Windows.Forms.Label();
            this.SeperatorPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.SelectedControlPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.EditControlPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.SelectedItemLabel = new System.Windows.Forms.Label();
            this.SavePanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.RightMarginPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.ListEditorPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SelectedControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomMarginPanel
            // 
            this.BottomMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.BottomMarginPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomMarginPanel.Location = new System.Drawing.Point(0, 304);
            this.BottomMarginPanel.Name = "BottomMarginPanel";
            this.BottomMarginPanel.Size = new System.Drawing.Size(320, 16);
            this.BottomMarginPanel.TabIndex = 13;
            // 
            // TopMarginPanel
            // 
            this.TopMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMarginPanel.Location = new System.Drawing.Point(0, 0);
            this.TopMarginPanel.Name = "TopMarginPanel";
            this.TopMarginPanel.Size = new System.Drawing.Size(320, 16);
            this.TopMarginPanel.TabIndex = 7;
            // 
            // LeftMarginPanel
            // 
            this.LeftMarginPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftMarginPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMarginPanel.Location = new System.Drawing.Point(0, 16);
            this.LeftMarginPanel.Name = "LeftMarginPanel";
            this.LeftMarginPanel.Size = new System.Drawing.Size(16, 288);
            this.LeftMarginPanel.TabIndex = 19;
            // 
            // ListEditorPanel
            // 
            this.ListEditorPanel.BackColor = System.Drawing.Color.Transparent;
            this.ListEditorPanel.Controls.Add(this.ListBox);
            this.ListEditorPanel.Controls.Add(this.ButtonPanel);
            this.ListEditorPanel.Controls.Add(this.AllItemsLabel);
            this.ListEditorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListEditorPanel.Location = new System.Drawing.Point(16, 16);
            this.ListEditorPanel.Name = "ListEditorPanel";
            this.ListEditorPanel.Size = new System.Drawing.Size(286, 288);
            this.ListEditorPanel.TabIndex = 21;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.DeleteButton);
            this.ButtonPanel.Controls.Add(this.EditButton);
            this.ButtonPanel.Controls.Add(this.AddButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 238);
            this.ButtonPanel.MaximumSize = new System.Drawing.Size(0, 50);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(286, 50);
            this.ButtonPanel.TabIndex = 16;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(191, 9);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(84, 36);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.EnabledChanged += new System.EventHandler(this.Button_EnableChanged);
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.DeleteButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.Transparent;
            this.EditButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditButton.BackgroundImage")));
            this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditButton.FlatAppearance.BorderSize = 0;
            this.EditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(101, 9);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(84, 36);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.EnabledChanged += new System.EventHandler(this.Button_EnableChanged);
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            this.EditButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.EditButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(11, 9);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(84, 36);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.EnabledChanged += new System.EventHandler(this.Button_EnableChanged);
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            this.AddButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.AddButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // AllItemsLabel
            // 
            this.AllItemsLabel.BackColor = System.Drawing.Color.Transparent;
            this.AllItemsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AllItemsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllItemsLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.AllItemsLabel.Location = new System.Drawing.Point(0, 0);
            this.AllItemsLabel.Name = "AllItemsLabel";
            this.AllItemsLabel.Size = new System.Drawing.Size(286, 20);
            this.AllItemsLabel.TabIndex = 18;
            this.AllItemsLabel.Text = "All Items";
            this.AllItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SeperatorPanel
            // 
            this.SeperatorPanel.BackColor = System.Drawing.Color.Transparent;
            this.SeperatorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SeperatorPanel.Location = new System.Drawing.Point(302, 16);
            this.SeperatorPanel.Name = "SeperatorPanel";
            this.SeperatorPanel.Size = new System.Drawing.Size(16, 288);
            this.SeperatorPanel.TabIndex = 22;
            // 
            // SelectedControlPanel
            // 
            this.SelectedControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.SelectedControlPanel.Controls.Add(this.EditControlPanel);
            this.SelectedControlPanel.Controls.Add(this.SelectedItemLabel);
            this.SelectedControlPanel.Controls.Add(this.SavePanel);
            this.SelectedControlPanel.Controls.Add(this.RightMarginPanel);
            this.SelectedControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedControlPanel.Location = new System.Drawing.Point(318, 16);
            this.SelectedControlPanel.Name = "SelectedControlPanel";
            this.SelectedControlPanel.Size = new System.Drawing.Size(2, 288);
            this.SelectedControlPanel.TabIndex = 23;
            this.SelectedControlPanel.Visible = false;
            // 
            // EditControlPanel
            // 
            this.EditControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditControlPanel.Location = new System.Drawing.Point(0, 20);
            this.EditControlPanel.Name = "EditControlPanel";
            this.EditControlPanel.Size = new System.Drawing.Size(0, 220);
            this.EditControlPanel.TabIndex = 11;
            // 
            // SelectedItemLabel
            // 
            this.SelectedItemLabel.BackColor = System.Drawing.Color.Transparent;
            this.SelectedItemLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectedItemLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedItemLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.SelectedItemLabel.Location = new System.Drawing.Point(0, 0);
            this.SelectedItemLabel.Name = "SelectedItemLabel";
            this.SelectedItemLabel.Size = new System.Drawing.Size(0, 20);
            this.SelectedItemLabel.TabIndex = 10;
            this.SelectedItemLabel.Text = "Selected Item";
            this.SelectedItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SavePanel
            // 
            this.SavePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SavePanel.Location = new System.Drawing.Point(0, 240);
            this.SavePanel.Name = "SavePanel";
            this.SavePanel.Size = new System.Drawing.Size(0, 48);
            this.SavePanel.TabIndex = 8;
            // 
            // RightMarginPanel
            // 
            this.RightMarginPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMarginPanel.Location = new System.Drawing.Point(-14, 0);
            this.RightMarginPanel.Name = "RightMarginPanel";
            this.RightMarginPanel.Size = new System.Drawing.Size(16, 288);
            this.RightMarginPanel.TabIndex = 3;
            // 
            // ListBox
            // 
            this.ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 18;
            this.ListBox.Location = new System.Drawing.Point(0, 20);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(286, 218);
            this.ListBox.TabIndex = 20;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // ListEditorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.SelectedControlPanel);
            this.Controls.Add(this.SeperatorPanel);
            this.Controls.Add(this.ListEditorPanel);
            this.Controls.Add(this.LeftMarginPanel);
            this.Controls.Add(this.BottomMarginPanel);
            this.Controls.Add(this.TopMarginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ListEditorControl";
            this.Size = new System.Drawing.Size(320, 320);
            this.ListEditorPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.SelectedControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Objects.PanelExtender TopMarginPanel;
        private Objects.PanelExtender BottomMarginPanel;
        private Objects.PanelExtender LeftMarginPanel;
        private Objects.PanelExtender ListEditorPanel;
        private System.Windows.Forms.Label AllItemsLabel;
        private Objects.PanelExtender ButtonPanel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private Objects.PanelExtender SeperatorPanel;
        private Objects.PanelExtender SelectedControlPanel;
        private Objects.PanelExtender EditControlPanel;
        private System.Windows.Forms.Label SelectedItemLabel;
        private Objects.PanelExtender SavePanel;
        private Objects.PanelExtender RightMarginPanel;
        private System.Windows.Forms.ListBox ListBox;
    }
}
