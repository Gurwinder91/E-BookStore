
using EBookStore.Persistence;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace EBookStore.Api.IntegrationTest.Infrastructure
{
    public class QueryTestFixture: IDisposable
    {
        public EBookStoreDbContext Context { get; private set; }

        public TestServer TestServer { get; private set; }

        public HttpClient Client { get; private set; }

        public QueryTestFixture()
        {
            TestServer = TestServerFactory.Create();
            Context = TestServer.Host.Services.GetService<EBookStoreDbContext>();
            EBookStoreContextFactory.Create(Context);
            Client = TestServer.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            TestServerFactory.Destroy(TestServer);
            EBookStoreContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
