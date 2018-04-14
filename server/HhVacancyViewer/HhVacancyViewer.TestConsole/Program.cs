using System;
using System.Text;
using HhVacancyViewer.Core.ApiInterop;

namespace HhVacancyViewer.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello World!");
            IHeadHunterApi api = new HeadHunterApi();

            var vacancies = api.GetVacancies().Result;

            foreach (var vacancy in vacancies)
            {
                Console.WriteLine(vacancy.Summary);
            }

            Console.ReadLine();
        }
    }
}
