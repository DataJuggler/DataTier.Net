
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class DTNField
    [Serializable]
    public partial class DTNField
    {

        #region Private Variables
        private GridColumn gridColumn;
        private bool loadByTableId;
        private bool assigned;
        private bool descending;
        #endregion

        #region Constructor
        public DTNField()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DTNField Clone()
            {
                // Create New Object
                DTNField newDTNField = (DTNField) this.MemberwiseClone();

                // Return Cloned Object
                return newDTNField;
            }
            #endregion

            #region ToString()
            /// <summary>
            /// returns the String
            /// </summary>
            public override string ToString()
            {
                // initial value
                string toString = FieldName;

                // return value
                return toString;
            }
            #endregion

        #endregion

        #region Properties

            #region Assigned
            /// <summary>
            /// This property gets or sets the value for 'Assigned'.
            /// </summary>
            public bool Assigned
            {
                get { return assigned; }
                set { assigned = value; }
            }
            #endregion
            
            #region Descending
            /// <summary>
            /// This property gets or sets the value for 'Descending'.
            /// </summary>
            public bool Descending
            {
                get { return descending; }
                set { descending = value; }
            }
            #endregion
            
            #region GridColumn
            /// <summary>
            /// This property gets or sets the value for 'GridColumn'.
            /// </summary>
            public GridColumn GridColumn
            {
                get { return gridColumn; }
                set { gridColumn = value; }
            }
            #endregion
            
            #region HasGridColumn
            /// <summary>
            /// This property returns true if this object has a 'GridColumn'.
            /// </summary>
            public bool HasGridColumn
            {
                get
                {
                    // initial value
                    bool hasGridColumn = (GridColumn != null);

                    // return value
                    return hasGridColumn;
                }
            }
            #endregion
            
            #region LoadByTableId
            /// <summary>
            /// This property gets or sets the value for 'LoadByTableId'.
            /// </summary>
            public bool LoadByTableId
            {
                get { return loadByTableId; }
                set { loadByTableId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
