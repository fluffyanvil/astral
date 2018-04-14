using System.Collections.Generic;

namespace HhVacancyViewer.Core.HhApi.Requests.Parameters
{
    public class GetVacanciesRequestParameters : BaseRequestParameters
    {
        public int Specialization { get; set; }

        public int Area { get; set; }

        public bool OnlyWithSalary { get; set; }

        public int PerPage { get; set; }

        public GetVacanciesRequestParameters(int specialization, int area, bool onlyWithSalary, int perPage)
        {
            Specialization = specialization;
            Area = area;
            OnlyWithSalary = onlyWithSalary;
            PerPage = perPage;
        }

        public static GetVacanciesRequestParameters Build()
        {
            return new GetVacanciesRequestParameters(1, 1859, true, 50);
        }
        public override Dictionary<string, string> Parameters => 
            new Dictionary<string, string>
                {
                    {"specialization", Specialization.ToString() },
                    {"area", Area.ToString() },
                    { "only_with_salary", OnlyWithSalary.ToString().ToLower()},
                    { "per_page", PerPage.ToString()}
                };
    }
}