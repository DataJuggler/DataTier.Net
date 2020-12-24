
namespace UsingStatementsRemovalTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DataTierFolderControl = new DataJuggler.Win.Controls.LabelTextBoxBrowserControl();
            this.DeleteControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.FetchControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.InsertControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.UpdateControl = new DataJuggler.Win.Controls.LabelTextBoxControl();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.Graph = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // DataTierFolderControl
            // 
            this.DataTierFolderControl.BackColor = System.Drawing.Color.Transparent;
            this.DataTierFolderControl.BrowseType = DataJuggler.Win.Controls.Enumerations.BrowseTypeEnum.File;
            this.DataTierFolderControl.ButtonImage = ((System.Drawing.Image)(resources.GetObject("DataTierFolderControl.ButtonImage")));
            this.DataTierFolderControl.ButtonWidth = 48;
            this.DataTierFolderControl.DarkMode = false;
            this.DataTierFolderControl.DisabledLabelColor = System.Drawing.Color.Empty;
            this.DataTierFolderControl.Editable = false;
            this.DataTierFolderControl.EnabledLabelColor = System.Drawing.Color.Empty;
            this.DataTierFolderControl.Filter = null;
            this.DataTierFolderControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataTierFolderControl.HideBrowseButton = false;
            this.DataTierFolderControl.LabelBottomMargin = 0;
            this.DataTierFolderControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.DataTierFolderControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DataTierFolderControl.LabelText = "DataTier Folder:";
            this.DataTierFolderControl.LabelTopMargin = 0;
            this.DataTierFolderControl.LabelWidth = 160;
            this.DataTierFolderControl.Location = new System.Drawing.Point(41, 63);
            this.DataTierFolderControl.Name = "DataTierFolderControl";
            this.DataTierFolderControl.OnTextChangedListener = null;
            this.DataTierFolderControl.OpenCallback = null;
            this.DataTierFolderControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DataTierFolderControl.SelectedPath = null;
            this.DataTierFolderControl.Size = new System.Drawing.Size(1004, 32);
            this.DataTierFolderControl.StartPath = null;
            this.DataTierFolderControl.TabIndex = 0;
            this.DataTierFolderControl.TextBoxBottomMargin = 0;
            this.DataTierFolderControl.TextBoxDisabledColor = System.Drawing.Color.Empty;
            this.DataTierFolderControl.TextBoxEditableColor = System.Drawing.Color.Empty;
            this.DataTierFolderControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DataTierFolderControl.TextBoxTopMargin = 0;
            this.DataTierFolderControl.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // DeleteControl
            // 
            this.DeleteControl.BackColor = System.Drawing.Color.Transparent;
            this.DeleteControl.BottomMargin = 0;
            this.DeleteControl.Editable = false;
            this.DeleteControl.Encrypted = false;
            this.DeleteControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteControl.LabelBottomMargin = 0;
            this.DeleteControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.DeleteControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeleteControl.LabelText = "Delete Procs:";
            this.DeleteControl.LabelTopMargin = 0;
            this.DeleteControl.LabelWidth = 160;
            this.DeleteControl.Location = new System.Drawing.Point(41, 110);
            this.DeleteControl.MultiLine = false;
            this.DeleteControl.Name = "DeleteControl";
            this.DeleteControl.OnTextChangedListener = null;
            this.DeleteControl.PasswordMode = false;
            this.DeleteControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DeleteControl.Size = new System.Drawing.Size(959, 32);
            this.DeleteControl.TabIndex = 1;
            this.DeleteControl.TextBoxBottomMargin = 0;
            this.DeleteControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.DeleteControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.DeleteControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteControl.TextBoxTopMargin = 0;
            // 
            // FetchControl
            // 
            this.FetchControl.BackColor = System.Drawing.Color.Transparent;
            this.FetchControl.BottomMargin = 0;
            this.FetchControl.Editable = false;
            this.FetchControl.Encrypted = false;
            this.FetchControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FetchControl.LabelBottomMargin = 0;
            this.FetchControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.FetchControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FetchControl.LabelText = "Fetch Procs:";
            this.FetchControl.LabelTopMargin = 0;
            this.FetchControl.LabelWidth = 160;
            this.FetchControl.Location = new System.Drawing.Point(41, 148);
            this.FetchControl.MultiLine = false;
            this.FetchControl.Name = "FetchControl";
            this.FetchControl.OnTextChangedListener = null;
            this.FetchControl.PasswordMode = false;
            this.FetchControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FetchControl.Size = new System.Drawing.Size(959, 32);
            this.FetchControl.TabIndex = 2;
            this.FetchControl.TextBoxBottomMargin = 0;
            this.FetchControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.FetchControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.FetchControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FetchControl.TextBoxTopMargin = 0;
            // 
            // InsertControl
            // 
            this.InsertControl.BackColor = System.Drawing.Color.Transparent;
            this.InsertControl.BottomMargin = 0;
            this.InsertControl.Editable = false;
            this.InsertControl.Encrypted = false;
            this.InsertControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InsertControl.LabelBottomMargin = 0;
            this.InsertControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.InsertControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InsertControl.LabelText = "Insert Procs:";
            this.InsertControl.LabelTopMargin = 0;
            this.InsertControl.LabelWidth = 160;
            this.InsertControl.Location = new System.Drawing.Point(41, 186);
            this.InsertControl.MultiLine = false;
            this.InsertControl.Name = "InsertControl";
            this.InsertControl.OnTextChangedListener = null;
            this.InsertControl.PasswordMode = false;
            this.InsertControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InsertControl.Size = new System.Drawing.Size(959, 32);
            this.InsertControl.TabIndex = 3;
            this.InsertControl.TextBoxBottomMargin = 0;
            this.InsertControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.InsertControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.InsertControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InsertControl.TextBoxTopMargin = 0;
            // 
            // UpdateControl
            // 
            this.UpdateControl.BackColor = System.Drawing.Color.Transparent;
            this.UpdateControl.BottomMargin = 0;
            this.UpdateControl.Editable = false;
            this.UpdateControl.Encrypted = false;
            this.UpdateControl.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpdateControl.LabelBottomMargin = 0;
            this.UpdateControl.LabelColor = System.Drawing.Color.LemonChiffon;
            this.UpdateControl.LabelFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UpdateControl.LabelText = "Update Procs:";
            this.UpdateControl.LabelTopMargin = 0;
            this.UpdateControl.LabelWidth = 160;
            this.UpdateControl.Location = new System.Drawing.Point(41, 224);
            this.UpdateControl.MultiLine = false;
            this.UpdateControl.Name = "UpdateControl";
            this.UpdateControl.OnTextChangedListener = null;
            this.UpdateControl.PasswordMode = false;
            this.UpdateControl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UpdateControl.Size = new System.Drawing.Size(959, 32);
            this.UpdateControl.TabIndex = 4;
            this.UpdateControl.TextBoxBottomMargin = 0;
            this.UpdateControl.TextBoxDisabledColor = System.Drawing.Color.LightGray;
            this.UpdateControl.TextBoxEditableColor = System.Drawing.Color.White;
            this.UpdateControl.TextBoxFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpdateControl.TextBoxTopMargin = 0;
            // 
            // ProcessButton
            // 
            this.ProcessButton.BackColor = System.Drawing.Color.Transparent;
            this.ProcessButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProcessButton.BackgroundImage")));
            this.ProcessButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProcessButton.FlatAppearance.BorderSize = 0;
            this.ProcessButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ProcessButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcessButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProcessButton.ForeColor = System.Drawing.Color.LemonChiffon;
            this.ProcessButton.Location = new System.Drawing.Point(837, 304);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(163, 52);
            this.ProcessButton.TabIndex = 5;
            this.ProcessButton.Text = "Start";
            this.ProcessButton.UseVisualStyleBackColor = false;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            this.ProcessButton.MouseEnter += new System.EventHandler(this.ProcessButton_MouseEnter);
            this.ProcessButton.MouseLeave += new System.EventHandler(this.ProcessButton_MouseLeave);
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(199, 262);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(801, 23);
            this.Graph.TabIndex = 6;
            this.Graph.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1095, 414);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.UpdateControl);
            this.Controls.Add(this.InsertControl);
            this.Controls.Add(this.FetchControl);
            this.Controls.Add(this.DeleteControl);
            this.Controls.Add(this.DataTierFolderControl);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Using Statements Removal Tool";
            this.ResumeLayout(false);

        }

        #endregion

        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl DataTierFolderControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl DeleteControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl FetchControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl InsertControl;
        private DataJuggler.Win.Controls.LabelTextBoxControl UpdateControl;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.ProgressBar Graph;
    }
}

