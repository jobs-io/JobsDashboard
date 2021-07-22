namespace JobsDashboard {
    public class App {
        private readonly IHttpClient httpClient;
        private readonly string source;
        public App (IHttpClient httpClient, string source) {
            this.source = source;
            this.httpClient = httpClient;
        }
        public void GetJobs () {
            httpClient.GetAsync (source);
        }
    }
}