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
        private Mock<IConfiguration> configMock;
    
        [SetUp]
        public void Setup()
        {
            httpClientMock = new Mock<IHttpClient>();
            dataStoreMock = new Mock<IDataStore>();
            configMock = new Mock<IConfiguration>();
        }

        [Test]
        public async Task ShouldGetJobsFromSource() {
            var source = "https://my-source/jobs";
            var data = new {
                title = "I am a little helper",
                description = "I help run sql jobs",
                company = "I belong to everyone"
            };
            var content = $"<html><body><jobs><data><title>{data.title}</title><description>{data.description}</description><company>{data.company}</company></data><data><title>{data.title}</title><description>{data.description}</description><company>{data.company}</company></data></jobs></body></html>";

            var response = new HttpResponseMessage() {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(content)
            };

            configMock.Setup(x => x.GetValue("path")).Returns("//jobs");
            configMock.Setup(x => x.GetValue("title")).Returns("//data/title");
            configMock.Setup(x => x.GetValue("description")).Returns("//data/description");
            configMock.Setup(x => x.GetValue("company")).Returns("//data/company");

            httpClientMock.Setup(x => x.GetAsync(source)).Returns(Task.FromResult(response));
            
            var jobs = await new App(httpClientMock.Object, source, dataStoreMock.Object, configMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source));
            Assert.AreEqual(1, jobs.Count);
            Assert.AreEqual(data.title, jobs[0].Title);
            Assert.AreEqual(data.description, jobs[0].Description);
            Assert.AreEqual(data.company, jobs[0].Company);
            configMock.Verify(x => x.GetValue("path"));
            configMock.Verify(x => x.GetValue("title"));
            configMock.Verify(x => x.GetValue("description"));
            configMock.Verify(x => x.GetValue("company"));
        }

        // [Test]
        // public void ShouldGetJobFromDataStoreIfItExists() {
        //     var source = "https://my-source/jobs";

        //     httpClientMock.Setup(x => x.GetAsync(source));
        //     dataStoreMock.Setup(x => x.Exists(source)).Returns(true);
            
        //     new App(httpClientMock.Object, source, dataStoreMock.Object).GetJobs();

        //     httpClientMock.Verify(x => x.GetAsync(source), Times.Never());
        //     dataStoreMock.Verify(x => x.Exists(source));
        // }

        // [Test]
        // public void ShouldCreateJobIfItDoesNotExist() {

        // }
    }
}