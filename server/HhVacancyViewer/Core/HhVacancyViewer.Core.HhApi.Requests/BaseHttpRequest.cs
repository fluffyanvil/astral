using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HhVacancyViewer.Core.HhApi.Requests
{
    public abstract class BaseHttpRequest<TRequestParameters, TResponse>
        where TRequestParameters : BaseRequestParameters
        where TResponse : BaseHttpResponse
    {
        private readonly HttpClient _httpClient;
        private readonly string _address;
        private readonly string _method;
        private string _responseJson;
        private readonly Serializer<TResponse> _serializer;

        private TResponse _result;
        protected BaseHttpRequest(string address, string method = "GET")
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", ".net core");
            _address = address;
            _method = method;
            _serializer = new Serializer<TResponse>();
        }
        public async Task<TResponse> Execute(TRequestParameters requestParameters)
        {
            try
            {
                var parameters = requestParameters.Parameters;
                var url = $"{_address}?{string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}";
                var responseStream = await _httpClient.GetStreamAsync(url);
                if (responseStream != null)
                    using (var sr = new StreamReader(responseStream))
                    {
                        _responseJson = sr.ReadToEnd();
                        _result = _serializer.DeserializeJson(_responseJson);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return _result;
        }
    }
}