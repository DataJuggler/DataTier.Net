

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class CustomReader
    public partial class CustomReader
    {

        #region Private Variables
        private string className;
        private int customReaderId;
        private int fieldSetId;
        private string fileName;
        private string readerName;
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
                this.customReaderId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string ClassName
            public string ClassName
            {
                get
                {
                    return className;
                }
                set
                {
                    className = value;
                }
            }
            #endregion

            #region int CustomReaderId
            public int CustomReaderId
            {
                get
                {
                    return customReaderId;
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
                set
                {
                    fieldSetId = value;
                }
            }
            #endregion

            #region string FileName
            public string FileName
            {
                get
                {
                    return fileName;
                }
                set
                {
                    fileName = value;
                }
            }
            #endregion

            #region string ReaderName
            public string ReaderName
            {
                get
                {
                    return readerName;
                }
                set
                {
                    readerName = value;
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
                    bool isNew = (this.CustomReaderId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
