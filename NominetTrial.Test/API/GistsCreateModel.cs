using Newtonsoft.Json;

namespace NominetTrial.Test.API
{
    public class GistsCreateModel
    {
        public string description { get; set; }
        public bool @public { get; set; }
        public NewFiles files { get; set; }
    }

    public class MyFile1Txt
    {
        public string content { get; set; }
    }

    public class MyFile2Txt
    {
        public string content { get; set; }
    }

    public class NewFiles
    {
        [JsonProperty("myFile1.txt")]
        public MyFile1Txt MyFile1Txt { get; set; }
        [JsonProperty("myFile2.txt")]
        public MyFile2Txt MyFile2Txt { get; set; }
    }
}
