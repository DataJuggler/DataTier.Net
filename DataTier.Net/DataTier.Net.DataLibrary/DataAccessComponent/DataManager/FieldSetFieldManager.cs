

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class FieldSetFieldManager
    /// <summary>
    /// This class is used to manage a 'FieldSetField' object.
    /// </summary>
    public class FieldSetFieldManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FieldSetFieldManager' object.
        /// </summary>
        public FieldSetFieldManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteFieldSetField()
            /// <summary>
            /// This method deletes a 'FieldSetField' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteFieldSetField(DeleteFieldSetFieldStoredProcedure deleteFieldSetFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteFieldSetFieldProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllFieldSetFields()
            /// <summary>
            /// This method fetches a  'List<FieldSetField>' object.
            /// This method uses the 'FieldSetFields_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<FieldSetField>'</returns>
            /// </summary>
            public List<FieldSetField> FetchAllFieldSetFields(FetchAllFieldSetFieldsStoredProcedure fetchAllFieldSetFieldsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<FieldSetField> fieldSetFieldCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allFieldSetFieldsDataSet = this.DataHelper.LoadDataSet(fetchAllFieldSetFieldsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allFieldSetFieldsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allFieldSetFieldsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            fieldSetFieldCollection = FieldSetFieldReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return fieldSetFieldCollection;
            }
            #endregion

            #region FindFieldSetField()
            /// <summary>
            /// This method finds a  'FieldSetField' object.
            /// This method uses the 'FieldSetField_Find' procedure.
            /// </summary>
            /// <returns>A 'FieldSetField' object.</returns>
            /// </summary>
            public FieldSetField FindFieldSetField(FindFieldSetFieldStoredProcedure findFieldSetFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                FieldSetField fieldSetField = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet fieldSetFieldDataSet = this.DataHelper.LoadDataSet(findFieldSetFieldProc, databaseConnector);

                    // Verify DataSet Exists
                    if(fieldSetFieldDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(fieldSetFieldDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load FieldSetField
                            fieldSetField = FieldSetFieldReader.Load(row);
                        }
                    }
                }

                // return value
                return fieldSetField;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertFieldSetField()
            /// <summary>
            /// This method inserts a 'FieldSetField' object.
            /// This method uses the 'FieldSetField_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertFieldSetField(InsertFieldSetFieldStoredProcedure insertFieldSetFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertFieldSetFieldProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateFieldSetField()
            /// <summary>
            /// This method updates a 'FieldSetField'.
            /// This method uses the 'FieldSetField_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateFieldSetField(UpdateFieldSetFieldStoredProcedure updateFieldSetFieldProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateFieldSetFieldProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
