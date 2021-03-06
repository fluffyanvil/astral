﻿using Newtonsoft.Json;

namespace HhVacancyViewer.Core.HhApi.Models.Models
{
    public class Contacts
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phones")]
        public Phone[] Phones { get; set; }
    }

    public class Phone
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("comment")]
        public object Comment { get; set; }
    }
}
