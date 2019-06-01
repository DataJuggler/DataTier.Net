

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class CustomReader
    [Serializable]
    public partial class CustomReader
    {

        #region Private Variables
        private bool fetchAllForTable;
        private FieldSet fieldSet;
        private DTNTable table;
        #endregion

        #region Constructor
        public CustomReader()
        {
            
        }
        #endregion

        #region Methods

            #region Clone()
            public CustomReader Clone()
            {
                // Create New Object
                CustomReader newCustomReader = (CustomReader) this.MemberwiseClone();

                // Return Cloned Object
                return newCustomReader;
            }
        #endregion
                        
            #region ToString()
            /// <summary>
            /// method returns the Name of this object when ToString is called.
            /// </summary>
            public override string ToString()
            {
                // return the ReaderName when ToString() is called.
                return ReaderName;
            }
            #endregion
            
        #endregion

        #region Properties

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
            
            #region FieldSet
            /// <summary>
            /// This property gets or sets the value for 'FieldSet'.
            /// </summary>
            public FieldSet FieldSet
            {
                get { return fieldSet; }
                set { fieldSet = value; }
            }
            #endregion
            
            #region HasFieldSet
            /// <summary>
            /// This property returns true if this object has a 'FieldSet'.
            /// </summary>
            public bool HasFieldSet
            {
                get
                {
                    // initial value
                    bool hasFieldSet = (this.FieldSet != null);
                    
                    // return value
                    return hasFieldSet;
                }
            }
            #endregion

            #region HasFieldSetId
            /// <summary>
            /// This property returns true if the 'FieldSetId' is greater than 0.
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
            
            #region HasTable
            /// <summary>
            /// This property returns true if this object has a 'Table'.
            /// </summary>
            public bool HasTable
            {
                get
                {
                    // initial value
                    bool hasTable = (this.Table != null);
                    
                    // return value
                    return hasTable;
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
            
            #region Table
            /// <summary>
            /// This property gets or sets the value for 'Table'.
            /// </summary>
            public DTNTable Table
            {
                get { return table; }
                set { table = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
