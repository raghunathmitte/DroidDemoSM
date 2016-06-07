using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDemoData.Models
{
    public class RowItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("videoUrl")]
        public string VideoUrl { get; set; }
    }

    public class Result
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("items")]
        public List<RowItem> Tiles { get; set; }
    }

    
    public class Results
    {
        [JsonProperty("response")]
        public string Response { get; set; }
        [JsonProperty("results")]
        public List<Result> VerticalTiles { get; set; }
    }
}
