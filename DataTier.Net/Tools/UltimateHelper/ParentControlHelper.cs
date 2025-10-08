

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class ParentObjectHelper
    /// <summary>
    /// This class is used to find the parent control for a source control.
    /// </summary>
    public class ParentControlHelper
    {
        
        #region Methods

            #region UserControl GetParentUserControl(UserControl sourceControl, string controlId, int maxAttempts = 0)
            /// <summary>controlId
            /// This method returns the Parent UserControl that matches the controlId given.
            /// This method is for Web User Controls only.
            /// </summary>
            public static UserControl GetParentUserControl(UserControl sourceControl, string controlId, int maxAttempts = 0)
            {
                // initial value
                UserControl parentControl = null;

                // locals
                int attempts = 0;
                Control tempParentControl = sourceControl.Parent;

                try
                {
                    // if the tempParentControl exists
                    if (tempParentControl != null)
                    {
                        do
                        {
                            // increment attempts
                            attempts++;

                            // if the parentControl exists
                            tempParentControl = (Control) tempParentControl.Parent;

                            // if the tempParentControl exists
                            if (tempParentControl != null)
                            {
                                // if this is the Type being searched for
                                if (tempParentControl.ID == controlId)
                                {
                                    // set the return value
                                    parentControl = tempParentControl as UserControl;

                                    // break out of the loop
                                    break;
                                }
                                else
                                {
                                    // if the max attempt has been reached and maxAttempts is greater than 0
                                    if ((maxAttempts > 0) && (attempts >= maxAttempts))
                                    {
                                        // break out of loop
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // break out of loop
                                break;
                            }

                        } while (true);
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return parentControl;
            }
            #endregion

            #region UserControl GetParentUserControl(UserControl sourceControl, Type parentType, int maxAttempts = 0)
            /// <summary>
            /// This method returns the Parent UserControl that matches the parentType given.
            /// This method is for Web User Controls only.
            /// </summary>
            public static UserControl GetParentUserControl(UserControl sourceControl, Type parentType, int maxAttempts = 0)
            {
                // initial value
                UserControl parentControl = null;

                // locals
                int attempts = 0;
                Control tempParentControl = sourceControl.Parent;

                try
                {
                    // if the tempParentControl exists
                    if (tempParentControl != null)
                    {
                        do
                        {
                            // increment attempts
                            attempts++;

                            // if the parentControl exists
                            tempParentControl = (Control)tempParentControl.Parent;

                            // if the tempParentControl exists
                            if (tempParentControl != null)
                            {
                                // if this is the Type being searched for
                                if (tempParentControl.GetType() == parentType)
                                {
                                    // set the return value
                                    parentControl = tempParentControl as UserControl;

                                    // break out of the loop
                                    break;
                                }
                                else
                                {
                                    // if the max attempt has been reached and maxAttempts is greater than 0
                                    if ((maxAttempts > 0) && (attempts >= maxAttempts))
                                    {
                                        // break out of loop
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // break out of loop
                                break;
                            }

                        } while (true);
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }

                // return value
                return parentControl;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
