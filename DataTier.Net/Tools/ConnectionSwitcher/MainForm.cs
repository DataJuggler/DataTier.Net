
using ConnectionSwitcher.Enumerations;
using DataJuggler.UltimateHelper;
using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;

#region using statements


#endregion

namespace ConnectionSwitcher
{

    #region class MainForm
    /// <summary>
    /// This class is the MainForm for this app
    /// </summary>
    public partial class MainForm : Form, ISelectedIndexListener
    {
        
        #region Private Variables
        private const string EnvironmentVariableName = "DataTierNetConnection";
        private const string DataTierDotNetDotDatabase = "Data Source=Rocket\\SQLExpress;Initial Catalog=DataTier.Net.Database;Integrated Security=True;Encrypt=False;";
        private const string DataTierDotNetDotDatabaseDotDev = "Data Source=Rocket\\SQLExpress;Initial Catalog=DataTier.Net.Database.Dev;Integrated Security=True;Encrypt=False;";
        private const string DataTierDotNetDotDatabaseDotDemo = "Data Source=Rocket\\SQLExpress;Initial Catalog=DataTier.Net.Database.Demo;Integrated Security=True;Encrypt=False;";
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            /// <summary>
            /// event is fired when a selection is made in the 'On'.
            /// </summary>
            public void OnSelectedIndexChanged(LabelComboBoxControl control, int selectedIndex, object selectedItem)
            {
                // Determine the Connection value by the selectedIndex
                if (selectedIndex == 0)
                {
                    // Display the ConnectionString
                    ConnectionStringControl.Text = DataTierDotNetDotDatabase;
                }
                else if (selectedIndex == 1)
                {
                    // Display the ConnectionString
                    ConnectionStringControl.Text = DataTierDotNetDotDatabaseDotDemo;
                }
                else if (selectedIndex == 2)
                {
                    // Display the ConnectionString
                    ConnectionStringControl.Text = DataTierDotNetDotDatabaseDotDev;
                }
            }
            #endregion
            
            #region UpdateValueButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'UpdateValueButton' is clicked.
            /// </summary>
            private void UpdateValueButton_Click(object sender, EventArgs e)
            {
                // Set the vale
                EnvironmentVariableHelper.SetEnvironmentVariableValue(EnvironmentVariableName, ConnectionStringControl.Text, EnvironmentVariableTarget.User);

                // Display the result
                StatusLabel.Text = "The Environment Variable Has Been Updated";
            }
            #endregion
            
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                 // Load the ComboBox
                ConnectionTypeComboBox.LoadItems(typeof(ConnectionTypeEnum));

                // Get the current value
                string currentValue = EnvironmentVariableHelper.GetEnvironmentVariableValue(EnvironmentVariableName, EnvironmentVariableTarget.User);

                // If the currentValue string exists
                if (TextHelper.Exists(currentValue))
                {
                    // Get the currentValue
                    switch (currentValue)
                    {
                        case DataTierDotNetDotDatabase:

                            // Select this item
                            ConnectionTypeComboBox.SelectedIndex = 0;

                            // required
                            break;

                        case DataTierDotNetDotDatabaseDotDemo:

                            // Select this item
                            ConnectionTypeComboBox.SelectedIndex = 1;

                            // required
                            break;

                        case DataTierDotNetDotDatabaseDotDev:

                            // Select this item
                            ConnectionTypeComboBox.SelectedIndex = 2;

                            // required
                            break;
                    }
                }

                // Display the value
                ConnectionStringControl.Text = currentValue;

                // Setup the Listener
                ConnectionTypeComboBox.SelectedIndexListener = this;
            }
        #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
