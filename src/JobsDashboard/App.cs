using System.Threading.Tasks;
using JobsDashboard.Data;

namespace JobsDashboard
{
    public class App
    {
        private readonly IHttpClient httpClient;
        private readonly string source;
        private readonly IDataStore dataStore;
        private readonly IConfiguration config;
        public App(IHttpClient httpClient, string source, IDataStore dataStore, IConfiguration config)
        {
            this.config = config;
            this.dataStore = dataStore;
            this.source = source;
            this.httpClient = httpClient;
        }
        public async ValueTask<Jobs> GetJobs()
        {
            if (dataStore.Exists(source))
                return new Jobs(null, config);
            var results = await httpClient.GetAsync(source);
            var reader = new HtmlReader.Reader(await results.Content.ReadAsStringAsync());
            return new Jobs(reader, config);
        }
    }
}