using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpixel.API.Elements;
using Sharpixel.API.Requests;

namespace Sharpixel.API.Simplified
{
    /// <summary>
    /// Class used for simplified requests to api.
    /// </summary>
    public sealed class SimpleClient
    {
        /// <summary>
        /// API Key used for sending requests
        /// </summary>
        public string AuthKey { get; set; }

        /// <summary>
        /// Authenticate to client with key
        /// </summary>
        /// <param name="Key">API Key</param>
        public SimpleClient(string Key)
        {
            AuthKey = Key;
        }

        /// <summary>
        /// Gets player by its uuid
        /// </summary>
        /// <param name="uuid">Player's Minecraft UUID</param>
        /// <returns>Player's data in <see cref="Player"/> class</returns>
        public Player GetPlayerByUUID(string uuid)
        {
            ComplexRequest<Player> request = new ComplexRequest<Player>();
            request.KEY = AuthKey;
            request.RequestParams = new RequestParameters(AuthKey);
            request.RequestParams.Add("uuid", uuid);
            request.RequestUri = "https://api.hypixel.net/player";
            request.MakeRequest();
            ComplexResponse<Player> resp = (ComplexResponse<Player>) request.Response;
            Player pl = resp.ParsedData;
            return pl;
        }

        /// <summary>
        /// Gets player by its username
        /// </summary>
        /// <param name="name">Players username</param>
        /// <returns>Player's data in <see cref="Player"/> class</returns>
        [Obsolete("Not recommended because of rate limit on this operation")]
        public Player GetPlayerByName(string name)
        {
            ComplexRequest<Player> request = new ComplexRequest<Player>();
            request.KEY = AuthKey;
            request.RequestParams = new RequestParameters(AuthKey);
            request.RequestParams.Add("name", name);
            request.RequestUri = "https://api.hypixel.net/player";
            request.MakeRequest();
            ComplexResponse<Player> resp = (ComplexResponse<Player>)request.Response;
            Player pl = resp.ParsedData;
            return pl;
        }


    }
}
