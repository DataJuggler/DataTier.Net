

#region using statements

using DataJuggler.UltimateHelper;

#endregion

namespace ConfigUpdater
{

    #region class MainForm
    /// <summary>
    /// This form is the main form for this app.
    /// </summary>
    public partial class MainForm : Form
    {
        
        #region Private Variables
        private string appConfigPath;
        private int attempts;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
            #region CloseTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Close Timer _ Tick
            /// </summary>
            private void CloseTimer_Tick(object sender, EventArgs e)
            {
                // Call done
                Done_Click(this, new EventArgs());
            }
            #endregion
            
            #region ConfigTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Config Timer _ Tick
            /// </summary>
            private void ConfigTimer_Tick(object sender, EventArgs e)
            {
                // Increment the value for Attempts
                Attempts++;

                // if Attemps is greater than 1 and the AppConfigPath exists                
                if ((Attempts > 1) && (HasAppConfigPath))
                {
                    

                    try
                    {
                        // if the file exists on disk
                        if (FileHelper.Exists(AppConfigPath))
                        {
                            // if the text is not already set
                            if (!AppConfigPathControl.HasText)
                            {
                                // Display the path
                                AppConfigPathControl.Text = AppConfigPath;
                            }

                           
                        }                        
                    }
                    catch (Exception error)
                    {
                        // For debugging only
                        DebugHelper.WriteDebugError("ConfigTimer_Tick", "MainForm.cs", error);

                        // Change the text
                        InfoLabel.Text = "Oops, your config file could not be updated.";
                        InfoLabel.ForeColor = Color.Firebrick;
                    }
                }
            }
            #endregion
            
            #region ConvertButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ConvertButton' is clicked.
            /// </summary>
            private void ConvertButton_Click(object sender, EventArgs e)
            {
                // read in the new file
                string fileText = File.ReadAllText(AppConfigPath);

                // If the fileText string exists
                if (TextHelper.Exists(fileText))
                {
                    // get the new file name
                    string newName = AppConfigPath.Replace(".newconfig", "");

                    // Delete the old one
                    File.Delete(newName);

                    // Write out the text
                    File.WriteAllText(newName, fileText);

                    // Change the text
                    InfoLabel.Text = "DataTier.Net can now be restarted. This app will close";
                    InfoLabel.ForeColor = Color.LemonChiffon;                   

                    // Close the app
                    CloseTimer.Start();
                }
            }
            #endregion
            
            #region Done_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'Done' is clicked.
            /// </summary>
            private void Done_Click(object sender, EventArgs e)
            {
                // close the app
                Application.Exit();
            }
            #endregion
            
        #endregion

        #region Properties
            
            #region AppConfigPath
            /// <summary>
            /// This property gets or sets the value for 'AppConfigPath'.
            /// </summary>
            public string AppConfigPath
            {
                get { return appConfigPath; }
                set { appConfigPath = value; }
            }
            #endregion
            
            #region Attempts
            /// <summary>
            /// This property gets or sets the value for 'Attempts'.
            /// </summary>
            public int Attempts
            {
                get { return attempts; }
                set { attempts = value; }
            }
            #endregion
            
            #region HasAppConfigPath
            /// <summary>
            /// This property returns true if the 'AppConfigPath' exists.
            /// </summary>
            public bool HasAppConfigPath
            {
                get
                {
                    // initial value
                    bool hasAppConfigPath = (!String.IsNullOrEmpty(this.AppConfigPath));
                    
                    // return value
                    return hasAppConfigPath;
                }
            }
        #endregion

        #endregion
    }
    #endregion

}

