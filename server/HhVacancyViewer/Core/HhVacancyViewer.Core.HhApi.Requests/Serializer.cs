using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Requests
{
    public class Serializer<TResult>
    {
        public TResult DeserializeJson(string json)
        {
            var result = JsonConvert.DeserializeObject<TResult>(json);
            return result;
        }
    }
}