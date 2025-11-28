

#region using statements

using DataJuggler.Net;
using DataTierClient.Objects;
using EnvDTE;
using System.Collections.Generic;
using ObjectLibrary.BusinessObjects;
using System;
using DataJuggler.Core.UltimateHelper;
using System.IO;
using static System.Net.WebRequestMethods;

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
                    if ((!String.IsNullOrEmpty(solutionFileName)) && (System.IO.File.Exists(solutionFileName)))
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
                                
                                // Wait until the projects are ready
                                WaitUntilSolutionProjectsReady(dte, 20000, 250);

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
                double versionNumber = 19;
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

            #region HandleUpdateProject(VisualStudioSolution visualStudioSolution, EnvDTE.Project project, List<ProjectFile> files, bool removalMode)
            /// <summary>
            /// returns the Update Project
            /// </summary>
            public static UpdateProjectResponse HandleUpdateProject(VisualStudioSolution visualStudioSolution, EnvDTE.Project project, List<ProjectFile> files, bool removalMode)
            {
                // initial value
                UpdateProjectResponse response = new UpdateProjectResponse();

                try
                {
                    // wait for the projectItems
                    WaitUntilProjectItemsReady(project, 2000, 100);

                    // if this project name is the ApplicationLogicComponen project
                    if (project.Name == visualStudioSolution.ApplicationLogicComponentProjectName)
                    {
                        // if we are in RemovalMode
                        if (removalMode)
                        {
                            // update the ApplicationLogicComponent Project 
                            response = RemoveFilesFromProject(project, files, DataManager.ProjectTypeEnum.ALC);
                        }
                        else
                        {
                            // update the ApplicationLogicComponent Project 
                            response = UpdateProject(project, files, DataManager.ProjectTypeEnum.ALC);
                        }
                    }
                    // if this project name is the ApplicationLogicComponen project
                    else if (project.Name == visualStudioSolution.DataAccessComponentProjectName)
                    {
                        // if removalMode
                        if (removalMode)
                        {
                            // update the ApplicationLogicComponent Project 
                            response = RemoveFilesFromProject(project, files, DataManager.ProjectTypeEnum.DAC);
                        }
                        else
                        {
                            // update the ApplicationLogicComponent Project 
                            response = UpdateProject(project, files, DataManager.ProjectTypeEnum.DAC);
                        }
                    }
                    // if this project name is the ObjectLibrary project
                    else if (project.Name == visualStudioSolution.ObjectLibraryProjectName)
                    {  
                        // if removalMode
                        if (removalMode)
                        {
                            // update the ApplicationLogicComponent Project 
                            response = RemoveFilesFromProject(project, files, DataManager.ProjectTypeEnum.ObjectLibrary);
                        }
                        else
                        {
                            // update the ApplicationLogicComponent Project 
                            response = UpdateProject(project, files, DataManager.ProjectTypeEnum.ObjectLibrary);
                        }
                    }
                                    
                    // if the value for removalMode is true
                    if (removalMode)
                    {
                        // If the value for tempRemovedCount is greater than zero
                        if (response.FilesRemoved > 0)
                        {
                            // Set the value for isDirty to true
                            response.IsDirty = true;

                            // set updated to true
                            response.Success = true;
                        }
                    }
                    else
                    {
                        // one or more files were added
                        if (response.FilesAdded > 0)
                        {
                            // set isDirty to true so 
                            // the solution gets saved
                            response.IsDirty = true;

                            // set updated to true
                            response.Success = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Add this error
                    response.Exceptions.Add(error);
                }

                // return value
                return response;
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
            private static UpdateProjectResponse RemoveFilesFromProject(EnvDTE.Project project, List<ProjectFile> files, DataManager.ProjectTypeEnum projectType)
            {
                // initial value
                UpdateProjectResponse projectResponse = new UpdateProjectResponse();

                // this is RemoveMode
                projectResponse.RemoveMode = true;
                    
                // local
                UpdateFileResponse updateFileResponse = null;
                
                try
                {
                    // verify all objects exist
                    if ((project != null) && (project.ProjectItems != null) && (files != null) && (files.Count > 0))
                    {
                        // iterate collection of ProjectFiles
                        foreach (ProjectFile projectFile in files)
                        {
                            // Create a new instance of an 'updateFileResponse' object.
                            updateFileResponse = new UpdateFileResponse();
                            
                            // if this file should go in this project
                            if (projectFile.ProjectType == projectType)
                            {
                                try
                                {
                                    // check if the file already exists
                                    updateFileResponse = RemoveFileIfFileExistsInProject(project, project.ProjectItems, projectFile);
                                    
                                    // if the file was removed
                                    if (updateFileResponse.Success)
                                    {  
                                        // Increment the value for filesRemoved
                                        projectResponse.FilesRemoved++;
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
                return projectResponse;
            }
            #endregion

            #region RemoveFileIfFileExistsInProject(EnvDTE.Project project, ProjectItems projectItems, ProjectFile projectFile)
            /// <summary>
            /// This method removes a file if it exists in the project passed in
            /// </summary>
            /// <param name="project"></param>
            /// <param name="projectFile"></param>
            /// <returns></returns>
            private static UpdateFileResponse RemoveFileIfFileExistsInProject(EnvDTE.Project project, ProjectItems projectItems, ProjectFile projectFile)
            {
                // initial value
                UpdateFileResponse response = new UpdateFileResponse();

                // local (Com objects start at 1)
                int index = 0;
    
                // iterate project items
                foreach(ProjectItem projectItem in projectItems)
                {  
                    // Increment the value for index
                    index++;

                    // if the name matches
                    if (projectItem.Name == projectFile.FileName)
                    {
                        // if this is not the Gateway
                        if (!projectFile.FileName.Contains("Gateway"))
                        {
                            // Remove this item
                            projectItems.Item(index).Remove();

                            // this file exists
                            response.FileExists = true;

                            // Set to true
                            response.Success = true;
                        }
                            
                        // break out of loop
                        break;
                    }
                    else if ((projectItem.ProjectItems != null) && (projectItem.ProjectItems.Count > 0))
                    {
                        // check if the file exists in the project
                        response = RemoveFileIfFileExistsInProject(project, projectItem.ProjectItems, projectFile);
                            
                        // if the file does exist
                        if (response.Success)
                        {
                            // break out of loop
                            break;
                        }
                    }
                }
                    
                // return value
                return response;
            }  
            #endregion

            #region SafeGetProjectItems(EnvDTE.Project project)
            /// <summary>
            /// method returns the Get Project Items
            /// </summary>
            private static EnvDTE.ProjectItems SafeGetProjectItems(EnvDTE.Project project)
            {
                // initial value
                EnvDTE.ProjectItems projectItems = null;
                
                // if the project exists
                if (project != null)
                {
                    try
                    {
                        projectItems = project.ProjectItems;
                    }
                    catch
                    {
                        // swallow; COM can throw until fully ready
                    }
                }
                
                // return value
                return projectItems;
            }
            #endregion
            
            #region TryTouchProject(EnvDTE.Project project)
            /// <summary>
            /// method returns the Touch Project
            /// </summary>
            private static void TryTouchProject(EnvDTE.Project project)
            {
                // if the project exists
                if (project != null)
                {
                    try
                    {
                        // Touching these often triggers load completion
                        string fullName = project.FullName;
                        object projectObject = project.Object;
                        
                        EnvDTE.Properties properties = project.Properties;
                        if (properties != null)
                        {
                            int propertyCount = properties.Count;
                        }
                    }
                    catch
                    {
                        // ignore; we're only nudging
                    }
                }
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
            private static UpdateProjectResponse UpdateProject(EnvDTE.Project project, List<ProjectFile> files, DataManager.ProjectTypeEnum projectType)
            {
                // initial value
                UpdateProjectResponse response = new UpdateProjectResponse();

                // This is Add mode
                response.RemoveMode = false;
                    
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
                                        // This file is being attempted
                                        response.FilesAttempted++;

                                        // add this file Uncomment This
                                        project.ProjectItems.AddFromFile(projectFile.FullFilePath);

                                        // increment FilesAdded
                                        response.FilesAdded++;
                                    }
                                }
                                catch (Exception error)
                                {
                                    // for debugging only (for now)
                                    response.Exceptions.Add(error);
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only (for now)
                    response.Exceptions.Add(error);
                }
                    
                // return value
                return response;
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
            internal static UpdateSolutionResponse UpdateSolution(VisualStudioSolution visualStudioSolution, string solutionFileName, List<ProjectFile> files, bool removalMode)
            {
                // intial value
                UpdateSolutionResponse response = new UpdateSolutionResponse();
                    
                // locals
                Solution solution = null;
                bool isDirty = false;
                UpdateProjectResponse projectResponse = null;
                    
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
                                
                            // each project needs to be updated
                            foreach (EnvDTE.Project project in solution.Projects)
                            {
                                // Update the files in this project
                                projectResponse = HandleUpdateProject(visualStudioSolution, project, files, removalMode);                                

                                // Add this response
                                response.ProjectResponses.Add(projectResponse);
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // did not update
                    response.Success = false;

                    // only raise the error if fatal, it might not be a problem
                    if (response.FatalError)
                    {
                        // raise the error
                        throw error;
                    }
                }
                finally
                {
                    try
                    {
                        // if the solution exists
                        if (solution != null)
                        {
                            // close the solution
                            solution.Close(isDirty);
                        }
                    }
                    catch (Exception error)
                    {
                        // store
                        response.Exception = error;

                        // if this is not fatal, just go with it. 
                        if (response.FatalError)
                        {
                            // raise the error
                            throw error;  
                        }
                    }

                    // unregister the MessageFilter
                    MessageFilter.Revoke();
                }
                    
                // return value
                return response;
            }
            #endregion
            
            #region WaitForProjectItems(EnvDTE.Project project, int timeoutMs, int pollMs)
            /// <summary>
            /// method returns the For Project Items
            /// </summary>
            private static bool WaitUntilProjectItemsReady(EnvDTE.Project project, int timeoutMilliseconds, int pollMilliseconds)
            {
                // initial value
                bool ready = false;

                // if the project exists
                if (project != null)
                {
                    DateTime endTime = DateTime.UtcNow.AddMilliseconds(timeoutMilliseconds);

                    while (DateTime.UtcNow < endTime)
                    {
                        // Nudge project to complete initialization
                        TryTouchProject(project);

                        EnvDTE.ProjectItems projectItems = SafeGetProjectItems(project);

                        // if the projectItems exist
                        if (projectItems != null)
                        {
                            ready = true;
                            break;
                        }

                        System.Windows.Forms.Application.DoEvents();
                        System.Threading.Thread.Sleep(pollMilliseconds);
                    }

                    // final attempt after loop
                    if (!ready)
                    {
                        TryTouchProject(project);
                        EnvDTE.ProjectItems finalItems = SafeGetProjectItems(project);

                        if (finalItems != null)
                        {
                            ready = true;
                        }
                    }
                }

                // return value
                return ready;
            }
            #endregion

            #region WaitUntilSolutionProjectsReady(EnvDTE.DTE dte, int timeoutMilliseconds, int pollMilliseconds)
            /// <summary>
            /// 
            /// </summary>
            /// <param name="dte"></param>
            /// <param name="timeoutMilliseconds"></param>
            /// <param name="pollMilliseconds"></param>
            /// <returns></returns>
            private static bool WaitUntilSolutionProjectsReady(EnvDTE.DTE dte, int timeoutMilliseconds, int pollMilliseconds)
            {
                // initial value
                bool isReady = false;

                // if the dte and Solution objects exist
                if ((dte != null) && (dte.Solution != null) && (dte.Solution.IsOpen))
                {
                    DateTime endTime = DateTime.UtcNow.AddMilliseconds(timeoutMilliseconds);

                    while ((DateTime.UtcNow < endTime) && (!isReady))
                    {
                        try
                        {
                            EnvDTE.Projects projects = dte.Solution.Projects;

                            // if the projects collection exists
                            if (projects != null)
                            {
                                foreach (EnvDTE.Project project in projects)
                                {
                                    // if the project exists
                                    if (project == null)
                                    {
                                        continue;
                                    }

                                    bool projectReady = WaitUntilProjectItemsReady(project, pollMilliseconds * 2, pollMilliseconds);

                                    // if the project is ready
                                    if (projectReady)
                                    {
                                        // Set the return value
                                        isReady = true;

                                        // exit loop
                                        break;
                                    }
                                }

                                // if there were no projects or none required project items
                                if (!isReady)
                                {
                                    // Set the return value
                                    isReady = true;

                                    // exit loop
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            // do nothing, VS not ready yet
                        }

                        System.Windows.Forms.Application.DoEvents();
                        System.Threading.Thread.Sleep(pollMilliseconds);
                    }

                    // final attempt after loop if not ready
                    if (!isReady)
                    {
                        try
                        {
                            EnvDTE.Projects projects = dte.Solution.Projects;

                            // if the projects collection exists
                            if (projects != null)
                            {
                                // Set the return value
                                isReady = true;
                            }
                        }
                        catch
                        {
                            // swallow any final errors
                        }
                    }
                }

                // return value
                return isReady;
            }
            #endregion
                    
        #endregion
                
    } 
    #endregion
    
}