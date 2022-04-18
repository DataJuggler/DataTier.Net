

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
        private string fieldName;
        private int isNullable;
        private int projectId;
        private int tableId;
        private string tableName;
        #endregion

        #region Methods


        #endregion

        #region Properties

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
