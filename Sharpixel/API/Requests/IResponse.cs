using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Sharpixel.API.Requests
{
    /// <summary>
    /// Interface which contains data of JSON API request.
    /// </summary>
    public interface IResponse
    {
        #nullable enable
        /// <summary>
        /// Whole original data of json request
        /// </summary>
        public JObject? Original { get; set; }
        /// <summary>
        /// Main data token of json request. For example, it will be "player" for Player data request.
        /// </summary>
        public JObject? Data { get; set; }
        #nullable disable
        /// <summary>
        /// Was the request successful?
        /// </summary>
        public bool IsSuccessful { get; set; }
        /// <summary>
        /// Raw JSON data of API request in string
        /// </summary>
        public string RawData { get; set; }
    }
}