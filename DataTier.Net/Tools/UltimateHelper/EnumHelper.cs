

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class EnumHelper
    /// <summary>
    /// This class is used to make it easier to parse an enumeration
    /// </summary>
    public class EnumHelper
    {
        
        #region GetEnumValues<T>()
        /// <summary>
        /// This method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetEnumValues<T>()
        {
            // Can't use type constraints on value types, so have to do check like this
            if (typeof(T).BaseType != typeof(Enum))
            {
                // raise an exception that the T object passed is not of type System.Enum
                throw new ArgumentException("T must be of type System.Enum");
            }

            // Return all the values of this enum
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        } 
        #endregion

        #region GetEnumValue<T>(string enumValueAsString, object notFoundValue)
        /// <summary>
        /// This method returns an enumeration value for the enumValueString given
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValueAsString"></param>
        /// <returns></returns>
        public static T GetEnumValue<T>(string enumValueAsString, object notFoundValue)
        {  
            // set the return value
            T enumValue = (T) notFoundValue;

            // Get the enumValues
            List<T> enumValues = GetEnumValues<T>();

            // If the enumValues collection exists and has one or more items
            if ((ListHelper.HasOneOrMoreItems(enumValues)) && (TextHelper.Exists(enumValueAsString)))
            {
                // itereate the enumValues
                foreach (T tempEnumValue in enumValues)
                {
                    // if this is the enum being sought
                    if (tempEnumValue.ToString().ToLower() == enumValueAsString.ToLower())
                    {
                        // set the return value
                        return tempEnumValue;
                    }
                }
            }

            // return value
            return enumValue;
        }
        #endregion

    }
    #endregion

}
