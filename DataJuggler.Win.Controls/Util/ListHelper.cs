

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

#endregion

namespace DataJuggler.Win.Controls.Util
{

    #region class ListHelper
    /// <summary>
    /// This class contains helper methods to convert Collections to List<T> />
    /// </summary>
    public class ListHelper
    {
        
        #region Methods

            #region ConvertToListOf<T>(IList sourceList)
            /// <summary>
            /// This method converts an IList to a Generic List.
            /// </summary>
            public static object ConvertToListOf<T>(IList sourceList)
            {
                // initial value
                IList<T> convertedList = new List<T>();

                // if the sourceList exists
                if (sourceList != null)
                {
                    // iterate the items
                    foreach(T value in sourceList)
                    {
                        // add this item to the return value
                        convertedList.Add(value);
                    }
                }

                // return value
                return convertedList;
            }
            #endregion

            #region HasOneOrMoreItems(List<object> list)
            /// <summary>
            /// This method returns true if the list provided exists and has at least one item.
            /// </summary>
            public static bool HasOneOrMoreItems(IList sourceList)
            {
                // initial value
                bool hasOneOrMoreItems = false;

                // if there are one or more items in the sourceList
                if ((sourceList != null) && (sourceList.Count > 0))
                {
                    // set to true
                    hasOneOrMoreItems = true;
                }

                // return value
                return hasOneOrMoreItems;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
