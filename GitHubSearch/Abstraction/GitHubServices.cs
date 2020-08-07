using GitHubSearch.Interface;
using GitHubSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearch.Abstraction
{
    public class GitHubService : IGitHubServices<GitHubRepoModel>
    {
        private readonly IConfig _config;
        private readonly IWebClient _webClient;
        private readonly IConverter _converter;

        private GitHubRepoModel _model;

        public GitHubService(IConfig config, IWebClient webClient, IConverter converter)
        {
            _config = config;
            _webClient = webClient;
            _converter = converter;

            _model = new GitHubRepoModel();
        }

        public GitHubRepoModel GetRepoByName(string searchString)
        {
            var jsonResult = _webClient.DownloadString(string.Format(_config.GitHubUrl, searchString));
            _model.RepoDetailsMap = _converter.DeserializeObject(jsonResult);

            foreach (var key in _model.RepoDetailsMap.Keys)
            {
                string[] strArr = key.Split('/');
                string currentKey = strArr[1] + "  (" + strArr[0] + ")";
                _model.ListOfRepositories.Add(currentKey);
            }

            return _model;
        }

        public string CheckReadMeByName(string searchString, ref bool IsReadmePresent)
        {
            string readmeStr = string.Format(_config.GitHubReadmeUrl, searchString);
            IsReadmePresent = true;
            string htmlResult = _webClient.DownloadString(readmeStr);
            if (string.IsNullOrEmpty(htmlResult) || htmlResult.Contains("Page not found"))
            {
                IsReadmePresent = false;
                return String.Empty;
            }

            return readmeStr;
        }


    }
}