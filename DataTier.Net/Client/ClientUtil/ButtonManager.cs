

#region using statements

using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class ButtonManager
    /// <summary>
    /// The buttons look better enabled but with a different background image and font color,
    /// so this handles the 'enabling'.
    /// </summary>
    public class ButtonManager
    {
        
        #region Private Variables
        private bool enableNewProject;
        private bool enableOpenProject;
        private bool enableEditProject;
        private bool enableCloseProject;
        private bool enableBuiildAll;
        private bool enableViewProjectSummary;
        private bool enableIncludeProjectFiles;
        #endregion

        #region Methods

            #region HandleButtonImage(Button button, bool enabled)
            /// <summary>
            /// This method Handle Button Image
            /// </summary>
            public void HandleButtonImage(Button button, bool enabled)
            {
                // If the button object exists
                if (NullHelper.Exists(button))
                {
                    // if enabled
                    if (enabled)
                    {
                        // appear enabled
                        button.BackgroundImage = Properties.Resources.Black_Button1;
                        button.ForeColor = Color.LemonChiffon;
                        button.Enabled = true;
                    }
                    else
                    {
                        // appear disabled
                        button.BackgroundImage = Properties.Resources.DarkBlackButton;
                        button.ForeColor = Color.DimGray;
                        button.Enabled = false;
                    }

                    // Refresh everything
                    button.Refresh();
                }
            }
            #endregion
            
            #region IsButtonEnabled(Button button)
            /// <summary>
            /// This method returns true if the button given should be enabled
            /// </summary>
            /// <param name="button"></param>
            /// <returns></returns>
            public bool IsButtonEnabled(Button button)
            {
                // initial value
                bool isButtonEnabled = false;
            
                // If the button object exists
                if (NullHelper.Exists(button))
                {
                    // determine the result by the name of the button
                    switch (button.Text)
                    {
                        case "New Project":

                            // Set the return value
                            isButtonEnabled = EnableNewProject;

                            // required
                            break;

                        case "Open Project":

                            // Set the return value
                            isButtonEnabled = EnableOpenProject;

                            // required
                            break;

                        case "Edit Project":

                            // Set the return value
                            isButtonEnabled = EnableEditProject;

                            // required
                            break;

                        case "Close Project":

                            // Set the return value
                            isButtonEnabled = EnableCloseProject;

                            // required
                            break;

                        case "Build All":

                            // Set the return value
                            isButtonEnabled = EnableBuiildAll;

                            // required
                            break;

                        case "View Project Summary":

                            // Set the return value
                            isButtonEnabled = EnableViewProjectSummary;

                            // required
                            break;

                        case "Include Project Files":

                            // Set the return value
                            isButtonEnabled = EnableIncludeProjectFiles;

                            // required
                            break;

                        case "Manage Data":

                            // Set to true
                            isButtonEnabled = true;

                            // required
                            break;

                        default: 

                            if ((button.Name.StartsWith("ViewPDF")) || (button.Name.StartsWith("ViewWord")))
                            {  
                                // Set to true
                                isButtonEnabled = true;
                            }

                            // required
                            break;
                    }
                }

                // return value
                return isButtonEnabled;
            }
            #endregion

        #endregion

        #region Properties

            #region EnableBuiildAll
            /// <summary>
            /// This property gets or sets the value for 'EnableBuiildAll'.
            /// </summary>
            public bool EnableBuiildAll
            {
                get { return enableBuiildAll; }
                set { enableBuiildAll = value;
                }
            }
            #endregion
            
            #region EnableCloseProject
            /// <summary>
            /// This property gets or sets the value for 'EnableCloseProject'.
            /// </summary>
            public bool EnableCloseProject
            {
                get { return enableCloseProject; }
                set { enableCloseProject = value; }
            }
            #endregion
            
            #region EnableEditProject
            /// <summary>
            /// This property gets or sets the value for 'EnableEditProject'.
            /// </summary>
            public bool EnableEditProject
            {
                get { return enableEditProject; }
                set { enableEditProject = value; }
            }
            #endregion
            
            #region EnableIncludeProjectFiles
            /// <summary>
            /// This property gets or sets the value for 'EnableIncludeProjectFiles'.
            /// </summary>
            public bool EnableIncludeProjectFiles
            {
                get { return enableIncludeProjectFiles; }
                set { enableIncludeProjectFiles = value; }
            }
            #endregion
            
            #region EnableNewProject
            /// <summary>
            /// This property gets or sets the value for 'EnableNewProject'.
            /// </summary>
            public bool EnableNewProject
            {
                get { return enableNewProject; }
                set { enableNewProject = value; }
            }
            #endregion
            
            #region EnableOpenProject
            /// <summary>
            /// This property gets or sets the value for 'EnableOpenProject'.
            /// </summary>
            public bool EnableOpenProject
            {
                get { return enableOpenProject; }
                set { enableOpenProject = value; }
            }
            #endregion
            
            #region EnableViewProjectSummary
            /// <summary>
            /// This property gets or sets the value for 'EnableViewProjectSummary'.
            /// </summary>
            public bool EnableViewProjectSummary
            {
                get { return enableViewProjectSummary; }
                set { enableViewProjectSummary = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
