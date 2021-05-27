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
    /// <summary>
    /// Class used for making more complex requests, and turning them into pre-made classes
    /// </summary>
    /// <typeparam name="T">Type of return class data</typeparam>
    public sealed class ComplexRequest<T> : IRequest
    {
        public string RequestUri { get; set; }
        public SortedDictionary<string, string> RequestParameters { get; set; }
        public Action<ComplexResponse<T>> OnReceiveResponse { get; set; }
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
