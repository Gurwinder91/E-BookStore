using EBookStore.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Persistence
{
    public class EBookStoreDbContext : DbContext
    {
        public EBookStoreDbContext(DbContextOptions<EBookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EBookStoreDbContext).Assembly);
        }
    }
}
