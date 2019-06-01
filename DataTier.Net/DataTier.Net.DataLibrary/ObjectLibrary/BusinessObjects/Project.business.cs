

#region using statements

using System;
using System.Collections.Generic;
using ObjectLibrary.Enumerations;
using System.Text;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Project
    /// <summary>
    /// This class represents a project.
    /// </summary>
    [Serializable]
    public partial class Project
    {

        #region Private Variables
        public List<ReferencesSet> allReferences;
        public List<DTNDatabase> databases;
        public ReferencesSet objectReferencesSet;
        public ReferencesSet dataManagerReferencesSet;
        public ReferencesSet dataOperationsReferencesSet;
        public ReferencesSet controllerReferencesSet;
        public ReferencesSet readerReferencesSet;
        public ReferencesSet writerReferencesSet;
        public ReferencesSet storedProcedureReferencesSet;
		private List<Enumeration> enumerations;
        private List<DTNTable> tables;
        #endregion

        #region Constructor
        public Project()
        {
            // Perform Initializations
            Init();
        }
        #endregion

        #region Methods

            #region AppendToProjectFolder()
            /// <summary>
            /// This method appends the string to the ProjectFolder
            /// to the return the default path for a child folder.
            /// </summary>
            /// <returns></returns>
            public string AppendToProjectFolder(string folderName)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(this.ProjectFolder);
                
                // if it does not end with a back slash add it now
                if(!this.ProjectFolder.EndsWith(@"\"))
                {
                    // Append the backslash
                    sb.Append(@"\");
                }
                
                // Append the folder name
                sb.Append(folderName);
                
                // get the new string 
                // for debugging only, could return sb.ToString();
                string returnString = sb.ToString();
                
                // return value
                return returnString;
            } 
            #endregion

            #region AutoFillChildFolders()
            /// <summary>
            /// This method takes the ProjectFolder and autofills 
            /// values for the child folders based upon the 
            /// template structure.
            /// </summary>
            public void AutoFillChildFolders()
            {
                // If the project folder exists
                if(!String.IsNullOrEmpty(this.ProjectFolder))
                {
                    // Set the values now
                    
                    // Set the ObjectFolder (Also known as the Data Object Folder).
                    this.ObjectFolder = this.AppendToProjectFolder(@"ObjectLibrary\BusinessObjects");
                    
                    // Set the Data Manager Folder.
                    this.DataManagerFolder = this.AppendToProjectFolder(@"DataAccessComponent\DataManager");
                    
                    // Set the Data Operations Folder
                    this.DataOperationsFolder = this.AppendToProjectFolder(@"ApplicationLogicComponent\DataOperations");
                    
                    // Set the Controllers Folder
                    this.ControllerFolder = this.AppendToProjectFolder(@"ApplicationLogicComponent\Controllers");
                    
                    // Set the Reader Folder
                    this.ReaderFolder = this.AppendToProjectFolder(@"DataAccessComponent\DataManager\Readers");
                    
                    // Set the Writers Folder
                    this.DataWriterFolder = this.AppendToProjectFolder(@"DataAccessComponent\DataManager\Writers");
                    
                    // Set the StoredProcedureFolder
                    this.StoredProcedureObjectFolder = this.AppendToProjectFolder(@"DataAccessComponent\StoredProcedureManager");

                    // Create the StoredProcsFolder (Only shown for SQL Server) 
                    this.StoredProcsFolder = this.AppendToProjectFolder(@"DataAccessComponent\StoredProcedureManager\StoredProcedureSQL");
                }
            } 
            #endregion

            #region CreateDefaultReferences()
            /// <summary>
            /// This method creates the default references.
            /// </summary>
            private void CreateDefaultReferences()
            {
                // Set ObjectNamespace
                this.ObjectNamespace = "ObjectLibrary.BusinessObjects";
            
                // Create ObjectReferencesSet
                this.ObjectReferencesSet = new ReferencesSet("DataObjects");

                // Create Object References
                this.ObjectReferencesSet.References.Add(new ProjectReference("System"));
                
                // Add this references set to All Refrences
                this.AllReferences.Add(this.ObjectReferencesSet);

                // Set DataManagerNamespace
                this.DataManagerNamespace = "DataAccessComponent.DataManager";
                
                // Create DataManagerReferencesSet
                this.DataManagerReferencesSet = new ReferencesSet("DataManager");
                
                // Create DataManager References
                this.DataManagerReferencesSet.References.Add(new ProjectReference("System"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("System.Data"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                this.DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataManager.Readers"));
                this.AllReferences.Add(this.DataManagerReferencesSet);

                // Set DataOperationNamespace
                this.DataOperationsNamespace = "ApplicationLogicComponent.DataOperations";
                
                // Create DataOperationsReferencesSet
                this.DataOperationsReferencesSet = new ReferencesSet("DataOperations");
                
                // Create DataOperation References
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("System"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataManager.Writers"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataManager"));
                this.DataOperationsReferencesSet.References.Add(new ProjectReference("ApplicationLogicComponent.DataBridge"));
                this.AllReferences.Add(this.DataOperationsReferencesSet);

                // Set Controller Namespace
                this.ControllerNamespace = "ApplicationLogicComponent.Controllers";
                
                // Create ControllerReferencesSet
                this.ControllerReferencesSet = new ReferencesSet("Controllers");
                
                // Create Controller References
                this.ControllerReferencesSet.References.Add(new ProjectReference("System"));
                this.ControllerReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                this.ControllerReferencesSet.References.Add(new ProjectReference("ApplicationLogicComponent.Logging"));
                this.ControllerReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                this.ControllerReferencesSet.References.Add(new ProjectReference("ApplicationLogicComponent.DataOperations"));
                this.ControllerReferencesSet.References.Add(new ProjectReference("ApplicationLogicComponent.DataBridge"));
                this.AllReferences.Add(this.ControllerReferencesSet);

                // Set ReaderNamespace
                this.ReaderNamespace = "DataAccessComponent.DataManager.Readers";
                
                // Add Reader References
                this.ReaderReferencesSet = new ReferencesSet("Readers");
                
                // Set Reader References
                this.ReaderReferencesSet.References.Add(new ProjectReference("System"));
                this.ReaderReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                this.ReaderReferencesSet.References.Add(new ProjectReference("System.Data"));
                this.ReaderReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                this.AllReferences.Add(this.ReaderReferencesSet);

                // Set Writer Namespace
                this.DataWriterNamespace = "DataAccessComponent.DataManager.Writers";
                
                // Add Writer References
                this.WriterReferencesSet = new ReferencesSet("Writers");
                
                // Set Writer References
                this.WriterReferencesSet.References.Add(new ProjectReference("System"));
                this.WriterReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                this.WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                this.WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                this.WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                this.WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                this.WriterReferencesSet.References.Add(new ProjectReference("System.Data"));
                this.WriterReferencesSet.References.Add(new ProjectReference("System.Data.SqlClient"));
                this.AllReferences.Add(this.WriterReferencesSet);

                // Set StoredProcedure Namespace
                this.StoredProcedureObjectNamespace = "DataAccessComponent.StoredProcedureManager";
                
                // Stored Procedure References
                this.StoredProcedureReferencesSet = new ReferencesSet("StoredProcedures");
                
                // Set Stored Procedure References
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("System"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                this.AllReferences.Add(this.StoredProcedureReferencesSet);
            }
            #endregion

            #region GetDatabaseIndex(int databaseId)
            /// <summary>
            /// This method returns the Database Index
            /// </summary>
            public int GetDatabaseIndex(int databaseId)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the Databases object exists
                if (this.HasDatabases)
                {
                    // Iterate the collection of DTNDatabase objects
                    foreach (DTNDatabase database in Databases)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this is the item being sought
                        if (database.DatabaseId == databaseId)
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of this loop
                            break;
                        }
                    }
                }
                
                // return value
                return index;
            }
            #endregion
            
            #region GetReferencesSetIndex(int referencesSetId)
            /// <summary>
            /// This method returns the References Set Index
            /// </summary>
            public int GetReferencesSetIndex(int referencesSetId)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // if the AllReferences exist
                if (this.AllReferences != null)
                {
                    // Iterate the collection of ReferencesSet objects
                    foreach (ReferencesSet referencesSet in AllReferences)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this is the item being sought
                        if (referencesSet.ReferencesSetId == referencesSetId)
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return index;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// Perform Initializations
            /// </summary>
            public void Init()
            {
                // Set ClassFileOption
                this.ClassFileOption = (int) FileOptionsEnum.SeperateFilesPerTable;
            
                // Create Databases Collection
                this.Databases = new List<DTNDatabase>();
                
                // Create AllReferences
                this.AllReferences = new List<ReferencesSet>();
                
                // Create Enumerations
                this.Enumerations = new List<Enumeration>();

                // Create the Tables collection
                this.Tables = new List<DTNTable>();
                
                // Create Default References
                this.CreateDefaultReferences();
            }
            #endregion

            #region SetProjectIdOnDatabases(int projectId)
            /// <summary>
            /// This method Set Project ID On Databases
            /// </summary>
            public void SetProjectIdOnDatabases(int projectId)
            {
                // If the Databases object exists
                if (this.HasDatabases)
                {
                    // Iterate the collection of ReferencesSet objects
                    foreach (DTNDatabase database in Databases)
                    {
                        // set the projectId
                        database.ProjectId = projectId;
                    }
                }
            }
            #endregion
            
            #region SetProjectIdOnReferences(int projectId)
            /// <summary>
            /// This method Sets the ProjectId On References
            /// </summary>
            public void SetProjectIdOnReferences(int projectId)
            {
                // If the AllReferences object exists
                if (this.HasAllReferences)
                {
                    // Iterate the collection of ReferencesSet objects
                    foreach (ReferencesSet referencesSet in AllReferences)
                    {
                        // set the projectId
                        referencesSet.ProjectId = projectId;
                    }
                }
            }
            #endregion
            
            #region ToString()
            /// <summary>
            /// This method returns the project name 
            /// when ToString is called. 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // initial value
                string projectName = "";
                
                // if the ProjectName exists
                if(this.ProjectName != null)
                {
                    // set projectName
                    projectName = this.ProjectName;
                }
                
                // return the project name
                return projectName;
            }
            #endregion
        
        #endregion

        #region Properties

            #region AllReferences
            /// <summary>
            /// A collection of all ReferencesSets in the database.
            /// </summary>
            public List<ReferencesSet> AllReferences
            {
                get { return allReferences; }
                set { allReferences = value; }
            }
            #endregion

            #region ControllerReferencesSet
            /// <summary>
            /// The controller references set.
            /// </summary>
            public ReferencesSet ControllerReferencesSet
            {
                get { return controllerReferencesSet; }
                set { controllerReferencesSet = value; }
            } 
            #endregion

            #region Databases
            /// <summary>
            /// The databases for this project.
            /// </summary>
            public List<DTNDatabase> Databases
            {
                get { return databases; }
                set { databases = value; }
            }
            #endregion

            #region DataManagerReferencesSet
            /// <summary>
            /// The ReferencesSet For DataManager.
            /// </summary>
            public ReferencesSet DataManagerReferencesSet
            {
                get { return dataManagerReferencesSet; }
                set { dataManagerReferencesSet = value; }
            }
            #endregion

            #region DataOperationsReferencesSet
            /// <summary>
            /// The references set for DataOperations.
            /// </summary>
            public ReferencesSet DataOperationsReferencesSet
            {
                get { return dataOperationsReferencesSet; }
                set { dataOperationsReferencesSet = value; }
            }
            #endregion

			#region Enumerations
			/// <summary>
			/// A collection of enumerations for this project.
			/// </summary>
			public List<Enumeration> Enumerations
			{
				get { return enumerations; }
				set { enumerations = value; }
			}
            #endregion

            #region HasDatabases
            /// <summary>
            /// This property returns true if this object has a 'Databases'.
            /// </summary>
            public bool HasDatabases
            {
                get
                {
                    // initial value
                    bool hasDatabases = (this.Databases != null);
                    
                    // return value
                    return hasDatabases;
                }
            }
            #endregion

            #region HasAllReferences
            /// <summary>
            /// This property returns true if this object has an 'AllReferences'.
            /// </summary>
            public bool HasAllReferences
            {
                get
                {
                    // initial value
                    bool hasAllReferences = (this.AllReferences != null);
                    
                    // return value
                    return hasAllReferences;
                }
            }
            #endregion

            #region HasTables
            /// <summary>
            /// This property returns true if this object has a 'Tables'.
            /// </summary>
            public bool HasTables
            {
                get
                {
                    // initial value
                    bool hasTables = (this.Tables != null);
                    
                    // return value
                    return hasTables;
                }
            }
            #endregion
            
            #region ObjectReferencesSet
            /// <summary>
            /// The object references set.
            /// </summary>
            public ReferencesSet ObjectReferencesSet
            {
                get { return objectReferencesSet; }
                set { objectReferencesSet = value; }
            }
            #endregion

            #region ReaderReferencesSet
            /// <summary>
            /// The ReaderReferencesSet
            /// </summary>
            public ReferencesSet ReaderReferencesSet
            {
                get { return readerReferencesSet; }
                set { readerReferencesSet = value; }
            }
            #endregion

            #region StoredProcedureReferencesSet
            /// <summary>
            /// this property is the ReferencesSets for a StoredProcedure.
            /// </summary>
            public ReferencesSet StoredProcedureReferencesSet
            {
                get { return storedProcedureReferencesSet; }
                set { storedProcedureReferencesSet = value; }
            } 
            #endregion

            #region Tables
            /// <summary>
            /// This property gets or sets the value for 'Tables'.
            /// </summary>
            public List<DTNTable> Tables
            {
                get { return tables; }
                set { tables = value; }
            }
            #endregion

            #region WriterReferencesSet
            /// <summary>
            /// The Writer ReferencesSet
            /// </summary>
            public ReferencesSet WriterReferencesSet
            {
                get { return writerReferencesSet; }
                set { writerReferencesSet = value; }
            }
            #endregion
        
        #endregion
       
    }
    #endregion

}