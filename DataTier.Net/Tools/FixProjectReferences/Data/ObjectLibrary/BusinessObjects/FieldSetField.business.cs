

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSetField
    [Serializable]
    public partial class FieldSetField
    {

        #region Private Variables
        #endregion

        #region Constructor
        public FieldSetField()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public FieldSetField Clone()
            {
                // Create New Object
                FieldSetField newFieldSetField = (FieldSetField) this.MemberwiseClone();

                // Return Cloned Object
                return newFieldSetField;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
