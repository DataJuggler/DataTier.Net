

#region using statements

using System;
using DataJuggler.Core.UltimateHelper;
using System.Windows.Forms;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;
using ObjectLibrary.BusinessObjects;
using DataGateway;
using System.ComponentModel;

#endregion

namespace DataTierClient.Controls
{

    #region class ReferencesSetEditor : UserControl, ISaveCancelControl, ITabButtonParent
    /// <summary>
    /// This class is designed to create or edit references set.
    /// </summary>
    public partial class ReferencesSetEditor : UserControl, ISaveCancelControl, ITabButtonParent
    {
    
        #region Private Variables
        private ReferencesSet selectedRefSet;
        private Project selectedProject;
        private ProjectReference selectedReference;
        private bool userCancelled;
        private ReferencesSet originalSet;
        #endregion

        #region Constructor()
        /// <summary>
        /// Create a new instance of a ReferencesSetEditor
        /// </summary>
        public ReferencesSetEditor()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this object.
            Init();
        }
        #endregion
        
        #region Events

            #region AddButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The add button was clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void AddButton_Click(object sender, EventArgs e)
            {
                // Create New Reference
                ProjectReference reference = CreateNewReference();
                
                // if the reference exists
                if ((reference != null) && (this.SelectedReferencesSet != null))
                {
                    // Add the reference to the selected references set
                    this.SelectedReferencesSet.References.Add(reference);
                    
                    // Display References
                    this.DisplayReferences();
                }
            }
            #endregion

            #region DeleteButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The delete button was clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void DeleteButton_Click(object sender, EventArgs e)
            {
                // if the SelectedReference exists
                if (NullHelper.Exists(SelectedReference, SelectedReferencesSet))
                {  
                    // get a local value
                    ProjectReference reference = this.SelectedReference;
                    
                    // get the index
                    int index = this.SelectedReferencesSet.GetReferenceIndex(reference.ReferencesId);

                    // delete the reference
                    Gateway gateway = new Gateway();
                    
                    // delete the ProjectReference
                    bool deleted = gateway.DeleteProjectReference(this.SelectedReference.ReferencesId);
                    
                    // if deleted
                    if (deleted)
                    {
                        // remove this item
                        this.SelectedReferencesSet.References.RemoveAt(index);

                        // redisplay the references
                        this.DisplayReferences();
                    }
                }
            }
            #endregion

            #region EditButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The edit button was clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void EditButton_Click(object sender, EventArgs e)
            {
                // Get the selected reference
                if(this.SelectedReference != null)
                {
                    // if not set
                    if (SelectedReferencesSet.IsNew)
                    {
                        // Set the ProjectId
                        SelectedReferencesSet.ProjectId = SelectedProject.ProjectId;
                    }

                    // Create 
                    ReferenceEditorForm editorForm = new ReferenceEditorForm();

                    // Setup Control
                    editorForm.ReferenceEditor.Setup(this.SelectedReference, this.SelectedReferencesSet);

                    // Show form to user
                    editorForm.ShowDialog();

                    // if the user did not cancel
                    if (!editorForm.UserCancelled)
                    {
                        // Redisplay the references
                        this.DisplayReferences();
                    }
                }
            }
            #endregion

            #region ReferencesListBox_DoubleClick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when References List Box _ Double Click
            /// </summary>
            private void ReferencesListBox_DoubleClick(object sender, EventArgs e)
            {
                // Simulate the tab button clicking
                OnTabButtonClicked(EditButton);
            }
            #endregion
            
            #region ReferencesListBox_SelectedIndexChanged(object sender, EventArgs e)
            /// <summary>
            /// An item was selected in the References list box.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReferencesListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Set the selected item
                this.SelectedReference = this.ReferencesListBox.SelectedItem as ProjectReference;
                
                // Enable controls
                UIEnable();
            }
            #endregion

            #region ReferencesSetNameTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// The references text box text has changed.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void ReferencesSetNameTextBox_TextChanged(object sender, EventArgs e)
            {
                // if the references set name exists
                if(this.SelectedReferencesSet != null)
                {
                    // Set the references set name
                    this.SelectedReferencesSet.ReferencesSetName = this.ReferencesSetNameTextBox.Text.ToString();

                    // enable the Save button if there are changes
                    UIEnable();
                }
            }
            #endregion
        
        #endregion
        
        #region Methods

            #region CheckForChanges()
            /// <summary>
            /// This method returns the For Changes
            /// </summary>
            private bool CheckForChanges()
            {
                // initial value
                bool changes = false;

                // if the SelectedReferencesSet exosts
                if (this.HasSelectedReferencesSet)
                {
                    // if the OriginalSet exists
                    if (this.HasOriginalSet)
                    {
                        // has changes
                        if (this.OriginalSet.ReferencesSetName != this.SelectedReferencesSet.ReferencesSetName)
                        {
                            // set to true
                            changes = true;
                        }
                        else if ((this.OriginalSet.References != null) && (this.SelectedReferencesSet.References != null))
                        {
                            // if the counts do not match
                            if (this.OriginalSet.References.Count != this.SelectedReferencesSet.References.Count)
                            {
                                // set to true
                                changes = true;
                            }
                            else
                            {
                                // iterate the References
                                foreach (ProjectReference reference in originalSet.References)
                                {
                                    // now we must find each reference
                                    int index = FindReferenceIndexByName(reference.ReferenceName);

                                    // if the index was not found
                                    if (index < 0)
                                    {
                                        // changes 
                                        changes = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // set to true
                        changes = true;
                    }
                }

                // return value
                return changes;
            }  
            #endregion
            
            #region CreateNewReference()
            /// <summary>
            /// Create new ProjectReference
            /// </summary>
            /// <returns></returns>
            private ProjectReference CreateNewReference()
            {
                // initial value
                ProjectReference reference = new ProjectReference();
                
                // local
                ProjectReference newReference = new ProjectReference();
                
                // Create 
                ReferenceEditorForm editorForm = new ReferenceEditorForm();
                
                // Setup Control
                editorForm.ReferenceEditor.Setup(newReference, this.SelectedReferencesSet);
                
                // Show form to user
                editorForm.ShowDialog();
                
                // if the user did not cancel
                if(!editorForm.UserCancelled)
                {
                    // get reference
                    reference = editorForm.ReferenceEditor.SelectedReference;
                }  
                else
                {
                    // set to null
                    reference = null;
                }              
                
                // return value
                return reference;
            } 
            #endregion

            #region DisplayReferences()
            /// <summary>
            /// This method displays the current referenceSet and the
            /// references.
            /// </summary>
            private void DisplayReferences()
            {
                // Clear all items
                this.ReferencesListBox.Items.Clear();
                
                // if the ReferencesList exist.
                if (this.SelectedReferencesSet != null) 
                {
                    // Clear the text box
                    this.ReferencesSetNameTextBox.Text = this.SelectedReferencesSet.ReferencesSetName;
                    
                    // loop through each reference
                    foreach (ProjectReference reference in this.SelectedReferencesSet.References)
                    {
                        // Add this reference
                        this.ReferencesListBox.Items.Add(reference);
                    }
                }

                // enable the buttons
                UIEnable();
            }
            #endregion

            #region FindReferenceIndexByName(string name)
            /// <summary>
            /// This method returns the Index By Name
            /// </summary>
            public int FindReferenceIndexByName(string name)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // if the original set exists
                if (HasOriginalSet)
                {
                    // iterate the references
                    foreach (ProjectReference reference in this.SelectedReferencesSet.References)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this is the itemi being sought
                        if (TextHelper.IsEqual(reference.ReferenceName, name))
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return index;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Default to user cancelled
                this.UserCancelled = true;
                
                // Enable controls
                UIEnable();
            }
            #endregion
          
            #region OnCancel()
            /// <summary>
            /// This method implements the OnCancel method.
            /// </summary>
            public void OnCancel()
            {
                // If the ParentForm exists
                if (this.ParentForm != null)
                {
                    // Close Form
                    this.ParentForm.Close();
                }
            }
            #endregion
            
            #region OnSave()
            /// <summary>
            /// This method implements the OnSave method.
            /// </summary>
            public void OnSave()
            {
                // if the SelectedReferencesSet exists
                if(this.SelectedReferencesSet != null)
                {   
                    // if the SelectedProject.AllReferences exists
                    if ((this.SelectedProject != null) && (this.SelectedProject.AllReferences != null))
                    {
                        // get the index
                        int index = this.SelectedProject.GetReferencesSetIndex(this.SelectedReferencesSet.ReferencesSetId);
                        
                        // if the item was found in the collection
                        if(index >= 0)
                        {
                            // update this item
                            this.SelectedProject.AllReferences[index] = this.SelectedReferencesSet;
                        }
                        else
                        {
                            // Add this ReferencesSet
                            this.SelectedProject.AllReferences.Add(this.SelectedReferencesSet);
                        }
                    }
                    
                    // User Did Not Cancel
                    this.UserCancelled = false;

                    // If the ParentForm exists
                    if (this.ParentForm != null)
                    {
                        // Close Form
                        this.ParentForm.Close();
                    }
                }
            }
            #endregion

            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// A tab button was clicked. 
            /// </summary>
            /// <param name="buttonText"></param>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // determine action by the button text
                switch (tabButton.ButtonText)
                {
                    case "Add":

                        // call the AddButton_Click event
                        AddButton_Click(this, null);

                        // required
                        break;

                    case "Edit":

                        // Call the EditButton_Click event
                        EditButton_Click(this, null);

                        // required
                        break;

                    case "Delete":

                        // Call the DeleteButton_Click event
                        DeleteButton_Click(this, null);

                        // required
                        break;
                }
            }
            #endregion

            #region Setup(ReferencesSet referenceSet)
            /// <summary>
            /// This method prepares this control to be launched.
            /// </summary>
            public void Setup(ReferencesSet referenceSet)
            {
                // clone the original set
                this.OriginalSet = referenceSet.Clone();
                
                // Set selected references set
                this.SelectedReferencesSet = referenceSet;
                
                // set to Create
                string formText = "Create New References Set";
                
                // if the reference exists
                if ((this.SelectedReferencesSet != null) && (!this.SelectedReferencesSet.IsNew))
                {
                    // set to edit
                    formText = "Edit References Set";    
                }
                
                // Display References
                this.DisplayReferences();
                
                // if the parent form exists
                if(this.ParentForm != null)
                {
                    // set header text on the form
                    this.ParentForm.Text = formText;
                }
            }
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method enables controls on this control
            /// </summary>
            private void UIEnable()
            {
                // Enable the controls if there is a selected reference
                this.EditButton.Enabled = (this.SelectedReference != null);
                this.DeleteButton.Enabled = (this.SelectedReference != null);
               
                // check for changes
                bool hasChanges = CheckForChanges();

                // enable the Save button if there are changes
                this.SaveCancelControl.EnableSaveButton(hasChanges);
                
                // Refresh this control
                this.Refresh();
            }
            #endregion
        
        #endregion

        #region Properties

            #region HasOriginalSet
            /// <summary>
            /// This property returns true if this object has an 'OriginalSet'.
            /// </summary>
            public bool HasOriginalSet
            {
                get
                {
                    // initial value
                    bool hasOriginalSet = (this.OriginalSet != null);
                    
                    // return value
                    return hasOriginalSet;
                }
            }
            #endregion
            
            #region HasSelectedReferencesSet
            /// <summary>
            /// This property returns true if this object has a 'SelectedReferencesSet'.
            /// </summary>
            public bool HasSelectedReferencesSet
            {
                get
                {
                    // initial value
                    bool hasSelectedReferencesSet = (this.SelectedReferencesSet != null);
                    
                    // return value
                    return hasSelectedReferencesSet;
                }
            }
            #endregion
            
            #region OriginalSet
            /// <summary>
            /// This property gets or sets the value for 'OriginalSet'.
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ReferencesSet OriginalSet
            {
                get { return originalSet; }
                set { originalSet = value; }
            }
            #endregion
            
            #region SelectedProject
            /// <summary>
            /// The SelectedProject.
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Project SelectedProject
            {
                get { return selectedProject; }
                set { selectedProject = value; }
            }
            #endregion

            #region SelectedReference
            /// <summary>
            /// The SelecedReference from the grid.
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ProjectReference SelectedReference
            {
                get { return selectedReference; }
                set { selectedReference = value; }
            } 
            #endregion

            #region SelectedReferencesSet
            /// <summary>
            /// The ReferencesSet currently being created or edited.
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ReferencesSet SelectedReferencesSet
            {
                get { return selectedRefSet; }
                set 
                { 
                    if (value != null)
                    {
                        selectedRefSet = value;
                    }
                }
            }
            #endregion

            #region UserCancelled
            /// <summary>
            /// Did the user cancel the current edit.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
        #endregion

        #endregion
    }
    #endregion
    
}
