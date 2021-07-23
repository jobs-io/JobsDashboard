namespace JobsDashboard
{
    public interface IDataStore
    {
         bool Exists(string source);
         string GetJobs(string source);
    }
}