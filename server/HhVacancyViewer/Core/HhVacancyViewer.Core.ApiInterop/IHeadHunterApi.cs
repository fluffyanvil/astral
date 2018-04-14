using System.Collections.Generic;
using System.Threading.Tasks;
using HhVacancyViewer.Core.HhApi.Models.Models;

namespace HhVacancyViewer.Core.ApiInterop
{
    public interface IHeadHunterApi
    {
        Task<IEnumerable<Vacancy>> GetVacancies();
    }
}
