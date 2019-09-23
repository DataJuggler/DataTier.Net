

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ApplicationLogicComponent.Exceptions;

#endregion


namespace ApplicationLogicComponent.Logging
{

    #region ErrorHandler
    /// <summary>
    /// This class handles logging of errors.
    /// This class will have the ability to log
    /// errors as system errors or log to a log file 
    /// or both.
    /// </summary>
    public class ErrorHandler
    {

        #region Private Variables
        private bool logAsSystemEvent;
        private bool logToFile;
        private string logFileName;
        #endregion

        #region Constructor

        #region Default Constructor
        /// <summary>
        /// Creates a new instance of a ErrorHandler
        /// </summary>
        public ErrorHandler()
        {
        }
        #endregion

        #region ErrorHandler(string logFileNameArg)
        /// <summary>
        /// Creates a new instance of a ErrorHandler
        /// </summary>
        /// <param name="logFileNameArg"></param>
        public ErrorHandler(string logFileNameArg)
        {
            // Set LogFileName
            this.LogFileName = logFileName;
        }
        #endregion

        #endregion

        #region Methods

            #region CreateMessage
            /// <summary>
            /// Create the message from the exception
            /// </summary>
            /// <returns></returns>
            private string CreateMessage(CustomException error)
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
                if (errorObject as CustomException != null)
                {
                    // Set exception to errorObject
                    exception = (CustomException)errorObject;
                }
                else
                {
                    // if error object is an exception
                    if (errorObject as Exception != null)
                    {
                        // Create error
                        Exception error = (Exception)errorObject;

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

            #region LogError(CustomException error)
            /// <summary>
            /// This class logs exceptions as they happen.
            /// </summary>
            /// <param name="error"></param>
            private void LogError(CustomException exception)
            {
                try
                {
                    // verify exception exists
                    if (exception != null)
                    {
                        // If LogToFile is true
                        if (this.LogToFile)
                        {
                            // Log the error to a file.
                            LogErrorToFile(exception);
                        }

                        // If LogAsSystemEvent is true
                        if (this.LogAsSystemEvent)
                        {
                            // Log To System Event Log
                            LogErrorAsSystemEvent(exception);
                        }
                    }
                }
                catch
                {
                }
            }
            #endregion

            #region LogErrorAsSystemEvent(CustomException exception)
            /// <summary>
            /// This method logs errors to the system event log.
            /// </summary>
            /// <param name="exception"></param>
            private void LogErrorAsSystemEvent(CustomException exception)
            {
                throw new Exception("Log as system event log not implemented yet.");
            }
            #endregion

            #region LogErrorToFile(CustomException error)
        /// <summary>
        /// This method logs an error to a file.
        /// </summary>
        /// <param name="error"></param>
        private void LogErrorToFile(CustomException error)
        {
            // local
            StreamWriter writer = null;

            // Verify Log File Exists
            if (!String.IsNullOrEmpty(this.LogFileName))
            {
                // check if file exists
                if (File.Exists(this.LogFileName))
                {
                    // Create writer while appending text to the file
                    writer = File.AppendText(this.LogFileName);
                }
                else
                {
                    // Create Writer for create
                    writer = File.CreateText(this.LogFileName);
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
        #endregion

        #endregion

        #region Properties

        #region LogAsSystemEvent
        /// <summary>
        /// If true errors are logged as system events.
        /// </summary>
        public bool LogAsSystemEvent
        {
            get { return logAsSystemEvent; }
            set { logAsSystemEvent = value; }
        }

        #endregion

        #region LogFileName
        /// <summary>
        /// Name of file to log errors to.
        /// </summary>
        public string LogFileName
        {
            get { return logFileName; }
            set { logFileName = value; }
        }
        #endregion

        #region LogToFile
        /// <summary>
        /// If true errors are logged to a file.
        /// </summary>
        public bool LogToFile
        {
            get { return logToFile; }
            set { logToFile = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
