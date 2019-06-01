

#region using statements

using System;
using System.Collections.Generic;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNDatabase
    [Serializable]
    public partial class DTNDatabase
    {

        #region Private Variables
        private List<DTNTable> tables;
        #endregion

        #region Constructor
        public DTNDatabase()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DTNDatabase Clone()
            {
                // Create New Object
                DTNDatabase newDTNDatabase = (DTNDatabase) this.MemberwiseClone();

                // Return Cloned Object
                return newDTNDatabase;
            }
            #endregion

            #region ToString()
            /// <summary>
            /// This method is called when ToString() is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // return the name of the database
                return this.DatabaseName;
            } 
            #endregion

        #endregion

        #region Properties

            #region Tables
            /// <summary>
            /// This property gets or sets the value for 'Tables'.
            /// </summary>
            public List<DTNTable> Tables
            {
                get { return tables; }
                set { tables = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
