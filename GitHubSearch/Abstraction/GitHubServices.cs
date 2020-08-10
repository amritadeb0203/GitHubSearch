using GitHubSearch.Interface;
using GitHubSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearch.Abstraction
{
    public class GitHubService : IGitHubServices
    {
        private readonly IConfig _config;
        private readonly IWebClient _webClient;
        private readonly IConverter _converter;

        private AppModelData _appData;

        public GitHubService(IConfig config, IWebClient webClient, IConverter converter, AppModelData data)
        {
            _config = config;
            _webClient = webClient;
            _converter = converter;
            _appData = data;
        }

        public AppModelData GetRepoByName(string searchString)
        {
            _appData.InitialiseAllData();

            var jsonResult = _webClient.DownloadString(string.Format(_config.GitHubUrl, searchString));
            _appData.RepoDetailsMap = _converter.DeserializeObject(jsonResult);

            foreach (var key in _appData.RepoDetailsMap.Keys)
            {
                string[] strArr = key.Split('/');
                string currentKey = strArr[1] + "  (" + strArr[0] + ")";
                _appData.ListOfRepositories.Add(currentKey);
            }

            _appData.SearchString = searchString;

            return _appData;
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
