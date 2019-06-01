

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class GitHubFollower
    public partial class GitHubFollower
    {

        #region Private Variables
        private bool active;
        private string emailAddress;
        private string followerName;
        private DateTime followerSince;
        private int id;
        private int notificationId;
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

            #region string FollowerName
            public string FollowerName
            {
                get
                {
                    return followerName;
                }
                set
                {
                    followerName = value;
                }
            }
            #endregion

            #region DateTime FollowerSince
            public DateTime FollowerSince
            {
                get
                {
                    return followerSince;
                }
                set
                {
                    followerSince = value;
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

            #region int NotificationId
            public int NotificationId
            {
                get
                {
                    return notificationId;
                }
                set
                {
                    notificationId = value;
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
