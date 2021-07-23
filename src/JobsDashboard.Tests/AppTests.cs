using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobsDashboard.Tests
{

    public class AppTests
    {
        private class Data {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Company { get; set; }
        }
        private JobsDashboard.App app;
        private Mock<IHttpClient> httpClientMock;
        private Mock<IDataStore> dataStoreMock;
        private Mock<IConfiguration> configMock;
        private string content;
        private string source;

        private Data data = new Data() {
            Title = "I am a little helper",
            Description = "I help run sql jobs",
            Company = "I belong to everyone"
        };

        [SetUp]
        public void Setup()
        {
            httpClientMock = new Mock<IHttpClient>();
            dataStoreMock = new Mock<IDataStore>();
            configMock = new Mock<IConfiguration>();

            content = $"<html><body><jobs><data><title>{data.Title}</title><description>{data.Description}</description><company>{data.Company}</company></data><data><title>{data.Title}</title><description>{data.Description}</description><company>{data.Company}</company></data></jobs></body></html>";
            source = "https://my-source/jobs";

            configMock.Setup(x => x.GetValue("path")).Returns("//jobs");
            configMock.Setup(x => x.GetValue("title")).Returns("//data/title");
            configMock.Setup(x => x.GetValue("description")).Returns("//data/description");
            configMock.Setup(x => x.GetValue("company")).Returns("//data/company");
        }

        [Test]
        public async Task ShouldGetJobsFromSource() {
            var response = new HttpResponseMessage() {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(content)
            };

            httpClientMock.Setup(x => x.GetAsync(source)).Returns(Task.FromResult(response));
            
            var jobs = await new App(httpClientMock.Object, source, dataStoreMock.Object, configMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source));
            Assert.AreEqual(1, jobs.Count);
            Assert.AreEqual(data.Title, jobs[0].Title);
            Assert.AreEqual(data.Description, jobs[0].Description);
            Assert.AreEqual(data.Company, jobs[0].Company);
            configMock.Verify(x => x.GetValue("path"));
            configMock.Verify(x => x.GetValue("title"));
            configMock.Verify(x => x.GetValue("description"));
            configMock.Verify(x => x.GetValue("company"));
        }

        [Test]
        public async Task ShouldGetJobFromDataStoreIfItExists() {
            // var source = "https://my-source/jobs";

            // configMock.Setup(x => x.GetValue("path")).Returns("//jobs");
            // configMock.Setup(x => x.GetValue("title")).Returns("//data/title");
            // configMock.Setup(x => x.GetValue("description")).Returns("//data/description");
            // configMock.Setup(x => x.GetValue("company")).Returns("//data/company");

            httpClientMock.Setup(x => x.GetAsync(source));
            dataStoreMock.Setup(x => x.Exists(source)).Returns(true);
            dataStoreMock.Setup(x => x.GetJobs(source)).Returns(content);
            
            var jobs = await new App(httpClientMock.Object, source, dataStoreMock.Object, configMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source), Times.Never());
            Assert.AreEqual(1, jobs.Count);
            Assert.AreEqual(data.Title, jobs[0].Title);
            Assert.AreEqual(data.Description, jobs[0].Description);
            Assert.AreEqual(data.Company, jobs[0].Company);
            dataStoreMock.Verify(x => x.Exists(source));
            dataStoreMock.Verify(x => x.GetJobs(source));
            configMock.Verify(x => x.GetValue("path"));
            configMock.Verify(x => x.GetValue("title"));
            configMock.Verify(x => x.GetValue("description"));
            configMock.Verify(x => x.GetValue("company"));
        }

        [Test]
        public async Task ShouldCreateJobIfItDoesNotExist() {
            // var source = "https://my-source/jobs";

            // configMock.Setup(x => x.GetValue("path")).Returns("//jobs");
            // configMock.Setup(x => x.GetValue("title")).Returns("//data/title");
            // configMock.Setup(x => x.GetValue("description")).Returns("//data/description");
            // configMock.Setup(x => x.GetValue("company")).Returns("//data/company");

            var response = new HttpResponseMessage() {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(content)
            };
            httpClientMock.Setup(x => x.GetAsync(source)).Returns(Task.FromResult(response));
            dataStoreMock.Setup(x => x.Exists(source)).Returns(false);
            var d = new Dictionary<string, string>() { { source, content }};
            dataStoreMock.Setup(x => x.CreateJobs(d));
            dataStoreMock.Setup(x => x.GetJobs(source)).Returns(content);
            
            await new App(httpClientMock.Object, source, dataStoreMock.Object, configMock.Object).GetJobs();

            dataStoreMock.Verify(x => x.Exists(source));
            httpClientMock.Verify(x => x.GetAsync(source));
            dataStoreMock.Verify(x => x.CreateJobs(d));
            dataStoreMock.Verify(x => x.GetJobs(source), Times.Never());
            configMock.Verify(x => x.GetValue("path"));
            configMock.Verify(x => x.GetValue("title"));
            configMock.Verify(x => x.GetValue("description"));
            configMock.Verify(x => x.GetValue("company"));
        }
    }
}