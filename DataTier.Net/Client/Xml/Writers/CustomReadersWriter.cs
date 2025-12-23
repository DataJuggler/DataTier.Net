

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

    #region class CustomReadersWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'CustomReader' objects to xml.
    /// </summary>
    public class CustomReadersWriter
    {

        #region Methods

            #region ExportList(List<CustomReader> customReaders, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'CustomReader' objects to xml
            // </Summary>
            public string ExportList(List<CustomReader> customReaders, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string customReadersXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open CustomReader Node
                sb.Append("<CustomReaders>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more CustomReader objects
                if ((customReaders != null) && (customReaders.Count > 0))
                {
                    // Iterate the customReaders collection
                    foreach (CustomReader customReader  in customReaders)
                    {
                        // Get the xml for this customReaders
                        customReadersXml = ExportCustomReader(customReader, indent + 2);

                        // If the customReadersXml string exists
                        if (TextHelper.Exists(customReadersXml))
                        {
                            // Add this customReaders to the xml
                            sb.Append(customReadersXml);
                        }
                    }
                }

                // Add the close CustomReadersWriter Node
                sb.Append(indentString);
                sb.Append("</CustomReaders>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportCustomReader(CustomReader customReader, int indent = 0)
            // <Summary>
            // This method is used to export a CustomReader object to xml.
            // </Summary>
            public string ExportCustomReader(CustomReader customReader, int indent = 0)
            {
                // initial value
                string customReaderXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the customReader object exists
                if (NullHelper.Exists(customReader))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open customReader node
                    sb.Append("<CustomReader>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for ClassName

                    sb.Append(indentString2);
                    sb.Append("<ClassName>" + customReader.ClassName + "</ClassName>" + Environment.NewLine);

                    // Write out the value for FetchAllForTable

                    sb.Append(indentString2);
                    sb.Append("<FetchAllForTable>" + customReader.LoadByTableId + "</FetchAllForTable>" + Environment.NewLine);

                    // If the value for the property customReader.HasFieldSet is true
                    if (customReader.HasFieldSet)
                    {
                        // Write out the value for FieldSet

                        // create a second writer
                        FieldSetsWriter fieldSetsWriter = new FieldSetsWriter();

                        // get the fieldSetsExml
                        string fieldSetXml = fieldSetsWriter.ExportFieldSet(customReader.FieldSet, indent + 1);

                        sb.Append(indentString2);
                        sb.Append(fieldSetXml);
                    }

                    // Write out the value for FieldSetId

                    sb.Append(indentString2);
                    sb.Append("<FieldSetId>" + customReader.FieldSetId + "</FieldSetId>" + Environment.NewLine);

                    // Write out the value for ReaderName

                    sb.Append(indentString2);
                    sb.Append("<ReaderName>" + customReader.ReaderName + "</ReaderName>" + Environment.NewLine);

                    // Write out the value for TableId

                    sb.Append(indentString2);
                    sb.Append("<TableId>" + customReader.TableId + "</TableId>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close customReader node
                    sb.Append("</CustomReader>" + Environment.NewLine);

                    // set the return value
                    customReaderXml = sb.ToString();
                }
                // return value
                return customReaderXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
