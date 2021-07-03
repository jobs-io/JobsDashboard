using NUnit.Framework;
using Moq;
using JobsDashboard.Core;

namespace JobsDashboard.Tests.Core
{
    public class FeedTests
    {
        private Mock<IConfiguration> configuration;

        [SetUp]
        public void BeforeEachTest() {
            configuration = new Mock<IConfiguration>();
        }

        [Test]
        public void ShouldGetSource() {
            this.configuration.Setup(x => x.GetValue("source"));

            var feed = new Feed(configuration.Object);

            this.configuration.Verify(x => x.GetValue("source"), Times.Once);
        }

        [Test]
        public void ShouldGetPathToJobs() {
            this.configuration.Setup(x => x.GetValue("pathToJobs"));

            var feed = new Feed(configuration.Object);

            this.configuration.Verify(x => x.GetValue("pathToJobs"), Times.Once);

        }
    }
}