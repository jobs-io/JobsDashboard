namespace JobsDashboard
{
    public class App
    {
        private readonly IHttpClient httpClient;
        public App(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public void GetJobs()
        {
            httpClient.GetAsync("");
        }
    }
}
