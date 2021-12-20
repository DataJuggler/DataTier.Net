

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class UIField
    public partial class UIField
    {

        #region Private Variables
        private string caption;
        private DataTypeEnum dataType;
        private int dTNFieldId;
        private int fieldOrdinal;
        private int id;
        private int maxLength;
        private double maxRange;
        private int minLength;
        private double minRange;
        private bool required;
        private int userInterfaceId;
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
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string Caption
            public string Caption
            {
                get
                {
                    return caption;
                }
                set
                {
                    caption = value;
                }
            }
            #endregion

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

            #region int DTNFieldId
            public int DTNFieldId
            {
                get
                {
                    return dTNFieldId;
                }
                set
                {
                    dTNFieldId = value;
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

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region int MaxLength
            public int MaxLength
            {
                get
                {
                    return maxLength;
                }
                set
                {
                    maxLength = value;
                }
            }
            #endregion

            #region double MaxRange
            public double MaxRange
            {
                get
                {
                    return maxRange;
                }
                set
                {
                    maxRange = value;
                }
            }
            #endregion

            #region int MinLength
            public int MinLength
            {
                get
                {
                    return minLength;
                }
                set
                {
                    minLength = value;
                }
            }
            #endregion

            #region double MinRange
            public double MinRange
            {
                get
                {
                    return minRange;
                }
                set
                {
                    minRange = value;
                }
            }
            #endregion

            #region bool Required
            public bool Required
            {
                get
                {
                    return required;
                }
                set
                {
                    required = value;
                }
            }
            #endregion

            #region int UserInterfaceId
            public int UserInterfaceId
            {
                get
                {
                    return userInterfaceId;
                }
                set
                {
                    userInterfaceId = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
