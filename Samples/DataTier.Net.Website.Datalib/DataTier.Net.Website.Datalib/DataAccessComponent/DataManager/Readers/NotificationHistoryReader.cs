

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class NotificationHistoryReader
    /// <summary>
    /// This class loads a single 'NotificationHistory' object or a list of type <NotificationHistory>.
    /// </summary>
    public class NotificationHistoryReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'NotificationHistory' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'NotificationHistory' DataObject.</returns>
            public static NotificationHistory Load(DataRow dataRow)
            {
                // Initial Value
                NotificationHistory notificationHistory = new NotificationHistory();

                // Create field Integers
                int deliveredfield = 0;
                int idfield = 1;
                int notificationIdfield = 2;
                int sendDatefield = 3;

                try
                {
                    // Load Each field
                    notificationHistory.Delivered = DataHelper.ParseBoolean(dataRow.ItemArray[deliveredfield], false);
                    notificationHistory.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    notificationHistory.NotificationId = DataHelper.ParseInteger(dataRow.ItemArray[notificationIdfield], 0);
                    notificationHistory.SendDate = DataHelper.ParseDate(dataRow.ItemArray[sendDatefield]);
                }
                catch
                {
                }

                // return value
                return notificationHistory;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'NotificationHistory' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A NotificationHistory Collection.</returns>
            public static List<NotificationHistory> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<NotificationHistory> notificationHistorys = new List<NotificationHistory>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'NotificationHistory' from rows
                        NotificationHistory notificationHistory = Load(row);

                        // Add this object to collection
                        notificationHistorys.Add(notificationHistory);
                    }
                }
                catch
                {
                }

                // return value
                return notificationHistorys;
            }
            #endregion

        #endregion

    }
    #endregion

}
