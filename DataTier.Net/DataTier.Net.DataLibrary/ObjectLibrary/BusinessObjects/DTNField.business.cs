

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
        private bool descending;
        private bool fetchAllForFieldSet;
        private bool deleteAllForProject;
        private bool fetchAllForTable;
        private int fieldSetId;
        private bool assigned;
        private GridColumn gridColumn;
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

            #region Assigned
            /// <summary>
            /// This property gets or sets the value for 'Assigned'.
            /// This property is not mapped to othe database. It's
            /// only used to create Grid Columns.
            /// </summary>
            public bool Assigned
            {
                get { return assigned; }
                set { assigned = value; }
            }
            #endregion
            
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
            
            #region GridColumn
            /// <summary>
            /// This property gets or sets the value for 'GridColumn'.
            /// </summary>
            public GridColumn GridColumn
            {
                get 
                {
                    // if the value for HasGridColumn is false
                    if (!HasGridColumn)
                    {
                        // create on demand
                        gridColumn = new GridColumn();
                    }

                    // return value
                    return gridColumn;
                }
                set { gridColumn = value; }
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
            
            #region HasGridColumn
            /// <summary>
            /// This property returns true if this object has a 'GridColumn'.
            /// </summary>
            public bool HasGridColumn
            {
                get
                {
                    // initial value
                    bool hasGridColumn = (gridColumn != null);
                    
                    // return value
                    return hasGridColumn;
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
