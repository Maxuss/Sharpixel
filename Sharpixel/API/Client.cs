using System;
using Sharpixel.API.Elements;
using Sharpixel.API.Requests;

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
        /// Authenticate client with key
        /// <seealso cref="Client()"/>
        /// </summary>
        /// <param name="key">Your hypixel API key</param>
        public Client(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Authenticate client without giving key.
        /// <seealso cref="Client(string)"/>
        /// </summary>
        public Client()
        {
            Key = null;
        }

        /// <summary>
        /// Requester for simple requests
        /// </summary>
        public IRequest Request { get; set; }
    }
}