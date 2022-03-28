

#region using statements

using DataJuggler.Core.UltimateHelper.Objects;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTierClient.ClientUtil;

#endregion

namespace DataTierClient.Objects
{

    #region class AppSettingsObject
    /// <summary>
    /// This class is used to hold all the TextLines from the App.config file so the file can be updated with SetupComplete
    /// </summary>
    public class AppSettingsObject
    {
        
        #region Private Variables
        private List<TextLine> linesBeforeAppSettings;
        private List<TextLine> appSettingsLines;
        private List<TextLine> linesAfterAppSettings;
        #endregion

        #region Default Constructor
        /// <summary>
        /// Create a new instance of an AppSettingsObject
        /// </summary>
        public AppSettingsObject()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Methods            

            #region GetAppSettingsText()
            /// <summary>
            /// This method returns the text of all the text lines
            /// </summary>
            /// <returns></returns>
            public string GetAppSettingsText()
            {   
                // initial value
                string appSettingsText = "";

                // create a string builder
                StringBuilder sb = new StringBuilder();

                // now get the text for each of the TextLine collecion
                string linesBeforeText = GetTextFromLines(this.LinesBeforeAppSettings);
                string appSettingsLinesText = GetTextFromLines(this.AppSettingsLines);
                string linesAfterText = GetTextFromLines(this.LinesAfterAppSettings);

                // now add each of these lines text
                sb.Append(linesBeforeText);
                sb.Append(appSettingsLinesText);
                sb.Append(linesAfterText);

                // set the return value
                appSettingsText = sb.ToString();

                // return value
                return appSettingsText;
            }
            #endregion
            
            #region GetTextFromLines(List<TextLine> list)
            /// <summary>
            /// This method returns a list of Text From Lines
            /// </summary>
            private string GetTextFromLines(List<TextLine> list)
            {
                // initial value
                string text = "";

                // create a string builder
                StringBuilder sb = new StringBuilder();

                // if there are one or more lines in the list
                if (ListHelper.HasOneOrMoreItems(list))
                {
                    // iterate the list of lines
                    foreach (TextLine line in list)
                    {
                        // add this line
                        sb.Append(line.Text + Environment.NewLine);
                   }

                   // set the return value
                   text = sb.ToString();
                }

                // return value
                return text;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // create the collections
                linesBeforeAppSettings = new List<TextLine>();
                appSettingsLines = new List<TextLine>();
                linesAfterAppSettings = new List<TextLine>();
            }
            #endregion            
            
        #endregion

        #region Properties

            #region AppSettingsLines
            /// <summary>
            /// This property gets or sets the value for 'AppSettingsLines'.
            /// </summary>
            public List<TextLine> AppSettingsLines
            {
                get { return appSettingsLines; }
                set { appSettingsLines = value; }
            }
            #endregion

            #region HasAppSettingsLines
            /// <summary>
            /// This property returns true if this object has an 'AppSettingsLines'.
            /// </summary>
            public bool HasAppSettingsLines
            {
                get
                {
                    // initial value
                    bool hasAppSettingsLines = (this.AppSettingsLines != null);
                    
                    // return value
                    return hasAppSettingsLines;
                }
            }
            #endregion
            
            #region HasLinesAfterAppSettings
            /// <summary>
            /// This property returns true if this object has a 'LinesAfterAppSettings'.
            /// </summary>
            public bool HasLinesAfterAppSettings
            {
                get
                {
                    // initial value
                    bool hasLinesAfterAppSettings = (this.LinesAfterAppSettings != null);
                    
                    // return value
                    return hasLinesAfterAppSettings;
                }
            }
            #endregion
            
            #region HasLinesBeforeAppSettings
            /// <summary>
            /// This property returns true if this object has a 'LinesBeforeAppSettings'.
            /// </summary>
            public bool HasLinesBeforeAppSettings
            {
                get
                {
                    // initial value
                    bool hasLinesBeforeAppSettings = (this.LinesBeforeAppSettings != null);
                    
                    // return value
                    return hasLinesBeforeAppSettings;
                }
            }
            #endregion
            
            #region HasSetupComplete
            /// <summary>
            /// This read only property returns the value for 'HasSetupComplete'.
            /// </summary>
            public bool HasSetupComplete
            {
                get
                {
                    // initial value
                    bool hasSetupComplete = false;

                    // if the AppSettingsLines exists
                    if (this.HasAppSettingsLines)
                    {
                        // iterate the AppSettingsLines
                        foreach (TextLine line in this.AppSettingsLines)
                        {
                            // if the SetupCompleteLine has been reached
                            if (line.Text.Contains("SetupComplete"))
                            {
                                // set the return value to true
                                hasSetupComplete = true;
                            }
                        }
                    }
                    
                    // return value
                    return hasSetupComplete;
                }
            }
            #endregion
            
            #region LinesAfterAppSettings
            /// <summary>
            /// This property gets or sets the value for 'LinesAfterAppSettings'.
            /// </summary>
            public List<TextLine> LinesAfterAppSettings
            {
                get { return linesAfterAppSettings; }
                set { linesAfterAppSettings = value; }
            }
            #endregion
            
            #region LinesBeforeAppSettings
            /// <summary>
            /// This property gets or sets the value for 'LinesBeforeAppSettings'.
            /// </summary>
            public List<TextLine> LinesBeforeAppSettings
            {
                get { return linesBeforeAppSettings; }
                set { linesBeforeAppSettings = value; }
            }
            #endregion
            
        #endregion


    }
    #endregion

}
