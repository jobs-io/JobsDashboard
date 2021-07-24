using System.Collections.Generic;
using JobsDashboard.Core;

namespace JobsDashboard.Console.Core
{
    public class Configuration : IConfiguration
    {
        private readonly IDictionary<string, string> items;

        public Configuration(IDictionary<string, string> items)
        {
            this.items = items;   
        }
        public string GetValue(string key)
        {
            return items[key];
        }
    }
}