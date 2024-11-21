

#region using statements

using System;
using System.Collections.Generic;
using System.Text;

#endregion


namespace DataAccessComponent.DataBridge
{

    #region NullableBoolean
    /// <summary>
    /// This class is a nullable boolean.
    /// It has values for true, false & null
    /// </summary>
    public class NullableBoolean
    {

        #region Private Variables
        private NullableBooleanEnum value;
        #endregion

        #region Constructors

        #region Default Constructor
        /// <summary>
        /// Creaetes a new instance of a NullableBoolean
        /// </summary>
        public NullableBoolean()
        {
            // Set Value
            this.Value = NullableBooleanEnum.Null;
        }
        #endregion

        #region Parameterized Constructor
        /// <summary>
        /// Creaetes a new instance of a NullableBoolean
        /// </summary>
        public NullableBoolean(bool objectValue)
        {
            // set value
            if (objectValue == true)
            {
                // Set value to true
                this.Value = NullableBooleanEnum.True;
            }
            else
            {
                // Set value to false
                this.Value = NullableBooleanEnum.False;
            }
        }
        #endregion

        #endregion

        #region Properties

        #region Value
        /// <summary>
        /// The current setting for this object.
        /// </summary>
        public NullableBooleanEnum Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
