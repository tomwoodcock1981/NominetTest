using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NominetTrial.API.Extensions;
using NominetTrial.API.HttpHelper;

namespace NominetTrial.Test.API
{
    public class CreateGist
    {
        private HttpWebRequestBuilder _httpWebRequestBuilder;
        private GistCreateModel _gistCreateModel;
        private MyFileTxt _myFilesTxt;
        private Files _files;
        private ApiResponse _apiResponse;


        public ApiResponse BuildRequest(string content, string description, bool @public)
        {
            _httpWebRequestBuilder = new HttpWebRequestBuilder();
            _gistCreateModel = new GistCreateModel();
            _myFilesTxt = new MyFileTxt();
            _files = new Files();

            _myFilesTxt.Content = content;
            _files.myFileTxt = _myFilesTxt;
            _gistCreateModel.Description = description;
            _gistCreateModel.Public = @public;
            _gistCreateModel.Files = _files;
            _gistCreateModel.Files.myFileTxt = _myFilesTxt;

            _apiResponse = _httpWebRequestBuilder
                .WithAuthorisationHeaders()
                .AsPost()
                .WithJsonBody(JsonConvert.SerializeObject(_gistCreateModel))
                .Build()
                .GetApiResponse();

            return _apiResponse;
        }
    }
}
