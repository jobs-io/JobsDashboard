using System.Net.Http;
using System.Threading.Tasks;

namespace JobsDashboard
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}