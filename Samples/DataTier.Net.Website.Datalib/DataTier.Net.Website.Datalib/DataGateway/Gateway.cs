
#region using statements

using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.DataOperations;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

#endregion

namespace DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// The Gateway to the FlyingElephantWeb.
        /// </summary>
        public Gateway()
        {
            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods

            #region DeleteGitHubFollower(int id, GitHubFollower tempGitHubFollower = null)
            /// <summary>
            /// This method is used to delete GitHubFollower objects.
            /// </summary>
            /// <param name="id">Delete the GitHubFollower with this id</param>
            /// <param name="tempGitHubFollower">Pass in a tempGitHubFollower to perform a custom delete.</param>
            public bool DeleteGitHubFollower(int id, GitHubFollower tempGitHubFollower = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempGitHubFollower does not exist
                    if (tempGitHubFollower == null)
                    {
                        // create a temp GitHubFollower
                        tempGitHubFollower = new GitHubFollower();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempGitHubFollower.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.GitHubFollowerController.Delete(tempGitHubFollower);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteNotification(int id, Notification tempNotification = null)
            /// <summary>
            /// This method is used to delete Notification objects.
            /// </summary>
            /// <param name="id">Delete the Notification with this id</param>
            /// <param name="tempNotification">Pass in a tempNotification to perform a custom delete.</param>
            public bool DeleteNotification(int id, Notification tempNotification = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempNotification does not exist
                    if (tempNotification == null)
                    {
                        // create a temp Notification
                        tempNotification = new Notification();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempNotification.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.NotificationController.Delete(tempNotification);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteNotificationHistory(int id, NotificationHistory tempNotificationHistory = null)
            /// <summary>
            /// This method is used to delete NotificationHistory objects.
            /// </summary>
            /// <param name="id">Delete the NotificationHistory with this id</param>
            /// <param name="tempNotificationHistory">Pass in a tempNotificationHistory to perform a custom delete.</param>
            public bool DeleteNotificationHistory(int id, NotificationHistory tempNotificationHistory = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempNotificationHistory does not exist
                    if (tempNotificationHistory == null)
                    {
                        // create a temp NotificationHistory
                        tempNotificationHistory = new NotificationHistory();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempNotificationHistory.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.NotificationHistoryController.Delete(tempNotificationHistory);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.DataManager.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindGitHubFollower(int id, GitHubFollower tempGitHubFollower = null)
            /// <summary>
            /// This method is used to find 'GitHubFollower' objects.
            /// </summary>
            /// <param name="id">Find the GitHubFollower with this id</param>
            /// <param name="tempGitHubFollower">Pass in a tempGitHubFollower to perform a custom find.</param>
            public GitHubFollower FindGitHubFollower(int id, GitHubFollower tempGitHubFollower = null)
            {
                // initial value
                GitHubFollower gitHubFollower = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempGitHubFollower does not exist
                    if (tempGitHubFollower == null)
                    {
                        // create a temp GitHubFollower
                        tempGitHubFollower = new GitHubFollower();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempGitHubFollower.UpdateIdentity(id);
                    }

                    // perform the find
                    gitHubFollower = this.AppController.ControllerManager.GitHubFollowerController.Find(tempGitHubFollower);
                }

                // return value
                return gitHubFollower;
            }
            #endregion

            #region FindNotification(int id, Notification tempNotification = null)
            /// <summary>
            /// This method is used to find 'Notification' objects.
            /// </summary>
            /// <param name="id">Find the Notification with this id</param>
            /// <param name="tempNotification">Pass in a tempNotification to perform a custom find.</param>
            public Notification FindNotification(int id, Notification tempNotification = null)
            {
                // initial value
                Notification notification = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempNotification does not exist
                    if (tempNotification == null)
                    {
                        // create a temp Notification
                        tempNotification = new Notification();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempNotification.UpdateIdentity(id);
                    }

                    // perform the find
                    notification = this.AppController.ControllerManager.NotificationController.Find(tempNotification);
                }

                // return value
                return notification;
            }
            #endregion

            #region FindNotificationBy(string emailAddress)
            /// <summary>
            /// This method is used to find 'Notification' objects for the EmailAddress given.
            /// </summary>
            public Notification FindNotificationBy(string emailAddress)
            {
                // initial value
                Notification notification = null;
                
                // Create a temp Notification object
                Notification tempNotification = new Notification();
                
                // Set the value for FindBy to true
                tempNotification.FindBy = true;
                
                // Set the value for EmailAddress
                tempNotification.EmailAddress = emailAddress;
                
                // Perform the find
                notification = FindNotification(0, tempNotification);
                
                // return value
                return notification;
            }
            #endregion
            
            #region FindNotificationByEmailAddress(string emailAddress)
            /// <summary>
            /// This method is used to find 'Notification' objects for the EmailAddress given.
            /// </summary>
            public Notification FindNotificationByEmailAddress(string emailAddress)
            {
                // initial value
                Notification notification = null;
                
                // Create a temp Notification object
                Notification tempNotification = new Notification();
                
                // Set the value for FindByEmailAddress to true
                tempNotification.FindByEmailAddress = true;
                
                // Set the value for EmailAddress
                tempNotification.EmailAddress = emailAddress;
                
                // Perform the find
                notification = FindNotification(0, tempNotification);
                
                // return value
                return notification;
            }
            #endregion
            
            #region FindNotificationHistory(int id, NotificationHistory tempNotificationHistory = null)
            /// <summary>
            /// This method is used to find 'NotificationHistory' objects.
            /// </summary>
            /// <param name="id">Find the NotificationHistory with this id</param>
            /// <param name="tempNotificationHistory">Pass in a tempNotificationHistory to perform a custom find.</param>
            public NotificationHistory FindNotificationHistory(int id, NotificationHistory tempNotificationHistory = null)
            {
                // initial value
                NotificationHistory notificationHistory = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempNotificationHistory does not exist
                    if (tempNotificationHistory == null)
                    {
                        // create a temp NotificationHistory
                        tempNotificationHistory = new NotificationHistory();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempNotificationHistory.UpdateIdentity(id);
                    }

                    // perform the find
                    notificationHistory = this.AppController.ControllerManager.NotificationHistoryController.Find(tempNotificationHistory);
                }

                // return value
                return notificationHistory;
            }
            #endregion

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                this.AppController = new ApplicationController();
            }
            #endregion

            #region LoadGitHubFollowers(GitHubFollower tempGitHubFollower = null)
            /// <summary>
            /// This method loads a collection of 'GitHubFollower' objects.
            /// </summary>
            public List<GitHubFollower> LoadGitHubFollowers(GitHubFollower tempGitHubFollower = null)
            {
                // initial value
                List<GitHubFollower> gitHubFollowers = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    gitHubFollowers = this.AppController.ControllerManager.GitHubFollowerController.FetchAll(tempGitHubFollower);
                }

                // return value
                return gitHubFollowers;
            }
            #endregion

            #region LoadNotificationHistorys(NotificationHistory tempNotificationHistory = null)
            /// <summary>
            /// This method loads a collection of 'NotificationHistory' objects.
            /// </summary>
            public List<NotificationHistory> LoadNotificationHistorys(NotificationHistory tempNotificationHistory = null)
            {
                // initial value
                List<NotificationHistory> notificationHistorys = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    notificationHistorys = this.AppController.ControllerManager.NotificationHistoryController.FetchAll(tempNotificationHistory);
                }

                // return value
                return notificationHistorys;
            }
            #endregion

            #region LoadNotifications(Notification tempNotification = null)
            /// <summary>
            /// This method loads a collection of 'Notification' objects.
            /// </summary>
            public List<Notification> LoadNotifications(Notification tempNotification = null)
            {
                // initial value
                List<Notification> notifications = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    notifications = this.AppController.ControllerManager.NotificationController.FetchAll(tempNotification);
                }

                // return value
                return notifications;
            }
            #endregion

            #region SaveGitHubFollower(ref GitHubFollower gitHubFollower)
            /// <summary>
            /// This method is used to save 'GitHubFollower' objects.
            /// </summary>
            /// <param name="gitHubFollower">The GitHubFollower to save.</param>
            public bool SaveGitHubFollower(ref GitHubFollower gitHubFollower)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.GitHubFollowerController.Save(ref gitHubFollower);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveNotification(ref Notification notification)
            /// <summary>
            /// This method is used to save 'Notification' objects.
            /// </summary>
            /// <param name="notification">The Notification to save.</param>
            public bool SaveNotification(ref Notification notification)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.NotificationController.Save(ref notification);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveNotificationHistory(ref NotificationHistory notificationHistory)
            /// <summary>
            /// This method is used to save 'NotificationHistory' objects.
            /// </summary>
            /// <param name="notificationHistory">The NotificationHistory to save.</param>
            public bool SaveNotificationHistory(ref NotificationHistory notificationHistory)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.NotificationHistoryController.Save(ref notificationHistory);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

        #region AppController
        /// <summary>
        /// This property gets or sets the value for 'AppController'.
        /// </summary>
        public ApplicationController AppController
        {
            get { return appController; }
            set { appController = value; }
        }
        #endregion

        #region HasAppController
        /// <summary>
        /// This property returns true if this object has an 'AppController'.
        /// </summary>
        public bool HasAppController
        {
            get
            {
                // initial value
                bool hasAppController = (this.AppController != null);

                // return value
                return hasAppController;
            }
        }
        #endregion

        #endregion

    }
    #endregion

}
