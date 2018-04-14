using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Models.Models
{
    public class Employer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}