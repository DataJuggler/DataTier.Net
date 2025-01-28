

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ProjectReferencesView
    public partial class ProjectReferencesView
    {

        #region Private Variables
        private int controllerReferencesSetId;
        private int dataManagerReferencesSetId;
        private int dataWriterReferencesSetId;
        private int objectReferencesSetId;
        private int projectId;
        private string projectName;
        private int readerReferencesSetId;
        private string referenceName;
        private int referencesId;
        private int referencesSetId;
        private string referencesSetName;
        private int storedProcedureReferencesSetId;
        #endregion

        #region Methods


        #endregion

        #region Properties

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

            #region int ProjectId
            public int ProjectId
            {
                get
                {
                    return projectId;
                }
                set
                {
                    projectId = value;
                }
            }
            #endregion

            #region ReferencesId
            /// <summary>
            /// This property gets or sets the value for 'ReferencesId'.
            /// </summary>
            public int ReferencesId
            {
                get { return referencesId; }
                set { referencesId = value; }
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

            #region string ReferenceName
            public string ReferenceName
            {
                get
                {
                    return referenceName;
                }
                set
                {
                    referenceName = value;
                }
            }
            #endregion

            #region int ReferencesSetId
            public int ReferencesSetId
            {
                get
                {
                    return referencesSetId;
                }
                set
                {
                    referencesSetId = value;
                }
            }
            #endregion

            #region string ReferencesSetName
            public string ReferencesSetName
            {
                get
                {
                    return referencesSetName;
                }
                set
                {
                    referencesSetName = value;
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

        #endregion

    }
    #endregion

}
