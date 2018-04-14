using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HhVacancyViewer.Core.HhApi.Models.Models;
using HhVacancyViewer.Core.HhApi.Requests;
using HhVacancyViewer.Core.HhApi.Requests.Parameters;
using HhVacancyViewer.Core.HhApi.Requests.Requests;
using HhVacancyViewer.Core.HhApi.Requests.Responses;

namespace HhVacancyViewer.Core.ApiInterop
{
    public class HeadHunterApi : IHeadHunterApi
    {
        private readonly BaseHttpRequest<GetVacanciesRequestParameters, GetVacanciesResponse> _getVacanciesRequest;
        private readonly GetVacanciesRequestParameters _getVacanciesRequestParameters;

        public HeadHunterApi()
        {
            _getVacanciesRequest = new GetVacanciesRequest();
            _getVacanciesRequestParameters = GetVacanciesRequestParameters.Build();
        }

        public async Task<IEnumerable<Vacancy>> GetVacancies()
        {
            try
            {
                var result = await _getVacanciesRequest.Execute(_getVacanciesRequestParameters);
                return result.Items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}