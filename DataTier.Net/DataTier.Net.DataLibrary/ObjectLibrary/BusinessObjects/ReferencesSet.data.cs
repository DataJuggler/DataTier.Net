

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ReferencesSet
    public partial class ReferencesSet
    {

        #region Private Variables
        private int projectId;
        private int referencesSetId;
        private string referencesSetName;
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
                this.referencesSetId = id;
            }
            #endregion

        #endregion

        #region Properties

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

            #region int ReferencesSetId
            public int ReferencesSetId
            {
                get
                {
                    return referencesSetId;
                }
            }
            #endregion

            #region string ReferencesSetName
            public string ReferencesSetName
            {
                get
                {
                    return referencesSetName;
                }
                set
                {
                    referencesSetName = value;
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
                    bool isNew = (this.ReferencesSetId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
