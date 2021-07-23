using System.Collections.Generic;

namespace JobsDashboard.Data
{
    public interface IDataStore
    {
         bool Exists(string source);
         string GetJobs(string source);
         void CreateJobs(IDictionary<string, string> data);
    }
}