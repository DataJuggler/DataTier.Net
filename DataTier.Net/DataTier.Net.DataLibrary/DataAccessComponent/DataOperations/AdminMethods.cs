

#region using statements

using System;
using System.Collections.Generic;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class AdminMethods
    /// <summary>
    /// This class contains methods for modifying a 'Admin' object.
    /// </summary>
    public static class AdminMethods
    {

        #region Methods

            #region DeleteAdmin(Admin)
            /// <summary>
            /// This method deletes a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteAdminStoredProcedure deleteAdminProc = null;

                    // verify the first parameters is a(n) 'Admin'.
                    if (parameters[0].ObjectValue as Admin != null)
                    {
                        // Create Admin
                        Admin admin = (Admin) parameters[0].ObjectValue;

                        // verify admin exists
                        if(admin != null)
                        {
                            // Now create deleteAdminProc from AdminWriter
                            // The DataWriter converts the 'Admin'
                            // to the SqlParameter[] array needed to delete a 'Admin'.
                            deleteAdminProc = AdminWriter.CreateDeleteAdminStoredProcedure(admin);
                        }
                    }

                    // Verify deleteAdminProc exists
                    if(deleteAdminProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = AdminManager.DeleteAdmin(deleteAdminProc, dataConnector);

                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Admin' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to delete.
            /// <returns>A PolymorphicObject object with all  'Admins' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<Admin> adminListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllAdminsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get AdminParameter
                    // Declare Parameter
                    Admin paramAdmin = null;

                    // verify the first parameters is a(n) 'Admin'.
                    if (parameters[0].ObjectValue as Admin != null)
                    {
                        // Get AdminParameter
                        paramAdmin = (Admin) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllAdminsProc from AdminWriter
                    fetchAllProc = AdminWriter.CreateFetchAllAdminsStoredProcedure(paramAdmin);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    adminListCollection = AdminManager.FetchAllAdmins(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(adminListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = adminListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FindAdmin(Admin)
            /// <summary>
            /// This method finds a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Admin admin = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindAdminStoredProcedure findAdminProc = null;

                    // verify the first parameters is a 'Admin'.
                    if (parameters[0].ObjectValue as Admin != null)
                    {
                        // Get AdminParameter
                        Admin paramAdmin = (Admin) parameters[0].ObjectValue;

                        // verify paramAdmin exists
                        if(paramAdmin != null)
                        {
                            // Now create findAdminProc from AdminWriter
                            // The DataWriter converts the 'Admin'
                            // to the SqlParameter[] array needed to find a 'Admin'.
                            findAdminProc = AdminWriter.CreateFindAdminStoredProcedure(paramAdmin);
                        }

                        // Verify findAdminProc exists
                        if(findAdminProc != null)
                        {
                            // Execute Find Stored Procedure
                            admin = AdminManager.FindAdmin(findAdminProc, dataConnector);

                            // if dataObject exists
                            if(admin != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = admin;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region InsertAdmin (Admin)
            /// <summary>
            /// This method inserts a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Admin admin = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertAdminStoredProcedure insertAdminProc = null;

                    // verify the first parameters is a(n) 'Admin'.
                    if (parameters[0].ObjectValue as Admin != null)
                    {
                        // Create Admin Parameter
                        admin = (Admin) parameters[0].ObjectValue;

                        // verify admin exists
                        if(admin != null)
                        {
                            // Now create insertAdminProc from AdminWriter
                            // The DataWriter converts the 'Admin'
                            // to the SqlParameter[] array needed to insert a 'Admin'.
                            insertAdminProc = AdminWriter.CreateInsertAdminStoredProcedure(admin);
                        }

                        // Verify insertAdminProc exists
                        if(insertAdminProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = AdminManager.InsertAdmin(insertAdminProc, dataConnector);

                            // Set the value for Sucess based on if the Insert was Successful
                            result.Success = result.HasIntegerValue;
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region UpdateAdmin (Admin)
            /// <summary>
            /// This method updates a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Admin admin = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateAdminStoredProcedure updateAdminProc = null;

                    // verify the first parameters is a(n) 'Admin'.
                    if (parameters[0].ObjectValue as Admin != null)
                    {
                        // Create Admin Parameter
                        admin = (Admin) parameters[0].ObjectValue;

                        // verify admin exists
                        if(admin != null)
                        {
                            // Now create updateAdminProc from AdminWriter
                            // The DataWriter converts the 'Admin'
                            // to the SqlParameter[] array needed to update a 'Admin'.
                            updateAdminProc = AdminWriter.CreateUpdateAdminStoredProcedure(admin);
                        }

                        // Verify updateAdminProc exists
                        if(updateAdminProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = AdminManager.UpdateAdmin(updateAdminProc, dataConnector);
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
