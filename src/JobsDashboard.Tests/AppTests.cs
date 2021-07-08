using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace JobsDashboard.Tests
{
    public class AppTests
    {
        private JobsDashboard.App app; 
    
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldGetJobs() {
            new App().GetJobs();
        }
    }
}