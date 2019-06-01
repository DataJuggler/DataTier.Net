

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class ControllerManager
    /// <summary>
    /// This class manages the child controllers for this application.
    /// </summary>
    public class ControllerManager
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        private GitHubFollowerController githubfollowerController;
        private NotificationController notificationController;
        private NotificationHistoryController notificationhistoryController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControllerManager' object.
        /// </summary>
        public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;

            // Create Child Controllers
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child Controllers
            /// </summary>
            private void Init()
            {
                // Create Child Controllers
                this.GitHubFollowerController = new GitHubFollowerController(this.ErrorProcessor, this.AppController);
                this.NotificationController = new NotificationController(this.ErrorProcessor, this.AppController);
                this.NotificationHistoryController = new NotificationHistoryController(this.ErrorProcessor, this.AppController);
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

            #region GitHubFollowerController
            public GitHubFollowerController GitHubFollowerController
            {
                get { return githubfollowerController; }
                set { githubfollowerController = value; }
            }
            #endregion

            #region NotificationController
            public NotificationController NotificationController
            {
                get { return notificationController; }
                set { notificationController = value; }
            }
            #endregion

            #region NotificationHistoryController
            public NotificationHistoryController NotificationHistoryController
            {
                get { return notificationhistoryController; }
                set { notificationhistoryController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
