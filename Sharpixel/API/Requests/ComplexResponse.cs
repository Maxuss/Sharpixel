using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpixel.API.Requests
{
    /// <summary>
    /// Used for <see cref="ComplexRequest{T}"/> requests
    /// </summary>
    /// <typeparam name="T">Type of pre-made class</typeparam>
    public sealed class ComplexResponse<T> : IResponse
    {
        public JObject Original { get; set; }
        public JObject Data { get; set; }
        public bool IsSuccessful { get; set; }
        /// <summary>
        /// Represents JSON data parsed into specified <see cref="T"/> Type
        /// </summary>
        public T ParsedData { get; set; }
        public string RawData { get; set; }

        public ComplexResponse(JObject data, string raw)
        {
            Original = data;
            RawData = raw;
            IsSuccessful = (bool)data["success"];
            ParsedData = ParseObject();
        }

        private T ParseObject()
        {
            return JsonConvert.DeserializeObject<T>(RawData);
        }
    }
}
