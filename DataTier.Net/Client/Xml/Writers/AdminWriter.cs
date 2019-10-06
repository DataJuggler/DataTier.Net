

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

    #region class AdminWriter
    /// <summary>
    /// This class is used to export an instance or a list of 'Admin' objects to xml.
    /// </summary>
    public class AdminWriter
    {

        #region Methods

            #region ExportList(List<Admin> admins, int indent = 0)
            // <Summary>
            // This method is used to export a list of 'Admin' objects to xml
            // </Summary>
            public string ExportList(List<Admin> admins, int indent = 0)
            {
                // initial value
                string xml = "";

                // locals
                string adminsXml = String.Empty;
                string indentString = TextHelper.Indent(indent);

                // Create a new instance of a StringBuilder object
                StringBuilder sb = new StringBuilder();

                // Add the indentString
                sb.Append(indentString);

                // Add the open Admin Node
                sb.Append("<Admins>");

                // Add a new line
                sb.Append(Environment.NewLine);

                // If there are one or more Admin objects
                if ((admins != null) && (admins.Count > 0))
                {
                    // Iterate the admins collection
                    foreach (Admin admin  in admins)
                    {
                        // Get the xml for this admins
                        adminsXml = ExportAdmin(admin, indent + 2);

                        // If the adminsXml string exists
                        if (TextHelper.Exists(adminsXml))
                        {
                            // Add this admins to the xml
                            sb.Append(adminsXml);
                        }
                    }
                }

                // Add the close AdminsWriter Node
                sb.Append(indentString);
                sb.Append("</Admins>");

                // Set the return value
                xml = sb.ToString();

                // return value
                return xml;
            }
            #endregion

            #region ExportAdmin(Admin admin, int indent = 0)
            // <Summary>
            // This method is used to export a Admin object to xml.
            // </Summary>
            public string ExportAdmin(Admin admin, int indent = 0)
            {
                // initial value
                string adminXml = "";

                // locals
                string indentString = TextHelper.Indent(indent);
                string indentString2 = TextHelper.Indent(indent + 2);

                // If the admin object exists
                if (NullHelper.Exists(admin))
                {
                    // Create a StringBuilder
                    StringBuilder sb = new StringBuilder();

                    // Append the indentString
                    sb.Append(indentString);

                    // Write the open admin node
                    sb.Append("<Admin>" + Environment.NewLine);

                    // Write out each property

                    // Write out the value for AdminId

                    sb.Append(indentString2);
                    sb.Append("<AdminId>" + admin.AdminId + "</AdminId>" + Environment.NewLine);

                    // Write out the value for CodeVersion

                    sb.Append(indentString2);
                    sb.Append("<CodeVersion>" + admin.CodeVersion + "</CodeVersion>" + Environment.NewLine);

                    // Write out the value for GitCommit

                    sb.Append(indentString2);
                    sb.Append("<GitCommit>" + admin.GitCommit + "</GitCommit>" + Environment.NewLine);

                    // Write out the value for IsNew

                    sb.Append(indentString2);
                    sb.Append("<IsNew>" + admin.IsNew + "</IsNew>" + Environment.NewLine);

                    // Write out the value for LastUpdated

                    sb.Append(indentString2);
                    sb.Append("<LastUpdated>" + admin.LastUpdated + "</LastUpdated>" + Environment.NewLine);

                    // Write out the value for SchemaHash

                    sb.Append(indentString2);
                    sb.Append("<SchemaHash>" + admin.SchemaHash + "</SchemaHash>" + Environment.NewLine);

                    // Append the indentString
                    sb.Append(indentString);

                    // Write out the close admin node
                    sb.Append("</Admin>" + Environment.NewLine);

                    // set the return value
                    adminXml = sb.ToString();
                }
                // return value
                return adminXml;
            }
            #endregion

        #endregion

    }
    #endregion

}
