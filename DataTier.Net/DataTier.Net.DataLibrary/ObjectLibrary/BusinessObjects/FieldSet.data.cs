

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSet
    public partial class FieldSet
    {

        #region Private Variables
        private int databaseId;
        private int fieldSetId;
        private string name;
        private bool orderByMode;
        private bool parameterMode;
        private int projectId;
        private bool readerMode;
        private int tableId;
        private bool delete;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.fieldSetId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int DatabaseId
            public int DatabaseId
            {
                get
                {
                    return databaseId;
                }
                set
                {
                    databaseId = value;
                }
            }
            #endregion

            #region int FieldSetId
            public int FieldSetId
            {
                get
                {
                    return fieldSetId;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region bool OrderByMode
            public bool OrderByMode
            {
                get
                {
                    return orderByMode;
                }
                set
                {
                    orderByMode = value;
                }
            }
            #endregion

            #region bool ParameterMode
            public bool ParameterMode
            {
                get
                {
                    return parameterMode;
                }
                set
                {
                    parameterMode = value;
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

            #region bool ReaderMode
            public bool ReaderMode
            {
                get
                {
                    return readerMode;
                }
                set
                {
                    readerMode = value;
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

            #region bool Delete
            public bool Delete
            {
                get
                {
                    return delete;
                }
                set
                {
                    delete = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.FieldSetId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
