

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
using DataJuggler.Net.Enumerations;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class UserInterfaceMethods
    /// <summary>
    /// This class contains methods for modifying a 'UserInterface' object.
    /// </summary>
    public class UserInterfaceMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'UserInterfaceMethods' object.
        /// </summary>
        public UserInterfaceMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteUserInterface(UserInterface)
            /// <summary>
            /// This method deletes a 'UserInterface' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UserInterface' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteUserInterface(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteUserInterfaceStoredProcedure deleteUserInterfaceProc = null;

                    // verify the first parameters is a(n) 'UserInterface'.
                    if (parameters[0].ObjectValue as UserInterface != null)
                    {
                        // Create UserInterface
                        UserInterface userInterface = (UserInterface) parameters[0].ObjectValue;

                        // verify userInterface exists
                        if(userInterface != null)
                        {
                            // Now create deleteUserInterfaceProc from UserInterfaceWriter
                            // The DataWriter converts the 'UserInterface'
                            // to the SqlParameter[] array needed to delete a 'UserInterface'.
                            deleteUserInterfaceProc = UserInterfaceWriter.CreateDeleteUserInterfaceStoredProcedure(userInterface);
                        }
                    }

                    // Verify deleteUserInterfaceProc exists
                    if(deleteUserInterfaceProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.UserInterfaceManager.DeleteUserInterface(deleteUserInterfaceProc, dataConnector);

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
            /// This method fetches all 'UserInterface' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UserInterface' to delete.
            /// <returns>A PolymorphicObject object with all  'UserInterfaces' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<UserInterface> userInterfaceListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllUserInterfacesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get UserInterfaceParameter
                    // Declare Parameter
                    UserInterface paramUserInterface = null;

                    // verify the first parameters is a(n) 'UserInterface'.
                    if (parameters[0].ObjectValue as UserInterface != null)
                    {
                        // Get UserInterfaceParameter
                        paramUserInterface = (UserInterface) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllUserInterfacesProc from UserInterfaceWriter
                    fetchAllProc = UserInterfaceWriter.CreateFetchAllUserInterfacesStoredProcedure(paramUserInterface);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    userInterfaceListCollection = this.DataManager.UserInterfaceManager.FetchAllUserInterfaces(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(userInterfaceListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = userInterfaceListCollection;
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

            #region FindUserInterface(UserInterface)
            /// <summary>
            /// This method finds a 'UserInterface' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UserInterface' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindUserInterface(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UserInterface userInterface = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindUserInterfaceStoredProcedure findUserInterfaceProc = null;

                    // verify the first parameters is a 'UserInterface'.
                    if (parameters[0].ObjectValue as UserInterface != null)
                    {
                        // Get UserInterfaceParameter
                        UserInterface paramUserInterface = (UserInterface) parameters[0].ObjectValue;

                        // verify paramUserInterface exists
                        if(paramUserInterface != null)
                        {
                            // Now create findUserInterfaceProc from UserInterfaceWriter
                            // The DataWriter converts the 'UserInterface'
                            // to the SqlParameter[] array needed to find a 'UserInterface'.
                            findUserInterfaceProc = UserInterfaceWriter.CreateFindUserInterfaceStoredProcedure(paramUserInterface);
                        }

                        // Verify findUserInterfaceProc exists
                        if(findUserInterfaceProc != null)
                        {
                            // Execute Find Stored Procedure
                            userInterface = this.DataManager.UserInterfaceManager.FindUserInterface(findUserInterfaceProc, dataConnector);

                            // if dataObject exists
                            if(userInterface != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = userInterface;
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

            #region InsertUserInterface (UserInterface)
            /// <summary>
            /// This method inserts a 'UserInterface' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UserInterface' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertUserInterface(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UserInterface userInterface = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertUserInterfaceStoredProcedure insertUserInterfaceProc = null;

                    // verify the first parameters is a(n) 'UserInterface'.
                    if (parameters[0].ObjectValue as UserInterface != null)
                    {
                        // Create UserInterface Parameter
                        userInterface = (UserInterface) parameters[0].ObjectValue;

                        // verify userInterface exists
                        if(userInterface != null)
                        {
                            // Now create insertUserInterfaceProc from UserInterfaceWriter
                            // The DataWriter converts the 'UserInterface'
                            // to the SqlParameter[] array needed to insert a 'UserInterface'.
                            insertUserInterfaceProc = UserInterfaceWriter.CreateInsertUserInterfaceStoredProcedure(userInterface);
                        }

                        // Verify insertUserInterfaceProc exists
                        if(insertUserInterfaceProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.UserInterfaceManager.InsertUserInterface(insertUserInterfaceProc, dataConnector);
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

            #region UpdateUserInterface (UserInterface)
            /// <summary>
            /// This method updates a 'UserInterface' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UserInterface' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateUserInterface(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UserInterface userInterface = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateUserInterfaceStoredProcedure updateUserInterfaceProc = null;

                    // verify the first parameters is a(n) 'UserInterface'.
                    if (parameters[0].ObjectValue as UserInterface != null)
                    {
                        // Create UserInterface Parameter
                        userInterface = (UserInterface) parameters[0].ObjectValue;

                        // verify userInterface exists
                        if(userInterface != null)
                        {
                            // Now create updateUserInterfaceProc from UserInterfaceWriter
                            // The DataWriter converts the 'UserInterface'
                            // to the SqlParameter[] array needed to update a 'UserInterface'.
                            updateUserInterfaceProc = UserInterfaceWriter.CreateUpdateUserInterfaceStoredProcedure(userInterface);
                        }

                        // Verify updateUserInterfaceProc exists
                        if(updateUserInterfaceProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.UserInterfaceManager.UpdateUserInterface(updateUserInterfaceProc, dataConnector);

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
