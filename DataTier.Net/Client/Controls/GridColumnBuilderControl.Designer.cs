
namespace DataTierClient.Controls
{
    partial class GridColumnBuilderControl
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
            this.components = new System.ComponentModel.Container();
            this.AvailableFieldsListBox = new System.Windows.Forms.ListBox();
            this.AvailableFieldsLabel = new System.Windows.Forms.Label();
            this.AssignedFieldsLabel = new System.Windows.Forms.Label();
            this.AssignedFieldsListBox = new System.Windows.Forms.ListBox();
            this.AssignAllButton = new System.Windows.Forms.PictureBox();
            this.AssignSelectedButton = new System.Windows.Forms.PictureBox();
            this.RemoveSelectedButton = new System.Windows.Forms.PictureBox();
            this.RemoveAllButton = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SelectedTableTextBox = new System.Windows.Forms.TextBox();
            this.SelectedTableLabel = new System.Windows.Forms.Label();
            this.CreateGridColumnsButton = new System.Windows.Forms.Button();
            this.SelectedFieldTextBox = new System.Windows.Forms.TextBox();
            this.SelectedFieldLabel = new System.Windows.Forms.Label();
            this.CaptionTextBox = new System.Windows.Forms.TextBox();
            this.CaptionLabel = new System.Windows.Forms.Label();
            this.DataTypeTextBox = new System.Windows.Forms.TextBox();
            this.DataTypeLabel = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.FontBoldLabel = new System.Windows.Forms.Label();
            this.DefaultValuesLabel = new System.Windows.Forms.Label();
            this.FontBoldCheckBox = new System.Windows.Forms.CheckBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.FontSizeTextBox = new System.Windows.Forms.TextBox();
            this.FontSizeLabel = new System.Windows.Forms.Label();
            this.FontNameTextBox = new System.Windows.Forms.TextBox();
            this.FontNameLabel = new System.Windows.Forms.Label();
            this.FormatTextBox = new System.Windows.Forms.TextBox();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.ClassNameTextBox = new System.Windows.Forms.TextBox();
            this.ClassNameLabel = new System.Windows.Forms.Label();
            this.ParentTextBox = new System.Windows.Forms.TextBox();
            this.ParentLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.ImageCheckBox = new System.Windows.Forms.CheckBox();
            this.IsImageLabel = new System.Windows.Forms.Label();
            this.ImageButtonCheckBox = new System.Windows.Forms.CheckBox();
            this.ImageButtonLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AssignAllButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignSelectedButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveSelectedButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveAllButton)).BeginInit();
            this.SuspendLayout();
            // 
            // AvailableFieldsListBox
            // 
            this.AvailableFieldsListBox.FormattingEnabled = true;
            this.AvailableFieldsListBox.ItemHeight = 26;
            this.AvailableFieldsListBox.Location = new System.Drawing.Point(32, 54);
            this.AvailableFieldsListBox.Name = "AvailableFieldsListBox";
            this.AvailableFieldsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AvailableFieldsListBox.Size = new System.Drawing.Size(260, 576);
            this.AvailableFieldsListBox.TabIndex = 0;
            // 
            // AvailableFieldsLabel
            // 
            this.AvailableFieldsLabel.BackColor = System.Drawing.Color.Transparent;
            this.AvailableFieldsLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.AvailableFieldsLabel.Location = new System.Drawing.Point(32, 24);
            this.AvailableFieldsLabel.Name = "AvailableFieldsLabel";
            this.AvailableFieldsLabel.Size = new System.Drawing.Size(158, 27);
            this.AvailableFieldsLabel.TabIndex = 1;
            this.AvailableFieldsLabel.Text = "Available Fields:";
            this.AvailableFieldsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AssignedFieldsLabel
            // 
            this.AssignedFieldsLabel.BackColor = System.Drawing.Color.Transparent;
            this.AssignedFieldsLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.AssignedFieldsLabel.Location = new System.Drawing.Point(572, 24);
            this.AssignedFieldsLabel.Name = "AssignedFieldsLabel";
            this.AssignedFieldsLabel.Size = new System.Drawing.Size(158, 27);
            this.AssignedFieldsLabel.TabIndex = 3;
            this.AssignedFieldsLabel.Text = "Assigned Fields:";
            this.AssignedFieldsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AssignedFieldsListBox
            // 
            this.AssignedFieldsListBox.FormattingEnabled = true;
            this.AssignedFieldsListBox.ItemHeight = 26;
            this.AssignedFieldsListBox.Location = new System.Drawing.Point(572, 55);
            this.AssignedFieldsListBox.Name = "AssignedFieldsListBox";
            this.AssignedFieldsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AssignedFieldsListBox.Size = new System.Drawing.Size(260, 576);
            this.AssignedFieldsListBox.TabIndex = 2;
            this.AssignedFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.AssignedFieldsListBox_SelectedIndexChanged);
            // 
            // AssignAllButton
            // 
            this.AssignAllButton.BackColor = System.Drawing.Color.Transparent;
            this.AssignAllButton.BackgroundImage = global::DataTierClient.Properties.Resources.VCRLastLight;
            this.AssignAllButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AssignAllButton.Location = new System.Drawing.Point(400, 114);
            this.AssignAllButton.Name = "AssignAllButton";
            this.AssignAllButton.Size = new System.Drawing.Size(64, 64);
            this.AssignAllButton.TabIndex = 4;
            this.AssignAllButton.TabStop = false;
            this.ToolTip.SetToolTip(this.AssignAllButton, "Assign All Fields");
            this.AssignAllButton.Click += new System.EventHandler(this.AssignAllButton_Click);
            this.AssignAllButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.AssignAllButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // AssignSelectedButton
            // 
            this.AssignSelectedButton.BackColor = System.Drawing.Color.Transparent;
            this.AssignSelectedButton.BackgroundImage = global::DataTierClient.Properties.Resources.VCRNextLight;
            this.AssignSelectedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AssignSelectedButton.Location = new System.Drawing.Point(400, 206);
            this.AssignSelectedButton.Name = "AssignSelectedButton";
            this.AssignSelectedButton.Size = new System.Drawing.Size(64, 64);
            this.AssignSelectedButton.TabIndex = 5;
            this.AssignSelectedButton.TabStop = false;
            this.ToolTip.SetToolTip(this.AssignSelectedButton, "Assign Selected Fields");
            this.AssignSelectedButton.Click += new System.EventHandler(this.AssignSelectedButton_Click);
            this.AssignSelectedButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.AssignSelectedButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // RemoveSelectedButton
            // 
            this.RemoveSelectedButton.BackColor = System.Drawing.Color.Transparent;
            this.RemoveSelectedButton.BackgroundImage = global::DataTierClient.Properties.Resources.VCRPrevLight;
            this.RemoveSelectedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveSelectedButton.Location = new System.Drawing.Point(400, 298);
            this.RemoveSelectedButton.Name = "RemoveSelectedButton";
            this.RemoveSelectedButton.Size = new System.Drawing.Size(64, 64);
            this.RemoveSelectedButton.TabIndex = 6;
            this.RemoveSelectedButton.TabStop = false;
            this.ToolTip.SetToolTip(this.RemoveSelectedButton, "Remove Selected Fields");
            this.RemoveSelectedButton.Click += new System.EventHandler(this.RemoveSelectedButton_Click);
            this.RemoveSelectedButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.RemoveSelectedButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // RemoveAllButton
            // 
            this.RemoveAllButton.BackColor = System.Drawing.Color.Transparent;
            this.RemoveAllButton.BackgroundImage = global::DataTierClient.Properties.Resources.VCRFirstLight;
            this.RemoveAllButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveAllButton.Location = new System.Drawing.Point(400, 390);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Size = new System.Drawing.Size(64, 64);
            this.RemoveAllButton.TabIndex = 7;
            this.RemoveAllButton.TabStop = false;
            this.ToolTip.SetToolTip(this.RemoveAllButton, "Remove All Fields");
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            this.RemoveAllButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.RemoveAllButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // SelectedTableTextBox
            // 
            this.SelectedTableTextBox.Location = new System.Drawing.Point(316, 54);
            this.SelectedTableTextBox.Name = "SelectedTableTextBox";
            this.SelectedTableTextBox.ReadOnly = true;
            this.SelectedTableTextBox.Size = new System.Drawing.Size(232, 34);
            this.SelectedTableTextBox.TabIndex = 10;
            // 
            // SelectedTableLabel
            // 
            this.SelectedTableLabel.BackColor = System.Drawing.Color.Transparent;
            this.SelectedTableLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.SelectedTableLabel.Location = new System.Drawing.Point(316, 24);
            this.SelectedTableLabel.Name = "SelectedTableLabel";
            this.SelectedTableLabel.Size = new System.Drawing.Size(158, 27);
            this.SelectedTableLabel.TabIndex = 9;
            this.SelectedTableLabel.Text = "Selected Table:";
            this.SelectedTableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreateGridColumnsButton
            // 
            this.CreateGridColumnsButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateGridColumnsButton.BackgroundImage = global::DataTierClient.Properties.Resources.BlackButton;
            this.CreateGridColumnsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateGridColumnsButton.FlatAppearance.BorderSize = 0;
            this.CreateGridColumnsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CreateGridColumnsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CreateGridColumnsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateGridColumnsButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateGridColumnsButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CreateGridColumnsButton.Location = new System.Drawing.Point(316, 590);
            this.CreateGridColumnsButton.Name = "CreateGridColumnsButton";
            this.CreateGridColumnsButton.Size = new System.Drawing.Size(232, 44);
            this.CreateGridColumnsButton.TabIndex = 109;
            this.CreateGridColumnsButton.Text = "Create Grid Columns";
            this.CreateGridColumnsButton.UseVisualStyleBackColor = false;
            this.CreateGridColumnsButton.Click += new System.EventHandler(this.CreateGridColumnsButton_Click);
            this.CreateGridColumnsButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CreateGridColumnsButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // SelectedFieldTextBox
            // 
            this.SelectedFieldTextBox.Enabled = false;
            this.SelectedFieldTextBox.Location = new System.Drawing.Point(856, 55);
            this.SelectedFieldTextBox.Name = "SelectedFieldTextBox";
            this.SelectedFieldTextBox.ReadOnly = true;
            this.SelectedFieldTextBox.Size = new System.Drawing.Size(232, 34);
            this.SelectedFieldTextBox.TabIndex = 111;
            // 
            // SelectedFieldLabel
            // 
            this.SelectedFieldLabel.BackColor = System.Drawing.Color.Transparent;
            this.SelectedFieldLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFieldLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.SelectedFieldLabel.Location = new System.Drawing.Point(856, 24);
            this.SelectedFieldLabel.Name = "SelectedFieldLabel";
            this.SelectedFieldLabel.Size = new System.Drawing.Size(158, 27);
            this.SelectedFieldLabel.TabIndex = 110;
            this.SelectedFieldLabel.Text = "Selected Field:";
            this.SelectedFieldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CaptionTextBox
            // 
            this.CaptionTextBox.BackColor = System.Drawing.Color.White;
            this.CaptionTextBox.Location = new System.Drawing.Point(856, 124);
            this.CaptionTextBox.Name = "CaptionTextBox";
            this.CaptionTextBox.Size = new System.Drawing.Size(232, 34);
            this.CaptionTextBox.TabIndex = 113;
            this.CaptionTextBox.TextChanged += new System.EventHandler(this.CaptionTextBox_TextChanged);
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.CaptionLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.CaptionLabel.Location = new System.Drawing.Point(856, 96);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(158, 27);
            this.CaptionLabel.TabIndex = 112;
            this.CaptionLabel.Text = "Caption:";
            this.CaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataTypeTextBox
            // 
            this.DataTypeTextBox.BackColor = System.Drawing.Color.White;
            this.DataTypeTextBox.Enabled = false;
            this.DataTypeTextBox.Location = new System.Drawing.Point(856, 200);
            this.DataTypeTextBox.Name = "DataTypeTextBox";
            this.DataTypeTextBox.ReadOnly = true;
            this.DataTypeTextBox.Size = new System.Drawing.Size(232, 34);
            this.DataTypeTextBox.TabIndex = 115;
            // 
            // DataTypeLabel
            // 
            this.DataTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.DataTypeLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTypeLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.DataTypeLabel.Location = new System.Drawing.Point(856, 172);
            this.DataTypeLabel.Name = "DataTypeLabel";
            this.DataTypeLabel.Size = new System.Drawing.Size(158, 27);
            this.DataTypeLabel.TabIndex = 114;
            this.DataTypeLabel.Text = "Data Type:";
            this.DataTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.BackColor = System.Drawing.Color.White;
            this.WidthTextBox.Location = new System.Drawing.Point(856, 276);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(232, 34);
            this.WidthTextBox.TabIndex = 117;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.BackColor = System.Drawing.Color.Transparent;
            this.WidthLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidthLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.WidthLabel.Location = new System.Drawing.Point(856, 248);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(158, 27);
            this.WidthLabel.TabIndex = 116;
            this.WidthLabel.Text = "Width:";
            this.WidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontBoldLabel
            // 
            this.FontBoldLabel.BackColor = System.Drawing.Color.Transparent;
            this.FontBoldLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontBoldLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.FontBoldLabel.Location = new System.Drawing.Point(854, 471);
            this.FontBoldLabel.Name = "FontBoldLabel";
            this.FontBoldLabel.Size = new System.Drawing.Size(134, 27);
            this.FontBoldLabel.TabIndex = 118;
            this.FontBoldLabel.Text = "Font Bold:";
            this.FontBoldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DefaultValuesLabel
            // 
            this.DefaultValuesLabel.BackColor = System.Drawing.Color.Transparent;
            this.DefaultValuesLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultValuesLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.DefaultValuesLabel.Location = new System.Drawing.Point(1128, 24);
            this.DefaultValuesLabel.Name = "DefaultValuesLabel";
            this.DefaultValuesLabel.Size = new System.Drawing.Size(158, 27);
            this.DefaultValuesLabel.TabIndex = 121;
            this.DefaultValuesLabel.Text = "Default Values";
            this.DefaultValuesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontBoldCheckBox
            // 
            this.FontBoldCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.FontBoldCheckBox.Font = new System.Drawing.Font("Calibri", 16F);
            this.FontBoldCheckBox.ForeColor = System.Drawing.Color.Coral;
            this.FontBoldCheckBox.Location = new System.Drawing.Point(996, 471);
            this.FontBoldCheckBox.Name = "FontBoldCheckBox";
            this.FontBoldCheckBox.Size = new System.Drawing.Size(28, 29);
            this.FontBoldCheckBox.TabIndex = 122;
            this.FontBoldCheckBox.UseVisualStyleBackColor = false;
            this.FontBoldCheckBox.CheckedChanged += new System.EventHandler(this.FontBoldCheckBox_CheckedChanged);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.BackColor = System.Drawing.Color.White;
            this.HeightTextBox.Location = new System.Drawing.Point(1128, 276);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(125, 34);
            this.HeightTextBox.TabIndex = 128;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // HeightLabel
            // 
            this.HeightLabel.BackColor = System.Drawing.Color.Transparent;
            this.HeightLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeightLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.HeightLabel.Location = new System.Drawing.Point(1128, 248);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(158, 27);
            this.HeightLabel.TabIndex = 127;
            this.HeightLabel.Text = "Height:";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontSizeTextBox
            // 
            this.FontSizeTextBox.BackColor = System.Drawing.Color.White;
            this.FontSizeTextBox.Enabled = false;
            this.FontSizeTextBox.Location = new System.Drawing.Point(1128, 200);
            this.FontSizeTextBox.Name = "FontSizeTextBox";
            this.FontSizeTextBox.Size = new System.Drawing.Size(125, 34);
            this.FontSizeTextBox.TabIndex = 126;
            this.FontSizeTextBox.TextChanged += new System.EventHandler(this.FontSizeTextBox_TextChanged);
            // 
            // FontSizeLabel
            // 
            this.FontSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.FontSizeLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontSizeLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.FontSizeLabel.Location = new System.Drawing.Point(1128, 172);
            this.FontSizeLabel.Name = "FontSizeLabel";
            this.FontSizeLabel.Size = new System.Drawing.Size(158, 27);
            this.FontSizeLabel.TabIndex = 125;
            this.FontSizeLabel.Text = "Font Size:";
            this.FontSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontNameTextBox
            // 
            this.FontNameTextBox.BackColor = System.Drawing.Color.White;
            this.FontNameTextBox.Location = new System.Drawing.Point(1128, 125);
            this.FontNameTextBox.Name = "FontNameTextBox";
            this.FontNameTextBox.Size = new System.Drawing.Size(232, 34);
            this.FontNameTextBox.TabIndex = 124;
            this.FontNameTextBox.TextChanged += new System.EventHandler(this.FontNameTextBox_TextChanged);
            // 
            // FontNameLabel
            // 
            this.FontNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.FontNameLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontNameLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.FontNameLabel.Location = new System.Drawing.Point(1128, 96);
            this.FontNameLabel.Name = "FontNameLabel";
            this.FontNameLabel.Size = new System.Drawing.Size(158, 27);
            this.FontNameLabel.TabIndex = 123;
            this.FontNameLabel.Text = "Font Name:";
            this.FontNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormatTextBox
            // 
            this.FormatTextBox.BackColor = System.Drawing.Color.White;
            this.FormatTextBox.Location = new System.Drawing.Point(856, 352);
            this.FormatTextBox.Name = "FormatTextBox";
            this.FormatTextBox.Size = new System.Drawing.Size(232, 34);
            this.FormatTextBox.TabIndex = 130;
            this.FormatTextBox.TextChanged += new System.EventHandler(this.FormatTextBox_TextChanged);
            // 
            // FormatLabel
            // 
            this.FormatLabel.BackColor = System.Drawing.Color.Transparent;
            this.FormatLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.FormatLabel.Location = new System.Drawing.Point(856, 324);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(158, 27);
            this.FormatLabel.TabIndex = 129;
            this.FormatLabel.Text = "Format:";
            this.FormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClassNameTextBox
            // 
            this.ClassNameTextBox.BackColor = System.Drawing.Color.White;
            this.ClassNameTextBox.Location = new System.Drawing.Point(856, 428);
            this.ClassNameTextBox.Name = "ClassNameTextBox";
            this.ClassNameTextBox.Size = new System.Drawing.Size(504, 34);
            this.ClassNameTextBox.TabIndex = 132;
            // 
            // ClassNameLabel
            // 
            this.ClassNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClassNameLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassNameLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ClassNameLabel.Location = new System.Drawing.Point(856, 400);
            this.ClassNameLabel.Name = "ClassNameLabel";
            this.ClassNameLabel.Size = new System.Drawing.Size(158, 27);
            this.ClassNameLabel.TabIndex = 131;
            this.ClassNameLabel.Text = "Class Name:";
            this.ClassNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ParentTextBox
            // 
            this.ParentTextBox.BackColor = System.Drawing.Color.White;
            this.ParentTextBox.Location = new System.Drawing.Point(1128, 352);
            this.ParentTextBox.Name = "ParentTextBox";
            this.ParentTextBox.Size = new System.Drawing.Size(232, 34);
            this.ParentTextBox.TabIndex = 134;
            this.ParentTextBox.TextChanged += new System.EventHandler(this.ParentTextBox_TextChanged);
            // 
            // ParentLabel
            // 
            this.ParentLabel.BackColor = System.Drawing.Color.Transparent;
            this.ParentLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParentLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ParentLabel.Location = new System.Drawing.Point(1128, 326);
            this.ParentLabel.Name = "ParentLabel";
            this.ParentLabel.Size = new System.Drawing.Size(202, 27);
            this.ParentLabel.TabIndex = 133;
            this.ParentLabel.Text = "Parent (Grid Name):";
            this.ParentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.StatusLabel.Location = new System.Drawing.Point(856, 590);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(504, 40);
            this.StatusLabel.TabIndex = 135;
            this.StatusLabel.Text = "Success";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StatusLabel.Visible = false;
            // 
            // StatusTimer
            // 
            this.StatusTimer.Interval = 5000;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // ImageCheckBox
            // 
            this.ImageCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ImageCheckBox.Font = new System.Drawing.Font("Calibri", 16F);
            this.ImageCheckBox.ForeColor = System.Drawing.Color.Coral;
            this.ImageCheckBox.Location = new System.Drawing.Point(996, 507);
            this.ImageCheckBox.Name = "ImageCheckBox";
            this.ImageCheckBox.Size = new System.Drawing.Size(28, 29);
            this.ImageCheckBox.TabIndex = 137;
            this.ImageCheckBox.UseVisualStyleBackColor = false;
            // 
            // IsImageLabel
            // 
            this.IsImageLabel.BackColor = System.Drawing.Color.Transparent;
            this.IsImageLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsImageLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.IsImageLabel.Location = new System.Drawing.Point(854, 507);
            this.IsImageLabel.Name = "IsImageLabel";
            this.IsImageLabel.Size = new System.Drawing.Size(134, 27);
            this.IsImageLabel.TabIndex = 136;
            this.IsImageLabel.Text = "Is Image:";
            this.IsImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImageButtonCheckBox
            // 
            this.ImageButtonCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ImageButtonCheckBox.Font = new System.Drawing.Font("Calibri", 16F);
            this.ImageButtonCheckBox.ForeColor = System.Drawing.Color.Coral;
            this.ImageButtonCheckBox.Location = new System.Drawing.Point(996, 546);
            this.ImageButtonCheckBox.Name = "ImageButtonCheckBox";
            this.ImageButtonCheckBox.Size = new System.Drawing.Size(28, 29);
            this.ImageButtonCheckBox.TabIndex = 139;
            this.ImageButtonCheckBox.UseVisualStyleBackColor = false;
            // 
            // ImageButtonLabel
            // 
            this.ImageButtonLabel.BackColor = System.Drawing.Color.Transparent;
            this.ImageButtonLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageButtonLabel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ImageButtonLabel.Location = new System.Drawing.Point(854, 547);
            this.ImageButtonLabel.Name = "ImageButtonLabel";
            this.ImageButtonLabel.Size = new System.Drawing.Size(134, 27);
            this.ImageButtonLabel.TabIndex = 138;
            this.ImageButtonLabel.Text = "Image Button:";
            this.ImageButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridColumnBuilderControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::DataTierClient.Properties.Resources.Deep_Black;
            this.Controls.Add(this.ImageButtonCheckBox);
            this.Controls.Add(this.ImageButtonLabel);
            this.Controls.Add(this.ImageCheckBox);
            this.Controls.Add(this.IsImageLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ParentTextBox);
            this.Controls.Add(this.ParentLabel);
            this.Controls.Add(this.ClassNameTextBox);
            this.Controls.Add(this.ClassNameLabel);
            this.Controls.Add(this.FormatTextBox);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.FontSizeTextBox);
            this.Controls.Add(this.FontSizeLabel);
            this.Controls.Add(this.FontNameTextBox);
            this.Controls.Add(this.FontNameLabel);
            this.Controls.Add(this.FontBoldCheckBox);
            this.Controls.Add(this.DefaultValuesLabel);
            this.Controls.Add(this.FontBoldLabel);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.DataTypeTextBox);
            this.Controls.Add(this.DataTypeLabel);
            this.Controls.Add(this.CaptionTextBox);
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.SelectedFieldTextBox);
            this.Controls.Add(this.SelectedFieldLabel);
            this.Controls.Add(this.CreateGridColumnsButton);
            this.Controls.Add(this.SelectedTableTextBox);
            this.Controls.Add(this.SelectedTableLabel);
            this.Controls.Add(this.RemoveAllButton);
            this.Controls.Add(this.RemoveSelectedButton);
            this.Controls.Add(this.AssignSelectedButton);
            this.Controls.Add(this.AssignAllButton);
            this.Controls.Add(this.AssignedFieldsLabel);
            this.Controls.Add(this.AssignedFieldsListBox);
            this.Controls.Add(this.AvailableFieldsLabel);
            this.Controls.Add(this.AvailableFieldsListBox);
            this.Font = new System.Drawing.Font("Calibri", 16F);
            this.Name = "GridColumnBuilderControl";
            this.Size = new System.Drawing.Size(1384, 664);
            ((System.ComponentModel.ISupportInitialize)(this.AssignAllButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignSelectedButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveSelectedButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemoveAllButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AvailableFieldsListBox;
        private System.Windows.Forms.Label AvailableFieldsLabel;
        private System.Windows.Forms.Label AssignedFieldsLabel;
        private System.Windows.Forms.ListBox AssignedFieldsListBox;
        private System.Windows.Forms.PictureBox AssignAllButton;
        private System.Windows.Forms.PictureBox AssignSelectedButton;
        private System.Windows.Forms.PictureBox RemoveSelectedButton;
        private System.Windows.Forms.PictureBox RemoveAllButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TextBox SelectedTableTextBox;
        private System.Windows.Forms.Label SelectedTableLabel;
        private System.Windows.Forms.Button CreateGridColumnsButton;
        private System.Windows.Forms.TextBox SelectedFieldTextBox;
        private System.Windows.Forms.Label SelectedFieldLabel;
        private System.Windows.Forms.TextBox CaptionTextBox;
        private System.Windows.Forms.Label CaptionLabel;
        private System.Windows.Forms.TextBox DataTypeTextBox;
        private System.Windows.Forms.Label DataTypeLabel;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label FontBoldLabel;
        private System.Windows.Forms.Label DefaultValuesLabel;
        private System.Windows.Forms.CheckBox FontBoldCheckBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox FontSizeTextBox;
        private System.Windows.Forms.Label FontSizeLabel;
        private System.Windows.Forms.TextBox FontNameTextBox;
        private System.Windows.Forms.Label FontNameLabel;
        private System.Windows.Forms.TextBox FormatTextBox;
        private System.Windows.Forms.Label FormatLabel;
        private System.Windows.Forms.TextBox ClassNameTextBox;
        private System.Windows.Forms.Label ClassNameLabel;
        private System.Windows.Forms.TextBox ParentTextBox;
        private System.Windows.Forms.Label ParentLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.CheckBox ImageCheckBox;
        private System.Windows.Forms.Label IsImageLabel;
        private System.Windows.Forms.CheckBox ImageButtonCheckBox;
        private System.Windows.Forms.Label ImageButtonLabel;
    }
}


