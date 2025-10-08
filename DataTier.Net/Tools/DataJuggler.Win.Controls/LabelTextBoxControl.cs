

#region using statements

using System.Windows.Forms;
using System.Drawing;
using DataJuggler.Win.Controls.Interfaces;
using System.ComponentModel;
using System;

#endregion

namespace DataJuggler.Win.Controls
{

    #region class LabelTextBoxControl : UserControl, IFieldValueControl
    /// <summary>
    /// This control is used to display a Label and a LabelTextBox for editing.
    /// </summary>
    public partial class LabelTextBoxControl : UserControl, IFieldValueControl
    {

        #region Private Variables
        private int labelWidth;
        private string labelText;
        private string text;
        private HorizontalAlignment textAlign;
        private bool passwordMode;
        private bool editable;
        private bool encrypted;
        private bool multiLine;
        private ContentAlignment labelTextAlign;
        private Font labelFont;
        private Font textBoxFont;
        private int labelTopMargin;
        private int labelBottomMargin;
        private int textBoxTopMargin;
        private int textBoxBottomMargin;
        private Color textBoxEditableColor;
        private Color textBoxDisabledColor;
        private ITextChanged onTextChangedListener;
        private int bottomMargin;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'LabelTextBoxControl' object.
        /// </summary>
        public LabelTextBoxControl()
        {
            // Create controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events
        
            #region TextBox_Resize(object sender, System.EventArgs e)
            /// <summary>
            /// This event fired when this control resized
            /// </summary>
            private void TextBox_Resize(object sender, System.EventArgs e)
            {
                // Bring the text box to front
                this.TextBox.BringToFront();

                // Refresh everything
                this.Refresh();
            }
            #endregion
            
            #region TextBox_TextChanged(object sender, EventArgs e)
            /// <summary>
            /// This event is fired when Text Box _ Text Changed
            /// </summary>
            private void TextBox_TextChanged(object sender, EventArgs e)
            {
                // if the Listener exists
                if (this.HasOnTextChangedListener)
                {
                    // send the on text changed
                    this.OnTextChangedListener.OnTextChanged(this, this.Text);
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
                // if the text box is enabled
                if ((this.TextBox.Enabled) && (this.TextBox.Visible))
                {
                    
                }
            } 
            #endregion

            #region Clear()
            /// <summary>
            /// Clear the items in this control
            /// </summary>
            public void Clear()
            {
                // erase the text
                this.TextBox.Text = "";
            }
            #endregion

            #region GetTextBox()
            /// <summary>
            /// This method returns the TextBox for this control
            /// </summary>
            /// <returns></returns>
            public TextBox GetTextBox()
            {
                // return the TextBox
                return this.TextBox;
            }
            #endregion

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            private void Init()
            {
                // set the LabelTextAlign and Width
                this.LabelTextAlign = ContentAlignment.MiddleRight;
                this.LabelWidth = 160;

                // Set Default Colors
                this.TextBoxEditableColor = Color.White;
                this.TextBoxDisabledColor = Color.LightGray;

                // create the fonts
                float fontSize = 14.25f;
                this.TextBoxFont = new Font("Verdana", fontSize);
                this.LabelFont = new Font("Verdana", fontSize, FontStyle.Bold);
                
                // Default to Editable
                this.Editable = true;
            }
            #endregion

            #region SetFocusToTextBox()
            /// <summary>
            /// This method Set Focus To Text Box
            /// </summary>
            public void SetFocusToTextBox()
            {
                // Set Focus
                this.TextBox.Focus();
            }
            #endregion

            #region Setup(string labelText, string text)
            /// <summary>
            /// This method prepares this control to be shown.
            /// </summary>
            /// <param name="labelText"></param>
            /// <param name="textBoxText"></param>
            public void Setup(string labelText, string text)
            {
                // set the properties
                this.LabelText = labelText;
                this.Text = text;
            } 
            #endregion

            #region UIControl()
            /// <summary>
            /// This method determines if the Textbox is enabled or not based upon the value
            /// of Editable and Updateable.
            /// </summary>
            private void UIControl()
            {
                // enabled or not
                bool enabled = this.Editable;

                // if Editable
               if (this.Editable)
               {
                    // set the editable color
                    this.TextBox.BackColor = this.TextBoxEditableColor;
               }
               else
               {
                    // set the editable color
                    this.TextBox.BackColor = this.TextBoxDisabledColor;
               }
                
                // enable the text box if enabled
                this.TextBox.Enabled = enabled;
            }  
            #endregion

        #endregion

        #region Properties
            
            #region BottomMargin
            /// <summary>
            /// This property gets or sets the value for 'BottomMargin'.
            /// </summary>
            public int BottomMargin
            {
                get { return bottomMargin; }
                set 
                { 
                    // set the value
                    bottomMargin = value;

                    // set the Height
                    this.BottomMarginPanel.Height = value;
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
                    UIControl(); 
                }
            } 
            #endregion

            #region Encrypted
            /// <summary>
            /// Does this control need to encrypted and decrypt the value
            /// before Saving or Displaying.
            /// </summary>
            public bool Encrypted
            {
                get { return encrypted; }
                set { encrypted = value; }
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
            
            #region HasOnTextChangedListener
            /// <summary>
            /// This property returns true if this object has an 'OnTextChangedListener'.
            /// </summary>
            public bool HasOnTextChangedListener
            {
                get
                {
                    // initial value
                    bool hasOnTextChangedListener = (this.OnTextChangedListener != null);
                    
                    // return value
                    return hasOnTextChangedListener;
                }
            }
            #endregion
            
            #region HasText
            /// <summary>
            /// This property returns true if the 'Text' exists.
            /// </summary>
            public bool HasText
            {
                get
                {
                    // initial value
                    bool hasText = (!String.IsNullOrEmpty(this.Text));
                    
                    // return value
                    return hasText;
                }
            }
            #endregion
            
            #region HasTextBoxFont
            /// <summary>
            /// This property returns true if this object has a 'TextBoxFont'.
            /// </summary>
            public bool HasTextBoxFont
            {
                get
                {
                    // initial value
                    bool hasTextBoxFont = (this.TextBoxFont != null);
                    
                    // return value
                    return hasTextBoxFont;
                }
            }
            #endregion

            #region IntValue
            /// <summary>
            /// This read only properety returns the value of this control cast as an Integer.
            /// </summary>
            public int IntValue
            {
                get
                {
                    // initial value
                    int intValue = 0;

                    // local
                    int tempValue = 0;

                    try
                    {
                        // there must be some text to be able to parse
                        if (this.HasText)
                        {
                            // try parsing the text as int
                            bool parsed = Int32.TryParse(this.Text, out tempValue);

                            // if parsed
                            if (parsed)
                            {
                                // set the return value
                                intValue = tempValue;
                            }
                        }
                    }
                    catch
                    {
                        // set to -1 (Not A Number or unparseable)
                        intValue = -1;
                    }

                    // return value
                    return intValue;
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
                    if (this.LabelBottomMarginPanel != null)
                    {
                        // Set the Height
                        this.LabelBottomMarginPanel.Height = value;
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
                    if (Label != null)
                    {
                        // set the return value
                        color = (Color) Label.ForeColor;
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

                    // if the TopMarginPanel exists
                    if (this.LabelTopMarginPanel != null)
                    {
                        // set the value
                        this.LabelTopMarginPanel.Height = value;
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

                    // if the LeftPanel exists
                    if (this.LeftPanel != null)
                    {
                        // set the LeftPanel width
                        this.LeftPanel.Width = value;
                    }
                }
            }
            #endregion

            #region MultiLine
            /// <summary>
            /// Should the LabelTextBox be MultiLine?
            /// </summary>
            public bool MultiLine
            {
                get { return multiLine; }
                set 
                { 
                    // set the value
                    multiLine = value; 
                    
                    // if the LabelTextBox exists
                    if (this.TextBox != null)
                    {
                        // set the value for the LabelTextBox
                        this.TextBox.Multiline = multiLine;
                    }
                }
            } 
            #endregion

            #region OnTextChangedListener
            /// <summary>
            /// This property gets or sets the value for 'OnTextChangedListener'.
            /// </summary>
            public ITextChanged OnTextChangedListener
            {
                get { return onTextChangedListener; }
                set { onTextChangedListener = value; }
            }
            #endregion
            
            #region PasswordMode
            /// <summary>
            /// The Password for this control.
            /// </summary>
            public bool PasswordMode
            {
                get { return passwordMode; }
                set 
                { 
                    passwordMode = value; 
                    
                    // if the LabelTextBox exists
                    if (this.TextBox != null)
                    {
                        // if password mode
                        if (passwordMode)
                        {
                            string password = "*";
                            char passwordChar = password[0];
                        
                            // set the password char
                            this.TextBox.PasswordChar = passwordChar;
                        }
                        else
                        {
                            // set the password char
                            this.TextBox.PasswordChar = new char();
                        }
                    }
                }
            } 
            #endregion

            #region ScrollBars
            /// <summary>
            /// This property gets or sets the value for 'ScrollBars'.
            /// </summary>
            public ScrollBars ScrollBars
            {
                get
                {
                    // initial value
                    ScrollBars scrollBars = ScrollBars.None;

                    // if the control exists
                    if (TextBox != null)
                    {
                        // set the return value
                        scrollBars = TextBox.ScrollBars;
                    }

                    // return value
                    return scrollBars;
                }
                set
                {
                    // if the control exists
                    if (TextBox != null)
                    {
                        // set the value
                        TextBox.ScrollBars = value;
                    }
                }
            }
            #endregion

            #region TextAlign
            /// <summary>
            /// The alignment for the TextAlign.
            /// </summary>
            public HorizontalAlignment TextAlign
            {
                get 
                {
                    // if the LabelTextBox exists
                    if (this.TextBox != null)
                    {
                        // set the return value
                        textAlign = this.TextBox.TextAlign;
                    }
                
                    // return value
                    return textAlign; 
                }
                set 
                { 
                    // set the value
                    textAlign = value; 
                    
                    // if the LabelTextBox exists
                    if (this.TextBox != null)
                    {
                        // set the return value
                        this.TextBox.TextAlign = this.TextBox.TextAlign;
                    }
                }
            } 
            #endregion

            #region Text
            /// <summary>
            /// The Text for the LabelTextBox
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
            public new string Text
            {
                get 
                { 
                    // if the LabelTextBox exists
                    if (this.TextBox != null)
                    {
                        // set the value
                        this.text = this.TextBox.Text;
                    }
                
                    // return value
                    return text; 
                }
                set 
                { 
                    // set the value
                    text = value; 
                    
                    // if the LabelTextBox exists
                    if (this.TextBox != null)
                    {
                        /// set the LabelTextBox text
                        this.TextBox.Text = value;
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

                    // if the TextBoxBottomMarginPanel exists
                    if (this.TextBoxBottomMarginPanel != null)
                    {
                        // set the height
                        this.TextBoxBottomMarginPanel.Height = value;
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

                    // Control the UI
                    UIControl();
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

                    // Control the UI
                    UIControl();
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

                    // if the font exists
                    if (this.HasTextBoxFont)
                    {
                        // Set the Font for the text box
                        this.TextBox.Font = textBoxFont;
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

                    // verify the control exists
                    if (this.TextBoxTopMarginPanel != null)
                    {
                        // set the height
                        this.TextBoxTopMarginPanel.Height = value;
                    }
                }
            }
            #endregion
            
        #endregion

    } 
    #endregion

}
