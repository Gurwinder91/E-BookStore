using EBookStore.Persistence;
using EBookStore.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Api.IntegrationTest.Infrastructure
{
    class EBookStoreContextFactory
    {
        public static void Create(EBookStoreDbContext context)
        {
            context.Database.EnsureCreated();
            EBookStoreDbInitializer.Initialize(context);           
        }

        public static void Destroy(EBookStoreDbContext context)
        {
            context.Dispose();
        }
    }
}
