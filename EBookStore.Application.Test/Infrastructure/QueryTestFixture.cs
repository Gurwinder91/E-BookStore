using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EBookStore.Application.Test.Infrastructure
{
    public class QueryTestFixture
    {
      
        public IConfiguration Configuration { get; private set; }

        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Configuration = ConfigurationFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
