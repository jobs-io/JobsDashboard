using System;
using JobsDashboard.Core;

namespace JobsDashboard
{
    public class App
    {
        public App(Feeds feeds)
        {
            feeds.Load();
        }
    }
}
