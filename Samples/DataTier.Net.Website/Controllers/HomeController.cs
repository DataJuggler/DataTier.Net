

#region using statements


using ObjectLibrary.BusinessObjects;
using DataGateway;
using DataJuggler.Core.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

#endregion

namespace DataTier.Net.Website.Controllers
{

    #region class HomeController
    /// <summary>
    /// This is the controller for the Home Page
    /// </summary>
    public class HomeController : Controller
    {
        
        #region Private Variables
        #endregion
        
        #region Methods
            
            #region About()
            /// <summary>
            /// method About
            /// </summary>
            public ActionResult About()
            {
                return View();
            }
            #endregion
            
            #region Contact()
            /// <summary>
            /// method Contact
            /// </summary>
            public ActionResult Contact()
            {  
                return View();
            }
            #endregion
            
            #region Index()
            /// <summary>
            /// method Index
            /// </summary>
            public ActionResult Index()
            {
                return View();
            }
            #endregion
            
            #region SignUp()
            /// <summary>
            /// method Sign Up
            /// </summary>
            public ActionResult SignUp(Notification notification)
            {  
                
                // if the notification.EmailAddress exists
                if ((NullHelper.Exists(notification)) && (TextHelper.Exists(notification.EmailAddress)))
                {
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway();

                    // check if exists
                    Notification existingNotification = gateway.FindNotificationByEmailAddress(notification.EmailAddress);

                    // If the existingNotification object does not exist
                    if (NullHelper.IsNull(existingNotification))
                    {
                        // perform the save
                        bool saved = gateway.SaveNotification(ref notification);

                        // if saved
                        if (saved)
                        {
                            bool isNew = notification.IsNew;
                        }
                    }
                }
                
                // to do: return signed up user.
                return View();
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
