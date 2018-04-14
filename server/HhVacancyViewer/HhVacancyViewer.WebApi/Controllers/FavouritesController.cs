using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HhVacancyViewer.Core.Pg;
using HhVacancyViewer.WebApi.Helpers;
using HhVacancyViewer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HhVacancyViewer.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Favourites")]
    public class FavouritesController : Controller
    {
        private HeadHunterDbContext _context;
        public FavouritesController(HeadHunterDbContext context)
        {
            _context = context;
        }
        // GET: api/Favourites
        [HttpGet]
        public IEnumerable<VacancyDto> Get()
        {
            return _context.Vacancies.Select(v => VacancyMapper.FromDbToDto(v));
        }

        // GET: api/Favourites/5
        [HttpGet("{id}", Name = "GetFavourites")]
        public async Task<VacancyDto> Get(long id)
        {
            var vacancy = await _context.Vacancies.FirstOrDefaultAsync(v => v.Id.Equals(id));
            return VacancyMapper.FromDbToDto(vacancy);
        }
        
        // POST: api/Favourites
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]VacancyDto value)
        {
            try
            {
                await _context.Vacancies.AddAsync(VacancyMapper.FromDtoToDb(value));
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch (Exception e)
            {
                
                return StatusCode(500, e);
            }
            
        }
    }
}
