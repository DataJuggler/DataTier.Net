

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Notification
    public partial class Notification
    {

        #region Private Variables
        private bool active;
        private DateTime createdDate;
        private string emailAddress;
        private string gitHubUserName;
        private int id;
        private bool lastSentDate;
        private NotificationTypeEnum notificationType;
        private bool verified;
        private bool delete;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region bool Active
            public bool Active
            {
                get
                {
                    return active;
                }
                set
                {
                    active = value;
                }
            }
            #endregion

            #region DateTime CreatedDate
            public DateTime CreatedDate
            {
                get
                {
                    return createdDate;
                }
                set
                {
                    createdDate = value;
                }
            }
            #endregion

            #region string EmailAddress
            public string EmailAddress
            {
                get
                {
                    return emailAddress;
                }
                set
                {
                    emailAddress = value;
                }
            }
            #endregion

            #region string GitHubUserName
            public string GitHubUserName
            {
                get
                {
                    return gitHubUserName;
                }
                set
                {
                    gitHubUserName = value;
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region bool LastSentDate
            public bool LastSentDate
            {
                get
                {
                    return lastSentDate;
                }
                set
                {
                    lastSentDate = value;
                }
            }
            #endregion

            #region NotificationTypeEnum NotificationType
            public NotificationTypeEnum NotificationType
            {
                get
                {
                    return notificationType;
                }
                set
                {
                    notificationType = value;
                }
            }
            #endregion

            #region bool Verified
            public bool Verified
            {
                get
                {
                    return verified;
                }
                set
                {
                    verified = value;
                }
            }
            #endregion

            #region bool Delete
            public bool Delete
            {
                get
                {
                    return delete;
                }
                set
                {
                    delete = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
