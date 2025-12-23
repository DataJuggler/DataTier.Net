

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class EnumerationReader
    /// <summary>
    /// This class loads a single 'Enumeration' object or a list of type <Enumeration>.
    /// </summary>
    public class EnumerationReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Enumeration' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Enumeration' DataObject.</returns>
            public static Enumeration Load(DataRow dataRow)
            {
                // Initial Value
                Enumeration enumeration = new Enumeration();

                // Create field Integers
                int enumerationIdfield = 0;
                int enumerationNamefield = 1;
                int fieldNamefield = 2;
                int projectIdfield = 3;

                try
                {
                    // Load Each field
                    enumeration.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[enumerationIdfield], 0));
                    enumeration.EnumerationName = DataHelper.ParseString(dataRow.ItemArray[enumerationNamefield]);
                    enumeration.FieldName = DataHelper.ParseString(dataRow.ItemArray[fieldNamefield]);
                    enumeration.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                }
                catch
                {
                }

                // return value
                return enumeration;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Enumeration' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Enumeration Collection.</returns>
            public static List<Enumeration> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Enumeration> enumerations = new List<Enumeration>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Enumeration' from rows
                        Enumeration enumeration = Load(row);

                        // Add this object to collection
                        enumerations.Add(enumeration);
                    }
                }
                catch
                {
                }

                // return value
                return enumerations;
            }
            #endregion

        #endregion

    }
    #endregion

}
