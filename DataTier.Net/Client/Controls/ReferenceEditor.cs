

#region using statements

using System;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using DataTierClient.Controls.Interfaces;
using DataAccessComponent.Connection;
using DataAccessComponent.DataGateway;
using System.ComponentModel;

#endregion


namespace DataTierClient.Controls
{

    #region class ReferenceEditor : UserControl, ISaveCancelControl
    /// <summary>
    /// This control edits a ProjectReference.
    /// </summary>
    public partial class ReferenceEditor : UserControl, ISaveCancelControl
    {
    
        #region Private Variables
        private ProjectReference selectedReference;
        private ProjectReference originalReference;
        private ReferencesSet parentReferenceSet;
        private bool userCancelled;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a ReferenceEditor.
        /// </summary>
        public ReferenceEditor()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object.
            Init();
        }
        #endregion
        
        #region Events

            #region ReferenceTextBox_KeyDown(object sender, KeyEventArgs e)
            /// <summary>
            /// event is fired when Reference Text Box _ Key Down
            /// </summary>
            private void ReferenceTextBox_KeyDown(object sender, KeyEventArgs e)
            {
                // if the Enter Key was pressed
                if (e.KeyCode == Keys.Enter)
                {
                    // Call the Save method
                    OnSave();
                }
            }
            #endregion
            
            #region ReferenceTextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Reference Text Box _ Text Changed
            /// </summary>
            private void ReferenceTextBox_TextChanged(object sender, EventArgs e)
            {
                // Enable the controls
                UIEnable();
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
                bool hasChanges = false;

                // if the SelectedReference exists
                if (this.HasSelectedReference)
                {
                    // set the new ReferenceName
                    this.SelectedReference.ReferenceName = this.ReferenceTextBox.Text;

                    // if the OriginalReference is null
                    if (this.SelectedReference.IsNew) 
                    {
                        // if the ReferenceName exists
                        if (this.SelectedReference.HasReferenceName)
                        {
                            // we have changes
                            hasChanges = true;
                        }
                    }
                    else
                    {
                        // if the name is different
                        if (this.SelectedReference.ReferenceName != this.OriginalReference.ReferenceName)
                        {
                            // we have changes
                            hasChanges = true;
                        }
                    }
                }
                
                // return value
                return hasChanges;
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
                // Create a new instance of a 'Gateway' object.
                Gateway gateway = new Gateway(ConnectionConstants.Name);

                // local
                bool saved = false;

                // if the parent references set exists
                if ((this.HasSelectedReference) && (HasParentReferenceSet))
                {
                    // set reference name
                    this.SelectedReference.ReferenceName = this.ReferenceTextBox.Text.ToString();

                    // If this is new
                    if (ParentReferenceSet.IsNew)
                    {
                        // Update 10.25.2024: If the ParentReferencesSet.ReferenecesSetId is not set, this needs to be saved
                        saved = gateway.SaveReferencesSet(ref parentReferenceSet);

                        if (!saved)
                        {
                            string error = gateway.GetLastException().ToString();
                        }
                    }
                    
                    // set parent references set
                    this.SelectedReference.ReferencesSetId = this.ParentReferenceSet.ReferencesSetId;
                    
                    // Get the reference
                    ProjectReference reference = this.SelectedReference;
                    
                    // Saved
                    saved = gateway.SaveProjectReference(ref reference);
                    
                    // if saved
                    if(saved)
                    {
                        // the user did not cancel
                        this.UserCancelled = false;

                        // If the ParentForm exists
                        if (this.ParentForm != null)
                        {
                            // Close Form
                            this.ParentForm.Close();
                        }
                    }
                    else
                    {
                        string exception = gateway.GetLastException().ToString();
                    }
                }
            }
            #endregion

            #region Setup(ProjectReference selectedReferenceArg, ReferencesSet parentReferenceSetArg)
            /// <summary>
            /// This method prepares this control to create or edit a project reference.
            /// </summary>
            /// <param name="selectedReference"></param>
            public void Setup(ProjectReference selectedReferenceArg, ReferencesSet parentReferenceSetArg)
            {
                // The ProjectReference being created or edited.
                this.SelectedReference = selectedReferenceArg;

                // Set ParentReferenceSet
                this.ParentReferenceSet = parentReferenceSetArg;
                
                // if the selected reference exists
                if(this.SelectedReference != null)
                {
                    // clone the SelectedReference so we can check for changes
                    this.OriginalReference = this.SelectedReference.Clone();

                    // If the SelectedReference is new
                    if(this.SelectedReference.IsNew)
                    {
                        // Edit the selected reference
                        this.ParentForm.Text = "Create New Reference";
                    }
                    else
                    {
                        // Edit the selected reference
                        this.ParentForm.Text = "Edit Reference";
                    }

                    // Display
                    this.ReferenceTextBox.Text = this.SelectedReference.ReferenceName;
                }
                else
                {
                    // The reference text box\
                    this.ReferenceTextBox.Text = "";

                    // set the OriginalReference to null since we do not have a SelectedReference
                    this.OriginalReference = null;
                }

                // Enable the Save button
                UIEnable();
            }   
            #endregion

            #region UIEnable()
            /// <summary>
            /// This method UI Enable
            /// </summary>
            public void UIEnable()
            {
                // check for changes
                bool hasChanges = CheckForChanges();

                // enable the SaveButton if there are changes
                this.SaveCancelControl.EnableSaveButton(hasChanges);
            }
            #endregion
            
        #endregion
        
        #region Properties

            #region HasOriginalReference
            /// <summary>
            /// This property returns true if this object has an 'OriginalReference'.
            /// </summary>
            public bool HasOriginalReference
            {
                get
                {
                    // initial value
                    bool hasOriginalReference = (this.OriginalReference != null);
                    
                    // return value
                    return hasOriginalReference;
                }
            }
            #endregion
            
            #region HasParentReferenceSet
            /// <summary>
            /// This property returns true if this object has a 'ParentReferenceSet'.
            /// </summary>
            public bool HasParentReferenceSet
            {
                get
                {
                    // initial value
                    bool hasParentReferenceSet = (this.ParentReferenceSet != null);
                    
                    // return value
                    return hasParentReferenceSet;
                }
            }
            #endregion
            
            #region HasSelectedReference
            /// <summary>
            /// This property returns true if this object has a 'SelectedReference'.
            /// </summary>
            public bool HasSelectedReference
            {
                get
                {
                    // initial value
                    bool hasSelectedReference = (this.SelectedReference != null);
                    
                    // return value
                    return hasSelectedReference;
                }
            }
            #endregion
            
            #region OriginalReference
            /// <summary>
            /// This property gets or sets the value for 'OriginalReference'.
            /// </summary>
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ProjectReference OriginalReference
            {
                get { return originalReference; }
                set { originalReference = value; }
            }
            #endregion
            
            #region ParentReferenceSet
            /// <summary>
            /// The reference set that is this object's parent.
            /// </summary>            
            [Browsable(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public ReferencesSet ParentReferenceSet
            {
                get { return parentReferenceSet; }
                set 
                {
                    if (value != null)
                    {
                        parentReferenceSet = value;
                    }
                }
            }
            #endregion

            #region SelectedReference
            /// <summary>
            /// The ProjectReference being created or edited.
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
