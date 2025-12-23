

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class DelayHelper
    /// <summary>
    /// This class is used to wait for a given number of seconds before returning. 
    /// Used by the CLI's calls to wait in between calls. 
    /// </summary>
    internal class DelayHelper
    {
        
        #region Methods
            
            #region Delay(double seconds)
            /// <summary>
            /// Delay
            /// </summary>
            public static void Delay(double seconds)
            {
                // Set the startTime
                DateTime startTime = DateTime.Now;
                TimeSpan elapsedTime = new TimeSpan();

                do
                {
                    // Get the currentTime
                    DateTime now = DateTime.Now;

                    // get the time passed
                    elapsedTime = now - startTime;

                } while (elapsedTime.TotalSeconds < seconds);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
