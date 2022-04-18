

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
        private int controlType;
        private DataTypeEnum dataType;
        private string defaultValue;
        private int displayOrder;
        private int dTNFieldId;
        private int fieldOrdinal;
        private int height;
        private int id;
        private int left;
        private int maxLength;
        private double maxRange;
        private int minLength;
        private double minRange;
        private bool required;
        private string requiredMessage;
        private int top;
        private int uIObjectId;
        private int userInterfaceId;
        private string validationMessage;
        private int width;
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

            #region int ControlType
            public int ControlType
            {
                get
                {
                    return controlType;
                }
                set
                {
                    controlType = value;
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

            #region string DefaultValue
            public string DefaultValue
            {
                get
                {
                    return defaultValue;
                }
                set
                {
                    defaultValue = value;
                }
            }
            #endregion

            #region int DisplayOrder
            public int DisplayOrder
            {
                get
                {
                    return displayOrder;
                }
                set
                {
                    displayOrder = value;
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

            #region int Height
            public int Height
            {
                get
                {
                    return height;
                }
                set
                {
                    height = value;
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

            #region int Left
            public int Left
            {
                get
                {
                    return left;
                }
                set
                {
                    left = value;
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

            #region string RequiredMessage
            public string RequiredMessage
            {
                get
                {
                    return requiredMessage;
                }
                set
                {
                    requiredMessage = value;
                }
            }
            #endregion

            #region int Top
            public int Top
            {
                get
                {
                    return top;
                }
                set
                {
                    top = value;
                }
            }
            #endregion

            #region int UIObjectId
            public int UIObjectId
            {
                get
                {
                    return uIObjectId;
                }
                set
                {
                    uIObjectId = value;
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

            #region string ValidationMessage
            public string ValidationMessage
            {
                get
                {
                    return validationMessage;
                }
                set
                {
                    validationMessage = value;
                }
            }
            #endregion

            #region int Width
            public int Width
            {
                get
                {
                    return width;
                }
                set
                {
                    width = value;
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
