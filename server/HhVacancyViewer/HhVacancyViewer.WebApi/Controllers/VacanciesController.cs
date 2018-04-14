using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HhVacancyViewer.Core.ApiInterop;
using HhVacancyViewer.Core.HhApi.Common.Models;
using HhVacancyViewer.Core.Pg;
using HhVacancyViewer.WebApi.Helpers;
using HhVacancyViewer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HhVacancyViewer.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Vacancies")]
    public class VacanciesController : Controller
    {
        private HeadHunterDbContext _context;
        private IHeadHunterApi _headHunterApi;
        public VacanciesController(HeadHunterDbContext context, IHeadHunterApi headHunterApi)
        {
            _context = context;
            _headHunterApi = headHunterApi;
        }
        // GET: api/Vacancies
        [HttpGet]
        public async Task<IEnumerable<VacancyDto>> Get()
        {
            var vacancies = await _headHunterApi.GetVacancies();
            return vacancies.Select(VacancyMapper.FromApiToDto);
        }
    }
}
