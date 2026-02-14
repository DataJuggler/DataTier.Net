

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using DataJuggler.Net;
using DataJuggler.Net.Enumerations;
using DataTierClient.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class ProjectHelper
    /// <summary>
    /// This class is used to find a list of files to insert into a CSharp project file, to include code generated files.
    /// Visual Studio has a bug in Add From File that used to work, so we are rolling our own project updater.
    ///  For now this is only used for .NET Framework projects (my work project)
    /// </summary>
    internal class ProjectHelper
    {

        #region Constants
        private const string CompileTemplate = "<Compile Include=\"[Path]\" />";        
        #endregion
        
        #region Methods
            
            #region GetInsertLines(DataManager.ProjectTypeEnum projectType, string projectDirectory, List<TextLine> compileFiles, List<ProjectFile> projectFiles)
            /// <summary>
            /// This method returns a list of lines to insert into a projectFile
            /// </summary>
            public static List<TextLine> GetInsertLines(DataManager.ProjectTypeEnum projectType, string projectDirectory, List<TextLine> compileFiles, List<ProjectFile> projectFiles)
            {
                // initial value
                List<TextLine> insertLines = null;

                // locals
                string relativePath = "";
                string insertString = "";
                FileInfo fileInfo = null;

                // If the compileFiles collection and the projectFiles collection both exist and each have one or more items
                if(ListHelper.HasOneOrMoreItems(compileFiles, projectFiles))
                {
                    // create the return value
                    insertLines = new List<TextLine>();

                    // sort in descending order
                    projectFiles = projectFiles.OrderByDescending(x => x.FullFilePath).ToList();

                    // iterate the projectFiles
                    foreach (ProjectFile projectFile in projectFiles)
                    {
                        // Only update the project you are in, because projectFiles contains all the projects
                        if (projectFile.ProjectType == projectType)
                        {
                            // get the path without the projectDirectory
                            fileInfo = new FileInfo(projectFile.FullFilePath);
                        
                            // set the relativePath
                            relativePath = fileInfo.FullName.Replace(projectDirectory, "");

                            // get the insertString
                            insertString = TextHelper.Indent(4) + CompileTemplate.Replace("[Path]", relativePath);

                             // create the insertLine
                            TextLine insertLine = new TextLine(insertString);

                            // set the index
                            insertLine.Index = FindInsertIndex(compileFiles, insertString);

                            // if the index was found
                            if (insertLine.Index >= 0)
                            {
                                // Add this line
                                insertLines.Add(insertLine);    
                            }
                        }
                    }                                       
                }

                // return value
                return insertLines;
            }
            #endregion
            
            #region FindInsertIndex(List<TextLine> textLines, string relativePath)
            /// <summary>
            /// returns the insert index for a new Compile line
            /// </summary>
            internal static int FindInsertIndex(List<TextLine> textLines, string insertString)
            {
                // initial value
                int insertIndex = -1;

                // If the textLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(textLines))
                {
                    // If the line already exists
                    bool exists = textLines.Any(x => string.Equals(x.Text.Trim(), insertString.Trim(), StringComparison.OrdinalIgnoreCase));

                    // if it already exists, return something different
                    if (exists)
                    {
                        // set the return value
                        insertIndex = -2;
                    }
                    else
                    {
                        // find the first line that comes AFTER the insertString
                        int nextIndex = textLines.FindIndex(x =>
                            string.Compare(x.Text, insertString, StringComparison.OrdinalIgnoreCase) > 0);

                        // if found
                        if (nextIndex >= 0)
                        {
                            // insert before this line
                            insertIndex = textLines[nextIndex].Index;
                        }
                        else
                        {
                            // insert after the last line
                            insertIndex = textLines.Last().Index + 1;
                        }
                    }
                }

                // return value
                return insertIndex;
            }
            #endregion
            
            #region GetProjectDirectory(EnvDTE.Project project)
            /// <summary>
            /// returns the Project Directory
            /// </summary>
            internal static string GetProjectDirectory(EnvDTE.Project project)
            {
                // initial value
                string projectDirectory = "";

                // if the project 
                if (NullHelper.Exists(project))
                {
                    // get the project file info
                    FileInfo projectFileInfo = new FileInfo(project.FullName);

                    // set the 
                    DirectoryInfo projectDirectoryInfo = projectFileInfo.Directory;

                    // get the projectDirectory
                    projectDirectory = projectDirectoryInfo.FullName + @"\";
                }

                // return value
                return projectDirectory;
            }
            #endregion
            
            #region MergeLines(List<TextLine> lines, List<TextLine> insertLines)
            /// <summary>
            /// method returns a list of Lines
            /// </summary>
            public static List<TextLine> MergeLines(List<TextLine> lines, List<TextLine> insertLines)
            {
                // If the lists have one or more items
                if (ListHelper.HasOneOrMoreItems(lines, insertLines))
                {
                    // insert in reverse index order so indexes don't shift
                    List<TextLine> orderedInsertLines = insertLines
                    .OrderByDescending(x => x.Index)
                    .ToList();

                    // insert the lines
                    foreach (TextLine insertLine in orderedInsertLines)
                    {
                        lines.Insert(insertLine.Index, insertLine);
                    }

                    // reindex after merge so Index matches new positions
                    //for (int index = 0; index < lines.Count; index++)
                    //{
                    //    lines[index].Index = index;
                    //}
                }

                // return value
                return lines;
            }
            #endregion
            
            #region UpdateProject(EnvDTE.Project project, List<ProjectFile> projectFiles, TargetFrameworkEnum targetFramework, DataManager.ProjectTypeEnum projectType)
            /// <summary>
            /// method Update Project
            /// </summary>
            public static UpdateProjectResponse UpdateProject(EnvDTE.Project project, List<ProjectFile> projectFiles, TargetFrameworkEnum targetFramework, DataManager.ProjectTypeEnum projectType)
            {
                // initial value
                UpdateProjectResponse response = new UpdateProjectResponse();

                try
                {
                    if (targetFramework == TargetFrameworkEnum.NetFramework)
                    {
                        // locals
                        List<TextLine> insertLines = null;

                        // make sure the project file is not in use
                        if (!FileHelper.IsFileInUse(project.FullName))
                        {
                            // Get the projectdirecotry
                            string projectDirectory = GetProjectDirectory(project);

                            // Get the text lines for this project
                            List<TextLine> lines = TextHelper.GetTextLinesFromFile(project.FullName);

                            // If the lines collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(lines))
                            {
                                // get the
                                List<TextLine> compileFiles = lines.Where(x => x.Text.Contains("<Compile") && x.Text.TrimEnd().EndsWith(".cs\" />", StringComparison.OrdinalIgnoreCase)).ToList();

                                // get the insertLines
                                insertLines = GetInsertLines(projectType, projectDirectory, compileFiles, projectFiles);

                                // get the udpatedTextLines
                                List<TextLine> updatedTextLines = MergeLines(lines, insertLines);

                                // Get the new documentText
                                string documentText = TextHelper.ExportTextLines(updatedTextLines);

                                // get the backup fileName
                                string backupFileName = project.FullName + ".bak";

                                // If a previous backup exists, delete it
                                if (File.Exists(backupFileName))
                                {
                                    // delete the backup
                                    File.Delete(backupFileName);
                                }

                                // Create fresh backup
                                File.Copy(project.FullName, backupFileName);

                                // Write updated project file
                                File.WriteAllText(project.FullName, documentText);

                                // set to true
                                response.Success = true;
                            }
                        }
                    }
                    else
                    {
                        // nothing to update for .NET Core
                        response.Success = true;
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
            
        #endregion
        
    }
    #endregion

}
