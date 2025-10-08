

#region using statements

using System.Windows.Forms;
using System.Drawing;
using DataJuggler.Win.Controls.Interfaces;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class LabelCheckBoxControl : UserControl, IFieldValueControl
    /// <summary>
    /// This control is used to display a Label and a LabelTextBox for editing.
    /// </summary>
    public partial class LabelCheckBoxControl : UserControl, IFieldValueControl
    {

        #region Private Variables
        private int labelWidth;
        private string labelText;
        private bool editable;
        private ContentAlignment labelTextAlign;
        private Font labelFont;
        private int checkBoxVerticalOffSet;
        private ICheckChangedListener checkChangedListener;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'LabelTextBoxControl' object.
        /// </summary>
        public LabelCheckBoxControl()
        {
            // Create controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region CheckBox_CheckedChanged(object sender, System.EventArgs e)
            /// <summary>
            /// This event is fired when Check Box _ Checked Changed
            /// </summary>
            private void CheckBox_CheckedChanged(object sender, System.EventArgs e)
            {
                // If the CheckChangedListener object exists
                if (this.HasCheckChangedListener)
                {
                    // Notify the listender that the value has changed
                    this.CheckChangedListener.OnCheckChanged(this, this.Checked);
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region Activate()
            /// <summary>
            /// Set focus to the text bo
            /// </summary>
            internal void Activate()
            {
               
            } 
            #endregion

            #region Clear()
            /// <summary>
            /// Clear the items in this control
            /// </summary>
            public void Clear()
            {
                // erase a selection
                this.CheckBox.Checked = false;
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            private void Init()
            {
                // set the LabelTextAlign
                this.LabelTextAlign = ContentAlignment.MiddleRight;

                // Set Default height & width
                this.LabelWidth = 140;
                this.Width = 280;
            }
            #endregion

            #region Setup(string labelText, bool isChecked)
            /// <summary>
            /// This method prepares this control to be shown.
            /// </summary>
            /// <param name="labelText"></param>
            /// <param name="isChecked"></param>
            public void Setup(string labelText, bool isChecked)
            {
                // set the properties
                this.LabelText = labelText;
                this.Checked = isChecked;
            } 
            #endregion

            #region UIControl()
            /// <summary>
            /// This method determines if the Textbox is enabled or not based upon the value
            /// of Editable and Updateable.
            /// </summary>
            private void UIEnable()
            {
                // enabled or not
                bool enabled = this.Editable;
                
                // enable the text box if enabled
                this.CheckBox.Enabled = enabled;
            }  
            #endregion

        #endregion

        #region Properties
            
            #region CheckBoxVerticalOffSet
            /// <summary>
            /// This property gets or sets the value for 'CheckBoxVerticalOffSet'.
            /// </summary>
            public int CheckBoxVerticalOffSet
            {
                get { return checkBoxVerticalOffSet; }
                set 
                { 
                    // set the value
                    checkBoxVerticalOffSet = value; 

                    // set the height of the MarginPanel to move the CheckBox down
                    this.CheckBoxMarginPanel.Height = value;
                }
            }
            #endregion

            #region CheckBoxControl
            /// <summary>
            /// Return the CheckBox on this control
            /// </summary>
            public CheckBox CheckBoxControl
            {
                get
                {
                    // return the CheckBox
                    return this.CheckBox;
                }
            } 
            #endregion
            
            #region CheckChangedListener
            /// <summary>
            /// This property gets or sets the value for 'CheckChangedListener'.
            /// </summary>
            public ICheckChangedListener CheckChangedListener
            {
                get { return checkChangedListener; }
                set { checkChangedListener = value; }
            }
            #endregion
            
            #region Checked
            /// <summary>
            /// This property gets or sets the value for 'Checked'.
            /// </summary>
            public bool Checked
            {
                get
                {
                    // set the value
                    return this.CheckBox.Checked;
                }
                set
                {
                    // Set the value for Checked
                    this.CheckBox.Checked = value;
                }
            }
            #endregion
            
            #region Editable
            /// <summary>
            /// When this is true the LabelTextBox is enabled.
            /// </summary>
            public bool Editable
            {
                get { return editable; }
                set 
                { 
                    // set the value
                    editable = value;
                    
                    // enable controls based upon this value
                    UIEnable(); 
                }
            } 
            #endregion

            #region FieldLabel
            /// <summary>
            /// This property returns the label from this control.
            /// </summary>
            public Label FieldLabel
            {
                get
                {
                    // return the Label from this control.
                    return this.Label;
                }
            }
            #endregion

            #region HasCheckChangedListener
            /// <summary>
            /// This property returns true if this object has a 'CheckChangedListener'.
            /// </summary>
            public bool HasCheckChangedListener
            {
                get
                {
                    // initial value
                    bool hasCheckChangedListener = (this.CheckChangedListener != null);
                    
                    // return value
                    return hasCheckChangedListener;
                }
            }
            #endregion
            
            #region HasLabelFont
            /// <summary>
            /// This property returns true if this object has a 'LabelFont'.
            /// </summary>
            public bool HasLabelFont
            {
                get
                {
                    // initial value
                    bool hasLabelFont = (this.LabelFont != null);
                    
                    // return value
                    return hasLabelFont;
                }
            }
            #endregion

            #region LabelColor
            /// <summary>
            /// This property gets or sets the value for 'LabelColor'.
            /// </summary>
            public Color LabelColor
            {
                get
                {
                    // initial value
                    Color color = Color.Black;

                    // if the control exists
                    if (Label != null)
                    {
                        // set the return value
                        color = (Color)Label.ForeColor;
                    }

                    // return value
                    return color;
                }
                set
                {
                    // if the control exists
                    if (Label != null)
                    {
                        // set the value
                        Label.ForeColor = value;
                    }
                }
            }
            #endregion
            
            #region LabelFont
            /// <summary>
            /// This property gets or sets the value for 'LabelFont'.
            /// </summary>
            public Font LabelFont
            {
                get { return labelFont; }
                set 
                { 
                    // set the value
                    labelFont = value;

                    // if the LabelFont exists
                    if (this.HasLabelFont)
                    {
                        // set the font for the label
                        this.Label.Font = labelFont;
                    }
                }
            }
            #endregion
            
            #region LabelText
            /// <summary>
            /// This property gets or sets the LabelText.
            /// </summary>
            public string LabelText
            {
                get { return labelText; }
                set 
                { 
                    // set the value
                    labelText = value; 
                    
                    // if the Label exists
                    if (this.Label != null)
                    {
                        // set the Label text
                        this.Label.Text = value;
                    }
                }
            } 
            #endregion

            #region LabelTextAlign
            /// <summary>
            /// Set the TextAlign for the label.
            /// </summary>
            public ContentAlignment LabelTextAlign
            {
                get { return labelTextAlign; }
                set 
                {   
                    // set the value
                    labelTextAlign = value; 
                    
                    if (this.Label != null)
                    {
                        // set the value
                        this.Label.TextAlign = value;
                    }
                }
            } 
            #endregion

            #region LabelWidth
            /// <summary>
            /// The LabelWidth
            /// </summary>
            public int LabelWidth
            {
                get { return labelWidth; }
                set
                {
                    // set the label width
                    labelWidth = value;

                    // if the Label exists
                    if (this.Label != null)
                    {
                        // set the label width
                        this.Label.Width = value;
                    }
                }
            }
            #endregion
            
        #endregion

    } 
    #endregion

}
