using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sharpixel.API.Requests
{
    public sealed class SpecializedRequest<T> : IRequest
    {
        public string KEY { get; set; }
        public string RequestUri { get; set; }
        public IResponse Response { get; set; } // ComplexResponse<T>
        public Action<ComplexResponse<T>> OnReceiveResponse { get; set; }
        public RequestParameters RequestParams { get; set; }

        public void Create(string URI)
        {
            RequestUri = URI;
        }

        public void Create(string URI, SortedDictionary<string, string> @params)
        {
            RequestUri = URI;
            RequestParams = new RequestParameters(KEY, @params);
        }

        public void Create(string URI, SortedDictionary<string, string> @params, Action<IResponse> OnResponse)
        {
            RequestUri = URI;
            RequestParams = new RequestParameters(@params);
            OnReceiveResponse += OnResponse;
        }

        /// <summary>
        /// Creates request based on <see cref="SpecializedDestination"/> enum.
        /// </summary>
        /// <param name="dest">Destination parameter</param>
        /// <param name="param">Parameters of request. e.g. uuid of player</param>
        public void Create(SpecializedDestination dest, string param)
        {
            switch(dest)
            {
                case SpecializedDestination.Player:
                    RequestUri = $"https://api.hypixel.net/player?key="+KEY+$"&uuid={param}";
                    break;
            }
        }

        public void MakeRequest()
        {
            try
            {
                string url = RequestParams.GenerateURL(RequestUri);

                var request = WebRequest.Create(url);
                request.Method = "GET";
                using WebResponse webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();
                using var reader = new StreamReader(webStream);
                string data = reader.ReadToEnd();
                JObject d = JsonConvert.DeserializeObject<JObject>(data);
                ComplexResponse<T> r = new ComplexResponse<T>(d, data);
                r.IsSuccessful = (bool)d["success"];
                r.Original = d;
                OnReceiveResponse(r);
                Response = r;
            }
            catch (Exception e)
            {
                throw new IOException("An exception occurred while making request to API. See inner exception for details.", e);
            }
        }
    }
}
