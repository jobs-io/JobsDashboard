using NUnit.Framework;
using Moq;
using JobsDashboard;
using JobsDashboard.Core;
using System.Collections.Generic;

namespace JobsDashboard.Tests
{
    public class AppTests
    {
        private JobsDashboard.App app; 
        private JobsDashboard.Core.Feeds feeds;
        private Mock<IFeed> feed;
    
        [SetUp]
        public void Setup()
        {
            feed = new Mock<IFeed>();
            var i = new Dictionary<string, IFeed>();
            i.Add("feed", feed.Object);
            feeds = new JobsDashboard.Core.Feeds(i);
            app = new App(feeds);
        }

        [Test]
        public void ShouldLoadFeedsWhenICallDownload()
        {
            this.feed.Setup(x => x.Load());

            app.Download();

            this.feed.Verify(x => x.Load());
        }
    }
}