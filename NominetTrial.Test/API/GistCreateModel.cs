using Newtonsoft.Json;

namespace NominetTrial.Test.API
{
    public partial class GistCreateModel
    {

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("files")]
        public Files Files { get; set; }
    }

    public partial class Files
    {
        [JsonProperty("myFile.txt")]
        public MyFileTxt myFileTxt { get; set; }
    }

    public partial class MyFileTxt
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
