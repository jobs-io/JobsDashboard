namespace JobsDashboard.Core
{
    public interface IConfiguration
    {
        string GetValue(string path);
    }
}