using System.Collections.Generic;

namespace JobsDashboard.Core
{
    public class Feeds
    {
        private readonly IDictionary<string, IFeed> feeds;
        public Feeds(IDictionary<string, IFeed> feeds) {
            this.feeds = feeds;
        }

        public void Load() {
            foreach(var key in this.feeds.Keys) {
                this.feeds[key].Load();
            }
        }
    }
}   