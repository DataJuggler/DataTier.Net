

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataAccessComponent.Exceptions;
using DataJuggler.UltimateHelper;
using System.Diagnostics;
using System.Runtime.Versioning;
using DataAccessComponent.Connection;

#endregion

namespace DataAccessComponent.Logging
{

    #region class ErrorHandler
    /// <summary>
    /// This class is used to Log Errors to files or System Events and (or) keep in memory
    /// </summary>
    public class ErrorHandler
    {
        
        #region Private Variables
        private List<Exception> exceptions;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of an ErrorHandler object
        /// </summary>
        public ErrorHandler()
        {
            // Create a new collection of 'Exception' objects.
            Exceptions = new List<Exception>();
        }
        #endregion

        #region Methods

            #region CreateMessage(CustomException error)
            /// <summary>
            /// Create the message from the exception
            /// </summary>
            /// <returns></returns>
            private static string CreateMessage(CustomException error)
            {
                // Create StringBuilder
                StringBuilder sb = new StringBuilder("Error: ");

                // append display text
                sb.Append(error.DisplayText);

                // append new line
                sb.Append(Environment.NewLine);

                // append method name
                sb.Append("Method: ");
                sb.Append(error.MethodName);

                // append new line
                sb.Append(Environment.NewLine);

                // apend object name
                sb.Append("Object: ");
                sb.Append(error.ObjectName);

                // append new line
                sb.Append(Environment.NewLine);

                // append user
                string user = "Unknown User - Error Occurred Before Login";

                // If UserID
                if (error.UserID > 0)
                {
                    // append user
                    user = "UserID: " + error.UserID.ToString();
                }

                // append user
                sb.Append(user);

                // append new line
                sb.Append(Environment.NewLine);

                // date
                sb.Append(DateTime.Now.ToString());

                // append new line
                sb.Append(Environment.NewLine);

                // return value
                return sb.ToString();
            }
            #endregion
            
            #region LogError(CustomException exception)
            /// <summary>
            /// method Log Error
            /// </summary>
            public void LogError(CustomException exception)
            {
                try
                {
                    // verify exception exists
                    if (exception != null)
                    {
                        // if the value for HasExceptions is true
                        if (HasExceptions)
                        {
                            // Add this error
                            Exceptions.Add(exception);
                        }

                        // Log the error to a file.
                        LogErrorToFile(exception);

                        // Attempt to log this as a SystemEvent
                        LogErrorAsSystemEvent(exception);
                    }
                }
                catch
                {
                }
            }
            #endregion
            
            #region LogError(string methodName, string objectName, object errorObject)
            /// <summary>
            /// This class logs errors as they come in.
            /// </summary>
            /// <param name="error"></param>
            public void LogError(string methodName, string objectName, object errorObject)
            {
                // locals
                CustomException exception = null;

                // if this object is
                if (errorObject is CustomException tempError)
                {
                    // Set exception to errorObject
                    exception = tempError;
                }
                else
                {
                    // if error object is an exception
                    if (errorObject is Exception tempError2)
                    {
                        // Create error
                        Exception error = tempError2;

                        // create exception
                        exception = new UnknownErrorException(methodName, objectName, error);
                    }
                }

                try
                {
                    // Log Error
                    LogError(exception);
                }
                catch
                {
                }
            }
            #endregion
            
            #region LogErrorAsSystemEvent(CustomException exception)
            /// <summary>
            /// event is fired when Log Error As System Event
            /// </summary>
            private void LogErrorAsSystemEvent(CustomException exception)
            {
                // set the eventLogResourceName
                string eventLogResourceName = EnvironmentVariableHelper.GetEnvironmentVariableValue(ConnectionConstants.LogEventResourceName, EnvironmentVariableTarget.User);

                // If the eventLogResourceName string exists
                if (TextHelper.Exists(eventLogResourceName))
                {
                    // Ensure the event source exists. If not, create it.
                    if (!EventLog.SourceExists(eventLogResourceName))
                    {
                        EventLog.CreateEventSource(eventLogResourceName, "Application");
                    }

                    // Write the exception details to the event log.
                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = eventLogResourceName;
                        eventLog.WriteEntry(exception.Message, EventLogEntryType.Error);
                    }
                }
            }
            #endregion

            #region LogErrorToFile(CustomException error)
            /// <summary>
            /// This method logs an error to a file.
            /// </summary>
            /// <param name="error"></param>
            private void LogErrorToFile(CustomException error)
            {
                // if the Error exists and the Exceptions exist
                if ((NullHelper.Exists(error)) && (HasExceptions))
                {
                    // local
                    StreamWriter writer = null;

                    // Get the logfileName
                    string logFileName = EnvironmentVariableHelper.GetEnvironmentVariableValue("DataTierNetLogFileName", EnvironmentVariableTarget.User);

                    // Verify Log File Exists
                    if (!String.IsNullOrEmpty(logFileName))
                    {
                        // check if file exists
                        if (File.Exists(logFileName))
                        {
                            // Create writer while appending text to the file
                            writer = File.AppendText(logFileName);
                        }
                        else
                        {
                            // Create Writer for create
                            writer = File.CreateText(logFileName);
                        }

                        // Create Message
                        string message = CreateMessage(error);

                        // Write Message
                        writer.WriteLine(message);

                        // flush writer
                        writer.Flush();

                        // close stream
                        writer.Close();

                        // set writer to nothing
                        writer = null;
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Exceptions
            /// <summary>
            /// This property gets or sets the value for 'Exceptions'.
            /// </summary>
            public List<Exception> Exceptions
            {
                get { return exceptions; }
                set { exceptions = value; }
            }
            #endregion
            
            #region HasExceptions
            /// <summary>
            /// This property returns true if this object has an 'Exceptions'.
            /// </summary>
            public bool HasExceptions
            {
                get
                {
                    // initial value
                    bool hasExceptions = (Exceptions != null);

                    // return value
                    return hasExceptions;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}