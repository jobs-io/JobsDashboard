using NUnit.Framework;
using Moq;
using System.Collections.Generic;

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
        public void ShouldGetJobs() {
            var source = "https://my-source/jobs";

            httpClientMock.Setup(x => x.GetAsync(source));
            
            new App(httpClientMock.Object, source, dataStoreMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source));
        }

        [Test]
        public void ShouldNotGetJobsIfItExists() {
            var source = "https://my-source/jobs";

            httpClientMock.Setup(x => x.GetAsync(source));
            dataStoreMock.Setup(x => x.Exists(source)).Returns(true);
            
            new App(httpClientMock.Object, source, dataStoreMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source), Times.Never());
            dataStoreMock.Verify(x => x.Exists(source));
        }
    }
}