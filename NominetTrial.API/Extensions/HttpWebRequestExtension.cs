using NominetTrial.API.HttpHelper;
using System.Net;

namespace NominetTrial.API.Extensions
{
    public static class HttpWebRequestExtension
    {
        public static ApiResponse GetApiResponse(this HttpWebRequest request)
        {
            ApiResponse apiResponse;
            try
            {
                apiResponse = new ApiResponse(request.GetResponse());
            }
            catch (WebException we)
            {
                apiResponse = new ApiResponse(we.Response, we);
            }

            return apiResponse;
        }
    }
}
