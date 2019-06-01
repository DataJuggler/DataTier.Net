

#region using statements

using System;
using System.Windows.Forms;
using DataTierClient.Controls.Interfaces;

#endregion


namespace DataTierClient.Controls
{

    #region class SaveCancelControl : UserControl
    /// <summary>
    /// This control is a generic control for performing a
    /// Save and Cancel function. Parent Controls that use
    /// this must implement ISaveCancel Interface.
    /// </summary>
    public partial class SaveCancelControl : UserControl, ITabButtonParent
    {

        #region Constructor()
        /// <summary>
        /// Create a new instance of a SaveCancelControl.
        /// </summary>
        public SaveCancelControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region SaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event tells the parent control to execute OnSave
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SaveButton_Click(object sender, EventArgs e)
            {
                // if this object has a parent control
                if(this.HasParentControl)
                {
                    // Execute OnSave
                    this.ParentControl.OnSave();
                }    
            }
            #endregion

            #region CancelButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event tells the parent control to perform OnCancel.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CancelButton_Click(object sender, EventArgs e)
            {
                // if this object has a parent control
                if (this.HasParentControl)
                {
                    // Execute OnSave
                    this.ParentControl.OnCancel();
                }    
            }
            #endregion
        
        #endregion

        #region Methods

            #region EnableSaveButton(bool enable)
            /// <summary>
            /// This method returns the Save Button
            /// </summary>
            internal void EnableSaveButton(bool enable)
            {
                // enable the SaveButton
                this.SaveButton.Enabled = enable;
                this.SaveButton.Selected = enable;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // enable the Cancel button
                this.CancelSaveButton.Enabled = true;
                this.CancelSaveButton.Selected = true;
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
                    case "Confirm Code Removal":
                    case "Next":
                    case "Save":

                        // Call the SaveButton_Click event
                        SaveButton_Click(this, null);

                        // required
                        break;

                    case "Cancel":
                    case "Done":

                        // Call the CancelButton_Click event
                        CancelButton_Click(this, null);

                        // required
                        break;
                }
            }
            #endregion

            #region SetupSaveButton(string buttonText, int width, bool visible = true, bool enabled = true)
            /// <summary>
            /// This method is used to customize the SaveButton
            /// </summary>
            /// <param name="buttonText"></param>
            /// <param name="width"></param>
            public void SetupSaveButton(string buttonText, int width, bool visible = true, bool enabled = true)
            {
                // Setup the SaveButton
                this.SaveButton.ButtonText = buttonText;
                this.SaveButton.Width = width;
                this.SaveButton.Visible = visible;
                this.SaveButton.Enabled = enabled;
            }
            #endregion

            #region SetupCancelButton(string buttonText, int width, bool visible = true, bool enabled = true)
            /// <summary>
            /// This method is used to customize the CancelButton
            /// </summary>
            /// <param name="buttonText"></param>
            /// <param name="width"></param>
            public void SetupCancelButton(string buttonText, int width, bool visible = true, bool enabled = true)
            {
                // Setup the CancelButton
                this.CancelSaveButton.ButtonText = buttonText;
                this.CancelSaveButton.Width = width;
                this.CancelSaveButton.Visible = visible;
                this.CancelSaveButton.Enabled = enabled;
            }
            #endregion
            
        #endregion
        
        #region Properties

            #region HasParentControl
            /// <summary>
            /// Does this object have a parent control. 
            /// </summary>
            public bool HasParentControl
            {
                get
                {
                    // initial value
                    bool hasParentControl = (this.ParentControl != null);
                    
                    // return value
                    return hasParentControl;
                }
            }
            #endregion

            #region ParentControl
            /// <summary>
            /// The parent for this control.
            /// </summary>
            public ISaveCancelControl ParentControl
            {
                get
                {
                    // initial value
                    ISaveCancelControl parentControl = this.Parent as ISaveCancelControl;

                    // If the parentControl object doesn't exist
                    if (parentControl == null)
                    {
                        // test if the parent is a panel
                        Panel panel = this.Parent as Panel; 

                        // If the panel object exists
                        if (panel != null)
                        {
                            // attempt to cast the panel's Parent as an ISaveCancelControl. 
                            // This is needed on the FieldSetEditor.
                            parentControl = panel.Parent as ISaveCancelControl;
                        }  
                    }

                    // return value
                    return parentControl;
                }
            } 
            #endregion
        
        #endregion

    }
    #endregion
    
}
