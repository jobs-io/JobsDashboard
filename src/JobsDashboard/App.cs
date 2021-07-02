using System;
using JobsDashboard.Core;

namespace JobsDashboard
{
    public class App
    {
        private readonly Feeds feeds;
        public App(Feeds feeds)
        {
            this.feeds = feeds;
        }
        public void Download() {
            this.feeds.Load();
        }
    }
}
