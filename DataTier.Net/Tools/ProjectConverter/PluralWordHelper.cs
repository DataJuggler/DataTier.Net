#region using statements

using DataJuggler.UltimateHelper;

#endregion

namespace ProjectConverter
{

    #region PluralWordHelper
    /// <summary>
    /// This class is used to create the plural form for certain words correctly.
    /// An example would be: Property should return Properties, not Propertys.
    /// This is used by DataTier.Net Code Generation Toolkit; it has been on my list
    /// to create a dictionairy to make this class extensible I just haven't had the time.
    /// </summary>
    public class PluralWordHelper
    {
        
        #region static methods

            #region GetPluralName(string singularWord, bool returnLowerCase)
            /// <summary>
            /// This method is used to get the plural word for the singularWord given.
            /// </summary>
            /// <param name="singularWord"></param>
            /// <param name="returnLowerCase"></param>
            /// <returns></returns>
            public static string GetPluralName(string singularWord, bool returnLowerCase)
            {
                // initial value
                string pluralName = singularWord;
                
                if (!String.IsNullOrEmpty(pluralName))
                {
                    // this list will evolve but this is the simplest way.
                    // An xml file or dictionairy object would also work
                    // but this is fasted.
                    switch(singularWord.ToLower())
                    {
                        case "property":
                        
                            // set the return value
                            pluralName = "Properties";
                            
                            // required
                            break;

                        case "category":

                            // set the return value
                            pluralName = "Categories";

                            // required
                            break;
                            
                        case "address":
                        
                            // set the return value
                            pluralName = "Addresses";
                            
                            // required
                            break;
                            
                        default:

                            // if singularWord doesnt end in "s" add an "s"
                            if (!singularWord.EndsWith("s", StringComparison.OrdinalIgnoreCase))
                            {
                                // add an s
                                pluralName = pluralName + "s";    
                            }
                            
                            // required
                            break;
                    }

                    // if the return value should start with a lowercase char
                    if (returnLowerCase)
                    {
                        // make the first letter lowercase if needed.
                        pluralName = TextHelper.CapitalizeFirstChar(pluralName, true);
                    }
                }

                // return value
                return pluralName;
            } 
            #endregion
        
        #endregion
        
    } 
    #endregion
    
}
