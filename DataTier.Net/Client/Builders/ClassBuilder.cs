

#region using statements

using DataGateway;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using DataJuggler.Net;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using DataTierClient.ClientUtil;
using DataJuggler.Net.Enumerations;

#endregion

namespace DataTierClient.Builders
{
    public class ClassBuilder
    {
    
        #region Private Variables

            #region Constants
            #endregion

            #region Variables
            // variables
            private Project currentProject;
            private DataJuggler.Net.DataManager dm;
            private bool businessObjectPass;
			#endregion 
            
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of the ClassBuilder.
        /// </summary>
        /// <param name="businessObjectPassArg"></param>
        /// <param name="license"></param>
        public ClassBuilder(bool businessObjectPassArg)
        {
            // Set Property For BusinessObjectPass
            this.BusinessObjectPass = businessObjectPassArg;
        }
        #endregion
        
        #region Methods

            #region AddDatabases(ref Project currentProject)
            /// <summary>
            /// This method adds all the databases in the current project
            /// to the DataManager (DM).
            /// </summary>
            /// <param name="currentProject"></param>
            public void AddDatabases(ref Project currentProject)
            {
                // Make sure the CurrentProject is set; I think this changed and now the CurrentProject
                // is created earlier. 
                if ((CurrentProject == null) || (!CurrentProject.Equals(currentProject)))
                {
                    // this has to be set before the DataManager can be created
                    this.CurrentProject = currentProject;
                }

                // locals
                Database database = null;
                List<Enumeration> enumerations = null;
                List<DTNDatabase> databases = null;

                // If the currentProject object exists
                if (NullHelper.Exists(currentProject))
                {
                    // set the databases
                    databases = currentProject.Databases;

                    // if the current project has enumerations
                    if (ListHelper.HasOneOrMoreItems(currentProject.Enumerations))
                    {
                        // get a list of enumerations
                        enumerations = new List<Enumeration>();
                    
                        // if the enumrations exist
                        foreach (Enumeration enumeration in currentProject.Enumerations)
                        {
                            // add thsi enumerations
                            enumerations.Add(enumeration);
                        }
                    }
                }
                
                // if databases exists
                if ((ListHelper.HasOneOrMoreItems(databases)) && (DataManager != null))
                {
                    // loop through each database
                    foreach(DTNDatabase db in databases)
                    {  
                        // convert to DataJuggler.Net.Sql database
                        database = ConvertSQLDatabase(db, enumerations);
                        
                        // if the database exists
                        if(database != null)
                        {
                            // If the database has Serializable selected
                            if(db.Serializable)
                            {
                                // Serialize each table
                                foreach(DataTable table in database.Tables)
                                {
                                    // Set serializable on the table
                                    table.Serializable = true;
                                }
                            }

                            // if there are one or more tables in the current Project
                            if (ListHelper.HasOneOrMoreItems(CurrentProject.Tables))
                            {
                                // iterate the tables
                                foreach (DTNTable table in CurrentProject.Tables)
                                {
                                    // attempt to find this table in this database
                                    DataTable dataTable = database.Tables.FirstOrDefault(x => x.Name == table.TableName);

                                    // If the dataTable object exists
                                    if (NullHelper.Exists(dataTable))
                                    {
                                        // Store the tableId in dataTable so a save performs an update and not a duplicate insert
                                        dataTable.TableId = table.TableId;

                                        // Set the value for Exclude in the dataTable
                                        dataTable.Exclude = table.Exclude;
                                        dataTable.CreateBindingCallback = table.CreateBindingCallback;

                                        // if this table has one or more fields
                                        if (ListHelper.HasOneOrMoreItems(table.Fields))
                                        {
                                            // iterate the fields
                                            foreach (DTNField field in table.Fields)
                                            {
                                                // We now must find the field in this DataTable
                                                DataField dataField = dataTable.Fields.FirstOrDefault(x => x.FieldName == field.FieldName);

                                                // If the dataField object exists
                                                if (NullHelper.Exists(dataField))
                                                {
                                                    // Store the FieldId, which is not really mapped, but when the field is converted
                                                    // back to a DTNField, this FieldId is converted if present.
                                                    dataField.FieldId = field.FieldId;

                                                    // set Exclude
                                                    dataField.Exclude = field.Exclude;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                                                    
                            // Add this database
                            this.DataManager.Databases.Add(database);            
                        }
                    } 

                    // now we must recreate the currentProject.Tables to match the database
                    if ((DataManager != null) && (DataManager.Databases != null) && (DataManager.Databases.Count > 0) && (DataManager.Databases[0].Tables.Count > 0))
                    {
                        // create the currentTables
                        List<DTNTable> currentTables = new List<DTNTable>();                        

                        // iterate the databases
                        foreach (Database db in DataManager.Databases)
                        {  
                            // attempt to find the database
                            DTNDatabase dtnDatabase = currentProject.Databases.FirstOrDefault(x => x.DatabaseName == db.Name);

                            // If the dtnDatabase object exists
                            if (NullHelper.Exists(dtnDatabase))
                            {
                                // iterate the tables
                                foreach (DataTable table in db.Tables)
                                {  
                                    // create the table
                                    DTNTable dtnTable = DataConverter.ConvertDataTable(table, currentProject, dtnDatabase);

                                    // We must check if we have an existing table already with this name that is excluded
                                    DTNTable existingTable = CurrentProject.Tables.FirstOrDefault(x => x.TableName == table.Name);

                                    // if the table exists
                                    if (NullHelper.Exists(dtnTable))
                                    {
                                        // if the existingTable was found
                                        if (NullHelper.Exists(existingTable))
                                        {
                                            // Update the value for exclude
                                            dtnTable.Exclude = existingTable.Exclude;
                                            dtnTable.CreateBindingCallback = existingTable.CreateBindingCallback;
                                        }
                                            
                                        // Add this table
                                        currentTables.Add(dtnTable);
                                    }
                                }
                            }
                        }

                        // Now set the CurrentProject.Tables back
                        currentProject.Tables = currentTables;
                    }
                }                
            }
            #endregion

            #region BuildClasses(Project currentProject, ProjectFileManager fileManager, bool writeClasses) 
            /// <summary>
            /// This method builds the classes for the current project.
            /// If Write Classes is false the database schema will be 
            /// loaded the classes will not be built.
            /// </summary>
            /// <param name="currentProject"></param>
            /// <param name="fileManager"></param>
            /// <param name="writeClasses"></param>
            /// <returns></returns>
            public bool BuildClasses(Project currentProject, ProjectFileManager fileManager, bool writeClasses) 
            {
                // initial value
                bool success = false;

                // Create DataManager
                this.Setup(currentProject);

                // This can not be .NET Framework, .NET5, .NET6 or .NET7.
                TargetFrameworkEnum targetFramework = (TargetFrameworkEnum) currentProject.TargetFramework;
               
                // Create New ClassWriter Object
                CSharpClassWriter classWriter = new CSharpClassWriter(fileManager, BusinessObjectPass, false, targetFramework);

                // Add Databases
                AddDatabases(ref currentProject);

                // if write classes
                if(writeClasses)
                {
                    // Write DataManager
                    success = classWriter.WriteDataClasses(DataManager);
                }
                else
                {
                    // set success to true
                    success = true;
                }
                
                // return value
                return success;
            }
            #endregion

            #region ConvertSQLDatabase(Databases db, List<Enumeration> enumerations)
            /// <summary>
            /// Converts a ObjectLibrary.Database 
            /// SQLServer database to a DataJuggler.Net Database 
            /// and reads the schema.
            /// </summary>
            /// <param name="databases"></param>
            /// <returns></returns>
            private Database ConvertSQLDatabase(DTNDatabase db, List<Enumeration> enumerations)
            {
                // Create sqlConnector
                SQLDatabaseConnector sqlConnector = new SQLDatabaseConnector();

                // if the tables are not loaded for the db
                if ((NullHelper.Exists(db)) && (!ListHelper.HasOneOrMoreItems(db.Tables)))
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // load the tables
                    db.Tables = gateway.LoadDTNTablesByProjectId(this.CurrentProject.ProjectId);
                }

                // if the DataManager does not exist
                if (NullHelper.IsNull(DataManager))
                {
                    if (NullHelper.Exists(CurrentProject))
                    {
                        // Don't know why this is still here, VB.Net was abandoned in 2006 or 2007
                        DataManager = new DataManager(CurrentProject.ProjectFolder, currentProject.ProjectName, DataManager.ClassOutputLanguage.CSharp);
                    }
                    else
                    {
                        // exit
                        return null;
                    }
                }

                // Create Database
                DataJuggler.Net.Database database = new Database(this.DataManager);

                // Set Database Properties
                database.ClassFileName = this.DataManager.ClassFileName;
                database.ClassName = db.DatabaseName + ".cs";
                database.ConnectionString = db.ConnectionString;
                database.Name = db.DatabaseName;
                database.ParentDataManager = this.DataManager;
                database.Password = db.DBPassword;
                database.Serializable = true;
                database.StoredProcedures = new List<StoredProcedure>();
                
                // set connection string
                sqlConnector.DatabaseConnection.ConnectionString = database.ConnectionString;

                // open database
                sqlConnector.DatabaseConnection.Open();

                // read database schema
                database = sqlConnector.LoadDatabaseSchema(database);

                // close this database
                sqlConnector.DatabaseConnection.Close();

                // if there are one or more tables
                if (ListHelper.HasOneOrMoreItems(database.Tables)) 
                {
                    // iterate the collection of tables                    
                    foreach (DataTable table in database.Tables)
                    {
                        // disable this for now
                        table.CreateBindingCallback = false;

                        // if there are one or more fields
                        if (ListHelper.HasOneOrMoreItems(table.Fields, enumerations))
                        {
                            // iterate the fields
                            foreach (DataField field in table.Fields)
                            {
                                // now iterate te enumerations                
                                foreach (Enumeration enumeration in enumerations)
                                {
                                    // if this field is designated as an enumeration
                                    if (TextHelper.IsEqual(field.FieldName, enumeration.FieldName))
                                    {
                                        // set to true
                                        field.IsEnumeration = true;

                                        // Set this as enumeration
                                        field.DataType = DataManager.DataTypeEnum.Enumeration;

                                        // Set the EnumerationName
                                        field.EnumDataTypeName = enumeration.EnumerationName;
                                    }
                                }
                            }
                        }
                    }
                }
                
                // return value
                return database;
            } 
            #endregion

            #region ReferencesSet ConvertReferences(List<ProjectReference> refCol, string referencesSetName)
            public DataJuggler.Net.ReferencesSet ConvertReferences(List<ProjectReference> refCol, string referencesSetName)
            {
                // Create New ReferencesSet
                DataJuggler.Net.ReferencesSet refSet = new DataJuggler.Net.ReferencesSet(referencesSetName);

                // Add Each References
                foreach (ProjectReference refObject in refCol)
                {
                    // Create New Reference
                    Reference component = new Reference(refObject.ReferenceName, refObject.ReferencesId);

                    // add this reference to the referencesSet
                    refSet.Add(component);
                }

                // Return RefSet
                return refSet;
            }
            #endregion

            #region GetClassName(DataTable table)
            /// <summary>
            /// Get the class name for a table
            /// </summary>
            /// <returns></returns>
            public string GetClassName(DataTable table)
            {

                // initial values
                StringBuilder sb = new StringBuilder();
                string appentText = "DataObject";

                // if table exists
                if ((table != null) && (!String.IsNullOrEmpty(table.Name)))
                {
                    // append table name
                    sb.Append(table.Name);
                }

                // if this is the business object pass
                if (BusinessObjectPass)
                {
                    // set appendText to business object
                    appentText = "BusinessObject";
                }

                // append 
                sb.Append(appentText);

                // return value
                return sb.ToString();
            }
            #endregion

            #region Setup(Project currentProjectArg)
            /// <summary>
            /// This method performs any initializations needed for this object.
            /// </summary>
            private DataManager Setup(Project currentProjectArg)
            {
                // Initial value
                DataManager dm = null;
                
                // Set current project
                this.CurrentProject = currentProjectArg;
                
                // if the current project exists
                if(this.CurrentProject != null)
                {
                    // Create DataManager
                    this.DataManager = new DataManager(this.CurrentProject.ObjectFolder, this.CurrentProject.ProjectName, DataManager.ClassOutputLanguage.CSharp);
                    
                    // Set NameSpaceName
                    this.DataManager.NamespaceName = this.CurrentProject.ObjectNamespace;

                    // Create References
                    this.DataManager.References = ConvertReferences(this.CurrentProject.ObjectReferencesSet.References, "Objects");
                    
                    // set DM
                    dm = this.DataManager;
                }
                
                // Return value
                return dm;
            }
            #endregion
    
        #endregion
        
        #region Properties
        
            #region BusinessObjectPass
            /// <summary>
            /// Is this the pass for the DataObjects
            /// or the BusinessObjects tier.
            /// </summary>
            public bool BusinessObjectPass
            {
                get { return businessObjectPass; }
                set { businessObjectPass = value; }
            }
            
            #endregion
            
            #region CurrentProject
            /// <summary>
            /// The current project classes are created for.
            /// </summary>
            public Project CurrentProject
            {
                get { return currentProject; }
                set { currentProject = value; }
            }  
            #endregion

            #region DataManager
            public DataJuggler.Net.DataManager DataManager
            {
                get { return dm; }
                set { dm = value; }
            } 
            #endregion
    
            #region ProjectOutputFolder
            public string ProjectOutputFolder
            {
                get
                {
                    // initial value
                    string projectOutputFolder = "";
                    
                    // set project output folder
                    if(this.CurrentProject != null)
                    {
                        // set project folder
                        projectOutputFolder = this.CurrentProject.ProjectFolder;
                    }
                    
                    // return value
                    return projectOutputFolder;
                }
            }
            #endregion
        
        #endregion
    
    }
}
