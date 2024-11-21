

#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using DataAccessComponent.Controllers;

#endregion


namespace DataAccessComponent.Exceptions
{

    #region class CustomException : Exception
    /// <summary>
    /// This object is used for storing errors in the application.
    /// </summary>
    public abstract class CustomException : Exception
    {

        #region Constructor

        #region Default Constructor
        /// <summary>
        /// Creates a new CustomException instance.
        /// </summary>
        public CustomException()
            : base()
        {

        }
        #endregion

        #region Paramterized Constructor
        /// <summary>
        /// Creates a new CustomException instance.
        /// </summary>
        public CustomException(string displayTextArg, string methodNameArg, string objectNameArg, string knowledgeBaseArticleIDArg, bool knownIssueArg, string statusArg, Exception exceptionArg)
        {
            // Set Properties
            this.DisplayText = displayTextArg;
            this.MethodName = methodNameArg;
            this.ObjectName = objectNameArg;
            this.KnowledgeBaseArticleID = knowledgeBaseArticleIDArg;
            this.KnownIssue = knownIssueArg;
            this.Status = statusArg;
            this.Exception = exceptionArg;
        }
        #endregion

        #endregion

        #region Properties

        #region DisplayText
        /// <summary>
        /// The text to display for this error.
        /// </summary>
        public abstract string DisplayText
        {
            get;
            set;
        }
        #endregion

        #region InnerException
        /// <summary>
        /// The System.Exception that caused this error.
        /// </summary>
        public abstract Exception Exception
        {
            get;
            set;
        }
        #endregion

        #region KnowledgeBaseArticleID
        /// <summary>
        /// If known this value will be the ID
        /// of the knowledge base article for this issue.
        /// </summary>
        public abstract string KnowledgeBaseArticleID
        {
            get;
            set;
        }
        #endregion

        #region KnownIssue
        /// <summary>
        /// Is this issue a known issue or not
        /// </summary>
        public abstract bool KnownIssue
        {
            get;
            set;
        }
        #endregion

        #region MethodName
        /// <summary>
        /// The name of the method where this error occurred.
        /// </summary>
        public abstract string MethodName
        {
            get;
            set;
        }
        #endregion

        #region ObjectName
        /// <summary>
        /// The name of the class, control, or form where the error occurred.
        /// </summary>
        public abstract string ObjectName
        {
            get;
            set;
        }
        #endregion

        #region ShowToUser
        /// <summary>
        /// Should this exception be shown to the user or not.
        /// </summary>
        public abstract bool ShowToUser
        {
            get;
            set;
        }
        #endregion

        #region Status
        /// <summary>
        /// The status of this issue.
        /// </summary>
        public abstract string Status
        {
            get;
            set;
        }
        #endregion

        #region UserID
        /// <summary>
        /// The status of this issue.
        /// </summary>
        public abstract int UserID
        {
            get;
            set;
        }
        #endregion

        #endregion

    }
    #endregion

}
