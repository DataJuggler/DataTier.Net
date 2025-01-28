
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion

namespace DataAccessComponent.Data.Writers
{

    #region class ProjectWriter
    /// <summary>
    /// This class is used for converting a 'Project' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ProjectWriter : ProjectWriterBase
    {

        #region Static Methods

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
            public static new FindProjectStoredProcedure CreateFindProjectStoredProcedure(Project project)
            {
                // Initial Value
                FindProjectStoredProcedure findProjectStoredProcedure = null;

                // verify project exists
                if(project != null)
                {
                    // Instanciate findProjectStoredProcedure
                    findProjectStoredProcedure = new FindProjectStoredProcedure();

                    // if project.FindByProjectName is true
                    if (project.FindByProjectName)
                    {
                            // Change the procedure name
                            findProjectStoredProcedure.ProcedureName = "Project_FindByProjectName";
                            
                            // Create the @ProjectName parameter
                            findProjectStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectName", project.ProjectName);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findProjectStoredProcedure.Parameters = CreatePrimaryKeyParameter(project);
                    }
                }

                // return value
                return findProjectStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
