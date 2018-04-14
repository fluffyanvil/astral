using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Models.Models
{
    public class Snippet
    {
        [JsonProperty("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("responsibility")]
        public string Responsibility { get; set; }
    }
}
