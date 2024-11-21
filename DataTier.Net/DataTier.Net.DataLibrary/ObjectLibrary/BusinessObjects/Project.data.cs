

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Project
    public partial class Project
    {

        #region Private Variables
        private string controllerFolder;
        private string controllerNamespace;
        private int controllerReferencesSetId;
        private string dataManagerFolder;
        private string dataManagerNamespace;
        private int dataManagerReferencesSetId;
        private string dataOperationsFolder;
        private string dataOperationsNamespace;
        private int dataOperationsReferencesSetId;
        private string dataWriterFolder;
        private string dataWriterNamespace;
        private int dataWriterReferencesSetId;
        private DateTime dateModified;
        private string objectFolder;
        private string objectNamespace;
        private int objectReferencesSetId;
        private string projectFolder;
        private int projectId;
        private string projectName;
        private string readerFolder;
        private string readerNamespace;
        private int readerReferencesSetId;        
        private string storedProcedureObjectFolder;
        private string storedProcedureObjectNamespace;
        private int storedProcedureReferencesSetId;
        private string storedProcsFolder;
        private TargetFrameworkEnum targetFramework;
        private int templateVersion;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.projectId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string ControllerFolder
            public string ControllerFolder
            {
                get
                {
                    return controllerFolder;
                }
                set
                {
                    controllerFolder = value;
                }
            }
            #endregion

            #region string ControllerNamespace
            public string ControllerNamespace
            {
                get
                {
                    return controllerNamespace;
                }
                set
                {
                    controllerNamespace = value;
                }
            }
            #endregion

            #region int ControllerReferencesSetId
            public int ControllerReferencesSetId
            {
                get
                {
                    return controllerReferencesSetId;
                }
                set
                {
                    controllerReferencesSetId = value;
                }
            }
            #endregion

            #region string DataManagerFolder
            public string DataManagerFolder
            {
                get
                {
                    return dataManagerFolder;
                }
                set
                {
                    dataManagerFolder = value;
                }
            }
            #endregion

            #region string DataManagerNamespace
            public string DataManagerNamespace
            {
                get
                {
                    return dataManagerNamespace;
                }
                set
                {
                    dataManagerNamespace = value;
                }
            }
            #endregion

            #region int DataManagerReferencesSetId
            public int DataManagerReferencesSetId
            {
                get
                {
                    return dataManagerReferencesSetId;
                }
                set
                {
                    dataManagerReferencesSetId = value;
                }
            }
            #endregion

            #region string DataOperationsFolder
            public string DataOperationsFolder
            {
                get
                {
                    return dataOperationsFolder;
                }
                set
                {
                    dataOperationsFolder = value;
                }
            }
            #endregion

            #region string DataOperationsNamespace
            public string DataOperationsNamespace
            {
                get
                {
                    return dataOperationsNamespace;
                }
                set
                {
                    dataOperationsNamespace = value;
                }
            }
            #endregion

            #region int DataOperationsReferencesSetId
            public int DataOperationsReferencesSetId
            {
                get
                {
                    return dataOperationsReferencesSetId;
                }
                set
                {
                    dataOperationsReferencesSetId = value;
                }
            }
            #endregion

            #region string DataWriterFolder
            public string DataWriterFolder
            {
                get
                {
                    return dataWriterFolder;
                }
                set
                {
                    dataWriterFolder = value;
                }
            }
            #endregion

            #region string DataWriterNamespace
            public string DataWriterNamespace
            {
                get
                {
                    return dataWriterNamespace;
                }
                set
                {
                    dataWriterNamespace = value;
                }
            }
            #endregion

            #region int DataWriterReferencesSetId
            public int DataWriterReferencesSetId
            {
                get
                {
                    return dataWriterReferencesSetId;
                }
                set
                {
                    dataWriterReferencesSetId = value;
                }
            }
            #endregion

            #region DateTime DateModified
            public DateTime DateModified
            {
                get
                {
                    return dateModified;
                }
                set
                {
                    dateModified = value;
                }
            }
            #endregion

            #region string ObjectFolder
            public string ObjectFolder
            {
                get
                {
                    return objectFolder;
                }
                set
                {
                    objectFolder = value;
                }
            }
            #endregion

            #region string ObjectNamespace
            public string ObjectNamespace
            {
                get
                {
                    return objectNamespace;
                }
                set
                {
                    objectNamespace = value;
                }
            }
            #endregion

            #region int ObjectReferencesSetId
            public int ObjectReferencesSetId
            {
                get
                {
                    return objectReferencesSetId;
                }
                set
                {
                    objectReferencesSetId = value;
                }
            }
            #endregion

            #region string ProjectFolder
            public string ProjectFolder
            {
                get
                {
                    return projectFolder;
                }
                set
                {
                    projectFolder = value;
                }
            }
            #endregion

            #region int ProjectId
            public int ProjectId
            {
                get
                {
                    return projectId;
                }
            }
            #endregion

            #region string ProjectName
            public string ProjectName
            {
                get
                {
                    return projectName;
                }
                set
                {
                    projectName = value;
                }
            }
            #endregion

            #region string ReaderFolder
            public string ReaderFolder
            {
                get
                {
                    return readerFolder;
                }
                set
                {
                    readerFolder = value;
                }
            }
            #endregion

            #region string ReaderNamespace
            public string ReaderNamespace
            {
                get
                {
                    return readerNamespace;
                }
                set
                {
                    readerNamespace = value;
                }
            }
            #endregion

            #region int ReaderReferencesSetId
            public int ReaderReferencesSetId
            {
                get
                {
                    return readerReferencesSetId;
                }
                set
                {
                    readerReferencesSetId = value;
                }
            }
            #endregion

            #region string StoredProcedureObjectFolder
            public string StoredProcedureObjectFolder
            {
                get
                {
                    return storedProcedureObjectFolder;
                }
                set
                {
                    storedProcedureObjectFolder = value;
                }
            }
            #endregion

            #region string StoredProcedureObjectNamespace
            public string StoredProcedureObjectNamespace
            {
                get
                {
                    return storedProcedureObjectNamespace;
                }
                set
                {
                    storedProcedureObjectNamespace = value;
                }
            }
            #endregion

            #region int StoredProcedureReferencesSetId
            public int StoredProcedureReferencesSetId
            {
                get
                {
                    return storedProcedureReferencesSetId;
                }
                set
                {
                    storedProcedureReferencesSetId = value;
                }
            }
            #endregion

            #region string StoredProcsFolder
            public string StoredProcsFolder
            {
                get
                {
                    return storedProcsFolder;
                }
                set
                {
                    storedProcsFolder = value;
                }
            }
            #endregion

            #region TargetFrameworkEnum TargetFramework
            public TargetFrameworkEnum TargetFramework
            {
                get
                {
                    return targetFramework;
                }
                set
                {
                    targetFramework = value;
                }
            }
            #endregion

            #region int TemplateVersion
            public int TemplateVersion
            {
                get
                {
                    return templateVersion;
                }
                set
                {
                    templateVersion = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.ProjectId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
