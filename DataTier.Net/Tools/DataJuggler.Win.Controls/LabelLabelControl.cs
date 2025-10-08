

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

    #region class LabelLabelControl
    /// <summary>
    /// This control is used to host a label and a value label
    /// </summary>
    public partial class LabelLabelControl : UserControl
    {
        
        #region Private Variables
        private Color labelColor;    
        private Font labelFont;
        private string labelText;
        private ContentAlignment labelTextAlign;
        private int labelWidth;
        private Color valueLabelColor;
        private Font valueLabelFont;
        private ContentAlignment valueLabelTextAlign;
        private string text;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'LabelLabelControl' object.
        /// </summary>
        public LabelLabelControl()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Properties

            #region LabelColor
            /// <summary>
            /// This property gets or sets the value for 'LabelColor'.
            /// </summary>
            public Color LabelColor
            {
                get 
                { 
                    // initial value
                    labelColor = this.Label.ForeColor;

                    // return value
                    return labelColor;
                }
                set 
                { 
                    // set the value
                    labelColor = value;

                    // Set the value on the control
                    this.Label.ForeColor = value;
                }
            }
            #endregion

            #region LabelFont
            /// <summary>
            /// This property gets or sets the value for 'LabelFont'.
            /// </summary>
            public Font LabelFont
            {
                get 
                { 
                    // initial value
                    labelFont = this.Label.Font;

                    // return value
                    return labelFont;
                }
                set 
                { 
                    // set the value
                    labelFont = value;
                }
            }
            #endregion
            
            #region LabelText
            /// <summary>
            /// This property gets or sets the value for 'LabelText'.
            /// </summary>
            public string LabelText
            {
                get 
                {
                    // initial value
                    labelText = this.Label.Text;

                    // return value    
                    return labelText;
                }
                set 
                {
                    // set the value
                    labelText = value;

                    // Set the value on the Label
                    this.Label.Text = value;
                }
            }
            #endregion
            
            #region LabelTextAlign
            /// <summary>
            /// This property gets or sets the value for 'LabelTextAlign'.
            /// </summary>
            public ContentAlignment LabelTextAlign
            {
                get 
                {
                    // set the value
                    labelTextAlign = this.Label.TextAlign;

                    // return value
                    return labelTextAlign;
                }
                set 
                {
                    // set the value
                    labelTextAlign = value;

                    this.Label.TextAlign = value;
                }
            }
            #endregion
            
            #region LabelWidth
            /// <summary>
            /// This property gets or sets the value for 'LabelWidth'.
            /// </summary>
            public int LabelWidth
            {
                get 
                {
                    // initial value
                    labelWidth = this.Label.Width;

                    // return value
                    return labelWidth;
                }
                set 
                {
                    // set the value
                    labelWidth = value;

                    // set the value on the label
                    this.Label.Width = value;
                }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// This property gets or sets the value for 'Text'.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
            public override string Text
            {
                get 
                { 
                    // set the value
                    text = this.ValueLabel.Text;

                    // return value
                    return text; 
                }
                set
                {
                    // set the value
                    text = value;

                    // Set the value on the control
                    this.ValueLabel.Text = text;
                }
            }
            #endregion
            
            #region ValueLabelColor
            /// <summary>
            /// This property gets or sets the value for 'ValueLabelColor'.
            /// </summary>
            public Color ValueLabelColor
            {
                get
                {
                    // set the value
                    valueLabelColor = this.ValueLabel.ForeColor;

                    // return value
                    return valueLabelColor;
                }
                set
                {
                    // set the value
                    valueLabelColor = value;

                    // set the value on the control
                    this.ValueLabel.ForeColor = value;
                }
            }
            #endregion
            
            #region ValueLabelFont
            /// <summary>
            /// This property gets or sets the value for 'ValueLabelFont'.
            /// </summary>
            public Font ValueLabelFont
            {
                get
                {
                    // set the value
                    valueLabelFont = this.ValueLabel.Font;

                    // return value
                    return valueLabelFont;
                }
                set
                {
                    // set the value
                    valueLabelFont = value;

                    // set the value on the control
                    this.ValueLabel.Font = value;
                }
            }
            #endregion
            
            #region ValueLabelTextAlign
            /// <summary>
            /// This property gets or sets the value for 'ValueLabelTextAlign'.
            /// </summary>
            public ContentAlignment ValueLabelTextAlign
            {
                get
                {
                    // set the value
                    valueLabelTextAlign = this.ValueLabel.TextAlign;

                    // return value
                    return valueLabelTextAlign;
                }
                set
                {
                    // set the value
                    valueLabelTextAlign = value;

                    // set the value on the control
                    this.ValueLabel.TextAlign = value;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
