

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class NotificationHistory
    public partial class NotificationHistory
    {

        #region Private Variables
        private bool delivered;
        private int id;
        private int notificationId;
        private DateTime sendDate;
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

            #region bool Delivered
            public bool Delivered
            {
                get
                {
                    return delivered;
                }
                set
                {
                    delivered = value;
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
                set
                {
                    id = value;
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

            #region DateTime SendDate
            public DateTime SendDate
            {
                get
                {
                    return sendDate;
                }
                set
                {
                    sendDate = value;
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

        #endregion

    }
    #endregion

}
