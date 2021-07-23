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
        public App(
            IHttpClient httpClient,
            string source,
            IDataStore dataStore,
            IConfiguration config
            )
        {
            this.config = config;
            this.dataStore = dataStore;
            this.source = source;
            this.httpClient = httpClient;
        }

        private HtmlReader.Reader GetHtmlReader(string html) {
            return new HtmlReader.Reader(html);
        }
        private IDictionary<string, string> CreatedData(string content) {
            return new Dictionary<string, string> {
                {
                    source,
                    content
                }
            };
        }
        public async ValueTask<Jobs> GetJobs()
        {
            if (dataStore.Exists(source))
                return new Jobs(
                    GetHtmlReader(dataStore.GetJobs(source)),
                    config
                );
            var results = await httpClient.GetAsync(source);
            var content = await results.Content.ReadAsStringAsync();
            var reader = new HtmlReader.Reader(content);
            this.dataStore.CreateJobs(CreatedData(content));
            return new Jobs(reader, config);
        }
    }
}