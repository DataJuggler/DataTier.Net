

#region using statements

using System;

#endregion

namespace DataJuggler.Core.UltimateHelper.Objects
{

    #region class Word
    /// <summary>
    /// This class represents a single word.
    /// </summary>
    public class Word
    {
        
        #region Private Variables
        private string text;
        #endregion

        #region Constructors
        
            #region Default Constructor
            /// <summary>
            /// Create a new instance of a Word object.
            /// </summary>
            public Word()
            {
            }
            #endregion

            #region Parameterized Constructor
            public Word(string text)
            {
                // Set the value for text
                this.Text = text;
            }
            #endregion

        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// This method is here so the Text is returned when ToString is called.
            /// </summary>
            public override string ToString()
            {
                // initial value
                string text = this.Text;

                // if this object does not have any text
                if (!this.HasText)
                {
                    // set the value to null
                    text = "null";
                }

                // return value
                return text;
            }
            #endregion
            
        #endregion
        
        #region Properties

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
            
            #region Text
            /// <summary>
            /// This property gets or sets the value for 'Text'.
            /// </summary>
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
