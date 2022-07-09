

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
using DataJuggler.Win.Controls.Interfaces;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class TabHostControl
    /// <summary>
    /// This class is used host the TabButtons.
    /// </summary>
    public partial class TabHostControl : UserControl
    {
        
        #region Private Variables
        private TabButton selectedTab;
        private List<TabButton> tabButtons;
        private int topMargin;
        private ITabHostControlParent tabHostParent;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a TabHostControl
        /// </summary>
        public TabHostControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Events

            
        #endregion
        
        #region Methods

            #region AddTabButton(int buttonNumber, string buttonText, int width, bool selected = false)
            /// <summary>
            /// This method returns the Tab Button
            /// </summary>
            public TabButton AddTabButton(int buttonNumber, string buttonText, int width, bool selected = false)
            {
                // initial value
                TabButton tabButton = new TabButton();

                // return value
                tabButton.ButtonNumber = buttonNumber;
                tabButton.ButtonText = buttonText;
                tabButton.Width = width;
                
                // Set the Dock to left
                tabButton.Dock = DockStyle.Left;
                                
                // set the   
                tabButton.Selected = selected;

                // Add the tabButton
                this.TabButtonHostPanel.Controls.Add(tabButton);

                // Add this button to the TabButtons collection
                this.TabButtons.Add(tabButton);

                // return value
                return tabButton;
            }
            #endregion
            
            #region GetTabButton(int buttonNumber)
            /// <summary>
            /// This method returns the Tab Button
            /// </summary>
            public TabButton GetTabButton(int buttonNumber)
            {
                // initial value
                TabButton tabButton = null;

                // If the TabButtons object exists
                if (this.HasTabButtons)
                {
                    // iterate the TabButtons
                    foreach (TabButton tempTabButton in this.TabButtons)
                    {
                        // if this is the control being sought
                        if (tempTabButton.ButtonNumber == buttonNumber)
                        {
                            // set the return value
                            tabButton = tempTabButton;

                            // break out of the loop
                            break;
                        }
                    }
                }                

                // return value
                return tabButton;
            }
            #endregion

            #region HideButton(int buttonNumber, bool showButton = false)
            /// <summary>
            /// This method returns the Button
            /// </summary>
            public void HideButton(int buttonNumber, bool showButton = false)
            {
                // Get the tabButtons button
                TabButton tabButton = GetTabButton(buttonNumber);

                // if the tabButton exists
                if (tabButton != null)
                {
                    // Show or hide the button
                    tabButton.Visible = showButton;
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create the tabButtons
                this.TabButtons = new List<TabButton>();                
            }
            #endregion
            
            #region SetButtonWidth(int width)
            /// <summary>
            /// This method sets the Button Width for all tabButtons
            /// </summary>
            public void SetButtonWidth(int width)
            {
                // if the tabButtons exist
                if (this.HasTabButtons)
                {
                    // iterate the tabButtons
                    foreach (TabButton button in this.TabButtons)
                    {
                        // set the width of this button
                        button.Width = width;
                    }                     
                }                                                                                     
            }
            #endregion
            
            #region SetButtonWidth(int buttonNumber, int width)
            /// <summary>
            /// This method returns the Button Width
            /// </summary>
            public void SetButtonWidth(int buttonNumber, int width)
            {
                // Get the tabButtons button
                TabButton tabButton = GetTabButton(buttonNumber);

                // if the tabButton exists
                if (tabButton != null)
                {
                    // Show or hide the button
                    tabButton.Width = width;
                }
            }
            #endregion
            
            #region SetupButton(int buttonNumber, string buttonText)
            /// <summary>
            /// This method returns the Button
            /// </summary>
            public void SetupButton(int buttonNumber, string buttonText)
            {
                // Get the tabButtons button
                TabButton tabButton = GetTabButton(buttonNumber);

                // if the tabButton exists
                if (tabButton != null)
                {
                    // Show or hide the button
                    tabButton.ButtonText = buttonText;
                }
            }
            #endregion

            #region TabSelected(TabButton selectedTab)
            /// <summary>
            /// A button was selected
            /// </summary>
            internal void TabSelected(TabButton selectedTab)
            {
                // set the selected tabButtons
                this.SelectedTab = selectedTab;

                // if the TabButtons collection exists
                if ((this.HasTabButtons) && (this.HasSelectedTab))
                {
                    // iterate the tabButtons
                    foreach (TabButton button in this.TabButtons)
                    {
                        // if is not the button selected
                        if (button.ButtonNumber != selectedTab.ButtonNumber)
                        {
                            // un select this button
                            button.Selected = false;
                        }
                    }
                }

                // If the TabHostParent object exists
                if (this.HasTabHostParent)
                {
                    // Notify the TabHostParent
                    this.TabHostParent.TabSelected(this.SelectedTab);
                }
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region HasSelectedTab
            /// <summary>
            /// This property returns true if this object has a 'SelectedTab'.
            /// </summary>
            public bool HasSelectedTab
            {
                get
                {
                    // initial value
                    bool hasSelectedTab = (this.SelectedTab != null);
                    
                    // return value
                    return hasSelectedTab;
                }
            }
            #endregion
            
            #region HasSelectedTabNumber
            /// <summary>
            /// This property returns true if the 'SelectedTabNumber' is set.
            /// </summary>
            public bool HasSelectedTabNumber
            {
                get
                {
                    // initial value
                    bool hasSelectedTabNumber = (this.SelectedTabNumber > 0);
                    
                    // return value
                    return hasSelectedTabNumber;
                }
            }
            #endregion

            #region HasTabButtons
            /// <summary>
            /// This property returns true if this object has a 'TabButtons'.
            /// </summary>
            public bool HasTabButtons
            {
                get
                {
                    // initial value
                    bool hasTabButtons = (this.TabButtons != null);
                    
                    // return value
                    return hasTabButtons;
                }
            }
            #endregion
            
            #region HasTabHostParent
            /// <summary>
            /// This property returns true if this object has a 'TabHostParent'.
            /// </summary>
            public bool HasTabHostParent
            {
                get
                {
                    // initial value
                    bool hasTabHostParent = (this.TabHostParent != null);
                    
                    // return value
                    return hasTabHostParent;
                }
            }
            #endregion
            
            #region LeftMargin
            /// <summary>
            /// This property gets or sets the value for 'LeftMargin'.
            /// </summary>
            public int LeftMargin
            {
                get
                {
                    // initial value
                    int leftMargin = 8;

                    // if the control exists
                    if (LeftMarginPanel != null)
                    {
                        // set the return value
                        leftMargin = (int)LeftMarginPanel.Width;
                    }

                    // return value
                    return leftMargin;
                }
                set
                {
                    // if the control exists
                    if (LeftMarginPanel != null)
                    {
                        // set the value
                        LeftMarginPanel.Width = value;
                    }
                }
            }
            #endregion
            
            #region SelectedTab
            /// <summary>
            /// This property gets or sets the value for 'SelectedTab'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public TabButton SelectedTab
            {
                get { return selectedTab; }
                set { selectedTab = value; }
            }
            #endregion

            #region SelectedTabNumber
            /// <summary>
            /// This read only property gets or sets the value for 'SelectedTab'.
            /// </summary>
            public int SelectedTabNumber
            {
                get
                {
                    // initial value
                    int selectedTabNumber = 0;

                    // if the SelectedTab exists
                    if (this.HasSelectedTab)
                    {
                        // set the button number
                        selectedTabNumber = this.SelectedTab.ButtonNumber;
                    }

                    // return value
                    return selectedTabNumber;
                }
            }
            #endregion

            #region TabButtons
            /// <summary>
            /// This property gets or sets the value for 'TabButtons'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public List<TabButton> TabButtons
            {
                get { return tabButtons; }
                set 
                { 
                    // you can only set the value if it exists
                    if ((TabButtons == null) && (value != null))
                    {
                        // set the value
                        tabButtons = value;
                    }
                }
            }
            #endregion
            
            #region TabHostParent
            /// <summary>
            /// This property gets or sets the value for 'TabHostParent'.
            /// </summary>
            public ITabHostControlParent TabHostParent
            {
                get { return tabHostParent; }
                set { tabHostParent = value; }
            }
            #endregion
            
            #region TopMargin
            /// <summary>
            /// This property gets or sets the value for 'TopMargin'.
            /// </summary>
            public int TopMargin
            {
                get { return topMargin; }
                set 
                { 
                    // set the value
                    topMargin = value;

                    // if the TopMarginPanel exists
                    if (this.TopMarginPanel != null)
                    {
                        // set the value
                        this.TopMarginPanel.Height = topMargin;
                    }
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
