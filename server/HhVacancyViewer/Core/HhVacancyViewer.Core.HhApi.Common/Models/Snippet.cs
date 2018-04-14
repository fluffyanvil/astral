using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Common.Models
{
    public class Snippet
    {
        [JsonProperty("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("responsibility")]
        public string Responsibility { get; set; }
    }
}
