
using EBookStore.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EBookStore.Api.IntegrationTest.Infrastructure
{
    internal class TestStartup : Startup
    {
        public TestStartup(IConfiguration config) : base(config)
        {
        }

        protected override void ConfigureJwtToken(IServiceCollection services)
        {

        }

        protected override void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<EBookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "EBookStoreInMemoryDb"));
        }

        protected override void ConfigureAuthentication(IApplicationBuilder app)
        {
            app.UseMiddleware<AutoAuthorizeMiddleware>();
        }

    }
}