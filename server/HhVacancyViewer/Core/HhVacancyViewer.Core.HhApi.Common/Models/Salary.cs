using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Common.Models
{
    public class Salary
    {
        [JsonProperty("to")]
        public int? To { get; set; }

        [JsonProperty("gross")]
        public bool? Gross { get; set; }

        [JsonProperty("from")]
        public int? From { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
