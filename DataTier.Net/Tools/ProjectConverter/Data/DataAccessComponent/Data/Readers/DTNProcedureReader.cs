

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class DTNProcedureReader
    /// <summary>
    /// This class loads a single 'DTNProcedure' object or a list of type <DTNProcedure>.
    /// </summary>
    public class DTNProcedureReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'DTNProcedure' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'DTNProcedure' DataObject.</returns>
            public static DTNProcedure Load(DataRow dataRow)
            {
                // Initial Value
                DTNProcedure dTNProcedure = new DTNProcedure();

                // Create field Integers
                int activefield = 0;
                int namefield = 1;
                int procedureIdfield = 2;
                int projectIdfield = 3;
                int tableIdfield = 4;

                try
                {
                    // Load Each field
                    dTNProcedure.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    dTNProcedure.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    dTNProcedure.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[procedureIdfield], 0));
                    dTNProcedure.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    dTNProcedure.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                }
                catch
                {
                }

                // return value
                return dTNProcedure;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'DTNProcedure' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A DTNProcedure Collection.</returns>
            public static List<DTNProcedure> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<DTNProcedure> dTNProcedures = new List<DTNProcedure>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'DTNProcedure' from rows
                        DTNProcedure dTNProcedure = Load(row);

                        // Add this object to collection
                        dTNProcedures.Add(dTNProcedure);
                    }
                }
                catch
                {
                }

                // return value
                return dTNProcedures;
            }
            #endregion

        #endregion

    }
    #endregion

}
