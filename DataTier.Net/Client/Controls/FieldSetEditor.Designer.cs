

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class FieldSetEditor
    /// <summary>
    /// method [Enter Method Description]
    /// </summary>
    partial class FieldSetEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private TabButton DeleteButton;
        private TabButton AddButton;
        private System.Windows.Forms.ListBox FieldSetsListBox;
        private System.Windows.Forms.Label FieldSetsLabel;
        private TabButton EditButton;
        private System.Windows.Forms.Label FieldsLabel;
        private SaveCancelControl SaveCancelControl;
        private System.Windows.Forms.CheckedListBox FieldsListBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl TableControl;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Panel EditPanel;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ParameterModeCheckBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl FieldSetNameControl;
        private SaveCancelControl SaveCancelControl2;
        private DataJuggler.Win.Controls.LabelCheckBoxControl OrderByModeCheckBox;
        private System.Windows.Forms.Panel TagsPanel;
        private System.Windows.Forms.PictureBox ParameterModeImage;
        private System.Windows.Forms.PictureBox ReaderModeImage;
        private System.Windows.Forms.PictureBox OrderByImage;
        private DataJuggler.Win.Controls.LabelCheckBoxControl ReaderModeCheckBox;
        private System.Windows.Forms.PictureBox EditModeImage;
        private DataJuggler.Win.Controls.Objects.PanelExtender BottomFillerPanel;
        private DataJuggler.Win.Controls.LabelLabelControl ValidationLabel;
        private System.Windows.Forms.Panel Filler1;
        private System.Windows.Forms.ListBox OrderByFieldsListBox;
        private System.Windows.Forms.Label OrderByFieldsLabel;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
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
            this.components = new System.ComponentModel.Container();
            this.FieldSetsListBox = new System.Windows.Forms.ListBox();
            this.FieldSetsLabel = new System.Windows.Forms.Label();
            this.FieldsLabel = new System.Windows.Forms.Label();
            this.FieldsListBox = new System.Windows.Forms.CheckedListBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.EditModeImage = new System.Windows.Forms.PictureBox();
            this.ReaderModeImage = new System.Windows.Forms.PictureBox();
            this.OrderByImage = new System.Windows.Forms.PictureBox();
            this.ParameterModeImage = new System.Windows.Forms.PictureBox();
            this.TableControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.ReaderModeCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.OrderByModeCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.SaveCancelControl2 = new DataTierClient.Controls.SaveCancelControl();
            this.ParameterModeCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.FieldSetNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.TagsPanel = new System.Windows.Forms.Panel();
            this.BottomFillerPanel = new DataJuggler.Win.Controls.Objects.PanelExtender();
            this.ValidationLabel = new DataJuggler.Win.Controls.LabelLabelControl();
            this.Filler1 = new System.Windows.Forms.Panel();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.OrderByFieldsListBox = new System.Windows.Forms.ListBox();
            this.OrderByFieldsLabel = new System.Windows.Forms.Label();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.DeleteButton = new DataTierClient.Controls.TabButton();
            this.AddButton = new DataTierClient.Controls.TabButton();
            this.EditButton = new DataTierClient.Controls.TabButton();
            this.DescendingCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.SelectedFieldsCountLabel = new DataJuggler.Win.Controls.LabelLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.EditModeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReaderModeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderByImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParameterModeImage)).BeginInit();
            this.EditPanel.SuspendLayout();
            this.TagsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FieldSetsListBox
            // 
            this.FieldSetsListBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldSetsListBox.FormattingEnabled = true;
            this.FieldSetsListBox.ItemHeight = 18;
            this.FieldSetsListBox.Location = new System.Drawing.Point(60, 85);
            this.FieldSetsListBox.Name = "FieldSetsListBox";
            this.FieldSetsListBox.Size = new System.Drawing.Size(222, 130);
            this.FieldSetsListBox.TabIndex = 101;
            this.FieldSetsListBox.SelectedIndexChanged += new System.EventHandler(this.FieldSetsListBox_SelectedIndexChanged);
            // 
            // FieldSetsLabel
            // 
            this.FieldSetsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldSetsLabel.Location = new System.Drawing.Point(60, 64);
            this.FieldSetsLabel.Name = "FieldSetsLabel";
            this.FieldSetsLabel.Size = new System.Drawing.Size(178, 20);
            this.FieldSetsLabel.TabIndex = 100;
            this.FieldSetsLabel.Text = "Field Sets:";
            this.FieldSetsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FieldsLabel
            // 
            this.FieldsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldsLabel.Location = new System.Drawing.Point(378, 85);
            this.FieldsLabel.Name = "FieldsLabel";
            this.FieldsLabel.Size = new System.Drawing.Size(100, 20);
            this.FieldsLabel.TabIndex = 107;
            this.FieldsLabel.Text = "Fields:";
            this.FieldsLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // FieldsListBox
            // 
            this.FieldsListBox.CheckOnClick = true;
            this.FieldsListBox.Enabled = false;
            this.FieldsListBox.FormattingEnabled = true;
            this.FieldsListBox.Location = new System.Drawing.Point(482, 85);
            this.FieldsListBox.Name = "FieldsListBox";
            this.FieldsListBox.Size = new System.Drawing.Size(316, 312);
            this.FieldsListBox.TabIndex = 105;
            this.ToolTip.SetToolTip(this.FieldsListBox, "Press Ctrl + A to Check All.\r\nPress Ctrl + N to Check None.");
            this.FieldsListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FieldsListBox_ItemCheck);
            this.FieldsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldsListBox_KeyDown);
            // 
            // EditModeImage
            // 
            this.EditModeImage.BackgroundImage = global::DataTierClient.Properties.Resources.EditMode;
            this.EditModeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditModeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditModeImage.Dock = System.Windows.Forms.DockStyle.Right;
            this.EditModeImage.Location = new System.Drawing.Point(1077, 0);
            this.EditModeImage.Name = "EditModeImage";
            this.EditModeImage.Size = new System.Drawing.Size(128, 40);
            this.EditModeImage.TabIndex = 127;
            this.EditModeImage.TabStop = false;
            this.ToolTip.SetToolTip(this.EditModeImage, "In Parameter Mode you may select up to four fields.");
            this.EditModeImage.Visible = false;
            // 
            // ReaderModeImage
            // 
            this.ReaderModeImage.BackgroundImage = global::DataTierClient.Properties.Resources.ReaderMode;
            this.ReaderModeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReaderModeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReaderModeImage.Location = new System.Drawing.Point(380, 0);
            this.ReaderModeImage.Name = "ReaderModeImage";
            this.ReaderModeImage.Size = new System.Drawing.Size(182, 40);
            this.ReaderModeImage.TabIndex = 126;
            this.ReaderModeImage.TabStop = false;
            this.ToolTip.SetToolTip(this.ReaderModeImage, "In Parameter Mode you may select up to four fields.");
            this.ReaderModeImage.Visible = false;
            // 
            // OrderByImage
            // 
            this.OrderByImage.BackgroundImage = global::DataTierClient.Properties.Resources.OrderBy;
            this.OrderByImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OrderByImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrderByImage.Location = new System.Drawing.Point(190, 0);
            this.OrderByImage.Name = "OrderByImage";
            this.OrderByImage.Size = new System.Drawing.Size(182, 40);
            this.OrderByImage.TabIndex = 123;
            this.OrderByImage.TabStop = false;
            this.ToolTip.SetToolTip(this.OrderByImage, "In Parameter Mode you may select up to four fields.");
            this.OrderByImage.Visible = false;
            // 
            // ParameterModeImage
            // 
            this.ParameterModeImage.BackgroundImage = global::DataTierClient.Properties.Resources.Parameter_Mode;
            this.ParameterModeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ParameterModeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParameterModeImage.Location = new System.Drawing.Point(0, 0);
            this.ParameterModeImage.Name = "ParameterModeImage";
            this.ParameterModeImage.Size = new System.Drawing.Size(182, 40);
            this.ParameterModeImage.TabIndex = 119;
            this.ParameterModeImage.TabStop = false;
            this.ToolTip.SetToolTip(this.ParameterModeImage, "In Parameter Mode you may select up to four fields.");
            this.ParameterModeImage.Visible = false;
            // 
            // TableControl
            // 
            this.TableControl.BackColor = System.Drawing.Color.Transparent;
            this.TableControl.BottomMargin = 0;
            this.TableControl.Editable = false;
            this.TableControl.Encrypted = false;
            this.TableControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableControl.LabelBottomMargin = 0;
            this.TableControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.TableControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.TableControl.LabelText = "Selected Table:";
            this.TableControl.LabelTopMargin = 0;
            this.TableControl.LabelWidth = 180;
            this.TableControl.Location = new System.Drawing.Point(299, 52);
            this.TableControl.MultiLine = false;
            this.TableControl.Name = "TableControl";
            this.TableControl.OnTextChangedListener = null;
            this.TableControl.PasswordMode = false;
            this.TableControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TableControl.Size = new System.Drawing.Size(499, 32);
            this.TableControl.TabIndex = 112;
            this.TableControl.TextBoxBottomMargin = 0;
            this.TableControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.TableControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.TableControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.TableControl.TextBoxTopMargin = 0;
            // 
            // EditPanel
            // 
            this.EditPanel.Controls.Add(this.ReaderModeCheckBox);
            this.EditPanel.Controls.Add(this.OrderByModeCheckBox);
            this.EditPanel.Controls.Add(this.SaveCancelControl2);
            this.EditPanel.Controls.Add(this.ParameterModeCheckBox);
            this.EditPanel.Controls.Add(this.FieldSetNameControl);
            this.EditPanel.Location = new System.Drawing.Point(3, 262);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(447, 195);
            this.EditPanel.TabIndex = 115;
            // 
            // ReaderModeCheckBox
            // 
            this.ReaderModeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ReaderModeCheckBox.CheckBoxHorizontalOffSet = 2;
            this.ReaderModeCheckBox.CheckBoxVerticalOffSet = 3;
            this.ReaderModeCheckBox.CheckChangedListener = null;
            this.ReaderModeCheckBox.Checked = false;
            this.ReaderModeCheckBox.Editable = true;
            this.ReaderModeCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderModeCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ReaderModeCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReaderModeCheckBox.LabelText = "Reader Mode:";
            this.ReaderModeCheckBox.LabelWidth = 180;
            this.ReaderModeCheckBox.Location = new System.Drawing.Point(20, 115);
            this.ReaderModeCheckBox.Name = "ReaderModeCheckBox";
            this.ReaderModeCheckBox.Size = new System.Drawing.Size(211, 24);
            this.ReaderModeCheckBox.TabIndex = 119;
            // 
            // OrderByModeCheckBox
            // 
            this.OrderByModeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.OrderByModeCheckBox.CheckBoxHorizontalOffSet = 2;
            this.OrderByModeCheckBox.CheckBoxVerticalOffSet = 3;
            this.OrderByModeCheckBox.CheckChangedListener = null;
            this.OrderByModeCheckBox.Checked = false;
            this.OrderByModeCheckBox.Editable = true;
            this.OrderByModeCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByModeCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.OrderByModeCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByModeCheckBox.LabelText = "Order By Mode:";
            this.OrderByModeCheckBox.LabelWidth = 180;
            this.OrderByModeCheckBox.Location = new System.Drawing.Point(20, 85);
            this.OrderByModeCheckBox.Name = "OrderByModeCheckBox";
            this.OrderByModeCheckBox.Size = new System.Drawing.Size(211, 24);
            this.OrderByModeCheckBox.TabIndex = 118;
            // 
            // SaveCancelControl2
            // 
            this.SaveCancelControl2.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl2.Location = new System.Drawing.Point(0, 155);
            this.SaveCancelControl2.Name = "SaveCancelControl2";
            this.SaveCancelControl2.Size = new System.Drawing.Size(447, 40);
            this.SaveCancelControl2.TabIndex = 117;
            // 
            // ParameterModeCheckBox
            // 
            this.ParameterModeCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ParameterModeCheckBox.CheckBoxHorizontalOffSet = 2;
            this.ParameterModeCheckBox.CheckBoxVerticalOffSet = 3;
            this.ParameterModeCheckBox.CheckChangedListener = null;
            this.ParameterModeCheckBox.Checked = false;
            this.ParameterModeCheckBox.Editable = true;
            this.ParameterModeCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterModeCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ParameterModeCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterModeCheckBox.LabelText = "Parameter Mode:";
            this.ParameterModeCheckBox.LabelWidth = 180;
            this.ParameterModeCheckBox.Location = new System.Drawing.Point(20, 54);
            this.ParameterModeCheckBox.Name = "ParameterModeCheckBox";
            this.ParameterModeCheckBox.Size = new System.Drawing.Size(211, 24);
            this.ParameterModeCheckBox.TabIndex = 116;
            // 
            // FieldSetNameControl
            // 
            this.FieldSetNameControl.BackColor = System.Drawing.Color.Transparent;
            this.FieldSetNameControl.BottomMargin = 0;
            this.FieldSetNameControl.Editable = false;
            this.FieldSetNameControl.Encrypted = false;
            this.FieldSetNameControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldSetNameControl.LabelBottomMargin = 0;
            this.FieldSetNameControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.FieldSetNameControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.FieldSetNameControl.LabelText = "Field Set Name:";
            this.FieldSetNameControl.LabelTopMargin = 0;
            this.FieldSetNameControl.LabelWidth = 180;
            this.FieldSetNameControl.Location = new System.Drawing.Point(20, 16);
            this.FieldSetNameControl.MultiLine = false;
            this.FieldSetNameControl.Name = "FieldSetNameControl";
            this.FieldSetNameControl.OnTextChangedListener = null;
            this.FieldSetNameControl.PasswordMode = false;
            this.FieldSetNameControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FieldSetNameControl.Size = new System.Drawing.Size(409, 32);
            this.FieldSetNameControl.TabIndex = 115;
            this.FieldSetNameControl.TextBoxBottomMargin = 0;
            this.FieldSetNameControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.FieldSetNameControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.FieldSetNameControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F);
            this.FieldSetNameControl.TextBoxTopMargin = 2;
            // 
            // TagsPanel
            // 
            this.TagsPanel.Controls.Add(this.EditModeImage);
            this.TagsPanel.Controls.Add(this.ReaderModeImage);
            this.TagsPanel.Controls.Add(this.OrderByImage);
            this.TagsPanel.Controls.Add(this.ParameterModeImage);
            this.TagsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagsPanel.Location = new System.Drawing.Point(0, 0);
            this.TagsPanel.Name = "TagsPanel";
            this.TagsPanel.Size = new System.Drawing.Size(1205, 40);
            this.TagsPanel.TabIndex = 119;
            // 
            // BottomFillerPanel
            // 
            this.BottomFillerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomFillerPanel.Location = new System.Drawing.Point(0, 492);
            this.BottomFillerPanel.Name = "BottomFillerPanel";
            this.BottomFillerPanel.Size = new System.Drawing.Size(1205, 20);
            this.BottomFillerPanel.TabIndex = 130;
            // 
            // ValidationLabel
            // 
            this.ValidationLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ValidationLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.ValidationLabel.LabelColor = System.Drawing.Color.Firebrick;
            this.ValidationLabel.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidationLabel.LabelText = "Error:";
            this.ValidationLabel.LabelWidth = 80;
            this.ValidationLabel.Location = new System.Drawing.Point(0, 468);
            this.ValidationLabel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ValidationLabel.Name = "ValidationLabel";
            this.ValidationLabel.Size = new System.Drawing.Size(1205, 24);
            this.ValidationLabel.TabIndex = 131;
            this.ValidationLabel.ValueLabelColor = System.Drawing.Color.Firebrick;
            this.ValidationLabel.ValueLabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidationLabel.Visible = false;
            // 
            // Filler1
            // 
            this.Filler1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Filler1.Location = new System.Drawing.Point(0, 464);
            this.Filler1.Name = "Filler1";
            this.Filler1.Size = new System.Drawing.Size(1205, 4);
            this.Filler1.TabIndex = 133;
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 512);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(1205, 40);
            this.SaveCancelControl.TabIndex = 110;
            // 
            // OrderByFieldsListBox
            // 
            this.OrderByFieldsListBox.Enabled = false;
            this.OrderByFieldsListBox.FormattingEnabled = true;
            this.OrderByFieldsListBox.ItemHeight = 18;
            this.OrderByFieldsListBox.Location = new System.Drawing.Point(817, 85);
            this.OrderByFieldsListBox.Name = "OrderByFieldsListBox";
            this.OrderByFieldsListBox.Size = new System.Drawing.Size(316, 148);
            this.OrderByFieldsListBox.TabIndex = 136;
            this.OrderByFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.OrderByFields_SelectedIndexChanged);
            // 
            // OrderByFieldsLabel
            // 
            this.OrderByFieldsLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByFieldsLabel.Location = new System.Drawing.Point(815, 62);
            this.OrderByFieldsLabel.Name = "OrderByFieldsLabel";
            this.OrderByFieldsLabel.Size = new System.Drawing.Size(154, 20);
            this.OrderByFieldsLabel.TabIndex = 135;
            this.OrderByFieldsLabel.Text = "Order By Fields:";
            this.OrderByFieldsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrderByFieldsLabel.EnabledChanged += new System.EventHandler(this.OrderByFieldsLabel_EnabledChanged);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.BackgroundImage = global::DataTierClient.Properties.Resources.Arrow_Down_Gray;
            this.MoveDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveDownButton.Enabled = false;
            this.MoveDownButton.FlatAppearance.BorderSize = 0;
            this.MoveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveDownButton.Location = new System.Drawing.Point(1137, 127);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(32, 32);
            this.MoveDownButton.TabIndex = 138;
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.EnabledChanged += new System.EventHandler(this.MoveDownButton_EnabledChanged);
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.BackgroundImage = global::DataTierClient.Properties.Resources.Arrow_Up_Gray;
            this.MoveUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MoveUpButton.Enabled = false;
            this.MoveUpButton.FlatAppearance.BorderSize = 0;
            this.MoveUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveUpButton.Location = new System.Drawing.Point(1137, 89);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(32, 32);
            this.MoveUpButton.TabIndex = 137;
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.EnabledChanged += new System.EventHandler(this.MoveUpButton_EnabledChanged);
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            this.MoveUpButton.MouseEnter += new System.EventHandler(this.Button_Enter);
            this.MoveUpButton.MouseLeave += new System.EventHandler(this.Button_Leave);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteButton.ButtonNumber = 0;
            this.DeleteButton.ButtonText = "Delete";
            this.DeleteButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(206, 223);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.DeleteButton.Selected = false;
            this.DeleteButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.DeleteButton.ShowNotSelectedImageWhenDisabled = true;
            this.DeleteButton.Size = new System.Drawing.Size(76, 26);
            this.DeleteButton.TabIndex = 104;
            // 
            // AddButton
            // 
            this.AddButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddButton.ButtonNumber = 0;
            this.AddButton.ButtonText = "Add";
            this.AddButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(60, 223);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.AddButton.Selected = true;
            this.AddButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.AddButton.ShowNotSelectedImageWhenDisabled = true;
            this.AddButton.Size = new System.Drawing.Size(64, 26);
            this.AddButton.TabIndex = 102;
            // 
            // EditButton
            // 
            this.EditButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditButton.ButtonNumber = 0;
            this.EditButton.ButtonText = "Edit";
            this.EditButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(133, 223);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.NotSelectedImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditButton.Selected = false;
            this.EditButton.SelectedImage = global::DataTierClient.Properties.Resources.DeepBlue;
            this.EditButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditButton.Size = new System.Drawing.Size(64, 26);
            this.EditButton.TabIndex = 103;
            // 
            // DescendingCheckBox
            // 
            this.DescendingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DescendingCheckBox.CheckBoxHorizontalOffSet = 2;
            this.DescendingCheckBox.CheckBoxVerticalOffSet = 3;
            this.DescendingCheckBox.CheckChangedListener = null;
            this.DescendingCheckBox.Checked = false;
            this.DescendingCheckBox.Editable = true;
            this.DescendingCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescendingCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.DescendingCheckBox.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescendingCheckBox.LabelText = "Descending:";
            this.DescendingCheckBox.LabelWidth = 120;
            this.DescendingCheckBox.Location = new System.Drawing.Point(996, 60);
            this.DescendingCheckBox.Name = "DescendingCheckBox";
            this.DescendingCheckBox.Size = new System.Drawing.Size(155, 24);
            this.DescendingCheckBox.TabIndex = 139;
            // 
            // SelectedFieldsCountLabel
            // 
            this.SelectedFieldsCountLabel.Font = new System.Drawing.Font("Verdana", 12F);
            this.SelectedFieldsCountLabel.ForeColor = System.Drawing.Color.Black;
            this.SelectedFieldsCountLabel.LabelColor = System.Drawing.Color.Black;
            this.SelectedFieldsCountLabel.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFieldsCountLabel.LabelText = "Count:";
            this.SelectedFieldsCountLabel.LabelWidth = 80;
            this.SelectedFieldsCountLabel.Location = new System.Drawing.Point(482, 417);
            this.SelectedFieldsCountLabel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SelectedFieldsCountLabel.Name = "SelectedFieldsCountLabel";
            this.SelectedFieldsCountLabel.Size = new System.Drawing.Size(305, 24);
            this.SelectedFieldsCountLabel.TabIndex = 140;
            this.SelectedFieldsCountLabel.ValueLabelColor = System.Drawing.Color.Black;
            this.SelectedFieldsCountLabel.ValueLabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFieldsCountLabel.Visible = false;
            // 
            // FieldSetEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.SelectedFieldsCountLabel);
            this.Controls.Add(this.DescendingCheckBox);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.OrderByFieldsListBox);
            this.Controls.Add(this.OrderByFieldsLabel);
            this.Controls.Add(this.Filler1);
            this.Controls.Add(this.ValidationLabel);
            this.Controls.Add(this.BottomFillerPanel);
            this.Controls.Add(this.TagsPanel);
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.TableControl);
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.FieldsLabel);
            this.Controls.Add(this.FieldsListBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FieldSetsListBox);
            this.Controls.Add(this.FieldSetsLabel);
            this.Controls.Add(this.EditButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FieldSetEditor";
            this.Size = new System.Drawing.Size(1205, 552);
            ((System.ComponentModel.ISupportInitialize)(this.EditModeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReaderModeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderByImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParameterModeImage)).EndInit();
            this.EditPanel.ResumeLayout(false);
            this.TagsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private DataJuggler.Win.Controls.LabelCheckBoxControl DescendingCheckBox;
        private DataJuggler.Win.Controls.LabelLabelControl SelectedFieldsCountLabel;
    }
    #endregion

}
