
#region using statements

using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.DataOperations;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

#endregion

namespace DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// The Gateway to the FlyingElephantWeb.
        /// </summary>
        public Gateway()
        {
            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods

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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.CustomReaderController.Delete(tempCustomReader);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.DTNDatabaseController.Delete(tempDTNDatabase);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.DTNFieldController.Delete(tempDTNField);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.DTNTableController.Delete(tempDTNTable);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.EnumerationController.Delete(tempEnumeration);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.FieldSetController.Delete(tempFieldSet);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.FieldSetFieldController.Delete(tempFieldSetField);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteFieldSetField(int fieldSetFieldId, FieldSetField tempFieldSetField = null)
            /// <summary>
            /// This method is used to delete FieldSetFields for the fieldSetId passed in.
            /// </summary>
            /// <param name="fieldSetId">The fieldSetId to delele FieldSets for.</param>
            public bool DeleteFieldSetFieldsForFieldSetId(int fieldSetId)
            {
                // initial value
                bool deleted = false;
        
                // Create a new instance of a 'FieldSetField' object.
                FieldSetField tempFieldSetField = new FieldSetField();                

                // Set the FieldSetId
                tempFieldSetField.FieldSetId = fieldSetId;

                // Set the value for the property 'DeleteAllForFieldSet' to true
                tempFieldSetField.DeleteAllForFieldSet = true;

                // perform the delete
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.MethodController.Delete(tempMethod);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.ProjectController.Delete(tempProject);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.ProjectReferenceController.Delete(tempProjectReference);
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
                if (this.HasAppController)
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
                    deleted = this.AppController.ControllerManager.ReferencesSetController.Delete(tempReferencesSet);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteTablesForProject(int tableId, DTNTable tempDTNTable = null)
            /// <summary>
            /// This method is used to delete DTNTable objects for the ProejctId given.
            /// This only delete the values stored in DataTier.Net Database. 
            /// </summary>
            /// <param name="projectId">Delete the DTNTable with this tableId</param>
            public bool DeleteTablesForProject(int projectId)
            {
                // initial value
                bool deleted = false;
        
                // Create a new instance of a 'DTNTable' object.
                DTNTable tempTable = new DTNTable();

                // Set the value for the property 'DeleteAllForProjectId' to true
                tempTable.DeleteAllForProjectId = true;

                // Set the projectId                
                tempTable.ProjectId = projectId;

                // perform the delete
                deleted = DeleteDTNTable(0, tempTable);
        
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
                    DataAccessComponent.DataManager.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
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
                if (this.HasAppController)
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
                    customReader = this.AppController.ControllerManager.CustomReaderController.Find(tempCustomReader);
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
                if (this.HasAppController)
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
                    dTNDatabase = this.AppController.ControllerManager.DTNDatabaseController.Find(tempDTNDatabase);
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
                if (this.HasAppController)
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
                    dTNField = this.AppController.ControllerManager.DTNFieldController.Find(tempDTNField);
                }

                // return value
                return dTNField;
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
                if (this.HasAppController)
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
                    dTNTable = this.AppController.ControllerManager.DTNTableController.Find(tempDTNTable);
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
                if (this.HasAppController)
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
                    enumeration = this.AppController.ControllerManager.EnumerationController.Find(tempEnumeration);
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
                if (this.HasAppController)
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
                    fieldSet = this.AppController.ControllerManager.FieldSetController.Find(tempFieldSet);
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
                if (this.HasAppController)
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
                    fieldSetField = this.AppController.ControllerManager.FieldSetFieldController.Find(tempFieldSetField);
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
                if (this.HasAppController)
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
                    method = this.AppController.ControllerManager.MethodController.Find(tempMethod);
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
                
                // Set the value for Name
                tempMethod.Name = name;
                
                // Perform the find
                method = FindMethod(0, tempMethod);
                
                // return value
                return method;
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
                if (this.HasAppController)
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
                    project = this.AppController.ControllerManager.ProjectController.Find(tempProject);
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
                if (this.HasAppController)
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
                    projectReference = this.AppController.ControllerManager.ProjectReferenceController.Find(tempProjectReference);
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
                if (this.HasAppController)
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
                    referencesSet = this.AppController.ControllerManager.ReferencesSetController.Find(tempReferencesSet);

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
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
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
                this.AppController = new ApplicationController();
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
                    project.Databases = LoadProjectDatabases(project.ProjectId);
                        
                    // Load References For This Project
                    LoadProjectReferencesForProject(ref project);

                    // Load the Enumerations
                    project.Enumerations = LoadEnumerationsForProject(project.ProjectId);
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
                if (this.HasAppController)
                {
                    // perform the load
                    customReaders = this.AppController.ControllerManager.CustomReaderController.FetchAll(tempCustomReader);
                }

                // return value
                return customReaders;
            }
            #endregion

            #region LoadCustomReadersForTable(int tableId)
            /// <summary>
            /// This method returns a list of Custom Readers For Table
            /// </summary>
            public List<CustomReader> LoadCustomReadersForTable(int tableId)
            {
                // initial value
                List<CustomReader> customReaders = null;
                
                // if the tableId is set
                if (tableId > 0)
                {
                    // Create a new instance of a 'CustomReader' object.
                    CustomReader tempCustomReader = new CustomReader();

                    // Set the value for the property 'FetchAllForTable' to true
                    tempCustomReader.FetchAllForTable = true;

                    // Set the TableId
                    tempCustomReader.TableId = tableId;

                    // load the customReaders
                    customReaders = LoadCustomReaders(tempCustomReader);
                }

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
                if (this.HasAppController)
                {
                    // perform the load
                    dTNDatabases = this.AppController.ControllerManager.DTNDatabaseController.FetchAll(tempDTNDatabase);
                }

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
                if (this.HasAppController)
                {
                    // perform the load
                    dTNFields = this.AppController.ControllerManager.DTNFieldController.FetchAll(tempDTNField);                    
                }

                // return value
                return dTNFields;
            }
            #endregion

            #region LoadDTNFieldsForTable(int tableId)
            /// <summary>
            /// This method loads a collection of 'DTNField' objects for the tableId given.
            /// </summary>
            public List<DTNField> LoadDTNFieldsForTable(int tableId)
            {
                // initial value
                List<DTNField> dTNFields = null;

                // Create a new instance of a 'DTNField' object.
                DTNField tempField = new DTNField();

                // Set the value for the property 'FetchAllForTable' to true
                tempField.FetchAllForTable = true;

                // set the ProjectId
                tempField.TableId = tableId;

                // perform the load
                dTNFields = LoadDTNFields(tempField);

                // return value
                return dTNFields;
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
                if (this.HasAppController)
                {
                    // perform the load
                    dTNTables = this.AppController.ControllerManager.DTNTableController.FetchAll(tempDTNTable);
                }

                // return value
                return dTNTables;
            }
            #endregion

            #region LoadDTNTablesForProject(int projectId)
            /// <summary>
            /// method returns the DTN Tables For Project
            /// </summary>
            public List<DTNTable> LoadDTNTablesForProject(int projectId)
            {
                // initial value
                List<DTNTable> tables = null;
                
                // Create a new instance of a 'DTNTable' object.
                DTNTable tempTable = new DTNTable();

                // Set the value for the property 'FetchAllForProjectId' to true
                tempTable.FetchAllForProjectId = true;

                // set hte projectId
                tempTable.ProjectId = projectId;

                // load the tables
                tables = LoadDTNTables(tempTable);
                
                // return value
                return tables;
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
                if (this.HasAppController)
                {
                    // perform the load
                    enumerations = this.AppController.ControllerManager.EnumerationController.FetchAll(tempEnumeration);
                }

                // return value
                return enumerations;
            }
            #endregion

            #region LoadEnumerationsForProject(int projectID)
			/// <summary>
			/// This method loads the enumerations for the projectId passed in.
			/// </summary>
			/// <param name="projectId">The PrimaryKey for the project table. This is used
			/// to find the selected project's enumerations.</param>
			/// <returns></returns>
			public List<Enumeration> LoadEnumerationsForProject(int projectId)
			{
				// initial value
				List<Enumeration> enumerations = new List<Enumeration>();
					
				// Create a temp enumeration
				Enumeration tempEnumeration = new Enumeration();
					
				// set properties on tempEnumeration
				tempEnumeration.ProjectId = projectId;
					
				// Load the enumerations
				enumerations = this.AppController.ControllerManager.EnumerationController.FetchAll(tempEnumeration);
					
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
                if (this.HasAppController)
                {
                    // perform the load
                    fieldSetFields = this.AppController.ControllerManager.FieldSetFieldController.FetchAll(tempFieldSetField);
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
                if (this.HasAppController)
                {
                    // perform the load
                    fieldSetFieldViews = this.AppController.ControllerManager.FieldSetFieldViewController.FetchAll(tempFieldSetFieldView);
                }

                // return value
                return fieldSetFieldViews;
            }
            #endregion

            #region LoadFieldSetFieldViewsByFieldSetId(int fieldSetId)
            /// <summary>
            /// This method is used to load 'FieldSetFieldView' objects for the FieldSetId given.
            /// </summary>
            public List<FieldSetFieldView> LoadFieldSetFieldViewsByFieldSetId(int fieldSetId)
            {
                // initial value
                List<FieldSetFieldView> fieldSetFieldViews = null;
                
                // Create a temp FieldSetFieldView object
                FieldSetFieldView tempFieldSetFieldView = new FieldSetFieldView();
                
                // Set the value for LoadByFieldSetId to true
                tempFieldSetFieldView.LoadByFieldSetId = true;
                
                // Set the value for FieldSetId
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
                if (this.HasAppController)
                {
                    // perform the load
                    fieldSets = this.AppController.ControllerManager.FieldSetController.FetchAll(tempFieldSet);
                }

                // return value
                return fieldSets;
            }
            #endregion

            #region LoadFieldSetsForTable(int tableId, bool onlyInParameterMode = false)
            /// <summary>
            /// This method loads a collection of 'FieldSet' objects for the tableId given.
            /// </summary>
            public List<FieldSet> LoadFieldSetsForTable(int tableId, bool onlyInParameterMode = false)
            {
                // initial value
                List<FieldSet> fieldSets = null;

                // If the value for tableId is greater than zero
                if (tableId > 0)
                {
                    // Create a new instance of a 'FieldSet' object.
                    FieldSet tempFieldSet = new FieldSet();

                    // Set the value for the property 'FetchAllForTable' to true
                    tempFieldSet.FetchAllForTable = true;

                    // Set the value for TableId
                    tempFieldSet.TableId = tableId;

                    // if the value for onlyInParameterMode is true
                    if (onlyInParameterMode)
                    {
                        // Set the value for the property 'ParameterMode' to true.
                        // This will change the procedure name to FieldSet_FetchAllInParameterModeForTable 
                        tempFieldSet.ParameterMode = true;
                    }

                    // load the fieldSets
                    fieldSets = LoadFieldSets(tempFieldSet);
                }

                // return value
                return fieldSets;
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
                if (this.HasAppController)
                {
                    // perform the load
                    methods = this.AppController.ControllerManager.MethodController.FetchAll(tempMethod);
                }

                // return value
                return methods;
            }
            #endregion

            #region LoadMethodsByProjectId(int projectId)
            /// <summary>
            /// This method is used to load 'Method' objects for the ProjectId given.
            /// </summary>
            public List<Method> LoadMethodsByProjectId(int projectId)
            {
                // initial value
                List<Method> methods = null;
                
                // Create a temp Method object
                Method tempMethod = new Method();
                
                // Set the value for LoadByProjectId to true
                tempMethod.LoadByProjectId = true;
                
                // Set the value for ProjectId
                tempMethod.ProjectId = projectId;
                
                // Perform the load
                methods = LoadMethods(tempMethod);
                
                // return value
                return methods;
            }
            #endregion
            
            #region LoadMethodsForTable(int tableId)
            /// <summary>
            /// This method loads a collection of 'Method' objects.
            /// </summary>
            public List<Method> LoadMethodsForTable(int tableId)
            {
                // initial value
                List<Method> methods = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // Create a new instance of a 'Method' object.
                    Method tempMethod = new Method();

                    // Set the value for the property 'FetchAllForTable' to true
                    tempMethod.FetchAllForTable = true;

                    // Set the value for the property 'TableId'
                    tempMethod.TableId = tableId;

                    // Load the methods
                    methods = LoadMethods(tempMethod);
                }

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
                if (this.HasAppController)
                {
                    // perform the load
                    projectReferences = this.AppController.ControllerManager.ProjectReferenceController.FetchAll(tempProjectReference);
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
                // if the project exists
                if(project != null)
                {
                    // Load ReferencesSets
                    project.ControllerReferencesSet = FindReferencesSet(project.ControllerReferencesSetId);
                    project.DataManagerReferencesSet = FindReferencesSet(project.DataManagerReferencesSetId);
                    project.DataOperationsReferencesSet = FindReferencesSet(project.DataOperationsReferencesSetId);
                    project.ObjectReferencesSet = FindReferencesSet(project.ObjectReferencesSetId);
                    project.ReaderReferencesSet = FindReferencesSet(project.ReaderReferencesSetId);
                    project.StoredProcedureReferencesSet = FindReferencesSet(project.StoredProcedureReferencesSetId);
                    project.WriterReferencesSet = FindReferencesSet(project.DataWriterReferencesSetId);

                    // Instanciate AllReferences
                    project.AllReferences = new List<ReferencesSet>();
                        
                    // Add each ReferencesSet to project.AllReferences; 

                    // This fixes a bug that a project that was opened
                    // does not populate the ReferencesSet combo boxes.
                    project.AllReferences.Add(project.ControllerReferencesSet);
                    project.AllReferences.Add(project.DataManagerReferencesSet);
                    project.AllReferences.Add(project.DataOperationsReferencesSet);
                    project.AllReferences.Add(project.ObjectReferencesSet);
                    project.AllReferences.Add(project.ReaderReferencesSet);
                    project.AllReferences.Add(project.StoredProcedureReferencesSet);
                    project.AllReferences.Add(project.WriterReferencesSet);
                }
            }
            #endregion

            #region LoadProjectReferencesForReferencesSetId(int referencesSetId)
            /// <summary>
            /// This method loads the references for a referencesSetId
            /// </summary>
            /// <param name="referencesSetId"></param>
            /// <returns></returns>
            internal List<ProjectReference> LoadProjectReferencesForReferencesSetId(int referencesSetId)
            {
                // Create clonedReference
                ProjectReference tempReference = new ProjectReference();
                    
                // set referencesSetID
                tempReference.ReferencesSetId = referencesSetId;

                // Create AppController
                ApplicationController appController = new ApplicationController();

                // fetch all references for this ReferencesSetID
                List<ProjectReference> references = appController.ControllerManager.ProjectReferenceController.FetchAll(tempReference);
                    
                // return value
                return references;
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
                if (this.HasAppController)
                {
                    // perform the load
                    projects = this.AppController.ControllerManager.ProjectController.FetchAll(tempProject);
                }

                // return value
                return projects;
            }
            #endregion

            #region LoadProjectDatabases(int projectId)
            /// <summaryprojectId
            /// Load project references
            /// </summary>
            /// <param name="projectId"></param>
            /// <returns></returns>
            public List<DTNDatabase> LoadProjectDatabases(int projectId)
            {
                // Create Temp Database
                DTNDatabase tempDatabase = new DTNDatabase();
                    
                // set projectID
                tempDatabase.ProjectId = projectId;

                // Create AppController
                ApplicationController appController = new ApplicationController();

                // Fetch All Databases For Project
                    
                // Fetch All Databases for this project
                List<DTNDatabase> databases = appController.ControllerManager.DTNDatabaseController.FetchAll(tempDatabase);
                    
                // return value
                return databases;
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
                if (this.HasAppController)
                {
                    // perform the load
                    referencesSets = this.AppController.ControllerManager.ReferencesSetController.FetchAll(tempReferencesSet);
                }

                // return value
                return referencesSets;
            }
            #endregion

            #region Save(ref ReferencesSet referencesSet, bool saveChildren)
            /// <summary>
            /// This method saves a ReferencesSet
            /// </summary>
            /// <param name="referencesSet"></param>
            /// <returns></returns>
            public bool Save(ref ReferencesSet referencesSet, bool saveChildren)
            {
                // initial value
                bool saved = false;
                    
                // if referencesSet exists
                if (referencesSet != null)
                {
                    // Create AppController
                    ApplicationController appController = new ApplicationController();

                    // save the database
                    saved = appController.ControllerManager.ReferencesSetController.Save(ref referencesSet);
                        
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
                            saved = Save(ref references);
                        }
                    }
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.CustomReaderController.Save(ref customReader);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.DTNDatabaseController.Save(ref dTNDatabase);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.DTNFieldController.Save(ref dTNField);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.DTNTableController.Save(ref dTNTable);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.EnumerationController.Save(ref enumeration);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.FieldSetController.Save(ref fieldSet);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.FieldSetFieldController.Save(ref fieldSetField);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.MethodController.Save(ref method);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.ProjectController.Save(ref project);
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.ProjectReferenceController.Save(ref projectReference);
                }

                // return value
                return saved;
            }
            #endregion

            #region Save(ref List<ProjectReference> references)
            /// <summary>
            /// This method saves a list of ProjectReference objects.
            /// </summary>
            /// <param name="references"></param>
            /// <returns></returns>
            public bool Save(ref List<ProjectReference> references)
            {
                // initial value
                bool saved = false;

                // local
                bool tempSaved = true;

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
                if(project != null)
                {
                    // if project.ControllerReferencesSet exists
                    if(project.ControllerReferencesSet != null)
                    {
                        // Create AppController
                        ApplicationController appController = new ApplicationController();

                        // save child references set
                        controllerReferencesSetSaved = Save(ref project.controllerReferencesSet, true);
                        dataManagerReferencesSetSaved = Save(ref project.dataManagerReferencesSet, true);
                        dataOperationsReferencesSetSaved = Save(ref project.dataOperationsReferencesSet, true);
                        objectReferencesSetSaved = Save(ref project.objectReferencesSet, true);
                        readerReferencesSetSaved = Save(ref project.readerReferencesSet, true);
                        storedProcedureReferencesSetSaved = Save(ref project.storedProcedureReferencesSet, true);
                        writerReferencesSetSaved = Save(ref project.writerReferencesSet, true);
                            
                        // if all saves succeeded
                        if ((controllerReferencesSetSaved) && (dataManagerReferencesSetSaved) && (dataOperationsReferencesSetSaved) && (objectReferencesSetSaved) && (readerReferencesSetSaved) && (storedProcedureReferencesSetSaved) && (writerReferencesSetSaved))
                        {
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
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.ReferencesSetController.Save(ref referencesSet);
                }

                // return value
                return saved;
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

        #endregion

    }
    #endregion

}


