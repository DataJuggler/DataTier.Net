
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.Data;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;
using DataAccessComponent.DataBridge;

#endregion

namespace DataAccessComponent.DataOperations
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
        private bool success;
        private NullableBoolean boolean;
        private DataSet dataSet;
        private int integerValue;
        private string text;
        private string name;
        private object objectValue;
        private bool aborted;
        private string abortedReason;
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
            // store the arg
            ObjectValue = valueArg;
        }
        #endregion

        #endregion

        #region Methods

        #endregion

        #region Properties

            #region Aborted
            /// <summary>
            /// This property gets or sets the value for 'Aborted'.
            /// </summary>
            public bool Aborted
            {
                get { return aborted; }
                set { aborted = value; }
            }
            #endregion
            
            #region AbortedReason
            /// <summary>
            /// This property gets or sets the value for 'AbortedReason'.
            /// </summary>
            public string AbortedReason
            {
                get { return abortedReason; }
                set { abortedReason = value; }
            }
            #endregion
            
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

            #region Success
            /// <summary>
            /// This property gets or sets the value for 'Success'.
            /// </summary>
            public bool Success
            {
                get { return success; }
                set { success = value; }
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