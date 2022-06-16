using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Mango.Web.StaticDetails;

namespace Mango.Web.Models
{
    // This will hold the API Requests that we will be sending to services (i.e. ProductAPI)
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        // For Authentication
        public string AccessToken { get; set; }

    }
}
