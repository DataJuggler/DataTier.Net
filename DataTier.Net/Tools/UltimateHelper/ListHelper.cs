

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class ListHelper
    /// <summary>
    /// This class contains helper methods for dealing with lists and collections.
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

            #region HasOneOrMoreItems(IList list)
            /// <summary>
            /// This method returns true if the List specified exists and hast 1 or more items.
            /// </summary>
            public static bool HasOneOrMoreItems(IList list)
            {
                // initial value
                bool hasOneOrMoreItems = false;

                // if there are one or more items
                if ((list != null) && (list.Count > 0))
                {
                    // set to true
                    hasOneOrMoreItems = true;
                }

                // return value
                return hasOneOrMoreItems;
            }
            #endregion

            #region HasOneOrMoreItems(IList list, IList list2)
            /// <summary>
            /// This method returns true if both Lists specified exists and have 1 or more items each
            /// </summary>
            public static bool HasOneOrMoreItems(IList list, IList list2)
            {
                // initial value
                bool hasOneOrMoreItems = false;

                // if there are one or more items
                if ((HasOneOrMoreItems(list)) && (HasOneOrMoreItems(list2)))
                {
                    // set to true
                    hasOneOrMoreItems = true;
                }

                // return value
                return hasOneOrMoreItems;
            }
            #endregion

            #region HasOneOrMoreItems(IList list, IList list2, IList list3)
            /// <summary>
            /// This method returns true if both Lists specified exists and have 1 or more items each
            /// </summary>
            public static bool HasOneOrMoreItems(IList list, IList list2, IList list3)
            {
                // initial value
                bool hasOneOrMoreItems = false;

                // if there are one or more items
                if ((HasOneOrMoreItems(list)) && (HasOneOrMoreItems(list2)) && (HasOneOrMoreItems(list3)))
                {
                    // set to true
                    hasOneOrMoreItems = true;
                }

                // return value
                return hasOneOrMoreItems;
            }
            #endregion

            #region HasXOrMoreItems(IList list)
            /// <summary>
            /// This method returns true if the List specified exists and hast at least
            /// as many items as the value of x.
            /// </summary>
            public static bool HasXOrMoreItems(IList list, int x)
            {
                // initial value
                bool hasXOrMoreItems = false;

                // if there are one or more items
                if ((list != null) && (list.Count >= x))
                {
                    // set to true
                    hasXOrMoreItems = true;
                }

                // return value
                return hasXOrMoreItems;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
