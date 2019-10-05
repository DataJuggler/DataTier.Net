

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

    #region class FieldsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'DTNField' objects to xml.
    /// </summary>
    public class FieldsWriter
    {

        #region Methods

            #region ExportList(List<DTNField> fields, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'DTNField' objects to xml
            // </Summary>
            public string ExportList(List<DTNField> fields, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string fieldsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open DTNField Node
                sb.Append("<Fields>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more DTNField objects
                if ((fields != null) && (fields.Count > 0))
                {
                    // Iterate the fields collection
                    foreach (DTNField dTNField  in fields)
                    {
                        // Get the xml for this fields
                        fieldsXml = ExportDTNField(dTNField, indent + 2);

                        // If the fieldsXml string exists
                        if (TextHelper.Exists(fieldsXml))
                        {
                            // Add this fields to the xml
                            sb.Append(fieldsXml);
                        }
                    }
                }

                // Add the close FieldsWriter Node
                sb.Append(indentString);
                sb.Append("</Fields>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportDTNField(DTNField dTNField, int indent = 0)
            // <Summary>
            // This method is used to export a DTNField object to xml.
            // </Summary>
            public string ExportDTNField(DTNField dTNField, int indent = 0)
            {
                // initial value
                string dTNFieldXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the dTNField object exists
                if (NullHelper.Exists(dTNField))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open dTNField node
                    sb.Append("<DTNField>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for AccessMode

                    sb.Append(indentString2);
                    sb.Append("<AccessMode>" + dTNField.AccessMode + "</AccessMode>" + Environment.NewLine);

                    // Write out the value for Caption

                    sb.Append(indentString2);
                    sb.Append("<Caption>" + dTNField.Caption + "</Caption>" + Environment.NewLine);

                    // Write out the value for DatabaseId

                    sb.Append(indentString2);
                    sb.Append("<DatabaseId>" + dTNField.DatabaseId + "</DatabaseId>" + Environment.NewLine);

                    // Write out the value for DataType

                    sb.Append(indentString2);
                    sb.Append("<DataType>" + dTNField.DataType + "</DataType>" + Environment.NewLine);

                    // Write out the value for DecimalPlaces

                    sb.Append(indentString2);
                    sb.Append("<DecimalPlaces>" + dTNField.DecimalPlaces + "</DecimalPlaces>" + Environment.NewLine);

                    // Write out the value for DefaultValue

                    sb.Append(indentString2);
                    sb.Append("<DefaultValue>" + dTNField.DefaultValue + "</DefaultValue>" + Environment.NewLine);

                    // Write out the value for DeleteAllForProject

                    sb.Append(indentString2);
                    sb.Append("<DeleteAllForProject>" + dTNField.DeleteAllForProject + "</DeleteAllForProject>" + Environment.NewLine);

                    // Write out the value for Descending

                    sb.Append(indentString2);
                    sb.Append("<Descending>" + dTNField.Descending.ToString() + "</Descending>" + Environment.NewLine);

                    // Write out the value for Exclude

                    sb.Append(indentString2);
                    sb.Append("<Exclude>" + dTNField.Exclude + "</Exclude>" + Environment.NewLine);

                    // Write out the value for FetchAllForFieldSet

                    sb.Append(indentString2);
                    sb.Append("<FetchAllForFieldSet>" + dTNField.FetchAllForFieldSet + "</FetchAllForFieldSet>" + Environment.NewLine);

                    // Write out the value for FetchAllForTable

                    sb.Append(indentString2);
                    sb.Append("<FetchAllForTable>" + dTNField.FetchAllForTable + "</FetchAllForTable>" + Environment.NewLine);

                    // Write out the value for FieldName

                    sb.Append(indentString2);
                    sb.Append("<FieldName>" + dTNField.FieldName + "</FieldName>" + Environment.NewLine);

                    // Write out the value for FieldOrdinal

                    sb.Append(indentString2);
                    sb.Append("<FieldOrdinal>" + dTNField.FieldOrdinal + "</FieldOrdinal>" + Environment.NewLine);

                    // Write out the value for FieldSetId

                    sb.Append(indentString2);
                    sb.Append("<FieldSetId>" + dTNField.FieldSetId + "</FieldSetId>" + Environment.NewLine);

                    // Write out the value for FieldSize

                    sb.Append(indentString2);
                    sb.Append("<FieldSize>" + dTNField.FieldSize + "</FieldSize>" + Environment.NewLine);

                    // Write out the value for IsNullable

                    sb.Append(indentString2);
                    sb.Append("<IsNullable>" + dTNField.IsNullable + "</IsNullable>" + Environment.NewLine);

                    // Write out the value for PrimaryKey

                    sb.Append(indentString2);
                    sb.Append("<PrimaryKey>" + dTNField.PrimaryKey + "</PrimaryKey>" + Environment.NewLine);

                    // Write out the value for ProjectId

                    sb.Append(indentString2);
                    sb.Append("<ProjectId>" + dTNField.ProjectId + "</ProjectId>" + Environment.NewLine);

                    // Write out the value for Required

                    sb.Append(indentString2);
                    sb.Append("<Required>" + dTNField.Required + "</Required>" + Environment.NewLine);

                    // Write out the value for Scope

                    sb.Append(indentString2);
                    sb.Append("<Scope>" + dTNField.Scope + "</Scope>" + Environment.NewLine);

                    // Write out the value for TableId

                    sb.Append(indentString2);
                    sb.Append("<TableId>" + dTNField.TableId + "</TableId>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close dTNField node
                    sb.Append("</DTNField>" + Environment.NewLine);

                    // set the return value
                    dTNFieldXml = sb.ToString();
                }
                // return value
                return dTNFieldXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
