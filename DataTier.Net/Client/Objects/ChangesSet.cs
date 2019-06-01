

#region using statements

using DataJuggler.Core.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class ChangesSet
    /// <summary>
    /// This class is used to keep track of which Tables and Fields
    /// have had their exclude value change.
    /// </summary>
    public class ChangesSet
    {
        
        #region Private Variables
        private List<ExcludeInfo> changes;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a ChangesSet object
        /// </summary>
        public ChangesSet()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // create both lists
                this.Changes = new List<ExcludeInfo>();
            }
            #endregion

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // initial value
                string info = "";
                
                // set the return value
                info = "Changes: " + this.Changes.Count;
                
                // return value
                return info;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Changes
            /// <summary>
            /// This property gets or sets the value for 'Changes'.
            /// </summary>
            public List<ExcludeInfo> Changes
            {
                get { return changes; }
                set { changes = value; }
            }
            #endregion
            
            #region HasChanges
            /// <summary>
            /// This property returns true if this object has a 'Changes'.
            /// </summary>
            public bool HasChanges
            {
                get
                {
                    // initial value
                    bool hasChanges = (this.Changes != null);
                    
                    // return value
                    return hasChanges;
                }
            }
            #endregion

            #region HasOneOrMoreChanges
            /// <summary>
            /// This property returns true if this object has one or more Changes
            /// </summary>
            public bool HasOneOrMoreChanges
            {
                get
                {
                    // initial value
                    bool hasOneOrMoreChanges = ListHelper.HasOneOrMoreItems(Changes);
                    
                    // return value
                    return hasOneOrMoreChanges;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
