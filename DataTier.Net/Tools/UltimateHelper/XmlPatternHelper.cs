

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region XmlPatternHelper
    /// <summary>
    /// This class is used to encode and decode xml text if the
    /// file contains ampersands (&) or greater than or less than signs.
    /// </summary>
    public class XmlPatternHelper
    {

        #region Private Variables
        // Source Values
        private const string GreaterThanSymbol = ">";
        private const string LessThanSymbol = "<";
        private const string AmpersandSymbol = "&";
        private const string PercentSymbol = "%";

        // EncodedValues
        private const string GreaterThanCode = "&gt;";
        private const string LessThanCode = "&lt;";
        private const string AmpersandCode = "&amp;";
        private const string PercentCode = "&#37;";
        #endregion      
        
        #region Methods

            #region Decode(string sourceText)
            /// <summary>
            /// Decode the xml safe text back to normal text
            /// </summary>
            /// <param name="sourceText"></param>
            /// <returns></returns>
            public static string Decode(string sourceText)
            {
                // initial value
                string decodedText = "";
                
                // If the sourceText string exists
                if (TextHelper.Exists(sourceText))
                {
                    // replace out each of the values that need to be replaced
                    decodedText = sourceText.Replace(AmpersandCode, AmpersandSymbol);
                    decodedText = decodedText.Replace(GreaterThanCode, GreaterThanSymbol);
                    decodedText = decodedText.Replace(LessThanCode, LessThanSymbol);
                    decodedText = decodedText.Replace(PercentCode, PercentSymbol);
                }
                
                // return value
                return decodedText;
            }
            #endregion

            #region Encode(string sourceText)
            /// <summary>
            /// Encode the text given into xml safe text
            /// </summary>
            /// <param name="sourceText"></param>
            /// <returns></returns>
            public static string Encode(string sourceText)
            {
                // initial value
                string encodedText = "";

                // If the sourceText string exists
                if (TextHelper.Exists(sourceText))
                {
                    // replace out each of the values that need to be replaced
                    encodedText = sourceText.Replace(GreaterThanSymbol, GreaterThanCode);
                    encodedText = encodedText.Replace(LessThanSymbol, LessThanCode);
                    encodedText = encodedText.Replace(AmpersandSymbol, AmpersandCode);
                    encodedText = encodedText.Replace(PercentSymbol, PercentCode);
                }

                // return value
                return encodedText;
            }
            #endregion

            #region NeedsEncoding(string text)
            /// <summary>
            /// This method returns true if the text passed in contains
            /// & < > or %.
            /// </summary>
            public static bool NeedsEncoding(string text)
            {
                // initial value
                bool needsEncoding = false;

                // If the text string exists
                if (TextHelper.Exists(text))
                {
                    // set to true if the text contains of the symbols that need encoding.
                    needsEncoding = text.Contains(AmpersandSymbol) || text.Contains(GreaterThanSymbol) || text.Contains(LessThanSymbol) || text.Contains(PercentSymbol);
                }
                
                // return value
                return needsEncoding;
            }
            #endregion
            
        #endregion  

    }
    #endregion

}

