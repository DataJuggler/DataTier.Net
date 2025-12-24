

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class CustomMethodEditor
    /// <summary>
    /// This method is used to create or edit methods.
    /// </summary>
    partial class CustomMethodEditor
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private DataJuggler.Win.Controls.LabelTextBoxControl SelectedTableControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl MethodTypeControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl MethodNameControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl ParametersControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl ProcedureNameControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl ParameterTypeControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl ParameterFieldControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl UseCustomReaderCheckBox;
        private DataJuggler.Win.Controls.LabelComboBoxControl CustomReaderControl;
        private TabButton EditReadersButton;
        private TabButton EditParametersSetButton;
        private SaveCancelControl SaveCancelControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl ParameterFieldSetControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl PropertyNameControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl UpdateOnBuildCheckbox;
        private System.Windows.Forms.PictureBox IsViewIcon;
        private System.Windows.Forms.ToolTip ToolTip;
        private DataJuggler.Win.Controls.LabelComboBoxControl OrderByFieldSetControl;
        private TabButton EditOrderByFieldSetsButton;
        private DataJuggler.Win.Controls.LabelComboBoxControl OrderByTypeControl;
        private DataJuggler.Win.Controls.LabelComboBoxControl OrderByFieldControl;
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
            this.CustomReaderControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.UseCustomReaderCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.ParameterFieldControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.ParameterTypeControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.ProcedureNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.ParametersControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.MethodNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.MethodTypeControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.SelectedTableControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.ParameterFieldSetControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.SaveCancelControl = new DataTierClient.Controls.SaveCancelControl();
            this.PropertyNameControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.UpdateOnBuildCheckbox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.IsViewIcon = new System.Windows.Forms.PictureBox();
            this.EditParametersSetButton = new DataTierClient.Controls.TabButton();
            this.EditReadersButton = new DataTierClient.Controls.TabButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OrderByFieldSetControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.EditOrderByFieldSetsButton = new DataTierClient.Controls.TabButton();
            this.OrderByTypeControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.OrderByFieldControl = new DataJuggler.Win.Controls.LabelComboBoxControl();
            this.DescendingCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            this.TopRowsControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.CustomWhereCheckBox = new DataJuggler.Win.Controls.LabelCheckBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.IsViewIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomReaderControl
            // 
            this.CustomReaderControl.BackColor = System.Drawing.Color.Transparent;
            this.CustomReaderControl.ComboBoxLeftMargin = 1;
            this.CustomReaderControl.ComboBoxText = "";
            this.CustomReaderControl.ComoboBoxFont = null;
            this.CustomReaderControl.Editable = true;
            this.CustomReaderControl.Enabled = false;
            this.CustomReaderControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomReaderControl.HideLabel = false;
            this.CustomReaderControl.LabelBottomMargin = 0;
            this.CustomReaderControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.CustomReaderControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomReaderControl.LabelText = "Custom Reader:";
            this.CustomReaderControl.LabelTopMargin = 0;
            this.CustomReaderControl.LabelWidth = 188;
            this.CustomReaderControl.List = null;
            this.CustomReaderControl.Location = new System.Drawing.Point(20, 419);
            this.CustomReaderControl.Name = "CustomReaderControl";
            this.CustomReaderControl.SelectedIndex = -1;
            this.CustomReaderControl.SelectedIndexListener = null;
            this.CustomReaderControl.Size = new System.Drawing.Size(620, 28);
            this.CustomReaderControl.Sorted = true;
            this.CustomReaderControl.Source = null;
            this.CustomReaderControl.TabIndex = 11;
            this.CustomReaderControl.EnabledChanged += new System.EventHandler(this.CustomReaderControl_EnabledChanged);
            // 
            // UseCustomReaderCheckBox
            // 
            this.UseCustomReaderCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.UseCustomReaderCheckBox.CheckBoxHorizontalOffSet = 0;
            this.UseCustomReaderCheckBox.CheckBoxVerticalOffSet = 3;
            this.UseCustomReaderCheckBox.CheckChangedListener = null;
            this.UseCustomReaderCheckBox.Checked = false;
            this.UseCustomReaderCheckBox.Editable = true;
            this.UseCustomReaderCheckBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseCustomReaderCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.UseCustomReaderCheckBox.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseCustomReaderCheckBox.LabelText = "Use Custom Reader:";
            this.UseCustomReaderCheckBox.LabelWidth = 200;
            this.UseCustomReaderCheckBox.Location = new System.Drawing.Point(8, 380);
            this.UseCustomReaderCheckBox.Name = "UseCustomReaderCheckBox";
            this.UseCustomReaderCheckBox.Size = new System.Drawing.Size(226, 28);
            this.UseCustomReaderCheckBox.TabIndex = 10;
            // 
            // ParameterFieldControl
            // 
            this.ParameterFieldControl.BackColor = System.Drawing.Color.Transparent;
            this.ParameterFieldControl.ComboBoxLeftMargin = 1;
            this.ParameterFieldControl.ComboBoxText = "";
            this.ParameterFieldControl.ComoboBoxFont = null;
            this.ParameterFieldControl.Editable = true;
            this.ParameterFieldControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterFieldControl.HideLabel = false;
            this.ParameterFieldControl.LabelBottomMargin = 0;
            this.ParameterFieldControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ParameterFieldControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterFieldControl.LabelText = "Parameter Field:";
            this.ParameterFieldControl.LabelTopMargin = 0;
            this.ParameterFieldControl.LabelWidth = 188;
            this.ParameterFieldControl.List = null;
            this.ParameterFieldControl.Location = new System.Drawing.Point(20, 140);
            this.ParameterFieldControl.Name = "ParameterFieldControl";
            this.ParameterFieldControl.SelectedIndex = -1;
            this.ParameterFieldControl.SelectedIndexListener = null;
            this.ParameterFieldControl.Size = new System.Drawing.Size(620, 28);
            this.ParameterFieldControl.Sorted = true;
            this.ParameterFieldControl.Source = null;
            this.ParameterFieldControl.TabIndex = 3;
            this.ParameterFieldControl.EnabledChanged += new System.EventHandler(this.ParameterFieldControl_EnabledChanged);
            // 
            // ParameterTypeControl
            // 
            this.ParameterTypeControl.BackColor = System.Drawing.Color.Transparent;
            this.ParameterTypeControl.ComboBoxLeftMargin = 1;
            this.ParameterTypeControl.ComboBoxText = "";
            this.ParameterTypeControl.ComoboBoxFont = null;
            this.ParameterTypeControl.Editable = true;
            this.ParameterTypeControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterTypeControl.HideLabel = false;
            this.ParameterTypeControl.LabelBottomMargin = 0;
            this.ParameterTypeControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ParameterTypeControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterTypeControl.LabelText = "Parameter Type:";
            this.ParameterTypeControl.LabelTopMargin = 0;
            this.ParameterTypeControl.LabelWidth = 188;
            this.ParameterTypeControl.List = null;
            this.ParameterTypeControl.Location = new System.Drawing.Point(20, 100);
            this.ParameterTypeControl.Name = "ParameterTypeControl";
            this.ParameterTypeControl.SelectedIndex = -1;
            this.ParameterTypeControl.SelectedIndexListener = null;
            this.ParameterTypeControl.Size = new System.Drawing.Size(620, 28);
            this.ParameterTypeControl.Sorted = true;
            this.ParameterTypeControl.Source = null;
            this.ParameterTypeControl.TabIndex = 2;
            // 
            // ProcedureNameControl
            // 
            this.ProcedureNameControl.BackColor = System.Drawing.Color.Transparent;
            this.ProcedureNameControl.BottomMargin = 0;
            this.ProcedureNameControl.Editable = true;
            this.ProcedureNameControl.Encrypted = false;
            this.ProcedureNameControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcedureNameControl.LabelBottomMargin = 0;
            this.ProcedureNameControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ProcedureNameControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcedureNameControl.LabelText = "Procedure Name:";
            this.ProcedureNameControl.LabelTopMargin = 2;
            this.ProcedureNameControl.LabelWidth = 188;
            this.ProcedureNameControl.Location = new System.Drawing.Point(20, 220);
            this.ProcedureNameControl.MultiLine = false;
            this.ProcedureNameControl.Name = "ProcedureNameControl";
            this.ProcedureNameControl.OnTextChangedListener = null;
            this.ProcedureNameControl.PasswordMode = false;
            this.ProcedureNameControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ProcedureNameControl.Size = new System.Drawing.Size(620, 28);
            this.ProcedureNameControl.TabIndex = 6;
            this.ProcedureNameControl.TextBoxBottomMargin = 0;
            this.ProcedureNameControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ProcedureNameControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ProcedureNameControl.TextBoxFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcedureNameControl.TextBoxTopMargin = 0;
            // 
            // ParametersControl
            // 
            this.ParametersControl.BackColor = System.Drawing.Color.Transparent;
            this.ParametersControl.BottomMargin = 0;
            this.ParametersControl.Editable = true;
            this.ParametersControl.Encrypted = false;
            this.ParametersControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersControl.LabelBottomMargin = 0;
            this.ParametersControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ParametersControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersControl.LabelText = "Parameter:";
            this.ParametersControl.LabelTopMargin = 2;
            this.ParametersControl.LabelWidth = 188;
            this.ParametersControl.Location = new System.Drawing.Point(20, 260);
            this.ParametersControl.MultiLine = false;
            this.ParametersControl.Name = "ParametersControl";
            this.ParametersControl.OnTextChangedListener = null;
            this.ParametersControl.PasswordMode = false;
            this.ParametersControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ParametersControl.Size = new System.Drawing.Size(620, 28);
            this.ParametersControl.TabIndex = 7;
            this.ParametersControl.TextBoxBottomMargin = 0;
            this.ParametersControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.ParametersControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.ParametersControl.TextBoxFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersControl.TextBoxTopMargin = 0;
            // 
            // MethodNameControl
            // 
            this.MethodNameControl.BackColor = System.Drawing.Color.Transparent;
            this.MethodNameControl.BottomMargin = 0;
            this.MethodNameControl.Editable = true;
            this.MethodNameControl.Encrypted = false;
            this.MethodNameControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodNameControl.LabelBottomMargin = 0;
            this.MethodNameControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.MethodNameControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodNameControl.LabelText = "Method Name:";
            this.MethodNameControl.LabelTopMargin = 2;
            this.MethodNameControl.LabelWidth = 188;
            this.MethodNameControl.Location = new System.Drawing.Point(20, 180);
            this.MethodNameControl.MultiLine = false;
            this.MethodNameControl.Name = "MethodNameControl";
            this.MethodNameControl.OnTextChangedListener = null;
            this.MethodNameControl.PasswordMode = false;
            this.MethodNameControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MethodNameControl.Size = new System.Drawing.Size(620, 28);
            this.MethodNameControl.TabIndex = 5;
            this.MethodNameControl.TextBoxBottomMargin = 0;
            this.MethodNameControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.MethodNameControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.MethodNameControl.TextBoxFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodNameControl.TextBoxTopMargin = 0;
            // 
            // MethodTypeControl
            // 
            this.MethodTypeControl.BackColor = System.Drawing.Color.Transparent;
            this.MethodTypeControl.ComboBoxLeftMargin = 1;
            this.MethodTypeControl.ComboBoxText = "";
            this.MethodTypeControl.ComoboBoxFont = null;
            this.MethodTypeControl.Editable = true;
            this.MethodTypeControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodTypeControl.HideLabel = false;
            this.MethodTypeControl.LabelBottomMargin = 0;
            this.MethodTypeControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.MethodTypeControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodTypeControl.LabelText = "Method Type:";
            this.MethodTypeControl.LabelTopMargin = 0;
            this.MethodTypeControl.LabelWidth = 188;
            this.MethodTypeControl.List = null;
            this.MethodTypeControl.Location = new System.Drawing.Point(20, 60);
            this.MethodTypeControl.Name = "MethodTypeControl";
            this.MethodTypeControl.SelectedIndex = -1;
            this.MethodTypeControl.SelectedIndexListener = null;
            this.MethodTypeControl.Size = new System.Drawing.Size(620, 28);
            this.MethodTypeControl.Sorted = true;
            this.MethodTypeControl.Source = null;
            this.MethodTypeControl.TabIndex = 1;
            // 
            // SelectedTableControl
            // 
            this.SelectedTableControl.BackColor = System.Drawing.Color.Transparent;
            this.SelectedTableControl.BottomMargin = 0;
            this.SelectedTableControl.Editable = false;
            this.SelectedTableControl.Encrypted = false;
            this.SelectedTableControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableControl.LabelBottomMargin = 0;
            this.SelectedTableControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.SelectedTableControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTableControl.LabelText = "Selected Table:";
            this.SelectedTableControl.LabelTopMargin = 4;
            this.SelectedTableControl.LabelWidth = 188;
            this.SelectedTableControl.Location = new System.Drawing.Point(20, 20);
            this.SelectedTableControl.MultiLine = false;
            this.SelectedTableControl.Name = "SelectedTableControl";
            this.SelectedTableControl.OnTextChangedListener = null;
            this.SelectedTableControl.PasswordMode = false;
            this.SelectedTableControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectedTableControl.Size = new System.Drawing.Size(620, 28);
            this.SelectedTableControl.TabIndex = 0;
            this.SelectedTableControl.TextBoxBottomMargin = 0;
            this.SelectedTableControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.SelectedTableControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.SelectedTableControl.TextBoxFont = new System.Drawing.Font("Calibri", 16F);
            this.SelectedTableControl.TextBoxTopMargin = 0;
            // 
            // ParameterFieldSetControl
            // 
            this.ParameterFieldSetControl.BackColor = System.Drawing.Color.Transparent;
            this.ParameterFieldSetControl.ComboBoxLeftMargin = 1;
            this.ParameterFieldSetControl.ComboBoxText = "";
            this.ParameterFieldSetControl.ComoboBoxFont = null;
            this.ParameterFieldSetControl.Editable = true;
            this.ParameterFieldSetControl.Enabled = false;
            this.ParameterFieldSetControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterFieldSetControl.HideLabel = false;
            this.ParameterFieldSetControl.LabelBottomMargin = 0;
            this.ParameterFieldSetControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.ParameterFieldSetControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParameterFieldSetControl.LabelText = "Parameter Set:";
            this.ParameterFieldSetControl.LabelTopMargin = 0;
            this.ParameterFieldSetControl.LabelWidth = 188;
            this.ParameterFieldSetControl.List = null;
            this.ParameterFieldSetControl.Location = new System.Drawing.Point(20, 140);
            this.ParameterFieldSetControl.Name = "ParameterFieldSetControl";
            this.ParameterFieldSetControl.SelectedIndex = -1;
            this.ParameterFieldSetControl.SelectedIndexListener = null;
            this.ParameterFieldSetControl.Size = new System.Drawing.Size(620, 28);
            this.ParameterFieldSetControl.Sorted = true;
            this.ParameterFieldSetControl.Source = null;
            this.ParameterFieldSetControl.TabIndex = 4;
            this.ParameterFieldSetControl.Visible = false;
            this.ParameterFieldSetControl.EnabledChanged += new System.EventHandler(this.ParametersSetControl_EnabledChanged);
            // 
            // SaveCancelControl
            // 
            this.SaveCancelControl.BackColor = System.Drawing.Color.Transparent;
            this.SaveCancelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveCancelControl.Location = new System.Drawing.Point(0, 592);
            this.SaveCancelControl.Name = "SaveCancelControl";
            this.SaveCancelControl.Size = new System.Drawing.Size(720, 48);
            this.SaveCancelControl.TabIndex = 13;
            // 
            // PropertyNameControl
            // 
            this.PropertyNameControl.BackColor = System.Drawing.Color.Transparent;
            this.PropertyNameControl.BottomMargin = 0;
            this.PropertyNameControl.Editable = true;
            this.PropertyNameControl.Encrypted = false;
            this.PropertyNameControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyNameControl.LabelBottomMargin = 0;
            this.PropertyNameControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.PropertyNameControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyNameControl.LabelText = "Property Name:";
            this.PropertyNameControl.LabelTopMargin = 2;
            this.PropertyNameControl.LabelWidth = 188;
            this.PropertyNameControl.Location = new System.Drawing.Point(20, 300);
            this.PropertyNameControl.MultiLine = false;
            this.PropertyNameControl.Name = "PropertyNameControl";
            this.PropertyNameControl.OnTextChangedListener = null;
            this.PropertyNameControl.PasswordMode = false;
            this.PropertyNameControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PropertyNameControl.Size = new System.Drawing.Size(620, 28);
            this.PropertyNameControl.TabIndex = 8;
            this.PropertyNameControl.TextBoxBottomMargin = 0;
            this.PropertyNameControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.PropertyNameControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.PropertyNameControl.TextBoxFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyNameControl.TextBoxTopMargin = 0;
            // 
            // UpdateOnBuildCheckbox
            // 
            this.UpdateOnBuildCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.UpdateOnBuildCheckbox.CheckBoxHorizontalOffSet = 0;
            this.UpdateOnBuildCheckbox.CheckBoxVerticalOffSet = 3;
            this.UpdateOnBuildCheckbox.CheckChangedListener = null;
            this.UpdateOnBuildCheckbox.Checked = true;
            this.UpdateOnBuildCheckbox.Editable = true;
            this.UpdateOnBuildCheckbox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateOnBuildCheckbox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.UpdateOnBuildCheckbox.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateOnBuildCheckbox.LabelText = "Update On Build:";
            this.UpdateOnBuildCheckbox.LabelWidth = 200;
            this.UpdateOnBuildCheckbox.Location = new System.Drawing.Point(8, 340);
            this.UpdateOnBuildCheckbox.Name = "UpdateOnBuildCheckbox";
            this.UpdateOnBuildCheckbox.Size = new System.Drawing.Size(226, 28);
            this.UpdateOnBuildCheckbox.TabIndex = 9;
            // 
            // IsViewIcon
            // 
            this.IsViewIcon.BackgroundImage = global::DataTierClient.Properties.Resources.V;
            this.IsViewIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IsViewIcon.Location = new System.Drawing.Point(647, 10);
            this.IsViewIcon.Name = "IsViewIcon";
            this.IsViewIcon.Size = new System.Drawing.Size(48, 48);
            this.IsViewIcon.TabIndex = 1000;
            this.IsViewIcon.TabStop = false;
            this.ToolTip.SetToolTip(this.IsViewIcon, "This table is actually a View, which limits the functionality to the Load By Meth" +
        "od Type.");
            this.IsViewIcon.Visible = false;
            // 
            // EditParametersSetButton
            // 
            this.EditParametersSetButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditParametersSetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditParametersSetButton.ButtonNumber = 0;
            this.EditParametersSetButton.ButtonText = "...";
            this.EditParametersSetButton.Enabled = false;
            this.EditParametersSetButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditParametersSetButton.Location = new System.Drawing.Point(640, 140);
            this.EditParametersSetButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditParametersSetButton.Name = "EditParametersSetButton";
            this.EditParametersSetButton.NotSelectedImage = null;
            this.EditParametersSetButton.Selected = false;
            this.EditParametersSetButton.SelectedImage = null;
            this.EditParametersSetButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditParametersSetButton.Size = new System.Drawing.Size(40, 32);
            this.EditParametersSetButton.TabIndex = 999;
            this.EditParametersSetButton.TabStop = false;
            this.EditParametersSetButton.Visible = false;
            // 
            // EditReadersButton
            // 
            this.EditReadersButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditReadersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditReadersButton.ButtonNumber = 0;
            this.EditReadersButton.ButtonText = "...";
            this.EditReadersButton.Enabled = false;
            this.EditReadersButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditReadersButton.Location = new System.Drawing.Point(640, 419);
            this.EditReadersButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditReadersButton.Name = "EditReadersButton";
            this.EditReadersButton.NotSelectedImage = null;
            this.EditReadersButton.Selected = false;
            this.EditReadersButton.SelectedImage = null;
            this.EditReadersButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditReadersButton.Size = new System.Drawing.Size(40, 32);
            this.EditReadersButton.TabIndex = 999;
            this.EditReadersButton.TabStop = false;
            // 
            // OrderByFieldSetControl
            // 
            this.OrderByFieldSetControl.BackColor = System.Drawing.Color.Transparent;
            this.OrderByFieldSetControl.ComboBoxLeftMargin = 1;
            this.OrderByFieldSetControl.ComboBoxText = "";
            this.OrderByFieldSetControl.ComoboBoxFont = null;
            this.OrderByFieldSetControl.Editable = true;
            this.OrderByFieldSetControl.Enabled = false;
            this.OrderByFieldSetControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByFieldSetControl.HideLabel = false;
            this.OrderByFieldSetControl.LabelBottomMargin = 0;
            this.OrderByFieldSetControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.OrderByFieldSetControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByFieldSetControl.LabelText = "Order By Field Set:";
            this.OrderByFieldSetControl.LabelTopMargin = 0;
            this.OrderByFieldSetControl.LabelWidth = 188;
            this.OrderByFieldSetControl.List = null;
            this.OrderByFieldSetControl.Location = new System.Drawing.Point(20, 499);
            this.OrderByFieldSetControl.Name = "OrderByFieldSetControl";
            this.OrderByFieldSetControl.SelectedIndex = -1;
            this.OrderByFieldSetControl.SelectedIndexListener = null;
            this.OrderByFieldSetControl.Size = new System.Drawing.Size(620, 28);
            this.OrderByFieldSetControl.Sorted = true;
            this.OrderByFieldSetControl.Source = null;
            this.OrderByFieldSetControl.TabIndex = 1002;
            this.OrderByFieldSetControl.Visible = false;
            // 
            // EditOrderByFieldSetsButton
            // 
            this.EditOrderByFieldSetsButton.BackgroundImage = global::DataTierClient.Properties.Resources.DeepGray;
            this.EditOrderByFieldSetsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditOrderByFieldSetsButton.ButtonNumber = 0;
            this.EditOrderByFieldSetsButton.ButtonText = "...";
            this.EditOrderByFieldSetsButton.Enabled = false;
            this.EditOrderByFieldSetsButton.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditOrderByFieldSetsButton.Location = new System.Drawing.Point(640, 499);
            this.EditOrderByFieldSetsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditOrderByFieldSetsButton.Name = "EditOrderByFieldSetsButton";
            this.EditOrderByFieldSetsButton.NotSelectedImage = null;
            this.EditOrderByFieldSetsButton.Selected = false;
            this.EditOrderByFieldSetsButton.SelectedImage = null;
            this.EditOrderByFieldSetsButton.ShowNotSelectedImageWhenDisabled = true;
            this.EditOrderByFieldSetsButton.Size = new System.Drawing.Size(40, 32);
            this.EditOrderByFieldSetsButton.TabIndex = 1003;
            this.EditOrderByFieldSetsButton.TabStop = false;
            this.EditOrderByFieldSetsButton.Visible = false;
            // 
            // OrderByTypeControl
            // 
            this.OrderByTypeControl.BackColor = System.Drawing.Color.Transparent;
            this.OrderByTypeControl.ComboBoxLeftMargin = 1;
            this.OrderByTypeControl.ComboBoxText = "";
            this.OrderByTypeControl.ComoboBoxFont = null;
            this.OrderByTypeControl.Editable = true;
            this.OrderByTypeControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByTypeControl.HideLabel = false;
            this.OrderByTypeControl.LabelBottomMargin = 0;
            this.OrderByTypeControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.OrderByTypeControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByTypeControl.LabelText = "Order By Type:";
            this.OrderByTypeControl.LabelTopMargin = 0;
            this.OrderByTypeControl.LabelWidth = 188;
            this.OrderByTypeControl.List = null;
            this.OrderByTypeControl.Location = new System.Drawing.Point(20, 459);
            this.OrderByTypeControl.Name = "OrderByTypeControl";
            this.OrderByTypeControl.SelectedIndex = -1;
            this.OrderByTypeControl.SelectedIndexListener = null;
            this.OrderByTypeControl.Size = new System.Drawing.Size(620, 28);
            this.OrderByTypeControl.Sorted = true;
            this.OrderByTypeControl.Source = null;
            this.OrderByTypeControl.TabIndex = 12;
            // 
            // OrderByFieldControl
            // 
            this.OrderByFieldControl.BackColor = System.Drawing.Color.Transparent;
            this.OrderByFieldControl.ComboBoxLeftMargin = 1;
            this.OrderByFieldControl.ComboBoxText = "";
            this.OrderByFieldControl.ComoboBoxFont = null;
            this.OrderByFieldControl.Editable = true;
            this.OrderByFieldControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByFieldControl.HideLabel = false;
            this.OrderByFieldControl.LabelBottomMargin = 0;
            this.OrderByFieldControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.OrderByFieldControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderByFieldControl.LabelText = "Order By Field:";
            this.OrderByFieldControl.LabelTopMargin = 0;
            this.OrderByFieldControl.LabelWidth = 188;
            this.OrderByFieldControl.List = null;
            this.OrderByFieldControl.Location = new System.Drawing.Point(20, 499);
            this.OrderByFieldControl.Name = "OrderByFieldControl";
            this.OrderByFieldControl.SelectedIndex = -1;
            this.OrderByFieldControl.SelectedIndexListener = null;
            this.OrderByFieldControl.Size = new System.Drawing.Size(620, 28);
            this.OrderByFieldControl.Sorted = true;
            this.OrderByFieldControl.Source = null;
            this.OrderByFieldControl.TabIndex = 14;
            this.OrderByFieldControl.Visible = false;
            // 
            // DescendingCheckBox
            // 
            this.DescendingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DescendingCheckBox.CheckBoxHorizontalOffSet = 0;
            this.DescendingCheckBox.CheckBoxVerticalOffSet = 4;
            this.DescendingCheckBox.CheckChangedListener = null;
            this.DescendingCheckBox.Checked = false;
            this.DescendingCheckBox.Editable = true;
            this.DescendingCheckBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescendingCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.DescendingCheckBox.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescendingCheckBox.LabelText = "Descending:";
            this.DescendingCheckBox.LabelWidth = 188;
            this.DescendingCheckBox.Location = new System.Drawing.Point(20, 533);
            this.DescendingCheckBox.Name = "DescendingCheckBox";
            this.DescendingCheckBox.Size = new System.Drawing.Size(226, 28);
            this.DescendingCheckBox.TabIndex = 1004;
            // 
            // TopRowsControl
            // 
            this.TopRowsControl.BackColor = System.Drawing.Color.Transparent;
            this.TopRowsControl.BottomMargin = 0;
            this.TopRowsControl.Editable = true;
            this.TopRowsControl.Encrypted = false;
            this.TopRowsControl.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRowsControl.LabelBottomMargin = 0;
            this.TopRowsControl.LabelColor = System.Drawing.SystemColors.ControlText;
            this.TopRowsControl.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRowsControl.LabelText = "Select Top Rows:";
            this.TopRowsControl.LabelTopMargin = 2;
            this.TopRowsControl.LabelWidth = 188;
            this.TopRowsControl.Location = new System.Drawing.Point(316, 380);
            this.TopRowsControl.MultiLine = false;
            this.TopRowsControl.Name = "TopRowsControl";
            this.TopRowsControl.OnTextChangedListener = null;
            this.TopRowsControl.PasswordMode = false;
            this.TopRowsControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TopRowsControl.Size = new System.Drawing.Size(324, 28);
            this.TopRowsControl.TabIndex = 1005;
            this.TopRowsControl.TextBoxBottomMargin = 0;
            this.TopRowsControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.TopRowsControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.TopRowsControl.TextBoxFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRowsControl.TextBoxTopMargin = 0;
            // 
            // CustomWhereCheckBox
            // 
            this.CustomWhereCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CustomWhereCheckBox.CheckBoxHorizontalOffSet = 0;
            this.CustomWhereCheckBox.CheckBoxVerticalOffSet = 4;
            this.CustomWhereCheckBox.CheckChangedListener = null;
            this.CustomWhereCheckBox.Checked = false;
            this.CustomWhereCheckBox.Editable = true;
            this.CustomWhereCheckBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomWhereCheckBox.LabelColor = System.Drawing.SystemColors.ControlText;
            this.CustomWhereCheckBox.LabelFont = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomWhereCheckBox.LabelText = "Custom Where:";
            this.CustomWhereCheckBox.LabelWidth = 188;
            this.CustomWhereCheckBox.Location = new System.Drawing.Point(437, 340);
            this.CustomWhereCheckBox.Name = "CustomWhereCheckBox";
            this.CustomWhereCheckBox.Size = new System.Drawing.Size(207, 28);
            this.CustomWhereCheckBox.TabIndex = 1006;
            // 
            // CustomMethodEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.CustomWhereCheckBox);
            this.Controls.Add(this.TopRowsControl);
            this.Controls.Add(this.DescendingCheckBox);
            this.Controls.Add(this.EditOrderByFieldSetsButton);
            this.Controls.Add(this.OrderByTypeControl);
            this.Controls.Add(this.IsViewIcon);
            this.Controls.Add(this.UpdateOnBuildCheckbox);
            this.Controls.Add(this.PropertyNameControl);
            this.Controls.Add(this.SaveCancelControl);
            this.Controls.Add(this.EditParametersSetButton);
            this.Controls.Add(this.EditReadersButton);
            this.Controls.Add(this.CustomReaderControl);
            this.Controls.Add(this.UseCustomReaderCheckBox);
            this.Controls.Add(this.ParameterFieldControl);
            this.Controls.Add(this.ParameterTypeControl);
            this.Controls.Add(this.ProcedureNameControl);
            this.Controls.Add(this.ParametersControl);
            this.Controls.Add(this.MethodNameControl);
            this.Controls.Add(this.MethodTypeControl);
            this.Controls.Add(this.SelectedTableControl);
            this.Controls.Add(this.ParameterFieldSetControl);
            this.Controls.Add(this.OrderByFieldControl);
            this.Controls.Add(this.OrderByFieldSetControl);
            this.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomMethodEditor";
            this.Size = new System.Drawing.Size(720, 640);
            ((System.ComponentModel.ISupportInitialize)(this.IsViewIcon)).EndInit();
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private DataJuggler.Win.Controls.LabelCheckBoxControl DescendingCheckBox;
        private DataJuggler.Win.Controls.LabelTextBoxControl TopRowsControl;
        private DataJuggler.Win.Controls.LabelCheckBoxControl CustomWhereCheckBox;
    }
    #endregion

}



