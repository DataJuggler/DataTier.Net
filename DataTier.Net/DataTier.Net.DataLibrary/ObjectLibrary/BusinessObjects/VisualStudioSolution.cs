

#region using statements

using EnvDTE;
using System.Collections.Generic;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class VisualStudioSolution
    /// <summary>
    /// This class is used to return a VisualStudioSolution 
    /// and keep track of the project names to update.
    /// </summary>
    public class VisualStudioSolution
    {   
    
        #region Private Variables
        private Solution solution;
        private string applicationLogicComponentProjectName;
        private string dataAccessComponentProjectName;
        private string objectLibraryProjectName;
        private IList<string> allSolutionProjects;
        #endregion

        #region Constructors

            #region Default Constructor
            /// <summary>
            /// Create a new instance of a VisualStudioSolution object. 
            /// This is used to update the project and include any generated files in 
            /// the solution that are not already present in the solution.
            /// </summary>
            public VisualStudioSolution()
            {
                // perform initializations for this object
                Init();
            }
            #endregion

            #region VisualStudioSolution(Solution solution)
            /// <summary>
            /// Create a new instance of a VisualStudioSolution object. 
            /// This is used to update the project and include any generated files in 
            /// the solution that are not already present in the solution.
            /// </summary>
            /// <param name="solution"></param>
            public VisualStudioSolution(Solution solution) 
            {
                // set the properties for the object
                this.Solution = solution;
                
                // perform initializations for this object
                Init();
            }
            #endregion
        
        #endregion
        
        #region Methods

            #region Init()
            /// <summary>
            /// Perform initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create a list of all solution project names
                this.AllSolutionProjects = new List<string>();
            } 
            #endregion
        
        #endregion
        
        #region Properties

            #region AllSolutionProjects
            /// <summary>
            /// This list is used in case the names of the projects
            /// could not be detected during a read of the solution.
            /// </summary>
            public IList<string> AllSolutionProjects
            {
                get { return allSolutionProjects; }
                set { allSolutionProjects = value; }
            } 
            #endregion

            #region ApplicationLogicComponentProjectName
            /// <summary>
            /// The name of the ALC Project.
            /// </summary>
            public string ApplicationLogicComponentProjectName
            {
                get { return applicationLogicComponentProjectName; }
                set { applicationLogicComponentProjectName = value; }
            }
            #endregion

            #region DataAccessComponentProjectName
            /// <summary>
            /// The name of the DAC project from your Solution.
            /// </summary>
            public string DataAccessComponentProjectName
            {
                get { return dataAccessComponentProjectName; }
                set { dataAccessComponentProjectName = value; }
            }
            #endregion

            #region ObjectLibraryProjectName
            /// <summary>
            /// The name of the ObjectLibrary project.
            /// </summary>
            public string ObjectLibraryProjectName
            {
                get { return objectLibraryProjectName; }
                set { objectLibraryProjectName = value; }
            }
            #endregion
            
            #region Solution
            /// <summary>
            /// The Solution that is to be updated.
            /// </summary>
            public Solution Solution
            {
                get { return solution; }
                set { solution = value; }
            } 
            #endregion
        
        #endregion
        
    } 
    #endregion
    
}
