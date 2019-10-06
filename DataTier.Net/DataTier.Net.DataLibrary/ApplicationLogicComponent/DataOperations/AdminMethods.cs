

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class AdminMethods
    /// <summary>
    /// This class contains methods for modifying a 'Admin' object.
    /// </summary>
    public class AdminMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'AdminMethods' object.
        /// </summary>
        public AdminMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteAdmin(Admin)
            /// <summary>
            /// This method deletes a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                        bool deleted = this.DataManager.AdminManager.DeleteAdmin(deleteAdminProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Admin' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to delete.
            /// <returns>A PolymorphicObject object with all  'Admins' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                    adminListCollection = this.DataManager.AdminManager.FetchAllAdmins(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(adminListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = adminListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindAdmin(Admin)
            /// <summary>
            /// This method finds a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            admin = this.DataManager.AdminManager.FindAdmin(findAdminProc, dataConnector);

                            // if dataObject exists
                            if(admin != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = admin;
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
                return returnObject;
            }
            #endregion

            #region InsertAdmin (Admin)
            /// <summary>
            /// This method inserts a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            returnObject.IntegerValue = this.DataManager.AdminManager.InsertAdmin(insertAdminProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateAdmin (Admin)
            /// <summary>
            /// This method updates a 'Admin' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Admin' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateAdmin(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            bool saved = this.DataManager.AdminManager.UpdateAdmin(updateAdminProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
