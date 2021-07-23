namespace JobsDashboard
{
    public interface IConfiguration
    {
        string GetValue(string path);
    }
}