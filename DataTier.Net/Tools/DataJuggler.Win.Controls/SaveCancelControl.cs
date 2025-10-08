

#region using statements

using System;
using System.Windows.Forms;
using DataJuggler.Win.Controls.Interfaces;
using System.Drawing;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class SaveCancelControl : UserControl
    /// <summary>
    /// This class is used to Save and Cancel in one control.
    /// </summary>
    public partial class SaveCancelControl : UserControl
    {
    
        #region private variables
        private bool doneMode;
        private Image hiddenImage;
        private bool showSaveAndCloseButton;
        private bool showSaveButton;
        private int saveAndCloseButtonWidth;
        private int saveButtonWidth;
        private int cancelButtonWidth;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SaveCancelControl' object.
        /// </summary>
        public SaveCancelControl()
        {
            // Create controls
            InitializeComponent();

            // Set the hidden image
            this.HiddenImage = this.CancelSave.Image;
            
            // default to not a border style
            this.BorderStyle = BorderStyle.None;
        }
        #endregion

        #region Events

            #region CancelSave_Click(object sender, EventArgs e)
            /// <summary>
            /// The Cancel save button was clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CancelSave_Click(object sender, EventArgs e)
            {
                // if the parent host exists
                if (this.HasParentHost)
                {
                    // notify the parent hoste to cancel
                    this.ParentHost.OnCancel();
                }
            }
            #endregion

            #region SaveAndCloseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The save and close button was clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SaveAndCloseButton_Click(object sender, EventArgs e)
            {
                // if the parent host exists
                if (this.HasParentHost)
                {
                    // notify the parent hoste to save
                    this.ParentHost.OnSave(true);
                }
            } 
            #endregion
            
            #region SaveButton_Click(object sender, EventArgs e)
            /// <summary>
            /// The Save button was clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SaveButton_Click(object sender, EventArgs e)
            {
                // if the parent host exists
                if (this.HasParentHost)
                {
                    // notify the parent hoste to save
                    this.ParentHost.OnSave(true);
                }
            }
            #endregion

        #endregion
        
        #region Methods

            #region FindParentHost()
            /// <summary>
            /// Keep searching objects for parents
            /// </summary>
            /// <returns></returns>
            private ISaveCancelHost FindParentHost()
            {
                // initial value
                ISaveCancelHost parentHost = null;
                
                // try the test
                parentHost = this.Parent as ISaveCancelHost;
                
                // get the control 
                Control control = this.Parent as Control;
                
                // if the parentHost has not been found yet
                if (parentHost == null)
                {
                    do
                    {
                        // if the control exists
                        if (control != null)
                        {
                            // test 
                            parentHost = control.Parent as ISaveCancelHost;
                            
                            // if the parent host is set
                            if (parentHost != null)
                            {
                                // break out of the loop
                                break;
                            }
                            
                            // set the new parent
                            control = control.Parent as Control;
                        }
                        else
                        {
                            // break out of loop
                            break;
                        }
                        
                    } while (true);
                }
                
                // return value
                return parentHost;
            } 
            #endregion
        
        #endregion

        #region Properties
            
            #region CancelButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonWidth'.
            /// </summary>
            public int CancelButtonWidth
            {
                get { return cancelButtonWidth; }
                set 
                { 
                    // set the value
                    cancelButtonWidth = value; 

                    // size the button
                    this.CancelSave.Width = value;
                }
            }
            #endregion
            
            #region DoneMode
            /// <summary>
            /// When DoneMode is true, the Cancel button changes the caption to Done.
            /// </summary>
            public bool DoneMode
            {
                get { return doneMode; }
                set 
                { 
                    // set the value
                    doneMode = value; 
                    
                    // if done mode
                    if (doneMode)
                    {
                        // set to Cancel
                        this.CancelSave.Text = "Done";
                        this.CancelSave.Image = null;
                        this.CancelSave.TextAlign = ContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        // set to Cancel
                        this.CancelSave.Text = "Cancel";

                        // Move to the right for the presence of the image
                        this.CancelSave.TextAlign = ContentAlignment.MiddleRight;

                        // Set the image
                        this.CancelSave.Image = this.HiddenImage;
                    }
                }
            } 
            #endregion
            
            #region HasHiddenImage
            /// <summary>
            /// This property returns true if this object has a 'HiddenImage'.
            /// </summary>
            public bool HasHiddenImage
            {
                get
                {
                    // initial value
                    bool hasHiddenImage = (this.HiddenImage != null);
                    
                    // return value
                    return hasHiddenImage;
                }
            }
            #endregion
            
            #region HasParentHost
            /// <summary>
            /// Does this object have a parent host
            /// </summary>
            public bool HasParentHost
            {
                get
                {
                    // initial value
                    bool hasParentHost = (this.ParentHost != null);

                    // return value
                    return hasParentHost;
                }
            }
            #endregion

            #region HiddenImage
            /// <summary>
            /// This property gets or sets the value for 'HiddenImage'.
            /// </summary>
            public Image HiddenImage
            {
                get { return hiddenImage; }
                set 
                { 
                    // this cannot be set to null
                    if (value != null)
                    {
                        // set the value
                        hiddenImage = value; 
                    }
                }
            }
            #endregion
            
            #region ParentHost
            /// <summary>
            /// The host of this control
            /// </summary>
            public ISaveCancelHost ParentHost
            {
                get
                {
                    // initial value
                    ISaveCancelHost parentHost = FindParentHost();
                    
                    // return value
                    return parentHost;
                }
            }
            #endregion

            #region SaveAndCloseButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'SaveAndCloseButtonWidth'.
            /// </summary>
            public int SaveAndCloseButtonWidth
            {
                get { return saveAndCloseButtonWidth; }
                set 
                { 
                    // set the value
                    saveAndCloseButtonWidth = value; 

                    // size the butotn
                    this.SaveAndCloseButton.Width = value;
                }
            }
            #endregion
            
            #region SaveButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonWidth'.
            /// </summary>
            public int SaveButtonWidth
            {
                get { return saveButtonWidth; }
                set 
                { 
                    // set the value
                    saveButtonWidth = value;

                    // set the width
                    this.SaveButton.Width = value;
                }
            }
            #endregion
            
            #region ShowSaveAndCloseButton
            /// <summary>
            /// This property gets or sets the value for 'ShowSaveAndCloseButton'.
            /// </summary>
            public bool ShowSaveAndCloseButton
            {
                get { return showSaveAndCloseButton; }
                set 
                { 
                    // set the value
                    showSaveAndCloseButton = value;

                    // Show the button if true
                    this.SaveAndCloseButton.Visible = value;
                }
            }
            #endregion
            
            #region ShowSaveButton
            /// <summary>
            /// This property gets or sets the value for 'ShowSaveButton'.
            /// </summary>
            public bool ShowSaveButton
            {
                get { return showSaveButton; }
                set 
                { 
                    // set the value
                    showSaveButton = value; 

                    // show the button if true
                    this.SaveButton.Visible = value;
                }
            }
            #endregion
            
        #endregion

    } 
    #endregion
    
}
