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
            var source = "https://my-source/jobs";

            httpClientMock.Setup(x => x.GetAsync(source));
            
            new App(httpClientMock.Object, source).GetJobs();

            httpClientMock.Verify(x => x.GetAsync(source));
        }
    }
}