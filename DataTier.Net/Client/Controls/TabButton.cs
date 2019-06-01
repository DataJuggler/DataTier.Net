

#region using statements

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DataTierClient.Enumerations;
using DataTierClient.Controls.Images;
using DataTierClient.Controls.Interfaces;
using System.Drawing;

#endregion


namespace DataTierClient.Controls
{

    #region class TabButton : UserControl
    /// <summary>
    /// This object is a button with Selected property.
    /// </summary>
    public partial class TabButton : UserControl
    {
        
        #region Private Variables
        private bool selected;
        private Image selectedImage;
        private Image notSelectedImage;
        private bool showNotSelectedImageWhenDisabled;
        private int buttonNumber;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a TabButton.
        /// </summary>
        public TabButton()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform Initializations for this object.
            Init();
        }
        #endregion
        
        #region Events

            #region Button_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Enter
            /// </summary>
            private void Button_MouseEnter(object sender, EventArgs e)
            {
                // Switch to the Cursor to a Hand
                this.Cursor = Cursors.Hand;
            }
            #endregion

            #region Button_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Leave
            /// </summary>
            private void Button_MouseLeave(object sender, EventArgs e)
            {
                // Switch to the Cursor to a Hand
                this.Cursor = Cursors.Default;
            }
            #endregion
            
            #region TabButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the TabButton is clicked.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void TabButton_Click(object sender, EventArgs e)
            {
                // if this object has a button parent
                if(this.HasButtonParent)
                {
                    // Notify the parent the tab button was clicked.
                    this.ButtonParent.OnTabButtonClicked(this);
                }
            }
            #endregion

            #region TabButton_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// This button has become enable or disabled.
            /// If ShowDisabledImageWhenNotEnabled
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void TabButton_EnabledChanged(object sender, EventArgs e)
            {
                // If the not selected image should be shown when 
                // the value for eanbled changed, the image must 
                // be changed.
                if (this.ShowNotSelectedImageWhenDisabled)
                {
                    // set the value for selected before calling.
                    this.Selected = this.Enabled;
                    
                    // change out the image
                    this.SetImage();
                }
            } 
            #endregion
        
        #endregion
        
        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// </summary>
            private void Init()
            {
                // Default To Not Selected
                this.Selected = false;   
                
                // default this to true, turn this off if you need to change it.
                this.ShowNotSelectedImageWhenDisabled = true;
            }
            #endregion
            
            #region SetImage()
            /// <summary>
            /// This method sets the image for selected or not selected.
            /// </summary>
            private void SetImage()
            {
                try
                {
                    // if this object is selected
                    if (this.Selected)
                    {
                        if (this.SelectedImage != null)
                        {
                            // Set image to selected
                            this.BackgroundImage = this.SelectedImage;
                        }
                    }
                    else
                    {
                        // if the image exists
                        if (this.NotSelectedImage != null)
                        {
                            // Set image to not selected
                            this.BackgroundImage = this.NotSelectedImage;
                        }
                    }
                }
                catch
                {
                }
            }
            #endregion

            #region SetImages(Image selectedImage, Image notSelectedImage)
            /// <summary>
            /// This method sets the Selected and NotSelected images.
            /// </summary>
            /// <param name="selectedImage"></param>
            /// <param name="notSelectedImage"></param>
            /// <returns></returns>
            public void SetImages(Image selectedImage, Image notSelectedImage)
            {
                // set the properties
                this.SelectedImage = selectedImage;
                this.NotSelectedImage = notSelectedImage;
            } 
            #endregion
        
        #endregion
        
        #region Properties

            #region ButtonNumber
            /// <summary>
            /// This property gets or sets the value for 'ButtonNumber'.
            /// </summary>
            public int ButtonNumber
            {
                get { return buttonNumber; }
                set { buttonNumber = value; }
            }
            #endregion
            
            #region ButtonParent
            /// <summary>
            /// The ButtonParent for this button.
            /// </summary>
            public ITabButtonParent ButtonParent
            {
                get
                {
                    // initial value
                    ITabButtonParent buttonParent = null;
                    
                    // set panel
                    Panel panel = this.Parent as Panel;
                    
                    // if the panel exists
                    if(panel != null)
                    {
                        // set buttonParent
                        buttonParent = panel.Parent as ITabButtonParent;
                    }
                    else if(this.Parent as ITabButtonParent != null)
                    {
                        // set the button parent
                        buttonParent = this.Parent as ITabButtonParent;
                    }
                    
                    // return value
                    return buttonParent;
                }
            }
            #endregion

            #region ButtonText
            /// <summary>
            /// The Text for this button.
            /// </summary>
            public string ButtonText
            {
                get
                {
                    // return the text of MainButton
                    return this.MainButton.Text;
                }
                set
                {
                    // set the value of MainButton.Text
                    this.MainButton.Text = value;
                }
            }
            #endregion

            #region HasButtonParent
            /// <summary>
            /// Does this object have a ButtonParent.
            /// </summary>
            public bool HasButtonParent
            {
                get
                {
                    // initial value
                    bool hasButtonParent = (this.ButtonParent != null);

                    // return value
                    return hasButtonParent;
                }
            }
            #endregion

            #region HasParentProjectWizard
            /// <summary>
            /// Does this object have a ParentStatusControl.
            /// </summary>
            public bool HasParentProjectWizard
            {
                get
                {
                    // initial value
                    bool hasParentStatusControl = (this.ParentStatusControl != null);

                    // return value
                    return hasParentStatusControl;
                }
            }
            #endregion

            #region HasParentStatusControl
            /// <summary>
            /// Does this object have a ParentStatusControl.
            /// </summary>
            public bool HasParentStatusControl
            {
                get
                {
                    // initial value
                    bool hasParentStatusControl = (this.ParentStatusControl != null);
                    
                    // return value
                    return hasParentStatusControl;
                }
            }
            #endregion

            #region NotSelectedImage
            /// <summary>
            /// Image to display when this control is not selected
            /// (or disabled when ShowNotSelectedImageWhenDisabled = True.
            /// </summary>
            public Image NotSelectedImage
            {
                get { return notSelectedImage; }
                set { notSelectedImage = value; }
            } 
            #endregion
            
            #region ParentProjectWizardControl
            /// <summary>
            /// This property is the ParentStatusControl's parent
            /// ProjectWizardControl. 
            /// </summary>
            public ProjectWizardControl ParentProjectWizardControl
            {
                get
                {
                    // initial value
                    ProjectWizardControl parentProjectWizard = null;
                    
                    // if the ParentStatusControl exists
                    if(this.HasParentStatusControl)
                    {
                        // set parentProjectWizard
                        parentProjectWizard = this.ParentStatusControl.ParentProjectWizard;
                    }
                    
                    // return value
                    return parentProjectWizard;
                }
            }
            #endregion

            #region ParentStatusControl
            /// <summary>
            /// The parent status control that this object sits on.
            /// </summary>
            internal WizardStatusControl ParentStatusControl
            {
                get
                {
                    // initial value
                    WizardStatusControl parentStatusControl = this.Parent as WizardStatusControl;
                    
                    // return value
                    return parentStatusControl;
                }
            }
            #endregion
            
            #region Selected
            /// <summary>
            /// Is this object selected or not.
            /// </summary>
            public bool Selected
            {
                get { return selected; }
                set 
                { 
                    // set value
                    selected = value; 
                    
                    // Set image
                    SetImage();
                }
            }
            #endregion

            #region SelectedImage
            /// <summary>
            /// The image to display when this control is selected
            /// (Or enable if ShowNotSelectedImageWhenDisabled = True.
            /// </summary>
            public Image SelectedImage
            {
                get { return selectedImage; }
                set { selectedImage = value; }
            } 
            #endregion

            #region ShowNotSelectedImageWhenDisabled
            /// <summary>
            /// When this property is true this control will
            /// show the 
            /// </summary>
            public bool ShowNotSelectedImageWhenDisabled
            {
                get { return showNotSelectedImageWhenDisabled; }
                set { showNotSelectedImageWhenDisabled = value; }
            } 
            #endregion
            
        #endregion

    }
    #endregion
    
}
