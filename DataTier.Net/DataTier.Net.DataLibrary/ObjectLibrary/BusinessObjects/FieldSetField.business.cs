
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSetField
    [Serializable]
    public partial class FieldSetField
    {

        #region Private Variables
        private bool deleteAllForFieldSet;
        private bool findByFieldSetId;
        private bool loadByFieldSetId;
        #endregion

        #region Constructor
        public FieldSetField()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public FieldSetField Clone()
            {
                // Create New Object
                FieldSetField newFieldSetField = (FieldSetField) this.MemberwiseClone();

                // Return Cloned Object
                return newFieldSetField;
            }
            #endregion

        #endregion

        #region Properties

            #region DeleteAllForFieldSet
            /// <summary>
            /// This property gets or sets the value for 'DeleteAllForFieldSet'.
            /// </summary>
            public bool DeleteAllForFieldSet
            {
                get { return deleteAllForFieldSet; }
                set { deleteAllForFieldSet = value; }
            }
            #endregion
            
            #region FindByFieldSetId
            /// <summary>
            /// This property gets or sets the value for 'FindByFieldSetId'.
            /// </summary>
            public bool FindByFieldSetId
            {
                get { return findByFieldSetId; }
                set { findByFieldSetId = value; }
            }
            #endregion

            #region HasFieldSetId
            /// <summary>
            /// This property returns true if the 'FieldSetId' is set.
            /// </summary>
            public bool HasFieldSetId
            {
                get
                {
                    // initial value
                    bool hasFieldSetId = (this.FieldSetId > 0);
                    
                    // return value
                    return hasFieldSetId;
                }
            }
            #endregion
            
            #region LoadByFieldSetId
            /// <summary>
            /// This property gets or sets the value for 'LoadByFieldSetId'.
            /// </summary>
            public bool LoadByFieldSetId
            {
                get { return loadByFieldSetId; }
                set { loadByFieldSetId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
