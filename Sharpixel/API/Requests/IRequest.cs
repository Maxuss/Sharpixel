using System;
using System.Collections.Generic;

namespace Sharpixel.API.Requests
{
    /// <summary>
    /// Interface used for all other requests to get data from Hypixel API
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// URI of request
        /// </summary>
        public string RequestUri { get; set; }

        /// <summary>
        /// Parameters of request.
        /// </summary>
        public SortedDictionary<string, string> RequestParameters { get; set; }

        /// <summary>
        /// Encapsulated void as <see cref="Action"/>, executed on receiving response.
        /// Takes <see cref="Response"/> abstract class as type param.
        /// </summary>
        public Action<Response> OnReceiveResponse { get; set; }

        /// <summary>
        /// Creates the request.
        /// </summary>
        public abstract void Create();
    }
}