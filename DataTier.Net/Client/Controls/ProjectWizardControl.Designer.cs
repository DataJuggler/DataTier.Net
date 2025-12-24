

#region using statements


#endregion

namespace DataTierClient.Controls
{

    #region class ProjectWizardControl
    /// <summary>
    /// This class is used to edit this project
    /// </summary>
    partial class ProjectWizardControl
    {
        
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private WizardStatusControl WizardStatusControl;
        private WizardControlPanel WizardControlPanel;
        private System.Windows.Forms.Panel MainPanel;
        private DatabasesEditor DatabasesEditor;
        private ControllerEditor ControllerEditor;
        private DataOperationsEditor DataOperationsEditor;
        private DataManagerEditor DataManagerEditor;
        private DataObjectsEditor DataObjectsEditor;
        private WriterEditor WriterEditor;
        private ReaderEditor ReaderEditor;
        private StoredProcedureEditor StoredProcedureEditor;
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ProjectEditor = new DataTierClient.Controls.ProjectEditorControl();
            this.StoredProcedureEditor = new DataTierClient.Controls.StoredProcedureEditor();
            this.WriterEditor = new DataTierClient.Controls.WriterEditor();
            this.ControllerEditor = new DataTierClient.Controls.ControllerEditor();
            this.DataOperationsEditor = new DataTierClient.Controls.DataOperationsEditor();
            this.DataManagerEditor = new DataTierClient.Controls.DataManagerEditor();
            this.DataObjectsEditor = new DataTierClient.Controls.DataObjectsEditor();
            this.ReaderEditor = new DataTierClient.Controls.ReaderEditor();
            this.DatabasesEditor = new DataTierClient.Controls.DatabasesEditor();
            this.WizardControlPanel = new DataTierClient.Controls.WizardControlPanel();
            this.WizardStatusControl = new DataTierClient.Controls.WizardStatusControl();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ProjectEditor);
            this.MainPanel.Controls.Add(this.StoredProcedureEditor);
            this.MainPanel.Controls.Add(this.WriterEditor);
            this.MainPanel.Controls.Add(this.ControllerEditor);
            this.MainPanel.Controls.Add(this.DataOperationsEditor);
            this.MainPanel.Controls.Add(this.DataManagerEditor);
            this.MainPanel.Controls.Add(this.DataObjectsEditor);
            this.MainPanel.Controls.Add(this.ReaderEditor);
            this.MainPanel.Controls.Add(this.DatabasesEditor);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(180, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(672, 308);
            this.MainPanel.TabIndex = 2;
            // 
            // ProjectEditor
            // 
            this.ProjectEditor.Attempts = 0;
            this.ProjectEditor.BackColor = System.Drawing.Color.Transparent;
            this.ProjectEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectEditor.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectEditor.Location = new System.Drawing.Point(0, 0);
            this.ProjectEditor.Name = "ProjectEditor";
            this.ProjectEditor.NextControl = DataTierClient.Enumerations.ActiveControlEnum.DatabasesTab;
            this.ProjectEditor.PrevControl = DataTierClient.Enumerations.ActiveControlEnum.NotSet;
            this.ProjectEditor.ShowAutoFillHelp = false;
            this.ProjectEditor.Size = new System.Drawing.Size(655, 308);
            this.ProjectEditor.TabIndex = 12;
            // 
            // StoredProcedureEditor
            // 
            this.StoredProcedureEditor.BackColor = System.Drawing.Color.Transparent;
            this.StoredProcedureEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StoredProcedureEditor.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoredProcedureEditor.Location = new System.Drawing.Point(0, 0);
            this.StoredProcedureEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StoredProcedureEditor.Name = "StoredProcedureEditor";
            this.StoredProcedureEditor.NextControl = DataTierClient.Enumerations.ActiveControlEnum.NotSet;
            this.StoredProcedureEditor.PrevControl = DataTierClient.Enumerations.ActiveControlEnum.WritersTab;
            this.StoredProcedureEditor.SelectedReferencesSet = null;
            this.StoredProcedureEditor.Size = new System.Drawing.Size(655, 308);
            this.StoredProcedureEditor.TabIndex = 11;
            // 
            // WriterEditor
            // 
            this.WriterEditor.BackColor = System.Drawing.Color.Transparent;
            this.WriterEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WriterEditor.Location = new System.Drawing.Point(0, 0);
            this.WriterEditor.Name = "WriterEditor";
            this.WriterEditor.SelectedReferencesSet = null;
            this.WriterEditor.Size = new System.Drawing.Size(655, 308);
            this.WriterEditor.TabIndex = 9;
            // 
            // ControllerEditor
            // 
            this.ControllerEditor.BackColor = System.Drawing.Color.Transparent;
            this.ControllerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControllerEditor.Location = new System.Drawing.Point(0, 0);
            this.ControllerEditor.Name = "ControllerEditor";
            this.ControllerEditor.Size = new System.Drawing.Size(655, 308);
            this.ControllerEditor.TabIndex = 7;
            // 
            // DataOperationsEditor
            // 
            this.DataOperationsEditor.BackColor = System.Drawing.Color.Transparent;
            this.DataOperationsEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataOperationsEditor.Location = new System.Drawing.Point(0, 0);
            this.DataOperationsEditor.Name = "DataOperationsEditor";
            this.DataOperationsEditor.SelectedReferencesSet = null;
            this.DataOperationsEditor.Size = new System.Drawing.Size(655, 308);
            this.DataOperationsEditor.TabIndex = 6;
            // 
            // DataManagerEditor
            // 
            this.DataManagerEditor.BackColor = System.Drawing.Color.Transparent;
            this.DataManagerEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataManagerEditor.Location = new System.Drawing.Point(0, 0);
            this.DataManagerEditor.Name = "DataManagerEditor";
            this.DataManagerEditor.SelectedReferencesSet = null;
            this.DataManagerEditor.Size = new System.Drawing.Size(655, 308);
            this.DataManagerEditor.TabIndex = 5;
            // 
            // DataObjectsEditor
            // 
            this.DataObjectsEditor.BackColor = System.Drawing.Color.Transparent;
            this.DataObjectsEditor.Dock = System.Windows.Forms.DockStyle.Right;
            this.DataObjectsEditor.Location = new System.Drawing.Point(655, 0);
            this.DataObjectsEditor.Name = "DataObjectsEditor";
            this.DataObjectsEditor.NextControl = DataTierClient.Enumerations.ActiveControlEnum.DataManagerTab;
            this.DataObjectsEditor.PrevControl = DataTierClient.Enumerations.ActiveControlEnum.DatabasesTab;
            this.DataObjectsEditor.Size = new System.Drawing.Size(17, 308);
            this.DataObjectsEditor.TabIndex = 4;
            // 
            // ReaderEditor
            // 
            this.ReaderEditor.BackColor = System.Drawing.Color.Transparent;
            this.ReaderEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReaderEditor.Location = new System.Drawing.Point(0, 0);
            this.ReaderEditor.Name = "ReaderEditor";
            this.ReaderEditor.NextControl = DataTierClient.Enumerations.ActiveControlEnum.WritersTab;
            this.ReaderEditor.PrevControl = DataTierClient.Enumerations.ActiveControlEnum.ControllersTab;
            this.ReaderEditor.SelectedReferencesSet = null;
            this.ReaderEditor.Size = new System.Drawing.Size(672, 308);
            this.ReaderEditor.TabIndex = 8;
            // 
            // DatabasesEditor
            // 
            this.DatabasesEditor.BackColor = System.Drawing.Color.Transparent;
            this.DatabasesEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabasesEditor.Location = new System.Drawing.Point(0, 0);
            this.DatabasesEditor.Name = "DatabasesEditor";
            this.DatabasesEditor.NextControl = DataTierClient.Enumerations.ActiveControlEnum.DataObjectsTab;
            this.DatabasesEditor.PrevControl = DataTierClient.Enumerations.ActiveControlEnum.ProjectsTab;
            this.DatabasesEditor.SelectedDatabase = null;
            this.DatabasesEditor.Size = new System.Drawing.Size(672, 308);
            this.DatabasesEditor.TabIndex = 2;
            // 
            // WizardControlPanel
            // 
            this.WizardControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.WizardControlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WizardControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WizardControlPanel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WizardControlPanel.Location = new System.Drawing.Point(180, 308);
            this.WizardControlPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.WizardControlPanel.Name = "WizardControlPanel";
            this.WizardControlPanel.Size = new System.Drawing.Size(672, 52);
            this.WizardControlPanel.TabIndex = 1;
            // 
            // WizardStatusControl
            // 
            this.WizardStatusControl.BackColor = System.Drawing.Color.LightSteelBlue;
            this.WizardStatusControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WizardStatusControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.WizardStatusControl.Location = new System.Drawing.Point(0, 0);
            this.WizardStatusControl.Name = "WizardStatusControl";
            this.WizardStatusControl.SelectedButton = null;
            this.WizardStatusControl.Size = new System.Drawing.Size(180, 360);
            this.WizardStatusControl.TabIndex = 0;
            // 
            // ProjectWizardControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.WizardControlPanel);
            this.Controls.Add(this.WizardStatusControl);
            this.Name = "ProjectWizardControl";
            this.Size = new System.Drawing.Size(852, 360);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            }
        #endregion

        #endregion

        private ProjectEditorControl ProjectEditor;
    }
    #endregion

}



