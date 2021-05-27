using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpixel.API.Requests
{
    public sealed class RequestParameters : SortedDictionary<string, string>
    {
        public string AuthKey;
        public string GenerateURL(string destination)
        {
            string url;
            url = $"{destination}?{this.FirstOrDefault().Key}={this[this.FirstOrDefault().Key]}";
            Remove(this.FirstOrDefault().Key);
            foreach (string req in Keys)
            {
                url += $"&{req}={this[req]}";
            }
            url += $"&key={AuthKey}";
            return url;
        }

        public RequestParameters(string key, SortedDictionary<string, string> data)
        {
            AuthKey = key;
            foreach(string k in data.Keys)
            {
                Add(k, data[k]);
            }
        }

        public RequestParameters(string key)
        {
            AuthKey = key;
        }

        public RequestParameters(SortedDictionary<string, string> @params)
        {
            foreach (string k in @params.Keys)
            {
                Add(k, @params[k]);
            }
        }
    }
}
