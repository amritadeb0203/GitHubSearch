using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearch.Models
{
    public class RepoDetailsModel
    {
        public RepoDetailsModel()
        {
            this.CurrentRepoDetails = new Dictionary<string, string>();
            this.CurrentRepo = string.Empty;
            this.IsReadMeAvailable = false;
            this.ReadmeURL = "README.md file not available !!";
        }

        public Dictionary<string, string> CurrentRepoDetails { get; set; }

        public string CurrentRepo { get; set; }

        public bool IsReadMeAvailable { get; set; }

        public string ReadmeURL { get; set; }
    }
}