using GitHubSearch.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GitHubSearch.Abstraction
{
    public class Config : IConfig
    {
        public string GitHubReadmeUrl => string.IsNullOrEmpty(ConfigurationManager.AppSettings["gitHubReadme.URL"])
            ? string.Empty
            : ConfigurationManager.AppSettings["gitHubReadme.URL"];

        public string GitHubUrl => string.IsNullOrEmpty(ConfigurationManager.AppSettings["gitHub.URL"])
            ? string.Empty
            : ConfigurationManager.AppSettings["gitHub.URL"];

        
    }
}