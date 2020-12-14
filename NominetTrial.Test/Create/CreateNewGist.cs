using NUnit.Framework;
using NominetTrial.API.HttpHelper;
using NominetTrial.API.Extensions;
using NominetTrial.Test.API;
using Newtonsoft.Json.Linq;

namespace NominetTrial.Test.Create
{
    [TestFixture]
    public class CreateNewGist
    {
        private CreateGist _createGist;
        private ApiResponse _apiResponse;

        public CreateNewGist()
        {
            _createGist = new CreateGist();
        }
        
        [Test]
        public void PostingValidGistData_AddsTheCorrectData_AndReturnsA201Response()
        {
            _apiResponse = _createGist.BuildRequest("This is a test gist", "myFile.txt", true);

            JObject jsonResponse = _apiResponse.DeserialiseResponse();

            Assert.AreEqual("myFile.txt", jsonResponse["files"]["myFile.txt"]["filename"].ToString());
            Assert.AreEqual("This is a test gist", jsonResponse["files"]["myFile.txt"]["content"].ToString());
            Assert.AreEqual(true, (bool)jsonResponse["public"]);
            Assert.AreEqual(201, (int)_apiResponse.StatusCode);
        }
    }
}
