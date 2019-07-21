

#region using statements

using DataTierClient.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;

#endregion

namespace DataTierClient.Controls
{

    #region class SetupControl
    /// <summary>
    /// This control is designed to make it easy for people to get started with DataTier.Net.
    /// There are now 3 steps that should take 5 minutes or less.
    /// </summary>
    public partial class SetupControl : UserControl, ICheckChangedListener
    {
        
        #region Private Variables
        private bool userCancelled;
        private const string DatabaseName = "DataTier.Net.Database";
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SetupControl' object.
        /// </summary>
        public SetupControl()
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

                // hide all 3 info labels
                InfoLabel1.Visible = false;
                InfoLabel2.Visible = false;
                InfoLabel3.Visible = false;
            }
            #endregion
            
            #region CancelButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CancelButton' is clicked.
            /// </summary>
            private void CancelButton_Click(object sender, EventArgs e)
            {
                // close this app
                userCancelled = true;

                // If the ParentForm object exists
                if (ParentForm != null)
                {
                    // close the parent form
                    ParentForm.Close();
                }
            }
            #endregion
            
            #region ConfigureButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'ConfigureButton' is clicked.
            /// </summary>
            private void ConfigureButton_Click(object sender, EventArgs e)
            {
                // Create a new instance of a 'ConnectionStringBuilderForm' object.
                ConnectionStringBuilderForm form = new ConnectionStringBuilderForm(DatabaseName);

                // Show the form
                form.ShowDialog();

                // if the user did not cancel
                if (!form.UserCancelled)
                {
                    // Setup is complete
                    this.UserCancelled = false;

                    // Close the Parentform
                    this.ParentForm.Close();
                }
            }
            #endregion
            
            #region ConfigureButton_MouseHover(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Configure Button _ Mouse Hover
            /// </summary>
            private void ConfigureButton_MouseHover(object sender, EventArgs e)
            {
                 // Show InfoLabel3 while hovering
                InfoLabel3.Visible = true;
            }
            #endregion
            
            #region InstallDatabaseSchemaButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InstallDatabaseSchemaButton' is clicked.
            /// </summary>
            private void InstallDatabaseSchemaButton_Click(object sender, EventArgs e)
            {
                // get the path to the sql
                string path = "../../../Database/SQL Scripts/DataTier.Net.Database.Schema.sql";

                // if the path exists
                if (File.Exists(path))
                {
                    try
                    {
                        // get the fullPath
                        string fullPath = Path.GetFullPath(path);

                        // launch SQL Server Management Studio if installed
                        System.Diagnostics.Process.Start(fullPath);
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("InstallDatabaseSchemaButton_Click", this.Name, error);  
                    }
                }
            }
            #endregion
            
            #region InstallDatabaseSchemaButton_MouseHover(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Install Database Schema Button _ Mouse Hover
            /// </summary>
            private void InstallDatabaseSchemaButton_MouseHover(object sender, EventArgs e)
            {
                // set to visible
                InfoLabel1.Visible = true;
            }
            #endregion
            
            #region InstallProjectTemplatesButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'InstallProjectTemplatesButton' is clicked.
            /// </summary>
            private void InstallProjectTemplatesButton_Click(object sender, EventArgs e)
            {
                // set the path to the vsix install
                string vsixPath = "../../../../VSIX/DataTierNet.ProjectTemplates.Installer.vsix";

                // if the vsixPath exists
                if (File.Exists(vsixPath))
                {
                    try
                    {
                        // get the fullPath (relative paths will not launch the file)
                        string fullPath = Path.GetFullPath(vsixPath);

                        // launch the VSIX installer to install the DataTier.Net Project Templates into Visual Studio
                        System.Diagnostics.Process.Start(fullPath);
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("InstallProjectTemplatesButton_Click", this.Name, error);  
                    }
                }
            }
            #endregion
            
            #region InstallProjectTemplatesButton_MouseHover(object sender, EventArgs e)
            /// <summary>
            /// event is fired when Install Project Templates Button _ Mouse Hover
            /// </summary>
            private void InstallProjectTemplatesButton_MouseHover(object sender, EventArgs e)
            {
                // Show InfoLabel2 while hovering
                InfoLabel2.Visible = true;
            }
            #endregion
            
            #region OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            /// <summary>
            /// event is fired when On Check Changed
            /// </summary>
            public void OnCheckChanged(LabelCheckBoxControl sender, bool isChecked)
            {
                // Show or hide the InfoLabel and InfoLabel1 basedup isChecked value.
                InfoLabel.Visible = !isChecked;
                InfoLabel1.Visible = isChecked;

                // there is only one label check box control so this has to be the DatabaseCreatedCheckBox
                
                // if isChecked is true
                if (isChecked)
                {
                    // Enable the button
                    InstallDatabaseSchemaButton.Enabled = true;
                    InstallDatabaseSchemaButton.ForeColor = Color.GhostWhite;
                }
                else
                {
                    // Disable the button
                    InstallDatabaseSchemaButton.Enabled = false;
                    InstallDatabaseSchemaButton.ForeColor = Color.DarkGray;
                }
            }
        #endregion

        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Setup the listener
                DatabaseCreatedCheckBox.CheckChangedListener = this;
            }
        #endregion

        #endregion

        #region Properties

            #region UserCancelled
            /// <summary>
            /// This property gets or sets the value for 'UserCancelled'.
            /// </summary>
            public bool UserCancelled
            {
                get { return userCancelled; }
                set { userCancelled = value; }
            }
        #endregion

        #endregion

    }
    #endregion

}
