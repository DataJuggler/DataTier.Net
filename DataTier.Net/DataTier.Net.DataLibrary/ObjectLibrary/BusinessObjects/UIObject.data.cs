

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class UIObject
    public partial class UIObject
    {

        #region Private Variables
        private int controlType;
        private int displayOrder;
        private int formType;
        private int height;
        private int id;
        private bool isControl;
        private bool isForm;
        private int left;
        private string name;
        private int parentId;
        private int top;
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

            #region int FormType
            public int FormType
            {
                get
                {
                    return formType;
                }
                set
                {
                    formType = value;
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

            #region bool IsControl
            public bool IsControl
            {
                get
                {
                    return isControl;
                }
                set
                {
                    isControl = value;
                }
            }
            #endregion

            #region bool IsForm
            public bool IsForm
            {
                get
                {
                    return isForm;
                }
                set
                {
                    isForm = value;
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

            #region int ParentId
            public int ParentId
            {
                get
                {
                    return parentId;
                }
                set
                {
                    parentId = value;
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
