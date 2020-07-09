using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TvCast.Domain.TvMazeModels
{
    public class TvMazeShow
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public TvMazeImage Image { get; set; }
        [JsonProperty("_embedded")]
        public TvMazeEmbedded Embedded { get; set; }
    }
}