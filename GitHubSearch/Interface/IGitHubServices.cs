using GitHubSearch.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubSearch.Interface
{
    
    public interface IGitHubServices
    {
        /// <summary>
        /// Search searchString at GitHub and returns the list of repositories
        /// </summary>
        /// <param name="searchString">username to search for</param>
        /// <returns>GitHubUser</returns>
        AppModelData GetRepoByName(string searchString);

        string CheckReadMeByName(string searchString, ref bool IsReadmePresent);

    }
}
