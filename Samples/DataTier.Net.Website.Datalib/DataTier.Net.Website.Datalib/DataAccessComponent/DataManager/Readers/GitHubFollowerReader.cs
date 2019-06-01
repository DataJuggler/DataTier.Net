

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class GitHubFollowerReader
    /// <summary>
    /// This class loads a single 'GitHubFollower' object or a list of type <GitHubFollower>.
    /// </summary>
    public class GitHubFollowerReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'GitHubFollower' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'GitHubFollower' DataObject.</returns>
            public static GitHubFollower Load(DataRow dataRow)
            {
                // Initial Value
                GitHubFollower gitHubFollower = new GitHubFollower();

                // Create field Integers
                int activefield = 0;
                int emailAddressfield = 1;
                int followerNamefield = 2;
                int followerSincefield = 3;
                int idfield = 4;
                int notificationIdfield = 5;

                try
                {
                    // Load Each field
                    gitHubFollower.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    gitHubFollower.EmailAddress = DataHelper.ParseString(dataRow.ItemArray[emailAddressfield]);
                    gitHubFollower.FollowerName = DataHelper.ParseString(dataRow.ItemArray[followerNamefield]);
                    gitHubFollower.FollowerSince = DataHelper.ParseDate(dataRow.ItemArray[followerSincefield]);
                    gitHubFollower.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    gitHubFollower.NotificationId = DataHelper.ParseInteger(dataRow.ItemArray[notificationIdfield], 0);
                }
                catch
                {
                }

                // return value
                return gitHubFollower;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'GitHubFollower' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A GitHubFollower Collection.</returns>
            public static List<GitHubFollower> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<GitHubFollower> gitHubFollowers = new List<GitHubFollower>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'GitHubFollower' from rows
                        GitHubFollower gitHubFollower = Load(row);

                        // Add this object to collection
                        gitHubFollowers.Add(gitHubFollower);
                    }
                }
                catch
                {
                }

                // return value
                return gitHubFollowers;
            }
            #endregion

        #endregion

    }
    #endregion

}
