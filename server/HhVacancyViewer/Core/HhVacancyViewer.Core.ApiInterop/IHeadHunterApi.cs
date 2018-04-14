using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HhVacancyViewer.Core.HhApi.Common.Models;

namespace HhVacancyViewer.Core.ApiInterop
{
    public interface IHeadHunterApi
    {
        Task<IEnumerable<Vacancy>> GetVacancies();
    }
}
