using System.Collections.Generic;
using JobsDashboard.Data;

namespace JobsDashboard.Console.Data
{
    public class DataStore : IDataStore
    {
        public void CreateJobs(IDictionary<string, string> data)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string source)
        {
            throw new System.NotImplementedException();
        }

        public string GetJobs(string source)
        {
            throw new System.NotImplementedException();
        }
    }
}