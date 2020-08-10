using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GitHubSearch.Interface;

namespace GitHubSearch.Abstraction
{
    public class AppModelData
    {

        public AppModelData()
        {
            InitialiseAllData();
            
            //this.ReadmeURL = "README.md file not available !!";
        }

        public string SearchString { get; set; }

        public List<string> ListOfRepositories { get; set; }

        public Dictionary<string, Dictionary<string, string>> RepoDetailsMap { get; set; }

        public Dictionary<string, string> RepoReadmeMap { get; set; }

        public void InitialiseAllData()
        {
            this.ListOfRepositories = new List<string>();
            this.RepoDetailsMap = new Dictionary<string, Dictionary<string, string>>();
            this.RepoReadmeMap = new Dictionary<string, string>();
            this.SearchString = string.Empty;
        }

        
    }
}