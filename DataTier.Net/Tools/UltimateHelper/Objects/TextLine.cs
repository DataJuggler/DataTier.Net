

#region using statements

using System.Collections.Generic;

#endregion

namespace DataJuggler.Core.UltimateHelper.Objects
{

    #region class TextLine
    /// <summary>
    /// This class represents one line of Text.
    /// </summary>
    public class TextLine
    {
        
        #region Private Variables
        private string text;
        private List<Word> words;
        private int lineNumber;
        #endregion

        #region Constructors

            #region Default Constructor
            /// <summary>
            /// Create a new instance of a TextLine object.
            /// </summary>
            public TextLine()
            {
                
            } 
            #endregion

            #region Parameterized Constructor
            /// <summary>
            /// Create a new instance of a TextLine object and set the Text property
            /// </summary>
            public TextLine(string text)
            {
                // Set the Text property
                this.Text = text;
            }
            #endregion

        #endregion

        #region Methods
            
            #region ToString()
            /// <summary>
            /// This method returns the Text of this object when ToString is called.
            /// </summary>
            public override string ToString()
            {
                // return the Text when ToString is called.
                return this.Text;
            }
            #endregion
            
        #endregion
      
        #region Properties
            
            #region LineNumber
            /// <summary>
            /// This property gets or sets the value for 'LineNumber'.
            /// </summary>
            public int LineNumber
            {
                get { return lineNumber; }
                set { lineNumber = value; }
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
            
            #region Words
            /// <summary>
            /// This property gets or sets the value for 'Words'.
            /// </summary>
            public List<Word> Words
            {
                get { return words; }
                set { words = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
