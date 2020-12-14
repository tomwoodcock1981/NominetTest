using NominetTrial.API.Extensions;
using NominetTrial.API.HttpHelper;
using NominetTrial.Test.API;
using NUnit.Framework;

namespace NominetTrial.Test.Retrieve
{
    [TestFixture]
    public class RetrieveGists
    {
        private CreateGist _createGist;
        private HttpWebRequestBuilder _httpWebRequestBuilder;
        private ApiResponse _apiResponse;
        private string _gistId;

        public RetrieveGists()
        {
            _createGist = new CreateGist();
            _apiResponse = _createGist.BuildRequest("This is a new test gist", "myFile.txt", true);
            _gistId = _apiResponse.JsonResponse["id"].ToString();
            _httpWebRequestBuilder = new HttpWebRequestBuilder("/" + _gistId);
        }

        [Test]
        public void WhenICreateANewGist_TheDetailsSentAreStoredCorrectly()
        {
            ApiResponse response = _httpWebRequestBuilder
                .WithAuthorisationHeaders()
                .Build()
                .GetApiResponse();

            Assert.AreEqual("myFile.txt", response.JsonResponse["files"]["myFile.txt"]["filename"].ToString());
            Assert.AreEqual(true, (bool)response.JsonResponse["public"]);
            Assert.AreEqual(200, (int)response.StatusCode);
        }
    }
}
