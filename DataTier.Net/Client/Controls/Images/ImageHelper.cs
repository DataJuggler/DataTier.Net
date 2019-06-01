
#region using statements

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Resources;
using DataTierClient.Enumerations;
using System.Windows.Forms;

#endregion

namespace DataTierClient.Controls.Images
{

    #region ImageHelper
    /// <summary>
    /// This objects returns objects from the 
    /// resource object 'ImagesResource'.
    /// </summary>
    public static class ImageHelper
    {
    
        #region Methods

            #region LoadImage(ButtonImagesEnum imageValue)
            /// <summary>
            /// This method loads the images for the GlossyDisabled,
            /// GlossyEnabled, VistaDisabled and VistaEnabled buttons.
            /// </summary>
            internal static Image LoadImage(ButtonImagesEnum imageValue)
            {
                // initial value
                Image image = null;

                // Create instance of resource manager
                ResourceManager resources = new System.Resources.ResourceManager(typeof(Images));

                // determine imageValue
                switch (imageValue)
                {   

                    case ButtonImagesEnum.DeepBlue:

                        // if this image exists in resource file
                        if (resources.GetObject("DeepBlue") as Bitmap != null)
                        {
                            // set image to VistaDisabled
                            image = (Bitmap)resources.GetObject("DeepBlue");
                        }

                        // required 
                        break;

                    case ButtonImagesEnum.DeepGray:

                        // if this image exists in resource file
                        if (resources.GetObject("DeepGray") as Bitmap != null)
                        {
                            // set image to VistaSelected
                            image = (Bitmap)resources.GetObject("DeepGray");
                        }

                        // required 
                        break;
                }

                // return value
                return image;
            }
            #endregion

            #region SetSelectedAndNotSelectedImages(Control.ControlCollection controls, Image selectedImage, Image notSelectedImage)
            /// <summary>
            /// This method sets the Selected and NotSelected images for all 
            /// TabButton controls on a control. This makes the control load
            /// faster than changing images at run time.
            /// </summary>
            /// <param name="controls"></param>
            /// <param name="selectedImage"></param>
            /// <param name="notSelectedImage"></param>
            public static void SetSelectedAndNotSelectedImages(Control.ControlCollection controls, Image selectedImage, Image notSelectedImage)
            {
                // local
                TabButton tabButton = null;

                try
                {
                    // if the controls exist
                    if (controls != null)
                    {
                        // iterate controls
                        foreach (Control control in controls)
                        {
                            // cast the control as a tab button
                            tabButton = control as TabButton;

                            // if the tabButton exists
                            if (tabButton != null)
                            {
                                // set the images on the control
                                tabButton.SetImages(selectedImage, notSelectedImage);
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();
                }
            } 
            #endregion
        
        #endregion
        
    }
    #endregion
    
}

