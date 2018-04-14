using System.Collections.Generic;

namespace HhVacancyViewer.Core.HhApi.Requests
{
    public abstract class BaseRequestParameters
    {
        public abstract Dictionary<string, string> Parameters { get; }
    }
}