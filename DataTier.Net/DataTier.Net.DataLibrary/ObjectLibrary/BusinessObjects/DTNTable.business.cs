
#region using statements

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class DTNTable
    [Serializable]
    public partial class DTNTable
    {

        #region Private Variables
        private List<DTNField> fields;
        private List<Method> methods;
        private List<CustomReader> customReaders;
        private List<FieldSet> fieldSets;
        private bool fetchAllForProjectId;
        private bool deleteAllForProjectId;
        private bool foundInLatestSchema;
        #endregion

        #region Constructor
        public DTNTable()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DTNTable Clone()
            {
                // Create New Object
                DTNTable newDTNTable = (DTNTable) this.MemberwiseClone();

                // Return Cloned Object
                return newDTNTable;
            }
            #endregion

            #region ToString()
            /// <summary>
            /// This method returns the TableName when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {   
                // initial value
                string tableName = "";

                // if the tableName exists
                if (!String.IsNullOrEmpty(TableName))
                {
                    // set the return value
                    tableName = this.TableName;
                }
                else
                {
                    // set the return value
                    tableName = "DTNTable";
                }

                return this.TableName;
            }
            #endregion

            #region UpdateTableIdForFields()
            /// <summary>
            /// This method Update Table Id For Fields
            /// </summary>
            public void UpdateTableIdForFields()
            {
                // If the Fields object exists
                if (this.HasFields)
                {
                    // Iterate the collection of DTNField objects
                    foreach (DTNField field in Fields)
                    {
                        // set the tableId                        
                        field.TableId = this.TableId;
                    }
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region CustomReaders
            /// <summary>
            /// This property gets or sets the value for 'CustomReaders'.
            /// </summary>
            public List<CustomReader> CustomReaders
            {
                get { return customReaders; }
                set { customReaders = value; }
            }
            #endregion
            
            #region DeleteAllForProjectId
            /// <summary>
            /// This property gets or sets the value for 'DeleteAllForProjectId'.
            /// </summary>
            public bool DeleteAllForProjectId
            {
                get { return deleteAllForProjectId; }
                set { deleteAllForProjectId = value; }
            }
            #endregion
            
            #region FetchAllForProjectId
            /// <summary>
            /// This property gets or sets the value for 'FetchAllForProjectId'.
            /// </summary>
            public bool FetchAllForProjectId
            {
                get { return fetchAllForProjectId; }
                set { fetchAllForProjectId = value; }
            }
            #endregion
            
            #region Fields
            /// <summary>
            /// This property gets or sets the value for 'Fields'.
            /// </summary>
            public List<DTNField> Fields
            {
                get { return fields; }
                set { fields = value; }
            }
            #endregion
            
            #region FieldSets
            /// <summary>
            /// This property gets or sets the value for 'FieldSets'.
            /// </summary>
            public List<FieldSet> FieldSets
            {
                get { return fieldSets; }
                set { fieldSets = value; }
            }
            #endregion
            
            #region FoundInLatestSchema
            /// <summary>
            /// This property gets or sets the value for 'FoundInLatestSchema'.
            /// </summary>
            public bool FoundInLatestSchema
            {
                get { return foundInLatestSchema; }
                set { foundInLatestSchema = value; }
            }
            #endregion
            
            #region HasCustomReaders
            /// <summary>
            /// This property returns true if this object has a 'CustomReaders'.
            /// </summary>
            public bool HasCustomReaders
            {
                get
                {
                    // initial value
                    bool hasCustomReaders = (this.CustomReaders != null);
                    
                    // return value
                    return hasCustomReaders;
                }
            }
            #endregion
            
            #region HasFields
            /// <summary>
            /// This property returns true if this object has a 'Fields'.
            /// </summary>
            public bool HasFields
            {
                get
                {
                    // initial value
                    bool hasFields = (this.Fields != null);
                    
                    // return value
                    return hasFields;
                }
            }
            #endregion
            
            #region HasFieldSets
            /// <summary>
            /// This property returns true if this object has a 'FieldSets'.
            /// </summary>
            public bool HasFieldSets
            {
                get
                {
                    // initial value
                    bool hasFieldSets = (this.FieldSets != null);
                    
                    // return value
                    return hasFieldSets;
                }
            }
            #endregion
            
            #region HasMethods
            /// <summary>
            /// This property returns true if this object has a 'Methods'.
            /// </summary>
            public bool HasMethods
            {
                get
                {
                    // initial value
                    bool hasMethods = (this.Methods != null);
                    
                    // return value
                    return hasMethods;
                }
            }
            #endregion
            
            #region HasOrderByFieldSets
            /// <summary>
            /// This property returns true if this object has an 'OrderByFieldSets'.
            /// </summary>
            public bool HasOrderByFieldSets
            {
                get
                {
                    // initial value
                    bool hasOrderByFieldSets = (this.OrderByFieldSets != null);
                    
                    // return value
                    return hasOrderByFieldSets;
                }
            }
            #endregion
            
            #region HasParameterFieldSets
            /// <summary>
            /// This property returns true if this object has a 'ParameterFieldSets'.
            /// </summary>
            public bool HasParameterFieldSets
            {
                get
                {
                    // initial value
                    bool hasParameterFieldSets = (this.ParameterFieldSets != null);
                    
                    // return value
                    return hasParameterFieldSets;
                }
            }
            #endregion
            
            #region HasProjectId
            /// <summary>
            /// This property returns true if the 'ProjectId' is set.
            /// </summary>
            public bool HasProjectId
            {
                get
                {
                    // initial value
                    bool hasProjectId = (this.ProjectId > 0);
                    
                    // return value
                    return hasProjectId;
                }
            }
            #endregion
            
            #region HasReaderFieldSets
            /// <summary>
            /// This property returns true if this object has a 'ReaderFieldSets'.
            /// </summary>
            public bool HasReaderFieldSets
            {
                get
                {
                    // initial value
                    bool hasReaderFieldSets = (this.ReaderFieldSets != null);
                    
                    // return value
                    return hasReaderFieldSets;
                }
            }
            #endregion
            
            #region Methods
            /// <summary>
            /// This property gets or sets the value for 'Methods'.
            /// </summary>
            public List<Method> Methods
            {
                get { return methods; }
                set { methods = value; }
            }
            #endregion

            #region OrderByFieldSets
            /// <summary>
            /// This read only property returns the FieldSets for a table that are set to OrderByMode equals true.
            /// </summary>
            public List<FieldSet> OrderByFieldSets
            {
                get
                {
                    // initial value
                    List<FieldSet> orderByFieldSets = null;

                    // if the value for HasFieldSets is true
                    if (HasFieldSets)
                    {
                        // set the return value
                        orderByFieldSets = FieldSets.Where(x => x.OrderByMode == true).OrderBy(x => x.Name).ToList();
                    }

                    // return value
                    return orderByFieldSets;
                }
            }
            #endregion

            #region ParameterFieldSets
            /// <summary>
            /// This read only property returns the FieldSets for a table that are set to ParameterMode equals true.
            /// </summary>
            public List<FieldSet> ParameterFieldSets
            {
                get
                {
                    // initial value
                    List<FieldSet> parameterFieldSets = null;

                    // if the value for HasFieldSets is true
                    if (HasFieldSets)
                    {
                        // set the return value
                        parameterFieldSets = FieldSets.Where(x => x.ParameterMode == true).OrderBy(x => x.Name).ToList();
                    }

                    // return value
                    return parameterFieldSets;
                }
            }
            #endregion

            #region ReaderFieldSets
            /// <summary>
            /// This read only property returns the FieldSets for a table that are set to ReaderMode equals true.
            /// </summary>
            public List<FieldSet> ReaderFieldSets
            {
                get
                {
                    // initial value
                    List<FieldSet> readerFieldSets = null;

                    // if the value for HasFieldSets is true
                    if (HasFieldSets)
                    {
                        // set the return value
                        readerFieldSets = FieldSets.Where(x => x.ReaderMode == true).OrderBy(x => x.Name).ToList();
                    }

                    // return value
                    return readerFieldSets;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
