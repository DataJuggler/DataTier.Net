

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ProjectReference
    public partial class ProjectReference
    {

        #region Private Variables
        private string referenceName;
        private int referencesId;
        private int referencesSetId;
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
                this.referencesId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string ReferenceName
            public string ReferenceName
            {
                get
                {
                    return referenceName;
                }
                set
                {
                    referenceName = value;
                }
            }
            #endregion

            #region int ReferencesId
            public int ReferencesId
            {
                get
                {
                    return referencesId;
                }
            }
            #endregion

            #region int ReferencesSetId
            public int ReferencesSetId
            {
                get
                {
                    return referencesSetId;
                }
                set
                {
                    referencesSetId = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.ReferencesId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
