
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

    #region class UIFieldWriter
    /// <summary>
    /// This class is used for converting a 'UIField' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class UIFieldWriter : UIFieldWriterBase
    {

        #region Static Methods

            #region CreateFindUIFieldStoredProcedure(UIField uIField)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindUIFieldStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'UIField_Find'.
            /// </summary>
            /// <param name="uIField">The 'UIField' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindUIFieldStoredProcedure CreateFindUIFieldStoredProcedure(UIField uIField)
            {
                // Initial Value
                FindUIFieldStoredProcedure findUIFieldStoredProcedure = null;

                // verify uIField exists
                if(uIField != null)
                {
                    // Instanciate findUIFieldStoredProcedure
                    findUIFieldStoredProcedure = new FindUIFieldStoredProcedure();

                    // if uIField.FindByUserInterfaceId is true
                    if (uIField.FindByUserInterfaceId)
                    {
                        // Change the procedure name
                        findUIFieldStoredProcedure.ProcedureName = "UIField_FindByUserInterfaceId";
                        
                        // Create the @UserInterfaceId parameter
                        findUIFieldStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@UserInterfaceId", uIField.UserInterfaceId);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findUIFieldStoredProcedure.Parameters = CreatePrimaryKeyParameter(uIField);
                    }
                }

                // return value
                return findUIFieldStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
