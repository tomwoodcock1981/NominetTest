using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NominetTrial.API.HttpHelper;
using System;
using System.IO;
using System.Net;

namespace NominetTrial.API.Extensions
{
    public static class HttpWebResponseExtension
    {
        public static string ToStringData(this WebResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            using (Stream responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                {
                    throw new InvalidOperationException("Response stream is null");
                }

                if (!responseStream.CanRead)
                {
                    throw new InvalidOperationException("Cannot read from the response stream, it may have already been read from");
                }

                StreamReader reader = new StreamReader(responseStream);

                string responseData = reader.ReadToEnd();

                return responseData;
            }
        }

        public static JObject DeserialiseResponse(this ApiResponse apiResponse)
        {
            return (JObject)JsonConvert.DeserializeObject(apiResponse.JsonResponse.ToString());
        }
    }
}
