

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net.Enumerations;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

#endregion

namespace DataTierClient.Controls
{

    #region class RemoveTemplatesControl
    /// <summary>
    /// method
    /// </summary>
    public partial class RemoveTemplatesControl : UserControl, ISelectedIndexListener
    {
        
        #region Private Variables
        private TargetFrameworkEnum selectedFramework;
        public const string UninstallDotNet5ProjectTemplates = "dotnet new -uninstall DataJuggler.DataTier.Net5.ProjectTemplates";        
        public const string UninstallDotNet6ProjectTemplates = "dotnet new uninstall DataJuggler.DataTier.Net6.ProjectTemplates";
        public const string UninstallDotNet7ProjectTemplates = "dotnet new uninstall DataJuggler.DataTier.Net7.ProjectTemplates";
        public const string UninstallDotNet8ProjectTemplates = "dotnet new uninstall DataJuggler.DataTier.NET8.ProjectTemplates";        
        public const string UninstallDotNet8ProjectTemplates2 = "dotnet new uninstall DataJuggler.DataTier.NET8V2.ProjectTemplates";
        public const string UninstallDotNet9ProjectTemplates = "dotnet new uninstall DataJuggler.DataTier.Net9.ProjectTemplatesV2";
        public const string UninstallDotNet10ProjectTemplates = "dotnet new uninstall DataJuggler.DataTier.Net10.ProjectTemplatesV2";
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'RemoveTemplatesControl' object.
        /// </summary>
        public RemoveTemplatesControl()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Events
            
            #region Button_Enter(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Enter
            /// </summary>
            private void Button_Enter(object sender, EventArgs e)
            {
                // Change the cursor to a hand
                Cursor = Cursors.Hand;
            }
            #endregion
            
            #region Button_Leave(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Button _ Leave
            /// </summary>
            private void Button_Leave(object sender, EventArgs e)
            {
                // Change the cursor back to the default pointer
                Cursor = Cursors.Default;
            }
            #endregion
            
            #region CopyButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CopyButton' is clicked.
            /// </summary>
            private void CopyButton_Click(object sender, EventArgs e)
            {
                // Copy the text
                Clipboard.SetText(ManuelInstructionsLabel.Text);

                // Updte the image
                CopyButton.BackgroundImage = Properties.Resources.Check_48x48;

                // Updte the UI
                Refresh();
                Application.DoEvents();

                // Start the Timer
                CopyTimer.Start();
            }
            #endregion
            
            #region CopyTimer_Tick(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Copy Timer _ Tick
            /// </summary>
            private void CopyTimer_Tick(object sender, EventArgs e)
            {
                // Update the Icon back
                CopyButton.BackgroundImage = Properties.Resources.ClipBoard;
            }
            #endregion
            
            #region DoneButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DoneButton' is clicked.
            /// </summary>
            private void DoneButton_Click(object sender, EventArgs e)
            {
                // Close this form
                ParentForm.Close();
            }
            #endregion
            
            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            /// <summary>
            /// event is fired when a selection is made in the 'On'.
            /// </summary>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // if the selected index is set                
                if (selectedIndex >= 0)
                {
                    // Set the selected text
                    string selectedText = selectedItem.ToString();

                    // if the text exists
                    if (TextHelper.Exists(selectedText))
                    {
                        // Get the selected text
                        switch (selectedText)
                        {
                            case "NET5":

                                // Set to .NET5
                                SelectedFramework = TargetFrameworkEnum.Net5;

                                // required
                                break;

                            case "NET6":

                                // Set to .NET6
                                SelectedFramework = TargetFrameworkEnum.Net6;

                                // required
                                break;

                            case "NET7":

                                // Set to .NET7
                                SelectedFramework = TargetFrameworkEnum.Net7;

                                // required
                                break;

                            case "NET8":

                                // Set to .NET8
                                SelectedFramework = TargetFrameworkEnum.Net8;

                                // required
                                break;

                            case "NET9":

                                // Set to .NET9
                                SelectedFramework = TargetFrameworkEnum.Net9;

                                // required
                                break;

                            case "NET10":

                                // Set to .NET9
                                SelectedFramework = TargetFrameworkEnum.Net10;

                                // required
                                break;
                        }
                    }

                    // Get the argument
                    string argument = GetArgumentsBasedUponSelectedFramework();

                    // if the text exists
                    if (TextHelper.Exists(argument))
                    {
                        // Display the text
                        ManuelInstructionsLabel.Text = argument.Replace("/C ", "");
                    }
                    else
                    {
                        // Display the text
                        ManuelInstructionsLabel.Text = "";
                    }
                }

                // Enable or disable controls
                UIEnable();
            }
            #endregion
            
            #region RemoveTemplateButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'RemoveTemplateButton' is clicked.
            /// </summary>
            private void RemoveTemplateButton_Click(object sender, EventArgs e)
            {
                // locals
                bool abort = false;

                // If a framework is selected
                if (HasSelectedFramework)
                {
                    // Only if NET 8
                    if (SelectedFramework == TargetFrameworkEnum.Net8)
                    {
                        // if both are not checked
                        if ((Version1RadioButton.Checked == false) && (Version2RadioButton.Checked == false))
                        {
                            // set to true
                            abort = true;

                            // Show a message
                            StatusLabel.Text = "You must select Version 1 or Version 2";
                            StatusLabel.ForeColor = Color.Coral;
                        }                        
                    }
                    
                    // if the value for abort is false
                    if (!abort)
                    {
                        // Other wise it should be valid
                        bool removed = PerformRemove();

                        // if removed
                        if (removed)
                        {
                            // Show a message
                            StatusLabel.Text = "Your template has been removed.";
                            StatusLabel.ForeColor = Color.LemonChiffon;                            
                        }
                    }
                }
            }
            #endregion
            
            #region RemoveTemplateButton_EnabledChanged(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Remove Template Button _ Enabled Changed
            /// </summary>
            private void RemoveTemplateButton_EnabledChanged(object sender, EventArgs e)
            {
                // If Enabled
                if (RemoveTemplateButton.Enabled)
                {
                    // Use Enabled Red Image
                    RemoveTemplateButton.BackgroundImage = Properties.Resources.WoodButtonWideRed;

                    // Use White
                    RemoveTemplateButton.ForeColor = Color.White;
                }
                else
                {
                    // Use Disabled Dark Gray
                    RemoveTemplateButton.BackgroundImage = Properties.Resources.WoodButtonWideDarkGray;

                    // Use White
                    RemoveTemplateButton.ForeColor = Color.FromArgb(20, 20, 20);
                }
            }
        #endregion

            #region RemoveTemplateButton_Paint(object sender, PaintEventArgs e)
            /// <summary>
            /// event is fired when Remove Template Button _ Paint
            /// </summary>
            private void RemoveTemplateButton_Paint(object sender, PaintEventArgs e)
            {
                // cast the sender as a button
                Button button = sender as Button;

                // If the button object exists
                if (button != null)
                {
                    if (button.Enabled)
                    {
                        // Draw White Text
                        TextRenderer.DrawText(e.Graphics, button.Text, button.Font, button.ClientRectangle, Color.GhostWhite, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    else
                    {
                        // Draw DarkGray
                        TextRenderer.DrawText(e.Graphics, button.Text, button.Font, button.ClientRectangle, Color.FromArgb(20, 20, 20), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region GetArgumentsBasedUponSelectedFramework()
            /// <summary>
            /// returns the Arguments Based Upon Selected Framework
            /// </summary>
            public string GetArgumentsBasedUponSelectedFramework()
            {
                // initial value
                string argument = "";                

                // Determine the action by the SelectedFramework
                switch (SelectedFramework)
                {
                    case TargetFrameworkEnum.Net5:

                        // Set the return value
                        argument = "/C " + UninstallDotNet5ProjectTemplates;

                        // Required
                        break;

                    case TargetFrameworkEnum.Net6:

                        // Set the return value
                        argument = "/C " + UninstallDotNet6ProjectTemplates;

                        // Required
                        break;

                    case TargetFrameworkEnum.Net7:

                        // Set the return value
                        argument = "/C " + UninstallDotNet7ProjectTemplates;

                        // Required
                        break;

                    case TargetFrameworkEnum.Net8:

                        // if Version 1 Template is checked
                        if (Version1RadioButton.Checked)
                        {
                            // Set the return value
                            argument = "/C " + UninstallDotNet8ProjectTemplates;
                        }
                        else
                        {
                            // Set the return value
                            argument = "/C " + UninstallDotNet8ProjectTemplates2;
                        }

                        // Required
                        break;

                    case TargetFrameworkEnum.Net9:

                        // Set the return value
                        argument = "/C " + UninstallDotNet9ProjectTemplates;

                        // Required
                        break;

                    case TargetFrameworkEnum.Net10:

                        // Set the return value
                        argument = "/C " + UninstallDotNet10ProjectTemplates;

                        // Required
                        break;
                }
                
                // return value
                return argument;
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Load the items
                FrameworkComboBox.LoadItems(typeof(TargetFrameworkEnum));

                // Remove .NET Framework
                FrameworkComboBox.Items.RemoveAt(5);

                // Make the text upper case
                for (int i = 0; i < FrameworkComboBox.Items.Count; i++)
                {
                    // To Upper
                    FrameworkComboBox.Items[i] = FrameworkComboBox.Items[i].ToString().ToUpper();
                }

                // Start disabled
                RemoveTemplateButton.Enabled = false;
                RemoveTemplateButton.Text = "Remove Template";
                RemoveTemplateButton.ForeColor = Color.GhostWhite;

                // setup the listener
                FrameworkComboBox.SelectedIndexListener = this;

                // Enable or disable controls
                UIEnable();
            }
            #endregion

            #region PerformRemove(bool silent = false)
            /// <summary>
            /// returns the Remove
            /// </summary>
            public bool PerformRemove(bool silent = false)
            {
                // initial value
                bool removed = false;

                // get the string to remove based on the selected framework
                string arguments = GetArgumentsBasedUponSelectedFramework();

                try               
                {
                    if (TextHelper.Exists(arguments))
                    {
                        // Create a Process to launch a command window (hidden) to create the item templates
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = arguments;                        
                        process.StartInfo = startInfo;
                        process.Start();
                    
                        // set to true
                        removed = true;
                    }
                    else
                    {
                        // Show a message
                        StatusLabel.Text = "Internal Error: Could not find the uninstall command for the selected framework.";
                        StatusLabel.ForeColor = Color.Coral;
                    }
                 }
                 catch (Exception error)
                 { 
                     // Set the error
                    DebugHelper.WriteDebugError("PerformRemove", this.Name, error);

                    // if the value for silent is false
                    if (!silent)
                    {
                        // show the user a message
                        MessageBoxHelper.ShowMessage("The DataTier.Net Project Templates could not be uninstalled.", "Uninsteall Templates Failed");
                    }
                 }
                
                // return value
                return removed;
            }
            #endregion
            
            #region UIEnable()
            /// <summary>
            /// UI Enable
            /// </summary>
            public void UIEnable()
            {
                // Enable the button if a Framework is selected
                RemoveTemplateButton.Enabled = HasSelectedFramework;

                // Only show the readio buttons if version 8
                bool radioButtonsVisible = ((int) SelectedFramework == 8);

                // Only show if .NET 8
                Version1RadioButton.Visible = radioButtonsVisible;
                Version2RadioButton.Visible = radioButtonsVisible;
            }
            #endregion
            
        #endregion

        #region Properties

            #region HasSelectedFramework
            /// <summary>
            /// This property returns true if this object has a 'SelectedFramework'.
            /// </summary>
            public bool HasSelectedFramework
            {
                get
                {
                    // initial value
                    bool hasSelectedFramework = ((int) SelectedFramework > 0);
                    
                    // return value
                    return hasSelectedFramework;
                }
            }
            #endregion
            
            #region SelectedFramework
            /// <summary>
            /// This property gets or sets the value for 'SelectedFramework'.
            /// </summary>
            [Browsable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public TargetFrameworkEnum SelectedFramework
            {
                get { return selectedFramework; }
                set { selectedFramework = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}