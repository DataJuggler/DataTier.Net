

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using DataJuggler.Core.UltimateHelper;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Project
    [Serializable]
    public partial class Project
    {

        #region Private Variables
        private List<ReferencesSet> allReferences;
        private List<DTNDatabase> databases;
        private ReferencesSet controllerReferencesSet;
        private ReferencesSet dataManagerReferencesSet;
        private ReferencesSet dataOperationsReferencesSet;
        private List<Enumeration> enumerations;
        private ReferencesSet objectReferencesSet;
        private ReferencesSet readerReferencesSet;
        private ReferencesSet storedProcedureReferencesSet;
        private List<DTNTable> tables;
        private ReferencesSet writerReferencesSet;
        private bool referencesRecreated;
        #endregion

        #region Constructor
        public Project()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods

            #region AppendToProjectFolder(string folderName)
            /// <summary>
            /// This method appends the string to the ProjectFolder
            /// to the return the default path for a child folder.
            /// </summary>
            /// <returns></returns>
            public string AppendToProjectFolder(string folderName)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder(ProjectFolder);
                
                // if it does not end with a back slash add it now
                if(!ProjectFolder.EndsWith(@"\"))
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
                if(!String.IsNullOrEmpty(ProjectFolder))
                {
                    // Set the values now
                    
                    // Set the ObjectFolder (Also known as the Data Object Folder).
                    ObjectFolder = AppendToProjectFolder(@"ObjectLibrary\BusinessObjects");

                    // if the original 4 project template
                    if (Ta == 1)
                    {
                        // Set the Data Operations Folder
                        DataOperationsFolder = AppendToProjectFolder(@"DataAccessComponent\DataOperations");
                        
                        // Set the Data Manager Folder.
                        DataManagerFolder = AppendToProjectFolder(@"DataAccessComponent\DataManager");
                        
                        // Set the Controllers Folder
                        ControllerFolder = AppendToProjectFolder(@"DataAccessComponent\Controllers");
                        
                        // Set the Reader Folder
                        ReaderFolder = AppendToProjectFolder(@"DataAccessComponent\DataManager\Readers");
                        
                        // Set the Writers Folder
                        DataWriterFolder = AppendToProjectFolder(@"DataAccessComponent\DataManager\Writers");
                    }
                    else
                    {
                        // new V2 2 project template
                        
                        // Set the Data Operations Folder
                        DataOperationsFolder = AppendToProjectFolder(@"DataAccessComponent\DataOperations");
                        
                        // Set the Data Manager Folder.
                        DataManagerFolder = AppendToProjectFolder(@"DataAccessComponent\Data");
                        
                        // Set the Reader Folder
                        ReaderFolder = AppendToProjectFolder(@"DataAccessComponent\Data\Readers");
                        
                        // Set the Writers Folder
                        DataWriterFolder = AppendToProjectFolder(@"DataAccessComponent\Data\Writers");
                        
                        // Set the Controllers Folder
                        ControllerFolder = AppendToProjectFolder(@"DataAccessComponent\Controllers");
                    }
                    
                    // Set the StoredProcedureFolder
                    StoredProcedureObjectFolder = AppendToProjectFolder(@"DataAccessComponent\StoredProcedureManager");
                    
                    // Create the StoredProcsFolder
                    StoredProcsFolder = AppendToProjectFolder(@"DataAccessComponent\StoredProcedureManager\StoredProcedureSQL");
                }
            }
            #endregion
            
            #region CreateDefaultReferences()
            /// <summary>
            /// This method creates the default references. Comment so this shows up in changes.
            /// </summary>
            public void CreateDefaultReferences()
            {  
                // local
                bool hasExistingReferences = (HasObjectReferencesSet && !ObjectReferencesSet.IsNew);

                // Set ObjectNamespace
                ObjectNamespace = "ObjectLibrary.BusinessObjects";
                
                // Create ObjectReferencesSet
                ObjectReferencesSet = new ReferencesSet("DataObjects");
                
                // Update to fix existing projects
                ObjectReferencesSet.UpdateIdentity(ObjectReferencesSetId);

                // Create Object References
                ObjectReferencesSet.References.Add(new ProjectReference("System"));
                ObjectReferencesSet.References.Add(new ProjectReference("ObjectLibrary.Enumerations"));
                
                // Add this references set to All Refrences
                AllReferences.Add(ObjectReferencesSet);
                
                // if the OldVersion
                if (Ta == 1)
                {
                    // Set DataManagerNamespace - Going Forward defaults to Data
                    DataManagerNamespace = "DataAccessComponent.DataManager";
                }
                else
                {
                    // Set DataManagerNamespace - Going Forward defaults to Data
                    DataManagerNamespace = "DataAccessComponent.Data";
                }
                
                // Create DataManagerReferencesSet
                DataManagerReferencesSet = new ReferencesSet("DataManager");

                // Update 1.26.2025 - Preserving Id
                DataManagerReferencesSet.UpdateIdentity(DataManagerReferencesSetId);
                
                // Create DataManager References
                DataManagerReferencesSet.References.Add(new ProjectReference("System"));
                DataManagerReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                DataManagerReferencesSet.References.Add(new ProjectReference("System.Data"));
                DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                DataManagerReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                
                // Use Data
                DataManagerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.Data.Readers"));
                
                // Add to AllReferences
                AllReferences.Add(DataManagerReferencesSet);
                
                // Create DataOperationsReferencesSet
                DataOperationsReferencesSet = new ReferencesSet("DataOperations");
                
                // Update 1.26.2025 - Preserving Id
                DataOperationsReferencesSet.UpdateIdentity(DataOperationsReferencesSetId);
                
                // Create DataOperation References
                DataOperationsReferencesSet.References.Add(new ProjectReference("System"));
                DataOperationsReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                DataOperationsReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                
                if (Ta == 1)
                {
                    DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataManager"));
                    DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataManager.Writers"));
                }
                else
                {
                    DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.Data"));
                    DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.Data.Writers"));
                }
                
                // Create ControllerReferencesSet
                ControllerReferencesSet = new ReferencesSet("Controllers");

                // Update, set the Id
                ControllerReferencesSet.UpdateIdentity(ControllerReferencesSetId);
                
                if (Ta == 1)
                {
                    // Set DataOperationNamespace
                    DataOperationsNamespace = "DataAccessComponent.DataOperations";
                    DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataBridge"));
                    ControllerNamespace = "DataAccessComponent.Controllers";
                    ControllerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.Logging"));
                    ControllerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataOperations"));
                    ControllerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataBridge"));
                }
                else
                {
                    // Set DataOperationNamespace
                    DataOperationsNamespace = "DataAccessComponent.DataOperations";
                    DataOperationsReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataBridge"));
                    ControllerNamespace = "DataAccessComponent.Controllers";
                    ControllerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.Logging"));
                    ControllerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataOperations"));
                    ControllerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.DataBridge"));
                    ControllerReferencesSet.References.Add(new ProjectReference("DataAccessComponent.Data"));
                }
                
                AllReferences.Add(DataOperationsReferencesSet);
                
                // Create Controller References
                ControllerReferencesSet.References.Add(new ProjectReference("System"));
                ControllerReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                ControllerReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                
                // Add this grou
                AllReferences.Add(ControllerReferencesSet);
                
                if (Ta == 1)
                {
                    // Set ReaderNamespace
                    ReaderNamespace = "DataAccessComponent.DataManager.Readers";
                }
                else
                {
                    // Set ReaderNamespace
                    ReaderNamespace = "DataAccessComponent.Data.Readers";
                }
                
                // Add Reader References
                ReaderReferencesSet = new ReferencesSet("Readers");

                // Update - Preserve Id
                ReaderReferencesSet.UpdateIdentity(ReaderReferencesSetId);
                
                // Set Reader References
                ReaderReferencesSet.References.Add(new ProjectReference("System"));
                ReaderReferencesSet.References.Add(new ProjectReference("System.Collections.Generic"));
                ReaderReferencesSet.References.Add(new ProjectReference("System.Data"));
                ReaderReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                ReaderReferencesSet.References.Add(new ProjectReference("ObjectLibrary.Enumerations"));
                AllReferences.Add(ReaderReferencesSet);
                
                // Set Writer Namespace
                DataWriterNamespace = "DataAccessComponent.Data.Writers";
                
                // Add Writer References
                WriterReferencesSet = new ReferencesSet("Writers");

                // Update Preserve Id
                WriterReferencesSet.UpdateIdentity(DataWriterReferencesSetId);
                
                // Set Writer References
                WriterReferencesSet.References.Add(new ProjectReference("System"));
                WriterReferencesSet.References.Add(new ProjectReference("ObjectLibrary.BusinessObjects"));
                WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                WriterReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                WriterReferencesSet.References.Add(new ProjectReference("System.Data"));
                
                // if .NET6, .NET7, .NET8, .NET9 or .NET10
                if ((int) TargetFramework > 5)
                {
                    // Switch to Microsoft
                    WriterReferencesSet.References.Add(new ProjectReference("Microsoft.Data.SqlClient"));
                }
                else
                {
                    // All Dot Net Core projects
                    WriterReferencesSet.References.Add(new ProjectReference("System.Data.SqlClient"));
                }
                
                // Add this references set
                AllReferences.Add(WriterReferencesSet);
                
                // Set StoredProcedure Namespace
                StoredProcedureObjectNamespace = "DataAccessComponent.StoredProcedureManager";
                
                // Stored Procedure References
                StoredProcedureReferencesSet = new ReferencesSet("StoredProcedures");

                // Update the Id
                StoredProcedureReferencesSet.UpdateIdentity(StoredProcedureReferencesSetId);
                
                // Set Stored Procedure References
                StoredProcedureReferencesSet.References.Add(new ProjectReference("System"));
                
                // If .NET10
                if (TargetFramework == TargetFrameworkEnum.Net10)
                {
                    // .NET10+
                    StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.NET.Data"));
                }
                // If .NET9
                else if (TargetFramework == TargetFrameworkEnum.Net9)
                {
                    // .NET9
                    StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.NET9"));
                }
                // If .NET8
                else if (TargetFramework == TargetFrameworkEnum.Net8)
                {
                    // .NET8
                    StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net8"));
                }
                // If .NET7
                else if (TargetFramework == TargetFrameworkEnum.Net7)
                {
                    // .NET7
                    StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net7"));
                }
                else if (TargetFramework == TargetFrameworkEnum.Net6)
                {
                    // .NET6
                    StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net6"));
                }
                else if (TargetFramework == TargetFrameworkEnum.Net5)
                {
                    // .NET5
                    StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net5"));
                }
                else
                {
                    // .NETFramework
                    StoredProcedureReferencesSet.References.Add(new ProjectReference("DataJuggler.Net"));
                }
                
                StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.DeleteProcedures"));
                StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.FetchProcedures"));
                StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.InsertProcedures"));
                StoredProcedureReferencesSet.References.Add(new ProjectReference("DataAccessComponent.StoredProcedureManager.UpdateProcedures"));
                AllReferences.Add(StoredProcedureReferencesSet);

                // if the existing References exist
                if (hasExistingReferences)
                {
                    // Edit 11.23.2024: If an existing project was opened and this had to be called, this will show a message
                    // to the user that the references had to be recreated
                    ReferencesRecreated = true;
                }
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
                if (HasDatabases)
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
                if (AllReferences != null)
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
                Databases = new List<DTNDatabase>();
                
                // Create AllReferences
                AllReferences = new List<ReferencesSet>();
                
                // Create Enumerations
                Enumerations = new List<Enumeration>();
                
                // Create the Tables collection
                Tables = new List<DTNTable>();
                
                // New projects now default to .NET 10
                TargetFramework = TargetFrameworkEnum.Net10;
            }
            #endregion

            #region SetProjectIdOnDatabases(int projectId)
            /// <summary>
            /// This method Set Project ID On Databases
            /// </summary>
            public void SetProjectIdOnDatabases(int projectId)
            {
                // If the Databases object exists
                if (HasDatabases)
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
                if (HasAllReferences)
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
            /// returns the String
            /// </summary>
            public override string ToString()
            {
                // initial value
                string toString = ProjectName;

                // return value
                return toString;
            }
            #endregion
            
            #region UpdateReferences(TargetFrameworkEnum previousFramework)
            /// <summary>
            /// This method updates the Stored Procedure References Set with the correct version of .NET Frameowork.
            /// Also, if greater than .NET 5, you must use Microsoft.Data.SqlClient, not System.Data.SqlClient
            /// </summary>
            public void UpdateReferences(TargetFrameworkEnum previousFramework)
            {
                // locals
                int index = -1;
                
                // *********************************************************************
                // ***********   System.Data.SqlClient and Microsoft.Data.SqlClient    ************
                // *********************************************************************
                
                // if .NET 6, .NET 7, .NET 8, .NET9 or .NET10
                if (((int) TargetFramework > 5) && (WriterReferencesSet != null))
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
                        // I think .NET5 and .NETFramework both need  Will answer this question soon.
                        WriterReferencesSet.References.Add(new ProjectReference("System.Data.SqlClient"));
                    }
                }
                
                // *********************************************************************************
                // ***  DataJuggler.Net, DataJuggler.Net5, DataJuggler.Net6, DataJuggler.Net7
                // ***  DataJuggler.Net8, DataJuggler.NET9, DataJuggler.NET10
                // *********************************************************************************
                
                // local
                string dataJugglerNetReferenceName = "";
                string prevReferenceName = "";
                
                // if .NETFramework
                if (TargetFramework == TargetFrameworkEnum.NetFramework)
                {
                    // Set the DataJuggler.Net Reference name
                    dataJugglerNetReferenceName = "DataJuggler.Net";
                }
                else
                {
                    // Get the TargetFramework Version
                    int targetFrameworkVersion = (int) TargetFramework;

                    if (targetFrameworkVersion >= 10)
                    {
                        // Set the dataJugglerNetReferenceName
                        dataJugglerNetReferenceName = "DataJuggler.NET.Data";
                    }
                    else
                    {
                        // Set the dataJugglerNetReferenceName
                        dataJugglerNetReferenceName = "DataJuggler.Net" + targetFrameworkVersion;
                    }
                }
                
                // if .Net Framework
                if (previousFramework == TargetFrameworkEnum.NetFramework)
                {
                    // Set the previous name
                    prevReferenceName = "DataJuggler.Net";
                }
                else
                {
                    // Get the TargetFramework Version
                    int previousFrameworkVersionNumber = (int) previousFramework;
                    
                    // Just in case of a downgrade (unlikely)
                    if (previousFrameworkVersionNumber >= 10)
                    {
                        // Set the dataJugglerNetReferenceName
                        prevReferenceName = "DataJuggler.NET.Data";
                    }
                    else
                    {
                        // Set the dataJugglerNetReferenceName
                        prevReferenceName = "DataJuggler.Net" + previousFrameworkVersionNumber;
                    }
                }
                
                // Now we need to find the index of the old reference name
                index = FindReferenceIndex(StoredProcedureReferencesSet.References, prevReferenceName);
                
                // if the index was found
                if (index >= 0)
                {
                    // remove this item
                    StoredProcedureReferencesSet.References.RemoveAt(index);
                    
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
            /// This property gets or sets the value for 'AllReferences'.
            /// </summary>
            public List<ReferencesSet> AllReferences
            {
                get { return allReferences; }
                set { allReferences = value; }
            }
            #endregion
            
            #region ControllerReferencesSet
            /// <summary>
            /// This property gets or sets the value for 'ControllerReferencesSet'.
            /// </summary>
            public ReferencesSet ControllerReferencesSet
            {
                get { return controllerReferencesSet; }
                set { controllerReferencesSet = value; }
            }
            #endregion
            
            #region Databases
            /// <summary>
            /// This property gets or sets the value for 'Databases'.
            /// </summary>
            public List<DTNDatabase> Databases
            {
                get { return databases; }
                set { databases = value; }
            }
            #endregion
            
            #region DataManagerReferencesSet
            /// <summary>
            /// This property gets or sets the value for 'DataManagerReferencesSet'.
            /// </summary>
            public ReferencesSet DataManagerReferencesSet
            {
                get { return dataManagerReferencesSet; }
                set { dataManagerReferencesSet = value; }
            }
            #endregion
            
            #region DataOperationsReferencesSet
            /// <summary>
            /// This property gets or sets the value for 'DataOperationsReferencesSet'.
            /// </summary>
            public ReferencesSet DataOperationsReferencesSet
            {
                get { return dataOperationsReferencesSet; }
                set { dataOperationsReferencesSet = value; }
            }
            #endregion
            
            #region Enumerations
            /// <summary>
            /// This property gets or sets the value for 'Enumerations'.
            /// </summary>
            public List<Enumeration> Enumerations
            {
                get { return enumerations; }
                set { enumerations = value; }
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
                    bool hasAllReferences = (AllReferences != null);

                    // return value
                    return hasAllReferences;
                }
            }
            #endregion
            
            #region HasControllerReferencesSet
            /// <summary>
            /// This property returns true if this object has a 'ControllerReferencesSet'.
            /// </summary>
            public bool HasControllerReferencesSet
            {
                get
                {
                    // initial value
                    bool hasControllerReferencesSet = (ControllerReferencesSet != null);

                    // return value
                    return hasControllerReferencesSet;
                }
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
                    bool hasDatabases = (Databases != null);

                    // return value
                    return hasDatabases;
                }
            }
            #endregion
            
            #region HasDataManagerReferencesSet
            /// <summary>
            /// This property returns true if this object has a 'DataManagerReferencesSet'.
            /// </summary>
            public bool HasDataManagerReferencesSet
            {
                get
                {
                    // initial value
                    bool hasDataManagerReferencesSet = (DataManagerReferencesSet != null);

                    // return value
                    return hasDataManagerReferencesSet;
                }
            }
            #endregion
            
            #region HasDataOperationsReferencesSet
            /// <summary>
            /// This property returns true if this object has a 'DataOperationsReferencesSet'.
            /// </summary>
            public bool HasDataOperationsReferencesSet
            {
                get
                {
                    // initial value
                    bool hasDataOperationsReferencesSet = (DataOperationsReferencesSet != null);

                    // return value
                    return hasDataOperationsReferencesSet;
                }
            }
            #endregion
            
            #region HasObjectReferencesSet
            /// <summary>
            /// This property returns true if this object has an 'ObjectReferencesSet'.
            /// </summary>
            public bool HasObjectReferencesSet
            {
                get
                {
                    // initial value
                    bool hasObjectReferencesSet = (ObjectReferencesSet != null);

                    // return value
                    return hasObjectReferencesSet;
                }
            }
            #endregion
            
            #region HasReaderReferencesSet
            /// <summary>
            /// This property returns true if this object has a 'ReaderReferencesSet'.
            /// </summary>
            public bool HasReaderReferencesSet
            {
                get
                {
                    // initial value
                    bool hasReaderReferencesSet = (ReaderReferencesSet != null);

                    // return value
                    return hasReaderReferencesSet;
                }
            }
            #endregion
            
            #region HasStoredProcedureReferencesSet
            /// <summary>
            /// This property returns true if this object has a 'StoredProcedureReferencesSet'.
            /// </summary>
            public bool HasStoredProcedureReferencesSet
            {
                get
                {
                    // initial value
                    bool hasStoredProcedureReferencesSet = (StoredProcedureReferencesSet != null);

                    // return value
                    return hasStoredProcedureReferencesSet;
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
                    bool hasTables = (Tables != null);

                    // return value
                    return hasTables;
                }
            }
            #endregion
            
            #region HasWriterReferencesSet
            /// <summary>
            /// This property returns true if this object has a 'WriterReferencesSet'.
            /// </summary>
            public bool HasWriterReferencesSet
            {
                get
                {
                    // initial value
                    bool hasWriterReferencesSet = (WriterReferencesSet != null);

                    // return value
                    return hasWriterReferencesSet;
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
            /// This property gets or sets the value for 'ObjectReferencesSet'.
            /// </summary>
            public ReferencesSet ObjectReferencesSet
            {
                get { return objectReferencesSet; }
                set { objectReferencesSet = value; }
            }
            #endregion
            
            #region ReaderReferencesSet
            /// <summary>
            /// This property gets or sets the value for 'ReaderReferencesSet'.
            /// </summary>
            public ReferencesSet ReaderReferencesSet
            {
                get { return readerReferencesSet; }
                set { readerReferencesSet = value; }
            }
            #endregion
            
            #region ReferencesRecreated
            /// <summary>
            /// This property gets or sets the value for 'ReferencesRecreated'.
            /// </summary>
            public bool ReferencesRecreated
            {
                get { return referencesRecreated; }
                set { referencesRecreated = value; }
            }
            #endregion
            
            #region StoredProcedureReferencesSet
            /// <summary>
            /// This property gets or sets the value for 'StoredProcedureReferencesSet'.
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

            #region ValidReferences
            /// <summary>
            /// This read only property returns true if all the References are loaded
            /// </summary>
            public bool ValidReferences
            {
                get
                {
                    // the ValidReferences is true if all these objects exist
                    bool validReferences = (HasControllerReferencesSet && HasDataOperationsReferencesSet && 
                                                      HasObjectReferencesSet && HasReaderReferencesSet && 
                                                      HasStoredProcedureReferencesSet && HasWriterReferencesSet &&
                                                      HasDataManagerReferencesSet);

                    // check each one
                    if (validReferences)
                    {
                        // Controller
                        if (!ListHelper.HasOneOrMoreItems(ControllerReferencesSet.References))
                        {
                            validReferences = false;
                        }

                        // DataOperations
                        if (!ListHelper.HasOneOrMoreItems(DataOperationsReferencesSet.References))
                        {
                            validReferences = false;
                        }

                        // Object
                        if (!ListHelper.HasOneOrMoreItems(ObjectReferencesSet.References))
                        {
                            validReferences = false;
                        }

                        // Reader
                        if (!ListHelper.HasOneOrMoreItems(ReaderReferencesSet.References))
                        {
                            validReferences = false;
                        }

                        // StoredProcedure
                        if (!ListHelper.HasOneOrMoreItems(StoredProcedureReferencesSet.References))
                        {
                            validReferences = false;
                        }

                        // Writer
                        if (!ListHelper.HasOneOrMoreItems(WriterReferencesSet.References))
                        {
                            validReferences = false;
                        }

                        // DataManager
                        if (!ListHelper.HasOneOrMoreItems(DataManagerReferencesSet.References))
                        {
                            validReferences = false;
                        }
                    }

                    
                    // return value
                    return validReferences;
                }
            }
            #endregion
            
            #region WriterReferencesSet
            /// <summary>
            /// This property gets or sets the value for 'WriterReferencesSet'.
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
