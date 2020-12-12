

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using System.Data.SqlClient;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class ProjectReferenceWriterBase
    /// <summary>
    /// This class is used for converting a 'ProjectReference' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ProjectReferenceWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ProjectReference projectReference)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='projectReference'>The 'ProjectReference' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ProjectReference projectReference)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (projectReference != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @ReferencesId = new SqlParameter("@ReferencesId", projectReference.ReferencesId);

                    // Set parameters[0] to @ReferencesId
                    parameters[0] = @ReferencesId;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteProjectReferenceStoredProcedure(ProjectReference projectReference)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteProjectReference'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReference_Delete'.
            /// </summary>
            /// <param name="projectReference">The 'ProjectReference' to Delete.</param>
            /// <returns>An instance of a 'DeleteProjectReferenceStoredProcedure' object.</returns>
            public static DeleteProjectReferenceStoredProcedure CreateDeleteProjectReferenceStoredProcedure(ProjectReference projectReference)
            {
                // Initial Value
                DeleteProjectReferenceStoredProcedure deleteProjectReferenceStoredProcedure = new DeleteProjectReferenceStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteProjectReferenceStoredProcedure.Parameters = CreatePrimaryKeyParameter(projectReference);

                // return value
                return deleteProjectReferenceStoredProcedure;
            }
            #endregion

            #region CreateFindProjectReferenceStoredProcedure(ProjectReference projectReference)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindProjectReferenceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReference_Find'.
            /// </summary>
            /// <param name="projectReference">The 'ProjectReference' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindProjectReferenceStoredProcedure CreateFindProjectReferenceStoredProcedure(ProjectReference projectReference)
            {
                // Initial Value
                FindProjectReferenceStoredProcedure findProjectReferenceStoredProcedure = null;

                // verify projectReference exists
                if(projectReference != null)
                {
                    // Instanciate findProjectReferenceStoredProcedure
                    findProjectReferenceStoredProcedure = new FindProjectReferenceStoredProcedure();

                    // Now create parameters for this procedure
                    findProjectReferenceStoredProcedure.Parameters = CreatePrimaryKeyParameter(projectReference);
                }

                // return value
                return findProjectReferenceStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ProjectReference projectReference)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new projectReference.
            /// </summary>
            /// <param name="projectReference">The 'ProjectReference' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ProjectReference projectReference)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify projectReferenceexists
                if(projectReference != null)
                {
                    // Create [ReferenceName] parameter
                    param = new SqlParameter("@ReferenceName", projectReference.ReferenceName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ReferencesSetId] parameter
                    param = new SqlParameter("@ReferencesSetId", projectReference.ReferencesSetId);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertProjectReferenceStoredProcedure(ProjectReference projectReference)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertProjectReferenceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReference_Insert'.
            /// </summary>
            /// <param name="projectReference"The 'ProjectReference' object to insert</param>
            /// <returns>An instance of a 'InsertProjectReferenceStoredProcedure' object.</returns>
            public static InsertProjectReferenceStoredProcedure CreateInsertProjectReferenceStoredProcedure(ProjectReference projectReference)
            {
                // Initial Value
                InsertProjectReferenceStoredProcedure insertProjectReferenceStoredProcedure = null;

                // verify projectReference exists
                if(projectReference != null)
                {
                    // Instanciate insertProjectReferenceStoredProcedure
                    insertProjectReferenceStoredProcedure = new InsertProjectReferenceStoredProcedure();

                    // Now create parameters for this procedure
                    insertProjectReferenceStoredProcedure.Parameters = CreateInsertParameters(projectReference);
                }

                // return value
                return insertProjectReferenceStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ProjectReference projectReference)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing projectReference.
            /// </summary>
            /// <param name="projectReference">The 'ProjectReference' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ProjectReference projectReference)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify projectReferenceexists
                if(projectReference != null)
                {
                    // Create parameter for [ReferenceName]
                    param = new SqlParameter("@ReferenceName", projectReference.ReferenceName);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ReferencesSetId]
                    param = new SqlParameter("@ReferencesSetId", projectReference.ReferencesSetId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [ReferencesId]
                    param = new SqlParameter("@ReferencesId", projectReference.ReferencesId);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateProjectReferenceStoredProcedure(ProjectReference projectReference)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateProjectReferenceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReference_Update'.
            /// </summary>
            /// <param name="projectReference"The 'ProjectReference' object to update</param>
            /// <returns>An instance of a 'UpdateProjectReferenceStoredProcedure</returns>
            public static UpdateProjectReferenceStoredProcedure CreateUpdateProjectReferenceStoredProcedure(ProjectReference projectReference)
            {
                // Initial Value
                UpdateProjectReferenceStoredProcedure updateProjectReferenceStoredProcedure = null;

                // verify projectReference exists
                if(projectReference != null)
                {
                    // Instanciate updateProjectReferenceStoredProcedure
                    updateProjectReferenceStoredProcedure = new UpdateProjectReferenceStoredProcedure();

                    // Now create parameters for this procedure
                    updateProjectReferenceStoredProcedure.Parameters = CreateUpdateParameters(projectReference);
                }

                // return value
                return updateProjectReferenceStoredProcedure;
            }
            #endregion

            #region CreateFetchAllProjectReferencesStoredProcedure(ProjectReference projectReference)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllProjectReferencesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ProjectReference_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllProjectReferencesStoredProcedure' object.</returns>
            public static FetchAllProjectReferencesStoredProcedure CreateFetchAllProjectReferencesStoredProcedure(ProjectReference projectReference)
            {
                // Initial value
                FetchAllProjectReferencesStoredProcedure fetchAllProjectReferencesStoredProcedure = new FetchAllProjectReferencesStoredProcedure();

                // return value
                return fetchAllProjectReferencesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
