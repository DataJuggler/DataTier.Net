

#region using statements

using DataJuggler.Core.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class EnumerationHelper
    /// <summary>
    /// This class is used to make it simple to pass in a fieldName and determine if the field is an Enumeration.
    /// </summary>
    public class EnumerationHelper
    {
        
        #region Methods

            #region GetEnumerationDataType(string fieldName, List<Enumeration> enumerations)
            /// <summary>
            /// This method returns the Enumeration Data Type
            /// </summary>
            public static string GetEnumerationDataType(string fieldName, List<Enumeration> enumerations)
            {
                // initial value
                string enumerationDataType = "";

                // if there are one or more Enumerations
                if ((ListHelper.HasOneOrMoreItems(enumerations)) && (TextHelper.Exists(fieldName)))
                {
                    // Iterate the collection of Enumeration objects                    
                    foreach (Enumeration enumeration in enumerations)
                    {
                        // if this field is in the Enumerations list
                        if (TextHelper.Equals(enumeration.FieldName, fieldName))
                        {
                            // set the return value to true
                            enumerationDataType = enumeration.EnumerationName;
                            
                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return enumerationDataType;
            }
            #endregion

            #region IsEnumeration(string fieldName, List<Enumeration> enumerations)
            /// <summary>
            /// This method is used to determine if a field is an Enumeration
            /// </summary>
            /// <param name="fieldName"></param>
            /// <param name=""></param>
            /// <returns></returns>
            public static bool IsEnumeration(string fieldName, List<Enumeration> enumerations)
            {
                // initial value
                bool isEnumeration = false;

                // if there are one or more Enumerations
                if ((ListHelper.HasOneOrMoreItems(enumerations)) && (TextHelper.Exists(fieldName)))
                {
                    // Iterate the collection of Enumeration objects                    
                    foreach (Enumeration enumeration in enumerations)
                    {
                        // if this field is in the Enumerations list
                        if (TextHelper.Equals(enumeration.FieldName, fieldName))
                        {
                            // set the return value to true
                            isEnumeration = true;
                            
                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return isEnumeration;
            }
            #endregion
            
            #region IsEnumeration(string fieldName, List<Enumeration> enumerations, ref string enumerationDataType)
            /// <summary>
            /// This method is used to determine if a field is an Enumeration
            /// </summary>
            /// <param name="fieldName"></param>
            /// <param name=""></param>
            /// <returns></returns>
            public static bool IsEnumeration(string fieldName, List<Enumeration> enumerations, ref string enumerationDataType)
            {
                // initial value
                bool isEnumeration = false;

                // if there are one or more Enumerations
                if ((ListHelper.HasOneOrMoreItems(enumerations)) && (TextHelper.Exists(fieldName)))
                {
                    // Iterate the collection of Enumeration objects
                    foreach (Enumeration enumeration in enumerations)
                    {
                        // if this field is in the Enumerations list
                        if (TextHelper.Equals(enumeration.FieldName, fieldName))
                        {
                            // set the return value to true
                            isEnumeration = true;

                            // Set the EnumerationDataType
                            enumerationDataType = enumeration.EnumerationName;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return isEnumeration;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
