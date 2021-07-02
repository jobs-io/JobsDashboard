using NUnit.Framework;
using Moq;
using JobsDashboard;
using JobsDashboard.Core;

namespace JobsDashboard.Tests
{
    public class AppTests
    {
        private JobsDashboard.App app; 
        private JobsDashboard.Core.Feeds feeds;
    
        [SetUp]
        public void Setup()
        {
            feeds = new JobsDashboard.Core.Feeds(null);
            app = new App(feeds);
        }

        [Test]
        public void ShouldLoadFeedsWhenICallDownload()
        {
            // this.feeds.Setup(x => x.Load());

            app.Download();

            // this.feeds.Verify(x => x.Load());
        }
    }
}