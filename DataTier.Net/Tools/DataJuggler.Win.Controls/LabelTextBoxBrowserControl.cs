

#region using statements

using DataJuggler.Win.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.Win.Controls.Enumerations;
using DataJuggler.Core.UltimateHelper;

#endregion

namespace DataJuggler.Win.Controls
{

    #region delegate CustomOpenDelegate
    /// <summary>
    /// This method is used to create a callback method for the 
    /// </summary>
    public delegate void CustomOpenDelegate();
    #endregion

    #region class LabelTextBoxBrowserControl
    /// <summary>
    /// This control is used to make it easy to create a browse button on any Form or Control.
    /// </summary>
    public partial class LabelTextBoxBrowserControl : UserControl
    {
        
        #region Private Variables
        private BrowseTypeEnum browseType;
        private Image buttonImage;
        private int buttonWidth;
        private Color disabledLabelColor;
        private bool editable;
        private Color enabledLabelColor;
        private string filter;
        private bool hideBrowseButton;
        private string labelText;
        private ContentAlignment labelTextAlign;
        private int labelBottomMargin;
        private int labelTopMargin;
        private Font labelFont;
        private int labelWidth;
        private ITextChanged onTextChangedListener;
        private string text;
        private HorizontalAlignment textAlign;
        private int textBoxBottomMargin;
        private Color textBoxDisabledColor;
        private Color textBoxEditableColor;
        private Font textBoxFont;
        private int textBoxTopMargin;
        private string selectedPath;
        private string startPath;
        private CustomOpenDelegate openCallback;
        private ThemeEnum theme;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'LabelTextBoxBrowserControl' object.
        /// </summary>
        public LabelTextBoxBrowserControl()
        {
            // Create Controls
            InitializeComponent();
            
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region BrowseButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'BrowseButton' is clicked.
            /// </summary>
            private void BrowseButton_Click(object sender, EventArgs e)
            {
                // If we are browsing for a file
                if (BrowseType == BrowseTypeEnum.File)
                {
                    // Browse for a file
                    DialogHelper.ChooseFile(this.TextBox, this.Filter, this.StartPath);
                }
                // If browsing for a directory
                else if (BrowseType == BrowseTypeEnum.Folder)
                {
                    // Browse for a directory
                    DialogHelper.ChooseFolder(this.TextBox, this.SelectedPath);
                }
                else if ((BrowseType == BrowseTypeEnum.CustomOpen ) && (HasOpenCallback))
                {
                    // Launch the OpenCallBack
                    OpenCallback();
                }
            }
            #endregion
            
            #region BrowseButton_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Browse Button _ Mouse Enter
            /// </summary>
            private void BrowseButton_MouseEnter(object sender, EventArgs e)
            {
                // Call MouseEnter
                this.Cursor = Cursors.Hand;
            }
            #endregion
            
            #region BrowseButton_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Browse Button _ Mouse Leave
            /// </summary>
            private void BrowseButton_MouseLeave(object sender, EventArgs e)
            {
                // Call MouseLeave
                this.Cursor = Cursors.Default;
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
            
            #region EnableBrowseButton(bool enable)
            /// <summary>
            /// This method Enable Browse Button
            /// </summary>
            public void EnableBrowseButton(bool enable)
            {
                // if enable is true
                if (enable)
                {
                    this.BrowseButton.Enabled = true;
                    this.BrowseButton.BackgroundImage = Properties.Resources.DarkBlueButton;
                }
                else
                {
                    this.BrowseButton.Enabled = false;
                    this.BrowseButton.BackgroundImage = Properties.Resources.DarkButton;
                }
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Default to enabled
                this.Enabled = true;
                
                // Default Colors
                this.Theme = ThemeEnum.Dark;
                
                this.Font = new Font("Verdana", 12);
                this.LabelFont = new Font("Verdana", 12, FontStyle.Bold);
                BackColor = Color.Transparent;
                this.TextBoxFont = this.Font;
                
                // Handle which controls are enabled or disabled and change the colors accordingly
                UIControl(this.Enabled);
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
            
            #region UIControl(bool enable)
            /// <summary>
            /// This method UI Control
            /// </summary>
            public void UIControl(bool enable)
            {
                // If the value for the property this.Enabled is true
                if (enable)
                {
                    // Use LemonChiffon if enable
                    this.Label.ForeColor = EnabledLabelColor;
                    this.BrowseButton.BackgroundImage = Properties.Resources.DarkBlueButton;
                }
                else 
                {
                    // Use DarkGray if disabled
                    this.Label.ForeColor = DisabledLabelColor;
                    this.BrowseButton.BackgroundImage = Properties.Resources.DarkButton;
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region BrowseType
            /// <summary>
            /// This property gets or sets the value for 'BrowseType'.
            /// </summary>
            public BrowseTypeEnum BrowseType
            {
                get { return browseType; }
                set { browseType = value; }
            }
            #endregion
            
            #region ButtonImage
            /// <summary>
            /// This property gets or sets the value for 'ButtonImage'.
            /// </summary>
            public Image ButtonImage
            {
                get
                { 
                    // set the return value
                    buttonImage = this.BrowseButton.BackgroundImage;
                    
                    // return value
                    return buttonImage;
                }
                set 
                {
                    // set the value
                    buttonImage = value;
                    
                    // Set the BackgroundImage
                    this.BrowseButton.BackgroundImage = value;
                }
            }
            #endregion
            
            #region ButtonWidth
            /// <summary>
            /// This property gets or sets the value for 'ButtonWidth'.
            /// </summary>
            public int ButtonWidth
            {
                get 
                { 
                    // Set the button width
                    buttonWidth = this.BrowseButton.Width;
                    
                    // return value
                    return buttonWidth;
                }
                set 
                { 
                    // Set the value
                    buttonWidth = value;
                    
                    // set the width
                    this.BrowseButton.Width = value;
                }
            }
            #endregion
            
            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;
                    
                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;
                    
                    // return value
                    return cp;
                }
            }
            #endregion
            
            #region DisabledLabelColor
            /// <summary>
            /// This property gets or sets the value for 'DisabledLabelColor'.
            /// </summary>
            public Color DisabledLabelColor
            {
                get { return disabledLabelColor; }
                set { disabledLabelColor = value; }
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
                }
            } 
            #endregion
            
            #region EnabledLabelColor
            /// <summary>
            /// This property gets or sets the value for 'EnabledLabelColor'.
            /// </summary>
            public Color EnabledLabelColor
            {
                get { return enabledLabelColor; }
                set { enabledLabelColor = value; }
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
            
            #region Filter
            /// <summary>
            /// This property gets or sets the value for 'Filter'.
            /// </summary>
            public string Filter
            {
                get { return filter; }
                set { filter = value; }
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
            
            #region HasOpenCallback
            /// <summary>
            /// This property returns true if this object has an 'OpenCallback'.
            /// </summary>
            public bool HasOpenCallback
            {
                get
                {
                    // initial value
                    bool hasOpenCallback = (this.OpenCallback != null);
                    
                    // return value
                    return hasOpenCallback;
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
            
            #region HideBrowseButton
            /// <summary>
            /// This property gets or sets the value for 'HideBrowseButton'.
            /// </summary>
            public bool HideBrowseButton
            {
                get { return hideBrowseButton; }
                set 
                { 
                    // set the value for hideBrowseButton
                    hideBrowseButton = value;
                    
                    // Show the BrowseButton if HideBrowseButton is not true
                    BrowseButton.Visible = !hideBrowseButton;
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
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
            public ContentAlignment LabelTextAlign
            {
                get { return labelTextAlign; }
                set 
                {   
                    // set the value
                    labelTextAlign = value; 
                    
                    if ((this.Label != null) && (value != 0))
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
            
            #region OpenCallback
            /// <summary>
            /// This property gets or sets the value for 'OpenCallback'.
            /// </summary>
            public CustomOpenDelegate OpenCallback
            {
                get { return openCallback; }
                set { openCallback = value; }
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
            
            #region SelectedPath
            /// <summary>
            /// This property gets or sets the value for 'SelectedPath'.
            /// </summary>
            public string SelectedPath
            {
                get { return selectedPath; }
                set { selectedPath = value; }
            }
            #endregion
            
            #region StartPath
            /// <summary>
            /// This property gets or sets the value for 'StartPath'.
            /// </summary>
            public string StartPath
            {
                get { return startPath; }
                set { startPath = value; }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// The Text for the LabelTextBox
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(true)]
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
            
            #region TextAlign
            /// <summary>
            /// The alignment for the TextAlign.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
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
                    UIControl(this.Enabled);
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
                    UIControl(this.Enabled);
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
            
            #region Theme
            /// <summary>
            /// This property gets or sets the value for 'Theme'.
            /// </summary>
            public ThemeEnum Theme
            {
                get { return theme; }
                set 
                { 
                    // set the value
                    theme = value;

                    // if using the Blue Theme
                    if (theme == ThemeEnum.Blue)
                    {
                        // use Dark Theme
                        this.LabelColor = Color.Black;
                        this.ButtonImage = Properties.Resources.DarkBlueButton;
                        this.EnabledLabelColor = Color.Black;
                        this.DisabledLabelColor = Color.DarkGray;
                    }
                    else
                    {
                        // use Dark Theme
                        this.LabelColor = Color.LemonChiffon;
                        this.ButtonImage = Properties.Resources.DarkButton;

                        // Set the Enable and Disabled colors in case Enabled changes
                        this.EnabledLabelColor = Color.LemonChiffon;
                        this.DisabledLabelColor = Color.LightGray;
                    }

                    // Refresh the UI
                    this.Refresh();
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
