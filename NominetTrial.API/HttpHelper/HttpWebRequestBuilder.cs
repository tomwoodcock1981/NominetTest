using System;
using System.IO;
using System.Net;
using System.Text;

namespace NominetTrial.API.HttpHelper
{
    public class HttpWebRequestBuilder
    { 
        private readonly HttpWebRequest _request;
        private readonly string uriBase = "https://api.github.com/gists";

        public HttpWebRequestBuilder()
        {
            _request = WebRequest.CreateHttp(uriBase);
            _request.Accept = "*/*";
            _request.ContentType = "application/json";
            _request.ServicePoint.Expect100Continue = false;
            _request.Method = "GET";
        }

        public HttpWebRequestBuilder(string uriPath)
        {
            _request = WebRequest.CreateHttp(uriBase + uriPath);
            _request.Accept = "*/*";
            _request.ContentType = "application/json";
            _request.ServicePoint.Expect100Continue = false;
            _request.AllowAutoRedirect = false;
            _request.Method = "GET";
        }

        public HttpWebRequestBuilder WithAuthorisationHeaders()
        {
            _request.Headers["Authorization"] = "Token " + "e4de2c715ef126141e56e62663132bb90811f43d";
            _request.UserAgent = "tomwoodcock";
            return this;
        }

        public HttpWebRequestBuilder AsPut()
        {
            _request.Method = "PUT";
            return this;
        }

        public HttpWebRequestBuilder AsPost()
        {
            _request.Method = "POST";
            return this;
        }

        public HttpWebRequestBuilder AsPatch()
        {
            _request.Method = "PATCH";
            return this;
        }

        public HttpWebRequestBuilder AsDelete()
        {
            _request.Method = "DELETE";
            return this;
        }

        public HttpWebRequestBuilder WithJsonBody(string json)
        {
            if (_request.Method == "GET")
            {
                throw new Exception("Cannot add a body to a request with a GET verb");
            }

            byte[] bytes = Encoding.UTF8.GetBytes(json);
            _request.ContentLength = bytes.Length;

            using (Stream writer = _request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
                writer.Flush();
            }

            return this;
        }

        public HttpWebRequest Build()
        {
            return _request;
        }
    }
}
