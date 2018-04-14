using HhVacancyViewer.Core.HhApi.Requests.Parameters;
using HhVacancyViewer.Core.HhApi.Requests.Responses;

namespace HhVacancyViewer.Core.HhApi.Requests.Requests
{
    public class GetVacanciesRequest : BaseHttpRequest<GetVacanciesRequestParameters, GetVacanciesResponse>
    {
        public GetVacanciesRequest() : base("https://api.hh.ru/vacancies")
        {
        }
    }
}