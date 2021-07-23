using System.Net.Http;
using System.Threading.Tasks;

namespace JobsDashboard.Core
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}