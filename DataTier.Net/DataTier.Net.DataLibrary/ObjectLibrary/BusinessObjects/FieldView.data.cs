

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldView
    public partial class FieldView
    {

        #region Private Variables
        private DataTypeEnum dataType;
        private bool exclude;
        private string fieldName;
        private int isNullable;
        private int projectId;
        private int tableId;
        private string tableName;
        #endregion

        #region Methods

            #region GetValue(string fieldName)
            // <summary>
            // This method returns the value for the fieldName given
            // </summary>
            public object GetValue(string fieldName)
            {
                // initial value
                object value = "";

                // // Determine the action by the fieldName
                switch (fieldName)
                {
                    case "DataType":

                        // set the value
                        value = this.DataType;

                        // required
                        break;

                    case "Exclude":

                        // set the value
                        value = this.Exclude;

                        // required
                        break;

                    case "FieldName":

                        // set the value
                        value = this.FieldName;

                        // required
                        break;

                    case "IsNullable":

                        // set the value
                        value = this.IsNullable;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "TableId":

                        // set the value
                        value = this.TableId;

                        // required
                        break;

                    case "TableName":

                        // set the value
                        value = this.TableName;

                        // required
                        break;

                }

                // return value
                return value;
            }
            #endregion


        #endregion

        #region Properties

            #region DataTypeEnum DataType
            public DataTypeEnum DataType
            {
                get
                {
                    return dataType;
                }
                set
                {
                    dataType = value;
                }
            }
            #endregion

            #region bool Exclude
            public bool Exclude
            {
                get
                {
                    return exclude;
                }
                set
                {
                    exclude = value;
                }
            }
            #endregion

            #region string FieldName
            public string FieldName
            {
                get
                {
                    return fieldName;
                }
                set
                {
                    fieldName = value;
                }
            }
            #endregion

            #region int IsNullable
            public int IsNullable
            {
                get
                {
                    return isNullable;
                }
                set
                {
                    isNullable = value;
                }
            }
            #endregion

            #region int ProjectId
            public int ProjectId
            {
                get
                {
                    return projectId;
                }
                set
                {
                    projectId = value;
                }
            }
            #endregion

            #region int TableId
            public int TableId
            {
                get
                {
                    return tableId;
                }
                set
                {
                    tableId = value;
                }
            }
            #endregion

            #region string TableName
            public string TableName
            {
                get
                {
                    return tableName;
                }
                set
                {
                    tableName = value;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
