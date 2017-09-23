using System;
using Newtonsoft.Json;

namespace AppRouletteNetFlix.Model
{
    public class Movie
    {
        [JsonProperty("show_title")]
        public string Title { get; set; }

        [JsonProperty("release_year")]
        public int ReleaseYear { get; set; }

        [JsonProperty("poster")]
        public string ImageUrl { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
