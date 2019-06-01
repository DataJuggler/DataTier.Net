

#region using statements

using System;
using System.Windows.Forms;
using DataTierClient.Controls.Interfaces;
using ObjectLibrary.BusinessObjects;

#endregion


namespace DataTierClient.Forms
{

    #region class ReferenceEditorForm : Form
    /// <summary>
    /// This form is designed to host the ReferencesEditor control
    /// which chreates or edits ProjectReferences.
    /// </summary>
    public partial class ReferenceEditorForm : Form, ISaveCancelControl
    {
    
        #region Private Variables
        #endregion
    
        #region Constructor
        /// <summary>
        /// Create a new instance of a ReferencesEditorForm
        /// </summary>
        public ReferenceEditorForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Methods

            #region OnCancel()
            /// <summary>
            /// The user choose to cancel this edit.
            /// </summary>
            public void OnCancel()
            {

            } 
            #endregion
        
            #region OnSave()
            /// <summary>
            /// The choose to save this edit.
            /// </summary>
            public void OnSave()
            {
                
            }
            #endregion
        
        #endregion
        
        #region Properties

            #region UserCancelled
            /// <summary>
            /// Did the user cancel this edit?
            /// </summary>
            public bool UserCancelled
            {
                get
                {
                    // initial value
                    bool userCancelled = this.ReferenceEditor.UserCancelled;
                    
                    // return value
                    return userCancelled;
                }
            }
            #endregion
        
        #endregion
        
    } 
    #endregion
    
}