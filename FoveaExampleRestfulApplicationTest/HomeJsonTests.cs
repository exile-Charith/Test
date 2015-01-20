using System;
using System.Net.Http;
using FoveaExampleRestfulApplication;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace FoveaExampleRestfulApplicationTest
{
    [TestFixture]
    public class HomeJsonTests
    {
        private void SetupDb()
        {
        }

        [Test]
        public void GetResponseRetrunsCorrectStatusCode()
        {
            const string baseAddress = "http://localhost:5000";

            using (var client = new HttpClient())
            using (WebApp.Start<Startup>(new StartOptions(baseAddress)))
            {
                client.BaseAddress = new Uri(baseAddress);
                var response = client.GetAsync("").Result;
                Assert.True(response.IsSuccessStatusCode, "Actual status code is: " + response.StatusCode);
            }
        }

        [Test]
        public void RepositoryAddsDataToDatabase()
        {
            SetupDb();
        }
    }
}