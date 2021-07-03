namespace JobsDashboard.Core
{
    public class Feed
    {
        public Feed(IConfiguration configuration)
        {
            configuration.GetValue("source");       
            configuration.GetValue("pathToJobs");       
        }
    }
}