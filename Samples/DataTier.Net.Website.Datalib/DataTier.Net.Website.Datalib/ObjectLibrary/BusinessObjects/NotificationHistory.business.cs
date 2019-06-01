

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class NotificationHistory
    [Serializable]
    public partial class NotificationHistory
    {

        #region Private Variables
        #endregion

        #region Constructor
        public NotificationHistory()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public NotificationHistory Clone()
            {
                // Create New Object
                NotificationHistory newNotificationHistory = (NotificationHistory) this.MemberwiseClone();

                // Return Cloned Object
                return newNotificationHistory;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
