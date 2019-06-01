
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using ApplicationLogicComponent.DataBridge;

#endregion

namespace ApplicationLogicComponent.DataOperations
{

    #region class PolymorphicObject
    /// <summary>
    /// This object can hold any type of object.
    /// Yes I know System.Object can hold these values also,
    /// but this has nullable boolean, integers, doubles & dates.
    /// This object can hold a data set to a collection of DataObjects.
    /// </summary>
    public class PolymorphicObject
    {

        #region Private Variables
        private NullableBoolean boolean;
        private DataSet dataSet;
        private int integerValue;
        private string text;
        private string name;
        private object objectValue;
        #endregion

        #region Constructor

        #region Default Constructor
        /// <summary>
        /// Creates a new instance of this PolymorphicObject
        /// </summary>
        public PolymorphicObject()
        {

        }
        #endregion

        #region Parameterized Constructor
        /// <summary>
        /// Creates a new instance of this PolymorphicObject
        /// </summary>
        public PolymorphicObject(object valueArg)
        {
            // Converts the object passed in to a value 
            // used by this PolymorphicObject.
            SetObjectValue(valueArg);
        }
        #endregion

        #endregion

        #region Methods

        #region Name
        /// <summary>
        /// The name of this object.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region SetObjectValue(object valueArg)
        /// <summary>
        /// This method casts the object until the correct type is found.
        /// </summary>
        /// <param name="valueArg"></param>
        private void SetObjectValue(object valueArg)
        {
            // Cast object to whatever type is needed.
            if (valueArg is bool)
            {
                // This is a system boolean, this must be converted to 
                // a RADBoolean
            }
        }
        #endregion

        #endregion

        #region Properties

        #region Boolean
        /// <summary>
        /// This property represents a nullable boolean, with 
        /// values for true, false, & null.
        /// </summary>
        public NullableBoolean Boolean
        {
            get { return boolean; }
            set { boolean = value; }
        }
        #endregion

        #region DataSet
        /// <summary>
        /// This property holds a DataSet if needed.
        /// </summary>
        public DataSet DataSet
        {
            get { return dataSet; }
            set { dataSet = value; }
        }
        #endregion

        #region IntegerValue
        /// <summary>
        /// The return value from a DataOperation
        /// that uses an int value.
        /// </summary>
        public int IntegerValue
        {
            get { return integerValue; }
            set { integerValue = value; }
        }
        #endregion

        #region ObjectValue
        /// <summary>
        /// The actual object to store as the value for this object.
        /// </summary>
        public object ObjectValue
        {
            get { return objectValue; }
            set { objectValue = value; }
        }
        #endregion

        #region Text
        /// <summary>
        /// The string text value if this object's value is a string
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}