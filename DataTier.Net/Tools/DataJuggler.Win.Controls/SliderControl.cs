

#region using statements

using System.Windows.Forms;
using DataJuggler.Win.Controls.Interfaces;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class SliderControl
    /// <summary>
    /// This class is used to capture Slider Values
    /// </summary>
    public partial class SliderControl : UserControl
    {
        
        #region Private Variables
        private int minimum;
        private int maximum;
        private LabelTextBoxControl textBox;
        private int increments;
        private ISliderValueChangedListener valueChangedListener;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SliderControl' object.
        /// </summary>
        public SliderControl()
        {
            // Create controls
            InitializeComponent();
        }
        #endregion

        #region Events

            #region Slider_ValueChanged(object sender, System.EventArgs e)
            /// <summary>
            /// This event is fired when the value of the Slider changes
            /// </summary>
            private void Slider_ValueChanged(object sender, System.EventArgs e)
            {
                try
                {
                    // if the LabelTextBox exists
                    if (this.HasTextBox)
                    {
                        // if the Increments value is set
                        if (this.HasIncrements)
                        {
                            // Get the DisplayValue
                            int sliderDisplayValue = (this.Slider.Value - (this.Slider.Value % Increments));

                            // Set the Text
                            this.LabelTextBox.Text = sliderDisplayValue.ToString();
                        }
                        else
                        {
                            // Set the Text
                            this.LabelTextBox.Text = this.Slider.Value.ToString();
                        }
                    }
                }
                catch (System.Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                try
                {
                    // if the ValueChangedListener exists
                    if (this.HasValueChangedListener)
                    {
                        // Notify the listener the value has changed
                        this.ValueChangedListener.OnSliderValueChanged(this, this.SliderValue);
                    }
                }
                catch (System.Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region HasIncrements
            /// <summary>
            /// This property returns true if the 'Increments' is set.
            /// </summary>
            public bool HasIncrements
            {
                get
                {
                    // initial value
                    bool hasIncrements = (this.Increments > 0);
                    
                    // return value
                    return hasIncrements;
                }
            }
            #endregion
            
            #region HasLabelTextBox
            /// <summary>
            /// This property returns true if this object has a 'LabelTextBox'.
            /// </summary>
            public bool HasLabelTextBox
            {
                get
                {
                    // initial value
                    bool hasLabelTextBox = (this.LabelTextBox != null);
                    
                    // return value
                    return hasLabelTextBox;
                }
            }
            #endregion
            
            #region HasTextBox
            /// <summary>
            /// This property returns true if this object has a 'TextBox'.
            /// </summary>
            public bool HasTextBox
            {
                get
                {
                    // initial value
                    bool hasTextBox = (this.TextBox != null);
                    
                    // return value
                    return hasTextBox;
                }
            }
            #endregion

            #region HasValueChangedListener
            /// <summary>
            /// This property returns true if this object has a 'ValueChangedListener'.
            /// </summary>
            public bool HasValueChangedListener
            {
                get
                {
                    // initial value
                    bool hasValueChangedListener = (this.ValueChangedListener != null);
                    
                    // return value
                    return hasValueChangedListener;
                }
            }
            #endregion
            
            #region Increments
            /// <summary>
            /// This property gets or sets the value for 'Increments'.
            /// This is the number the Slider Control rounds to in the
            /// Value Changed event
            /// </summary>
            public int Increments
            {
                get { return increments; }
                set { increments = value; }
            }
            #endregion
            
            #region LabelTextBox
            /// <summary>
            /// This property gets or sets the value for 'LabelTextBox'.
            /// </summary>
            public LabelTextBoxControl LabelTextBox
            {
                get { return textBox; }
                set { textBox = value; }
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
                    if (Slider != null)
                    {
                        // set the return value
                        largeChange = (int)Slider.LargeChange;
                    }

                    // return value
                    return largeChange;
                }
                set
                {
                    // if the control exists
                    if (Slider != null)
                    {
                        // set the value
                        Slider.LargeChange = value;
                    }
                }
            }
            #endregion

            #region Maximum
            /// <summary>
            /// This property gets or sets the value for 'Maximum'.
            /// </summary>
            public int Maximum
            {
                get { return maximum; }
                set
                {
                    // set the value
                    maximum = value;

                    // if the Slider exists
                    if (this.Slider != null)
                    {
                        // set the value
                        this.Slider.Maximum = value;
                    }
                }
            }
            #endregion

            #region Minimum
            /// <summary>
            /// This property gets or sets the value for 'Minimum'.
            /// </summary>
            public int Minimum
            {
                get { return minimum; }
                set
                {
                    // set the value
                    minimum = value;

                    // if the Slider exists
                    if (this.Slider != null)
                    {
                        // set the value
                        this.Slider.Minimum = value;
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
                    
                    // if the Slider exists
                    if (this.Slider != null)
                    {
                        // set the value
                        sliderValue = this.Slider.Value;
                    }

                    // return value
                    return sliderValue;
                }
                set
                {
                    // if the Slider exists
                    if (this.Slider != null)
                    {
                        // if the value is in range
                        if ((value >= this.Slider.Minimum) && (value <= this.Slider.Maximum))
                        {
                            // set the value
                            this.Slider.Value = value;
                        }
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
                    if (Slider != null)
                    {
                        // set the return value
                        smallChange = (int)Slider.SmallChange;
                    }

                    // return value
                    return smallChange;
                }
                set
                {
                    // if the control exists
                    if (Slider != null)
                    {
                        // set the value
                        Slider.SmallChange = value;
                    }
                }
            }
            #endregion

            #region TextBox
            /// <summary>
            /// This read only property returns the TextBox from the LabelTextBoxControl.
            /// </summary>
            public TextBox TextBox
            {
                get
                {
                    // initial value
                    TextBox textBox = null;

                    // If the LabelTextBox object exists
                    if (this.HasLabelTextBox)
                    {
                        // set the TextBox
                        textBox = this.LabelTextBox.GetTextBox();
                    }

                    // return value
                    return textBox;
                }
            }
            #endregion
            
            #region ValueChangedListener
            /// <summary>
            /// This property gets or sets the value for 'ValueChangedListener'.
            /// </summary>
            public ISliderValueChangedListener ValueChangedListener
            {
                get { return valueChangedListener; }
                set { valueChangedListener = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
