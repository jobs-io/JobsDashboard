using System.Collections.Generic;
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
                return new Jobs(new HtmlReader.Reader(dataStore.GetJobs(source)), config);
            var results = await httpClient.GetAsync(source);
            var content = await results.Content.ReadAsStringAsync();
            var reader = new HtmlReader.Reader(content);
            this.dataStore.CreateJobs(new Dictionary<string, string>() {{source, content}});
            return new Jobs(reader, config);
        }
    }
}