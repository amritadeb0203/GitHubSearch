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
            this.RepoDetailsMap = new Dictionary<string, Dictionary<string, string>>();
        }

        [Required]
        [Display(Name="Search Repository")]
        public string SearchString { get; set; }

        public List<string> ListOfRepositories { get; set; }

        public Dictionary<string, Dictionary<string, string>> RepoDetailsMap { get; set; }

    }
}