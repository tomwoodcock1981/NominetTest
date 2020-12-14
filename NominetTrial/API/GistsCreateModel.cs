using System;
using System.Collections.Generic;
using System.Text;

namespace NominetTrial.Tests.API
{
    public class GistsCreateModel
    {
        public GistsCreateModel()
        {
            Files = new List<string>();
            Description = new List<string>();
        }

        public List<string> Files { get; set; }

        public List<string> Description { get; set; }

        public bool Public { get; set; }
    }
}
