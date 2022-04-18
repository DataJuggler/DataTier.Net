

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ControlInfoDetailReader
    /// <summary>
    /// This class loads a single 'ControlInfoDetail' object or a list of type <ControlInfoDetail>.
    /// </summary>
    public class ControlInfoDetailReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ControlInfoDetail' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ControlInfoDetail' DataObject.</returns>
            public static ControlInfoDetail Load(DataRow dataRow)
            {
                // Initial Value
                ControlInfoDetail controlInfoDetail = new ControlInfoDetail();

                // Create field Integers
                int codeTextfield = 0;
                int displayOrderfield = 1;
                int idfield = 2;
                int uIControlIdfield = 3;

                try
                {
                    // Load Each field
                    controlInfoDetail.CodeText = DataHelper.ParseString(dataRow.ItemArray[codeTextfield]);
                    controlInfoDetail.DisplayOrder = DataHelper.ParseInteger(dataRow.ItemArray[displayOrderfield], 0);
                    controlInfoDetail.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    controlInfoDetail.UIControlId = DataHelper.ParseInteger(dataRow.ItemArray[uIControlIdfield], 0);
                }
                catch
                {
                }

                // return value
                return controlInfoDetail;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ControlInfoDetail' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ControlInfoDetail Collection.</returns>
            public static List<ControlInfoDetail> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ControlInfoDetail> controlInfoDetails = new List<ControlInfoDetail>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ControlInfoDetail' from rows
                        ControlInfoDetail controlInfoDetail = Load(row);

                        // Add this object to collection
                        controlInfoDetails.Add(controlInfoDetail);
                    }
                }
                catch
                {
                }

                // return value
                return controlInfoDetails;
            }
            #endregion

        #endregion

    }
    #endregion

}
