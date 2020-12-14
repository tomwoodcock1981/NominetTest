using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NominetTrial.API.Extensions;
using NominetTrial.API.HttpHelper;
using NominetTrial.Test.API;
using NUnit.Framework;

namespace NominetTrial.Test.Update
{
    [TestFixture]
    public class UpdateGist
    {
        private ApiResponse _apiResponse;
        private string _gistId;
        private HttpWebRequestBuilder _httpWebRequestBuilder;
        private CreateGists _createGists;
        private GistsCreateModel _gistsCreateModel;
        private MyFile1Txt _myFile1Txt;
        private MyFile2Txt _myFile2Txt;
        private NewFiles _newFiles;

        public UpdateGist()
        {
            _createGists = new CreateGists();
            _httpWebRequestBuilder = new HttpWebRequestBuilder();
            _gistsCreateModel = new GistsCreateModel();
            _myFile1Txt = new MyFile1Txt();
            _myFile2Txt = new MyFile2Txt();
            _newFiles = new NewFiles();

            ApiResponse response = _createGists.BuildRequest("This file will be updated", "This file will be deleted", "Testing Gist Update API", true);
            _gistId = response.JsonResponse["id"].ToString();
            _httpWebRequestBuilder = new HttpWebRequestBuilder("/" + _gistId);
        }

        [Test]
        public void WhenIUpdateAnExistingGist_TheGistDataIsUpdatedCorrectly()
        {
            _gistsCreateModel = new GistsCreateModel();
            _myFile1Txt = new MyFile1Txt();
            _myFile2Txt = new MyFile2Txt();
            _newFiles = new NewFiles();

            _myFile1Txt.content = "Text successfully updated";
            _newFiles.MyFile1Txt = _myFile1Txt;
            _newFiles.MyFile2Txt = null;
            _gistsCreateModel.description = "Testing Gist Update API";
            _gistsCreateModel.@public = true;
            _gistsCreateModel.files = _newFiles;

            ApiResponse response = _httpWebRequestBuilder
                .AsPatch()
                .WithAuthorisationHeaders()
                .WithJsonBody(JsonConvert.SerializeObject(_gistsCreateModel))
                .Build()
                .GetApiResponse();

            JObject jsonResponse = response.DeserialiseResponse();

            Assert.AreEqual("Text successfully updated", jsonResponse["files"]["myFile1.txt"]["content"].ToString());
            Assert.IsNull(jsonResponse["files"]["myFile2.txt"]);
            Assert.AreEqual(200, (int)response.StatusCode);
        }
    }
}
