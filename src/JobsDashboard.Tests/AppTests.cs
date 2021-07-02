using NUnit.Framework;

namespace JobsDashboard.Tests
{
    public class AppTests
    {
        private App app; 
    
        [SetUp]
        public void Setup()
        {
            app = new App();
        }

        [Test]
        public void Test1()
        {
            app.Download();
        }
    }
}