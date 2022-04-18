

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ControlInfoDetail
    public partial class ControlInfoDetail
    {

        #region Private Variables
        private string codeText;
        private int displayOrder;
        private int id;
        private int uIControlId;
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

            #region string CodeText
            public string CodeText
            {
                get
                {
                    return codeText;
                }
                set
                {
                    codeText = value;
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

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region int UIControlId
            public int UIControlId
            {
                get
                {
                    return uIControlId;
                }
                set
                {
                    uIControlId = value;
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
