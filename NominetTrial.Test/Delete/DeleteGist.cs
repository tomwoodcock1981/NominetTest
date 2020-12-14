using NominetTrial.API.Extensions;
using NominetTrial.API.HttpHelper;
using NominetTrial.Test.API;
using NUnit.Framework;

namespace NominetTrial.Test.Delete
{
    [TestFixture]
    public class DeleteGist
    {
        private CreateGist _createGist;
        private ApiResponse _apiResponse;
        private string _gistId;
        private HttpWebRequestBuilder _httpWebRequestBuilder;

        public DeleteGist()
        {
            _createGist = new CreateGist();
            _apiResponse = _createGist.BuildRequest("This is a new test gist", "myFile.txt", true);
            _gistId = _apiResponse.JsonResponse["id"].ToString();
            _httpWebRequestBuilder = new HttpWebRequestBuilder("/" + _gistId);
        }
        
        [Test]
        public void DeletingAnExistingGist_Returns204ResponseCode()
        {
            _apiResponse = _httpWebRequestBuilder
                .WithAuthorisationHeaders()
                .AsDelete()
                .Build()
                .GetApiResponse();

            Assert.AreEqual(204, (int)_apiResponse.HttpWebResponse.StatusCode);
        }
    }
}
