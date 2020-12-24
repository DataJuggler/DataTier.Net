
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

    #region class UserInterfaceWriter
    /// <summary>
    /// This class is used for converting a 'UserInterface' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UserInterfaceWriter : UserInterfaceWriterBase
    {

        #region Static Methods

            #region CreateFindUserInterfaceStoredProcedure(UserInterface userInterface)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindUserInterfaceStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UserInterface_Find'.
            /// </summary>
            /// <param name="userInterface">The 'UserInterface' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindUserInterfaceStoredProcedure CreateFindUserInterfaceStoredProcedure(UserInterface userInterface)
            {
                // Initial Value
                FindUserInterfaceStoredProcedure findUserInterfaceStoredProcedure = null;

                // verify userInterface exists
                if(userInterface != null)
                {
                    // Instanciate findUserInterfaceStoredProcedure
                    findUserInterfaceStoredProcedure = new FindUserInterfaceStoredProcedure();

                    // if userInterface.FindByProjectId is true
                    if (userInterface.FindByProjectId)
                    {
                        // Change the procedure name
                        findUserInterfaceStoredProcedure.ProcedureName = "UserInterface_FindByProjectId";
                        
                        // Create the @ProjectId parameter
                        findUserInterfaceStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@ProjectId", userInterface.ProjectId);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findUserInterfaceStoredProcedure.Parameters = CreatePrimaryKeyParameter(userInterface);
                    }
                }

                // return value
                return findUserInterfaceStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
