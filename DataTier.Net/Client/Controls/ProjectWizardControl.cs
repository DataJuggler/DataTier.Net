
#region using statements

using ObjectLibrary.BusinessObjects;
using DataAccessComponent.DataGateway;
using DataAccessComponent.ClientValidation;
using DataAccessComponent.Controllers;
using DataAccessComponent.Connection;
using System;
using System.Windows.Forms;
using DataTierClient.Controls.Interfaces;
using DataTierClient.ClientUtil;
using DataTierClient.Enumerations;
using DataTierClient.Forms;
using DataTierClient.Controls.Images;
using System.Drawing;

#endregion

namespace DataTierClient.Controls
{

    #region class ProjectWizardControl : UserControl
    /// <summary>
    /// The ProjectWizardControl edits all aspects of a project.
    /// </summary>
    public partial class ProjectWizardControl : UserControl
    {
        
        #region Private Variables
        private byte[] initialSelectedProject;
        private MainForm parentMainForm;
        private IWizardControl selectedControl;
        private ActiveControlEnum selectedButton;
        private Project selectedProject;
        #endregion

        #region Constructor()
        /// <summary>
        ///  Create a new instance of a ProjectWizardControl.
        /// </summary>
        public ProjectWizardControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this object.
            Init();
        }
        #endregion

        #region Methods

            #region ButtonSelected(ActiveControlEnum button)
            /// <summary>
            /// A button was selected in the WizardStatusControl.
            /// </summary>
            internal void ButtonSelected(ActiveControlEnum button)
            {
                // Make All Buttons Invisible
                HideControls();
                
                // Set SelectedControl to Null
                SelectedControl = null;

                // Set the selected button
                SelectedButton = button;
                
                // Determine Which Button To Make Visible
                switch(button)
                {
                    case ActiveControlEnum.ProjectsTab:
                        
                        // Set SelectedControl
                        SelectedControl = ProjectEditor;
                        
                        // required
                        break;

                    case ActiveControlEnum.DatabasesTab:

                        // Set SelectedControl
                        SelectedControl = DatabasesEditor;

                        // required
                        break;

                    case ActiveControlEnum.DataObjectsTab:

                        // Set SelectedControl
                        SelectedControl = DataObjectsEditor;

                        // required
                        break;

                    case ActiveControlEnum.DataManagerTab:

                        // set selected control
                        SelectedControl = DataManagerEditor;

                        // required
                        break;

                    case ActiveControlEnum.DataOperationsTab:

                        // set selected control
                        SelectedControl = DataOperationsEditor;

                        // required
                        break;

                    case ActiveControlEnum.ControllersTab:

                        // set selected control
                        SelectedControl = ControllerEditor;

                        // required
                        break;

                    case ActiveControlEnum.ReadersTab:

                        // set selected control
                        SelectedControl = ReaderEditor;

                        // required
                        break;
                        
                    case ActiveControlEnum.WritersTab:

                        // set selected control
                        SelectedControl = WriterEditor;

                        // required
                        break;

                    case ActiveControlEnum.StoredProceduresTab:

                        // set selected control
                        SelectedControl = StoredProcedureEditor;

                        // required
                        break;  
                }
                
                // if a selected control has been set
                if(SelectedControl != null)
                {
                    // Notify the wizard control
                    WizardStatusControl.SetSelectedButton(button);
                
                    // Cast the selected control as a control so the visible property 
                    // can be set
                    Control control = SelectedControl as Control;
                    
                    // if the control exists
                    if(control != null)
                    {
                        // set this control to visible
                        control.Visible = true;    
                    }
                    
                    // Display the selected cotnrol
                    SelectedControl.DisplaySelectedProject();
                    
                    // Enable Controls
                    UIEnable();
                }
                
                // Refresh
                Refresh();
            }
            #endregion

            #region DisplaySelectedObject()
            /// <summary>
            /// This method displays the active control.
            /// </summary>
            public void DisplaySelectedObject()
            {
                // Display selected project
                if(SelectedControl != null)
                {
                    // Display the selected project on the selected control.
                    SelectedControl.DisplaySelectedProject();   
                }    
            }
            #endregion

            #region HideControls()
            /// <summary>
            /// This method hides all controls on the MainPanel.
            /// </summary>
            private void HideControls()
            {
                // loop throgh all controls
                foreach(Control control in MainPanel.Controls)
                {
                    // hide this control. 
                    control.Visible = false;
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// Perform any initializations needed for this object.
            /// </summary>
            private void Init()
            {
                // Call the init for each control
                foreach(Control control in MainPanel.Controls)
                {
                    // call the Init for each method
                    IWizardControl wizardControl = control as IWizardControl;
                    
                    // if the wizard control exists
                    if(wizardControl != null)
                    {
                        // Call the Init method
                        wizardControl.Init();
                    }
                }
            
                // Set the SelectedControl to the ProjectsTab
                ButtonSelected(ActiveControlEnum.ProjectsTab);

                // Enable the controls
                UIEnable();
            }
            #endregion

            #region MovePrev()
            /// <summary>
            /// This method moves the ActiveControl to the 
            /// Previous Control. 
            /// </summary>
            internal void MovePrev()
            {
                // if the SelectedControl exists
                if (SelectedControl != null)
                {
                    // Move to the next control
                    ButtonSelected(SelectedControl.PrevControl);
                }      
            }
            #endregion 

            #region MoveNext()
            /// <summary>
            /// This method moves the ActiveControl to the Next control.
            /// </summary>
            internal void MoveNext()
            {
                // if the SelectedControl exists
                if(SelectedControl != null)
                {
                    // Move to the next control
                    ButtonSelected(SelectedControl.NextControl);
                }   
            }
            #endregion

            #region SaveAndClose()
            /// <summary>
            /// This method saves and closes this form.
            /// </summary>
            internal void SaveAndClose()
            {
                // Create a new instance of a 'DataGateway' object.
                Gateway gateway = new Gateway(ConnectionConstants.Name);

                // locals
				bool databasesSaved = false;
                bool referencesSaved = false;
                bool saved = false;
                Exception error = null;

                try
                {
                    // if the parent form exists
                    if (ParentForm != null)
                    {
                        // turn on cursor 
                        ParentForm.Cursor = Cursors.WaitCursor;
                    }

                    // If the selected project exists
                    if (SelectedProject != null)
                    {
                        // Set the current directory back

                        // Save the selected proejct
                        saved = gateway.SaveProject(ref selectedProject);

                        // if saved
                        if (saved)
                        { 
                            // save the children (sounds like a commerical for .55 cents per day)

							// set projectId on each database
							SelectedProject.SetProjectIdOnDatabases(SelectedProject.ProjectId);
                            
                            // set projectID on each ReferencesSet
							SelectedProject.SetProjectIdOnReferences(SelectedProject.ProjectId);

                            // Save the databases for this project
                            databasesSaved = SaveProjectDatabases(gateway);

                            // save references
							referencesSaved = gateway.SaveProjectReferences(ref selectedProject);
                            
							// If the references did not save
							if ((!referencesSaved) && (error != null))
							{
								// Set the exception
								error = gateway.GetLastException();
							}

							// if child objects saved
							if ((!databasesSaved) || (!referencesSaved))
							{
								// save failed
								saved = false;
							}
                        }
                    }

                    // If the save failed
                    if (!saved)
                    {
                        // get the last exception
                        error = gateway.GetLastException();

                        // get message
                        string message = "";
                        string title = "Save Failed";

                        // if the error exists
                        if (error != null)
                        {
                            // set the message
                            message = "An error occurred saving the selected 'Project'. The error thrown was: " + Environment.NewLine + error.ToString();
                        }
                        else
                        {
                            if (!referencesSaved)
                            {
                                // set the message
                                message = "An error occurred saving the selected 'Project'. The project could not be saved";
                            }
                            else if (!databasesSaved)
                            {
                                // set the message
                                message = "An error occurred saving the selected 'Project'. The database(s) could not be saved";
                            }
                        }

                        // Inform user of error
                        MessageHelper.DisplayMessage(message, title);
                    }

                    // Close this form
                    if ((WizardForm != null) && (saved))
                    {
                        // Close this form
                        WizardForm.Close();
                    }
                }
                catch (Exception error2)
                {
                    string title = "Save Error";
                    string message = "The project could not be saved." + Environment.NewLine + error2.ToString();
                
                    // show error
                    MessageHelper.DisplayMessage(message, title);
                }
                finally
                {
                    // if the parent form exists
                    if (ParentForm != null)
                    {
                        // turn off cursor before closing
                        ParentForm.Cursor = Cursors.Default;
                    }
                }
            }
            #endregion

            #region SaveProjectDatabases(Gateway gateway)
            /// <summary>
            /// This method saves the Project Databases.
            /// </summary>
            public bool SaveProjectDatabases(Gateway gateway)
            {
                // initial value
                bool databasesSaved = false;
                bool tempSaved = false;

                // if the SelectedProject has Databases
				if ((SelectedProject.HasDatabases) && (selectedProject.Databases.Count > 0))
                {
                    // default to true until a failure happens
                    databasesSaved = true;

                    // iterate the Databases
                    foreach (DTNDatabase database in SelectedProject.Databases)
                    {
                        // clone the object so it can be saved by reference
                        DTNDatabase tempDatabase = database.Clone();

                        // save the DTNDatabase
                        tempSaved = gateway.SaveDTNDatabase(ref tempDatabase);

                        // if the value for tempSaved is false
                        if (!tempSaved)
                        {
                            // set to false
                            databasesSaved = false;
                        }
                    }
                }
                
                // return value
                return databasesSaved;
            }
            #endregion

            #region SetFocusToProjectNameControl()
            /// <summary>
            /// This method Set Focus To Project Name Control
            /// </summary>
            internal void SetFocusToProjectNameControl()
            {
                // Set Focus To The ProjectNameControl
                ProjectEditor.SetFocusToProjectNameControl();
            }
            #endregion
            
            #region SetImages(Image selectedImage, Image notSelectedImage)
            /// <summary>
            /// This method sets the images for the controls.
            /// </summary>
            /// <param name="selectedImage"></param>
            /// <param name="notSelectedImage"></param>
            internal void SetImages(Image selectedImage, Image notSelectedImage)
            {
                // set the images
                ImageHelper.SetSelectedAndNotSelectedImages(WizardStatusControl.Controls, selectedImage, notSelectedImage);

                // refresh this control
                Refresh();
            }
            #endregion

            #region Setup(Project projectArg, ActiveControlEnum activeControl, MainForm mainForm)
            /// <summary>
            /// This method is used to prepare this control.
            /// </summary>
            /// <param name="controllerArg"></param>
            /// <param name="projectArg"></param>
            internal void Setup(Project projectArg, ActiveControlEnum activeControl, MainForm mainForm)
            {
                 // Set Properties
                 SelectedProject = projectArg;

                 // Set ParentMainForm
                 ParentMainForm = mainForm;
                 
                 // Set the text
                 WizardForm.Text = "New Project";
                 
                 // if the selected project exists
                 if(SelectedProject != null)
                 {
                    // If this is an existing project
                    if(!SelectedProject.IsNew)
                    {
                        // Set the text to edit project
                        WizardForm.Text = "Edit Project";
                    }
                 
                    // Create the initial selected proejct
                    InitialSelectedProject = SerializationManager.SerializeObject(SelectedProject);
                 }
                 
                 // Set Selected Control
                 ButtonSelected(activeControl);
            }
            #endregion
            
            #region Validate()
            /// <summary>
            /// This method validates the sourceObject passed in.
            /// </summary>
            /// <returns></returns>
            public new bool Validate()
            {
                // initial value
                bool valid = false;
                
                // If the SelectedProject exists
                if (HasSelectedProject)
                {
                    // Create a ClientValidationManager
                    ClientValidationManager clientValidationManager = new ClientValidationManager();

                    // Create required fields
                    
                    // Create Project Required Fields
                    RequiredField projectNameField = new RequiredField("ProjectName", RequiredField.CreateMissingRequiredFieldMessage("Project Name", SelectedProject.ProjectName, false), SelectedProject, false);
                    RequiredField projectFolderField = new RequiredField("ProjectFolder", RequiredField.CreateMissingRequiredFieldMessage("Project Folder", SelectedProject.ProjectFolder, true), SelectedProject, true);

                    // Create Object Required Fields
                    RequiredField objectFolderField = new RequiredField("ObjectFolder", RequiredField.CreateMissingRequiredFieldMessage("Object Folder", SelectedProject.ObjectFolder, true), SelectedProject, true);
                    RequiredField objectNamespaceField = new RequiredField("ObjectNamespace", RequiredField.CreateMissingRequiredFieldMessage("Object Namespace", SelectedProject.ObjectNamespace, false), SelectedProject, false);

                    // Create DataManager Required Fields
                    RequiredField dataManagerFolderField = new RequiredField("DataManagerFolder", RequiredField.CreateMissingRequiredFieldMessage("Data Manager Folder", SelectedProject.DataManagerFolder, true), SelectedProject, true);
                    RequiredField dataManagerNamespaceField = new RequiredField("DataManagerNamespace", RequiredField.CreateMissingRequiredFieldMessage("Data Manager Namespace", SelectedProject.DataManagerNamespace, false), SelectedProject, false);
                    
                    // Create DataOperations Required Fields
                    RequiredField dataOperationsFolderField = new RequiredField("DataOperationsFolder", RequiredField.CreateMissingRequiredFieldMessage("Data Operations Folder", SelectedProject.DataOperationsFolder, true), SelectedProject, true);
                    RequiredField dataOperationsNamespaceField = new RequiredField("DataOperationsNamespace", RequiredField.CreateMissingRequiredFieldMessage("Data Operations Namespace", SelectedProject.DataOperationsNamespace, false), SelectedProject, false);

                    // Create Controller Required Fields
                    RequiredField controllerFolderField = new RequiredField("ControllerFolder", RequiredField.CreateMissingRequiredFieldMessage("Controller Folder", SelectedProject.ControllerFolder, true), SelectedProject, true);
                    RequiredField controllerNamespaceField = new RequiredField("ControllerNamespace", RequiredField.CreateMissingRequiredFieldMessage("Controller Namespace", SelectedProject.ControllerNamespace, false), SelectedProject, false);

                    // Create Reader Required Fields
                    RequiredField readerFolderField = new RequiredField("ReaderFolder", RequiredField.CreateMissingRequiredFieldMessage("Reader Folder", SelectedProject.ReaderFolder, true), SelectedProject, true);
                    RequiredField readerNamespaceField = new RequiredField("ReaderNamespace", RequiredField.CreateMissingRequiredFieldMessage("Reader Namespace", SelectedProject.ReaderNamespace, false), SelectedProject, false);

                    // Create Writer Required Fields
                    RequiredField writerFolderField = new RequiredField("DataWriterFolder", RequiredField.CreateMissingRequiredFieldMessage("Writer Folder", SelectedProject.DataWriterFolder, true), SelectedProject, true);
                    RequiredField writerNamespaceField = new RequiredField("DataWriterNamespace", RequiredField.CreateMissingRequiredFieldMessage("Writer Namespace", SelectedProject.DataWriterNamespace, false), SelectedProject, false);
                    
                    // Create StoredProcedure Required Fields
                    RequiredField storedProcFolderField = new RequiredField("StoredProcedureObjectFolder", RequiredField.CreateMissingRequiredFieldMessage("Stored Procedure Object Folder", SelectedProject.StoredProcedureObjectFolder, true), SelectedProject, true);
                    RequiredField storedProcNamespaceField = new RequiredField("StoredProcedureObjectNamespace", RequiredField.CreateMissingRequiredFieldMessage("Stored Procedure Object Namespace", SelectedProject.StoredProcedureObjectNamespace, false), SelectedProject, false);

                    // if V2 of Templates
                    if (SelectedProject.Ta == 2)
                    {
                        string temp = SelectedProject.DataManagerFolder;
                    }
                    
                    // Add Required Fields
                    
                    // Add Project Fields
                    clientValidationManager.RequiredFields.Add(projectNameField);
                    clientValidationManager.RequiredFields.Add(projectFolderField);

                    // Add Object Required Fields
                    clientValidationManager.RequiredFields.Add(objectFolderField);
                    clientValidationManager.RequiredFields.Add(objectNamespaceField);
                    
                    // Add DataManager Required Fields
                    clientValidationManager.RequiredFields.Add(dataManagerFolderField);
                    clientValidationManager.RequiredFields.Add(dataManagerNamespaceField);
                    
                    // Add DataOperations Required Fields
                    clientValidationManager.RequiredFields.Add(dataOperationsFolderField);
                    clientValidationManager.RequiredFields.Add(dataOperationsNamespaceField);
                    
                    // Add Controller Required Fields
                    clientValidationManager.RequiredFields.Add(controllerFolderField);
                    clientValidationManager.RequiredFields.Add(controllerNamespaceField);

                    // Add Reader Required Fields
                    clientValidationManager.RequiredFields.Add(readerFolderField);
                    clientValidationManager.RequiredFields.Add(readerNamespaceField);

                    // Add Writer Required Fields
                    clientValidationManager.RequiredFields.Add(writerFolderField);
                    clientValidationManager.RequiredFields.Add(writerNamespaceField);
                    
                    // Add Stored Procedure Writer Fields
                    clientValidationManager.RequiredFields.Add(storedProcFolderField);
                    clientValidationManager.RequiredFields.Add(storedProcNamespaceField);

                    // Valildate this object. 
                    valid = clientValidationManager.Validate(SelectedProject);

                    // if this object is not valid
                    if (!valid)
                    {
                        // Create a new instance of a 'ValidationForm' object.
                        ValidationForm validationForm = new ValidationForm();    

                        // Setup the ClientValidationManager
                        validationForm.Setup(clientValidationManager);
                        
                        // Show the form
                        validationForm.ShowDialog();
                    }
                }

                // return value
                return valid;
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method enables controls for this object.
            /// </summary>
            internal void UIEnable()
            {
                // locals
                bool backEnabled = false;
                bool nextEnabled = false;
                bool saveEnabled = false;
                
                // If we have a SelectedControl
                if(SelectedControl != null)
                {
                    // set the values
                    backEnabled = (SelectedControl.PrevControl != ActiveControlEnum.NotSet);
                    nextEnabled = (SelectedControl.NextControl != ActiveControlEnum.NotSet);
                    
                    // if the initial selected project exists
                    if(InitialSelectedProject != null)
                    {
                        // has the object changed
                        saveEnabled = SerializationManager.HasObjectChanged(InitialSelectedProject, SelectedProject);
                    }
                }
                
                // set the values
                WizardControlPanel.BackButton.Enabled = backEnabled;
                WizardControlPanel.NextButton.Enabled = nextEnabled;
                WizardControlPanel.SaveButton.Enabled = saveEnabled;

                // always enable the DoneButton
                WizardControlPanel.DoneButton.Enabled = true;
                WizardControlPanel.DoneButton.Selected = true;

                // Refresh
                Refresh();
            }
            #endregion
        
        #endregion
        
        #region Properties

            #region InitialSelectedProject
            /// <summary>
            /// This object is a serialized copy of the SelectedProject.
            /// This object is used in conjuction with the IsDirty property
            /// of the ProjectWizardControl to determine if the SelectedProject
            /// has changed and needs to be saved (inserted or updated).
            /// </summary>
            public byte[] InitialSelectedProject
            {
                get { return initialSelectedProject; }
                set { initialSelectedProject = value; }
            }
            #endregion
            
            #region HasParentMainForm
            /// <summary>
            /// Does this object have a ParentMainForm.
            /// </summary>
            public bool HasParentMainForm
            {
                get
                {
                    // initial value
                    bool hasParentMainForm = (ParentMainForm != null);

                    // return value
                    return hasParentMainForm;
                }
            } 
            #endregion

            #region HasSelectedProject
            /// <summary>
            /// Does this object have a selected project.
            /// </summary>
            public bool HasSelectedProject
            {
                get
                {
                    // initial value
                    bool hasSelectedProject = (SelectedProject != null);
                    
                    // return value
                    return hasSelectedProject;
                }
            } 
            #endregion

            #region ParentMainForm
            /// <summary>
            /// A reference to the MainForm for this application.
            /// </summary>
            public MainForm ParentMainForm
            {
                get { return parentMainForm; }
                set { parentMainForm = value; }
            }
            #endregion
            
            #region SelectedButton
            /// <summary>
            /// The SelectedButton
            /// </summary>
                
            public ActiveControlEnum SelectedButton
            {
                get { return selectedButton; }
                set { selectedButton = value; }
            }
            #endregion

            #region SelectedControl
            /// <summary>
            /// The SelectedControl for the ProjectWizardControl.
            /// </summary>
            public IWizardControl SelectedControl
            {
                get { return selectedControl; }
                set { selectedControl = value; }
            }
            #endregion

            #region SelectedProject
            /// <summary>
            /// The project currently being created or edited.
            /// </summary>
            public Project SelectedProject
            {
                get { return selectedProject; }
                set { selectedProject = value; }
            } 
            #endregion

            #region WizardForm
            /// <summary>
            /// This property is the parent form of this control.
            /// </summary>
            public ProjectWizardForm WizardForm
            {
                get
                {
                    // initial value
                    ProjectWizardForm wizardForm = Parent as ProjectWizardForm;

                    // return value
                    return wizardForm;

                }
            }
            #endregion
        
        #endregion

    }
    #endregion
    
}
