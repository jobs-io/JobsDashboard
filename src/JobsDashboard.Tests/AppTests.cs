using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace JobsDashboard.Tests
{
    public class AppTests
    {
        private JobsDashboard.App app;
        private Mock<IHttpClient> httpClientMock;
    
        [SetUp]
        public void Setup()
        {
            httpClientMock = new Mock<IHttpClient>();
        }

        [Test]
        public void ShouldGetJobs() {
            httpClientMock.Setup(x => x.GetAsync(""));
            
            new App(httpClientMock.Object).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(""));
        }
    }
}