

#region using statements

using DataAccessComponent.ClientValidation;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Forms
{

    #region class ValidationForm
    /// <summary>
    /// This Form is used to host the ValidationControl. 
    /// </summary>
    public partial class ValidationForm : Form
    {  
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ValidationForm' object.
        /// </summary>
        public ValidationForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Methods

            #region Setup(ClientValidationManager validationManager)
            /// <summary>
            /// method setups the ClientValidationManager
            /// </summary>
            public void Setup(ClientValidationManager validationManager)
            {
                // Set the Validationmanager  
                this.ValidationControl.ValidationManager = validationManager;

                // Show the missing fields
                this.ValidationControl.ShowMissingFields();
            }
            #endregion
            
        #endregion

    }
    #endregion

}
