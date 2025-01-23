

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ReferencesSet
    [Serializable]
    public partial class ReferencesSet
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ReferencesSet()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ReferencesSet Clone()
            {
                // Create New Object
                ReferencesSet newReferencesSet = (ReferencesSet) this.MemberwiseClone();

                // Return Cloned Object
                return newReferencesSet;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
