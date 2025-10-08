

#region using statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class TabButton
    /// <summary>
    /// This class represents a Tab on the TabHost control.
    /// </summary>
    [Browsable (false)]
    public partial class TabButton : UserControl
    {
        
        #region Private Variables
        private bool selected;
        private int buttonNumber;
        private string buttonText;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a TabButton
        /// </summary>
        public TabButton()
        {
            // Create controls
            InitializeComponent();
        }
        #endregion

        #region Events

            #region Button_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Enter
            /// </summary>
            private void Button_MouseEnter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Button _ Mouse Leave
            /// </summary>
            private void Button_MouseLeave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                this.Cursor = Cursors.Default;
            }
            #endregion
            
            #region TabButton_Click(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when the 'TabButton' is clicked.
            /// </summary>
            private void TabButton_Click(object sender, EventArgs e)
            {
                // if the ParentTabHost exists
                if (this.HasParentTabHost)
                {
                    // set selected to true
                    this.Selected = true;

                    // a button was selected
                    this.ParentTabHost.TabSelected(this);
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region DisplayTabImage()
            /// <summary>
            /// This method Display Tab Image
            /// </summary>
            public void DisplayTabImage()
            {
                // create a tabImages control
                TabImagesControl tabImages = new TabImagesControl();

                // local
                Image image = tabImages.GetTabImage(this.Selected);

                // set the image
                this.BackgroundImage = image;

                // set the refresh
                this.Refresh();
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
            
            #region ButtonText
            /// <summary>
            /// This property gets or sets the value for 'ButtonText'.
            /// </summary>
            public string ButtonText
            {
                get { return buttonText; }
                set 
                { 
                    // set the value
                    buttonText = value;

                    // set the value
                    this.Label.Text = value;
                }
            }
            #endregion
            
            #region HasButtonNumber
            /// <summary>
            /// This property returns true if the 'ButtonNumber' is set.
            /// </summary>
            public bool HasButtonNumber
            {
                get
                {
                    // initial value
                    bool hasButtonNumber = (this.ButtonNumber > 0);
                    
                    // return value
                    return hasButtonNumber;
                }
            }
            #endregion
            
            #region HasButtonText
            /// <summary>
            /// This property returns true if the 'ButtonText' exists.
            /// </summary>
            public bool HasButtonText
            {
                get
                {
                    // initial value
                    bool hasButtonText = (!String.IsNullOrEmpty(this.ButtonText));
                    
                    // return value
                    return hasButtonText;
                }
            }
            #endregion
            
            #region HasParentTabHost
            /// <summary>
            /// This property returns true if this object has a 'ParentTabHost'.
            /// </summary>
            public bool HasParentTabHost
            {
                get
                {
                    // initial value
                    bool hasParentTabHost = (this.ParentTabHost != null);
                    
                    // return value
                    return hasParentTabHost;
                }
            }
            #endregion
            
            #region ParentTabHost
            /// <summary>
            /// This read only property returns the value for 'ParentTabHost'.
            /// </summary>
            public TabHostControl ParentTabHost
            {
                get
                {
                    // initial value
                    TabHostControl parentTabHost = null;
                    
                    // get the parent as a panel
                    Panel panel = this.Parent as Panel;

                    // if the panel exists
                    if (panel != null)
                    {
                        // cast the panel.Parent as a TabHostControl
                        parentTabHost = panel.Parent as TabHostControl;
                    }

                    // return value
                    return parentTabHost;        
                }
            }
            #endregion
            
            #region Selected
            /// <summary>
            /// This property gets or sets the value for 'Selected'.
            /// </summary>
            public bool Selected
            {
                get { return selected; }
                set 
                {
                    // set the value
                    selected = value;

                    // display the TabImage
                    DisplayTabImage();
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
