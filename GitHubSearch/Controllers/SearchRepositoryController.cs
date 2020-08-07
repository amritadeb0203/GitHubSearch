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
        public readonly IGitHubServices<GitHubRepoModel> _githubService;

        public SearchRepositoryController(IGitHubServices<GitHubRepoModel> githubService)
        {
            _githubService = githubService;
        }

        [HttpGet]
        public ActionResult SearchRepo()
        {
            return View(new GitHubRepoModel());
        }

        [HttpPost]
        public ActionResult SearchRepo(GitHubRepoModel model)
        {
            var retModel = _githubService.GetRepoByName(model.SearchString);
            model.ListOfRepositories = retModel.ListOfRepositories;
            
            return View(model);
        }
        

        [HttpGet]
        public ActionResult RepoDetails(string key, GitHubRepoModel model)
        {
            char[] delim = new char[] { ' ', '(', ')' };
            string[] strArr = key.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            string currentKey = strArr[1] + "/" + strArr[0];
            GitHubRepoModel retModel = _githubService.GetRepoByName(currentKey);

            RepoDetailsModel modelDet = new RepoDetailsModel();
            modelDet.CurrentRepo = currentKey;
            modelDet.CurrentRepoDetails = retModel.RepoDetailsMap[currentKey];

            bool checkIfReadMe = true;
            string retStr = _githubService.CheckReadMeByName(currentKey, ref checkIfReadMe);
            modelDet.IsReadMeAvailable = checkIfReadMe;
            if (checkIfReadMe)
                modelDet.ReadmeURL = retStr;

            return View(modelDet);
        }
    }
}
