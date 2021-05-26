using System;

namespace Sharpixel.API
{
    /// <summary>
    /// Main class used for requesting data to API
    /// </summary>
    public sealed class Client
    {
        /// <summary>
        /// Authentication key for API
        /// </summary>
        public string Key
        {
            get;
            set;
        }
        
        /// <summary>
        /// Authenticate client
        /// </summary>
        /// <param name="key">Your hypixel API key</param>
        public Client(string key)
        {
            Key = key;
        }
    }
}