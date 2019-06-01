

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSetField
    public partial class FieldSetField
    {

        #region Private Variables
        private int fieldId;
        private int fieldOrdinal;
        private int fieldSetFieldId;
        private int fieldSetId;
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
                this.fieldSetFieldId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int FieldId
            public int FieldId
            {
                get
                {
                    return fieldId;
                }
                set
                {
                    fieldId = value;
                }
            }
            #endregion

            #region int FieldOrdinal
            public int FieldOrdinal
            {
                get
                {
                    return fieldOrdinal;
                }
                set
                {
                    fieldOrdinal = value;
                }
            }
            #endregion

            #region int FieldSetFieldId
            public int FieldSetFieldId
            {
                get
                {
                    return fieldSetFieldId;
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
                    bool isNew = (this.FieldSetFieldId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
