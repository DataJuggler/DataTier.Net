

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace DataTierClient.ClientUtil
{

    #region ConflictHelper
    /// <summary>
    /// This class used to fix conflicts when an object
    /// being created conflicts with another object.
    /// For now PropertyCollection for a table called
    /// Property (or tblProperty if the table has a prefix).
    /// To fix this problem a namespace is passed in and appended
    /// but only on an as needed basis. It makes code "bloated"
    /// if not needed.
    /// </summary>
    public class ConflictHelper
    {
        
        #region Static Methods

            #region CheckForConflict(string className)
            /// You must add any items to the list in yourself.
            /// A really advanced way to do it would be pass in the references set
            /// for the object being created and use some type of Visual Studio 
            /// resouce to check for conflicts. Any volunteers Microsoft people?
            /// I am doing with a switch block; this tool is used by programmers
            /// so they can figure this out.
            public static bool CheckForConflict(string className)
            {
                // initial value
                bool hasConflict = false;
                
                // safeguard (force of habit, should never happen)
                if (!String.IsNullOrEmpty(className))
                {
                    // check the class name
                    switch(className)
                    {
                        case "Property":
                        
                            // this is a conflict with System.Data.PropertyCollection
                            // I started to do add a parameter for only on collections,
                            // but I decided just to call this where you need it to fix bugs,
                            // you do not need it for the singular Property just PropertyCollection.
                            // there may be others is why I created this utility.
                            hasConflict = true;
                    
                        // required
                        break;
                    }
                }
                
                // return value
                return hasConflict;
            } 
            #endregion

            #region ResolveConflict(string className, string nameSpaceName)
            /// <summary>
            /// This method should be called after you call CheckForConflict
            /// which checks if there are conflicts with this name.
            /// </summary>
            /// <param name="className"></param>
            /// <param name="nameSpaceName"></param>
            /// <returns></returns>
            public static string ResolveConflict(string className, string nameSpaceName)
            {
                // initial value
                string resolvedName = nameSpaceName + "." + className;    
                
                // return value    
                return resolvedName;
            }
            #endregion

        #endregion
        
    } 
    #endregion
    
}
