

#region using statements

using System.Text;

#endregion

namespace DataJuggler.Net.Cryptography.Objects
{

    #region class PasswordHashInfo
    /// <summary>
    /// This class is used to return an object with
    /// the PasswordHash and the Salt byte array
    /// in one object.
    /// </summary>
    public class PasswordHashInfo
    {

        #region Private Variables
        private byte[] passwordHash;
        private byte[] salt;
        private const string Seperator = "||||";
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a PasswordhashInfo
        /// </summary>
        /// <param name="passwordHash"></param>
        /// <param name="salt"></param>
        public PasswordHashInfo(byte[] passwordHash, byte[] salt)
        {
            // store the args
            this.PasswordHash = passwordHash;
            this.Salt = salt;
        }
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// This method return information about this PasswordHash in the form of a string
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // initial value
                string toString = "";

                // verify both byte arrays have data
                if ((PasswordHash.Length > 0) && (Salt.Length > 0))
                {
                    // separating to make it easier to debug
                    string part1 = Encoding.Unicode.GetString(PasswordHash);

                    // built a salty string
                    string salty =  System.Text.Encoding.Unicode.GetString(Salt);

                    // set the return value
                    toString = part1 + Seperator + salty;
                }

                // return value
                return toString;
            }
            #endregion

        #endregion

        #region Properties

        #region PasswordHash
        /// <summary>
        /// This property gets or sets the value for 'PasswordHash'.
        /// </summary>
        public byte[] PasswordHash
            {
                get { return passwordHash; }
                set { passwordHash = value; }
            }
            #endregion
            
            #region Salt
            /// <summary>
            /// This property gets or sets the value for 'Salt'.
            /// </summary>
            public byte[] Salt
            {
                get { return salt; }
                set { salt = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
