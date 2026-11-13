
#region using statements

using System;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class BuildExcludes
    [Serializable]
    public partial class BuildExcludes
    {

        #region Private Variables
        private bool findByTableId;
        private bool loadByProjectId;
        #endregion

        #region Constructor
        public BuildExcludes()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public BuildExcludes Clone()
            {
                // Create New Object
                BuildExcludes newBuildExcludes = (BuildExcludes) this.MemberwiseClone();

                // Return Cloned Object
                return newBuildExcludes;
            }
            #endregion
            
        #endregion

        #region Properties

            #region ExcludesCount
            /// <summary>
            /// This read only property returns the number of items excluded
            /// </summary>
            public int ExcludesCount
            {

                get
                {
                    // initial value
                    int excludesCount = 0;

                    // if the value for ExcludeDelete is true
                    if (ExcludeDelete)
                    {
                        // Increment the value for excludesCount
                        excludesCount++;
                    }

                    // if the value for ExcludeFetchAll is true
                    if (ExcludeFetchAll)
                    {
                        // Increment the value for excludesCount
                        excludesCount++;
                    }

                    // if the value for ExcludeFind is true
                    if (ExcludeFind)
                    {
                        // Increment the value for excludesCount
                        excludesCount++;
                    }

                    // if the value for ExcludeInsert is true
                    if (ExcludeInsert)
                    {
                        // Increment the value for excludesCount
                        excludesCount++;
                    }

                    // if the value for ExcludeUpdate is true
                    if (ExcludeUpdate)
                    {
                        // Increment the value for excludesCount
                        excludesCount++;
                    }

                    // return value
                    return excludesCount;
                }
            }
            #endregion

            #region FindByTableId
            /// <summary>
            /// This property gets or sets the value for 'FindByTableId'.
            /// </summary>
            public bool FindByTableId
            {
                get { return findByTableId; }
                set { findByTableId = value; }
            }
            #endregion

            #region LoadByProjectId
            /// <summary>
            /// This property gets or sets the value for 'LoadByProjectId'.
            /// </summary>
            public bool LoadByProjectId
            {
                get { return loadByProjectId; }
                set { loadByProjectId = value; }
            }
            #endregion

            #region NothingExcluded
            /// <summary>
            /// This read only property returns true if all five exclude values are false
            /// </summary>
            public bool NothingExcluded
            {
                get
                {
                    // initial value
                    bool nothingExcluded = false;

                    // if none of the exclude values are set
                    if ((!ExcludeDelete) && (!ExcludeFetchAll) && (!ExcludeFind) && (!ExcludeInsert) && (!ExcludeUpdate))
                    {
                        // set the return value
                        nothingExcluded = true;
                    }

                    // return value
                    return nothingExcluded;
                }
            }
#endregion

            #region ScheduledForDelete
            /// <summary>
            /// This read only property returns true if this is an existing record and nothing is excluded
            /// </summary>
            public bool ScheduledForDelete
            {
                get
                {
                    // initial value
                    bool scheduledForDelete = ((!IsNew) && (NothingExcluded));

                    // return value
                    return scheduledForDelete;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
