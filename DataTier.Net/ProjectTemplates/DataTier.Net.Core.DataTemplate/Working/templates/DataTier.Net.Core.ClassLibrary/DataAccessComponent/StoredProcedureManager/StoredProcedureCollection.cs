

#region using statements

using System;
using System.Collections;
using System.Text;

#endregion


namespace DataAccessComponent.StoredProcedureManager
{
    public class StoredProcedureCollection : CollectionBase
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a 'StoredProcedureCollection' object.
        /// </summary>
        public StoredProcedureCollection()
        {

        }
        #endregion

        #region Methods

        #region Add(StoredProcedure storedProcedure)
        /// <summary>
        /// This method adds a 'StoredProcedure' object
        /// to this collection.
        /// </summary>
        /// <param name="storedProcedure"></param>
        public void Add(StoredProcedure storedProcedure)
        {
            // Add this object to this collection
            this.List.Add(storedProcedure);
        }
        #endregion

        #endregion

        #region Properties
        #endregion

    }
}
