using System.Linq;
using HhVacancyViewer.Core.HhApi.Common.Models;
using HhVacancyViewer.Core.Pg;
using HhVacancyViewer.WebApi.Models;

namespace HhVacancyViewer.WebApi.Helpers
{
    public class VacancyMapper
    {
        public static Vacancies FromDtoToDb(VacancyDto dto)
        {
            return new Vacancies
            {
                Id = dto.Id,
                Employment = dto.Employment,
                ContactPerson = dto.ContactPerson,
                ContactPhone = dto.ContactPhone,
                ContactEmail = dto.ContactEmail,
                Description = dto.Employment,
                IsFavourite = dto.IsFavourite,
                Organization = dto.Organization,
                OrganizationUrl = dto.OrganizationUrl,
                SalaryFrom = dto.SalaryFrom,
                SalaryTo = dto.SalaryTo,
                Title = dto.Title
            };
        }

        public static VacancyDto FromDbToDto(Vacancies vacancy)
        {
            return new VacancyDto
            {
                Id = vacancy.Id,
                Employment = vacancy.Employment,
                ContactPerson = vacancy.ContactPerson,
                ContactPhone = vacancy.ContactPhone,
                ContactEmail = vacancy.ContactEmail,
                Description = vacancy.Employment,
                IsFavourite = vacancy.IsFavourite,
                Organization = vacancy.Organization,
                OrganizationUrl = vacancy.OrganizationUrl,
                SalaryFrom = vacancy.SalaryFrom,
                SalaryTo = vacancy.SalaryTo,
                Title = vacancy.Title
            };
        }

        public static VacancyDto FromApiToDto(Vacancy vacancy)
        {
            return new VacancyDto
            {
                Id = vacancy.Id,
                Employment = vacancy.Employment?.Name,
                ContactPerson = vacancy.Contacts?.Name,
                ContactPhone = vacancy.Contacts?.Phones?.FirstOrDefault()?.Number,
                ContactEmail = vacancy.Contacts?.Email,
                Description = $"{vacancy.Snippet?.Requirement} - {vacancy.Snippet?.Responsibility}",
                Organization = vacancy.Employer?.Name,
                OrganizationUrl = vacancy.Employer?.Url,
                SalaryFrom = vacancy.Salary?.From,
                SalaryTo = vacancy.Salary?.To,
                Title = vacancy.Name
            };
        }
    }
}