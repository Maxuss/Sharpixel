using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpixel.API.Requests
{
    /// <summary>
    /// Class used for getting response from standard JSON API Requesst
    /// </summary>
    public sealed class JSONResponse : IResponse
    {
        public JObject Original { get; set; }
        public JObject Data { get; set; }
        public bool IsSuccessful { get; set; }
        public string RawData { get; set; }

        public JSONResponse(string Raw)
        {
            RawData = Raw;
        }
    }
}
