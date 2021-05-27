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
    public sealed class JSONRequest : IRequest
    {
        public string RequestUri { get; set; }
        public SortedDictionary<string, string> RequestParameters { get; set; }
        /// <summary>
        /// Encapsulated void as <see cref="Action"/>, executed on receiving response.
        /// Takes <see cref="JSONResponse"/> class as type param.
        /// </summary>
        public Action<JSONResponse> OnReceiveResponse { get; set; }
        public IResponse Response { get; set; }

        public void Create(string URI)
        {
            RequestUri = URI;
        }

        public void Create(string URI, SortedDictionary<string, string> @params)
        {
            RequestUri = URI;
            RequestParameters = @params;
        }

        public void Create(string URI, SortedDictionary<string, string> @params, Action<IResponse> OnResponse)
        {
            RequestUri = URI;
            RequestParameters = @params;
            OnReceiveResponse += OnResponse;
        }
        /// <summary>
        /// Creates a request to API with defined parameters. All the data will be stored in <see cref="Response"/>
        /// </summary>
        /// <exception cref="IOException" />
        public void MakeRequest()
        {
            try
            {
                string url;
                if (RequestParameters != null)
                {
                    url = $"{RequestUri}?{RequestParameters.FirstOrDefault().Key}={RequestParameters[RequestParameters.FirstOrDefault().Key]}";
                    RequestParameters.Remove(RequestParameters.FirstOrDefault().Key);
                    foreach (string req in RequestParameters.Keys)
                    {
                        url += $"&{req}={RequestParameters[req]}";
                    }
                }
                else url = RequestUri;

                var request = WebRequest.Create(url);
                request.Method = "GET";
                using WebResponse webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();
                using var reader = new StreamReader(webStream);
                string data = reader.ReadToEnd();
                JObject d = JsonConvert.DeserializeObject<JObject>(data);
                JSONResponse r = new JSONResponse(data);
                r.IsSuccessful = (bool)d["success"];
                r.Original = d;
                OnReceiveResponse(r);
                Response = r;
            }
            catch(Exception e)
            {
                throw new IOException("An exception occurred while making request to API. See inner exception for details.", e);
            }
        }
    }
}
