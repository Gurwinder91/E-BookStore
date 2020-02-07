using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EBookStore.Api.IntegrationTest.Infrastructure
{
    internal class TestServerFactory
    {
        public static TestServer Create()
        {
            var path = Assembly.GetAssembly(typeof(TestServerFactory)).Location;
            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb => cb.AddJsonFile("appsettings.json"))
                .UseStartup<TestStartup>();

            return new TestServer(hostBuilder);
        }

        public static void Destroy(TestServer testServer)
        {
            testServer.Dispose();
        }
    }
}