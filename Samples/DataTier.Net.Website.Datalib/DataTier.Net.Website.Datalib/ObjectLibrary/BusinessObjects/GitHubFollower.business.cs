

#region using statements

using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class GitHubFollower
    [Serializable]
    public partial class GitHubFollower
    {

        #region Private Variables
        #endregion

        #region Constructor
        public GitHubFollower()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public GitHubFollower Clone()
            {
                // Create New Object
                GitHubFollower newGitHubFollower = (GitHubFollower) this.MemberwiseClone();

                // Return Cloned Object
                return newGitHubFollower;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
