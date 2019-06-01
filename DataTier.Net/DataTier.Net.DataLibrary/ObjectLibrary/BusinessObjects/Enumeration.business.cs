

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Enumeration
    [Serializable]
    public partial class Enumeration
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Enumeration()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Enumeration Clone()
            {
                // Create New Object
                Enumeration newEnumeration = (Enumeration) this.MemberwiseClone();

                // Return Cloned Object
                return newEnumeration;
            }
            #endregion

            #region ToString()
			/// <summary>
			/// This method is used to override the ToString()
			/// method.
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				// initial value
				string returnText = "<Enumeration>";
				
				// if the field name exists
				if(!String.IsNullOrEmpty(this.FieldName))
				{
					// Set the field name
					returnText = this.FieldName;
				}
				
				// return value
				return returnText;
			} 
			#endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
