using Newtonsoft.Json;
using NominetTrial.API.Extensions;
using NominetTrial.API.HttpHelper;

namespace NominetTrial.Test.API
{
    public class CreateGists
    {
        private HttpWebRequestBuilder _httpWebRequestBuilder;
        public GistsCreateModel _gistsCreateModel;
        private MyFile1Txt _myFile1Txt;
        private MyFile2Txt _myFile2Txt;
        private NewFiles _newFiles;
        private ApiResponse _apiResponse;


        public ApiResponse BuildRequest(string file1txt, string file2xt, string description, bool @public)
        {
            _httpWebRequestBuilder = new HttpWebRequestBuilder();
            _gistsCreateModel = new GistsCreateModel();
            _myFile1Txt = new MyFile1Txt();
            _myFile2Txt = new MyFile2Txt();
            _newFiles = new NewFiles();
            
            _myFile1Txt.content = file1txt;
            _myFile2Txt.content = file2xt;
            _newFiles.MyFile1Txt = _myFile1Txt;
            _newFiles.MyFile2Txt = _myFile2Txt;
            _gistsCreateModel.description = description;
            _gistsCreateModel.@public = @public;
            _gistsCreateModel.files = _newFiles;

            _apiResponse = _httpWebRequestBuilder
                .WithAuthorisationHeaders()
                .AsPost()
                .WithJsonBody(JsonConvert.SerializeObject(_gistsCreateModel))
                .Build()
                .GetApiResponse();

            return _apiResponse;
        }
    }
}
