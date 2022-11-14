
#region using statements

using System;
using System.Collections.Generic;
using ObjectLibrary.Enumerations;
using System.Text;
using DataJuggler.Net.Enumerations;

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
            /// This method creates the default references. Comment so this shows up in changes.
            /// </summary>
            public void CreateDefaultReferences()
            {
                // Set ObjectNamespace
                this.ObjectNamespace = "ObjectLibrary.BusinessObjects";
            
                // Create ObjectReferencesSet
                this.ObjectReferencesSet = new ReferencesSet("DataObjects");

                // Create Object References
                this.ObjectReferencesSet.References.Add(new ProjectReference("System"));
                this.ObjectReferencesSet.References.Add(new ProjectReference("ObjectLibrary.Enumerations"));
                
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
                this.ReaderReferencesSet.References.Add(new ProjectReference("ObjectLibrary.Enumerations"));
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
                
                // if .NET6 or .NET7
                if ((TargetFramework == TargetFrameworkEnum.Net6) || (TargetFramework == TargetFrameworkEnum.Net7))
                {
                    // Switch to Microsoft
                    this.WriterReferencesSet.References.Add(new ProjectReference("Microsoft.Data.SqlClient"));
                }
                else
                {
                    // I think .NET5 and .NETFramework both need this. Will answer this question soon.
                    this.WriterReferencesSet.References.Add(new ProjectReference("System.Data.SqlClient"));  
                }
                
                // Add this references set
                this.AllReferences.Add(this.WriterReferencesSet);

                 // Set StoredProcedure Namespace
                this.StoredProcedureObjectNamespace = "DataAccessComponent.StoredProcedureManager";
                
                // Stored Procedure References
                this.StoredProcedureReferencesSet = new ReferencesSet("StoredProcedures");
                
                // Set Stored Procedure References
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("System"));
                
                // If .NET7
                if (TargetFramework == TargetFrameworkEnum.Net7)
                {
                    // .NET7
                    this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net7"));
                }
                else if (TargetFramework == TargetFrameworkEnum.Net6)
                {
                    // .NET6
                    this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net6"));
                }
                else if (TargetFramework == TargetFrameworkEnum.Net5)
                {  
                    // .NET5
                    this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net5"));
                }
                else
                {
                    // .NETFramework
                    this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net"));
                }

                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                this.StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                this.AllReferences.Add(this.StoredProcedureReferencesSet);
            }
            #endregion

            #region FindReferenceIndex(List<ProjectReference> references, string name)
            /// <summary>
            /// returns the Reference Index
            /// </summary>
            public int FindReferenceIndex(List<ProjectReference> references, string name)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the references object exists
                if ((references != null) && (references.Count > 0))
                {   
                    // Iterate the collection of ProjectReference objects
                    foreach (ProjectReference reference in references)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this is the item being sought
                        if (reference.ReferenceName == name)
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
                // Create Databases Collection
                this.Databases = new List<DTNDatabase>();
                
                // Create AllReferences
                this.AllReferences = new List<ReferencesSet>();

                // Create Enumerations
                this.Enumerations = new List<Enumeration>();

                // Create the Tables collection
                this.Tables = new List<DTNTable>();

                // New projects now default to .NET 7
                TargetFramework = TargetFrameworkEnum.Net7;
                
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
        
            #region UpdateReferences()
            /// <summary>
            /// Update Data Juggler Net Reference
            /// </summary>
            public void UpdateReferences()
            {
                // local
                int index = -1;
                int index2 = -1;
                int index3 = -1;

                // *********************************************************************
                // ***********   System.Data.SqlClient and Microsoft.Data.SqlClient    ************
                // *********************************************************************

                // if .NET 6 or .NET 7
                if ((TargetFramework == TargetFrameworkEnum.Net6) || (TargetFramework == TargetFrameworkEnum.Net7))
                {
                    // find the index of System.Data.SqlClient
                    index = FindReferenceIndex(WriterReferencesSet.References, "System.Data.SqlClient");

                    // if the index was found
                    if (index >= 0)
                    {
                        // remove this item
                        WriterReferencesSet.References.RemoveAt(index);
                        
                        // now find this index
                        index = FindReferenceIndex(WriterReferencesSet.References, "Microsoft.Data.SqlClient");

                        // only add if not already there
                        if (index < 0)
                        {
                            // Switch to Microsoft
                            WriterReferencesSet.References.Add(new ProjectReference("Microsoft.Data.SqlClient"));
                        }
                    }
                }
                else
                {
                    // .NET5 / .NETFramework

                    // find the index of Microsoft.Data.SqlClient
                    index = FindReferenceIndex(WriterReferencesSet.References, "Microsoft.Data.SqlClient");

                    // if the index was found
                    if (index >= 0)
                    {
                        // remove this item
                        WriterReferencesSet.References.RemoveAt(index);    
                    }

                    // now find this index
                    index = FindReferenceIndex(WriterReferencesSet.References, "System.Data.SqlClient");

                    // only add if not already there
                    if (index < 0)
                    {
                        // I think .NET5 and .NETFramework both need this. Will answer this question soon.
                        this.WriterReferencesSet.References.Add(new ProjectReference("System.Data.SqlClient"));  
                    }
                }

                // *********************************************************************************
                // *******  DataJuggler.Net, DataJuggler.Net5 and DataJuggler.Net6 and DataJuggler.Net7    ********
                // *********************************************************************************

                // local
                string dataJugglerNetReferenceName = "";
                bool itemRemoved = false;

                // if .NETFramework
                if (TargetFramework == TargetFrameworkEnum.NetFramework)
                {
                    // Set the DataJuggler.Net Reference name
                    dataJugglerNetReferenceName = "DataJuggler.Net";

                    // find the index of Microsoft.Data.SqlClient
                    index = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net5");
                    index2 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net6");
                    index3 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net7");
                }
                else if (TargetFramework == TargetFrameworkEnum.Net5)
                {
                    // Set the DataJuggler.Net Reference name
                    dataJugglerNetReferenceName = "DataJuggler.Net5";

                    // find the index of Microsoft.Data.SqlClient
                    index = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net");
                    index2 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net6");
                    index3 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net7");
                }
                else if (TargetFramework == TargetFrameworkEnum.Net6)
                {
                    // Set the DataJuggler.Net Reference name
                    dataJugglerNetReferenceName = "DataJuggler.Net6";

                    // find the index of DataJuggler.Net and DataJuggler.Net5
                    index = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net");
                    index2 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net5");
                    index3 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net7");
                }
                else
                {
                    // .NET 7
                    // Set the DataJuggler.Net Reference name
                    dataJugglerNetReferenceName = "DataJuggler.Net7";

                    // find the index of DataJuggler.Net and DataJuggler.Net5
                    index = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net");
                    index2 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net5");
                    index3 = FindReferenceIndex(StoredProcedureReferencesSet.References, "DataJuggler.Net6");
                }

                // only one of these can fire, so indexes do not get out of wack

                // if the index was found
                if (index >= 0)
                {
                    // remove this item
                    StoredProcedureReferencesSet.References.RemoveAt(index);    

                    // an item was removed
                    itemRemoved = true;
                }

                // if the index2 was found
                if (index2 >= 0)
                {
                    // remove this item
                    StoredProcedureReferencesSet.References.RemoveAt(index2);

                    // item was removed
                    itemRemoved = true;
                }

                // if the index3 was found
                if (index3 >= 0)
                {
                    // remove this item
                    StoredProcedureReferencesSet.References.RemoveAt(index3);

                    // item was removed
                    itemRemoved = true;
                }

                // if the value for itemRemoved is true
                if (itemRemoved)
                {
                    // get the index of dataJugglerNetReferenceName
                    index = FindReferenceIndex(StoredProcedureReferencesSet.References, dataJugglerNetReferenceName);

                    // only add if not already there
                    if (index < 0)
                    {
                        // create a new projectReference
                        ProjectReference projectReference = new ProjectReference(dataJugglerNetReferenceName);

                        // add this item
                        StoredProcedureReferencesSet.References.Add(projectReference);
                    }
                }
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

            #region AllReferencesCount
            /// <summary>
            /// This read only property returns the value for 'AllReferencesCount'.
            /// </summary>
            public int AllReferencesCount
            {
                get
                {
                    // initial value
                    int allReferencesCount = 0;
                    
                    // If the AllReferences object exists
                    if (AllReferences != null)
                    {
                        // set the return value
                        allReferencesCount = AllReferences.Count;
                    }
                    
                    // return value
                    return allReferencesCount;
                }
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

            #region IsDotNetCore
            /// <summary>
            /// this read only property returns true if the TargetFramework is .Net5 or .Net6 or .Net7
            /// </summary>
            public bool IsDotNetCore
            {
                get
                {
                    // initial value
                    bool isDotNetCore = (TargetFramework != TargetFrameworkEnum.NetFramework);

                    // return value
                    return isDotNetCore;
                }
            }
            #endregion

            #region IsDotNetFramework
            /// <summary>
            /// this read only property returns true if the TargetFramework is NetFramework
            /// </summary>
            public bool IsDotNetFramework
            {
                get
                {
                    // initial value
                    bool isDotNetFramework = (TargetFramework == TargetFrameworkEnum.NetFramework);

                    // return value
                    return isDotNetFramework;
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