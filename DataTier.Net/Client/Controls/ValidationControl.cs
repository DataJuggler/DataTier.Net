

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DataAccessComponent.ClientValidation;

#endregion

namespace DataTierClient.Controls
{

    #region class ValidationControl : UserControl
    public partial class ValidationControl : UserControl
    {
        
        #region Private Variables
        private ClientValidationManager validationManager;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 
        /// ValidationControl object.
        /// </summary>
        public ValidationControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations
            Init();
        }
        #endregion

        #region Events

            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the Cursor hovers over the button.
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion

            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the Cursor finishes hovering over the button.
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region OKButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the OK button is clicked
            /// after showing the validation errors.
            /// This event hides this control.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OKButton_Click(object sender, EventArgs e)
            {
                // If the ParentForm object exists
                if (ParentForm != null)
                {
                    // Close the ParentForm
                    ParentForm.Close();
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs any initializations
            /// for this object.
            /// </summary>
            private void Init()
            {
                // Create RequiredFields collection
                this.ValidationManager = new ClientValidationManager();
            }
            #endregion

            #region ShowMissingFields()
            /// <summary>
            /// This method shows the missing fields
            /// </summary>
            internal void ShowMissingFields()
            {
                // Call the overload for this method.
                ShowMissingFields(this.ValidationManager.RequiredFields);
            }
            #endregion

            #region ShowMissingFields(List<RequiredField> missingFields)
            /// <summary>
            /// This method shows the missing fields
            /// </summary>
            internal void ShowMissingFields(List<RequiredField> missingFields)
            {
                // Add each required field
                this.ValidationListBox.Items.Clear();

                // Display Each field
                foreach (RequiredField field in missingFields)
                {
                    // Add this field
                    this.ValidationListBox.Items.Add(field.FailedMessage);
                }

                // Make this control visible
                this.Visible = true;
            }
            #endregion
        
        #endregion

        #region Properties

            #region ValidationManager
            /// <summary>
            /// The collection of required fields that are
            /// missing to display to the user.
            /// </summary>
            [Browsable (false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public ClientValidationManager ValidationManager
            {
                get { return validationManager; }
                set { validationManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion
    
}
