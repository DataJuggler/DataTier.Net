

#region using statements

using System;
using System.Collections.Generic;
using System.Data;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class CustomReaderReader
    /// <summary>
    /// This class loads a single 'CustomReader' object or a list of type <CustomReader>.
    /// </summary>
    public class CustomReaderReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'CustomReader' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'CustomReader' DataObject.</returns>
            public static CustomReader Load(DataRow dataRow)
            {
                // Initial Value
                CustomReader customReader = new CustomReader();

                // Create field Integers
                int classNamefield = 0;
                int customReaderIdfield = 1;
                int fieldSetIdfield = 2;
                int fileNamefield = 3;
                int readerNamefield = 4;
                int tableIdfield = 5;

                try
                {
                    // Load Each field
                    customReader.ClassName = DataHelper.ParseString(dataRow.ItemArray[classNamefield]);
                    customReader.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[customReaderIdfield], 0));
                    customReader.FieldSetId = DataHelper.ParseInteger(dataRow.ItemArray[fieldSetIdfield], 0);
                    customReader.FileName = DataHelper.ParseString(dataRow.ItemArray[fileNamefield]);
                    customReader.ReaderName = DataHelper.ParseString(dataRow.ItemArray[readerNamefield]);
                    customReader.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                }
                catch
                {
                }

                // return value
                return customReader;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'CustomReader' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A CustomReader Collection.</returns>
            public static List<CustomReader> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<CustomReader> customReaders = new List<CustomReader>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'CustomReader' from rows
                        CustomReader customReader = Load(row);

                        // Add this object to collection
                        customReaders.Add(customReader);
                    }
                }
                catch
                {
                }

                // return value
                return customReaders;
            }
            #endregion

        #endregion

    }
    #endregion

}
