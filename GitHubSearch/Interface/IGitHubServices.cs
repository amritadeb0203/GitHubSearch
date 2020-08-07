using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubSearch.Interface
{
    
    public interface IGitHubServices<out TRepository>
    {
        /// <summary>
        /// Search searchString at GitHub and returns the list of repositories
        /// </summary>
        /// <param name="searchString">username to search for</param>
        /// <returns>GitHubUser</returns>
        TRepository GetRepoByName(string searchString);

        string CheckReadMeByName(string searchString, ref bool IsReadmePresent);

    }
}
