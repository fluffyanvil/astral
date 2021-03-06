﻿using System;
using System.Collections.Generic;

namespace HhVacancyViewer.Core.Pg
{
    public partial class Vacancies
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }
        public string Organization { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string OrganizationUrl { get; set; }
        public string Employment { get; set; }
        public string Description { get; set; }
        public bool? IsFavourite { get; set; }
        public string ContactEmail { get; set; }
    }
}
