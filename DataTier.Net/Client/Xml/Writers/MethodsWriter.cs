

#region using statements

using DataTierClient.Objects;
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

    #region class MethodsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Method' objects to xml.
    /// </summary>
    public class MethodsWriter
    {

        #region Methods

            #region ExportList(List<Method> methods, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Method' objects to xml
            // </Summary>
            public string ExportList(List<Method> methods, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string methodsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Method Node
                sb.Append("<Methods>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Method objects
                if ((methods != null) && (methods.Count > 0))
                {
                    // Iterate the methods collection
                    foreach (Method method  in methods)
                    {
                        // Get the xml for this methods
                        methodsXml = ExportMethod(method, indent + 2);

                        // If the methodsXml string exists
                        if (TextHelper.Exists(methodsXml))
                        {
                            // Add this methods to the xml
                            sb.Append(methodsXml);
                        }
                    }
                }

                // Add the close MethodsWriter Node
                sb.Append(indentString);
                sb.Append("</Methods>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportMethod(Method method, int indent = 0)
            // <Summary>
            // This method is used to export a Method object to xml.
            // </Summary>
            public string ExportMethod(Method method, int indent = 0)
            {
                // initial value
                string methodXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the method object exists
                if (NullHelper.Exists(method))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open method node
                    sb.Append("<Method>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for Active

                    sb.Append(indentString2);
                    sb.Append("<Active>" + method.Active + "</Active>" + Environment.NewLine);

                    // Write out the value for CustomReader

                    sb.Append(indentString2);
                    sb.Append("<CustomReader>" + method.CustomReader + "</CustomReader>" + Environment.NewLine);

                    // Write out the value for CustomReaderId

                    sb.Append(indentString2);
                    sb.Append("<CustomReaderId>" + method.CustomReaderId + "</CustomReaderId>" + Environment.NewLine);

                    // Write out the value for FetchAllForTable

                    sb.Append(indentString2);
                    sb.Append("<FetchAllForTable>" + method.FetchAllForTable + "</FetchAllForTable>" + Environment.NewLine);

                    // Write out the value for FindByName

                    sb.Append(indentString2);
                    sb.Append("<FindByName>" + method.FindByName + "</FindByName>" + Environment.NewLine);

                    // Write out the value for HasCustomReader

                    sb.Append(indentString2);
                    sb.Append("<HasCustomReader>" + method.HasCustomReader + "</HasCustomReader>" + Environment.NewLine);

                    // Write out the value for HasProjectId

                    sb.Append(indentString2);
                    sb.Append("<HasProjectId>" + method.HasProjectId + "</HasProjectId>" + Environment.NewLine);

                    // Write out the value for HasTableId

                    sb.Append(indentString2);
                    sb.Append("<HasTableId>" + method.HasTableId + "</HasTableId>" + Environment.NewLine);

                    // Write out the value for IsNew

                    sb.Append(indentString2);
                    sb.Append("<IsNew>" + method.IsNew + "</IsNew>" + Environment.NewLine);

                    // Write out the value for LoadByProjectId

                    sb.Append(indentString2);
                    sb.Append("<LoadByProjectId>" + method.LoadByProjectId + "</LoadByProjectId>" + Environment.NewLine);

                    // Write out the value for MethodId

                    sb.Append(indentString2);
                    sb.Append("<MethodId>" + method.MethodId + "</MethodId>" + Environment.NewLine);

                    // Write out the value for MethodType

                    sb.Append(indentString2);
                    sb.Append("<MethodType>" + method.MethodType + "</MethodType>" + Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + method.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for OrderByDescending

                    sb.Append(indentString2);
                    sb.Append("<OrderByDescending>" + method.OrderByDescending + "</OrderByDescending>" + Environment.NewLine);

                    // Write out the value for OrderByFieldId

                    sb.Append(indentString2);
                    sb.Append("<OrderByFieldId>" + method.OrderByFieldId + "</OrderByFieldId>" + Environment.NewLine);

                    // Write out the value for OrderByFieldSetId

                    sb.Append(indentString2);
                    sb.Append("<OrderByFieldSetId>" + method.OrderByFieldSetId + "</OrderByFieldSetId>" + Environment.NewLine);

                    // Write out the value for OrderByType

                    sb.Append(indentString2);
                    sb.Append("<OrderByType>" + method.OrderByType + "</OrderByType>" + Environment.NewLine);

                    // Write out the value for ParameterFieldId

                    sb.Append(indentString2);
                    sb.Append("<ParameterFieldId>" + method.ParameterFieldId + "</ParameterFieldId>" + Environment.NewLine);

                    // Write out the value for Parameters

                    sb.Append(indentString2);
                    sb.Append("<Parameters>" + method.Parameters + "</Parameters>" + Environment.NewLine);

                    // Write out the value for ParametersFieldSetId

                    sb.Append(indentString2);
                    sb.Append("<ParametersFieldSetId>" + method.ParametersFieldSetId + "</ParametersFieldSetId>" + Environment.NewLine);

                    // Write out the value for ParameterType

                    sb.Append(indentString2);
                    sb.Append("<ParameterType>" + method.ParameterType + "</ParameterType>" + Environment.NewLine);

                    // Write out the value for ProcedureName

                    sb.Append(indentString2);
                    sb.Append("<ProcedureName>" + method.ProcedureName + "</ProcedureName>" + Environment.NewLine);

                    // Write out the value for ProcedureText

                    sb.Append(indentString2);
                    sb.Append("<ProcedureText>" + method.ProcedureText + "</ProcedureText>" + Environment.NewLine);

                    // Write out the value for ProjectId

                    sb.Append(indentString2);
                    sb.Append("<ProjectId>" + method.ProjectId + "</ProjectId>" + Environment.NewLine);

                    // Write out the value for PropertyName

                    sb.Append(indentString2);
                    sb.Append("<PropertyName>" + method.PropertyName + "</PropertyName>" + Environment.NewLine);

                    // Write out the value for TableId

                    sb.Append(indentString2);
                    sb.Append("<TableId>" + method.TableId + "</TableId>" + Environment.NewLine);

                    // Write out the value for TopRows

                    sb.Append(indentString2);
                    sb.Append("<TopRows>" + method.TopRows + "</TopRows>" + Environment.NewLine);

                    // Write out the value for UpdateProcedureOnBuild

                    sb.Append(indentString2);
                    sb.Append("<UpdateProcedureOnBuild>" + method.UpdateProcedureOnBuild + "</UpdateProcedureOnBuild>" + Environment.NewLine);

                    // Write out the value for UseCustomReader

                    sb.Append(indentString2);
                    sb.Append("<UseCustomReader>" + method.UseCustomReader + "</UseCustomReader>" + Environment.NewLine);

                    // Write out the value for UseCustomWhere

                    sb.Append(indentString2);
                    sb.Append("<UseCustomWhere>" + method.UseCustomWhere + "</UseCustomWhere>" + Environment.NewLine);

                    // Write out the value for WhereText

                    sb.Append(indentString2);
                    sb.Append("<WhereText>" + method.WhereText + "</WhereText>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close method node
                    sb.Append("</Method>" + Environment.NewLine);

                    // set the return value
                    methodXml = sb.ToString();
                }
                // return value
                return methodXml;
            }
            #endregion

            #region ExportList(List<Method> methods, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Method' objects to xml
            // </Summary>
            public string ExportList(List<MethodInfo> methods, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string methodsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Method Node
                sb.Append("<Methods>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Method objects
                if ((methods != null) && (methods.Count > 0))
                {
                    // Iterate the methods collection
                    foreach (MethodInfo method  in methods)
                    {
                        // Get the xml for this methods
                        methodsXml = ExportMethodInfo(method, indent + 2);

                        // If the methodsXml string exists
                        if (TextHelper.Exists(methodsXml))
                        {
                            // Add this methods to the xml
                            sb.Append(methodsXml);
                        }
                    }
                }

                // Add the close MethodsWriter Node
                sb.Append(indentString);
                sb.Append("</Methods>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportMethod(MethodInfo method, int indent = 0)
            // <Summary>
            // This method is used to export a Method object to xml.
            // </Summary>
            public string ExportMethodInfo(MethodInfo method, int indent = 0)
            {
                // initial value
                string methodXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the method object exists
                if (NullHelper.Exists(method))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open method node
                    sb.Append("<Method>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for HasCustomReader

                    sb.Append(indentString2);
                    sb.Append("<HasCustomReader>" + method.HasCustomReader + "</HasCustomReader>" + Environment.NewLine);

                    // Write out the value for MethodId

                    sb.Append(indentString2);
                    sb.Append("<MethodId>" + method.MethodId + "</MethodId>" + Environment.NewLine);

                    // Write out the value for MethodType

                    sb.Append(indentString2);
                    sb.Append("<MethodType>" + method.MethodType + "</MethodType>" + Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<MethodName>" + method.MethodName + "</MethodName>" + Environment.NewLine);

                    // Write out the value for OrderByDescending

                    sb.Append(indentString2);
                    sb.Append("<OrderByDescending>" + method.OrderByDescending + "</OrderByDescending>" + Environment.NewLine);

                    // Write out the value for OrderByType

                    sb.Append(indentString2);
                    sb.Append("<OrderByType>" + method.OrderByType + "</OrderByType>" + Environment.NewLine);

                    // Write out the value for ParameterType

                    sb.Append(indentString2);
                    sb.Append("<ParameterType>" + method.ParameterType + "</ParameterType>" + Environment.NewLine);

                    // Write out the value for ProcedureName

                    sb.Append(indentString2);
                    sb.Append("<ProcedureName>" + method.ProcedureName + "</ProcedureName>" + Environment.NewLine);

                    // Write out the value for ProcedureText

                    sb.Append(indentString2);
                    sb.Append("<ProcedureText>" + method.ProcedureText + "</ProcedureText>" + Environment.NewLine);

                    // Write out the value for PropertyName

                    sb.Append(indentString2);
                    sb.Append("<PropertyName>" + method.PropertyName + "</PropertyName>" + Environment.NewLine);

                    // Write out the value for TopRows

                    sb.Append(indentString2);
                    sb.Append("<TopRows>" + method.TopRows + "</TopRows>" + Environment.NewLine);

                    // Write out the value for UseCustomReader

                    sb.Append(indentString2);
                    sb.Append("<UseCustomReader>" + method.UseCustomReader + "</UseCustomReader>" + Environment.NewLine);

                    // Write out the value for ProcedureText

                    sb.Append(indentString2);
                    sb.Append("<ProcedureText>" + method.ProcedureText + "</ProcedureText>" + Environment.NewLine);

                    // Write out the value for UseCustomWhere

                    sb.Append(indentString2);
                    sb.Append("<UseCustomWhere>" + method.UseCustomWhere + "</UseCustomWhere>" + Environment.NewLine);

                    // Write out the value for WhereText

                    sb.Append(indentString2);
                    sb.Append("<WhereText>" + method.WhereText + "</WhereText>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close method node
                    sb.Append("</Method>" + Environment.NewLine);

                    // set the return value
                    methodXml = sb.ToString();
                }
                // return value
                return methodXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
