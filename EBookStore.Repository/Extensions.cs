using EBookStore.Repository.IRepositories;
using EBookStore.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Repository
{
    public static class Extensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRespository>();
            services.AddScoped<IPurchasedBookRepository, PurchasedBookRepository>();
        }
    }
}
