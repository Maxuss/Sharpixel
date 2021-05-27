using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Sharpixel.API.Requests
{
    /// <summary>
    /// Class which contains data of JSON API request. This class is <b>abstract!</b>
    /// </summary>
    public abstract class Response
    {
        #nullable enable
        /// <summary>
        /// Whole original data of json request
        /// </summary>
        public JObject? Original;
        /// <summary>
        /// Main data token of json request. For example, it will be "player" for Player data request.
        /// </summary>
        public JObject? Data;
        #nullable disable
        /// <summary>
        /// Was the request successful?
        /// </summary>
        public bool IsSuccessful;
    }
}