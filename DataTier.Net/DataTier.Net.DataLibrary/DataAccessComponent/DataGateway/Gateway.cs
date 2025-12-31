
#region using statements

using DataAccessComponent.Controllers;
using DataAccessComponent.Data;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using DataJuggler.Core.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

#endregion

namespace DataAccessComponent.DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method, create a custom method
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;        
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName)
        {
            // store the ConnectionName
            ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteAdmin(int adminId, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to delete Admin objects.
            /// </summary>
            /// <param name="adminId">Delete the Admin with this adminId</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom delete.</param>
            public bool DeleteAdmin(int adminId, Admin tempAdmin = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }
        
                    // if the adminId is set
                    if (adminId > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(adminId);
                    }
        
                    // perform the delete
                    deleted = AdminController.Delete(tempAdmin, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteCustomReader(int customReaderId, CustomReader tempCustomReader = null)
            /// <summary>
            /// This method is used to delete CustomReader objects.
            /// </summary>
            /// <param name="customReaderId">Delete the CustomReader with this customReaderId</param>
            /// <param name="tempCustomReader">Pass in a tempCustomReader to perform a custom delete.</param>
            public bool DeleteCustomReader(int customReaderId, CustomReader tempCustomReader = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempCustomReader does not exist
                    if (tempCustomReader == null)
                    {
                        // create a temp CustomReader
                        tempCustomReader = new CustomReader();
                    }
        
                    // if the customReaderId is set
                    if (customReaderId > 0)
                    {
                        // set the primary key
                        tempCustomReader.UpdateIdentity(customReaderId);
                    }
        
                    // perform the delete
                    deleted = CustomReaderController.Delete(tempCustomReader, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteDTNDatabase(int databaseId, DTNDatabase tempDTNDatabase = null)
            /// <summary>
            /// This method is used to delete DTNDatabase objects.
            /// </summary>
            /// <param name="databaseId">Delete the DTNDatabase with this databaseId</param>
            /// <param name="tempDTNDatabase">Pass in a tempDTNDatabase to perform a custom delete.</param>
            public bool DeleteDTNDatabase(int databaseId, DTNDatabase tempDTNDatabase = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNDatabase does not exist
                    if (tempDTNDatabase == null)
                    {
                        // create a temp DTNDatabase
                        tempDTNDatabase = new DTNDatabase();
                    }
        
                    // if the databaseId is set
                    if (databaseId > 0)
                    {
                        // set the primary key
                        tempDTNDatabase.UpdateIdentity(databaseId);
                    }
        
                    // perform the delete
                    deleted = DTNDatabaseController.Delete(tempDTNDatabase, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteDTNField(int fieldId, DTNField tempDTNField = null)
            /// <summary>
            /// This method is used to delete DTNField objects.
            /// </summary>
            /// <param name="fieldId">Delete the DTNField with this fieldId</param>
            /// <param name="tempDTNField">Pass in a tempDTNField to perform a custom delete.</param>
            public bool DeleteDTNField(int fieldId, DTNField tempDTNField = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNField does not exist
                    if (tempDTNField == null)
                    {
                        // create a temp DTNField
                        tempDTNField = new DTNField();
                    }
        
                    // if the fieldId is set
                    if (fieldId > 0)
                    {
                        // set the primary key
                        tempDTNField.UpdateIdentity(fieldId);
                    }
        
                    // perform the delete
                    deleted = DTNFieldController.Delete(tempDTNField, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteDTNProcedure(int procedureId, DTNProcedure tempDTNProcedure = null)
            /// <summary>
            /// This method is used to delete DTNProcedure objects.
            /// </summary>
            /// <param name="procedureId">Delete the DTNProcedure with this procedureId</param>
            /// <param name="tempDTNProcedure">Pass in a tempDTNProcedure to perform a custom delete.</param>
            public bool DeleteDTNProcedure(int procedureId, DTNProcedure tempDTNProcedure = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNProcedure does not exist
                    if (tempDTNProcedure == null)
                    {
                        // create a temp DTNProcedure
                        tempDTNProcedure = new DTNProcedure();
                    }
        
                    // if the procedureId is set
                    if (procedureId > 0)
                    {
                        // set the primary key
                        tempDTNProcedure.UpdateIdentity(procedureId);
                    }
        
                    // perform the delete
                    deleted = DTNProcedureController.Delete(tempDTNProcedure, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteDTNTable(int tableId, DTNTable tempDTNTable = null)
            /// <summary>
            /// This method is used to delete DTNTable objects.
            /// </summary>
            /// <param name="tableId">Delete the DTNTable with this tableId</param>
            /// <param name="tempDTNTable">Pass in a tempDTNTable to perform a custom delete.</param>
            public bool DeleteDTNTable(int tableId, DTNTable tempDTNTable = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNTable does not exist
                    if (tempDTNTable == null)
                    {
                        // create a temp DTNTable
                        tempDTNTable = new DTNTable();
                    }
        
                    // if the tableId is set
                    if (tableId > 0)
                    {
                        // set the primary key
                        tempDTNTable.UpdateIdentity(tableId);
                    }
        
                    // perform the delete
                    deleted = DTNTableController.Delete(tempDTNTable, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteEnumeration(int enumerationId, Enumeration tempEnumeration = null)
            /// <summary>
            /// This method is used to delete Enumeration objects.
            /// </summary>
            /// <param name="enumerationId">Delete the Enumeration with this enumerationId</param>
            /// <param name="tempEnumeration">Pass in a tempEnumeration to perform a custom delete.</param>
            public bool DeleteEnumeration(int enumerationId, Enumeration tempEnumeration = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempEnumeration does not exist
                    if (tempEnumeration == null)
                    {
                        // create a temp Enumeration
                        tempEnumeration = new Enumeration();
                    }
        
                    // if the enumerationId is set
                    if (enumerationId > 0)
                    {
                        // set the primary key
                        tempEnumeration.UpdateIdentity(enumerationId);
                    }
        
                    // perform the delete
                    deleted = EnumerationController.Delete(tempEnumeration, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteFieldSet(int fieldSetId, FieldSet tempFieldSet = null)
            /// <summary>
            /// This method is used to delete FieldSet objects.
            /// </summary>
            /// <param name="fieldSetId">Delete the FieldSet with this fieldSetId</param>
            /// <param name="tempFieldSet">Pass in a tempFieldSet to perform a custom delete.</param>
            public bool DeleteFieldSet(int fieldSetId, FieldSet tempFieldSet = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempFieldSet does not exist
                    if (tempFieldSet == null)
                    {
                        // create a temp FieldSet
                        tempFieldSet = new FieldSet();
                    }
        
                    // if the fieldSetId is set
                    if (fieldSetId > 0)
                    {
                        // set the primary key
                        tempFieldSet.UpdateIdentity(fieldSetId);
                    }
        
                    // perform the delete
                    deleted = FieldSetController.Delete(tempFieldSet, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteFieldSetField(int fieldSetFieldId, FieldSetField tempFieldSetField = null)
            /// <summary>
            /// This method is used to delete FieldSetField objects.
            /// </summary>
            /// <param name="fieldSetFieldId">Delete the FieldSetField with this fieldSetFieldId</param>
            /// <param name="tempFieldSetField">Pass in a tempFieldSetField to perform a custom delete.</param>
            public bool DeleteFieldSetField(int fieldSetFieldId, FieldSetField tempFieldSetField = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempFieldSetField does not exist
                    if (tempFieldSetField == null)
                    {
                        // create a temp FieldSetField
                        tempFieldSetField = new FieldSetField();
                    }
        
                    // if the fieldSetFieldId is set
                    if (fieldSetFieldId > 0)
                    {
                        // set the primary key
                        tempFieldSetField.UpdateIdentity(fieldSetFieldId);
                    }
        
                    // perform the delete
                    deleted = FieldSetFieldController.Delete(tempFieldSetField, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteFieldSetFieldByFieldSetId(int fieldSetId)
            /// <summary>
            /// This method is used to delete 'FieldSetField' objects for the FieldSetId given.
            /// </summary>
            public bool DeleteFieldSetFieldByFieldSetId(int fieldSetId)
            {
                // initial value
                bool deleted = false;
                
                // Create a temp FieldSetField object
                FieldSetField tempFieldSetField = new FieldSetField();
                
                // Set the value for DeleteByFieldSetId to true
                tempFieldSetField.DeleteByFieldSetId = true;
                
                // Using FieldSetId As fieldSetId
                tempFieldSetField.FieldSetId = fieldSetId;
                
                // Perform the delete
                deleted = DeleteFieldSetField(0, tempFieldSetField);
                
                // return value
                return deleted;
            }
            #endregion
            
            #region DeleteMethod(int methodId, Method tempMethod = null)
            /// <summary>
            /// This method is used to delete Method objects.
            /// </summary>
            /// <param name="methodId">Delete the Method with this methodId</param>
            /// <param name="tempMethod">Pass in a tempMethod to perform a custom delete.</param>
            public bool DeleteMethod(int methodId, Method tempMethod = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempMethod does not exist
                    if (tempMethod == null)
                    {
                        // create a temp Method
                        tempMethod = new Method();
                    }
        
                    // if the methodId is set
                    if (methodId > 0)
                    {
                        // set the primary key
                        tempMethod.UpdateIdentity(methodId);
                    }
        
                    // perform the delete
                    deleted = MethodController.Delete(tempMethod, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteProject(int projectId, Project tempProject = null)
            /// <summary>
            /// This method is used to delete Project objects.
            /// </summary>
            /// <param name="projectId">Delete the Project with this projectId</param>
            /// <param name="tempProject">Pass in a tempProject to perform a custom delete.</param>
            public bool DeleteProject(int projectId, Project tempProject = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempProject does not exist
                    if (tempProject == null)
                    {
                        // create a temp Project
                        tempProject = new Project();
                    }
        
                    // if the projectId is set
                    if (projectId > 0)
                    {
                        // set the primary key
                        tempProject.UpdateIdentity(projectId);
                    }
        
                    // perform the delete
                    deleted = ProjectController.Delete(tempProject, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteProjectReference(int referencesId, ProjectReference tempProjectReference = null)
            /// <summary>
            /// This method is used to delete ProjectReference objects.
            /// </summary>
            /// <param name="referencesId">Delete the ProjectReference with this referencesId</param>
            /// <param name="tempProjectReference">Pass in a tempProjectReference to perform a custom delete.</param>
            public bool DeleteProjectReference(int referencesId, ProjectReference tempProjectReference = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempProjectReference does not exist
                    if (tempProjectReference == null)
                    {
                        // create a temp ProjectReference
                        tempProjectReference = new ProjectReference();
                    }
        
                    // if the referencesId is set
                    if (referencesId > 0)
                    {
                        // set the primary key
                        tempProjectReference.UpdateIdentity(referencesId);
                    }
        
                    // perform the delete
                    deleted = ProjectReferenceController.Delete(tempProjectReference, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteReferencesSet(int referencesSetId, ReferencesSet tempReferencesSet = null)
            /// <summary>
            /// This method is used to delete ReferencesSet objects.
            /// </summary>
            /// <param name="referencesSetId">Delete the ReferencesSet with this referencesSetId</param>
            /// <param name="tempReferencesSet">Pass in a tempReferencesSet to perform a custom delete.</param>
            public bool DeleteReferencesSet(int referencesSetId, ReferencesSet tempReferencesSet = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempReferencesSet does not exist
                    if (tempReferencesSet == null)
                    {
                        // create a temp ReferencesSet
                        tempReferencesSet = new ReferencesSet();
                    }
        
                    // if the referencesSetId is set
                    if (referencesSetId > 0)
                    {
                        // set the primary key
                        tempReferencesSet.UpdateIdentity(referencesSetId);
                    }
        
                    // perform the delete
                    deleted = ReferencesSetController.Delete(tempReferencesSet, DataManager);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.Data.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindAdmin(int adminId, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to find 'Admin' objects.
            /// </summary>
            /// <param name="adminId">Find the Admin with this adminId</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom find.</param>
            public Admin FindAdmin(int adminId, Admin tempAdmin = null)
            {
                // initial value
                Admin admin = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }

                    // if the adminId is set
                    if (adminId > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(adminId);
                    }

                    // perform the find
                    admin = AdminController.Find(tempAdmin, DataManager);
                }

                // return value
                return admin;
            }
            #endregion

            #region FindCustomReader(int customReaderId, CustomReader tempCustomReader = null)
            /// <summary>
            /// This method is used to find 'CustomReader' objects.
            /// </summary>
            /// <param name="customReaderId">Find the CustomReader with this customReaderId</param>
            /// <param name="tempCustomReader">Pass in a tempCustomReader to perform a custom find.</param>
            public CustomReader FindCustomReader(int customReaderId, CustomReader tempCustomReader = null)
            {
                // initial value
                CustomReader customReader = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempCustomReader does not exist
                    if (tempCustomReader == null)
                    {
                        // create a temp CustomReader
                        tempCustomReader = new CustomReader();
                    }

                    // if the customReaderId is set
                    if (customReaderId > 0)
                    {
                        // set the primary key
                        tempCustomReader.UpdateIdentity(customReaderId);
                    }

                    // perform the find
                    customReader = CustomReaderController.Find(tempCustomReader, DataManager);
                }

                // return value
                return customReader;
            }
            #endregion

            #region FindDTNDatabase(int databaseId, DTNDatabase tempDTNDatabase = null)
            /// <summary>
            /// This method is used to find 'DTNDatabase' objects.
            /// </summary>
            /// <param name="databaseId">Find the DTNDatabase with this databaseId</param>
            /// <param name="tempDTNDatabase">Pass in a tempDTNDatabase to perform a custom find.</param>
            public DTNDatabase FindDTNDatabase(int databaseId, DTNDatabase tempDTNDatabase = null)
            {
                // initial value
                DTNDatabase dTNDatabase = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNDatabase does not exist
                    if (tempDTNDatabase == null)
                    {
                        // create a temp DTNDatabase
                        tempDTNDatabase = new DTNDatabase();
                    }

                    // if the databaseId is set
                    if (databaseId > 0)
                    {
                        // set the primary key
                        tempDTNDatabase.UpdateIdentity(databaseId);
                    }

                    // perform the find
                    dTNDatabase = DTNDatabaseController.Find(tempDTNDatabase, DataManager);
                }

                // return value
                return dTNDatabase;
            }
            #endregion

            #region FindDTNField(int fieldId, DTNField tempDTNField = null)
            /// <summary>
            /// This method is used to find 'DTNField' objects.
            /// </summary>
            /// <param name="fieldId">Find the DTNField with this fieldId</param>
            /// <param name="tempDTNField">Pass in a tempDTNField to perform a custom find.</param>
            public DTNField FindDTNField(int fieldId, DTNField tempDTNField = null)
            {
                // initial value
                DTNField dTNField = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNField does not exist
                    if (tempDTNField == null)
                    {
                        // create a temp DTNField
                        tempDTNField = new DTNField();
                    }

                    // if the fieldId is set
                    if (fieldId > 0)
                    {
                        // set the primary key
                        tempDTNField.UpdateIdentity(fieldId);
                    }

                    // perform the find
                    dTNField = DTNFieldController.Find(tempDTNField, DataManager);
                }

                // return value
                return dTNField;
            }
            #endregion

            #region FindDTNProcedure(int procedureId, DTNProcedure tempDTNProcedure = null)
            /// <summary>
            /// This method is used to find 'DTNProcedure' objects.
            /// </summary>
            /// <param name="procedureId">Find the DTNProcedure with this procedureId</param>
            /// <param name="tempDTNProcedure">Pass in a tempDTNProcedure to perform a custom find.</param>
            public DTNProcedure FindDTNProcedure(int procedureId, DTNProcedure tempDTNProcedure = null)
            {
                // initial value
                DTNProcedure dTNProcedure = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNProcedure does not exist
                    if (tempDTNProcedure == null)
                    {
                        // create a temp DTNProcedure
                        tempDTNProcedure = new DTNProcedure();
                    }

                    // if the procedureId is set
                    if (procedureId > 0)
                    {
                        // set the primary key
                        tempDTNProcedure.UpdateIdentity(procedureId);
                    }

                    // perform the find
                    dTNProcedure = DTNProcedureController.Find(tempDTNProcedure, DataManager);
                }

                // return value
                return dTNProcedure;
            }
            #endregion

            #region FindDTNTable(int tableId, DTNTable tempDTNTable = null)
            /// <summary>
            /// This method is used to find 'DTNTable' objects.
            /// </summary>
            /// <param name="tableId">Find the DTNTable with this tableId</param>
            /// <param name="tempDTNTable">Pass in a tempDTNTable to perform a custom find.</param>
            public DTNTable FindDTNTable(int tableId, DTNTable tempDTNTable = null)
            {
                // initial value
                DTNTable dTNTable = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempDTNTable does not exist
                    if (tempDTNTable == null)
                    {
                        // create a temp DTNTable
                        tempDTNTable = new DTNTable();
                    }

                    // if the tableId is set
                    if (tableId > 0)
                    {
                        // set the primary key
                        tempDTNTable.UpdateIdentity(tableId);
                    }

                    // perform the find
                    dTNTable = DTNTableController.Find(tempDTNTable, DataManager);
                }

                // return value
                return dTNTable;
            }
            #endregion

            #region FindEnumeration(int enumerationId, Enumeration tempEnumeration = null)
            /// <summary>
            /// This method is used to find 'Enumeration' objects.
            /// </summary>
            /// <param name="enumerationId">Find the Enumeration with this enumerationId</param>
            /// <param name="tempEnumeration">Pass in a tempEnumeration to perform a custom find.</param>
            public Enumeration FindEnumeration(int enumerationId, Enumeration tempEnumeration = null)
            {
                // initial value
                Enumeration enumeration = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempEnumeration does not exist
                    if (tempEnumeration == null)
                    {
                        // create a temp Enumeration
                        tempEnumeration = new Enumeration();
                    }

                    // if the enumerationId is set
                    if (enumerationId > 0)
                    {
                        // set the primary key
                        tempEnumeration.UpdateIdentity(enumerationId);
                    }

                    // perform the find
                    enumeration = EnumerationController.Find(tempEnumeration, DataManager);
                }

                // return value
                return enumeration;
            }
            #endregion

            #region FindFieldSet(int fieldSetId, FieldSet tempFieldSet = null)
            /// <summary>
            /// This method is used to find 'FieldSet' objects.
            /// </summary>
            /// <param name="fieldSetId">Find the FieldSet with this fieldSetId</param>
            /// <param name="tempFieldSet">Pass in a tempFieldSet to perform a custom find.</param>
            public FieldSet FindFieldSet(int fieldSetId, FieldSet tempFieldSet = null)
            {
                // initial value
                FieldSet fieldSet = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempFieldSet does not exist
                    if (tempFieldSet == null)
                    {
                        // create a temp FieldSet
                        tempFieldSet = new FieldSet();
                    }

                    // if the fieldSetId is set
                    if (fieldSetId > 0)
                    {
                        // set the primary key
                        tempFieldSet.UpdateIdentity(fieldSetId);
                    }

                    // perform the find
                    fieldSet = FieldSetController.Find(tempFieldSet, DataManager);
                }

                // return value
                return fieldSet;
            }
            #endregion

            #region FindFieldSetField(int fieldSetFieldId, FieldSetField tempFieldSetField = null)
            /// <summary>
            /// This method is used to find 'FieldSetField' objects.
            /// </summary>
            /// <param name="fieldSetFieldId">Find the FieldSetField with this fieldSetFieldId</param>
            /// <param name="tempFieldSetField">Pass in a tempFieldSetField to perform a custom find.</param>
            public FieldSetField FindFieldSetField(int fieldSetFieldId, FieldSetField tempFieldSetField = null)
            {
                // initial value
                FieldSetField fieldSetField = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempFieldSetField does not exist
                    if (tempFieldSetField == null)
                    {
                        // create a temp FieldSetField
                        tempFieldSetField = new FieldSetField();
                    }

                    // if the fieldSetFieldId is set
                    if (fieldSetFieldId > 0)
                    {
                        // set the primary key
                        tempFieldSetField.UpdateIdentity(fieldSetFieldId);
                    }

                    // perform the find
                    fieldSetField = FieldSetFieldController.Find(tempFieldSetField, DataManager);
                }

                // return value
                return fieldSetField;
            }
            #endregion

            #region FindMethod(int methodId, Method tempMethod = null)
            /// <summary>
            /// This method is used to find 'Method' objects.
            /// </summary>
            /// <param name="methodId">Find the Method with this methodId</param>
            /// <param name="tempMethod">Pass in a tempMethod to perform a custom find.</param>
            public Method FindMethod(int methodId, Method tempMethod = null)
            {
                // initial value
                Method method = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempMethod does not exist
                    if (tempMethod == null)
                    {
                        // create a temp Method
                        tempMethod = new Method();
                    }

                    // if the methodId is set
                    if (methodId > 0)
                    {
                        // set the primary key
                        tempMethod.UpdateIdentity(methodId);
                    }

                    // perform the find
                    method = MethodController.Find(tempMethod, DataManager);
                }

                // return value
                return method;
            }
            #endregion

            #region FindMethodByName(string name)
            /// <summary>
            /// This method is used to find 'Method' objects for the Name given.
            /// </summary>
            public Method FindMethodByName(string name)
            {
                // initial value
                Method method = null;
                
                // Create a temp Method object
                Method tempMethod = new Method();
                
                // Set the value for FindByName to true
                tempMethod.FindByName = true;
                
                // Using Name As name
                tempMethod.Name = name;
                
                // Perform the find
                method = FindMethod(0, tempMethod);
                
                // return value
                return method;
            }
            #endregion

            #region FindPrimaryKey(DTNTable table)
            /// <summary>
            /// This method returns the Primary Key for a table.
            /// This method is for single field Primary Keys, not 
            /// Composite primary keys consisting of multiple fields.
            /// You can manually add a second jparameter if needed for now.
            /// </summary>
            public static DTNField FindPrimaryKey(DTNTable table)
            {
                // initial value
                DTNField primaryKey = null;

                // if the table has fields
                if ((NullHelper.Exists(table)) && (table.HasFields))
                {
                    // iterate the fields
                    foreach (DTNField field in table.Fields)    
                    {
                        // the field is a PrimaryKey
                        if (field.PrimaryKey)
                        {
                            // set the reeturn value
                            primaryKey = field;

                            // no reason to stick around until multiple primary key fields is handled.
                            break;
                        }
                    }
                }
    
                // return value
                return primaryKey;
            }
            #endregion
            
            #region FindProject(int projectId, Project tempProject = null)
            /// <summary>
            /// This method is used to find 'Project' objects.
            /// </summary>
            /// <param name="projectId">Find the Project with this projectId</param>
            /// <param name="tempProject">Pass in a tempProject to perform a custom find.</param>
            public Project FindProject(int projectId, Project tempProject = null)
            {
                // initial value
                Project project = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempProject does not exist
                    if (tempProject == null)
                    {
                        // create a temp Project
                        tempProject = new Project();
                    }

                    // if the projectId is set
                    if (projectId > 0)
                    {
                        // set the primary key
                        tempProject.UpdateIdentity(projectId);
                    }

                    // perform the find
                    project = ProjectController.Find(tempProject, DataManager);
                }

                // return value
                return project;
            }
            #endregion

            #region FindProjectReference(int referencesId, ProjectReference tempProjectReference = null)
            /// <summary>
            /// This method is used to find 'ProjectReference' objects.
            /// </summary>
            /// <param name="referencesId">Find the ProjectReference with this referencesId</param>
            /// <param name="tempProjectReference">Pass in a tempProjectReference to perform a custom find.</param>
            public ProjectReference FindProjectReference(int referencesId, ProjectReference tempProjectReference = null)
            {
                // initial value
                ProjectReference projectReference = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempProjectReference does not exist
                    if (tempProjectReference == null)
                    {
                        // create a temp ProjectReference
                        tempProjectReference = new ProjectReference();
                    }

                    // if the referencesId is set
                    if (referencesId > 0)
                    {
                        // set the primary key
                        tempProjectReference.UpdateIdentity(referencesId);
                    }

                    // perform the find
                    projectReference = ProjectReferenceController.Find(tempProjectReference, DataManager);
                }

                // return value
                return projectReference;
            }
            #endregion

            #region FindReferencesSet(int referencesSetId, ReferencesSet tempReferencesSet = null)
            /// <summary>
            /// This method is used to find 'ReferencesSet' objects.
            /// </summary>
            /// <param name="referencesSetId">Find the ReferencesSet with this referencesSetId</param>
            /// <param name="tempReferencesSet">Pass in a tempReferencesSet to perform a custom find.</param>
            public ReferencesSet FindReferencesSet(int referencesSetId, ReferencesSet tempReferencesSet = null)
            {
                // initial value
                ReferencesSet referencesSet = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // if the tempReferencesSet does not exist
                    if (tempReferencesSet == null)
                    {
                        // create a temp ReferencesSet
                        tempReferencesSet = new ReferencesSet();
                    }

                    // if the referencesSetId is set
                    if (referencesSetId > 0)
                    {
                        // set the primary key
                        tempReferencesSet.UpdateIdentity(referencesSetId);
                    }

                    // perform the find
                    referencesSet = ReferencesSetController.Find(tempReferencesSet, DataManager);

                    // If the referencesSet object exists
                    if (referencesSet != null)
                    {
                        // Load References For This ReferencesSet
                        referencesSet.References = LoadProjectReferencesForReferencesSetId(referencesSet.ReferencesSetId);
                    }
                }

                // return value
                return referencesSet;
            }
            #endregion

            #region FixProjectReferences()
            /// <summary>
            /// Fix Project References
            /// </summary>
            public void FixProjectReferences(ref Project project)
            {
                // If the project object exists
                if (NullHelper.Exists(project))
                {
                    // Load
                    ReferencesSet tempSet = new ReferencesSet();

                    // Set the value for the property 'FetchAllForProjectId' to true
                    tempSet.FetchAllForProjectId = true;

                    // Set the ProjectId
                    tempSet.ProjectId = project.ProjectId;
                        
                    // Load them all
                    List<ReferencesSet> referencesSets = LoadReferencesSets(tempSet);

                    // If the referencesSets collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(referencesSets))
                    {
                        foreach (ReferencesSet set in referencesSets)
                        {
                            switch (set.ReferencesSetName)
                            {
                                case "Controllers":

                                    // Set the ControllerReferencesSetId
                                    project.ControllerReferencesSetId = set.ReferencesSetId;

                                    // required
                                    break;
            
                                case "DataManager":

                                    // Set the DataManagerReferencesSetId
                                    project.DataManagerReferencesSetId = set.ReferencesSetId;

                                    // required
                                    break;
            
                                case "DataOperations":

                                    // Set the DataOperationsReferencesSetId
                                    project.DataOperationsReferencesSetId = set.ReferencesSetId;

                                    // required
                                    break;
            
                                case "DataObjects":

                                    // Set the ObjectReferencesSetId
                                    project.ObjectReferencesSetId = set.ReferencesSetId;

                                    // required
                                    break;
            
                                case "Readers":

                                    // Set the ReaderReferencesSetId
                                    project.ReaderReferencesSetId = set.ReferencesSetId;

                                    // required
                                    break;
            
                                case "StoredProcedures":

                                    // Set the StoredProcedureReferencesSetId
                                    project.StoredProcedureReferencesSetId = set.ReferencesSetId;

                                    // required
                                    break;
            
                                case "Writers":

                                    // Set the DataWriterReferencesSetId (note: special mapping)
                                    project.DataWriterReferencesSetId = set.ReferencesSetId;

                                    // required
                                    break;
                            }
                        }
                    }
                }

                // Save the project
                bool saved = SaveProject(ref project);
            }
            #endregion

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // if the value for HasErrorHandler is true
                if ((HasErrorHandler) && (ErrorHandler.HasExceptions))
                {
                    // return the Exception from the AppController
                    exception = AppController.DataManager.ErrorHandler.Exceptions.LastOrDefault();

                    // Set to null after the exception is retrieved so it does not return again
                    AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadAdmins(Admin tempAdmin = null)
            /// <summary>
            /// This method loads a collection of 'Admin' objects.
            /// </summary>
            public List<Admin> LoadAdmins(Admin tempAdmin = null)
            {
                // initial value
                List<Admin> admins = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    admins = AdminController.FetchAll(tempAdmin, DataManager);
                }

                // return value
                return admins;
            }
            #endregion

            #region LoadChildObjects(Project project)
            /// <summary>
            /// This method loads the Databases and ReferencesSets
            /// for a project.
            /// </summary>
            /// <param name="project"></param>
            /// <returns></returns>
            public Project LoadChildObjects(Project project)
            {
                // If the project exists and it is not a new project.
                if ((project != null) && (!project.IsNew))
                {
                    // Load Databases
                    project.Databases = LoadDTNDatabasesForProjectId(project.ProjectId);
                        
                    // Load References For This Project
                    LoadProjectReferencesForProject(ref project);

                    // Load the Enumerations
                    project.Enumerations = LoadEnumerationsForProjectId(project.ProjectId);
                }
                    
                // return value
                return project;
            }
            #endregion

            #region LoadCustomReaders(CustomReader tempCustomReader = null)
            /// <summary>
            /// This method loads a collection of 'CustomReader' objects.
            /// </summary>
            public List<CustomReader> LoadCustomReaders(CustomReader tempCustomReader = null)
            {
                // initial value
                List<CustomReader> customReaders = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    customReaders = CustomReaderController.FetchAll(tempCustomReader, DataManager);
                }

                // return value
                return customReaders;
            }
            #endregion

            #region LoadCustomReadersForTableId(int tableId)
            /// <summary>
            /// This method is used to load 'CustomReader' objects for the TableId given.
            /// </summary>
            public List<CustomReader> LoadCustomReadersForTableId(int tableId)
            {
                // initial value
                List<CustomReader> customReaders = null;
                
                // Create a temp CustomReader object
                CustomReader tempCustomReader = new CustomReader();
                
                // Set the value for LoadByTableId to true
                tempCustomReader.LoadByTableId = true;
                
                // Using TableId As tableId
                tempCustomReader.TableId = tableId;
                
                // Perform the load
                customReaders = LoadCustomReaders(tempCustomReader);
                
                // return value
                return customReaders;
            }
            #endregion
            
            #region LoadDTNDatabases(DTNDatabase tempDTNDatabase = null)
            /// <summary>
            /// This method loads a collection of 'DTNDatabase' objects.
            /// </summary>
            public List<DTNDatabase> LoadDTNDatabases(DTNDatabase tempDTNDatabase = null)
            {
                // initial value
                List<DTNDatabase> dTNDatabases = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    dTNDatabases = DTNDatabaseController.FetchAll(tempDTNDatabase, DataManager);
                }

                // return value
                return dTNDatabases;
            }
            #endregion

            #region LoadDTNDatabasesForProjectId(int projectId)
            /// <summary>
            /// This method is used to load 'DTNDatabase' objects for the ProjectId given.
            /// </summary>
            public List<DTNDatabase> LoadDTNDatabasesForProjectId(int projectId)
            {
                // initial value
                List<DTNDatabase> dTNDatabases = null;
                
                // Create a temp DTNDatabase object
                DTNDatabase tempDTNDatabase = new DTNDatabase();
                
                // Set the value for LoadByProjectId to true
                tempDTNDatabase.LoadByProjectId = true;
                
                // Using ProjectId As projectId
                tempDTNDatabase.ProjectId = projectId;
                
                // Perform the load
                dTNDatabases = LoadDTNDatabases(tempDTNDatabase);
                
                // return value
                return dTNDatabases;
            }
            #endregion
            
            #region LoadDTNFields(DTNField tempDTNField = null)
            /// <summary>
            /// This method loads a collection of 'DTNField' objects.
            /// </summary>
            public List<DTNField> LoadDTNFields(DTNField tempDTNField = null)
            {
                // initial value
                List<DTNField> dTNFields = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    dTNFields = DTNFieldController.FetchAll(tempDTNField, DataManager);
                }

                // return value
                return dTNFields;
            }
            #endregion

            #region LoadDTNFieldsForTableId(int tableId)
            /// <summary>
            /// This method is used to load 'DTNField' objects for the TableId given.
            /// </summary>
            public List<DTNField> LoadDTNFieldsForTableId(int tableId)
            {
                // initial value
                List<DTNField> dTNFields = null;
                
                // Create a temp DTNField object
                DTNField tempDTNField = new DTNField();
                
                // Set the value for LoadByTableId to true
                tempDTNField.LoadByTableId = true;
                
                // Using TableId As tableId
                tempDTNField.TableId = tableId;
                
                // Perform the load
                dTNFields = LoadDTNFields(tempDTNField);
                
                // return value
                return dTNFields;
            }
            #endregion
            
            #region LoadDTNProcedures(DTNProcedure tempDTNProcedure = null)
            /// <summary>
            /// This method loads a collection of 'DTNProcedure' objects.
            /// </summary>
            public List<DTNProcedure> LoadDTNProcedures(DTNProcedure tempDTNProcedure = null)
            {
                // initial value
                List<DTNProcedure> dTNProcedures = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    dTNProcedures = DTNProcedureController.FetchAll(tempDTNProcedure, DataManager);
                }

                // return value
                return dTNProcedures;
            }
            #endregion

            #region LoadDTNTables(DTNTable tempDTNTable = null)
            /// <summary>
            /// This method loads a collection of 'DTNTable' objects.
            /// </summary>
            public List<DTNTable> LoadDTNTables(DTNTable tempDTNTable = null)
            {
                // initial value
                List<DTNTable> dTNTables = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    dTNTables = DTNTableController.FetchAll(tempDTNTable, DataManager);
                }

                // return value
                return dTNTables;
            }
            #endregion

            #region LoadDTNTablesForProjectId(int projectId)
            /// <summary>
            /// This method is used to load 'DTNTable' objects for the ProjectId given.
            /// </summary>
            public List<DTNTable> LoadDTNTablesForProjectId(int projectId)
            {
                // initial value
                List<DTNTable> dTNTables = null;
                
                // Create a temp DTNTable object
                DTNTable tempDTNTable = new DTNTable();
                
                // Set the value for LoadByProjectId to true
                tempDTNTable.LoadByProjectId = true;
                
                // Using ProjectId As projectId
                tempDTNTable.ProjectId = projectId;
                
                // Perform the load
                dTNTables = LoadDTNTables(tempDTNTable);
                
                // return value
                return dTNTables;
            }
            #endregion
            
            #region LoadEnumerations(Enumeration tempEnumeration = null)
            /// <summary>
            /// This method loads a collection of 'Enumeration' objects.
            /// </summary>
            public List<Enumeration> LoadEnumerations(Enumeration tempEnumeration = null)
            {
                // initial value
                List<Enumeration> enumerations = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    enumerations = EnumerationController.FetchAll(tempEnumeration, DataManager);
                }

                // return value
                return enumerations;
            }
            #endregion

            #region LoadEnumerationsForProjectId(int projectId)
            /// <summary>
            /// This method is used to load 'Enumeration' objects for the ProjectId given.
            /// </summary>
            public List<Enumeration> LoadEnumerationsForProjectId(int projectId)
            {
                // initial value
                List<Enumeration> enumerations = null;
                
                // Create a temp Enumeration object
                Enumeration tempEnumeration = new Enumeration();
                
                // Set the value for LoadByProjectId to true
                tempEnumeration.LoadByProjectId = true;
                
                // Using ProjectId As projectId
                tempEnumeration.ProjectId = projectId;
                
                // Perform the load
                enumerations = LoadEnumerations(tempEnumeration);
                
                // return value
                return enumerations;
            }
            #endregion
            
            #region LoadFieldSetFields(FieldSetField tempFieldSetField = null)
            /// <summary>
            /// This method loads a collection of 'FieldSetField' objects.
            /// </summary>
            public List<FieldSetField> LoadFieldSetFields(FieldSetField tempFieldSetField = null)
            {
                // initial value
                List<FieldSetField> fieldSetFields = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    fieldSetFields = FieldSetFieldController.FetchAll(tempFieldSetField, DataManager);
                }

                // return value
                return fieldSetFields;
            }
            #endregion

            #region LoadFieldSetFieldViews(FieldSetFieldView tempFieldSetFieldView = null)
            /// <summary>
            /// This method loads a collection of 'FieldSetFieldView' objects.
            /// </summary>
            public List<FieldSetFieldView> LoadFieldSetFieldViews(FieldSetFieldView tempFieldSetFieldView = null)
            {
                // initial value
                List<FieldSetFieldView> fieldSetFieldViews = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    fieldSetFieldViews = FieldSetFieldViewController.FetchAll(tempFieldSetFieldView, DataManager);
                }

                // return value
                return fieldSetFieldViews;
            }
            #endregion

            #region LoadFieldSetFieldViewsForFieldSetId(int fieldSetId)
            /// <summary>
            /// This method is used to load 'FieldSetFieldView' objects for the FieldSetId given.
            /// </summary>
            public List<FieldSetFieldView> LoadFieldSetFieldViewsForFieldSetId(int fieldSetId)
            {
                // initial value
                List<FieldSetFieldView> fieldSetFieldViews = null;
                
                // Create a temp FieldSetFieldView object
                FieldSetFieldView tempFieldSetFieldView = new FieldSetFieldView();
                
                // Set the value for LoadByFieldSetId to true
                tempFieldSetFieldView.LoadByFieldSetId = true;
                
                // Using FieldSetId As fieldSetId
                tempFieldSetFieldView.FieldSetId = fieldSetId;
                
                // Perform the load
                fieldSetFieldViews = LoadFieldSetFieldViews(tempFieldSetFieldView);
                
                // return value
                return fieldSetFieldViews;
            }
            #endregion
            
            #region LoadFieldSets(FieldSet tempFieldSet = null)
            /// <summary>
            /// This method loads a collection of 'FieldSet' objects.
            /// </summary>
            public List<FieldSet> LoadFieldSets(FieldSet tempFieldSet = null)
            {
                // initial value
                List<FieldSet> fieldSets = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    fieldSets = FieldSetController.FetchAll(tempFieldSet, DataManager);
                }

                // return value
                return fieldSets;
            }
            #endregion

            #region LoadFieldSetsForTableId(int tableId)
            /// <summary>
            /// This method is used to load 'FieldSet' objects for the TableId given.
            /// </summary>
            public List<FieldSet> LoadFieldSetsForTableId(int tableId)
            {
                // initial value
                List<FieldSet> fieldSets = null;
                
                // Create a temp FieldSet object
                FieldSet tempFieldSet = new FieldSet();
                
                // Set the value for LoadByTableId to true
                tempFieldSet.LoadByTableId = true;
                
                // Using TableId As tableId
                tempFieldSet.TableId = tableId;
                
                // Perform the load
                fieldSets = LoadFieldSets(tempFieldSet);
                
                // return value
                return fieldSets;
            }
            #endregion
            
            #region LoadFieldViews(FieldView tempFieldView = null)
            /// <summary>
            /// This method loads a collection of 'FieldView' objects.
            /// </summary>
            public List<FieldView> LoadFieldViews(FieldView tempFieldView = null)
            {
                // initial value
                List<FieldView> fieldViews = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    fieldViews = FieldViewController.FetchAll(tempFieldView, DataManager);
                }

                // return value
                return fieldViews;
            }
            #endregion

            #region LoadMethods(Method tempMethod = null)
            /// <summary>
            /// This method loads a collection of 'Method' objects.
            /// </summary>
            public List<Method> LoadMethods(Method tempMethod = null)
            {
                // initial value
                List<Method> methods = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    methods = MethodController.FetchAll(tempMethod, DataManager);
                }

                // return value
                return methods;
            }
            #endregion

            #region LoadMethodsForProjectId(int projectId)
            /// <summary>
            /// This method is used to load 'Method' objects for the ProjectId given.
            /// </summary>
            public List<Method> LoadMethodsForProjectId(int projectId)
            {
                // initial value
                List<Method> methods = null;
                
                // Create a temp Method object
                Method tempMethod = new Method();
                
                // Set the value for LoadByProjectId to true
                tempMethod.LoadByProjectId = true;
                
                // Using ProjectId As projectId
                tempMethod.ProjectId = projectId;
                
                // Perform the load
                methods = LoadMethods(tempMethod);
                
                // return value
                return methods;
            }
            #endregion
            
            #region LoadMethodsForTableId(int tableId)
            /// <summary>
            /// This method is used to load 'Method' objects for the TableId given.
            /// </summary>
            public List<Method> LoadMethodsForTableId(int tableId)
            {
                // initial value
                List<Method> methods = null;
                
                // Create a temp Method object
                Method tempMethod = new Method();
                
                // Set the value for LoadByTableId to true
                tempMethod.LoadByTableId = true;
                
                // Using TableId As tableId
                tempMethod.TableId = tableId;
                
                // Perform the load
                methods = LoadMethods(tempMethod);
                
                // return value
                return methods;
            }
            #endregion
            
            #region LoadProjectReferences(ProjectReference tempProjectReference = null)
            /// <summary>
            /// This method loads a collection of 'ProjectReference' objects.
            /// </summary>
            public List<ProjectReference> LoadProjectReferences(ProjectReference tempProjectReference = null)
            {
                // initial value
                List<ProjectReference> projectReferences = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    projectReferences = ProjectReferenceController.FetchAll(tempProjectReference, DataManager);
                }

                // return value
                return projectReferences;
            }
            #endregion

            #region LoadProjectReferencesForProject(ref Project project)
            /// <summary>
            /// This method loads the project references
            /// </summary>
            /// <param name="project"></param>
            public void LoadProjectReferencesForProject(ref Project project)
            {
                // local
                // List<ProjectReference> tempReferences = null;

                // if the project exists
                if(project != null)
                {
                    // Load the ReferenceSets for ths project
                    LoadProjectReferencesSets(ref project);

                    // if not valid
                    if (!project.ValidReferences)
                    {
                        // Fix the ProjectReferences
                        FixProjectReferences(ref project);

                        // Load the ReferenceSets for ths project
                        LoadProjectReferencesSets(ref project);

                        // Create the default references
                        project.CreateDefaultReferences();
                    }                    
                }
            }
            #endregion

            #region LoadProjectReferencesForReferencesSetId(int referencesSetId)
            /// <summary>
            /// This method is used to load 'ProjectReference' objects for the ReferencesSetId given.
            /// </summary>
            public List<ProjectReference> LoadProjectReferencesForReferencesSetId(int referencesSetId)
            {
                // initial value
                List<ProjectReference> projectReferences = null;
                
                // Create a temp ProjectReference object
                ProjectReference tempProjectReference = new ProjectReference();
                
                // Set the value for LoadByReferencesSetId to true
                tempProjectReference.LoadByReferencesSetId = true;
                
                // Using ReferencesSetId As referencesSetId
                tempProjectReference.ReferencesSetId = referencesSetId;
                
                // Perform the load
                projectReferences = LoadProjectReferences(tempProjectReference);
                
                // return value
                return projectReferences;
            }
            #endregion

            #region LoadProjectReferencesSets()
            /// <summary>
            /// Load Project References Sets
            /// </summary>
            public void LoadProjectReferencesSets(ref Project project)
            {
                // If the project object exists
                if (NullHelper.Exists(project))
                {
                    // Load ReferencesSets
                    project.ControllerReferencesSet = FindReferencesSet(project.ControllerReferencesSetId);
                    project.DataManagerReferencesSet = FindReferencesSet(project.DataManagerReferencesSetId);
                    project.DataOperationsReferencesSet = FindReferencesSet(project.DataOperationsReferencesSetId);
                    project.ObjectReferencesSet = FindReferencesSet(project.ObjectReferencesSetId);
                    project.ReaderReferencesSet = FindReferencesSet(project.ReaderReferencesSetId);
                    project.StoredProcedureReferencesSet = FindReferencesSet(project.StoredProcedureReferencesSetId);
                    project.WriterReferencesSet = FindReferencesSet(project.DataWriterReferencesSetId);                    
                }
            }
            #endregion
            
            #region LoadProjectReferencesViews(ProjectReferencesView tempProjectReferencesView = null)
            /// <summary>
            /// This method loads a collection of 'ProjectReferencesView' objects.
            /// </summary>
            public List<ProjectReferencesView> LoadProjectReferencesViews(ProjectReferencesView tempProjectReferencesView = null)
            {
                // initial value
                List<ProjectReferencesView> projectReferencesViews = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    projectReferencesViews = ProjectReferencesViewController.FetchAll(tempProjectReferencesView, DataManager);
                }

                // return value
                return projectReferencesViews;
            }
            #endregion

            #region LoadProjects(Project tempProject = null)
            /// <summary>
            /// This method loads a collection of 'Project' objects.
            /// </summary>
            public List<Project> LoadProjects(Project tempProject = null)
            {
                // initial value
                List<Project> projects = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    projects = ProjectController.FetchAll(tempProject, DataManager);
                }

                // return value
                return projects;
            }
            #endregion

            #region LoadReferencesSets(ReferencesSet tempReferencesSet = null)
            /// <summary>
            /// This method loads a collection of 'ReferencesSet' objects.
            /// </summary>
            public List<ReferencesSet> LoadReferencesSets(ReferencesSet tempReferencesSet = null)
            {
                // initial value
                List<ReferencesSet> referencesSets = null;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the load
                    referencesSets = ReferencesSetController.FetchAll(tempReferencesSet, DataManager);
                }

                // return value
                return referencesSets;
            }
            #endregion

            #region SaveAdmin(ref Admin admin)
            /// <summary>
            /// This method is used to save 'Admin' objects.
            /// </summary>
            /// <param name="admin">The Admin to save.</param>
            public bool SaveAdmin(ref Admin admin)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = AdminController.Save(ref admin, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveCustomReader(ref CustomReader customReader)
            /// <summary>
            /// This method is used to save 'CustomReader' objects.
            /// </summary>
            /// <param name="customReader">The CustomReader to save.</param>
            public bool SaveCustomReader(ref CustomReader customReader)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = CustomReaderController.Save(ref customReader, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveDTNDatabase(ref DTNDatabase dTNDatabase)
            /// <summary>
            /// This method is used to save 'DTNDatabase' objects.
            /// </summary>
            /// <param name="dTNDatabase">The DTNDatabase to save.</param>
            public bool SaveDTNDatabase(ref DTNDatabase dTNDatabase)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = DTNDatabaseController.Save(ref dTNDatabase, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveDTNField(ref DTNField dTNField)
            /// <summary>
            /// This method is used to save 'DTNField' objects.
            /// </summary>
            /// <param name="dTNField">The DTNField to save.</param>
            public bool SaveDTNField(ref DTNField dTNField)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = DTNFieldController.Save(ref dTNField, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveDTNProcedure(ref DTNProcedure dTNProcedure)
            /// <summary>
            /// This method is used to save 'DTNProcedure' objects.
            /// </summary>
            /// <param name="dTNProcedure">The DTNProcedure to save.</param>
            public bool SaveDTNProcedure(ref DTNProcedure dTNProcedure)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = DTNProcedureController.Save(ref dTNProcedure, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveDTNTable(ref DTNTable dTNTable)
            /// <summary>
            /// This method is used to save 'DTNTable' objects.
            /// </summary>
            /// <param name="dTNTable">The DTNTable to save.</param>
            public bool SaveDTNTable(ref DTNTable dTNTable)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = DTNTableController.Save(ref dTNTable, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveEnumeration(ref Enumeration enumeration)
            /// <summary>
            /// This method is used to save 'Enumeration' objects.
            /// </summary>
            /// <param name="enumeration">The Enumeration to save.</param>
            public bool SaveEnumeration(ref Enumeration enumeration)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = EnumerationController.Save(ref enumeration, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveFieldSet(ref FieldSet fieldSet)
            /// <summary>
            /// This method is used to save 'FieldSet' objects.
            /// </summary>
            /// <param name="fieldSet">The FieldSet to save.</param>
            public bool SaveFieldSet(ref FieldSet fieldSet)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = FieldSetController.Save(ref fieldSet, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveFieldSetField(ref FieldSetField fieldSetField)
            /// <summary>
            /// This method is used to save 'FieldSetField' objects.
            /// </summary>
            /// <param name="fieldSetField">The FieldSetField to save.</param>
            public bool SaveFieldSetField(ref FieldSetField fieldSetField)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = FieldSetFieldController.Save(ref fieldSetField, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveMethod(ref Method method)
            /// <summary>
            /// This method is used to save 'Method' objects.
            /// </summary>
            /// <param name="method">The Method to save.</param>
            public bool SaveMethod(ref Method method)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = MethodController.Save(ref method, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveProject(ref Project project)
            /// <summary>
            /// This method is used to save 'Project' objects.
            /// </summary>
            /// <param name="project">The Project to save.</param>
            public bool SaveProject(ref Project project)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = ProjectController.Save(ref project, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveProjectReference(ref ProjectReference projectReference)
            /// <summary>
            /// This method is used to save 'ProjectReference' objects.
            /// </summary>
            /// <param name="projectReference">The ProjectReference to save.</param>
            public bool SaveProjectReference(ref ProjectReference projectReference)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = ProjectReferenceController.Save(ref projectReference, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveProjectReferences(ref Project project)
            /// <summary>
            /// This method saves the project references.
            /// </summary>
            /// <param name="project"></param>
            /// <returns></returns>
            public bool SaveProjectReferences(ref Project project)
            {
                // initial value
                bool saved = false;
                    
                // locals
                bool controllerReferencesSetSaved = false;
                bool dataManagerReferencesSetSaved = false;
                bool dataOperationsReferencesSetSaved = false;
                bool objectReferencesSetSaved = false;
                bool readerReferencesSetSaved = false;
                bool storedProcedureReferencesSetSaved = false;
                bool writerReferencesSetSaved = false;
                    
                // if project exists
                if ((project != null) && (project.ValidReferences))
                {  
                    // Create AppController
                    ApplicationController appController = new ApplicationController();

                    // set each  references set
                    ReferencesSet controllerReferencesSet = project.ControllerReferencesSet;
                    ReferencesSet dataManagerReferencesSet = project.DataManagerReferencesSet;
                    ReferencesSet objectReferencesSet = project.ObjectReferencesSet;
                    ReferencesSet dataOperationsReferencesSet = project.DataOperationsReferencesSet;
                    ReferencesSet readerReferencesSet = project.ReaderReferencesSet;                    
                    ReferencesSet storedProcedureReferencesSet = project.StoredProcedureReferencesSet;
                    ReferencesSet writerReferencesSet = project.WriterReferencesSet;

                    // Save each ReferencesSet
                    controllerReferencesSetSaved = SaveReferencesSet(ref controllerReferencesSet, true);
                    dataManagerReferencesSetSaved = SaveReferencesSet(ref dataManagerReferencesSet, true);
                    dataOperationsReferencesSetSaved = SaveReferencesSet(ref dataOperationsReferencesSet, true);
                    objectReferencesSetSaved = SaveReferencesSet(ref objectReferencesSet, true);
                    readerReferencesSetSaved = SaveReferencesSet(ref readerReferencesSet, true);
                    storedProcedureReferencesSetSaved = SaveReferencesSet(ref storedProcedureReferencesSet, true);
                    writerReferencesSetSaved = SaveReferencesSet(ref writerReferencesSet, true);
        
                    // if all saves succeeded
                    if ((controllerReferencesSetSaved) && (dataManagerReferencesSetSaved) && (dataOperationsReferencesSetSaved) && (objectReferencesSetSaved) && (readerReferencesSetSaved) && (storedProcedureReferencesSetSaved) && (writerReferencesSetSaved))
                    {
                        // Now update each object
                        project.ControllerReferencesSet = controllerReferencesSet;
                        project.DataManagerReferencesSet = dataManagerReferencesSet;
                        project.ObjectReferencesSet = objectReferencesSet;
                        project.DataOperationsReferencesSet = dataOperationsReferencesSet;
                        project.ReaderReferencesSet = readerReferencesSet;
                        project.StoredProcedureReferencesSet = storedProcedureReferencesSet;
                        project.WriterReferencesSet = writerReferencesSet;

                        // Update ID's for Project object
                        project.ControllerReferencesSetId = project.ControllerReferencesSet.ReferencesSetId;
                        project.DataManagerReferencesSetId = project.DataManagerReferencesSet.ReferencesSetId;
                        project.DataOperationsReferencesSetId = project.DataOperationsReferencesSet.ReferencesSetId;
                        project.ObjectReferencesSetId = project.ObjectReferencesSet.ReferencesSetId;
                        project.ReaderReferencesSetId = project.ReaderReferencesSet.ReferencesSetId;
                        project.StoredProcedureReferencesSetId = project.StoredProcedureReferencesSet.ReferencesSetId;
                        project.DataWriterReferencesSetId = project.WriterReferencesSet.ReferencesSetId;
                                
                        // Save the project again (without the child objects).
                        saved = SaveProject(ref project);
                    }
                }
                    
                // return value
                return saved;
            }  
            #endregion

            #region SaveProjectReferences(ref List<ProjectReference> references, int referencesSetId)
            /// <summary>
            /// This method saves a list of ProjectReference objects.
            /// </summary>
            /// <param name="references"></param>
            /// <returns></returns>
            public bool SaveProjectReferences(ref List<ProjectReference> references, int referencesSetId)
            {
                // initial value
                bool saved = false;

                // locals
                bool tempSaved = true;
                
                // Load the projectReferences for this referencesSetId
                List<ProjectReference> projectReferences = LoadProjectReferencesForReferencesSetId(referencesSetId);
                
                // if project exists
                if (references != null)
                {
                    // set saved to true
                    saved = true;

                    // Loop through each database
                    for (int x = 0; x < references.Count; x++)
                    {
                        // get a local database
                        ProjectReference projectReference = references[x];

                        // Why is this one not saved
                        if (projectReference.IsNew)
                        {
                            // If the projectReferences collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(projectReferences))
                            {
                                // Find the missing reference
                                ProjectReference missingReference = projectReferences.FirstOrDefault(a => a.ReferenceName == projectReference.ReferenceName);

                                // If the missingReference object exists
                                if (NullHelper.Exists(missingReference))
                                {
                                    // Update the Id
                                    projectReference.UpdateIdentity(missingReference.ReferencesId);
                                }
                            }
                        }

                        // Save this database
                        tempSaved = SaveProjectReference(ref projectReference);

                        // if save failed
                        if (!tempSaved)
                        {
                            // saved 
                            saved = false;
                        }
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveReferencesSet(ref ReferencesSet referencesSet)
            /// <summary>
            /// This method is used to save 'ReferencesSet' objects.
            /// </summary>
            /// <param name="referencesSet">The ReferencesSet to save.</param>
            public bool SaveReferencesSet(ref ReferencesSet referencesSet)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (HasAppController)
                {
                    // perform the save
                    saved = ReferencesSetController.Save(ref referencesSet, DataManager);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveReferencesSet(ref ReferencesSet referencesSet, bool saveChildren)
            /// <summary>
            /// This method saves a ReferencesSet
            /// </summary>
            /// <param name="referencesSet"></param>
            /// <returns></returns>
            public bool SaveReferencesSet(ref ReferencesSet referencesSet, bool saveChildren)
            {
                // initial value
                bool saved = false;
                    
                // if referencesSet exists
                if (referencesSet != null)
                {
                    // Create AppController
                    ApplicationController appController = new ApplicationController();

                    // save the database
                    saved = ReferencesSetController.Save(ref referencesSet, DataManager);
                        
                    // if saved
                    if ((saved) && (saveChildren))
                    {
                        // Save Project References
                        if(referencesSet.References != null)
                        {
                            // Set references set id
                            referencesSet.SetReferencesSetId(referencesSet.ReferencesSetId);
    
                            // save project references

                            // get a local copy
                            List<ProjectReference> references = referencesSet.References;

                            // perfrom save
                            saved = SaveProjectReferences(ref references, referencesSet.ReferencesSetId);
                        }
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region TestDatabaseConnection(ref Exception error)
            /// <summary>
            /// returns the Database Connection
            /// </summary>
            public bool TestDatabaseConnection(ref Exception error)
            {
                // initial value
                bool connected = false;

                // If the this object does not have a HasAppController property
                if (!this.HasAppController)
                {
                    // Create the Controller
                    this.AppController = new ApplicationController(this.ConnectionName);
                }

                // If the AppController object exists
                if ((this.HasAppController) && (!this.AppController.HasConnectionName))
                {
                    // Set the ConnectionName
                    this.AppController.ConnectionName = this.ConnectionName;
                }

                // perform the test
                connected = this.AppController.TestDatabaseConnection(ref error, this.DataManager);

                // return value
                return connected;
            }
            #endregion
            
        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region DataManager
            /// <summary>
            /// This read only property returns the value of DataManager from the object AppController.
            /// </summary>
            public DataManager DataManager
            {

                get
                {
                    // initial value
                    DataManager dataManager = null;

                    // if AppController exists
                    if (HasAppController)
                    {
                        // set the return value
                        dataManager = AppController.DataManager;
                    }

                    // return value
                    return dataManager;
                }
            }
            #endregion

            #region ErrorHandler
            /// <summary>
            /// This read only property returns the value of ErrorHandler from the object DataManager.
            /// </summary>
            public ErrorHandler ErrorHandler
            {

                get
                {
                    // initial value
                    ErrorHandler errorHandler = null;

                    // if DataManager exists
                    if (HasDataManager)
                    {
                        // set the return value
                        errorHandler = DataManager.ErrorHandler;
                    }

                    // return value
                    return errorHandler;
                }
            }
            #endregion

            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
            #region HasDataManager
            /// <summary>
            /// This property returns true if this object has a 'DataManager'.
            /// </summary>
            public bool HasDataManager
            {
                get
                {
                    // initial value
                    bool hasDataManager = (DataManager != null);

                    // return value
                    return hasDataManager;
                }
            }
            #endregion
            
            #region HasErrorHandler
            /// <summary>
            /// This property returns true if this object has an 'ErrorHandler'.
            /// </summary>
            public bool HasErrorHandler
            {
                get
                {
                    // initial value
                    bool hasErrorHandler = (ErrorHandler != null);

                    // return value
                    return hasErrorHandler;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

