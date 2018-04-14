using HhVacancyViewer.Core.HhApi.Common.Models;
using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Requests.Responses
{
    public class GetVacanciesResponse : BaseHttpResponse
    {
        [JsonProperty("items")]
        public Vacancy[] Items { get; set; }
    }
}