using System.Collections.Generic;
using JobsDashboard.Data;

namespace JobsDashboard
{
    public class App
    {
        private readonly IHttpClient httpClient;
        private readonly string source;
        private readonly IDataStore dataStore;
        public App(IHttpClient httpClient, string source, IDataStore dataStore)
        {
            this.dataStore = dataStore;
            this.source = source;
            this.httpClient = httpClient;
        }
        public Jobs GetJobs()
        {
            if (dataStore.Exists(source)) 
                return new Jobs();
            httpClient.GetAsync(source);
            return new Jobs();
        }
    }
}