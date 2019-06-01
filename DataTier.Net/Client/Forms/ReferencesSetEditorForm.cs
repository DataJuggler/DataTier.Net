

#region using statements

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DataTierClient.Controls.Interfaces;

#endregion


namespace DataTierClient.Forms
{

    #region class ReferencesSetEditorForm : Form
    /// <summary>
    /// This form is used to host the ReferencesSetEditorControl.
    /// </summary>
    public partial class ReferencesSetEditorForm : Form
    {
        
        #region Private Variables
        #endregion

        #region Constructor()
        /// <summary>
        /// This class is the ReferencesSetEditorForm.
        /// </summary>
        public ReferencesSetEditorForm()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
        
            #region Init()
            /// <summary>
            /// Perform Any Initializations for this object
            /// </summary>
            private void Init()
            {
                
            }
            #endregion
        
        #endregion
        
        #region Properties

            #region UserCancelled
            /// <summary>
            /// Did the user cancel this save or edit.
            /// </summary>
            public bool UserCancelled
            {
                get 
                { 
                    // initial value
                    bool userCancelled = this.ReferencesSetEditor.UserCancelled;
                    
                    // return value
                    return userCancelled; 
                }
            }
            #endregion
        
        #endregion
        
    }
    #endregion
    
}