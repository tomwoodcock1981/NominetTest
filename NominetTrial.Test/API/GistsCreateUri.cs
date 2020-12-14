namespace NominetTrial.Test.API
{
    public class GistsCreateUri
    {
        private string _uri;
        public GistsCreateUri(string baseUri)
        {
            _uri = baseUri;
        }

        public GistsCreateUri(string baseUri, string path)
        {
            _uri = baseUri + path;
        }
    }
}
