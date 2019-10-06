

#region using statements

using ObjectLibrary.BusinessObjects;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime.Objects;
using XmlMirror.Runtime.Util;

#endregion

namespace DataTierClient.Xml.Parsers
{

    #region class AdminParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Admin' objects.
    /// </summary>
    public partial class AdminParser : ParserBaseClass
    {

        #region Methods

            #region ParseAdmin(string adminXmlText)
            /// <summary>
            /// This method is used to parse an object of type 'Admin'.
            /// </summary>
            /// <param name="adminXmlText">The source xml to be parsed.</param>
            /// <returns>An object of type 'Admin'.</returns>
            public Admin ParseAdmin(string adminXmlText)
            {
                // initial value
                Admin admin = null;

                // if the sourceXmlText exists
                if (TextHelper.Exists(adminXmlText))
                {
                    // create an instance of the parser
                    XmlParser parser = new XmlParser();

                    // Create the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument(adminXmlText);

                    // If the XmlDoc exists and has a root node.
                    if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                    {
                        // Create a new admin
                        admin = new Admin();

                        // Perform preparsing operations
                        bool cancel = Parsing(this.XmlDoc.RootNode, ref admin);

                        // if the parsing should not be cancelled
                        if (!cancel)
                        {
                            // Parse the 'Admin' object
                            admin = ParseAdmin(ref admin, this.XmlDoc.RootNode);

                            // Perform post parsing operations
                            cancel = Parsed(this.XmlDoc.RootNode, ref admin);

                            // if the parsing should be cancelled
                            if (cancel)
                            {
                                // Set the 'admin' object to null
                                admin = null;
                            }
                        }
                    }
                }

                // return value
                return admin;
            }
            #endregion

            #region ParseAdmin(ref Admin admin, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse Admin objects.
            /// </summary>
            public Admin ParseAdmin(ref Admin admin, XmlNode xmlNode)
            {
                // if the admin object exists and the xmlNode exists
                if ((admin != null) && (xmlNode != null))
                {
                    // locals
                    DateTime defaultDate = new DateTime(2000, 1, 1);
                    DateTime errorDate = new DateTime(1900, 1, 1);

                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Admin.CodeVersion":

                            // Set the value for admin.CodeVersion
                            admin.CodeVersion = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Admin.GitCommit":

                            // Set the value for admin.GitCommit
                            admin.GitCommit = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Admin.LastUpdated":

                            // Set the value for admin.LastUpdated
                            admin.LastUpdated = DateHelper.ParseDate(xmlNode.FormattedNodeValue, defaultDate, errorDate);

                            // required
                            break;

                        case "Admin.SchemaHash":

                            // Set the value for admin.SchemaHash
                            admin.SchemaHash = xmlNode.FormattedNodeValue;

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this Admin
                            admin = ParseAdmin(ref admin, childNode);
                        }
                    }
                }

                // return value
                return admin;
            }
            #endregion

        #endregion

    }
    #endregion

}
