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
        /// Response of request.
        /// </summary>
        public IResponse Response { get; set; }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="URI">String representing URL of request</param>
        public abstract void Create(string URI);

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="URI">String representing URL of request</param>
        /// <param name="params">Parameters of request</param>
        public abstract void Create(string URI, SortedDictionary<string, string> @params);

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="URI">String representing URL of request</param>
        /// <param name="params">Parameters of request</param>
        /// <param name="OnResponse">Action, which will be executed on finishing request</param>
        public abstract void Create(string URI, SortedDictionary<string, string> @params, Action<IResponse> OnResponse);
        /// <summary>
        /// Sends request to API and return Response
        /// </summary>
        public abstract void MakeRequest();
    }
}