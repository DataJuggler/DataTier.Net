

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
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
                int orderByFieldIdfield = 5;
                int orderByFieldSetIdfield = 6;
                int orderByTypefield = 7;
                int parameterFieldIdfield = 8;
                int parametersfield = 9;
                int parametersFieldSetIdfield = 10;
                int parameterTypefield = 11;
                int procedureNamefield = 12;
                int procedureTextfield = 13;
                int projectIdfield = 14;
                int propertyNamefield = 15;
                int tableIdfield = 16;
                int updateProcedureOnBuildfield = 17;
                int useCustomReaderfield = 18;

                try
                {
                    // Load Each field
                    method.Active = DataHelper.ParseBoolean(dataRow.ItemArray[activefield], false);
                    method.CustomReaderId = DataHelper.ParseInteger(dataRow.ItemArray[customReaderIdfield], 0);
                    method.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[methodIdfield], 0));
                    method.MethodType = (MethodTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[methodTypefield], 0);
                    method.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
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
                    method.UpdateProcedureOnBuild = DataHelper.ParseBoolean(dataRow.ItemArray[updateProcedureOnBuildfield], false);
                    method.UseCustomReader = DataHelper.ParseBoolean(dataRow.ItemArray[useCustomReaderfield], false);
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
