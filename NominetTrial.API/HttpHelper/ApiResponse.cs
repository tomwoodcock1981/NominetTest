using Newtonsoft.Json.Linq;
using NominetTrial.API.Extensions;
using System.Net;

namespace NominetTrial.API.HttpHelper
{
    public class ApiResponse
    {
        public ApiResponse(WebResponse response)
        {
            Response = response;
            ResponseData = HttpWebResponse.ToStringData();
        }

        public ApiResponse(WebResponse response, WebException exception)
            : this(response)
        {
            WebException = exception;
        }

        public string ResponseData { get; }

        public JObject JsonResponse => JObject.Parse(ResponseData);

        public JArray JsonArrayResponse => JArray.Parse(ResponseData);

        public HttpStatusCode StatusCode => HttpWebResponse.StatusCode;

        public WebResponse Response { get; }

        public WebException WebException { get; set; }

        public HttpWebResponse HttpWebResponse => (HttpWebResponse)Response;
    }
}
