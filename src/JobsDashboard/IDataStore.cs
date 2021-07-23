using System.Collections.Generic;

namespace JobsDashboard
{
    public interface IDataStore
    {
         bool Exists(string source);
         string GetJobs(string source);
         void CreateJobs(IDictionary<string, string> data);
    }
}