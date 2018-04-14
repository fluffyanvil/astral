using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Models.Models
{
    public class Employment
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
