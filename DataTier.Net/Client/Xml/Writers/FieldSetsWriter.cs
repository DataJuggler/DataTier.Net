

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

    #region class FieldSetsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'FieldSet' objects to xml.
    /// </summary>
    public class FieldSetsWriter
    {

        #region Methods

            #region ExportList(List<FieldSet> fieldSets, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'FieldSet' objects to xml
            // </Summary>
            public string ExportList(List<FieldSet> fieldSets, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string fieldSetsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open FieldSet Node
                sb.Append("<FieldSets>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more FieldSet objects
                if ((fieldSets != null) && (fieldSets.Count > 0))
                {
                    // Iterate the fieldSets collection
                    foreach (FieldSet fieldSet  in fieldSets)
                    {
                        // Get the xml for this fieldSets
                        fieldSetsXml = ExportFieldSet(fieldSet, indent + 2);

                        // If the fieldSetsXml string exists
                        if (TextHelper.Exists(fieldSetsXml))
                        {
                            // Add this fieldSets to the xml
                            sb.Append(fieldSetsXml);
                        }
                    }
                }

                // Add the close FieldSetsWriter Node
                sb.Append(indentString);
                sb.Append("</FieldSets>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportFieldSet(FieldSet fieldSet, int indent = 0)
            // <Summary>
            // This method is used to export a FieldSet object to xml.
            // </Summary>
            public string ExportFieldSet(FieldSet fieldSet, int indent = 0)
            {
                // initial value
                string fieldSetXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the fieldSet object exists
                if (NullHelper.Exists(fieldSet))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open fieldSet node
                    sb.Append("<FieldSet>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for Delete

                    sb.Append(indentString2);
                    sb.Append("<Delete>" + fieldSet.Delete + "</Delete>" + Environment.NewLine);

                    // Write out the value for FetchAllForTable

                    sb.Append(indentString2);
                    sb.Append("<FetchAllForTable>" + fieldSet.FetchAllForTable + "</FetchAllForTable>" + Environment.NewLine);

                    // Write out the value for Fields

                    // Create the FieldsWriter
                    FieldsWriter fieldsWriter = new FieldsWriter();

                    // Export the Fields collection to xml
                    string dTNFieldXml = fieldsWriter.ExportList(fieldSet.Fields, indent + 2);
                    sb.Append(dTNFieldXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for FieldSetFields

                    // Create the FieldSetFieldsWriter
                    FieldSetFieldsWriter fieldSetFieldsWriter = new FieldSetFieldsWriter();

                    // Export the FieldSetFields collection to xml
                    string fieldSetFieldXml = fieldSetFieldsWriter.ExportList(fieldSet.FieldSetFields, indent + 2);
                    sb.Append(fieldSetFieldXml);
                    sb.Append(Environment.NewLine);

                    // Write out the value for Name

                    sb.Append(indentString2);
                    sb.Append("<Name>" + fieldSet.Name + "</Name>" + Environment.NewLine);

                    // Write out the value for OrderByMode

                    sb.Append(indentString2);
                    sb.Append("<OrderByMode>" + fieldSet.OrderByMode + "</OrderByMode>" + Environment.NewLine);

                    // Write out the value for ParameterMode

                    sb.Append(indentString2);
                    sb.Append("<ParameterMode>" + fieldSet.ParameterMode + "</ParameterMode>" + Environment.NewLine);

                    // Write out the value for ReaderMode

                    sb.Append(indentString2);
                    sb.Append("<ReaderMode>" + fieldSet.ReaderMode + "</ReaderMode>" + Environment.NewLine);

                    // Write out the value for TableId

                    sb.Append(indentString2);
                    sb.Append("<TableId>" + fieldSet.TableId + "</TableId>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close fieldSet node
                    sb.Append("</FieldSet>" + Environment.NewLine);

                    // set the return value
                    fieldSetXml = sb.ToString();
                }

                // return value
                return fieldSetXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
