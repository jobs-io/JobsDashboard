using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobsDashboard.Tests
{
    public class AppTests
    {
        private JobsDashboard.App app;
        private Mock<IHttpClient> httpClientMock;
        private Mock<IDataStore> dataStoreMock;
    
        [SetUp]
        public void Setup()
        {
            httpClientMock = new Mock<IHttpClient>();
            dataStoreMock = new Mock<IDataStore>();
        }

        [Test]
        public void ShouldGetJobsFromSource() {
            var source = "https://my-source/jobs";
            var content = "<html><body><data><title>job title</title></data></body></html>";

            var response = new HttpResponseMessage() {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(content)
            };

            httpClientMock.Setup(x => x.GetAsync(source)).Returns(Task.FromResult(response));
            
            var jobs = new App(httpClientMock.Object, source, dataStoreMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source));
        }

        [Test]
        public void ShouldGetJobFromDataStoreIfItExists() {
            var source = "https://my-source/jobs";

            httpClientMock.Setup(x => x.GetAsync(source));
            dataStoreMock.Setup(x => x.Exists(source)).Returns(true);
            
            new App(httpClientMock.Object, source, dataStoreMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source), Times.Never());
            dataStoreMock.Verify(x => x.Exists(source));
        }

        [Test]
        public void ShouldCreateJobIfItDoesNotExist() {

        }
    }
}