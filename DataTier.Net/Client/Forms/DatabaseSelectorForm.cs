

#region using statements

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;

#endregion


namespace DataTierClient.Forms
{
    
    #region class Databaseform
    /// <summary>
    /// This form's purpose is to add or edit an existing database.
    /// </summary>
    public partial class DatabaseSelectorForm : Form
    {
    
        #region Private Varibales
        
        #endregion
    
        #region Constructor
        /// <summary>
        /// Create a new instance of a DatabaseSelectorForm
        /// </summary>
        public DatabaseSelectorForm()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this control
            Init();
        }
        #endregion
        
        #region Methods

            #region Init()
            /// <summary>
            // Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // No BorderStyle
                this.DatabaseSelectorControl.BorderStyle = BorderStyle.None;
            }
            #endregion
        
        #endregion
        
        #region Properties

        #endregion
        
    }
    #endregion
    
}