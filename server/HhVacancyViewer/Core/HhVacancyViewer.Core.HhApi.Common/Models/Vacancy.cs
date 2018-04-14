using System;
using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Common.Models
{
    public class Vacancy
    {
        // заголовок, оклад, организация разместившая вакансию, контактное лицо, телефон, тип занятости, описание вакансии
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("salary")]
        public Salary Salary { get; set; }
        
        [JsonProperty("snippet")]
        public Snippet Snippet { get; set; }

        [JsonProperty("constacts")]
        public Contacts Contacts { get; set; }

        [JsonProperty("employer")]
        public Employer Employer { get; set; }

        [JsonProperty("employment")]
        public Employment Employment { get; set; }

        public string Summary =>
            $"{Name}, {Snippet.Requirement}, {Snippet.Responsibility}, ({Salary?.From}-{Salary?.To}, {Employer?.Name})";
    }
}