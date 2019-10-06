

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

    #region class AdminsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'Admin' objects.
    /// </summary>
    public partial class AdminParser : ParserBaseClass
    {

        #region Events

            #region Parsing(XmlNode xmlNode)
            /// <summary>
            /// This event is fired BEFORE the collection is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort parsing this collection.

                // return value
                return cancel;
            }
            #endregion

            #region Parsing(XmlNode xmlNode, ref Admin admin)
            /// <summary>
            /// This event is fired when a single object is initialized.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="admin"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsing(XmlNode xmlNode, ref Admin admin)
            {
                // initial value
                bool cancel = false;

                // Add any pre processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

            #region Parsed(XmlNode xmlNode, ref Admin admin)
            /// <summary>
            /// This event is fired AFTER the admin is parsed.
            /// </summary>
            /// <param name="xmlNode"></param>
            /// <param name="admin"></param>
            /// <returns>True if cancelled else false if not.</returns>
            public bool Parsed(XmlNode xmlNode, ref Admin admin)
            {
                // initial value
                bool cancel = false;

                // Add any post processing code here. Set cancel to true to abort adding this object.

                // return value
                return cancel;
            }
            #endregion

        #endregion

    }
    #endregion

}
