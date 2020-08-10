using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GitHubSearch.Models
{
    public class GitHubRepoModel
    {
        public GitHubRepoModel()
        {
            this.ListOfRepositories = new List<string>();

            this.CurrentRepoDetails = new Dictionary<string, string>();
            this.CurrentRepo = string.Empty;
            this.IsReadMeAvailable = false;
            this.ReadmeURL = "README.md file not available !!";

            IsSearchResultView = true;
        }

        [Required]
        [Display(Name="Search Repository")]
        public string SearchString { get; set; }

        public List<string> ListOfRepositories { get; set; }

        /////////////////////////////////////////////
        ///
        public Dictionary<string, string> CurrentRepoDetails { get; set; }

        public string CurrentRepo { get; set; }

        public bool IsReadMeAvailable { get; set; }

        public string ReadmeURL { get; set; }

        public bool IsSearchResultView;

    }
}