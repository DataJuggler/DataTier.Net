

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DataTierClient.Controls.Interfaces;
using DataTierClient.Forms;
using DataTierClient.Controls.Images;
using DataTierClient.Objects;
using DataTierClient.ClientUtil;

#endregion

namespace DataTierClient.Controls
{

    #region class SetupControl
    /// <summary>
    /// This class is used to ensure DataTier.Net is setup properly
    /// </summary>
    public partial class SetupDataTierNetControl : UserControl, ITabButtonParent
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SetupControl' object.
        /// </summary>
        public SetupDataTierNetControl()
        {
            // Create controls
            InitializeComponent();

            // Perform Initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region Information_MouseEnter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Information _ Mouse Enter
            /// </summary>
            private void Information_MouseEnter(object sender, EventArgs e)
            {
                // Show the label
                this.WritersLabel.Visible = true;
            }
            #endregion
            
            #region Information_MouseHover(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Information _ Mouse Hover
            /// </summary>
            private void Information_MouseHover(object sender, EventArgs e)
            {
                // Show the label
                this.WritersLabel.Visible = true;
            }
            #endregion
            
            #region Information_MouseLeave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Information _ Mouse Leave
            /// </summary>
            private void Information_MouseLeave(object sender, EventArgs e)
            {
                // Hide the label
                this.WritersLabel.Visible = false;
            }
            #endregion
            
            #region OnTabButtonClicked(TabButton tabButton)
            /// <summary>
            /// This event is fired when On Tab Button Clicked
            /// </summary>
            public void OnTabButtonClicked(TabButton tabButton)
            {
                // if the tabButton exists
                if (tabButton != null)
                {
                    // determine the button that was clicked
                    switch (tabButton.ButtonNumber)
                    {
                        case 1:

                            // launch the ConnectionStringBuilder
                            LaunchConnectionStringBuilder();

                            // required
                            break;

                        case 2:

                            // launch the ConfigurationManager
                            TestDatabaseConnection();

                            // required
                            break;

                        case 3:

                            // Update the Configuration File
                            UpdateSetupComplete();

                            // required
                            break;
                    }
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region CreateAppSettingsObject()
            /// <summary>
            /// This method returns the App Settings Object
            /// </summary>
            private AppSettingsObject CreateAppSettingsObject()
            {
                // initial value
                AppSettingsObject appSettingsObject = new AppSettingsObject();

                // get the configuration file path
                string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

                // locals
                bool appSettingsStarted = false;
                bool appSettingsEnded = false;
                bool isAppSettingStartLine = false;
                bool isAppSettingEndLine = false;
                
                // if the File exists
                if (File.Exists(configFile))
                {
                    // Set the configFileText
                    string configFileText = File.ReadAllText(configFile);

                    // if the configFileText exists
                    if (TextHelper.Exists(configFileText))
                    {
                        // Convert the configFileText to Lines
                        List<TextLine> lines = WordParser.GetTextLines(configFileText);

                        // if there are one or more textLines
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // iterate the textLines
                            foreach (TextLine line in lines)
                            {  
                                // Set the value for isAppSettingStartLine
                                isAppSettingStartLine = line.Text.Contains("<appSettings>");
                                isAppSettingEndLine = line.Text.Contains("</appSettings>");

                                // if the appSettings has been started and this is not the AppSettingsStartLine
                                if ((!appSettingsStarted) && (!isAppSettingStartLine))
                                {
                                    // add this line to the before app settings
                                    appSettingsObject.LinesBeforeAppSettings.Add(line);
                                }
                                else if (isAppSettingStartLine)
                                {
                                    // set appSettingsStarted to true
                                    appSettingsStarted = true;

                                    // Add this line
                                    appSettingsObject.AppSettingsLines.Add(line);
                                }
                                // if the appSettings has started and has not endedd 
                                else if ((appSettingsStarted) && (!appSettingsEnded))
                                {
                                    // Add this line
                                    appSettingsObject.AppSettingsLines.Add(line);

                                    // if this is the AppSettings End Line
                                    if (isAppSettingEndLine)
                                    {
                                        // set appSettingsEnded to true
                                        appSettingsEnded = true;
                                    }
                                }
                                // if the AppSettings has ended and this is not the appSettingsEndLine
                                else if (appSettingsEnded)
                                {
                                    // add this line to the before app settings
                                    appSettingsObject.LinesAfterAppSettings.Add(line);
                                }
                            }
                        }
                    }
                }

                // return value
                return appSettingsObject;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Load the BackgroundImage
                this.DontShowAgainButton.BackgroundImage = ImageHelper.LoadImage(Enumerations.ButtonImagesEnum.DeepGray);
            }
            #endregion
            
            #region LaunchConfigurationManager()
            /// <summary>
            /// This method Launch Configuration Manager
            /// </summary>
            private void LaunchConnectionStringBuilder()
            {
                // set the path
                string temp = "../../../Tools/ConnectionStringBuilder/ConnectionBuilder/bin/Debug/ConnectionBuilder.exe";
                
                // get the fullPath
                string path = Path.GetFullPath(temp);

                // if the path exists
                if (File.Exists(path))
                {
                    // set the databaseName
                    string databaseName = "";

                    // create a StartInfo
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(path, databaseName);
                    // System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(path);

                    // start the process
                    System.Diagnostics.Process.Start(startInfo);
                }
                else
                {
                    // Set the MessageBoxShow
                    MessageBox.Show("Sorry we could not find DataTier.Net Connection String Builder.", "App Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            
            #region TestDatabaseConnection()
            /// <summary>
            /// This method Test Database Connection
            /// </summary>
            private void TestDatabaseConnection()
            {
                // if the ParentMainForm exists
                if (this.HasParentMainForm)
                {
                    // Test the connectionTest
                    bool connectionTest = this.ParentMainForm.TestDatabaseConnection();

                    // if the connectionTest exists
                    if (connectionTest)
                    {
                        // Enable DontShowAgainButton
                        this.DontShowAgainButton.Enabled = true;

                        // Enable the button
                        this.DontShowAgainButton.BackgroundImage = ImageHelper.LoadImage(Enumerations.ButtonImagesEnum.DeepBlue);
                    }
                    else
                    {
                        // Set the Show
                        MessageBox.Show("A connection to the DataTier.Net database could not be established.", "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            #endregion
            
            #region UpdateSetupComplete()
            /// <summary>
            /// This method Update Setup Complete
            /// </summary>
            private void UpdateSetupComplete()
            {
                try
                {
                    // Create the appSettingsObject
                    AppSettingsObject appSettingsObject = CreateAppSettingsObject();

                    // if the appSettingsObject does exist
                    if (appSettingsObject != null)
                    {
                        // if the HasSetjupComplete value is present
                        if (appSettingsObject.HasSetupComplete)
                        {
                            // the appSettingsObject does have a SetupCompleteEntry, so we must update it
                            appSettingsObject.UpdateSetupCompleteValue(true);
                        }
                        else
                        {
                            // the appSettingsObject does not have a SetupCompleteEntry, so we must create it
                            appSettingsObject.AddSetupCompleteValue(true);
                        }

                        // Get the updated text
                        string appSettingsText = appSettingsObject.GetAppSettingsText();

                        // do not continue without text
                        if (TextHelper.Exists(appSettingsText))
                        {
                            // get the configuration file path
                            string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

                            // if the configFile exists
                            if (File.Exists(configFile))
                            {
                                // Write out the text
                                File.WriteAllText(configFile, appSettingsText);

                                // we also must update the app.config file itself
                                string appConfigFile = Path.GetFullPath("../../App.config");

                                // if appConfigFile exists
                                if (File.Exists(appConfigFile))
                                {
                                    // Write out the text
                                    File.WriteAllText(appConfigFile, appSettingsText);
                                }

                                // Hide this control
                                this.Visible = false;
                            }
                        }
                        else
                        {
                            // Show the user a message how to manually update
                            MessageBox.Show("We were not able to update the app.config file. Add an entry for 'SetupComplete = true in the AppSettings section.", "App Config Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // Show the user a message how to manually update
                    MessageBox.Show("We were not able to update the app.config file. Add an entry for 'SetupComplete = true in the AppSettings section.", "App Config Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasParentMainForm
            /// <summary>
            /// This property returns true if this object has a 'ParentMainForm'.
            /// </summary>
            public bool HasParentMainForm
            {
                get
                {
                    // initial value
                    bool hasParentMainForm = (this.ParentMainForm != null);
                    
                    // return value
                    return hasParentMainForm;
                }
            }
            #endregion
            
            #region ParentMainForm
            /// <summary>
            /// This read only property returns the value for 'ParentMainForm'.
            /// </summary>
            public MainForm ParentMainForm
            {
                get
                {
                    // initial value
                    MainForm parentMainForm = this.ParentForm as MainForm;

                    // return value
                    return parentMainForm;
                }
            }
        #endregion

        #endregion


    }
    #endregion

}
