

#region using statements

using System;
using System.Drawing;
using System.Windows.Forms;
using DataJuggler.Win.Controls.Interfaces;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class LabelSliderControl
    /// <summary>
    /// This class contains a Label and a Slider (Track Bar) control.
    /// </summary>
    public partial class LabelSliderControl : UserControl
    {
        
        #region Private Variables
        private Font labelFont;
        private string labelText;
        private bool labelTextBoxControlEditable;
        private int labelTextBoxControlHeight;
        private int labelTextBoxControlWidth;
        private int labelWidth;
        private int rightMargin;
        private int sliderMaximum;
        private int sliderMinimum;
        private Font textBoxFont;
        private int labelBottomMargin;
        private int labelTopMargin;
        private int textBoxBottomMargin;
        private int textBoxTopMargin;
        private int textBoxRightMargin;
        private Color textBoxEditableColor;
        private Color textBoxDisabledColor;
        private int topMargin;
        private int leftPanelWidth;

        // constants
        private const int DefaultHeight = 36;
        private const int DefaultWidth = 360;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'LabelSliderControl' object.
        /// </summary>
        public LabelSliderControl()
        {
            // Create controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
        #endregion  

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object
            /// </summary>
            public void Init()
            {
                // if the LabelWidth is not set
                if (this.LabelWidth < 1)
                {
                    // default label with
                    this.LabelWidth = 120;
                }

                // if the Minimum is not set
                if (this.SliderMinimum == 0)
                {
                    // set the Minimum to 1
                    this.SliderControl.Minimum = 1;
                }

                // if the Maximum is not set
                if (this.SliderControl.Maximum == 0)
                {
                    // Set to 5
                    this.SliderControl.Maximum = 5;
                }

                // if the Width is not set
                if (this.LeftPanel.Width == 0)
                {
                    // Set the width
                    this.LeftPanel.Width = 360;
                }

                // Show the SliderControl
                this.SliderControl.Visible = true;

                // Set the default height and width
                this.Height = DefaultHeight;
                this.Width = DefaultWidth;
                
                // Register the LabelTextBox with the Slider
                this.SliderControl.LabelTextBox = this.LabelTextBoxControl;
            }
            #endregion

            #region SetSliderWidth()
            /// <summary>
            /// This method Set Slider Width
            /// </summary>
            public void SetSliderWidth()
            {
                // Set the Width of the Slider control
                this.SliderControl.Width = this.Width - this.leftPanelWidth;
            }
            #endregion
            
            #region Setup(int minimumValue, int maximumValue, int sliderValue)
            /// <summary>
            /// This method returns the
            /// </summary>
            public void Setup(int minimumValue, int maximumValue, int sliderValue)
            {
                this.SliderControl.Minimum = minimumValue;
                this.SliderControl.Maximum = maximumValue;
                this.SliderValue = sliderValue;
            }
            #endregion
            
            #region ShowSliderControl()
            /// <summary>
            /// This method Show Slider Control
            /// </summary>
            public void ShowSliderControl()
            {
                // Show the SliderControl
                this.SliderControl.Visible = true;                
            }
            #endregion

            #region ValueChangedListener
            /// <summary>
            /// This property gets or sets the value for 'ValueChangedListener'.
            /// </summary>
            public ISliderValueChangedListener ValueChangedListener
            {
                get
                {
                    // initial value
                    ISliderValueChangedListener valueChangedListener = null;

                    // if the control exists
                    if (this.HasSliderControl)
                    {
                        // set the return value
                        valueChangedListener = (ISliderValueChangedListener)SliderControl.ValueChangedListener;
                    }

                    // return value
                    return valueChangedListener;
                }
                set
                {
                    // if the control exists
                    if (this.HasSliderControl)
                    {  
                        // set the value
                        SliderControl.ValueChangedListener = value;
                    }
                }
            }
            #endregion

        #endregion

        #region Properties
           
            #region HasLabelTextBoxControl
            /// <summary>
            /// This read only property returns true if this object's LabelTextBoxControl exists.
            /// </summary>
            public bool HasLabelTextBoxControl
            {
                get
                {
                    // initial value
                    bool hasLabelTextBoxControl = (this.LabelTextBoxControl != null);

                    // return value
                    return hasLabelTextBoxControl;
                }
            }
            #endregion

            #region HasSliderControl
            /// <summary>
            /// This read only property returns true if this object's SliderControl exists.
            /// </summary>
            public bool HasSliderControl
            {
                get
                {
                    // initial value 
                    bool hasSliderControl = (this.SliderControl != null);

                    // return value
                    return hasSliderControl;
                }
            }
            #endregion

            #region Increments
            /// <summary>
            /// This property gets or sets the value for 'Increments'.
            /// </summary>
            public int Increments
            {
                get
                {
                    // initial value
                    int increments = 1;

                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the return value
                        increments = (int)SliderControl.Increments;
                    }

                    // return value
                    return increments;
                }
                set
                {
                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the value
                        SliderControl.Increments = value;
                    }
                }
            }
            #endregion
            
            #region LabelBottomMargin
            /// <summary>
            /// This property gets or sets the value for 'LabelBottomMargin'.
            /// </summary>
            public int LabelBottomMargin
            {
                get { return labelBottomMargin; }
                set 
                { 
                    // set the value
                    labelBottomMargin = value;

                    // verify the control exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.LabelBottomMargin = value;
                    }
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
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the return value
                        color = (Color)this.LabelTextBoxControl.LabelColor;
                    }

                    // return value
                    return color;
                }
                set
                {
                    // if the control exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the return value
                        this.LabelTextBoxControl.LabelColor = value;
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

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.LabelFont = value;
                    }
                }
            }
            #endregion
            
            #region LabelText
            /// <summary>
            /// This property gets or sets the value for 'LabelText'.
            /// </summary>
            public string LabelText
            {
                get { return labelText; }
                set 
                { 
                    // set the value
                    labelText = value;

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.LabelText = value;
                    }
                }
            }
            #endregion
            
            #region LabelTextBoxControlEditable
            /// <summary>
            /// This property gets or sets the value for 'LabelTextBoxControlEditable'.
            /// </summary>
            public bool LabelTextBoxControlEditable
            {
                get { return labelTextBoxControlEditable; }
                set 
                { 
                    // set the value
                    labelTextBoxControlEditable = value;

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.Editable = value;
                    }
                }
            }
            #endregion

            #region LabelTextBoxControlHeight
            /// <summary>
            /// This property gets or sets the value for 'LabelTextBoxControlHeight'.
            /// </summary>
            public int LabelTextBoxControlHeight
            {
                get { return labelTextBoxControlHeight; }
                set
                {
                    // set the value
                    labelTextBoxControlHeight = value;

                    // if the BottomPanel exists
                    if (this.LeftPanel != null)
                    {
                        // set the value
                        this.LeftPanel.Height = value;
                    }
                }
            }
            #endregion
            
            #region LabelTextBoxControlWidth
            /// <summary>
            /// This property gets or sets the value for 'LabelTextBoxControlWidth'.
            /// </summary>
            public int LabelTextBoxControlWidth
            {
                get { return labelTextBoxControlWidth; }
                set 
                { 
                    // set the value
                    labelTextBoxControlWidth = value;

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.Width = value;
                    }
                }
            }
            #endregion
            
            #region LabelTopMargin
            /// <summary>
            /// This property gets or sets the value for 'LabelTopMargin'.
            /// </summary>
            public int LabelTopMargin
            {
                get { return labelTopMargin; }
                set 
                { 
                    // set the value
                    labelTopMargin = value;

                    // if the control exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // notify the control to set the value
                        this.LabelTextBoxControl.LabelTopMargin = value;
                    }
                }
            }
            #endregion
            
            #region LabelWidth
            /// <summary>
            /// This property gets or sets the value for 'LabelWidth'.
            /// </summary>
            public int LabelWidth
            {
                get { return labelWidth; }
                set 
                { 
                    // set the value
                    labelWidth = value;

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.LabelWidth = value;
                    }
                }
            }
            #endregion

            #region LargeChange
            /// <summary>
            /// This property gets or sets the value for 'LargeChange'.
            /// </summary>
            public int LargeChange
            {
                get
                {
                    // initial value
                    int largeChange = 5;

                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the return value
                        largeChange = (int)SliderControl.LargeChange;
                    }

                    // return value
                    return largeChange;
                }
                set
                {
                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the value
                        SliderControl.LargeChange = value;
                    }
                }
            }
            #endregion
           
            #region LeftPanelWidth
            /// <summary>
            /// This property gets or sets the value for 'LeftPanelWidth'.
            /// </summary>
            public int LeftPanelWidth
            {
                get { return leftPanelWidth; }
                set 
                { 
                    // set the value
                    leftPanelWidth = value;

                    // if the LeftPanel exists
                    if (this.LeftPanel != null)
                    {
                        // set the value
                        this.LeftPanel.Width = value;
                    }
                }
            }
            #endregion
            
            #region RightMargin
            /// <summary>
            /// This property gets or sets the value for 'RightMargin'.
            /// </summary>
            public int RightMargin
            {
                get { return rightMargin; }
                set 
                { 
                    // set the value
                    rightMargin = value;

                    // set the value for the panel width
                    this.SpacerPanel.Width = value;
                }
            }
            #endregion
            
            #region SliderMaximum
            /// <summary>
            /// This property gets or sets the value for 'SliderMaximum'.
            /// </summary>
            public int SliderMaximum
            {
                get { return sliderMaximum; }
                set 
                { 
                    // set the value
                    sliderMaximum = value;

                    // if the SliderControl exists
                    if (this.HasSliderControl)
                    {
                        // Set the maximum
                        this.SliderControl.Maximum = value;
                    }
                }
            }
            #endregion
            
            #region SliderMinimum
            /// <summary>
            /// This property gets or sets the value for 'SliderMinimum'.
            /// </summary>
            public int SliderMinimum
            {
                get { return sliderMinimum; }
                set 
                { 
                    // set the value
                    sliderMinimum = value;

                    // if the SliderControl exists
                    if (this.HasSliderControl)
                    {
                        // set the value
                        this.SliderControl.Minimum = value;
                    }
                }
            }
            #endregion

            #region SliderValue
            /// <summary>
            /// This property gets or sets the value for 'SliderValue'.
            /// </summary>
            public int SliderValue
            {
                get
                {
                    // initial value
                    int sliderValue = 0;

                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the return value
                        sliderValue = (int) SliderControl.SliderValue;
                    }

                    // return value
                    return sliderValue;
                }
                set
                {
                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the value
                        SliderControl.SliderValue = value;
                    }
                }
            }
            #endregion

            #region SmallChange
            /// <summary>
            /// This property gets or sets the value for 'SmallChange'.
            /// </summary>
            public int SmallChange
            {
                get
                {
                    // initial value
                    int smallChange = 1;

                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the return value
                        smallChange = (int)SliderControl.SmallChange;
                    }

                    // return value
                    return smallChange;
                }
                set
                {
                    // if the control exists
                    if (SliderControl != null)
                    {
                        // set the value
                        SliderControl.SmallChange = value;
                    }
                }
            }
            #endregion

            #region TextBoxBottomMargin
            /// <summary>
            /// This property gets or sets the value for 'TextBoxBottomMargin'.
            /// </summary>
            public int TextBoxBottomMargin
            {
                get { return textBoxBottomMargin; }
                set 
                { 
                    // set the value
                    textBoxBottomMargin = value;

                    // verify the control exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value on the control
                        this.LabelTextBoxControl.TextBoxBottomMargin = value;
                    }
                }
            }
            #endregion
            
            #region TextBoxDisabledColor
            /// <summary>
            /// This property gets or sets the value for 'TextBoxDisabledColor'.
            /// </summary>
            public Color TextBoxDisabledColor
            {
                get { return textBoxDisabledColor; }
                set 
                { 
                    // set the value
                    textBoxDisabledColor = value;

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.TextBoxDisabledColor = value;
                    }
                }
            }
            #endregion
            
            #region TextBoxEditableColor
            /// <summary>
            /// This property gets or sets the value for 'TextBoxEditableColor'.
            /// </summary>
            public Color TextBoxEditableColor
            {
                get { return textBoxEditableColor; }
                set 
                { 
                    // set the value
                    textBoxEditableColor = value;

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value on the control
                        this.LabelTextBoxControl.TextBoxEditableColor = value;
                    }
                }
            }
            #endregion
            
            #region TextBoxFont
            /// <summary>
            /// This property gets or sets the value for 'TextBoxFont'.
            /// </summary>
            public Font TextBoxFont
            {
                get { return textBoxFont; }
                set 
                { 
                    // set the value
                    textBoxFont = value;

                    // if the LabelTextBox exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value
                        this.LabelTextBoxControl.TextBoxFont = value;
                    }
                }
            }
            #endregion
            
            #region TextBoxRightMargin
            /// <summary>
            /// This property gets or sets the value for 'TextBoxRightMargin'.
            /// </summary>
            public int TextBoxRightMargin
            {
                get { return textBoxRightMargin; }
                set 
                { 
                    // set the value
                    textBoxRightMargin = value;

                    // if the SpacerPanel exists
                    if (this.SpacerPanel != null)
                    {
                        // set the value
                        this.SpacerPanel.Width = value;
                    }
                }
            }
            #endregion
            
            #region TextBoxTopMargin
            /// <summary>
            /// This property gets or sets the value for 'TextBoxTopMargin'.
            /// </summary>
            public int TextBoxTopMargin
            {
                get { return textBoxTopMargin; }
                set 
                { 
                    // set the value
                    textBoxTopMargin = value;

                    // if the LabelTextBoxControl exists
                    if (this.HasLabelTextBoxControl)
                    {
                        // set the value on the control
                        this.LabelTextBoxControl.TextBoxTopMargin = value;
                    }
                }
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
                        // set the height
                        this.TopMarginPanel.Height = value;
                    }
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
