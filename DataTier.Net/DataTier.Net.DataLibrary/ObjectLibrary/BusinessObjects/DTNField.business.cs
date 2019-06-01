

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNField
    [Serializable]
    public partial class DTNField
    {

        #region Private Variables
        private bool fetchAllForFieldSet;
        private bool deleteAllForProject;
        private bool fetchAllForTable;
        private int fieldSetId;
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
            /// This method returns the FieldName when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return this.FieldName;
            }
            #endregion

        #endregion

        #region Properties

            #region DeleteAllForProject
            /// <summary>
            /// This property gets or sets the value for 'DeleteAllForProject'.
            /// </summary>
            public bool DeleteAllForProject
            {
                get { return deleteAllForProject; }
                set { deleteAllForProject = value; }
            }
            #endregion
            
            #region FetchAllForFieldSet
            /// <summary>
            /// This property gets or sets the value for 'FetchAllForFieldSet'.
            /// </summary>
            public bool FetchAllForFieldSet
            {
                get { return fetchAllForFieldSet; }
                set { fetchAllForFieldSet = value; }
            }
            #endregion
            
            #region FetchAllForTable
            /// <summary>
            /// This property gets or sets the value for 'FetchAllForTable'.
            /// </summary>
            public bool FetchAllForTable
            {
                get { return fetchAllForTable; }
                set { fetchAllForTable = value; }
            }
            #endregion
            
            #region FieldSetId
            /// <summary>
            /// This property gets or sets the value for 'FieldSetId'.
            /// </summary>
            public int FieldSetId
            {
                get { return fieldSetId; }
                set { fieldSetId = value; }
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
            
            #region HasTableId
            /// <summary>
            /// This property returns true if the 'TableId' is set.
            /// </summary>
            public bool HasTableId
            {
                get
                {
                    // initial value
                    bool hasTableId = (this.TableId > 0);
                    
                    // return value
                    return hasTableId;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
