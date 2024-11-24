

#region using statements

using EnvDTE;
using System;
using System.IO;
using System.Windows.Forms;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Net;
using System.Collections.Generic;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class VisualStudioHelper
    /// <summary>
    /// This class is used to include project files 
    /// after a build.
    /// </summary>
    internal class VisualStudioHelper
    {
       
        #region Static Methods

            #region CheckIfFileExistsInProject(EnvDTE.Project project, ProjectFile projectFile)
            /// <summary>
            /// This method checks if a file exists
            /// </summary>
            /// <param name="project"></param>
            /// <param name="projectFile"></param>
            /// <returns></returns>
            private static bool CheckIfFileExistsInProject(ProjectItems projectItems, ProjectFile projectFile)
            {
                // initial value
                bool fileExists = false;
                
                // iterate project items
                foreach(ProjectItem projectItem in projectItems)
                {  
                    // if the name matches
                    if(projectItem.Name == projectFile.FileName)
                    {
                        // abort this add, file already exists
                        fileExists = true;
                            
                        // break out of loop
                        break;
                    }
                    else if ((projectItem.ProjectItems != null) && (projectItem.ProjectItems.Count > 0))
                    {
                        // check if the file exists in the project
                        fileExists = CheckIfFileExistsInProject(projectItem.ProjectItems, projectFile);
                            
                        // if the file does exist
                        if (fileExists)
                        {
                            // abort this add, file already exists
                            fileExists = true;

                            // break out of loop
                            break;
                        }
                    }
                }
                    
                // return value
                return fileExists;
            }  
            #endregion
            
            #region FindSolution(string solutionFileName)
            /// <summary>
            /// This method updates VisualStudio after a build.
            /// </summary>
            public static VisualStudioSolution FindSolution(string solutionFileName)
            {
                // initial value
                VisualStudioSolution solution = null;
                
                // locals
                DTE dte = null;
                int alcIndex = -1;
                int dacIndex = -1;
                int objectLibraryIndex = -1;
                string projectName = "";
                
                try
                {
                    // if the solution file name exists
                    if ((!String.IsNullOrEmpty(solutionFileName)) && (File.Exists(solutionFileName)))
                    {
                        // Update 3.2.2019: The ObjectType should work from 2019 back to 2010
                        //                          But only 2017 & 2019 have been tested recently
                        Type objectType = GetObjectType();
                           
                        // create an instance of the dte
                        dte = System.Activator.CreateInstance(objectType) as EnvDTE.DTE;
                            
                        // if the dte.Solution object exists
                        if ((dte != null) && (dte.Solution != null))
                        {
                            // register the MessageFilter to interrupt calls
                            MessageFilter.Register();
                            
                            // open the solution
                            dte.Solution.Open(solutionFileName);
                            
                            // verify the solution is open.
                            if (dte.Solution.IsOpen)
                            {
                                // create the solution
                                solution = new VisualStudioSolution(dte.Solution);
                                
                                // iterate projects collection.
                                foreach (EnvDTE.Project project in dte.Solution.Projects)
                                { 
                                    // get the projectName
                                    projectName = project.Name;
                                        
                                    // verify the project name exists
                                    if (!String.IsNullOrEmpty(projectName))
                                    {
                                        // add this project name to all projects.
                                        solution.AllSolutionProjects.Add(projectName);
                                        
                                        // check the index of different names
                                        alcIndex = projectName.IndexOf("ApplicationLogicComponent");
                                        dacIndex = projectName.IndexOf("DataAccessComponent");
                                        objectLibraryIndex = projectName.IndexOf("ObjectLibrary");
                                            
                                        // if the alcIndex was found
                                        if (alcIndex >= 0)
                                        {
                                            // set the project name
                                            solution.ApplicationLogicComponentProjectName = projectName;
                                        }

                                        // if the dacIndex was found
                                        if (dacIndex >= 0)
                                        {
                                            // set the project name
                                            solution.DataAccessComponentProjectName = projectName;
                                        }

                                        // if the dacIndex was found
                                        if (objectLibraryIndex >= 0)
                                        {
                                            // set the project name
                                            solution.ObjectLibraryProjectName = project.Name;
                                        }
                                    }
                                }    
                            }
                                
                            // close the solution
                            dte.Solution.Close(false);

                            // unregister the MessageFilter
                            MessageFilter.Revoke();
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // set the title
                    string title = "Error Reading Project";

                    // show the message to the user
                    MessageHelper.DisplayMessage("An error occurred while reading your project file.", title);
                }
                finally
                {
                    // destroy the com object
                    dte = null;
                }
                    
                // return value
                return solution;
            }
            #endregion

            #region GetObjectType()
            /// <summary>
            /// This method returns the Object Type of the latest version of Visual Studio installed
            /// </summary>
            private static Type GetObjectType()
            {
                // Initial value
                Type objectType = null;

                // locals
                double versionNumber = 17;
                string programId = "";
        
                do
                {
                    try
                    {
                        // decrement the value for versionNumber
                        versionNumber--;

                        // set the programId for each version of visual Studio
                        programId = "VisualStudio.DTE." + versionNumber + ".0";

                        // Check if Visual Studio 2013 is installed
                        objectType = Type.GetTypeFromProgID(programId);

                        // exit if we get down to Visual Studio 2008 or below
                        if (versionNumber < 8)
                        {
                            // bail
                            break;
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        string err = error.ToString();
                    }

                } while (objectType == null);
                    

                // return value
                return objectType;
            } 
            #endregion

            #region RemoveFilesFromProject(EnvDTE.Project project, List<ProjectFile> files, DataManager.ProjectTypeEnum projectType)
            /// <summary>
            /// This method updates the files for a project that are of the
            /// same project type.
            /// </summary>
            /// <param name="project"></param>
            /// <param name="files"></param>
            /// <param name="projectTypeEnum"></param>
            /// <returns></returns>
            private static int RemoveFilesFromProject(EnvDTE.Project project, List<ProjectFile> files, DataManager.ProjectTypeEnum projectType)
            {
                // initial value
                int filesRemoved = 0;
                    
                // locals
                bool fileRemoved = false;
                
                try
                {
                    // verify all objects exist
                    if ((project != null) && (project.ProjectItems != null) && (files != null) && (files.Count > 0))
                    {
                        // iterate collection of ProjectFiles
                        foreach (ProjectFile projectFile in files)
                        {
                            // reset
                            fileRemoved = false;
                            
                            // if this file should go in this project
                            if (projectFile.ProjectType == projectType)
                            {
                                try
                                {
                                    // check if the file already exists
                                    fileRemoved = RemoveFileIfFileExistsInProject(project, project.ProjectItems, projectFile);
                                    
                                    // if the file was removed
                                    if (fileRemoved)
                                    {  
                                        // Increment the value for filesRemoved
                                        filesRemoved++;
                                    }
                                }
                                catch (Exception error)
                                {
                                    // for debugging only (for now)
                                    string err = error.ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only (for now)
                    string err = error.ToString();
                }
                    
                // return value
                return filesRemoved;
            }
            #endregion

            #region RemoveFileIfFileExistsInProject(EnvDTE.Project project, ProjectItems projectItems, ProjectFile projectFile)
            /// <summary>
            /// This method removes a file if it exists in the project passed in
            /// </summary>
            /// <param name="project"></param>
            /// <param name="projectFile"></param>
            /// <returns></returns>
            private static bool RemoveFileIfFileExistsInProject(EnvDTE.Project project, ProjectItems projectItems, ProjectFile projectFile)
            {
                // initial value
                bool fileRemoved = false;

                // local (Com objects start at 1)
                int index = 0;
                    
                // iterate project items
                foreach(ProjectItem projectItem in projectItems)
                {  
                    // Increment the value for tempIndex
                    index++;

                    // if the name matches
                    if(projectItem.Name == projectFile.FileName)
                    {
                        // Remove this item
                        projectItems.Item(index).Remove();

                        // Set to true
                        fileRemoved = true;
                            
                        // break out of loop
                        break;
                    }
                    else if ((projectItem.ProjectItems != null) && (projectItem.ProjectItems.Count > 0))
                    {
                        // check if the file exists in the project
                        fileRemoved = RemoveFileIfFileExistsInProject(project, projectItem.ProjectItems, projectFile);
                            
                        // if the file does exist
                        if (fileRemoved)
                        {
                            // break out of loop
                            break;
                        }
                    }
                }
                    
                // return value
                return fileRemoved;
            }  
            #endregion
            
            #region UpdateProject(EnvDTE.Project project, IList<ProjectFile> files, DataManager.ProjectTypeEnum projectType)
            /// <summary>
            /// This method updates the files for a project that are of the
            /// same project type.
            /// </summary>
            /// <param name="project"></param>
            /// <param name="files"></param>
            /// <param name="projectTypeEnum"></param>
            /// <returns></returns>
            private static int UpdateProject(EnvDTE.Project project, List<ProjectFile> files, DataManager.ProjectTypeEnum projectType)
            {
                // initial value
                int newFilesAddedCount = 0;
                    
                // locals
                bool abort = false;
                
                try
                {
                    // verify all objects exist
                    if ((project != null) && (project.ProjectItems != null) && (files != null) && (files.Count > 0))
                    {
                        // iterate collection of ProjectFiles
                        foreach (ProjectFile projectFile in files)
                        {
                            // reset
                            abort = false;
                            
                            // if this file should go in this project
                            if (projectFile.ProjectType == projectType)
                            {
                                try
                                {
                                    // check if the file already exists
                                    abort = CheckIfFileExistsInProject(project.ProjectItems, projectFile);
                                    
                                    // if we should continue
                                    if (!abort)
                                    {
                                            
                                        // add this file
                                        project.ProjectItems.AddFromFile(projectFile.FullFilePath);

                                        // increment newFilesAddedCount
                                        newFilesAddedCount++;
                                    }
                                }
                                catch (Exception error)
                                {
                                    // for debugging only (for now)
                                    string err = error.ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only (for now)
                    string err = error.ToString();
                }
                    
                // return value
                return newFilesAddedCount;
            }
            #endregion

            #region UpdateSolution(VisualStudioSolution visualStudioSolution, string solutionFileName, List<ProjectFile> files, bool removalMode)
            /// <summary>
            /// This method updates your solution to include any new files
            /// that have been generated.
            /// </summary>
            /// <param name="visualStudioSolution"></param>
            /// <param name="project"></param>
            /// <returns></returns>
            internal static bool UpdateSolution(VisualStudioSolution visualStudioSolution, string solutionFileName, List<ProjectFile> files, bool removalMode)
            {
                // intial value
                bool updated = true;
                    
                // locals
                Solution solution = null;
                bool isDirty = false;
                int tempAddedCount = 0;
                int tempRemovedCount = 0;
                    
                try
                {
                    // verify all the object exists
                    if ((visualStudioSolution != null) && (visualStudioSolution.Solution != null) && (files != null) && (files.Count > 0))
                    {
                        // get the 
                        solution = visualStudioSolution.Solution;
                            
                        // verify the fileName is set here (should be)
                        if (!String.IsNullOrEmpty(solutionFileName))
                        {
                            // register the MessageFilter to interrupt calls
                            MessageFilter.Register();
                            
                            // open the solution
                            solution.Open(solutionFileName);
                                
                            // here the solution is opened, now 
                            // each project needs to be updated
                            foreach (EnvDTE.Project project in solution.Projects)
                            {
                                // if this project name is the ApplicationLogicComponen project
                                if (project.Name == visualStudioSolution.ApplicationLogicComponentProjectName)
                                {
                                    // if we are in RemovalMode
                                    if (removalMode)
                                    {
                                        // update the ApplicationLogicComponent Project 
                                        tempRemovedCount += RemoveFilesFromProject(project, files, DataManager.ProjectTypeEnum.ALC);
                                    }
                                    else
                                    {
                                        // update the ApplicationLogicComponent Project 
                                        tempAddedCount += UpdateProject(project, files, DataManager.ProjectTypeEnum.ALC);
                                    }
                                }
                                // if this project name is the ApplicationLogicComponen project
                                else if (project.Name == visualStudioSolution.DataAccessComponentProjectName)
                                {
                                    // if removalMode
                                    if (removalMode)
                                    {
                                        // update the ApplicationLogicComponent Project 
                                        tempRemovedCount += RemoveFilesFromProject(project, files, DataManager.ProjectTypeEnum.DAC);
                                    }
                                    else
                                    {
                                        // update the ApplicationLogicComponent Project 
                                        tempAddedCount += UpdateProject(project, files, DataManager.ProjectTypeEnum.DAC);
                                    }
                                }
                                // if this project name is the ObjectLibrary project
                                else if (project.Name == visualStudioSolution.ObjectLibraryProjectName)
                                {  
                                    // if removalMode
                                    if (removalMode)
                                    {
                                        // update the ApplicationLogicComponent Project 
                                        tempRemovedCount += RemoveFilesFromProject(project, files, DataManager.ProjectTypeEnum.ObjectLibrary);
                                    }
                                    else
                                    {
                                        // update the ApplicationLogicComponent Project 
                                        tempAddedCount += UpdateProject(project, files, DataManager.ProjectTypeEnum.ObjectLibrary);
                                    }
                                }
                                    
                                // if the value for removalMode is true
                                if (removalMode)
                                {
                                    // If the value for tempRemovedCount is greater than zero
                                    if (tempRemovedCount > 0)
                                    {
                                        // Set the value for isDirty to true
                                        isDirty = true;

                                        // set updated to true
                                        updated = true;
                                    }
                                }
                                else
                                {
                                    // one or more files were added
                                    if (tempAddedCount > 0)
                                    {
                                        // set isDirty to true so 
                                        // the solution gets saved
                                        isDirty = true;

                                        // set updated to true
                                        updated = true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // did not update
                    updated = false;
                    
                    // raise the error
                    throw error;
                }
                finally
                {
                    // if the solution exists
                    if (solution != null)
                    {
                        // close the solution
                        solution.Close(isDirty);
                    }

                    // unregister the MessageFilter
                    MessageFilter.Revoke();
                }
                    
                // return value
                return updated;
            }
            #endregion
            
        #endregion
                
    } 
    #endregion
    
}
