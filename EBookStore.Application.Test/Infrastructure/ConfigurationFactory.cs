using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EBookStore.Application.Test.Infrastructure
{
    public class ConfigurationFactory
    {

        public static IConfiguration Create()
        {
            var config = new[]
            {
                new KeyValuePair<string, string>("AppTokenSecret", "GurwinderSinghSomalZaildarSecret")
            };

            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(config);

            return builder.Build();
        }
    }
}
