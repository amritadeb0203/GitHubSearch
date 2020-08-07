using System.Collections.Generic;

namespace GitHubSearch.Interface
{
    public interface IConverter
    {
        T DeserializeObject<T>(string input);

        Dictionary<string, Dictionary<string, string>> DeserializeObject(string input);
    }
}
