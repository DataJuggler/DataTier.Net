

#region using statements

using System;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Project
    public partial class Project
    {

        #region Private Variables
        private bool addIGridValueInterface;
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

            #region CreateValuesList
            // <summary>
            // This method creates the ValuesList for an Insert SQL Statement.'
            // </summary>
            public string CreateValuesList()
            {
                // initial value
                string valuesList = "";

                // locals
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string comma = ",";
                string singleQuote = "'";

                // AddIGridValueInterface

                // If AddIGridValueInterface is true
                if (AddIGridValueInterface)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // ControllerFolder

                sb.Append(singleQuote);
                sb.Append(ControllerFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ControllerNamespace

                sb.Append(singleQuote);
                sb.Append(ControllerNamespace);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ControllerReferencesSetId

                sb.Append(ControllerReferencesSetId);

                // Add a comma
                sb.Append(comma);

                // DataManagerFolder

                sb.Append(singleQuote);
                sb.Append(DataManagerFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DataManagerNamespace

                sb.Append(singleQuote);
                sb.Append(DataManagerNamespace);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DataManagerReferencesSetId

                sb.Append(DataManagerReferencesSetId);

                // Add a comma
                sb.Append(comma);

                // DataOperationsFolder

                sb.Append(singleQuote);
                sb.Append(DataOperationsFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DataOperationsNamespace

                sb.Append(singleQuote);
                sb.Append(DataOperationsNamespace);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DataOperationsReferencesSetId

                sb.Append(DataOperationsReferencesSetId);

                // Add a comma
                sb.Append(comma);

                // DataWriterFolder

                sb.Append(singleQuote);
                sb.Append(DataWriterFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DataWriterNamespace

                sb.Append(singleQuote);
                sb.Append(DataWriterNamespace);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DataWriterReferencesSetId

                sb.Append(DataWriterReferencesSetId);

                // Add a comma
                sb.Append(comma);

                // DateModified

                // If a valid date
                if (DateModified.Year > 1900)
                {
                    sb.Append(singleQuote);
                    sb.Append(DateModified.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(singleQuote);
                }
                else
                {
                    sb.Append("NULL");
                }

                // Add a comma
                sb.Append(comma);

                // ObjectFolder

                sb.Append(singleQuote);
                sb.Append(ObjectFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ObjectNamespace

                sb.Append(singleQuote);
                sb.Append(ObjectNamespace);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ObjectReferencesSetId

                sb.Append(ObjectReferencesSetId);

                // Add a comma
                sb.Append(comma);

                // ProjectFolder

                sb.Append(singleQuote);
                sb.Append(ProjectFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ProjectName

                sb.Append(singleQuote);
                sb.Append(ProjectName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ReaderFolder

                sb.Append(singleQuote);
                sb.Append(ReaderFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ReaderNamespace

                sb.Append(singleQuote);
                sb.Append(ReaderNamespace);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ReaderReferencesSetId

                sb.Append(ReaderReferencesSetId);

                // Add a comma
                sb.Append(comma);

                // StoredProcedureObjectFolder

                sb.Append(singleQuote);
                sb.Append(StoredProcedureObjectFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // StoredProcedureObjectNamespace

                sb.Append(singleQuote);
                sb.Append(StoredProcedureObjectNamespace);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // StoredProcedureReferencesSetId

                sb.Append(StoredProcedureReferencesSetId);

                // Add a comma
                sb.Append(comma);

                // StoredProcsFolder

                sb.Append(singleQuote);
                sb.Append(StoredProcsFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // TargetFramework

                sb.Append(TargetFramework);

                // Add a comma
                sb.Append(comma);

                // TemplateVersion

                sb.Append(TemplateVersion);

                // Set the return value
                valuesList = sb.ToString();

                // Return Value
                return valuesList;
            }
            #endregion

            #region GenerateInsertSQL
            // <summary>
            // This method generates a SQL Insert statement for ah object loaded.'
            // </summary>
            public string GenerateInsertSQL()
            {
                // local
                string valuesList = CreateValuesList();

                // Set the return Value
                string insertSQL = "INSERT INTO [Project] (AddIGridValueInterface,ControllerFolder,ControllerNamespace,ControllerReferencesSetId,DataManagerFolder,DataManagerNamespace,DataManagerReferencesSetId,DataOperationsFolder,DataOperationsNamespace,DataOperationsReferencesSetId,DataWriterFolder,DataWriterNamespace,DataWriterReferencesSetId,DateModified,ObjectFolder,ObjectNamespace,ObjectReferencesSetId,ProjectFolder,ProjectName,ReaderFolder,ReaderNamespace,ReaderReferencesSetId,StoredProcedureObjectFolder,StoredProcedureObjectNamespace,StoredProcedureReferencesSetId,StoredProcsFolder,TargetFramework,TemplateVersion) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

                // Return Value
                return insertSQL;
            }
            #endregion

            #region GetValue(string fieldName)
            // <summary>
            // This method returns the value for the fieldName given
            // </summary>
            public object GetValue(string fieldName)
            {
                // initial value
                object value = "";

                // // Determine the action by the fieldName
                switch (fieldName)
                {
                    case "AddIGridValueInterface":

                        // set the value
                        value = this.AddIGridValueInterface;

                        // required
                        break;

                    case "ControllerFolder":

                        // set the value
                        value = this.ControllerFolder;

                        // required
                        break;

                    case "ControllerNamespace":

                        // set the value
                        value = this.ControllerNamespace;

                        // required
                        break;

                    case "ControllerReferencesSetId":

                        // set the value
                        value = this.ControllerReferencesSetId;

                        // required
                        break;

                    case "DataManagerFolder":

                        // set the value
                        value = this.DataManagerFolder;

                        // required
                        break;

                    case "DataManagerNamespace":

                        // set the value
                        value = this.DataManagerNamespace;

                        // required
                        break;

                    case "DataManagerReferencesSetId":

                        // set the value
                        value = this.DataManagerReferencesSetId;

                        // required
                        break;

                    case "DataOperationsFolder":

                        // set the value
                        value = this.DataOperationsFolder;

                        // required
                        break;

                    case "DataOperationsNamespace":

                        // set the value
                        value = this.DataOperationsNamespace;

                        // required
                        break;

                    case "DataOperationsReferencesSetId":

                        // set the value
                        value = this.DataOperationsReferencesSetId;

                        // required
                        break;

                    case "DataWriterFolder":

                        // set the value
                        value = this.DataWriterFolder;

                        // required
                        break;

                    case "DataWriterNamespace":

                        // set the value
                        value = this.DataWriterNamespace;

                        // required
                        break;

                    case "DataWriterReferencesSetId":

                        // set the value
                        value = this.DataWriterReferencesSetId;

                        // required
                        break;

                    case "DateModified":

                        // set the value
                        value = this.DateModified;

                        // required
                        break;

                    case "ObjectFolder":

                        // set the value
                        value = this.ObjectFolder;

                        // required
                        break;

                    case "ObjectNamespace":

                        // set the value
                        value = this.ObjectNamespace;

                        // required
                        break;

                    case "ObjectReferencesSetId":

                        // set the value
                        value = this.ObjectReferencesSetId;

                        // required
                        break;

                    case "ProjectFolder":

                        // set the value
                        value = this.ProjectFolder;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "ProjectName":

                        // set the value
                        value = this.ProjectName;

                        // required
                        break;

                    case "ReaderFolder":

                        // set the value
                        value = this.ReaderFolder;

                        // required
                        break;

                    case "ReaderNamespace":

                        // set the value
                        value = this.ReaderNamespace;

                        // required
                        break;

                    case "ReaderReferencesSetId":

                        // set the value
                        value = this.ReaderReferencesSetId;

                        // required
                        break;

                    case "StoredProcedureObjectFolder":

                        // set the value
                        value = this.StoredProcedureObjectFolder;

                        // required
                        break;

                    case "StoredProcedureObjectNamespace":

                        // set the value
                        value = this.StoredProcedureObjectNamespace;

                        // required
                        break;

                    case "StoredProcedureReferencesSetId":

                        // set the value
                        value = this.StoredProcedureReferencesSetId;

                        // required
                        break;

                    case "StoredProcsFolder":

                        // set the value
                        value = this.StoredProcsFolder;

                        // required
                        break;

                    case "TargetFramework":

                        // set the value
                        value = this.TargetFramework;

                        // required
                        break;

                    case "TemplateVersion":

                        // set the value
                        value = this.TemplateVersion;

                        // required
                        break;

                }

                // return value
                return value;
            }
            #endregion

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

            #region bool AddIGridValueInterface
            public bool AddIGridValueInterface
            {
                get
                {
                    return addIGridValueInterface;
                }
                set
                {
                    addIGridValueInterface = value;
                }
            }
            #endregion

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
