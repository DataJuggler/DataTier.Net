

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace DataAccessComponent.Data.Writers
{

    #region class ProjectWriterBase
    /// <summary>
    /// This class is used for converting a 'Project' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ProjectWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Project project)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='project'>The 'Project' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Project project)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (project != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @ProjectId = new SqlParameter("@ProjectId", project.ProjectId);

                    // Set parameters[0] to @ProjectId
                    parameters[0] = @ProjectId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteProjectStoredProcedure(Project project)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteProject'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Project_Delete'.
            /// </summary>
            /// <param name="project">The 'Project' to Delete.</param>
            /// <returns>An instance of a 'DeleteProjectStoredProcedure' object.</returns>
            public static DeleteProjectStoredProcedure CreateDeleteProjectStoredProcedure(Project project)
            {
                // Initial Value
                DeleteProjectStoredProcedure deleteProjectStoredProcedure = new DeleteProjectStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteProjectStoredProcedure.Parameters = CreatePrimaryKeyParameter(project);

                // return value
                return deleteProjectStoredProcedure;
            }
            #endregion

            #region CreateFindProjectStoredProcedure(Project project)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindProjectStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Project_Find'.
            /// </summary>
            /// <param name="project">The 'Project' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindProjectStoredProcedure CreateFindProjectStoredProcedure(Project project)
            {
                // Initial Value
                FindProjectStoredProcedure findProjectStoredProcedure = null;

                // verify project exists
                if(project != null)
                {
                    // Instanciate findProjectStoredProcedure
                    findProjectStoredProcedure = new FindProjectStoredProcedure();

                    // Now create parameters for this procedure
                    findProjectStoredProcedure.Parameters = CreatePrimaryKeyParameter(project);
                }

                // return value
                return findProjectStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Project project)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new project.
            /// </summary>
            /// <param name="project">The 'Project' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Project project)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[27];
                SqlParameter param = null;

                // verify projectexists
                if(project != null)
                {
                    // Create [ControllerFolder] parameter
                    param = new SqlParameter("@ControllerFolder", project.ControllerFolder);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ControllerNamespace] parameter
                    param = new SqlParameter("@ControllerNamespace", project.ControllerNamespace);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [ControllerReferencesSetId] parameter
                    param = new SqlParameter("@ControllerReferencesSetId", project.ControllerReferencesSetId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [DataManagerFolder] parameter
                    param = new SqlParameter("@DataManagerFolder", project.DataManagerFolder);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [DataManagerNamespace] parameter
                    param = new SqlParameter("@DataManagerNamespace", project.DataManagerNamespace);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [DataManagerReferencesSetId] parameter
                    param = new SqlParameter("@DataManagerReferencesSetId", project.DataManagerReferencesSetId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [DataOperationsFolder] parameter
                    param = new SqlParameter("@DataOperationsFolder", project.DataOperationsFolder);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [DataOperationsNamespace] parameter
                    param = new SqlParameter("@DataOperationsNamespace", project.DataOperationsNamespace);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [DataOperationsReferencesSetId] parameter
                    param = new SqlParameter("@DataOperationsReferencesSetId", project.DataOperationsReferencesSetId);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [DataWriterFolder] parameter
                    param = new SqlParameter("@DataWriterFolder", project.DataWriterFolder);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [DataWriterNamespace] parameter
                    param = new SqlParameter("@DataWriterNamespace", project.DataWriterNamespace);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [DataWriterReferencesSetId] parameter
                    param = new SqlParameter("@DataWriterReferencesSetId", project.DataWriterReferencesSetId);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create [DateModified] Parameter
                    param = new SqlParameter("@DateModified", SqlDbType.DateTime);

                    // If project.DateModified does not exist.
                    if (project.DateModified.Year < 1900)
                    {
                        // Set the value to null
                        param.Value = null;
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = project.DateModified;
                    }

                    // set parameters[12]
                    parameters[12] = param;

                    // Create [ObjectFolder] parameter
                    param = new SqlParameter("@ObjectFolder", project.ObjectFolder);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create [ObjectNamespace] parameter
                    param = new SqlParameter("@ObjectNamespace", project.ObjectNamespace);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create [ObjectReferencesSetId] parameter
                    param = new SqlParameter("@ObjectReferencesSetId", project.ObjectReferencesSetId);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create [ProjectFolder] parameter
                    param = new SqlParameter("@ProjectFolder", project.ProjectFolder);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create [ProjectName] parameter
                    param = new SqlParameter("@ProjectName", project.ProjectName);

                    // set parameters[17]
                    parameters[17] = param;

                    // Create [ReaderFolder] parameter
                    param = new SqlParameter("@ReaderFolder", project.ReaderFolder);

                    // set parameters[18]
                    parameters[18] = param;

                    // Create [ReaderNamespace] parameter
                    param = new SqlParameter("@ReaderNamespace", project.ReaderNamespace);

                    // set parameters[19]
                    parameters[19] = param;

                    // Create [ReaderReferencesSetId] parameter
                    param = new SqlParameter("@ReaderReferencesSetId", project.ReaderReferencesSetId);

                    // set parameters[20]
                    parameters[20] = param;

                    // Create [StoredProcedureObjectFolder] parameter
                    param = new SqlParameter("@StoredProcedureObjectFolder", project.StoredProcedureObjectFolder);

                    // set parameters[21]
                    parameters[21] = param;

                    // Create [StoredProcedureObjectNamespace] parameter
                    param = new SqlParameter("@StoredProcedureObjectNamespace", project.StoredProcedureObjectNamespace);

                    // set parameters[22]
                    parameters[22] = param;

                    // Create [StoredProcedureReferencesSetId] parameter
                    param = new SqlParameter("@StoredProcedureReferencesSetId", project.StoredProcedureReferencesSetId);

                    // set parameters[23]
                    parameters[23] = param;

                    // Create [StoredProcsFolder] parameter
                    param = new SqlParameter("@StoredProcsFolder", project.StoredProcsFolder);

                    // set parameters[24]
                    parameters[24] = param;

                    // Create [TargetFramework] parameter
                    param = new SqlParameter("@TargetFramework", project.TargetFramework);

                    // set parameters[25]
                    parameters[25] = param;

                    // Create [TemplateVersion] parameter
                    param = new SqlParameter("@TemplateVersion", project.Ta);

                    // set parameters[26]
                    parameters[26] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertProjectStoredProcedure(Project project)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertProjectStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Project_Insert'.
            /// </summary>
            /// <param name="project"The 'Project' object to insert</param>
            /// <returns>An instance of a 'InsertProjectStoredProcedure' object.</returns>
            public static InsertProjectStoredProcedure CreateInsertProjectStoredProcedure(Project project)
            {
                // Initial Value
                InsertProjectStoredProcedure insertProjectStoredProcedure = null;

                // verify project exists
                if(project != null)
                {
                    // Instanciate insertProjectStoredProcedure
                    insertProjectStoredProcedure = new InsertProjectStoredProcedure();

                    // Now create parameters for this procedure
                    insertProjectStoredProcedure.Parameters = CreateInsertParameters(project);
                }

                // return value
                return insertProjectStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Project project)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing project.
            /// </summary>
            /// <param name="project">The 'Project' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Project project)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[28];
                SqlParameter param = null;

                // verify projectexists
                if(project != null)
                {
                    // Create parameter for [ControllerFolder]
                    param = new SqlParameter("@ControllerFolder", project.ControllerFolder);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ControllerNamespace]
                    param = new SqlParameter("@ControllerNamespace", project.ControllerNamespace);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [ControllerReferencesSetId]
                    param = new SqlParameter("@ControllerReferencesSetId", project.ControllerReferencesSetId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [DataManagerFolder]
                    param = new SqlParameter("@DataManagerFolder", project.DataManagerFolder);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [DataManagerNamespace]
                    param = new SqlParameter("@DataManagerNamespace", project.DataManagerNamespace);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [DataManagerReferencesSetId]
                    param = new SqlParameter("@DataManagerReferencesSetId", project.DataManagerReferencesSetId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [DataOperationsFolder]
                    param = new SqlParameter("@DataOperationsFolder", project.DataOperationsFolder);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [DataOperationsNamespace]
                    param = new SqlParameter("@DataOperationsNamespace", project.DataOperationsNamespace);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [DataOperationsReferencesSetId]
                    param = new SqlParameter("@DataOperationsReferencesSetId", project.DataOperationsReferencesSetId);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [DataWriterFolder]
                    param = new SqlParameter("@DataWriterFolder", project.DataWriterFolder);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [DataWriterNamespace]
                    param = new SqlParameter("@DataWriterNamespace", project.DataWriterNamespace);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [DataWriterReferencesSetId]
                    param = new SqlParameter("@DataWriterReferencesSetId", project.DataWriterReferencesSetId);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [DateModified]
                    // Create [DateModified] Parameter
                    param = new SqlParameter("@DateModified", SqlDbType.DateTime);

                    // If project.DateModified does not exist.
                    if (project.DateModified.Year < 1900)
                    {
                        // Set the value to null
                        param.Value = null;
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = project.DateModified;
                    }


                    // set parameters[12]
                    parameters[12] = param;

                    // Create parameter for [ObjectFolder]
                    param = new SqlParameter("@ObjectFolder", project.ObjectFolder);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create parameter for [ObjectNamespace]
                    param = new SqlParameter("@ObjectNamespace", project.ObjectNamespace);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create parameter for [ObjectReferencesSetId]
                    param = new SqlParameter("@ObjectReferencesSetId", project.ObjectReferencesSetId);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create parameter for [ProjectFolder]
                    param = new SqlParameter("@ProjectFolder", project.ProjectFolder);

                    // set parameters[16]
                    parameters[16] = param;

                    // Create parameter for [ProjectName]
                    param = new SqlParameter("@ProjectName", project.ProjectName);

                    // set parameters[17]
                    parameters[17] = param;

                    // Create parameter for [ReaderFolder]
                    param = new SqlParameter("@ReaderFolder", project.ReaderFolder);

                    // set parameters[18]
                    parameters[18] = param;

                    // Create parameter for [ReaderNamespace]
                    param = new SqlParameter("@ReaderNamespace", project.ReaderNamespace);

                    // set parameters[19]
                    parameters[19] = param;

                    // Create parameter for [ReaderReferencesSetId]
                    param = new SqlParameter("@ReaderReferencesSetId", project.ReaderReferencesSetId);

                    // set parameters[20]
                    parameters[20] = param;

                    // Create parameter for [StoredProcedureObjectFolder]
                    param = new SqlParameter("@StoredProcedureObjectFolder", project.StoredProcedureObjectFolder);

                    // set parameters[21]
                    parameters[21] = param;

                    // Create parameter for [StoredProcedureObjectNamespace]
                    param = new SqlParameter("@StoredProcedureObjectNamespace", project.StoredProcedureObjectNamespace);

                    // set parameters[22]
                    parameters[22] = param;

                    // Create parameter for [StoredProcedureReferencesSetId]
                    param = new SqlParameter("@StoredProcedureReferencesSetId", project.StoredProcedureReferencesSetId);

                    // set parameters[23]
                    parameters[23] = param;

                    // Create parameter for [StoredProcsFolder]
                    param = new SqlParameter("@StoredProcsFolder", project.StoredProcsFolder);

                    // set parameters[24]
                    parameters[24] = param;

                    // Create parameter for [TargetFramework]
                    param = new SqlParameter("@TargetFramework", project.TargetFramework);

                    // set parameters[25]
                    parameters[25] = param;

                    // Create parameter for [TemplateVersion]
                    param = new SqlParameter("@TemplateVersion", project.Ta);

                    // set parameters[26]
                    parameters[26] = param;

                    // Create parameter for [ProjectId]
                    param = new SqlParameter("@ProjectId", project.ProjectId);
                    parameters[27] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateProjectStoredProcedure(Project project)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateProjectStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Project_Update'.
            /// </summary>
            /// <param name="project"The 'Project' object to update</param>
            /// <returns>An instance of a 'UpdateProjectStoredProcedure</returns>
            public static UpdateProjectStoredProcedure CreateUpdateProjectStoredProcedure(Project project)
            {
                // Initial Value
                UpdateProjectStoredProcedure updateProjectStoredProcedure = null;

                // verify project exists
                if(project != null)
                {
                    // Instanciate updateProjectStoredProcedure
                    updateProjectStoredProcedure = new UpdateProjectStoredProcedure();

                    // Now create parameters for this procedure
                    updateProjectStoredProcedure.Parameters = CreateUpdateParameters(project);
                }

                // return value
                return updateProjectStoredProcedure;
            }
            #endregion

            #region CreateFetchAllProjectsStoredProcedure(Project project)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllProjectsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Project_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllProjectsStoredProcedure' object.</returns>
            public static FetchAllProjectsStoredProcedure CreateFetchAllProjectsStoredProcedure(Project project)
            {
                // Initial value
                FetchAllProjectsStoredProcedure fetchAllProjectsStoredProcedure = new FetchAllProjectsStoredProcedure();

                // return value
                return fetchAllProjectsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
