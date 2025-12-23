

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

    #region class MethodReader
    /// <summary>
    /// This class loads a single 'Method' object or a list of type <Method>.
    /// </summary>
    public class MethodReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Method' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Method' DataObject.</returns>
            public static Method Load(DataRow dataRow)
            {
                // Initial Value
                Method method = new Method();

                // Create field Integers
                int activefield = 0;
                int customReaderIdfield = 1;
                int methodIdfield = 2;
                int methodTypefield = 3;
                int namefield = 4;
                int orderByDescendingfield = 5;
                int orderByFieldIdfield = 6;
                int orderByFieldSetIdfield = 7;
                int orderByTypefield = 8;
                int parameterFieldIdfield = 9;
                int parametersfield = 10;
                int parametersFieldSetIdfield = 11;
                int parameterTypefield = 12;
                int procedureNamefield = 13;
                int procedureTextfield = 14;
                int projectIdfield = 15;
                int propertyNamefield = 16;
                int tableIdfield = 17;
                int topRowsfield = 18;
                int updateProcedureOnBuildfield = 19;
                int useCustomReaderfield = 20;
                int useCustomWherefield = 21;
                int whereTextfield = 22;

                try
                {
                    // Load Each field
                    method.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    method.CustomReaderId = DataHelper.ParseInteger(dataRow.ItemArray[customReaderIdfield], 0);
                    method.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[methodIdfield], 0));
                    method.MethodType = (MethodTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[methodTypefield], 0);
                    method.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    method.OrderByDescending = DataHelper.ParseBoolean(dataRow.ItemArray[orderByDescendingfield], false);
                    method.OrderByFieldId = DataHelper.ParseInteger(dataRow.ItemArray[orderByFieldIdfield], 0);
                    method.OrderByFieldSetId = DataHelper.ParseInteger(dataRow.ItemArray[orderByFieldSetIdfield], 0);
                    method.OrderByType = (OrderByTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[orderByTypefield], 0);
                    method.ParameterFieldId = DataHelper.ParseInteger(dataRow.ItemArray[parameterFieldIdfield], 0);
                    method.Parameters = DataHelper.ParseString(dataRow.ItemArray[parametersfield]);
                    method.ParametersFieldSetId = DataHelper.ParseInteger(dataRow.ItemArray[parametersFieldSetIdfield], 0);
                    method.ParameterType = (ParameterTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[parameterTypefield], 0);
                    method.ProcedureName = DataHelper.ParseString(dataRow.ItemArray[procedureNamefield]);
                    method.ProcedureText = DataHelper.ParseString(dataRow.ItemArray[procedureTextfield]);
                    method.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    method.PropertyName = DataHelper.ParseString(dataRow.ItemArray[propertyNamefield]);
                    method.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                    method.TopRows = DataHelper.ParseInteger(dataRow.ItemArray[topRowsfield], 0);
                    method.UpdateProcedureOnBuild = DataHelper.ParseBoolean(dataRow.ItemArray[updateProcedureOnBuildfield], false);
                    method.UseCustomReader = DataHelper.ParseBoolean(dataRow.ItemArray[useCustomReaderfield], false);
                    method.UseCustomWhere = DataHelper.ParseBoolean(dataRow.ItemArray[useCustomWherefield], false);
                    method.WhereText = DataHelper.ParseString(dataRow.ItemArray[whereTextfield]);
                }
                catch
                {
                }

                // return value
                return method;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Method' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Method Collection.</returns>
            public static List<Method> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Method> methods = new List<Method>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Method' from rows
                        Method method = Load(row);

                        // Add this object to collection
                        methods.Add(method);
                    }
                }
                catch
                {
                }

                // return value
                return methods;
            }
            #endregion

        #endregion

    }
    #endregion

}
