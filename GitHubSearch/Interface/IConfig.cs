using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubSearch.Interface
{
    public interface IConfig
    {
        string GitHubUrl { get; }

        string GitHubReadmeUrl { get; }

    }
}
