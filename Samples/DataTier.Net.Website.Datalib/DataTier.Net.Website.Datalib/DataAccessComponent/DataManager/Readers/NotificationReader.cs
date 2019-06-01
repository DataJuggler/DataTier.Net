

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class NotificationReader
    /// <summary>
    /// This class loads a single 'Notification' object or a list of type <Notification>.
    /// </summary>
    public class NotificationReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Notification' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Notification' DataObject.</returns>
            public static Notification Load(DataRow dataRow)
            {
                // Initial Value
                Notification notification = new Notification();

                // Create field Integers
                int activefield = 0;
                int createdDatefield = 1;
                int emailAddressfield = 2;
                int gitHubUserNamefield = 3;
                int idfield = 4;
                int lastSentDatefield = 5;
                int notificationTypefield = 6;
                int verifiedfield = 7;

                try
                {
                    // Load Each field
                    notification.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    notification.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    notification.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    notification.GitHubUserName = DataHelper.ParseString(dataRow.ItemArray[gitHubUserNamefield]);
                    notification.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    notification.LastSentDate = DataHelper.ParseBoolean(dataRow.ItemArray[lastSentDatefield], false);
                    notification.NotificationType = (NotificationTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[notificationTypefield], 0);
                    notification.Verified = DataHelper.ParseBoolean(dataRow.ItemArray[verifiedfield], false);
                }
                catch
                {
                }

                // return value
                return notification;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Notification' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Notification Collection.</returns>
            public static List<Notification> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Notification> notifications = new List<Notification>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Notification' from rows
                        Notification notification = Load(row);

                        // Add this object to collection
                        notifications.Add(notification);
                    }
                }
                catch
                {
                }

                // return value
                return notifications;
            }
            #endregion

        #endregion

    }
    #endregion

}
