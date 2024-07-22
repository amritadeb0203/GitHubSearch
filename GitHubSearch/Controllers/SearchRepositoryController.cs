using GitHubSearch.Abstraction;
using GitHubSearch.Interface;
using GitHubSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GitHubSearch.Controllers
{
    public class SearchRepositoryController : Controller
    {
        public readonly IGitHubServices _githubService;
        private AppModelData _appData;

        public SearchRepositoryController(IGitHubServices githubService, AppModelData data)
        {
            _githubService = githubService;
            _appData = data;
        }

        [HttpGet]
        public ActionResult SearchRepo()
        {
            return View(new GitHubRepoModel());
        }

        [HttpPost]
        public ActionResult SearchRepo(GitHubRepoModel model)
        {
            model.IsSearchResultView = true;
            var retModel = _githubService.GetRepoByName(model.SearchString);
            model.ListOfRepositories = retModel.ListOfRepositories;
            
            return View(model);
        }
        

        [HttpGet]
        public ActionResult RepoDetails(string key, GitHubRepoModel model)
        {
            model.IsSearchResultView = false;
            char[] delim = new char[] { ' ', '(', ')' };
            string[] strArr = key.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            string currentKey = strArr[1] + "/" + strArr[0];

            if (!_appData.RepoReadmeMap.ContainsKey(currentKey))
            {
                bool checkIfReadMe = true;
                string retStr = _githubService.CheckReadMeByName(currentKey, ref checkIfReadMe);
                model.IsReadMeAvailable = checkIfReadMe;
                if (checkIfReadMe)
                    _appData.RepoReadmeMap.Add(currentKey, retStr);
                else
                    _appData.RepoReadmeMap.Add(currentKey, string.Empty);
            }

            model.ReadmeURL = _appData.RepoReadmeMap[currentKey];
            model.IsReadMeAvailable = !string.IsNullOrEmpty(model.ReadmeURL);
            model.CurrentRepo = key;
            model.CurrentRepoDetails = _appData.RepoDetailsMap[currentKey];

            //Fill the old data as well since it is single page
            model.SearchString = _appData.SearchString;
            model.ListOfRepositories = _appData.ListOfRepositories;

            return View("SearchRepo", model);
        }
    }
}


