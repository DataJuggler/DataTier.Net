

#region using statements

using ObjectLibrary.BusinessObjects;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;
using System.Text;

#endregion

namespace DataTierClient.Xml.Writers
{

    #region class ProjectsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Project' objects to xml.
    /// </summary>
    public class ProjectsWriter
    {

        #region Methods

            #region ExportList(List<Project> projects, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Project' objects to xml
            // </Summary>
            public string ExportList(List<Project> projects, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string projectsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Project Node
                sb.Append("<Projects>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Project objects
                if ((projects != null) && (projects.Count > 0))
                {
                    // Iterate the projects collection
                    foreach (Project project  in projects)
                    {
                        // Get the xml for this projects
                        projectsXml = ExportProject(project, indent + 2);

                        // If the projectsXml string exists
                        if (TextHelper.Exists(projectsXml))
                        {
                            // Add this projects to the xml
                            sb.Append(projectsXml);
                        }
                    }
                }

                // Add the close ProjectsWriter Node
                sb.Append(indentString);
                sb.Append("</Projects>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportProject(Project project, int indent = 0)
            // <Summary>
            // This method is used to export a Project object to xml.
            // </Summary>
            public string ExportProject(Project project, int indent = 0)
            {
                // initial value
                string projectXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the project object exists
                if (NullHelper.Exists(project))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open project node
                    sb.Append("<Project>" + Environment.NewLine);

                    // Write out each property

                    
                    // Write out the value for BindingCallbackOption

                    sb.Append(indentString2);
                    sb.Append("<BindingCallbackOption>" + project.BindingCallbackOption + "</BindingCallbackOption>" + Environment.NewLine);

                    // Write out the value for ControllerFolder

                    sb.Append(indentString2);
                    sb.Append("<ControllerFolder>" + project.ControllerFolder + "</ControllerFolder>" + Environment.NewLine);

                    // Write out the value for ControllerNamespace

                    sb.Append(indentString2);
                    sb.Append("<ControllerNamespace>" + project.ControllerNamespace + "</ControllerNamespace>" + Environment.NewLine);

                    // Write out the value for ControllerReferencesSet

                    sb.Append(indentString2);
                    sb.Append("<ControllerReferencesSet>" + project.ControllerReferencesSet + "</ControllerReferencesSet>" + Environment.NewLine);

                    // Write out the value for ControllerReferencesSetId

                    sb.Append(indentString2);
                    sb.Append("<ControllerReferencesSetId>" + project.ControllerReferencesSetId + "</ControllerReferencesSetId>" + Environment.NewLine);

                    // Write out the value for DataManagerFolder

                    sb.Append(indentString2);
                    sb.Append("<DataManagerFolder>" + project.DataManagerFolder + "</DataManagerFolder>" + Environment.NewLine);

                    // Write out the value for DataManagerNamespace

                    sb.Append(indentString2);
                    sb.Append("<DataManagerNamespace>" + project.DataManagerNamespace + "</DataManagerNamespace>" + Environment.NewLine);

                    // Write out the value for DataManagerReferencesSet

                    sb.Append(indentString2);
                    sb.Append("<DataManagerReferencesSet>" + project.DataManagerReferencesSet + "</DataManagerReferencesSet>" + Environment.NewLine);

                    // Write out the value for DataManagerReferencesSetId

                    sb.Append(indentString2);
                    sb.Append("<DataManagerReferencesSetId>" + project.DataManagerReferencesSetId + "</DataManagerReferencesSetId>" + Environment.NewLine);

                    // Write out the value for DataOperationsFolder

                    sb.Append(indentString2);
                    sb.Append("<DataOperationsFolder>" + project.DataOperationsFolder + "</DataOperationsFolder>" + Environment.NewLine);

                    // Write out the value for DataOperationsNamespace

                    sb.Append(indentString2);
                    sb.Append("<DataOperationsNamespace>" + project.DataOperationsNamespace + "</DataOperationsNamespace>" + Environment.NewLine);

                    // Write out the value for DataOperationsReferencesSet

                    sb.Append(indentString2);
                    sb.Append("<DataOperationsReferencesSet>" + project.DataOperationsReferencesSet + "</DataOperationsReferencesSet>" + Environment.NewLine);

                    // Write out the value for DataOperationsReferencesSetId

                    sb.Append(indentString2);
                    sb.Append("<DataOperationsReferencesSetId>" + project.DataOperationsReferencesSetId + "</DataOperationsReferencesSetId>" + Environment.NewLine);

                    // Write out the value for DataWriterFolder

                    sb.Append(indentString2);
                    sb.Append("<DataWriterFolder>" + project.DataWriterFolder + "</DataWriterFolder>" + Environment.NewLine);

                    // Write out the value for DataWriterNamespace

                    sb.Append(indentString2);
                    sb.Append("<DataWriterNamespace>" + project.DataWriterNamespace + "</DataWriterNamespace>" + Environment.NewLine);

                    // Write out the value for DataWriterReferencesSetId

                    sb.Append(indentString2);
                    sb.Append("<DataWriterReferencesSetId>" + project.DataWriterReferencesSetId + "</DataWriterReferencesSetId>" + Environment.NewLine);

                    // Write out the value for DateModified

                    sb.Append(indentString2);
                    sb.Append("<DateModified>" + project.DateModified + "</DateModified>" + Environment.NewLine);

                    // Write out the value for DotNet5

                    sb.Append(indentString2);
                    sb.Append("<DotNet5>" + project.DotNet5 + "</DotNet5>" + Environment.NewLine);

                    // Write out the value for EnableBlazorFeatures

                    sb.Append(indentString2);
                    sb.Append("<EnableBlazorFeatures>" + project.EnableBlazorFeatures + "</EnableBlazorFeatures>" + Environment.NewLine);


                    // Write out the value for HasAllReferences

                    sb.Append(indentString2);
                    sb.Append("<HasAllReferences>" + project.HasAllReferences + "</HasAllReferences>" + Environment.NewLine);

                    // Write out the value for HasDatabases

                    sb.Append(indentString2);
                    sb.Append("<HasDatabases>" + project.HasDatabases + "</HasDatabases>" + Environment.NewLine);

                    // Write out the value for HasTables

                    sb.Append(indentString2);
                    sb.Append("<HasTables>" + project.HasTables + "</HasTables>" + Environment.NewLine);

                    // Write out the value for IsNew

                    sb.Append(indentString2);
                    sb.Append("<IsNew>" + project.IsNew + "</IsNew>" + Environment.NewLine);

                    // Write out the value for ObjectFolder

                    sb.Append(indentString2);
                    sb.Append("<ObjectFolder>" + project.ObjectFolder + "</ObjectFolder>" + Environment.NewLine);

                    // Write out the value for ObjectNamespace

                    sb.Append(indentString2);
                    sb.Append("<ObjectNamespace>" + project.ObjectNamespace + "</ObjectNamespace>" + Environment.NewLine);

                    // Write out the value for ObjectReferencesSet

                    sb.Append(indentString2);
                    sb.Append("<ObjectReferencesSet>" + project.ObjectReferencesSet + "</ObjectReferencesSet>" + Environment.NewLine);

                    // Write out the value for ObjectReferencesSetId

                    sb.Append(indentString2);
                    sb.Append("<ObjectReferencesSetId>" + project.ObjectReferencesSetId + "</ObjectReferencesSetId>" + Environment.NewLine);

                    // Write out the value for ProjectFolder

                    sb.Append(indentString2);
                    sb.Append("<ProjectFolder>" + project.ProjectFolder + "</ProjectFolder>" + Environment.NewLine);

                    // Write out the value for ProjectId

                    sb.Append(indentString2);
                    sb.Append("<ProjectId>" + project.ProjectId + "</ProjectId>" + Environment.NewLine);

                    // Write out the value for ProjectName

                    sb.Append(indentString2);
                    sb.Append("<ProjectName>" + project.ProjectName + "</ProjectName>" + Environment.NewLine);

                    // Write out the value for ReaderFolder

                    sb.Append(indentString2);
                    sb.Append("<ReaderFolder>" + project.ReaderFolder + "</ReaderFolder>" + Environment.NewLine);

                    // Write out the value for ReaderNamespace

                    sb.Append(indentString2);
                    sb.Append("<ReaderNamespace>" + project.ReaderNamespace + "</ReaderNamespace>" + Environment.NewLine);

                    // Write out the value for ReaderReferencesSet

                    sb.Append(indentString2);
                    sb.Append("<ReaderReferencesSet>" + project.ReaderReferencesSet + "</ReaderReferencesSet>" + Environment.NewLine);

                    // Write out the value for ReaderReferencesSetId

                    sb.Append(indentString2);
                    sb.Append("<ReaderReferencesSetId>" + project.ReaderReferencesSetId + "</ReaderReferencesSetId>" + Environment.NewLine);

                    // Write out the value for ServicesFolder

                    sb.Append(indentString2);
                    sb.Append("<ServicesFolder>" + project.ServicesFolder + "</ServicesFolder>" + Environment.NewLine);

                    // Write out the value for StoredProcedureObjectFolder

                    sb.Append(indentString2);
                    sb.Append("<StoredProcedureObjectFolder>" + project.StoredProcedureObjectFolder + "</StoredProcedureObjectFolder>" + Environment.NewLine);

                    // Write out the value for StoredProcedureObjectNamespace

                    sb.Append(indentString2);
                    sb.Append("<StoredProcedureObjectNamespace>" + project.StoredProcedureObjectNamespace + "</StoredProcedureObjectNamespace>" + Environment.NewLine);

                    // Write out the value for StoredProcedureReferencesSet

                    sb.Append(indentString2);
                    sb.Append("<StoredProcedureReferencesSet>" + project.StoredProcedureReferencesSet + "</StoredProcedureReferencesSet>" + Environment.NewLine);

                    // Write out the value for StoredProcedureReferencesSetId

                    sb.Append(indentString2);
                    sb.Append("<StoredProcedureReferencesSetId>" + project.StoredProcedureReferencesSetId + "</StoredProcedureReferencesSetId>" + Environment.NewLine);

                    // Write out the value for StoredProcsFolder

                    sb.Append(indentString2);
                    sb.Append("<StoredProcsFolder>" + project.StoredProcsFolder + "</StoredProcsFolder>" + Environment.NewLine);

                    // Write out the value for UIFolderPath

                    sb.Append(indentString2);
                    sb.Append("<UIFolderPath>" + project.UIFolderPath + "</UIFolderPath>" + Environment.NewLine);

                    // Write out the value for WriterReferencesSet

                    sb.Append(indentString2);
                    sb.Append("<WriterReferencesSet>" + project.WriterReferencesSet + "</WriterReferencesSet>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close project node
                    sb.Append("</Project>" + Environment.NewLine);

                    // set the return value
                    projectXml = sb.ToString();
                }
                // return value
                return projectXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
