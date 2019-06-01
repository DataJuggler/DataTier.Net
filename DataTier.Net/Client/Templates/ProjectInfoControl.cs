

#region Using Statements

using RADStudioClient.Controls.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion


namespace $rootnamespace$
{

    #region class $safeitemrootname$ : BaseWizardControl, IWizardControl
    /// <summary>
    /// This class edits the basic information for a project.
    /// </summary>
    public partial class $safeitemrootname$ : BaseWizardControl, IWizardControl
    {
        
        #region Private Variables
        #endregion 
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a $safeitemrootname$.
        /// </summary>
        public $safeitemrootname$()
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
            /// Perform Initializations For This Object.
            /// </summary>
            public void Init()
            {
                // Set Dock To Fill
                this.Dock = DockStyle.Fill;   
            }
            #endregion

            #region DisplaySelectedProject()
            /// <summary>
            /// Display the selected project.
            /// </summary>
            public void DisplaySelectedProject()
            {
                
            }
            #endregion

            #region ValidateSelectedProject()
            /// <summary>
            /// Validate the selected project.
            /// </summary>
            public bool ValidateSelectedProject()
            {
                // initial value
                bool valid = false;
                
                // return value
                return valid;
            }
            #endregion
        
        #endregion
        
        #region Properties
        
            
        
        #endregion
        
    }
    #endregion
    
}
