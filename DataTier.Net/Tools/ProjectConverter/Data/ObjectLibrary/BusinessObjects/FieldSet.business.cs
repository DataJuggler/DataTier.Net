

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSet
    [Serializable]
    public partial class FieldSet
    {

        #region Private Variables
        #endregion

        #region Constructor
        public FieldSet()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public FieldSet Clone()
            {
                // Create New Object
                FieldSet newFieldSet = (FieldSet) this.MemberwiseClone();

                // Return Cloned Object
                return newFieldSet;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
