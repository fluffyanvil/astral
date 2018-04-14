using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HhVacancyViewer.Core.ApiInterop;
using HhVacancyViewer.Core.Pg;
using HhVacancyViewer.WebApi.Helpers;
using HhVacancyViewer.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HhVacancyViewer.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Vacancies")]
    [EnableCors("SiteCorsPolicy")]
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
            var hhVacancies = await _headHunterApi.GetVacancies();
            var storedVacancies = _context.Vacancies;
            var dtos = hhVacancies.Select(VacancyMapper.FromApiToDto).ToList();

            foreach (var vacancyDto in dtos)
            {
                vacancyDto.IsFavourite = storedVacancies.FirstOrDefault(v => v.Id.Equals(vacancyDto.Id))?.IsFavourite ?? false;
            }

            return dtos;
        }

        [HttpGet("{id}", Name = "GetVacancyById")]
        public async Task<VacancyDto> Get(long id)
        {
            var stored = await _context.Vacancies.FirstOrDefaultAsync(v => v.Id.Equals(id));
            return VacancyMapper.FromDbToDto(stored);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VacancyDto value)
        {
            try
            {
                var vacancy = VacancyMapper.FromDtoToDb(value);
                var target = _context.Vacancies.FirstOrDefault(v => v.Id.Equals(vacancy.Id));

                if (target == null)
                {
                    await _context.AddAsync(vacancy);
                    await _context.SaveChangesAsync();
                    return StatusCode(200);
                }
                target.IsFavourite = target.IsFavourite != null ? !target.IsFavourite : true;
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }

            
        }
    }
}
