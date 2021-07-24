using System.Net.Http;
using System.Threading.Tasks;
using JobsDashboard.Core;

namespace JobsDashboard.Console.Core
{
    public class HttpClient : IHttpClient
    {
        private System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return this.httpClient.GetAsync(requestUri);
        }
    }
}