using GitHubSearch.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubSearch.Abstraction
{
    public class JsonConverter : IConverter
    {
        public T DeserializeObject<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public Dictionary<string, Dictionary<string, string>> DeserializeObject(string input)
        {
            JObject jObj = JObject.Parse(input);

            string[] tagArray = new string[]{"id","name","full_name","html_url","description","fork",
                                         "stargazers_count","watchers_count","forks_count","open_issues_count","open_issues","watchers"};

            Dictionary<string, Dictionary<string, string>> allData = new Dictionary<string, Dictionary<string, string>>();

            foreach (var childToken in jObj.SelectToken("items").Children())
            {
                string currentKey = childToken.SelectToken("full_name").Value<string>();

                Dictionary <string, string> currDetails = new Dictionary<string, string>();

                foreach (var Key in tagArray)
                {
                    string Value = childToken[Key].Value<string>();
                    Console.WriteLine(Key + "  " + Value);
                    currDetails.Add(Key, Value);
                }

                allData.Add(currentKey, currDetails);
                
            }

            return allData;
        }


    }
}