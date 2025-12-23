
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Method
    [Serializable]
    public partial class Method
    {

        #region Private Variables
        private bool findByName;
        private CustomReader customReader;
        private bool loadByTableId;
        private bool loadByProjectId;
        #endregion

        #region Constructor
        public Method()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Method Clone()
            {
                // Create New Object
                Method newMethod = (Method) this.MemberwiseClone();

                // Return Cloned Object
                return newMethod;
            }
            #endregion

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // return the name when ToString() is called
                return this.Name;
            }
            #endregion

        #endregion

        #region Properties

            #region CustomReader
            /// <summary>
            /// This property gets or sets the value for 'CustomReader'.
            /// </summary>
            public CustomReader CustomReader
            {
                get { return customReader; }
                set { customReader = value; }
            }
            #endregion
            
            #region FindByName
            /// <summary>
            /// This property gets or sets the value for 'FindByName'.
            /// </summary>
            public bool FindByName
            {
                get { return findByName; }
                set { findByName = value; }
            }
            #endregion

            #region HasCustomReader
            /// <summary>
            /// This property returns true if this object has a 'CustomReader'.
            /// </summary>
            public bool HasCustomReader
            {
                get
                {
                    // initial value
                    bool hasCustomReader = (CustomReader != null);

                    // return value
                    return hasCustomReader;
                }
            }
            #endregion

            #region HasProjectId
            /// <summary>
            /// This property returns true if the 'ProjectId' is set.
            /// </summary>
            public bool HasProjectId
            {
                get
                {
                    // initial value
                    bool hasProjectId = (this.ProjectId > 0);
                    
                    // return value
                    return hasProjectId;
                }
            }
            #endregion

            #region HasTableId
            /// <summary>
            /// This property returns true if the 'TableId' is set.
            /// </summary>
            public bool HasTableId
            {
                get
                {
                    // initial value
                    bool hasTableId = (this.TableId > 0);
                    
                    // return value
                    return hasTableId;
                }
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

            #region LoadByTableId
            /// <summary>
            /// This property gets or sets the value for 'LoadByTableId'.
            /// </summary>
            public bool LoadByTableId
            {
                get { return loadByTableId; }
                set { loadByTableId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
