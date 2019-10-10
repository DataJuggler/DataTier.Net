

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

    #region class FieldSetFieldsWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'FieldSetField' objects to xml.
    /// </summary>
    public class FieldSetFieldsWriter
    {

        #region Methods

            #region ExportList(List<FieldSetFieldView> fieldSetFields, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'FieldSetField' objects to xml
            // </Summary>
            public string ExportList(List<FieldSetFieldView> fieldSetFields, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string fieldSetFieldsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open FieldSetField Node
                sb.Append("<FieldSetFields>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more FieldSetField objects
                if ((fieldSetFields != null) && (fieldSetFields.Count > 0))
                {
                    // Iterate the fieldSetFields collection
                    foreach (FieldSetFieldView fieldSetField  in fieldSetFields)
                    {
                        // Get the xml for this fieldSetFields
                        fieldSetFieldsXml = ExportFieldSetField(fieldSetField, indent + 2);

                        // If the fieldSetFieldsXml string exists
                        if (TextHelper.Exists(fieldSetFieldsXml))
                        {
                            // Add this fieldSetFields to the xml
                            sb.Append(fieldSetFieldsXml);
                        }
                    }
                }

                // Add the close FieldSetFieldsWriter Node
                sb.Append(indentString);
                sb.Append("</FieldSetFields>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportFieldSetField(FieldSetFieldView fieldSetField, int indent = 0)
            // <Summary>
            // This method is used to export a FieldSetField object to xml.
            // </Summary>
            public string ExportFieldSetField(FieldSetFieldView fieldSetField, int indent = 0)
            {
                // initial value
                string fieldSetFieldXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the fieldSetField object exists
                if (NullHelper.Exists(fieldSetField))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open fieldSetField node
                    sb.Append("<FieldSetField>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for Descending
                    sb.Append(indentString2);
                    sb.Append("<Descending>" + fieldSetField.OrderByDescending + "</Descending>" + Environment.NewLine);

                    // Write out the value for FieldId

                    sb.Append(indentString2);
                    sb.Append("<FieldId>" + fieldSetField.FieldId + "</FieldId>" + Environment.NewLine);

                    // Write out the value for FieldOrdinal

                    sb.Append(indentString2);
                    sb.Append("<FieldOrdinal>" + fieldSetField.FieldOrdinal + "</FieldOrdinal>" + Environment.NewLine);

                    // Write out the value for FieldSetId

                    sb.Append(indentString2);
                    sb.Append("<FieldSetId>" + fieldSetField.FieldSetId + "</FieldSetId>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close fieldSetField node
                    sb.Append("</FieldSetField>" + Environment.NewLine);

                    // set the return value
                    fieldSetFieldXml = sb.ToString();
                }
                // return value
                return fieldSetFieldXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
