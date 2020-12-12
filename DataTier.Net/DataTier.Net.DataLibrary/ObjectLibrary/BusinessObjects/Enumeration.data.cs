

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Enumeration
    public partial class Enumeration
    {

        #region Private Variables
        private int enumerationId;
        private string enumerationName;
        private string fieldName;
        private int projectId;
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
                this.enumerationId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int EnumerationId
            public int EnumerationId
            {
                get
                {
                    return enumerationId;
                }
            }
            #endregion

            #region string EnumerationName
            public string EnumerationName
            {
                get
                {
                    return enumerationName;
                }
                set
                {
                    enumerationName = value;
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

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.EnumerationId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
