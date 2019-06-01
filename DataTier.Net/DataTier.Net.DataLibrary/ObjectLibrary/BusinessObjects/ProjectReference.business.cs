

#region using statements

using System;
using System.Collections.Generic;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ProjectReference
    [Serializable]
    public partial class ProjectReference
    {

        #region Private Variables
        #endregion

        #region Constructors

            #region Default Constructor
            /// <summary>
            /// Create a new instance of a 'ProjectReference' object.
            /// </summary>
            public ProjectReference()
            {

            } 
            #endregion

            #region Parameterized Constructor
            /// <summary>
            /// Create a new instance of a 'ProjectReference' object.
            /// </summary>
            /// <param name="referenceName"></param>
            public ProjectReference(string referenceName)
            {
                // set the reference name
                this.ReferenceName = referenceName;
            } 
            #endregion

        #endregion

        #region Methods

            #region Clone()
            public ProjectReference Clone()
            {
                // Create New Object
                ProjectReference newProjectReference = (ProjectReference) this.MemberwiseClone();

                // Return Cloned Object
                return newProjectReference;
            }
            #endregion
            
            #region ToString()
            /// <summary>
            /// This method is used to return the ReferenceName when ToString is called.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // return the name of this reference
                return this.ReferenceName;
            } 
            #endregion

        #endregion

        #region Properties

            #region HasReferenceName
            /// <summary>
            /// This read only property returns true if this object has a ReferenceName
            /// </summary>
            public bool HasReferenceName
            {
                get
                {
                    // initial value
                    bool hasReferenceName = (!String.IsNullOrEmpty(this.ReferenceName));

                    // return value
                    return hasReferenceName;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
